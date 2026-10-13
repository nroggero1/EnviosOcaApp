using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EnviosOcaApp.Models;

namespace EnviosOcaApp.Services
{
    public class OcaRestService
    {
        private readonly AppSettings _settings;
        private readonly HttpClient _httpClient;

        public string BaseUrl => _settings?.OcaBaseUrl ?? "https://webservice.oca.com.ar/epak_tracking/Oep_TrackEPak.asmx";

        public OcaRestService(AppSettings settings)
        {
            _settings = settings;

            var handler = new HttpClientHandler
            {
                CheckCertificateRevocationList = false,
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler);
        }

        public async Task<bool> ActualizarUsuarioOcaAsync(string nombre, string apellido, EmpresaOca empresa = null)
        {
            try
            {
                string usuarioOca = (_settings != null && !_settings.EsProduccion)
                    ? "test@oca.com.ar"
                    : (empresa != null && !string.IsNullOrWhiteSpace(empresa.Usuario) ? empresa.Usuario : "sschechtel@prevencionart.com.ar");

                string passwordOca = (_settings != null && !_settings.EsProduccion)
                    ? "123456"
                    : (empresa != null && !string.IsNullOrWhiteSpace(empresa.Password) ? empresa.Password : "Corresponsalia04");

                // 1. Login contra el middleware de ePak para obtener JWT
                var loginPayload = new { email = usuarioOca, password = passwordOca };
                string loginJson = System.Text.Json.JsonSerializer.Serialize(loginPayload);
                var loginContent = new StringContent(loginJson, Encoding.UTF8, "application/json");

                var loginRes = await _httpClient.PostAsync("https://ocaepak.oca.com.ar/middleware/login", loginContent);
                if (!loginRes.IsSuccessStatusCode) return false;

                string loginRespBody = await loginRes.Content.ReadAsStringAsync();
                using var doc = System.Text.Json.JsonDocument.Parse(loginRespBody);
                if (!doc.RootElement.TryGetProperty("access_token", out var tokenProp)) return false;
                string token = tokenProp.GetString() ?? "";

                // 2. Preparar payload respetando validaciones mínimas de OCA
                string nomFinal = (nombre ?? "VICTOR").Trim();
                string apeFinal = (apellido ?? "CEJAS").Trim();
                if (nomFinal.Length < 3) nomFinal = nomFinal.PadRight(3, '.');
                if (apeFinal.Length < 4) apeFinal = apeFinal.PadRight(4, '.');

                var updatePayload = new
                {
                    Apellido = apeFinal.ToUpperInvariant(),
                    Nombre = nomFinal.ToUpperInvariant(),
                    Empresa = (empresa?.Nombre ?? "SANCOR SEGUROS").ToUpperInvariant(),
                    Contacto = (empresa?.ContactoOrigen ?? "CORRESPONSALIA").ToUpperInvariant(),
                    Calle = "LAINEZ",
                    Numero = "58",
                    Piso = "",
                    Depto = "",
                    IdCodPostal = 4069,
                    Localidad = "SUNCHALES",
                    eCorreo1 = usuarioOca,
                    Telefono = "3493420000"
                };

                string updateJson = System.Text.Json.JsonSerializer.Serialize(updatePayload);
                using var putRequest = new HttpRequestMessage(HttpMethod.Put, "https://ocaepak.oca.com.ar/middleware/user");
                putRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                putRequest.Content = new StringContent(updateJson, Encoding.UTF8, "application/json");

                var putRes = await _httpClient.SendAsync(putRequest);
                return putRes.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public Task<OcaResponse> GenerarLoteRealAsync(EmpresaOca empresa, string remitente, System.Collections.Generic.List<EnvioOca> lote)
        {
            string ape = remitente ?? "";
            string nom = "";
            if (!string.IsNullOrWhiteSpace(remitente) && remitente.Contains(" "))
            {
                var partes = remitente.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                ape = partes[0];
                nom = partes[1];
            }
            return GenerarLoteRealAsync(empresa, ape, nom, lote);
        }

        public async Task<OcaResponse> GenerarLoteRealAsync(EmpresaOca empresa, string remitenteApellido, string remitenteNombre, System.Collections.Generic.List<EnvioOca> lote)
        {
            if (empresa == null) throw new ArgumentException("La empresa es obligatoria.");
            if (lote == null || lote.Count == 0) throw new ArgumentException("El lote no puede estar vacío.");

            // Determinar credenciales según entorno QA / Producción
            string usuarioOca;
            string passwordOca;
            string nroCuenta;
            string operativa;

            if (_settings != null && !_settings.EsProduccion)
            {
                // Entorno QA oficial según developers.oca.com.ar/epak.html
                usuarioOca = !string.IsNullOrWhiteSpace(empresa.Usuario) ? empresa.Usuario : "test@oca.com.ar";
                passwordOca = !string.IsNullOrWhiteSpace(empresa.Password) ? empresa.Password : "123456";
                nroCuenta = !string.IsNullOrWhiteSpace(empresa.NroCuenta) ? empresa.NroCuenta : "111757/001";
                operativa = !string.IsNullOrWhiteSpace(empresa.Operativa) ? empresa.Operativa : "64665";
            }
            else
            {
                // Entorno PRODUCCIÓN
                usuarioOca = !string.IsNullOrWhiteSpace(empresa.Usuario) ? empresa.Usuario : "sschechtel@prevencionart.com.ar";
                passwordOca = !string.IsNullOrWhiteSpace(empresa.Password) ? empresa.Password : "Corresponsalia04";
                nroCuenta = empresa.NroCuenta;
                operativa = empresa.Operativa;
            }

            string contactoRetiro = !string.IsNullOrWhiteSpace(empresa.ContactoOrigen) ? empresa.ContactoOrigen : "CORRESPONSALIA";
            if (contactoRetiro.Length > 30) contactoRetiro = contactoRetiro.Substring(0, 30);

            string remitenteTextoCompleto = $"{remitenteApellido} {remitenteNombre}".Trim();
            string solicitanteRemitente = string.IsNullOrWhiteSpace(remitenteTextoCompleto) ? empresa.Nombre : remitenteTextoCompleto;
            if (solicitanteRemitente.Length > 30) solicitanteRemitente = solicitanteRemitente.Substring(0, 30);

            // 1. Construir el XML_Datos interno que OCA exige
            var origenNode = new XElement("origen",
                new XAttribute("calle", empresa.CalleOrigen ?? ""),
                new XAttribute("nro", empresa.NumeroOrigen ?? ""),
                new XAttribute("piso", ""),
                new XAttribute("depto", ""),
                new XAttribute("cp", empresa.CpOrigen ?? ""),
                new XAttribute("localidad", empresa.LocalidadOrigen ?? ""),
                new XAttribute("provincia", empresa.ProvinciaOrigen ?? ""),
                new XAttribute("contacto", contactoRetiro),
                new XAttribute("email", ""),
                new XAttribute("solicitante", solicitanteRemitente),
                new XAttribute("observaciones", ""),
                new XAttribute("centrocosto", empresa.CentroCosto ?? "1"),
                new XAttribute("idfranjahoraria", "1"),
                new XAttribute("idcentroimposicionorigen", "0"),
                new XAttribute("fecha", DateTime.Now.ToString("yyyyMMdd")),
                new XElement("envios")
            );

            var enviosNode = origenNode.Element("envios");

            foreach (var envio in lote)
            {
                // OCA exige que tanto apellido como nombre tengan datos (no vacíos)
                string nombreCompleto = envio.NombreDestinatario?.Trim() ?? "";
                string apellido = nombreCompleto;
                string nombre = "Destinatario";
                if (nombreCompleto.Contains(" "))
                {
                    var partes = nombreCompleto.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    apellido = partes[0];
                    nombre = partes[1];
                }

                if (apellido.Length > 30) apellido = apellido.Substring(0, 30);
                if (nombre.Length > 30) nombre = nombre.Substring(0, 30);

                string idOperativaFinal = (_settings != null && !_settings.EsProduccion)
                    ? "64665"
                    : (envio.IdOperativa > 0 ? envio.IdOperativa.ToString() : operativa);

                var envioNode = new XElement("envio",
                    new XAttribute("idoperativa", idOperativaFinal),
                    new XAttribute("nroremito", envio.Remito),
                    new XAttribute("cantidadremitos", "1"),
                    new XElement("destinatario",
                        new XAttribute("apellido", apellido),
                        new XAttribute("nombre", nombre),
                        new XAttribute("calle", envio.Calle ?? ""),
                        new XAttribute("nro", envio.Numero ?? ""),
                        new XAttribute("piso", envio.Piso ?? ""),
                        new XAttribute("depto", ""),
                        new XAttribute("localidad", envio.Localidad ?? ""),
                        new XAttribute("provincia", envio.Provincia ?? ""),
                        new XAttribute("cp", envio.CP ?? ""),
                        new XAttribute("email", envio.Email ?? ""),
                        new XAttribute("telefono", envio.Telefono ?? ""),
                        new XAttribute("idci", "0"),
                        new XAttribute("celular", envio.Telefono ?? ""),
                        new XAttribute("observaciones", "")
                    ),
                    new XElement("paquetes")
                );

                var paquetesNode = envioNode.Element("paquetes");
                foreach (var paquete in envio.Paquetes)
                {
                    paquetesNode.Add(new XElement("paquete",
                        new XAttribute("alto", paquete.Alto.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)),
                        new XAttribute("ancho", paquete.Ancho.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)),
                        new XAttribute("largo", paquete.Largo.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)),
                        new XAttribute("peso", paquete.Peso.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)),
                        new XAttribute("valor", paquete.Valor.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)),
                        new XAttribute("cant", "1")
                    ));
                }

