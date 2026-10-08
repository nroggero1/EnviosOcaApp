using System;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using EnviosOcaApp.Models;
using System.IO;

namespace EnviosOcaApp.Services
{
    public class OcaRestService
    {
        private readonly AppSettings _settings;
        private readonly HttpClient _httpClient;

        // URL oficial de Producción de OCA ePak (Probando si el Firewall la deja pasar)
        private readonly string OcaApiUrl = "http://webservice.oca.com.ar/epak_tracking/Oep_TrackEPak.asmx";

        public OcaRestService(AppSettings settings)
        {
            _settings = settings;
            _httpClient = new HttpClient();
        }

        public async Task<OcaResponse> GenerarLoteRealAsync(EmpresaOca empresa, string remitente, System.Collections.Generic.List<EnvioOca> lote)
        {
            if (empresa == null) throw new ArgumentException("La empresa es obligatoria.");
            if (lote == null || lote.Count == 0) throw new ArgumentException("El lote no puede estar vacío.");

            // 1. Construir el XML_Datos interno que OCA exige
            var origenNode = new XElement("origen",
                new XAttribute("calle", empresa.CalleOrigen),
                new XAttribute("nro", empresa.NumeroOrigen),
                new XAttribute("piso", ""),
                new XAttribute("depto", ""),
                new XAttribute("cp", empresa.CpOrigen),
                new XAttribute("localidad", empresa.LocalidadOrigen),
                new XAttribute("provincia", empresa.ProvinciaOrigen),
                new XAttribute("contacto", ""),
                new XAttribute("email", ""),
                new XAttribute("solicitante", ""),
                new XAttribute("observaciones", ""),
                new XAttribute("centrocosto", empresa.CentroCosto),
                new XAttribute("idfranjahoraria", "1"),
                new XAttribute("idcentroimposicionorigen", "0"),
                new XAttribute("fecha", DateTime.Now.ToString("yyyyMMdd")),
                new XElement("envios")
            );

            var enviosNode = origenNode.Element("envios");

            foreach (var envio in lote)
            {
                var envioNode = new XElement("envio",
                    new XAttribute("idoperativa", envio.IdOperativa),
                    new XAttribute("nroremito", envio.Remito),
                    new XElement("destinatario",
                        new XAttribute("apellido", envio.NombreDestinatario),
                        new XAttribute("nombre", ""),
                        new XAttribute("calle", envio.Calle),
                        new XAttribute("nro", envio.Numero),
                        new XAttribute("piso", envio.Piso),
                        new XAttribute("depto", ""),
                        new XAttribute("localidad", envio.Localidad),
                        new XAttribute("provincia", envio.Provincia),
                        new XAttribute("cp", envio.CP),
                        new XAttribute("email", envio.Email),
                        new XAttribute("telefono", envio.Telefono),
                        new XAttribute("celular", ""), new XAttribute("idci", "0"),
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
                    new XAttribute("nrocuenta", empresa.NroCuenta),
                    new XAttribute("origen", "API")
                ),
                new XElement("origenes", origenNode)
            );

            string xmlDatosString = xmlDatos.ToString(SaveOptions.DisableFormatting);

            // 2. Construir el sobre SOAP con credenciales extraídas de config (appsettings o empresas.json)
            string usuarioOca = string.IsNullOrWhiteSpace(empresa.Usuario) ? "sschechtel@prevencionart.com.ar" : empresa.Usuario; 
            string passwordOca = string.IsNullOrWhiteSpace(empresa.Password) ? "Corresponsalia04" : empresa.Password;

            string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <IngresoORMultiplesRetiros_v2 xmlns=""#Oca_e_Pak"">
      <usr>{usuarioOca}</usr>
      <psw>{passwordOca}</psw>
      <xml_Datos><![CDATA[{xmlDatosString}]]></xml_Datos>
      <ConfirmarRetiro>false</ConfirmarRetiro>
      <ArchivoCliente></ArchivoCliente>
      <ArchivoProceso></ArchivoProceso>
    </IngresoORMultiplesRetiros_v2>
  </soap:Body>
</soap:Envelope>";

            var request = new HttpRequestMessage(HttpMethod.Post, OcaApiUrl);
            request.Headers.Add("SOAPAction", "\"#Oca_e_Pak/IngresoORMultiplesRetiros_v2\"");
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

            System.IO.File.WriteAllText(@"C:\Users\nroggero\OneDrive - Grupo Sancor Seguros\Escritorio\Automati\PruebaBot\EnviosOCA\UltimaPeticionOca.xml", soapEnvelope);

            // 3. Enviar a OCA
            var httpResponse = await _httpClient.SendAsync(request);
            string responseBody = await httpResponse.Content.ReadAsStringAsync();

            try
            {
                string debugPath = @"C:\Users\nroggero\OneDrive - Grupo Sancor Seguros\Escritorio\Automati\PruebaBot\EnviosOCA\UltimaRespuestaOca.xml";
                System.IO.File.WriteAllText(debugPath, responseBody);
            }
            catch { }

            var ocaRes = new OcaResponse();

            // 4. Parsear respuesta 
            try
            {
                var xdoc = XDocument.Parse(responseBody);
                XNamespace ns = "http://www.oca.com.ar/";
                
                var errorNode = xdoc.Descendants(ns + "Error").FirstOrDefault();
                if (errorNode == null) 
                    errorNode = xdoc.Descendants("Error").FirstOrDefault(); // Fallback sin namespace por las dudas

                if (errorNode != null)
                {
                    ocaRes.TieneErrores = true;
                    ocaRes.MensajeError = errorNode.Element(ns + "Descripcion")?.Value 
                                          ?? errorNode.Element("Descripcion")?.Value 
                                          ?? "Error desconocido devuelto por OCA.";
                    return ocaRes;
                }

                var resumenNode = xdoc.Descendants(ns + "Resumen").FirstOrDefault();
                if (resumenNode == null)
                    resumenNode = xdoc.Descendants("Resumen").FirstOrDefault();

                if (resumenNode != null)
                {
                    ocaRes.CodigoOperacion = resumenNode.Element(ns + "CodigoOperacion")?.Value 
                                             ?? resumenNode.Element("CodigoOperacion")?.Value 
                                             ?? "";
                }

                var enviosResult = xdoc.Descendants(ns + "Envio").ToList();
                if (enviosResult.Count == 0)
                    enviosResult = xdoc.Descendants("Envio").ToList();

                foreach (var env in enviosResult)
                {
                    string remito = env.Element(ns + "NumeroRemito")?.Value ?? env.Element("NumeroRemito")?.Value ?? "";
                    string numeroEnvio = env.Element(ns + "NumeroEnvio")?.Value ?? env.Element("NumeroEnvio")?.Value ?? "";

                    ocaRes.EnviosGenerados.Add(new OcaEnvioGenerado
                    {
                        NumeroRemito = remito,
                        NumeroEnvio = numeroEnvio
                    });
                }
            }
            catch (Exception ex)
            {
                ocaRes.TieneErrores = true;
                ocaRes.MensajeError = $"Fallo al parsear XML de OCA. Crudo: {responseBody.Substring(0, Math.Min(200, responseBody.Length))}... Exception: {ex.Message}";
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

            var request = new HttpRequestMessage(HttpMethod.Post, OcaApiUrl);
            request.Headers.Add("SOAPAction", "\"#Oca_e_Pak/Tracking_Pieza_ConIdEstado\"");
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

            var httpResponse = await _httpClient.SendAsync(request);
            string responseBody = await httpResponse.Content.ReadAsStringAsync();

            var xdoc = XDocument.Parse(responseBody);
            
            // OCA returns a diffgram dataset
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

            string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <GetPdfDeEtiquetasPorOrdenOrNumeroEnvio xmlns=""#Oca_e_Pak"">
      <idOrdenRetiro></idOrdenRetiro>
      <nroEnvio>{ordenOcaOTracking}</nroEnvio>
      <logisticaInversa></logisticaInversa>
    </GetPdfDeEtiquetasPorOrdenOrNumeroEnvio>
  </soap:Body>
</soap:Envelope>";

            var request = new HttpRequestMessage(HttpMethod.Post, OcaApiUrl);
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

            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Etiquetas_OCA");
            Directory.CreateDirectory(folder);

            string pdfPath = Path.Combine(folder, $"Etiqueta_{ordenOcaOTracking}.pdf");
            byte[] pdfBytes = Convert.FromBase64String(base64pdf);
            File.WriteAllBytes(pdfPath, pdfBytes);

            return pdfPath;
        }

        // Queda MOCK para la impresion porque OCA requiere otro endpoint SOAP y no tenemos credenciales para validar ZPL aún
        public async Task<string> ObtenerEtiquetaMockAsync(string ordenOcaOTracking)
        {
            await Task.Delay(1500);

            if (string.IsNullOrWhiteSpace(ordenOcaOTracking))
                throw new ArgumentException("El código no puede estar vacío.");

            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Etiquetas_OCA_Test");
            Directory.CreateDirectory(folder);

            string pdfPath = Path.Combine(folder, $"Etiqueta_{ordenOcaOTracking}.pdf");
            File.WriteAllText(pdfPath, $"[SIMULACION PDF PARA ETIQUETA OCA]\nOrden/Tracking: {ordenOcaOTracking}\nFecha: {DateTime.Now}\nCódigo de Barras ZPL: ^XA^FO50,50^B3N,N,100,Y,N^FD{ordenOcaOTracking}^FS^XZ");

            return pdfPath;
        }
    }
}
