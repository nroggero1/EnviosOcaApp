using EnviosOcaApp.Utils;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace EnviosOcaApp.Views
{
    public partial class FrmImpresionEtiquetas : Form
    {
        private ContextMenuStrip cmsRecientes = null!;
        private const int RegistrosPorPagina = 25;
        private bool _esAdministrador;
        private int _paginaActual;
        private string _columnaOrden = "__FechaOrden";
        private bool _ordenAscendente;
        private DataView? _vistaHistorial;
        private FlowLayoutPanel _panelFiltrosAdmin = null!;
        private FlowLayoutPanel _panelPaginacion = null!;
        private DateTimePicker _dtpDesde = null!;
        private DateTimePicker _dtpHasta = null!;
        private ComboBox _cmbUsuario = null!;
        private Button _btnFiltrar = null!;
        private Button _btnPaginaAnterior = null!;
        private Button _btnPaginaSiguiente = null!;
        private Label _lblPagina = null!;

        public FrmImpresionEtiquetas()
        {
            InitializeComponent();
            ConfigurarContextMenu();
            ConfigurarFiltrosAdmin();
            ConfigurarPaginacion();
            lblTipDobleClic.Text = "Doble clic: Seguimiento | Clic derecho: opciones";
            lblTipDobleClic.AutoSize = false;
            lblTipDobleClic.AutoEllipsis = true;
            grpRecientes.Resize += (_, _) =>
            {
                AjustarAnchoAyuda();
                AjustarLayoutRecientes();
            };
            dgvRecientes.ColumnHeaderMouseClick += DgvRecientes_ColumnHeaderMouseClick;
            AjustarAnchoAyuda();
            AjustarLayoutRecientes();
        }

        private void ConfigurarFiltrosAdmin()
        {
            _panelFiltrosAdmin = new FlowLayoutPanel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                FlowDirection = FlowDirection.LeftToRight,
                Location = new Point(15, 18),
                Height = 30,
                WrapContents = false,
                Visible = false
            };

            var lblDesde = new Label { Text = "Desde:", AutoSize = true, Margin = new Padding(3, 8, 3, 3) };
            _dtpDesde = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                ShowCheckBox = true,
                Width = 125,
                Margin = new Padding(3, 3, 8, 3)
            };

            var lblHasta = new Label { Text = "Hasta:", AutoSize = true, Margin = new Padding(3, 8, 3, 3) };
            _dtpHasta = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                ShowCheckBox = true,
                Width = 125,
                Margin = new Padding(3, 3, 8, 3)
            };

            var lblUsuario = new Label { Text = "Usuario:", AutoSize = true, Margin = new Padding(3, 8, 3, 3) };
            _cmbUsuario = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 145,
                Margin = new Padding(3, 3, 8, 3)
            };

            _btnFiltrar = new Button { Text = "Filtrar", AutoSize = true, Margin = new Padding(3, 2, 3, 3) };
            _btnFiltrar.Click += (_, _) => CargarAuditoriaReciente();

            _panelFiltrosAdmin.Controls.Add(lblDesde);
            _panelFiltrosAdmin.Controls.Add(_dtpDesde);
            _panelFiltrosAdmin.Controls.Add(lblHasta);
            _panelFiltrosAdmin.Controls.Add(_dtpHasta);
            _panelFiltrosAdmin.Controls.Add(lblUsuario);
            _panelFiltrosAdmin.Controls.Add(_cmbUsuario);
            _panelFiltrosAdmin.Controls.Add(_btnFiltrar);
            grpRecientes.Controls.Add(_panelFiltrosAdmin);
        }

        private void ConfigurarPaginacion()
        {
            _panelPaginacion = new FlowLayoutPanel
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                FlowDirection = FlowDirection.LeftToRight,
                Height = 30,
                Left = 15,
                Width = 285,
                WrapContents = false
            };

            _btnPaginaAnterior = new Button { Text = "Anterior", AutoSize = true, Height = 26, Margin = new Padding(0, 1, 5, 1) };
            _btnPaginaAnterior.Click += (_, _) =>
            {
                if (_paginaActual > 0)
                {
                    _paginaActual--;
                    MostrarPaginaActual();
                }
            };

            _lblPagina = new Label { AutoSize = true, Margin = new Padding(5, 7, 5, 3) };

            _btnPaginaSiguiente = new Button { Text = "Siguiente", AutoSize = true, Height = 26, Margin = new Padding(5, 1, 0, 1) };
            _btnPaginaSiguiente.Click += (_, _) =>
            {
                int ultimaPagina = _vistaHistorial == null
                    ? 0
                    : Math.Max(0, (_vistaHistorial.Count - 1) / RegistrosPorPagina);
                if (_paginaActual < ultimaPagina)
                {
                    _paginaActual++;
                    MostrarPaginaActual();
                }
            };

            _panelPaginacion.Controls.Add(_btnPaginaAnterior);
            _panelPaginacion.Controls.Add(_lblPagina);
            _panelPaginacion.Controls.Add(_btnPaginaSiguiente);
            grpRecientes.Controls.Add(_panelPaginacion);
        }

        private void AjustarLayoutRecientes()
        {
            if (_panelPaginacion == null || _panelFiltrosAdmin == null)
                return;

            _panelFiltrosAdmin.Width = Math.Max(0, btnRefrescar.Left - _panelFiltrosAdmin.Left - 8);
            _panelPaginacion.Top = btnAnularEnvio.Top - _panelPaginacion.Height - 5;

            int gridTop = _esAdministrador ? 54 : 50;
            dgvRecientes.Top = gridTop;
            dgvRecientes.Height = Math.Max(30, _panelPaginacion.Top - dgvRecientes.Top - 6);
        }

        private void AjustarAnchoAyuda()
        {
            lblTipDobleClic.Width = Math.Max(
                0,
                btnAnularEnvio.Left - lblTipDobleClic.Left - 8);
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
            _esAdministrador = Program.AuditoriaService.EsAdministrador(Environment.UserName);
            _panelFiltrosAdmin.Visible = _esAdministrador;
            if (_esAdministrador)
            {
                _cmbUsuario.Items.Clear();
                _cmbUsuario.Items.Add("Todos");
                foreach (string usuario in Program.AuditoriaService.ObtenerUsuariosUnicos())
                    _cmbUsuario.Items.Add(usuario);
                _cmbUsuario.SelectedIndex = 0;
            }
            AjustarLayoutRecientes();
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
                DateTime? desde = _esAdministrador && _dtpDesde.Checked ? _dtpDesde.Value : null;
                DateTime? hasta = _esAdministrador && _dtpHasta.Checked ? _dtpHasta.Value : null;
                string? usuario = null;
                if (_esAdministrador && !string.Equals(_cmbUsuario.Text, "Todos", StringComparison.OrdinalIgnoreCase))
                    usuario = _cmbUsuario.Text;

                if (desde.HasValue && hasta.HasValue && desde.Value.Date > hasta.Value.Date)
                {
                    MessageBox.Show("La fecha Desde no puede ser posterior a la fecha Hasta.", "Filtro inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dt = Program.AuditoriaService.ObtenerHistorial(desde, hasta, usuario, _esAdministrador);
                if (!dt.Columns.Contains("__FechaOrden"))
                    dt.Columns.Add("__FechaOrden", typeof(DateTime));

                foreach (DataRow row in dt.Rows)
                {
                    string fecha = dt.Columns.Contains("Fecha") ? row["Fecha"]?.ToString() ?? string.Empty : string.Empty;
                    string hora = dt.Columns.Contains("Hora") ? row["Hora"]?.ToString() ?? string.Empty : string.Empty;
                    if (!DateTime.TryParseExact(
                            $"{fecha} {hora}",
                            "dd/MM/yyyy HH:mm:ss",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out DateTime fechaHora)
                        && !DateTime.TryParseExact(
                            fecha,
                            "dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out fechaHora))
                    {
                        fechaHora = DateTime.MinValue;
                    }

                    row["__FechaOrden"] = fechaHora;
                }

                _vistaHistorial = new DataView(dt);
                _columnaOrden = "__FechaOrden";
                _ordenAscendente = false;
                _vistaHistorial.Sort = "[__FechaOrden] DESC";
                _paginaActual = 0;
                MostrarPaginaActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar la auditoría: {ex.Message}");
            }
        }

        private void DgvRecientes_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (_vistaHistorial == null || e.ColumnIndex < 0)
                return;

            string columna = dgvRecientes.Columns[e.ColumnIndex].Name;
            if (columna == "__FechaOrden")
                return;

            if (columna == _columnaOrden)
            {
                _ordenAscendente = !_ordenAscendente;
            }
            else
            {
                _columnaOrden = columna;
                _ordenAscendente = true;
            }
            string direccion = _ordenAscendente ? "ASC" : "DESC";
            string columnaSegura = "[" + columna.Replace("]", "]]") + "]";
            _vistaHistorial.Sort = $"{columnaSegura} {direccion}, [__FechaOrden] DESC";
            _paginaActual = 0;
            MostrarPaginaActual();
        }

        private void MostrarPaginaActual()
        {
            DataView? vistaHistorial = _vistaHistorial;
            if (vistaHistorial == null)
                return;

            int totalRegistros = vistaHistorial.Count;
            int totalPaginas = Math.Max(1, (totalRegistros + RegistrosPorPagina - 1) / RegistrosPorPagina);
            _paginaActual = Math.Clamp(_paginaActual, 0, totalPaginas - 1);
            int inicio = _paginaActual * RegistrosPorPagina;
            DataTable tablaHistorial = vistaHistorial.Table
                ?? throw new InvalidOperationException("La vista de auditoría no tiene una tabla asociada.");
            var pagina = tablaHistorial.Clone();

            for (int i = inicio; i < Math.Min(inicio + RegistrosPorPagina, totalRegistros); i++)
            {
                if (vistaHistorial[i] is DataRowView rowView)
                    pagina.ImportRow(rowView.Row);
            }

            dgvRecientes.DataSource = pagina;
            dgvRecientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRecientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRecientes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            if (dgvRecientes.Columns.Contains("__FechaOrden"))
                dgvRecientes.Columns["__FechaOrden"].Visible = false;
            if (dgvRecientes.Columns.Contains("Usuario_Sistema")) dgvRecientes.Columns["Usuario_Sistema"].HeaderText = "Usuario";
            if (dgvRecientes.Columns.Contains("Empresa_Seleccionada")) dgvRecientes.Columns["Empresa_Seleccionada"].HeaderText = "Empresa";
            if (dgvRecientes.Columns.Contains("Nro_Orden_OCA")) dgvRecientes.Columns["Nro_Orden_OCA"].HeaderText = "Nro. Orden OCA";
            if (dgvRecientes.Columns.Contains("Estado_Operacion")) dgvRecientes.Columns["Estado_Operacion"].HeaderText = "Estado Operación";
            if (dgvRecientes.Columns.Contains("Fecha_Modificacion")) dgvRecientes.Columns["Fecha_Modificacion"].HeaderText = "Fecha Modificación";
            if (dgvRecientes.Columns.Contains("Usuario_Modificacion")) dgvRecientes.Columns["Usuario_Modificacion"].HeaderText = "Usuario Modificación";

            foreach (DataGridViewColumn column in dgvRecientes.Columns)
                column.SortMode = DataGridViewColumnSortMode.Programmatic;

            if (dgvRecientes.Columns.Contains("Destinatario")
                && dgvRecientes.Columns["Destinatario"] is DataGridViewColumn destinatarioColumn)
            {
                destinatarioColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            _lblPagina.Text = $"Página {_paginaActual + 1} de {totalPaginas}";
            _btnPaginaAnterior.Enabled = _paginaActual > 0;
            _btnPaginaSiguiente.Enabled = _paginaActual < totalPaginas - 1;
            AjustarLayoutRecientes();
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
            string empresa = dgvRecientes.Columns.Contains("Empresa_Seleccionada")
                ? row.Cells["Empresa_Seleccionada"].Value?.ToString() ?? ""
                : "";
            if (string.IsNullOrWhiteSpace(empresa))
            {
                MessageBox.Show(
                    "No se pudo determinar la empresa que generó esta orden.",
                    "Empresa no identificada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
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
                var (exito, mensaje) = await Program.OcaService.AnularOrdenGeneradaAsync(idOrdenRetiro, empresa);
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