                enviosNode.Add(envioNode);
            }

            var xmlDatos = new XElement("ROWS",
                new XElement("cabecera",
                    new XAttribute("ver", "2.0"),
                    new XAttribute("nrocuenta", nroCuenta),
                    new XAttribute("origen", "API")
                ),
                new XElement("origenes", origenNode)
            );

            string xmlDatosString = "<?xml version=\"1.0\" encoding=\"iso-8859-1\" standalone=\"yes\"?>\n" + xmlDatos.ToString(SaveOptions.DisableFormatting);

            var ocaRes = new OcaResponse();

            // 1. Actualizar titular en OCA al nombre del remitente antes de transmitir
            if (_settings == null || _settings.EsProduccion)
            {
                try
                {
                    await ActualizarUsuarioOcaAsync(remitenteNombre, remitenteApellido, empresa);
                }
                catch { }
            }

            try
            {
                var formValues = new System.Collections.Generic.Dictionary<string, string>
                {
                    { "usr", usuarioOca },
                    { "psw", passwordOca },
                    { "xml_Datos", xmlDatosString },
                    { "ConfirmarRetiro", "true" },
                    { "ArchivoCliente", "" },
                    { "ArchivoProceso", "" },
                    { "compatMode", "0" }
                };

                var formContent = new FormUrlEncodedContent(formValues);
                var httpResponse = await _httpClient.PostAsync($"{BaseUrl}/IngresoORMultiplesRetiros_v2", formContent);
                string responseBody = await httpResponse.Content.ReadAsStringAsync();

                var xdoc = XDocument.Parse(responseBody);

                // 1. Verificar si hay errores explícitos
                var errorNode = xdoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "Error");
                if (errorNode != null)
                {
                    string msgError = errorNode.Element("Descripcion")?.Value
                        ?? errorNode.Element(errorNode.Name.Namespace + "Descripcion")?.Value
                        ?? "Error desconocido devuelto por OCA.";

                    ocaRes.TieneErrores = true;
                    ocaRes.MensajeError = msgError;
                    return ocaRes;
                }

                // 2. Extraer Resumen
                var resumenNode = xdoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "Resumen");
                if (resumenNode != null)
                {
                    ocaRes.CodigoOperacion = resumenNode.Element("CodigoOperacion")?.Value
                        ?? resumenNode.Element(resumenNode.Name.Namespace + "CodigoOperacion")?.Value
                        ?? "";
                }

                // 3. Verificar si hay rechazos por remito
                var detalleRechazos = xdoc.Descendants().Where(x => x.Name.LocalName == "DetalleRechazos").ToList();
                if (detalleRechazos.Count > 0)
                {
                    ocaRes.TieneErrores = true;
                    var rechazos = detalleRechazos.Select(r =>
                    {
                        string remito = r.Element("Remito")?.Value ?? r.Element(r.Name.Namespace + "Remito")?.Value ?? "";
                        string motivo = r.Element("Motivo")?.Value ?? r.Element(r.Name.Namespace + "Motivo")?.Value ?? "";
                        return $"Remito {remito}: {motivo}";
                    });
                    ocaRes.MensajeError = string.Join("; ", rechazos);
                    return ocaRes;
                }

                // 4. Extraer envíos ingresados exitosamente
                var detalleIngresos = xdoc.Descendants().Where(x => x.Name.LocalName == "DetalleIngresos").ToList();
                foreach (var det in detalleIngresos)
                {
                    string remito = det.Element("Remito")?.Value ?? det.Element(det.Name.Namespace + "Remito")?.Value ?? "";
                    string numeroEnvio = det.Element("NumeroEnvio")?.Value ?? det.Element(det.Name.Namespace + "NumeroEnvio")?.Value ?? "";
                    string ordenRetiro = det.Element("OrdenRetiro")?.Value ?? det.Element(det.Name.Namespace + "OrdenRetiro")?.Value ?? "";

                    ocaRes.EnviosGenerados.Add(new OcaEnvioGenerado
                    {
                        NumeroRemito = remito,
                        NumeroEnvio = numeroEnvio,
                        OrdenRetiro = ordenRetiro
                    });
                }

                // Si no devolvió DetalleIngresos pero sí CodigoOperacion (por ejemplo en carritos)
                if (ocaRes.EnviosGenerados.Count == 0 && !string.IsNullOrWhiteSpace(ocaRes.CodigoOperacion))
                {
                    for (int i = 0; i < lote.Count; i++)
                    {
                        ocaRes.EnviosGenerados.Add(new OcaEnvioGenerado
                        {
                            NumeroRemito = lote[i].Remito,
                            NumeroEnvio = ocaRes.CodigoOperacion,
                            OrdenRetiro = ocaRes.CodigoOperacion
                        });
                    }
                }

                // 5. Descargar/precargar de inmediato el PDF de las etiquetas para guardarlas en disco
                if (!ocaRes.TieneErrores && ocaRes.EnviosGenerados.Count > 0)
                {
                    foreach (var guia in ocaRes.EnviosGenerados)
                    {
                        if (!string.IsNullOrWhiteSpace(guia.NumeroEnvio))
                        {
                            try
                            {
                                await ObtenerEtiquetaPdfAsync(guia.NumeroEnvio);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ocaRes.TieneErrores = true;
                ocaRes.MensajeError = "Fallo al enviar datos a OCA. Exception: " + ex.Message;
            }
            finally
            {
                // 2. RESTAURAR SIEMPRE EL TITULAR AL USUARIO INICIAL "VICTOR CEJAS"
                if (_settings == null || _settings.EsProduccion)
                {
                    try
                    {
                        await ActualizarUsuarioOcaAsync("VICTOR", "CEJAS", empresa);
                    }
                    catch { }
                }
            }

            return ocaRes;
        }

        public async Task<DataTable> ObtenerTrackingAsync(string numeroEnvio)
        {
            if (string.IsNullOrWhiteSpace(numeroEnvio))
                throw new ArgumentException("El número de envío no puede estar vacío.");

            string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <Tracking_Pieza_ConIdEstado xmlns=""#Oca_e_Pak"">
      <NumeroEnvio>{numeroEnvio}</NumeroEnvio>
    </Tracking_Pieza_ConIdEstado>
  </soap:Body>
</soap:Envelope>";

            var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);
            request.Headers.Add("SOAPAction", "\"#Oca_e_Pak/Tracking_Pieza_ConIdEstado\"");
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

            var httpResponse = await _httpClient.SendAsync(request);
            string responseBody = await httpResponse.Content.ReadAsStringAsync();

            var xdoc = XDocument.Parse(responseBody);
            
            var diffgram = xdoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "diffgram");
            
            if (diffgram == null || !diffgram.HasElements)
            {
                return null;
            }

            var newDataSet = diffgram.Elements().FirstOrDefault(x => x.Name.LocalName == "NewDataSet");
            if (newDataSet == null || !newDataSet.HasElements)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Estado");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Sucursal");

            foreach (var row in newDataSet.Elements())
            {
                var estado = row.Element("Estado")?.Value ?? row.Element(newDataSet.Name.Namespace + "Estado")?.Value;
                var fecha = row.Element("Fecha")?.Value ?? row.Element(newDataSet.Name.Namespace + "Fecha")?.Value;
                var sucursal = row.Element("Sucursal")?.Value ?? row.Element(newDataSet.Name.Namespace + "Sucursal")?.Value;

                dt.Rows.Add(estado, fecha, sucursal);
            }

            return dt;
        }

        public async Task<string> ObtenerEtiquetaPdfAsync(string ordenOcaOTracking)
        {
            if (string.IsNullOrWhiteSpace(ordenOcaOTracking))
                throw new ArgumentException("El código no puede estar vacío.");

            if (ordenOcaOTracking.StartsWith("MOCK-"))
            {
                await Task.Delay(1000);
                string folderMock = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Etiquetas_OCA");
                Directory.CreateDirectory(folderMock);
                string pdfPathMock = Path.Combine(folderMock, $"Etiqueta_{ordenOcaOTracking}.pdf");
                File.WriteAllText(pdfPathMock, $"[SIMULACION PDF PARA ETIQUETA OCA]\nOrden/Tracking: {ordenOcaOTracking}\nFecha: {DateTime.Now}\nCódigo de Barras ZPL: ^XA^FO50,50^B3N,N,100,Y,N^FD{ordenOcaOTracking}^FS^XZ");
                return pdfPathMock;
            }

            string idOrdenRetiroTag = "<idOrdenRetiro></idOrdenRetiro>";
            string nroEnvioTag = $"<nroEnvio>{ordenOcaOTracking}</nroEnvio>";

            if (ordenOcaOTracking.Length <= 10 && long.TryParse(ordenOcaOTracking, out _))
            {
                idOrdenRetiroTag = $"<idOrdenRetiro>{ordenOcaOTracking}</idOrdenRetiro>";
                nroEnvioTag = "<nroEnvio></nroEnvio>";
            }

            string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <GetPdfDeEtiquetasPorOrdenOrNumeroEnvio xmlns=""#Oca_e_Pak"">
      {idOrdenRetiroTag}
      {nroEnvioTag}
      <logisticaInversa></logisticaInversa>
    </GetPdfDeEtiquetasPorOrdenOrNumeroEnvio>
  </soap:Body>
</soap:Envelope>";

            var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);
            request.Headers.Add("SOAPAction", "\"#Oca_e_Pak/GetPdfDeEtiquetasPorOrdenOrNumeroEnvio\"");
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

            var httpResponse = await _httpClient.SendAsync(request);
            string responseBody = await httpResponse.Content.ReadAsStringAsync();

            var xdoc = XDocument.Parse(responseBody);
            
            var resultNode = xdoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "GetPdfDeEtiquetasPorOrdenOrNumeroEnvioResult");

            if (resultNode == null)
            {
                throw new Exception("No se pudo obtener el resultado del PDF de OCA.");
            }

            string base64pdf = resultNode.Value;

            if (string.IsNullOrWhiteSpace(base64pdf) || base64pdf.Contains("No se encontraron etiquetas"))
            {
                throw new Exception("OCA respondió que no se encontraron etiquetas para el número de envío indicado.");
            }
            
            if (base64pdf.Length < 100)
            {
                throw new Exception($"Error de OCA al obtener etiqueta: {base64pdf}");
            }

            string folder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Etiquetas_OCA");
            System.IO.Directory.CreateDirectory(folder);

            string pdfPath = System.IO.Path.Combine(folder, $"Etiqueta_{ordenOcaOTracking}.pdf");
            byte[] pdfBytes = Convert.FromBase64String(base64pdf);
            System.IO.File.WriteAllBytes(pdfPath, pdfBytes);

            return pdfPath;
        }

        public async Task<(bool Exito, string Mensaje)> AnularOrdenGeneradaAsync(int idOrdenRetiro)
        {
            string usuarioOca = (_settings != null && !_settings.EsProduccion)
                ? "test@oca.com.ar"
                : "sschechtel@prevencionart.com.ar";

            string passwordOca = (_settings != null && !_settings.EsProduccion)
                ? "123456"
                : "Corresponsalia04";

            var formValues = new System.Collections.Generic.Dictionary<string, string>
            {
                { "usr", usuarioOca },
                { "psw", passwordOca },
                { "IdOrdenRetiro", idOrdenRetiro.ToString() }
            };

            var formContent = new FormUrlEncodedContent(formValues);
            var response = await _httpClient.PostAsync($"{BaseUrl}/AnularOrdenGenerada", formContent);
            string responseBody = await response.Content.ReadAsStringAsync();

            var xdoc = XDocument.Parse(responseBody);
            var tableNode = xdoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "Table");
            if (tableNode != null)
            {
                string idResultStr = tableNode.Element("IdResult")?.Value
                    ?? tableNode.Element(tableNode.Name.Namespace + "IdResult")?.Value
                    ?? "0";

                string mensaje = tableNode.Element("Mensaje")?.Value
                    ?? tableNode.Element(tableNode.Name.Namespace + "Mensaje")?.Value
                    ?? "Sin mensaje devuelto por OCA.";

                int.TryParse(idResultStr, out int idResult);
                // Si la orden fue anulada exitosamente o el mensaje lo indica
                bool exito = idResult == 1 || mensaje.ToLower().Contains("anulada") || mensaje.ToLower().Contains("éxito") || mensaje.ToLower().Contains("exito");
                return (exito, mensaje);
            }

            return (false, "Respuesta no reconocida de OCA.");
        }

        public async Task<OcaResponse> GenerarLoteMockAsync(string cuitEmpresa, string remitente, System.Collections.Generic.List<EnvioOca> lote)
        {
            await Task.Delay(1500);

            if (string.IsNullOrWhiteSpace(cuitEmpresa))
                throw new ArgumentException("El CUIT de la empresa es obligatorio.");

            if (lote == null || lote.Count == 0)
                throw new ArgumentException("El lote no puede estar vacío.");

            var response = new OcaResponse
            {
                TieneErrores = false,
                CodigoOperacion = "MOCK-OP-" + DateTime.Now.Ticks.ToString()
            };

            foreach (var envio in lote)
            {
                response.EnviosGenerados.Add(new OcaEnvioGenerado
                {
                    NumeroRemito = envio.Remito,
                    NumeroEnvio = "32111" + DateTime.Now.ToString("yyMMddHHmm") + new Random().Next(1000, 9999).ToString()
                });
            }

            return response;
        }
    }
}
