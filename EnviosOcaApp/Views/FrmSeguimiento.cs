using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Diagnostics;
using EnviosOcaApp.Utils;

namespace EnviosOcaApp.Views
{
    public partial class FrmSeguimiento : Form
    {
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private ComboBox cmbUsuario;
        private Button btnFiltrar;
        private Label lblUsuario;
        private bool esAdministrador = false;
        private ContextMenuStrip cmsAuditoria;

        public FrmSeguimiento()
        {
            InitializeComponent();
            ConfigurarFiltrosUi();
            ConfigurarTopOcaUi();
            ConfigurarContextMenuAuditoria();
        }

        public void ConsultarTracking(string codigoTracking)
        {
            if (string.IsNullOrWhiteSpace(codigoTracking)) return;

            txtTracking.Text = codigoTracking.Trim();
            tabControlAuditoria.SelectedTab = tabOca;
            btnBuscarTracking.PerformClick();
        }

        private void ConfigurarContextMenuAuditoria()
        {
            cmsAuditoria = new ContextMenuStrip();

            var itemTracking = new ToolStripMenuItem("🔍 Ver Seguimiento en OCA", null, (s, e) =>
            {
                if (dgvAuditoriaInterna.SelectedRows.Count > 0)
                {
                    var row = dgvAuditoriaInterna.SelectedRows[0];
                    string tracking = dgvAuditoriaInterna.Columns.Contains("Nro_Orden_OCA")
                        ? row.Cells["Nro_Orden_OCA"].Value?.ToString() ?? ""
                        : "";
                    if (!string.IsNullOrWhiteSpace(tracking) && tracking != "NO_GENERADO_AUN")
                    {
                        ConsultarTracking(tracking);
                    }
                }
            });

            var itemImprimir = new ToolStripMenuItem("🖨️ Imprimir / Descargar Etiqueta", null, async (s, e) =>
            {
                if (dgvAuditoriaInterna.SelectedRows.Count > 0)
                {
                    var row = dgvAuditoriaInterna.SelectedRows[0];
                    string tracking = dgvAuditoriaInterna.Columns.Contains("Nro_Orden_OCA")
                        ? row.Cells["Nro_Orden_OCA"].Value?.ToString() ?? ""
                        : "";
                    if (!string.IsNullOrWhiteSpace(tracking) && tracking != "NO_GENERADO_AUN")
                    {
                        try
                        {
                            string pdf = await Program.OcaService.ObtenerEtiquetaPdfAsync(tracking);
                            Process.Start(new ProcessStartInfo { FileName = pdf, UseShellExecute = true });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al descargar etiqueta: {ex.Message}", "Error OCA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            });

            var itemAnular = new ToolStripMenuItem("❌ Anular Envío en OCA", null, async (s, e) =>
            {
                await AnularEnvioDesdeAuditoria();
            });

            cmsAuditoria.Items.Add(itemTracking);
            cmsAuditoria.Items.Add(itemImprimir);
            cmsAuditoria.Items.Add(new ToolStripSeparator());
            cmsAuditoria.Items.Add(itemAnular);

            dgvAuditoriaInterna.ContextMenuStrip = cmsAuditoria;
            dgvAuditoriaInterna.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hit = dgvAuditoriaInterna.HitTest(e.X, e.Y);
                    if (hit.RowIndex >= 0)
                    {
                        dgvAuditoriaInterna.ClearSelection();
                        dgvAuditoriaInterna.Rows[hit.RowIndex].Selected = true;
                    }
                }
            };
        }

        private async Task AnularEnvioDesdeAuditoria()
        {
            if (dgvAuditoriaInterna.SelectedRows.Count == 0) return;

            var row = dgvAuditoriaInterna.SelectedRows[0];
            string estado = dgvAuditoriaInterna.Columns.Contains("Estado_Operacion") ? row.Cells["Estado_Operacion"].Value?.ToString() ?? "" : "";
            if (estado.Equals("ANULADA", StringComparison.OrdinalIgnoreCase) || estado.Contains("Anulad", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Este envío ya figura como ANULADO en el sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nroOca = dgvAuditoriaInterna.Columns.Contains("Nro_Orden_OCA") ? row.Cells["Nro_Orden_OCA"].Value?.ToString() ?? "" : "";
            string destinatario = dgvAuditoriaInterna.Columns.Contains("Destinatario") ? row.Cells["Destinatario"].Value?.ToString() ?? "" : "";

            int idOrdenRetiro = 0;
            if (!string.IsNullOrWhiteSpace(nroOca) && nroOca.Length <= 10 && int.TryParse(nroOca, out int idDirecto))
            {
                idOrdenRetiro = idDirecto;
            }
            else
            {
                var match = System.Text.RegularExpressions.Regex.Match(destinatario, @"(?:OR|OrdenRetiro|Orden):\s*(\d+)");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int idMatch))
                {
                    idOrdenRetiro = idMatch;
                }
            }

            if (idOrdenRetiro == 0)
            {
                string? input = InputBoxHelper.Show(
                    $"El identificador principal es un Tracking ({nroOca}).\nPara solicitar la anulación ante OCA se requiere el N° de Orden de Retiro numérico:\n\nIngrese la Orden de Retiro:",
                    "Anular Envío en OCA",
                    "");
                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input.Trim(), out idOrdenRetiro))
                {
                    return;
                }
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de que desea anular la Orden de Retiro N° {idOrdenRetiro} ante OCA?\n\nDestinatario: {destinatario}\n\nEsta acción cancelará la orden formalmente ante OCA.",
                "Confirmar Anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var (exito, mensaje) = await Program.OcaService.AnularOrdenGeneradaAsync(idOrdenRetiro);
                if (exito)
                {
                    Program.AuditoriaService.ActualizarEstadoOrden(nroOca, "ANULADA");
                    Program.AuditoriaService.ActualizarEstadoOrden(idOrdenRetiro.ToString(), "ANULADA");
                    CargarDatosAuditoria();
                    MessageBox.Show($"La orden fue anulada con éxito en OCA.\n\nRespuesta OCA: {mensaje}", "Orden Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (mensaje.Contains("Orden Retiro Anulada", StringComparison.OrdinalIgnoreCase) || mensaje.Contains("ya fue anulada", StringComparison.OrdinalIgnoreCase))
                    {
                        Program.AuditoriaService.ActualizarEstadoOrden(nroOca, "ANULADA");
                        Program.AuditoriaService.ActualizarEstadoOrden(idOrdenRetiro.ToString(), "ANULADA");
                        CargarDatosAuditoria();
                        MessageBox.Show($"OCA indicó que la orden ya se encontraba anulada:\n{mensaje}\n\nSe actualizó el estado a ANULADA.", "Orden ya Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"OCA no pudo anular la orden:\n{mensaje}", "Aviso de OCA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la anulación: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarTopOcaUi()
        {
            tabOca.Controls.Remove(panelTopOca);

            var flp = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(5),
                WrapContents = true
            };

            lblIngresoTracking.AutoSize = true;
            lblIngresoTracking.Anchor = AnchorStyles.Left;
            lblIngresoTracking.Margin = new Padding(3, 8, 3, 3);
            
            txtTracking.Width = 200;
            txtTracking.Margin = new Padding(3, 5, 15, 3);
            
            btnBuscarTracking.Margin = new Padding(3, 4, 15, 3);
            
            lblEstadoTracking.AutoSize = true;
            lblEstadoTracking.Anchor = AnchorStyles.Left;
            lblEstadoTracking.Margin = new Padding(3, 8, 3, 3);

            flp.Controls.Add(lblIngresoTracking);
            flp.Controls.Add(txtTracking);
            flp.Controls.Add(btnBuscarTracking);

            var btnAnularOrden = new Button
            {
                Text = "Anular Orden de Retiro",
                BackColor = Color.FromArgb(192, 57, 43),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(15, 4, 15, 3),
                AutoSize = true,
                Cursor = Cursors.Hand
            };
            btnAnularOrden.FlatAppearance.BorderSize = 0;
            btnAnularOrden.Click += async (s, e) =>
            {
                string input = txtTracking.Text.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Ingrese un número de Tracking u Orden de Retiro en el campo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idOrden = 0;
                if (input.Length <= 10 && int.TryParse(input, out int idDirecto))
                {
                    idOrden = idDirecto;
                }
                else
                {
                    // Buscar en la auditoría si este tracking tiene una OR asociada
                    if (dgvAuditoriaInterna.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow r in dgvAuditoriaInterna.Rows)
                        {
                            string codOca = dgvAuditoriaInterna.Columns.Contains("Nro_Orden_OCA") ? r.Cells["Nro_Orden_OCA"].Value?.ToString() ?? "" : "";
                            string dest = dgvAuditoriaInterna.Columns.Contains("Destinatario") ? r.Cells["Destinatario"].Value?.ToString() ?? "" : "";
                            if (codOca.Equals(input, StringComparison.OrdinalIgnoreCase) || dest.Contains(input))
                            {
                                var match = System.Text.RegularExpressions.Regex.Match(dest, @"(?:OR|OrdenRetiro|Orden):\s*(\d+)");
                                if (match.Success && int.TryParse(match.Groups[1].Value, out int idMatch))
                                {
                                    idOrden = idMatch;
                                    break;
                                }
                            }
                        }
                    }

                    if (idOrden == 0)
                    {
                        string? promptVal = InputBoxHelper.Show(
                            $"El código ingresado ({input}) corresponde a un Tracking de 19 dígitos.\nPara anular formalmente ante OCA se requiere el N° de Orden de Retiro numérico:\n\nIngrese la Orden de Retiro:",
                            "Anular Orden de Retiro",
                            "");
                        if (string.IsNullOrWhiteSpace(promptVal) || !int.TryParse(promptVal.Trim(), out idOrden))
                        {
                            return;
                        }
                    }
                }

                var confirm = MessageBox.Show($"¿Está seguro de que desea anular la Orden de Retiro N° {idOrden} ante OCA?\nEsta acción cancelará la orden de retiro formalmente.", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                btnAnularOrden.Enabled = false;
                lblEstadoTracking.Text = "Procesando anulación en OCA...";
                lblEstadoTracking.ForeColor = Color.Blue;

                try
                {
                    var (exito, mensaje) = await Program.OcaService.AnularOrdenGeneradaAsync(idOrden);
                    if (exito)
                    {
                        lblEstadoTracking.Text = "Orden anulada con éxito.";
                        lblEstadoTracking.ForeColor = Color.Green;
                        Program.AuditoriaService.ActualizarEstadoOrden(input, "ANULADA");
                        Program.AuditoriaService.ActualizarEstadoOrden(idOrden.ToString(), "ANULADA");
                        Program.AuditoriaService.RegistrarNavegacion("Auditoría y Seguimiento", $"Orden anulada en OCA: {idOrden}");
                        CargarDatosAuditoria();
                        MessageBox.Show($"Respuesta de OCA:\n{mensaje}", "Orden Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (mensaje.Contains("Orden Retiro Anulada", StringComparison.OrdinalIgnoreCase) || mensaje.Contains("ya fue anulada", StringComparison.OrdinalIgnoreCase))
                        {
                            lblEstadoTracking.Text = "La orden ya estaba anulada en OCA.";
                            lblEstadoTracking.ForeColor = Color.DarkOrange;
                            Program.AuditoriaService.ActualizarEstadoOrden(input, "ANULADA");
                            Program.AuditoriaService.ActualizarEstadoOrden(idOrden.ToString(), "ANULADA");
                            Program.AuditoriaService.RegistrarNavegacion("Auditoría y Seguimiento", $"Orden confirmada como ya anulada en OCA: {idOrden}");
                            CargarDatosAuditoria();
                            MessageBox.Show($"OCA informó que la orden ya se encontraba anulada:\n{mensaje}\n\nSe actualizó el estado a ANULADA.", "Orden ya Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            lblEstadoTracking.Text = "No se pudo anular la orden.";
                            lblEstadoTracking.ForeColor = Color.Red;
                            MessageBox.Show($"OCA no pudo anular la orden:\n{mensaje}", "Aviso de OCA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblEstadoTracking.Text = "Error al conectar con OCA.";
                    lblEstadoTracking.ForeColor = Color.Red;
                    MessageBox.Show($"Error: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnAnularOrden.Enabled = true;
                }
            };

            flp.Controls.Add(btnAnularOrden);
            flp.Controls.Add(lblEstadoTracking);

            tabOca.Controls.Add(flp);
            dgvTrackingOca.BringToFront();
        }

        private void ConfigurarFiltrosUi()
        {
            var flp = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(5),
                WrapContents = true
            };
            
            var lblDesde = new Label { Text = "Desde:", AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 8, 3, 3) };
            dtpDesde = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 110, Margin = new Padding(3, 5, 15, 3) };
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            
            var lblHasta = new Label { Text = "Hasta:", AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 8, 3, 3) };
            dtpHasta = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 110, Margin = new Padding(3, 5, 15, 3) };
            dtpHasta.Value = DateTime.Now;

            lblUsuario = new Label { Text = "Usuario:", AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 8, 3, 3) };
            cmbUsuario = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 150, Margin = new Padding(3, 5, 15, 3) };

            btnFiltrar = new Button { Text = "Filtrar", Margin = new Padding(3, 4, 3, 3) };
            btnFiltrar.Click += BtnFiltrar_Click;

            flp.Controls.Add(lblDesde);
            flp.Controls.Add(dtpDesde);
            flp.Controls.Add(lblHasta);
            flp.Controls.Add(dtpHasta);
            flp.Controls.Add(lblUsuario);
            flp.Controls.Add(cmbUsuario);
            flp.Controls.Add(btnFiltrar);

            tabAuditoria.Controls.Add(flp);
            dgvAuditoriaInterna.BringToFront();
        }

        private void FrmSeguimiento_Load(object sender, EventArgs e)
        {
            EnviosOcaApp.Utils.UiHelper.ForzarMayusculasEnControles(this);
            VerificarPermisos();
            CargarComboUsuarios();
            CargarDatosAuditoria();
        }

        private void VerificarPermisos()
        {
            esAdministrador = false;
            try
            {
                string jsonPath = Program.ConfiguracionActual.ObtenerRutaUsuariosCompleta();
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    var usuarios = JsonSerializer.Deserialize<List<Models.UsuarioApp>>(json);
                    if (usuarios != null)
                    {
                        var currentUser = System.Linq.Enumerable.FirstOrDefault(usuarios, u => u.UsernameWindows.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase));
                        if (currentUser != null && currentUser.EsAdministrador)
                        {
                            esAdministrador = true;
                        }
                    }
                }
            }
            catch { }

            lblUsuario.Visible = esAdministrador;
            cmbUsuario.Visible = esAdministrador;
        }

        private void CargarComboUsuarios()
        {
            if (!esAdministrador) return;
            
            try
            {
                cmbUsuario.Items.Clear();
                cmbUsuario.Items.Add("Todos");
                var unicos = Program.AuditoriaService.ObtenerUsuariosUnicos();
                foreach (var u in unicos) cmbUsuario.Items.Add(u);
                cmbUsuario.SelectedIndex = 0;
            }
            catch { }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatosAuditoria();
        }

        private void CargarDatosAuditoria()
        {
            try
            {
                string usuarioFiltro = esAdministrador ? (cmbUsuario.Text == "Todos" ? null : cmbUsuario.Text) : Environment.UserName;
                
                dgvAuditoriaInterna.DataSource = Program.AuditoriaService.ObtenerHistorial(dtpDesde.Value, dtpHasta.Value, usuarioFiltro, esAdministrador);
                dgvAuditoriaInterna.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                
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
                        ConsultarTracking(tracking);
                    }
                }
            }
        }
    }
}
