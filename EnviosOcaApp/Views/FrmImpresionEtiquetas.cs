using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnviosOcaApp.Utils;

namespace EnviosOcaApp.Views
{
    public partial class FrmImpresionEtiquetas : Form
    {
        private ContextMenuStrip cmsRecientes = null!;

        public FrmImpresionEtiquetas()
        {
            InitializeComponent();
            ConfigurarContextMenu();
        }

        private void ConfigurarContextMenu()
        {
            cmsRecientes = new ContextMenuStrip();

            var itemSeguimiento = new ToolStripMenuItem("🔍 Ver Seguimiento en OCA (Doble Clic)", null, (s, e) =>
            {
                NavegarSeguimientoSeleccionado();
            });

            var itemImprimir = new ToolStripMenuItem("🖨️ Imprimir / Descargar Etiqueta", null, (s, e) =>
            {
                btnImprimirSeleccionado_Click(this, EventArgs.Empty);
            });

            var itemAnular = new ToolStripMenuItem("❌ Anular Envío en OCA", null, async (s, e) =>
            {
                await ProcesarAnulacionSeleccionada();
            });

            cmsRecientes.Items.Add(itemSeguimiento);
            cmsRecientes.Items.Add(itemImprimir);
            cmsRecientes.Items.Add(new ToolStripSeparator());
            cmsRecientes.Items.Add(itemAnular);

            dgvRecientes.ContextMenuStrip = cmsRecientes;
            dgvRecientes.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hit = dgvRecientes.HitTest(e.X, e.Y);
                    if (hit.RowIndex >= 0)
                    {
                        dgvRecientes.ClearSelection();
                        dgvRecientes.Rows[hit.RowIndex].Selected = true;
                    }
                }
            };
        }

        private void FrmImpresionEtiquetas_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode)
                return;

            EnviosOcaApp.Utils.UiHelper.ForzarMayusculasEnControles(this);
            CargarAuditoriaReciente();
            dgvRecientes.Cursor = Cursors.Hand;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarAuditoriaReciente();
        }

        private void CargarAuditoriaReciente()
        {
            try
            {
                var dt = Program.AuditoriaService.ObtenerHistorial(null, null, Environment.UserName, true);
                dgvRecientes.DataSource = dt;
                
                if (dgvRecientes.Columns.Count > 0)
                {
                    dgvRecientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (dgvRecientes.Columns.Contains("Usuario_Sistema")) dgvRecientes.Columns["Usuario_Sistema"].HeaderText = "Usuario";
                    if (dgvRecientes.Columns.Contains("Empresa_Seleccionada")) dgvRecientes.Columns["Empresa_Seleccionada"].HeaderText = "Empresa";
                    if (dgvRecientes.Columns.Contains("Nro_Orden_OCA")) dgvRecientes.Columns["Nro_Orden_OCA"].HeaderText = "Nro. Orden OCA";
                    if (dgvRecientes.Columns.Contains("Estado_Operacion")) dgvRecientes.Columns["Estado_Operacion"].HeaderText = "Estado Operación";
                    if (dgvRecientes.Columns.Contains("Fecha_Modificacion")) dgvRecientes.Columns["Fecha_Modificacion"].HeaderText = "Fecha Modificación";
                    if (dgvRecientes.Columns.Contains("Usuario_Modificacion")) dgvRecientes.Columns["Usuario_Modificacion"].HeaderText = "Usuario Modificación";

                    if (dgvRecientes.Columns.Contains("Destinatario"))
                    {
                        dgvRecientes.Columns["Destinatario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar la auditoría: {ex.Message}");
            }
        }

        private async void btnImprimirDirecto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTracking.Text))
            {
                MessageBox.Show("Ingrese un número de Tracking o Nro de Operación OCA.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await ProcesarImpresion(txtTracking.Text.Trim());
        }

        private async void btnImprimirSeleccionado_Click(object sender, EventArgs e)
        {
            if (dgvRecientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un envío de la grilla inferior.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nroOca = "";
            if (dgvRecientes.Columns.Contains("Nro_Orden_OCA"))
            {
                nroOca = dgvRecientes.SelectedRows[0].Cells["Nro_Orden_OCA"].Value?.ToString() ?? "";
            }

            if (string.IsNullOrWhiteSpace(nroOca))
            {
                MessageBox.Show("No se encontró el Nro_Orden_OCA en la fila seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await ProcesarImpresion(nroOca);
        }

        private async void btnAnularEnvio_Click(object sender, EventArgs e)
        {
            await ProcesarAnulacionSeleccionada();
        }

        private async Task ProcesarAnulacionSeleccionada()
        {
            if (dgvRecientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un envío de la grilla inferior para anular.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvRecientes.SelectedRows[0];
            string estado = dgvRecientes.Columns.Contains("Estado_Operacion") ? row.Cells["Estado_Operacion"].Value?.ToString() ?? "" : "";
            if (estado.Equals("ANULADA", StringComparison.OrdinalIgnoreCase) || estado.Contains("Anulad", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Este envío ya se encuentra marcado como ANULADO en el sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nroOca = dgvRecientes.Columns.Contains("Nro_Orden_OCA") ? row.Cells["Nro_Orden_OCA"].Value?.ToString() ?? "" : "";
            string destinatario = dgvRecientes.Columns.Contains("Destinatario") ? row.Cells["Destinatario"].Value?.ToString() ?? "" : "";

            // 1. Extraer o resolver el número numérico de Orden de Retiro
            int idOrdenRetiro = 0;
            if (!string.IsNullOrWhiteSpace(nroOca) && nroOca.Length <= 10 && int.TryParse(nroOca, out int idDirecto))
            {
                idOrdenRetiro = idDirecto;
            }
            else
            {
                var match = Regex.Match(destinatario, @"(?:OR|OrdenRetiro|Orden):\s*(\d+)");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int idMatch))
                {
                    idOrdenRetiro = idMatch;
                }
            }

            // Si aún no se determinó, solicitar al usuario el número
            if (idOrdenRetiro == 0)
            {
                string? input = InputBoxHelper.Show(
                    $"El identificador principal es un Tracking ({nroOca}).\nPara solicitar la anulación formal ante OCA se requiere el N° de Orden de Retiro (numérico):\n\nIngrese la Orden de Retiro:",
                    "Anular Envío en OCA",
                    "");
                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input.Trim(), out idOrdenRetiro))
                {
                    return;
                }
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de que desea anular la Orden de Retiro N° {idOrdenRetiro} ante OCA?\n\nDestinatario: {destinatario}\n\nEsta acción dará de baja la orden formalmente en el sistema de OCA.",
                "Confirmar Anulación en OCA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            btnImprimirSeleccionado.Enabled = false;
            btnAnularEnvio.Enabled = false;
            lblStatus.ForeColor = Color.Blue;
            lblStatus.Text = $"Conectando con OCA para anular Orden {idOrdenRetiro}...";

            try
            {
                var (exito, mensaje) = await Program.OcaService.AnularOrdenGeneradaAsync(idOrdenRetiro);
                if (exito)
                {
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = $"Orden {idOrdenRetiro} anulada exitosamente en OCA.";
                    
                    Program.AuditoriaService.ActualizarEstadoOrden(nroOca, "ANULADA");
                    Program.AuditoriaService.ActualizarEstadoOrden(idOrdenRetiro.ToString(), "ANULADA");
                    Program.AuditoriaService.RegistrarNavegacion("Impresión de Etiquetas", $"Orden anulada: {idOrdenRetiro}");

                    CargarAuditoriaReciente();
                    MessageBox.Show($"La orden fue anulada exitosamente en OCA.\n\nRespuesta OCA: {mensaje}", "Orden Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "No se pudo anular la orden en OCA.";

                    if (mensaje.Contains("Orden Retiro Anulada", StringComparison.OrdinalIgnoreCase) || mensaje.Contains("ya fue anulada", StringComparison.OrdinalIgnoreCase))
                    {
                        Program.AuditoriaService.ActualizarEstadoOrden(nroOca, "ANULADA");
                        Program.AuditoriaService.ActualizarEstadoOrden(idOrdenRetiro.ToString(), "ANULADA");
                        Program.AuditoriaService.RegistrarNavegacion("Impresión de Etiquetas", $"Orden confirmada como ya anulada en OCA: {idOrdenRetiro}");
                        CargarAuditoriaReciente();
                        MessageBox.Show($"OCA informó que la orden ya se encontraba anulada:\n{mensaje}\n\nSe actualizó el estado en el sistema a ANULADA.", "Orden ya Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"OCA no pudo anular la orden:\n{mensaje}", "Aviso de OCA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Error al intentar anular la orden.";
                MessageBox.Show($"Ocurrió un error al comunicarse con OCA: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnImprimirSeleccionado.Enabled = true;
                btnAnularEnvio.Enabled = true;
            }
        }

        private void dgvRecientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            NavegarSeguimientoSeleccionado();
        }

        private void NavegarSeguimientoSeleccionado()
        {
            if (dgvRecientes.SelectedRows.Count == 0) return;

            var row = dgvRecientes.SelectedRows[0];
            string codigoTracking = "";

            if (dgvRecientes.Columns.Contains("Nro_Orden_OCA"))
            {
                codigoTracking = row.Cells["Nro_Orden_OCA"].Value?.ToString() ?? "";
            }

            if (string.IsNullOrWhiteSpace(codigoTracking) || codigoTracking == "NO_GENERADO_AUN" || codigoTracking == "S/D")
            {
                string dest = dgvRecientes.Columns.Contains("Destinatario") ? row.Cells["Destinatario"].Value?.ToString() ?? "" : "";
                var match = Regex.Match(dest, @"Tracking:\s*([0-9A-Za-z]+)");
                if (match.Success)
                {
                    codigoTracking = match.Groups[1].Value;
                }
            }

            if (string.IsNullOrWhiteSpace(codigoTracking) || codigoTracking == "NO_GENERADO_AUN" || codigoTracking == "S/D")
            {
                MessageBox.Show("No se encontró un número de orden o tracking válido en la fila seleccionada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.TopLevelControl is Form1 form1)
            {
                form1.NavegarASeguimiento(codigoTracking);
            }
        }

        private async Task ProcesarImpresion(string codigoBusqueda)
        {
            btnImprimirDirecto.Enabled = false;
            btnImprimirSeleccionado.Enabled = false;
            btnAnularEnvio.Enabled = false;
            lblStatus.ForeColor = Color.Blue;
            lblStatus.Text = $"Conectando con OCA para descargar {codigoBusqueda}...";

            try
            {
                string archivoPdfLocal = await Program.OcaService.ObtenerEtiquetaPdfAsync(codigoBusqueda);

                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "¡Etiqueta descargada correctamente!";

                Process.Start(new ProcessStartInfo
                {
                    FileName = archivoPdfLocal,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Error al descargar la etiqueta.";
                MessageBox.Show(ex.Message, "Error OCA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnImprimirDirecto.Enabled = true;
                btnImprimirSeleccionado.Enabled = true;
                btnAnularEnvio.Enabled = true;
            }
        }
    }
}
