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
            Directory.CreateDirectory(_settings.DirectorioAuditoriaEtiquetas);
            Directory.CreateDirectory(_settings.DirectorioAuditoriaNavegacion);
        }

        private bool EsAdministrador(string currentUser)
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "usuarios.json");
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    
                    // Verificación flexible: si el usuario de red actual está en el mail o en el nombre
                    if (json.Contains(currentUser, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                // Ignorar si hay error al leer el archivo
            }
            return false;
        }

        public void RegistrarGeneracionEtiqueta(string empresa, string nroOrdenOca, string remitente, string destinatario, string estado)
        {
            var mesActual = DateTime.Now.ToString("yyyy_MM");
            var archivoPath = Path.Combine(_settings.DirectorioAuditoriaEtiquetas, $"auditoria_{mesActual}.xlsx");

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

                    var range = worksheet.Range("A1:H1");
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

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(archivoPath);
            }
        }
        public System.Data.DataTable ObtenerHistorialMensual()
        {
            var dt = new System.Data.DataTable();
            var mesActual = DateTime.Now.ToString("yyyy_MM");
            var archivoPath = Path.Combine(_settings.DirectorioAuditoriaEtiquetas, $"auditoria_{mesActual}.xlsx");

            if (!File.Exists(archivoPath))
                return dt; // Retorna vacio si no hay auditoria este mes

            try
            {
                using (var workbook = new XLWorkbook(archivoPath))
                {
                    var ws = workbook.Worksheet(1);
                    bool firstRow = true;
                    
                    var currentUser = Environment.UserName;
                    bool isAdmin = EsAdministrador(currentUser);

                    foreach (var row in ws.RowsUsed())
                    {
                        if (firstRow)
                        {
                            foreach (var cell in row.Cells())
                                dt.Columns.Add(cell.Value.ToString());
                            firstRow = false;
                        }
                        else
                        {
                            string rowUser = row.Cell(3).Value.ToString(); // Usuario_Sistema es columna 3
                            
                            if (isAdmin || string.Equals(rowUser, currentUser, StringComparison.OrdinalIgnoreCase))
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
            }
            catch (Exception)
            {
                // Manejar archivo bloqueado u otro error devolviendo lo leido hasta ahora
            }
            
            // Invertir las filas para que los más recientes salgan primero
            var dtInvertido = dt.Clone();
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                dtInvertido.ImportRow(dt.Rows[i]);
            }

            return dtInvertido;
        }
        public void RegistrarNavegacion(string modulo, string accion)
        {
            try
            {
                var mesActual = DateTime.Now.ToString("yyyy_MM");
                var archivoPath = Path.Combine(_settings.DirectorioAuditoriaNavegacion, $"navegacion_{mesActual}.csv");
                
                var usuario = Environment.UserName;
                var timestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                string linea = $"{timestamp},{usuario},{modulo},{accion}\n";
                File.AppendAllText(archivoPath, linea);
            }
            catch
            {
                // Ignoramos errores de log de navegación para no bloquear la app
            }
        }
    }
}
