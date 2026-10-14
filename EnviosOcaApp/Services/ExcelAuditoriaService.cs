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
            Directory.CreateDirectory(_settings.ObtenerDirectorioAuditoriaEtiquetas());
            Directory.CreateDirectory(_settings.ObtenerDirectorioAuditoriaNavegacion());
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
                        throw; // Si es el Ãºltimo intento, dejamos que falle
                    
                    System.Threading.Thread.Sleep(delay + new Random().Next(50, 150)); // Jitter para evitar colisiones en cadena
                }
            }
        }

        public void RegistrarGeneracionEtiqueta(string empresa, string nroOrdenOca, string remitente, string destinatario, string estado)
        {
            ExecuteWithRetry(() =>
            {
                var mesActual = DateTime.Now.ToString("yyyy_MM");
                var archivoPath = Path.Combine(_settings.ObtenerDirectorioAuditoriaEtiquetas(), $"auditoria_{mesActual}.xlsx");

                var usuario = Environment.UserName;
                var fecha = DateTime.Now.ToString("dd/MM/yyyy");
                var hora = DateTime.Now.ToString("HH:mm:ss");

                bool archivoExiste = File.Exists(archivoPath);

                using (var workbook = archivoExiste ? new XLWorkbook(archivoPath) : new XLWorkbook())
                {
                    var worksheet = archivoExiste ? workbook.Worksheet(1) : workbook.Worksheets.Add("Auditoria");

                    if (!archivoExiste)
                    {
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
                        range.Style.Fill.BackgroundColor = XLColor.LightGray;
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
                if (!Directory.Exists(_settings.ObtenerDirectorioAuditoriaEtiquetas())) return;
                var archivos = Directory.GetFiles(_settings.ObtenerDirectorioAuditoriaEtiquetas(), "auditoria_*.xlsx");
                foreach (var archivoPath in archivos)
                {
                    using (var workbook = new XLWorkbook(archivoPath))
                    {
                        var ws = workbook.Worksheet(1);
                        bool modificado = false;

                        // Asegurar encabezados para fecha y usuario de modificación
                        if (ws.Cell(1, 9).IsEmpty() || ws.Cell(1, 9).Value.ToString() != "Fecha_Modificacion")
                        {
                            ws.Cell(1, 9).Value = "Fecha_Modificacion";
                            ws.Cell(1, 9).Style.Font.Bold = true;
                            ws.Cell(1, 9).Style.Fill.BackgroundColor = XLColor.LightGray;
                        }
                        if (ws.Cell(1, 10).IsEmpty() || ws.Cell(1, 10).Value.ToString() != "Usuario_Modificacion")
                        {
                            ws.Cell(1, 10).Value = "Usuario_Modificacion";
                            ws.Cell(1, 10).Style.Font.Bold = true;
                            ws.Cell(1, 10).Style.Fill.BackgroundColor = XLColor.LightGray;
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
                                row.Cell(10).Value = !string.IsNullOrWhiteSpace(usuarioModifica) ? usuarioModifica : Environment.UserName;
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

        public System.Data.DataTable ObtenerHistorial(DateTime? desde = null, DateTime? hasta = null, string usuario = null, bool isAdmin = false)
        {
            var dt = new System.Data.DataTable();
            bool headersAdded = false;

            if (!isAdmin)
            {
                usuario = Environment.UserName; // Forzar filtro al usuario actual si no es admin
            }

            if (!Directory.Exists(_settings.ObtenerDirectorioAuditoriaEtiquetas())) return dt;
            
            var archivos = Directory.GetFiles(_settings.ObtenerDirectorioAuditoriaEtiquetas(), "auditoria_*.xlsx");

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
            // Optional sorting by combining Fecha y Hora can be complex with strings, so just reversing order as it was:
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                dtInvertido.ImportRow(dt.Rows[i]);
            }

            return dtInvertido;
        }

        public System.Collections.Generic.List<string> ObtenerUsuariosUnicos()
        {
            var usuarios = new System.Collections.Generic.HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (!Directory.Exists(_settings.ObtenerDirectorioAuditoriaEtiquetas())) return new System.Collections.Generic.List<string>();

            var archivos = Directory.GetFiles(_settings.ObtenerDirectorioAuditoriaEtiquetas(), "auditoria_*.xlsx");
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
                    var archivoPath = Path.Combine(_settings.ObtenerDirectorioAuditoriaNavegacion(), $"navegacion_{mesActual}.csv");
                    
                    var usuario = Environment.UserName;
                    var timestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                    string linea = $"{timestamp},{usuario},{modulo},{accion}\n";
                    File.AppendAllText(archivoPath, linea);
                });
            }
            catch
            {
                // Ignoramos errores de log de navegaciÃ³n para no bloquear la app
            }
        }
    }
}


