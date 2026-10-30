using System;
using System.IO;
using ClosedXML.Excel;
using EnviosOcaApp.Models;

namespace EnviosOcaApp.Services
{
    public class ExcelAuditoriaService
    {
        private readonly AppSettings _settings;

        public ExcelAuditoriaService(AppSettings settings)
        {
            _settings = settings;
            try
            {
                Directory.CreateDirectory(_settings.ObtenerDirectorioAuditoriaEtiquetas());
                Directory.CreateDirectory(_settings.ObtenerDirectorioAuditoriaNavegacion());
            }
            catch
            {
                // Si la red tiene demora o no está disponible en el milisegundo de inicio, no bloqueamos el arranque
            }
        }

        private bool EsAdministrador(string currentUser)
        {
            try
            {
                string jsonPath = _settings?.ObtenerRutaUsuariosCompleta() 
                    ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "usuarios.json");
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    var usuarios = System.Text.Json.JsonSerializer.Deserialize<System.Collections.Generic.List<UsuarioApp>>(json);
                    var user = usuarios?.FirstOrDefault(u => u.UsernameWindows.Equals(currentUser, StringComparison.OrdinalIgnoreCase));
                    return user != null && user.EsAdministrador;
                }
            }
            catch
            {
                // Ignorar si hay error al leer el archivo
            }
            return false;
        }

        private void ExecuteWithRetry(Action action, int maxAttempts = 10)
        {
            int delay = 300;
            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    action();
                    return; // Exito, salimos del retry
                }
                catch (IOException)
                {
                    if (i == maxAttempts - 1)
                        throw; // Si es el último intento, dejamos que falle
                    
                    System.Threading.Thread.Sleep(delay + new Random().Next(50, 150)); // Jitter para evitar colisiones en cadena
                }
            }
        }

        public void RegistrarGeneracionEtiqueta(string empresa, string nroOrdenOca, string remitente, string destinatario, string estado)
        {
            ExecuteWithRetry(() =>
            {
                var dirEtiquetas = _settings.ObtenerDirectorioAuditoriaEtiquetas();
                if (!Directory.Exists(dirEtiquetas))
                    Directory.CreateDirectory(dirEtiquetas);

                var mesActual = DateTime.Now.ToString("yyyy_MM");
                var archivoPath = Path.Combine(dirEtiquetas, $"auditoria_{mesActual}.xlsx");

                var usuario = Environment.UserName.ToUpper();
                var fecha = DateTime.Now.ToString("dd/MM/yyyy");
                var hora = DateTime.Now.ToString("HH:mm:ss");

                bool archivoExiste = File.Exists(archivoPath);

                using (var workbook = archivoExiste ? new XLWorkbook(archivoPath) : new XLWorkbook())
                {
                    var worksheet = archivoExiste ? workbook.Worksheet(1) : workbook.Worksheets.Add("Auditoria");

                    // Asegurar que la Fila 1 siempre contenga los encabezados
                    bool tieneEncabezados = !worksheet.Cell(1, 1).IsEmpty() && 
                                            worksheet.Cell(1, 1).GetString().Trim().Equals("Fecha", StringComparison.OrdinalIgnoreCase);

                    if (!tieneEncabezados)
                    {
                        // Si la fila 1 tenía datos porque se creó antes sin encabezados, insertamos una fila arriba
                        if (!worksheet.Cell(1, 1).IsEmpty())
                        {
                            worksheet.Row(1).InsertRowsAbove(1);
                        }

                        worksheet.Cell(1, 1).Value = "Fecha";
                        worksheet.Cell(1, 2).Value = "Hora";
                        worksheet.Cell(1, 3).Value = "Usuario_Sistema";
                        worksheet.Cell(1, 4).Value = "Empresa_Seleccionada";
                        worksheet.Cell(1, 5).Value = "Nro_Orden_OCA";
                        worksheet.Cell(1, 6).Value = "Remitente";
                        worksheet.Cell(1, 7).Value = "Destinatario";
                        worksheet.Cell(1, 8).Value = "Estado_Operacion";
                        worksheet.Cell(1, 9).Value = "Fecha_Modificacion";
                        worksheet.Cell(1, 10).Value = "Usuario_Modificacion";

                        var range = worksheet.Range("A1:J1");
                        range.Style.Font.Bold = true;
                        range.Style.Fill.BackgroundColor = XLColor.FromArgb(167, 3, 85); // Magenta institucional OCA
                        range.Style.Font.FontColor = XLColor.White;
                        range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }

                    var ultimaFila = worksheet.LastRowUsed()?.RowNumber() ?? 1;
                    var nuevaFila = ultimaFila + 1;

                    worksheet.Cell(nuevaFila, 1).Value = fecha;
                    worksheet.Cell(nuevaFila, 2).Value = hora;
                    worksheet.Cell(nuevaFila, 3).Value = usuario;
                    worksheet.Cell(nuevaFila, 4).Value = empresa;
                    worksheet.Cell(nuevaFila, 5).Value = nroOrdenOca;
                    worksheet.Cell(nuevaFila, 6).Value = remitente;
                    worksheet.Cell(nuevaFila, 7).Value = destinatario;
                    worksheet.Cell(nuevaFila, 8).Value = estado;
                    worksheet.Cell(nuevaFila, 9).Value = "";
                    worksheet.Cell(nuevaFila, 10).Value = "";

                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(archivoPath);
                }
            });
        }

        public void ActualizarEstadoOrden(string nroOrdenOca, string nuevoEstado, string? usuarioModifica = null)
        {
            if (string.IsNullOrWhiteSpace(nroOrdenOca)) return;

            ExecuteWithRetry(() =>
            {
                var dirEtiquetas = _settings.ObtenerDirectorioAuditoriaEtiquetas();
                if (!Directory.Exists(dirEtiquetas)) return;
                var archivos = Directory.GetFiles(dirEtiquetas, "auditoria_*.xlsx");
                foreach (var archivoPath in archivos)
                {
                    using (var workbook = new XLWorkbook(archivoPath))
                    {
                        var ws = workbook.Worksheet(1);
                        bool modificado = false;

                        // Asegurar encabezados en caso de archivo previo sin cabecera
                        bool tieneEncabezados = !ws.Cell(1, 1).IsEmpty() && 
                                                ws.Cell(1, 1).GetString().Trim().Equals("Fecha", StringComparison.OrdinalIgnoreCase);
                        if (!tieneEncabezados && !ws.Cell(1, 1).IsEmpty())
                        {
                            ws.Row(1).InsertRowsAbove(1);
                            ws.Cell(1, 1).Value = "Fecha";
                            ws.Cell(1, 2).Value = "Hora";
                            ws.Cell(1, 3).Value = "Usuario_Sistema";
                            ws.Cell(1, 4).Value = "Empresa_Seleccionada";
                            ws.Cell(1, 5).Value = "Nro_Orden_OCA";
                            ws.Cell(1, 6).Value = "Remitente";
                            ws.Cell(1, 7).Value = "Destinatario";
                            ws.Cell(1, 8).Value = "Estado_Operacion";
                            ws.Cell(1, 9).Value = "Fecha_Modificacion";
                            ws.Cell(1, 10).Value = "Usuario_Modificacion";
                            var range = ws.Range("A1:J1");
                            range.Style.Font.Bold = true;
                            range.Style.Fill.BackgroundColor = XLColor.FromArgb(167, 3, 85);
                            range.Style.Font.FontColor = XLColor.White;
                        }

                        foreach (var row in ws.RowsUsed())
                        {
                            if (row.RowNumber() == 1) continue;
                            string colOrden = row.Cell(5).Value.ToString().Trim();
                            string colDest = row.Cell(7).Value.ToString();
                            if (colOrden.Equals(nroOrdenOca.Trim(), StringComparison.OrdinalIgnoreCase) ||
                                colDest.Contains(nroOrdenOca.Trim()))
                            {
                                row.Cell(8).Value = nuevoEstado;
                                row.Cell(9).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                                row.Cell(10).Value = !string.IsNullOrWhiteSpace(usuarioModifica) ? usuarioModifica.ToUpper() : Environment.UserName.ToUpper();
                                modificado = true;
                            }
                        }
                        if (modificado)
                        {
                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(archivoPath);
                        }
                    }
                }
            });
        }

        public System.Data.DataTable ObtenerHistorial(DateTime? desde = null, DateTime? hasta = null, string? usuario = null, bool isAdmin = false)
        {
            var dt = new System.Data.DataTable();
            bool headersAdded = false;

            if (!isAdmin)
            {
                usuario = Environment.UserName; // Forzar filtro al usuario actual si no es admin
            }

            var dirEtiquetas = _settings.ObtenerDirectorioAuditoriaEtiquetas();
            if (!Directory.Exists(dirEtiquetas)) return dt;
            
            var archivos = Directory.GetFiles(dirEtiquetas, "auditoria_*.xlsx");

            foreach (var archivoPath in archivos)
            {
                try
                {
                    ExecuteWithRetry(() => 
                    {
                        using (var stream = new FileStream(archivoPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (var workbook = new XLWorkbook(stream))
                        {
                            var ws = workbook.Worksheet(1);
                            bool firstRow = true;

                            foreach (var row in ws.RowsUsed())
                            {
                                if (firstRow)
                                {
                                    if (!headersAdded)
                                    {
                                        foreach (var cell in row.Cells())
                                            dt.Columns.Add(cell.Value.ToString());
                                        headersAdded = true;
                                    }
                                    firstRow = false;
                                }
                                else
                                {
                                    string fechaStr = row.Cell(1).Value.ToString();
                                    string rowUser = row.Cell(3).Value.ToString();
                                    
                                    // Filtro de Fecha
                                    bool fechaValida = true;
                                    if (DateTime.TryParseExact(fechaStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaFila))
                                    {
                                        if (desde.HasValue && fechaFila.Date < desde.Value.Date) fechaValida = false;
                                        if (hasta.HasValue && fechaFila.Date > hasta.Value.Date) fechaValida = false;
                                    }

                                    // Filtro de Usuario
                                    bool usuarioValido = true;
                                    if (!string.IsNullOrWhiteSpace(usuario))
                                    {
                                        if (!string.Equals(rowUser, usuario, StringComparison.OrdinalIgnoreCase))
                                            usuarioValido = false;
                                    }

                                    if (fechaValida && usuarioValido)
                                    {
                                        dt.Rows.Add();
                                        int i = 0;
                                        foreach (var cell in row.Cells(1, dt.Columns.Count))
                                        {
                                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                            i++;
                                        }
                                    }
                                }
                            }
                        }
                    });
                }
                catch { }
            }
            
            // Invertir las filas para que los más recientes salgan primero
            var dtInvertido = dt.Clone();
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                dtInvertido.ImportRow(dt.Rows[i]);
            }

            return dtInvertido;
        }

        public System.Collections.Generic.List<string> ObtenerUsuariosUnicos()
        {
            var usuarios = new System.Collections.Generic.HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var dirEtiquetas = _settings.ObtenerDirectorioAuditoriaEtiquetas();
            if (!Directory.Exists(dirEtiquetas)) return new System.Collections.Generic.List<string>();

            var archivos = Directory.GetFiles(dirEtiquetas, "auditoria_*.xlsx");
            foreach (var archivoPath in archivos)
            {
                try
                {
                    ExecuteWithRetry(() => 
                    {
                        using (var stream = new FileStream(archivoPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (var workbook = new XLWorkbook(stream))
                        {
                            var ws = workbook.Worksheet(1);
                            bool firstRow = true;
                            foreach (var row in ws.RowsUsed())
                            {
                                if (firstRow) { firstRow = false; continue; }
                                string rowUser = row.Cell(3).Value.ToString();
                                if (!string.IsNullOrWhiteSpace(rowUser)) usuarios.Add(rowUser);
                            }
                        }
                    });
                }
                catch { }
            }
            var list = System.Linq.Enumerable.ToList(usuarios);
            list.Sort();
            return list;
        }

        public void RegistrarNavegacion(string modulo, string accion)
        {
            try
            {
                ExecuteWithRetry(() =>
                {
                    var mesActual = DateTime.Now.ToString("yyyy_MM");
                    var dirNavegacion = _settings.ObtenerDirectorioAuditoriaNavegacion();
                    if (!Directory.Exists(dirNavegacion))
                        Directory.CreateDirectory(dirNavegacion);

                    var archivoPath = Path.Combine(dirNavegacion, $"navegacion_{mesActual}.csv");

                    var usuario = Environment.UserName.ToUpper();
                    var fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    var hora = DateTime.Now.ToString("HH:mm:ss");

                    // Codificación UTF-8 con BOM obligatorio para que Excel en Windows muestre tildes y caracteres en español correctamente
                    var utf8ConBom = new System.Text.UTF8Encoding(true);

                    bool archivoExiste = File.Exists(archivoPath);
                    bool tieneContenido = archivoExiste && new FileInfo(archivoPath).Length > 0;

                    if (!tieneContenido)
                    {
                        string encabezado = "Fecha,Hora,Usuario,Modulo,Accion\r\n";
                        File.WriteAllText(archivoPath, encabezado, utf8ConBom);
                    }
                    else
                    {
                        // Si el archivo ya existía pero no tenía el encabezado 'Fecha', lo agregamos al principio
                        try
                        {
                            string primerLinea = "";
                            using (var reader = new StreamReader(archivoPath, System.Text.Encoding.Default, true))
                            {
                                primerLinea = reader.ReadLine() ?? "";
                            }
                            if (!primerLinea.StartsWith("Fecha", StringComparison.OrdinalIgnoreCase))
                            {
                                string contenidoPrevio = File.ReadAllText(archivoPath, System.Text.Encoding.UTF8);
                                string nuevoContenido = "Fecha,Hora,Usuario,Modulo,Accion\r\n" + contenidoPrevio;
                                File.WriteAllText(archivoPath, nuevoContenido, utf8ConBom);
                            }
                        }
                        catch { }
                    }

                    // Escapar comillas dobles para formato CSV estándar
                    string accionEscapada = accion.Replace("\"", "\"\"");
                    string linea = $"{fecha},{hora},{usuario},{modulo},\"{accionEscapada}\"\r\n";

                    File.AppendAllText(archivoPath, linea, utf8ConBom);
                });
            }
            catch
            {
                // Ignoramos errores de log de navegación para no bloquear la app
            }
        }
    }
}
