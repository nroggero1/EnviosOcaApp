using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnviosOcaApp.Views
{
    public partial class FrmSeguimiento : Form
    {
        public FrmSeguimiento()
        {
            InitializeComponent();
        }

        private void FrmSeguimiento_Load(object sender, EventArgs e)
        {
            try
            {
                dgvAuditoriaInterna.DataSource = Program.AuditoriaService.ObtenerHistorialMensual();
                dgvAuditoriaInterna.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                
                // Ocultar columna de usuario y hacer que Destinatario ocupe el resto
                if (dgvAuditoriaInterna.Columns.Contains("Usuario_Sistema"))
                    dgvAuditoriaInterna.Columns["Usuario_Sistema"].Visible = false;

                if (dgvAuditoriaInterna.Columns.Contains("Destinatario"))
                    dgvAuditoriaInterna.Columns["Destinatario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar auditoría interna: " + ex.Message);
            }
        }

        private async void btnBuscarTracking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTracking.Text))
            {
                MessageBox.Show("Ingrese un número de Tracking.");
                return;
            }

            lblEstadoTracking.Text = "Conectando con OCA...";
            dgvTrackingOca.DataSource = null;

            try
            {
                var dt = await Program.OcaService.ObtenerTrackingAsync(txtTracking.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvTrackingOca.DataSource = dt;
                    lblEstadoTracking.Text = "Seguimiento descargado.";
                    
                    dgvTrackingOca.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (dgvTrackingOca.Columns.Contains("Estado"))
                        dgvTrackingOca.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    lblEstadoTracking.Text = "No se encontraron eventos para este envío.";
                }
            }
            catch (Exception ex)
            {
                lblEstadoTracking.Text = "Error al buscar.";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAuditoriaInterna_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAuditoriaInterna.Rows[e.RowIndex];
                if (dgvAuditoriaInterna.Columns.Contains("Nro_Orden_OCA"))
                {
                    var tracking = row.Cells["Nro_Orden_OCA"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(tracking) && tracking != "NO_GENERADO_AUN")
                    {
                        txtTracking.Text = tracking;
                        tabControlAuditoria.SelectedTab = tabOca;
                        btnBuscarTracking.PerformClick();
                    }
                }
            }
        }
    }
}
