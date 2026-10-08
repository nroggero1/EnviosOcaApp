using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnviosOcaApp.Views
{
    public partial class FrmImpresionEtiquetas : Form
    {
        public FrmImpresionEtiquetas()
        {
            InitializeComponent();
        }

        private void FrmImpresionEtiquetas_Load(object sender, EventArgs e)
        {
            CargarAuditoriaReciente();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarAuditoriaReciente();
        }

        private void CargarAuditoriaReciente()
        {
            try
            {
                var dt = Program.AuditoriaService.ObtenerHistorialMensual();
                dgvRecientes.DataSource = dt;
                
                // Ajustar visualmente el ancho de columnas si hay datos
                if (dgvRecientes.Columns.Count > 0)
                {
                    dgvRecientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    // Darle el espacio restante al Destinatario que suele ser el más largo
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

            // Asumiendo que la columna 5 es "Nro_Orden_OCA", o podemos buscar por nombre
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

        private async Task ProcesarImpresion(string codigoBusqueda)
        {
            btnImprimirDirecto.Enabled = false;
            btnImprimirSeleccionado.Enabled = false;
            lblStatus.ForeColor = Color.Blue;
            lblStatus.Text = $"Conectando con OCA para descargar {codigoBusqueda}...";

            try
            {
                string archivoPdfLocal = await Program.OcaService.ObtenerEtiquetaPdfAsync(codigoBusqueda);

                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "¡Etiqueta descargada correctamente!";

                // Abrir el PDF simulado automáticamente
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
            }
        }
    }
}
