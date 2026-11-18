using EnviosOcaApp.Models;
using EnviosOcaApp.Utils;
using EnviosOcaApp.Validators;
using System.ComponentModel;

namespace EnviosOcaApp.Views
{
    public partial class FrmGeneracionEnvio : Form
    {
        private BindingList<PaqueteOca> listaPaquetesActual;
        private BindingList<EnvioOca> listaLoteEnvios;
        private TableLayoutPanel? _tlpOrigen;
        private OficinaSucursal? _oficinaSeleccionada;
        private DireccionOrigenManual? _direccionManual;

        private List<OficinaSucursal> _oficinas = new();
        private List<OficinaSucursal> _opcionesOficina = new();
        private bool _actualizandoFiltroOficinas;
        private readonly System.Windows.Forms.Timer _oficinaFiltroTimer = new()
        {
            Interval = 180
        };

        public FrmGeneracionEnvio()
        {
            InitializeComponent();
            _oficinaFiltroTimer.Tick += OficinaFiltroTimer_Tick;
            Disposed += (_, _) => _oficinaFiltroTimer.Dispose();
            listaPaquetesActual = new BindingList<PaqueteOca>();
            listaLoteEnvios = new BindingList<EnvioOca>();
            OrganizarLayoutResponsivo();
        }

        private void OrganizarLayoutResponsivo()
        {
            var tlpGlobal = (TableLayoutPanel)this.Controls.Find("tlpGlobal", true)[0];
            tlpGlobal.Dock = DockStyle.Fill;
            tlpGlobal.Margin = new Padding(0);
            tlpGlobal.ColumnStyles.Clear();
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

            var tlpDestino = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 4,
                RowCount = 6,
                AutoSize = false,
                Height = 200,
                Padding = new Padding(3),
                Margin = new Padding(0)
            };
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            for (int i = 0; i < 6; i++)
            {
                tlpDestino.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            }

            lblRemito.Visible = false;
            txtRemito.Visible = false;
            lblTelefono.Visible = false;
            txtTelefono.Visible = false;

            tlpDestino.Controls.Add(lblDestinatario, 0, 0);
            tlpDestino.Controls.Add(txtDestinatario, 1, 0);
            tlpDestino.SetColumnSpan(txtDestinatario, 3);
            txtDestinatario.Dock = DockStyle.Fill;

            tlpDestino.Controls.Add(lblCalle, 0, 1);
            tlpDestino.Controls.Add(txtCalle, 1, 1);
            txtCalle.Dock = DockStyle.Fill;
            tlpDestino.SetColumnSpan(txtCalle, 3);

            tlpDestino.Controls.Add(lblNumero, 0, 2);
            tlpDestino.Controls.Add(txtNumero, 1, 2);
            txtNumero.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblPiso, 2, 2);
            tlpDestino.Controls.Add(txtPiso, 3, 2);
            txtPiso.Dock = DockStyle.Fill;

            tlpDestino.Controls.Add(lblLocalidad, 0, 3);
            tlpDestino.Controls.Add(txtLocalidad, 1, 3);
            txtLocalidad.Dock = DockStyle.Fill;
            tlpDestino.SetColumnSpan(txtLocalidad, 3);

            tlpDestino.Controls.Add(lblProvincia, 0, 4);
            tlpDestino.Controls.Add(txtProvincia, 1, 4);
            txtProvincia.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblCP, 2, 4);
            tlpDestino.Controls.Add(txtCP, 3, 4);
            txtCP.Dock = DockStyle.Fill;

            tlpDestino.Controls.Add(lblEmail, 0, 5);
            tlpDestino.Controls.Add(txtEmail, 1, 5);
            tlpDestino.SetColumnSpan(txtEmail, 3);
            txtEmail.Dock = DockStyle.Fill;

            foreach (Control c in tlpDestino.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            var grpComposicion = (GroupBox)this.Controls.Find("grpComposicion", true)[0];
            grpComposicion.Dock = DockStyle.Fill;
            grpComposicion.Margin = new Padding(2);
            var grpDestino = (GroupBox)grpComposicion.Controls.Find("grpDestino", true)[0];
            grpDestino.Controls.Clear();
            grpDestino.Controls.Add(tlpDestino);

            var tlpPaquete = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                AutoSize = false,
                Padding = new Padding(3),
                Margin = new Padding(0)
            };
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            lblTamanoPaquete = new Label { Text = "Tamaño:", AutoSize = false };
            cmbTamanoPaquete = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill
            };
            tlpPaquete.Controls.Add(lblTamanoPaquete, 0, 0);
            tlpPaquete.Controls.Add(cmbTamanoPaquete, 1, 0);
            tlpPaquete.SetColumnSpan(cmbTamanoPaquete, 3);

            var flpDim = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(0), WrapContents = false };
            txtAlto.Width = 27; txtAncho.Width = 27; txtLargo.Width = 27;
            txtAlto.Margin = Padding.Empty;
            txtAncho.Margin = Padding.Empty;
            txtLargo.Margin = Padding.Empty;
            flpDim.Controls.Add(txtAlto);
            flpDim.Controls.Add(new Label { Text = "x", AutoSize = false, Width = 10, Font = new Font("Segoe UI", 9F), TextAlign = ContentAlignment.MiddleCenter, Margin = new Padding(1, 0, 1, 0) });
            flpDim.Controls.Add(txtAncho);
            flpDim.Controls.Add(new Label { Text = "x", AutoSize = false, Width = 10, Font = new Font("Segoe UI", 9F), TextAlign = ContentAlignment.MiddleCenter, Margin = new Padding(1, 0, 1, 0) });
            flpDim.Controls.Add(txtLargo);
            lblDimensiones.Text = "Dim. (cm):";
            lblDimensiones.AutoSize = false;
            lblPeso.Text = "Peso (kg):";
            lblPeso.AutoSize = false;
            lblValor.AutoSize = false;
            lblObservaciones.Text = "Obs.:";
            lblObservaciones.AutoSize = false;
            foreach (Label label in new[] { lblTamanoPaquete, lblDimensiones, lblPeso, lblValor, lblObservaciones })
            {
                label.Font = new Font("Segoe UI", 9F);
            }

            tlpPaquete.Controls.Add(lblDimensiones, 0, 1);
            tlpPaquete.Controls.Add(flpDim, 1, 1);

            tlpPaquete.Controls.Add(lblPeso, 2, 1);
            tlpPaquete.Controls.Add(txtPeso, 3, 1);
            txtPeso.Dock = DockStyle.Fill;

            tlpPaquete.Controls.Add(lblValor, 0, 2);
            tlpPaquete.Controls.Add(txtValor, 1, 2);
            txtValor.Dock = DockStyle.Fill;

            tlpPaquete.Controls.Add(lblObservaciones, 2, 2);
            tlpPaquete.Controls.Add(txtObservaciones, 3, 2);
            txtObservaciones.Dock = DockStyle.Fill;

            var flpOpciones = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = false };
            chkPrioritario = new CheckBox { Text = "Envío Prioritario", AutoSize = true, Checked = true, Visible = false };
            chkSeguro = new CheckBox { Text = "Seguro", AccessibleName = "Asegurar envío", AutoSize = false, Checked = false, Width = 75, Height = 29, Font = new Font("Segoe UI", 9F) };
            // El check prioritario no se muestra (default = TRUE && visible = false)
            flpOpciones.Controls.Add(chkSeguro);
            tlpPaquete.Controls.Add(flpOpciones, 0, 3);

            txtValor.TextChanged -= TxtValor_TextChanged;
            txtValor.TextChanged += TxtValor_TextChanged;
            chkSeguro.CheckedChanged -= ChkSeguro_CheckedChanged;
            chkSeguro.CheckedChanged += ChkSeguro_CheckedChanged;

            btnAgregarPaquete.Size = new Size(80, 34);
            btnQuitarPaquete.Size = new Size(80, 34);
            btnAgregarEnvioAlLote.Size = new Size(124, 34);
            foreach (Button boton in new[] { btnAgregarEnvioAlLote, btnQuitarPaquete, btnAgregarPaquete, btnQuitarEnvio, btnGenerar })
            {
                boton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                boton.Margin = new Padding(2);
            }
            btnAgregarEnvioAlLote.Margin = Padding.Empty;
            btnQuitarPaquete.Margin = Padding.Empty;
            btnAgregarPaquete.Margin = Padding.Empty;

            var flpBotones = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlowDirection = FlowDirection.RightToLeft, WrapContents = false };
            flpBotones.Controls.Add(btnAgregarEnvioAlLote);
            flpBotones.Controls.Add(btnQuitarPaquete);
            flpBotones.Controls.Add(btnAgregarPaquete);
            tlpPaquete.Controls.Add(flpBotones, 1, 3);
            tlpPaquete.SetColumnSpan(flpBotones, 3);

            dgvPaquetes.MinimumSize = new Size(0, 60);
            tlpPaquete.Controls.Add(dgvPaquetes, 0, 4);
            tlpPaquete.SetColumnSpan(dgvPaquetes, 4);
            dgvPaquetes.Dock = DockStyle.Fill;
            dgvPaquetes.Visible = true;
            dgvPaquetes.BringToFront();

            foreach (Control c in tlpPaquete.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            var grpPaquete = (GroupBox)grpComposicion.Controls.Find("grpPaquete", true)[0];
            grpPaquete.Dock = DockStyle.Fill;
            grpPaquete.Controls.Clear();
            grpPaquete.Controls.Add(tlpPaquete);

            cmbTamanoPaquete.SelectedIndexChanged -= CmbTamanoPaquete_SelectedIndexChanged;
            cmbTamanoPaquete.SelectedIndexChanged += CmbTamanoPaquete_SelectedIndexChanged;

            tlpComposicion.Dock = DockStyle.Fill;
            tlpComposicion.Margin = new Padding(0);
            tlpComposicion.ColumnStyles.Clear();
            tlpComposicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpComposicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grpComposicion.Controls.Clear();
            grpComposicion.Controls.Add(tlpComposicion);

            var lotLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(4),
                Margin = new Padding(0)
            };
            lotLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            lotLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 134F));
            lotLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            grpLote.Controls.Clear();
            dgvLoteEnvios.Dock = DockStyle.Fill;
            dgvLoteEnvios.Margin = new Padding(2);
            lotLayout.Controls.Add(dgvLoteEnvios, 0, 0);

            var accionesLote = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 1,
                RowCount = 2,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            accionesLote.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            accionesLote.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            accionesLote.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            btnQuitarEnvio.Dock = DockStyle.Fill;
            accionesLote.Controls.Add(btnQuitarEnvio, 0, 0);
            btnGenerar.Dock = DockStyle.Fill;
            accionesLote.Controls.Add(btnGenerar, 0, 1);
            lotLayout.Controls.Add(accionesLote, 1, 0);
            grpLote.Dock = DockStyle.Fill;
            grpLote.Margin = new Padding(2);
            grpLote.Controls.Add(lotLayout);

            var panelAcciones = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 1,
                Margin = new Padding(0),
                Padding = new Padding(2, 0, 2, 0)
            };
            panelAcciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.AutoEllipsis = true;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            panelAcciones.Controls.Add(lblStatus, 0, 0);

            var layoutPrincipal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5,
                Padding = new Padding(5),
                Margin = new Padding(0)
            };
            layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 132F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));

            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Margin = new Padding(2);
            lblTitulo.Location = new Point(14, 6);
            layoutPrincipal.Controls.Add(panelHeader, 0, 0);
            layoutPrincipal.Controls.Add(tlpGlobal, 0, 1);
            layoutPrincipal.Controls.Add(grpComposicion, 0, 2);
            layoutPrincipal.Controls.Add(grpLote, 0, 3);
            layoutPrincipal.Controls.Add(panelAcciones, 0, 4);

            AutoScroll = false;
            Controls.Clear();
            Controls.Add(layoutPrincipal);
        }

        private CheckBox chkPrioritario = null!;
        private bool _actualizandoSeguro = false;

        private void CargarOficinas()
        {
            try
            {
                string path =
                    Program.ConfiguracionActual
                        .ObtenerRutaOficinasCompleta();

                if (!System.IO.File.Exists(path))
                    return;

                string json =
                    System.IO.File.ReadAllText(path);

                _oficinas =
                    System.Text.Json.JsonSerializer
                        .Deserialize<List<OficinaSucursal>>(json)
                    ?? new List<OficinaSucursal>();

                cmbOficina.SelectedIndexChanged -=
                    CmbOficina_SelectedIndexChanged;
                cmbOficina.TextUpdate -=
                    CmbOficina_TextUpdate;
                cmbOficina.DropDown -=
                    CmbOficina_DropDown;

                cmbOficina.DataSource =
                    _opcionesOficina;

                cmbOficina.DisplayMember =
                    nameof(OficinaSucursal.DisplayCombo);

                cmbOficina.SelectedIndexChanged +=
                    CmbOficina_SelectedIndexChanged;
                cmbOficina.TextUpdate +=
                    CmbOficina_TextUpdate;
                cmbOficina.DropDown +=
                    CmbOficina_DropDown;

                ActualizarOficinasPorEmpresa();
            }
            catch
            {
            }
        }

        private List<OficinaSucursal> CrearOpcionesOficina(EmpresaOca? empresa)
        {
            var opciones = new List<OficinaSucursal>
            {
                new OficinaSucursal
                {
                    Codigo = "__SELECCIONAR__",
                    Nombre = "[ SELECCIONE ORIGEN ]"
                },
                new OficinaSucursal
                {
                    Codigo = "__MANUAL__",
                    Nombre = "[ INGRESO MANUAL DE DIRECCIÓN ]"
                }
            };

            if (empresa == null)
                return opciones;

            opciones.AddRange(
                OficinaSucursalFilter.FiltrarPorEmpresa(
                    _oficinas,
                    empresa.Nombre));

            return opciones;
        }

        private void CmbEmpresa_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ActualizarOficinasPorEmpresa();
        }

        private void ActualizarOficinasPorEmpresa()
        {
            _oficinaFiltroTimer.Stop();
            _opcionesOficina =
                CrearOpcionesOficina(cmbEmpresa.SelectedItem as EmpresaOca);

            _oficinaSeleccionada = null;
            _direccionManual = null;
            MostrarOrigenNoSeleccionado();

            _actualizandoFiltroOficinas = true;
            try
            {
                cmbOficina.DataSource = _opcionesOficina;
                cmbOficina.DisplayMember =
                    nameof(OficinaSucursal.DisplayCombo);
                cmbOficina.SelectedIndex = 0;
            }
            finally
            {
                _actualizandoFiltroOficinas = false;
            }
        }

        private void CmbOficina_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (_actualizandoFiltroOficinas)
                return;

            _oficinaFiltroTimer.Stop();

            if (cmbOficina.SelectedItem
                is not OficinaSucursal oficina)
            {
                return;
            }

            RestaurarListaOficinas(oficina);

            // ==========================
            // PLACEHOLDER
            // ==========================
            if (oficina.Codigo == "__SELECCIONAR__")
            {
                _oficinaSeleccionada = null;
                _direccionManual = null;

                MostrarOrigenNoSeleccionado();

                return;
            }

            // ==========================
            // INGRESO MANUAL
            // ==========================
            if (oficina.EsIngresoManual)
            {
                using var frm =
                    new FrmDireccionManual();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _direccionManual =
                        frm.DireccionManual;

                    _oficinaSeleccionada = null;

                    lblDireccionOficina.ForeColor =
                        Color.Black;

                    lblDireccionOficina.Text =
                        frm.DireccionCompleta;
                }
                else
                {
                    // El usuario canceló
                    _direccionManual = null;
                    _oficinaSeleccionada = null;

                    MostrarOrigenNoSeleccionado();

                    cmbOficina.SelectedIndex = 0;
                }

                return;
            }

            // ==========================
            // OFICINA NORMAL
            // ==========================
            _oficinaSeleccionada = oficina;

            _direccionManual = null;

            lblDireccionOficina.ForeColor =
                Color.Black;

            lblDireccionOficina.Text =
                oficina.DireccionCompleta;
        }

        private void CmbOficina_TextUpdate(
            object? sender,
            EventArgs e)
        {
            if (_actualizandoFiltroOficinas)
                return;

            if (cmbOficina.SelectedItem is OficinaSucursal oficina
                && string.Equals(
                    cmbOficina.Text,
                    oficina.DisplayCombo,
                    StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            _oficinaSeleccionada = null;
            _direccionManual = null;
            MostrarOrigenNoSeleccionado();

            _oficinaFiltroTimer.Stop();
            _oficinaFiltroTimer.Start();
        }

        private void OficinaFiltroTimer_Tick(object? sender, EventArgs e)
        {
            _oficinaFiltroTimer.Stop();

            string texto = cmbOficina.Text;
            int inicioSeleccion = cmbOficina.SelectionStart;
            int largoSeleccion = cmbOficina.SelectionLength;
            var opcionesFiltradas = string.IsNullOrWhiteSpace(texto)
                ? _opcionesOficina
                : _opcionesOficina
                    .Where(oficina => OficinaSucursalFilter.Matches(oficina, texto))
                    .ToList();

            _oficinaSeleccionada = null;
            _direccionManual = null;
            MostrarOrigenNoSeleccionado();

            _actualizandoFiltroOficinas = true;
            try
            {
                cmbOficina.BeginUpdate();
                try
                {
                    cmbOficina.DataSource = opcionesFiltradas;
                    cmbOficina.DisplayMember =
                        nameof(OficinaSucursal.DisplayCombo);
                    cmbOficina.SelectedIndex = -1;
                    cmbOficina.Text = texto;
                    cmbOficina.SelectionStart =
                        Math.Min(inicioSeleccion, cmbOficina.Text.Length);
                    cmbOficina.SelectionLength =
                        Math.Min(
                            largoSeleccion,
                            cmbOficina.Text.Length - cmbOficina.SelectionStart);
                }
                finally
                {
                    cmbOficina.EndUpdate();
                }
            }
            finally
            {
                _actualizandoFiltroOficinas = false;
            }

            cmbOficina.DroppedDown = true;
        }

        private void CmbOficina_DropDown(object? sender, EventArgs e)
        {
            if (_actualizandoFiltroOficinas
                || _oficinaFiltroTimer.Enabled
                || cmbOficina.SelectedItem is not OficinaSucursal oficina
                || ReferenceEquals(cmbOficina.DataSource, _opcionesOficina))
            {
                return;
            }

            RestaurarListaOficinas(oficina);
        }

        private void RestaurarListaOficinas(OficinaSucursal oficina)
        {
            if (ReferenceEquals(cmbOficina.DataSource, _opcionesOficina))
                return;

            _actualizandoFiltroOficinas = true;
            try
            {
                cmbOficina.DataSource = _opcionesOficina;
                cmbOficina.DisplayMember =
                    nameof(OficinaSucursal.DisplayCombo);
                cmbOficina.SelectedItem = oficina;
            }
            finally
            {
                _actualizandoFiltroOficinas = false;
            }
        }

        private void CmbTamanoPaquete_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbTamanoPaquete.SelectedItem is TipoBultoOca tipo)
            {
                if (tipo.EsPersonalizado)
                {
                    txtAlto.ReadOnly = false;
                    txtAncho.ReadOnly = false;
                    txtLargo.ReadOnly = false;
                    txtPeso.ReadOnly = false;

                    txtAlto.BackColor = Color.White;
                    txtAncho.BackColor = Color.White;
                    txtLargo.BackColor = Color.White;
                    txtPeso.BackColor = Color.White;

                    txtAlto.Clear();
                    txtAncho.Clear();
                    txtLargo.Clear();
                    txtPeso.Clear();

                    txtAlto.Focus();
                }
                else
                {
                    txtAlto.Text = tipo.Alto.ToString("0.#");
                    txtAncho.Text = tipo.Ancho.ToString("0.#");
                    txtLargo.Text = tipo.Largo.ToString("0.#");
                    txtPeso.Text = tipo.PesoMaximo.ToString("0.#");

                    txtAlto.ReadOnly = true;
                    txtAncho.ReadOnly = true;
                    txtLargo.ReadOnly = true;
                    txtPeso.ReadOnly = true;

                    txtAlto.BackColor = SystemColors.Control;
                    txtAncho.BackColor = SystemColors.Control;
                    txtLargo.BackColor = SystemColors.Control;
                    txtPeso.BackColor = SystemColors.Control;
                }
            }
        }

        private void TxtValor_TextChanged(object? sender, EventArgs e)
        {
            if (_actualizandoSeguro) return;

            try
            {
                _actualizandoSeguro = true;
                string texto = txtValor.Text.Trim();
                if (decimal.TryParse(texto, out decimal val) && val > 0)
                {
                    chkSeguro.Checked = true;
                }
                else if (string.IsNullOrWhiteSpace(texto))
                {
                    chkSeguro.Checked = false;
                }
            }
            finally
            {
                _actualizandoSeguro = false;
            }
        }

        private void ChkSeguro_CheckedChanged(object? sender, EventArgs e)
        {
            if (_actualizandoSeguro) return;

            try
            {
                _actualizandoSeguro = true;
                if (chkSeguro.Checked)
                {
                    string texto = txtValor.Text.Trim();
                    if (string.IsNullOrWhiteSpace(texto) || (decimal.TryParse(texto, out decimal val) && val <= 0))
                    {
                        txtValor.Focus();
                    }
                }
                else
                {
                    txtValor.Clear();
                }
            }
            finally
            {
                _actualizandoSeguro = false;
            }
        }





        private void ConfigurarLayoutDatosGlobales()
        {
            // grpOperador
            grpOperador.Controls.Clear();
            var tlpOperador = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(0)
            };
            tlpOperador.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpOperador.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            lblUsuario.AutoSize = true;
            lblUsuario.Anchor = AnchorStyles.Left; // Esto centra verticalmente de forma automática
            lblUsuario.Margin = new Padding(10, 3, 3, 3);

            txtUsuario.Dock = DockStyle.None;
            txtUsuario.Anchor = AnchorStyles.Left;
            txtUsuario.Width = 230;
            txtUsuario.Font = new Font("Segoe UI", 9F);
            txtUsuario.Margin = new Padding(3, 3, 8, 3);

            tlpOperador.Controls.Add(lblUsuario, 0, 0);
            tlpOperador.Controls.Add(txtUsuario, 1, 0);
            grpOperador.Controls.Add(tlpOperador);

            // grpOrigen
            grpOrigen.Controls.Clear();
            _tlpOrigen = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4,
                Padding = new Padding(2, 1, 2, 1),
                Margin = new Padding(0)
            };
            _tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            _tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            _tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tlpOrigen.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            _tlpOrigen.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            _tlpOrigen.RowStyles.Add(new RowStyle(SizeType.Percent, 22F));
            _tlpOrigen.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));

            lblEmpresa.AutoSize = true;
            lblEmpresa.Anchor = AnchorStyles.Left;
            lblEmpresa.Margin = new Padding(5, 1, 3, 1);

            cmbEmpresa.Dock = DockStyle.Fill;
            cmbEmpresa.Margin = new Padding(2, 1, 4, 1);

            lblRemitenteApellido.AutoSize = true;
            lblRemitenteApellido.Anchor = AnchorStyles.Left;
            lblRemitenteApellido.Margin = new Padding(5, 1, 2, 1);
            lblRemitenteApellido.Text = "Ap. Remitente:";

            txtRemitenteApellido.Dock = DockStyle.None;
            txtRemitenteApellido.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtRemitenteApellido.Margin = new Padding(2, 1, 4, 1);

            lblRemitenteNombre.AutoSize = true;
            lblRemitenteNombre.Anchor = AnchorStyles.Left;
            lblRemitenteNombre.Margin = new Padding(5, 1, 2, 1);
            lblRemitenteNombre.Text = "Nom. Remitente:";

            txtRemitenteNombre.Dock = DockStyle.None;
            txtRemitenteNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtRemitenteNombre.Margin = new Padding(2, 1, 4, 1);

            _tlpOrigen.Controls.Add(lblEmpresa, 0, 0);
            _tlpOrigen.Controls.Add(cmbEmpresa, 1, 0);
            _tlpOrigen.SetColumnSpan(cmbEmpresa, 3);
            lblOficina.Anchor = AnchorStyles.Left;
            lblOficina.Margin = new Padding(4, 1, 2, 1);
            cmbOficina.Dock = DockStyle.Fill;
            cmbOficina.Margin = new Padding(2, 1, 4, 1);
            _tlpOrigen.Controls.Add(lblOficina, 0, 1);
            _tlpOrigen.Controls.Add(cmbOficina, 1, 1);
            _tlpOrigen.SetColumnSpan(cmbOficina, 3);

            lblDireccionOficina.AutoSize = false;
            lblDireccionOficina.Height = 22;
            lblDireccionOficina.Dock = DockStyle.Fill;
            lblDireccionOficina.TextAlign = ContentAlignment.MiddleLeft;
            lblDireccionOficina.AutoEllipsis = true;
            lblDireccionOficina.Margin = new Padding(5, 1, 4, 1);
            _tlpOrigen.Controls.Add(lblDireccionOficina, 0, 2);
            _tlpOrigen.SetColumnSpan(lblDireccionOficina, 4);

            _tlpOrigen.Controls.Add(lblRemitenteApellido, 0, 3);
            _tlpOrigen.Controls.Add(txtRemitenteApellido, 1, 3);
            _tlpOrigen.Controls.Add(lblRemitenteNombre, 2, 3);
            _tlpOrigen.Controls.Add(txtRemitenteNombre, 3, 3);

            grpOrigen.Controls.Add(_tlpOrigen);
            cmbEmpresa.SizeChanged += (_, _) =>
            {
                if (cmbEmpresa.Width > 0)
                    cmbEmpresa.DropDownWidth = cmbEmpresa.Width;
            };
            cmbOficina.SizeChanged += (_, _) =>
            {
                if (cmbOficina.Width > 0)
                    cmbOficina.DropDownWidth = cmbOficina.Width;
            };

        }

        private (
    string Calle,
    string Numero,
    string Piso,
    string Localidad,
    string Provincia,
    string CP)
        ObtenerOrigenSeleccionado()
        {
            if (_direccionManual != null)
            {
                return
                (
                    _direccionManual.Calle,
                    _direccionManual.Numero,
                    _direccionManual.Piso,
                    _direccionManual.Localidad,
                    _direccionManual.Provincia,
                    _direccionManual.CP
                );
            }

            if (_oficinaSeleccionada != null)
            {
                return
                (
                    _oficinaSeleccionada.Calle,
                    _oficinaSeleccionada.Numero,
                    _oficinaSeleccionada.Piso,
                    _oficinaSeleccionada.Localidad,
                    _oficinaSeleccionada.Provincia,
                    _oficinaSeleccionada.CP
                );
            }

            throw new InvalidOperationException(
                "No existe origen seleccionado.");
        }

        private void FrmGeneracionEnvio_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode)
                return;

            EnviosOcaApp.Utils.UiHelper.ForzarMayusculasEnControles(this);
            ConfigurarLayoutDatosGlobales();
            txtUsuario.Text = Environment.UserName;

            string path = Program.ConfiguracionActual.ObtenerRutaEmpresasCompleta();
            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                var empresas = System.Text.Json.JsonSerializer.Deserialize<List<EmpresaOca>>(json);
                cmbEmpresa.DataSource = empresas;
                cmbEmpresa.DisplayMember = "Nombre";

                CargarOficinas();
            }

            cmbEmpresa.SelectedIndexChanged -= CmbEmpresa_SelectedIndexChanged;
            cmbEmpresa.SelectedIndexChanged += CmbEmpresa_SelectedIndexChanged;

            // CARGAR CONFIGURACIÓN DE USUARIO ACTUAL
            string usersPath = Program.ConfiguracionActual.ObtenerRutaUsuariosCompleta();
            bool esAdmin = false;
            string defaultApellido = Environment.UserName;
            string defaultNombre = "";

            if (System.IO.File.Exists(usersPath))
            {
                string jsonUsers = System.IO.File.ReadAllText(usersPath);
                var usuarios = System.Text.Json.JsonSerializer.Deserialize<List<UsuarioApp>>(jsonUsers);

                if (usuarios != null)
                {
                    var currentUser = usuarios.FirstOrDefault(u => u.UsernameWindows.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase));
                    if (currentUser != null)
                    {
                        defaultApellido = currentUser.Apellido ?? "";
                        defaultNombre = currentUser.Nombre ?? "";

                        string nombreCompleto = $"{defaultApellido} {defaultNombre}".Trim();
                        if (!string.IsNullOrWhiteSpace(nombreCompleto))
                        {
                            txtUsuario.Text = $"{nombreCompleto} ({currentUser.UsernameWindows})";
                        }

                        foreach (var item in cmbEmpresa.Items)
                        {
                            if (item is EmpresaOca emp && emp.Nombre.Equals(currentUser.EmpresaDefecto, StringComparison.OrdinalIgnoreCase))
                            {
                                cmbEmpresa.SelectedItem = item;
                                break;
                            }
                        }

                        esAdmin = currentUser.EsAdministrador;
                    }
                }
            }

            txtRemitenteApellido.Text = defaultApellido;
            txtRemitenteNombre.Text = defaultNombre;

            lblRemitenteApellido.Visible = esAdmin;
            txtRemitenteApellido.Visible = esAdmin;
            txtRemitenteApellido.Enabled = esAdmin;

            lblRemitenteNombre.Visible = esAdmin;
            txtRemitenteNombre.Visible = esAdmin;
            txtRemitenteNombre.Enabled = esAdmin;

            // Inicialización de Remito oculto con el usuario Windows
            txtRemito.Text = Environment.UserName.ToUpper();
            lblRemito.Visible = false;
            txtRemito.Visible = false;
            lblTelefono.Visible = false;
            txtTelefono.Visible = false;

            // Inicialización de Opciones de Paquete y Seguro
            txtValor.Text = "";
            chkSeguro.Checked = false;
            chkPrioritario.Checked = true;
            chkPrioritario.Visible = false;

            // Inicialización de selector de tamaño de bulto
            cmbTamanoPaquete.DataSource = TipoBultoOca.ObtenerTiposPredefinidos();
            cmbTamanoPaquete.SelectedIndex = 0;

            dgvPaquetes.DataSource = listaPaquetesActual;
            ConfigurarGrillaPaquetes();
            dgvLoteEnvios.DataSource = listaLoteEnvios;
        }

        private void ConfigurarGrillaPaquetes()
        {
            dgvPaquetes.ReadOnly = false;
            dgvPaquetes.AllowUserToAddRows = false;
            dgvPaquetes.AllowUserToDeleteRows = false;
            dgvPaquetes.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPaquetes.EditMode = DataGridViewEditMode.EditOnEnter;

            if (dgvPaquetes.Columns.Contains("Tamano"))
            {
                dgvPaquetes.Columns["Tamano"].HeaderText = "Tamaño";
                dgvPaquetes.Columns["Tamano"].ReadOnly = true;
            }
            if (dgvPaquetes.Columns.Contains("Alto")) dgvPaquetes.Columns["Alto"].HeaderText = "Alto (cm)";
            if (dgvPaquetes.Columns.Contains("Ancho")) dgvPaquetes.Columns["Ancho"].HeaderText = "Ancho (cm)";
            if (dgvPaquetes.Columns.Contains("Largo")) dgvPaquetes.Columns["Largo"].HeaderText = "Largo (cm)";
            if (dgvPaquetes.Columns.Contains("Peso")) dgvPaquetes.Columns["Peso"].HeaderText = "Peso (kg)";
            if (dgvPaquetes.Columns.Contains("Valor")) dgvPaquetes.Columns["Valor"].HeaderText = "Valor Declarado ($)";
            if (dgvPaquetes.Columns.Contains("Observaciones")) dgvPaquetes.Columns["Observaciones"].HeaderText = "Observaciones";

            dgvPaquetes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaquetes.ScrollBars = ScrollBars.Both;
            foreach (DataGridViewColumn column in dgvPaquetes.Columns)
            {
                column.MinimumWidth = column.Name switch
                {
                    "Tamano" => 85,
                    "Alto" or "Ancho" or "Largo" or "Peso" => 85,
                    "Valor" or "Observaciones" => 115,
                    _ => 70
                };
            }

            dgvPaquetes.DataError -= DgvPaquetes_DataError;
            dgvPaquetes.DataError += DgvPaquetes_DataError;

            dgvPaquetes.CellValidating -= DgvPaquetes_CellValidating;
            dgvPaquetes.CellValidating += DgvPaquetes_CellValidating;

            dgvPaquetes.CellValueChanged -= DgvPaquetes_CellValueChanged;
            dgvPaquetes.CellValueChanged += DgvPaquetes_CellValueChanged;

            dgvPaquetes.EditingControlShowing -= DgvPaquetes_EditingControlShowing;
            dgvPaquetes.EditingControlShowing += DgvPaquetes_EditingControlShowing;
        }

        private void DgvPaquetes_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Por favor, ingrese un número decimal válido para este campo.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = false;
        }

        private void DgvPaquetes_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvPaquetes.Columns[e.ColumnIndex].Name;
            string nuevoValor = e.FormattedValue?.ToString()?.Trim() ?? "";

            if (colName == "Alto" || colName == "Ancho" || colName == "Largo" || colName == "Peso")
            {
                if (!decimal.TryParse(nuevoValor, out decimal val) || val <= 0)
                {
                    MessageBox.Show($"El valor de {colName} debe ser un número mayor a cero.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            else if (colName == "Valor")
            {
                if (string.IsNullOrWhiteSpace(nuevoValor))
                {
                    return; // Si queda en blanco, se interpreta como 0
                }

                if (!decimal.TryParse(nuevoValor, out decimal val) || val < 0)
                {
                    MessageBox.Show("El valor declarado debe ser un número mayor o igual a cero.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void DgvPaquetes_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvPaquetes.Columns[e.ColumnIndex].Name;
            if (colName == "Alto" || colName == "Ancho" || colName == "Largo" || colName == "Peso")
            {
                if (dgvPaquetes.Rows[e.RowIndex].DataBoundItem is PaqueteOca pq)
                {
                    pq.Tamano = "OTRO";
                    dgvPaquetes.InvalidateRow(e.RowIndex);
                }
            }

            if (colName == "Valor")
            {
                bool algunAsegurado = listaPaquetesActual.Any(p => p.Valor > 0);
                if (algunAsegurado && !chkSeguro.Checked)
                {
                    _actualizandoSeguro = true;
                    chkSeguro.Checked = true;
                    _actualizandoSeguro = false;
                }
                else if (!algunAsegurado && string.IsNullOrWhiteSpace(txtValor.Text))
                {
                    _actualizandoSeguro = true;
                    chkSeguro.Checked = false;
                    _actualizandoSeguro = false;
                }
            }
        }

        private void DgvPaquetes_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void btnAgregarPaquete_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAlto.Text, out decimal alto) ||
                !decimal.TryParse(txtAncho.Text, out decimal ancho) ||
                !decimal.TryParse(txtLargo.Text, out decimal largo) ||
                !decimal.TryParse(txtPeso.Text, out decimal peso) ||
                alto <= 0 || ancho <= 0 || largo <= 0 || peso <= 0)
            {
                MessageBox.Show("Verifique que las dimensiones (Alto, Ancho, Largo) y el Peso sean valores numéricos mayores a cero.", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal valor = 0;
            if (chkSeguro.Checked)
            {
                if (!decimal.TryParse(txtValor.Text.Trim(), out valor) || valor <= 0)
                {
                    MessageBox.Show("Al marcar 'Asegurar envío', se debe declarar obligatoriamente el importe en 'Valor $'.", "Importe Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValor.Focus();
                    return;
                }
            }
            else
            {
                // Si no tildó, pero ingresó un valor positivo, tildar seguro
                if (!string.IsNullOrWhiteSpace(txtValor.Text.Trim()))
                {
                    if (decimal.TryParse(txtValor.Text.Trim(), out decimal valIngresado) && valIngresado > 0)
                    {
                        valor = valIngresado;
                        chkSeguro.Checked = true;
                    }
                    else
                    {
                        valor = 0;
                    }
                }
                else
                {
                    // Sin tilde y sin valor => envío sin seguro
                    valor = 0;
                }
            }

            string nombreTamano = (cmbTamanoPaquete.SelectedItem is TipoBultoOca t) ? t.Nombre : "OTRO";

            var paquete = new PaqueteOca
            {
                Tamano = nombreTamano,
                Alto = alto,
                Ancho = ancho,
                Largo = largo,
                Peso = peso,
                Valor = valor,
                Observaciones = txtObservaciones.Text
            };

            listaPaquetesActual.Add(paquete);

            // Limpiamos observaciones y valor (lo que automáticamente destilda chkSeguro)
            txtObservaciones.Clear();
            txtValor.Clear();

            // Si estaba en 'OTRO', limpiamos los campos para el siguiente bulto
            if (cmbTamanoPaquete.SelectedItem is TipoBultoOca tipoActual && tipoActual.EsPersonalizado)
            {
                txtAlto.Clear();
                txtAncho.Clear();
                txtLargo.Clear();
                txtPeso.Clear();
                txtAlto.Focus();
            }
        }

        private void btnQuitarPaquete_Click(object sender, EventArgs e)
        {
            var paquetesParaEliminar = new HashSet<PaqueteOca>();
            foreach (DataGridViewRow row in dgvPaquetes.SelectedRows)
            {
                if (!row.IsNewRow && row.DataBoundItem is PaqueteOca pq)
                    paquetesParaEliminar.Add(pq);
            }
            foreach (DataGridViewCell cell in dgvPaquetes.SelectedCells)
            {
                if (cell.RowIndex >= 0 && cell.RowIndex < dgvPaquetes.Rows.Count)
                {
                    var row = dgvPaquetes.Rows[cell.RowIndex];
                    if (!row.IsNewRow && row.DataBoundItem is PaqueteOca pq)
                        paquetesParaEliminar.Add(pq);
                }
            }

            foreach (var pq in paquetesParaEliminar)
            {
                listaPaquetesActual.Remove(pq);
            }
        }

        private bool ValidarRemitenteYOrigen()
        {
            var errores = new List<string>();
            SincronizarOficinaSeleccionadaDesdeCombo();

            if (cmbEmpresa.SelectedItem is EmpresaOca empresa)
            {
                errores.AddRange(
                    EnvioOcaValidator.ValidarRemitente(
                        empresa,
                        txtRemitenteApellido.Text,
                        txtRemitenteNombre.Text));
            }
            else
            {
                errores.Add("Debe seleccionar una empresa remitente.");
            }

            if (_oficinaSeleccionada == null && _direccionManual == null)
            {
                errores.Add("Debe seleccionar una oficina de origen o ingresar una dirección manual.");
            }
            else
            {
                errores.AddRange(
                    EnvioOcaValidator.ValidarOrigen(
                        ObtenerOrigenSeleccionado()));
            }

            if (errores.Count == 0)
                return true;

            MessageBox.Show(
                "Revise los datos del remitente y del origen:\n\n- " + string.Join("\n- ", errores),
                "Datos incompletos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        private void SincronizarOficinaSeleccionadaDesdeCombo()
        {
            if (_oficinaSeleccionada != null
                || _direccionManual != null
                || cmbOficina.SelectedItem is not OficinaSucursal oficina
                || oficina.Codigo == "__SELECCIONAR__"
                || oficina.EsIngresoManual)
            {
                return;
            }

            _oficinaSeleccionada = oficina;
            lblDireccionOficina.ForeColor = Color.Black;
            lblDireccionOficina.Text = oficina.DireccionCompleta;
        }

        private void btnAgregarEnvioAlLote_Click(object sender, EventArgs e)

        {

            if (!ValidarRemitenteYOrigen())
                return;

            // Remito obligatorio asignado automáticamente (usuario de Windows)
            string remito = txtRemito.Text.Trim();
            if (string.IsNullOrWhiteSpace(remito))
            {
                remito = Environment.UserName.ToUpper();
            }
            if (listaLoteEnvios.Any(x => x.Remito.Equals(remito, StringComparison.OrdinalIgnoreCase)))
            {
                remito = $"{remito}-{listaLoteEnvios.Count + 1}";
            }

            // Envío prioritario siempre activo por defecto (default = TRUE && visible = false)
            chkPrioritario.Checked = true;

            // Operativa: Prioritario con seguro (416557) o Prioritario sin seguro (283228)
            bool tieneSeguro = chkSeguro.Checked || listaPaquetesActual.Any(p => p.Valor > 0);
            int idOperativa = tieneSeguro ? 416557 : 283228;

            var envio = new EnvioOca
            {
                IdOperativa = idOperativa,
                Remito = remito,
                NombreDestinatario = txtDestinatario.Text.Trim(),
                Calle = txtCalle.Text.Trim(),
                Numero = txtNumero.Text.Trim(),
                Piso = txtPiso.Text.Trim(),
                Localidad = txtLocalidad.Text.Trim(),
                Provincia = txtProvincia.Text.Trim(),
                CP = txtCP.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Paquetes = listaPaquetesActual.ToList()
            };

            List<string> erroresEnvio = EnvioOcaValidator.ValidarEnvio(envio);
            if (erroresEnvio.Count > 0)
            {
                MessageBox.Show(
                    "Revise los datos obligatorios del destinatario y del envío:\n\n- " + string.Join("\n- ", erroresEnvio),
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            listaLoteEnvios.Add(envio);

            // Limpiamos los campos del destino
            txtRemito.Text = Environment.UserName.ToUpper();
            txtDestinatario.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            txtPiso.Clear();
            txtLocalidad.Clear();
            txtProvincia.Clear();
            txtCP.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtValor.Clear();
            chkSeguro.Checked = false;
            listaPaquetesActual.Clear();

            // Foco al siguiente Destinatario
            txtDestinatario.Focus();
        }

        private void btnQuitarEnvio_Click(object sender, EventArgs e)
        {
            if (dgvLoteEnvios.SelectedRows.Count > 0)
            {
                var enviosParaEliminar = new List<EnvioOca>();
                foreach (DataGridViewRow row in dgvLoteEnvios.SelectedRows)
                {
                    if (!row.IsNewRow && row.DataBoundItem is EnvioOca env)
                    {
                        enviosParaEliminar.Add(env);
                    }
                }

                foreach (var env in enviosParaEliminar)
                {
                    listaLoteEnvios.Remove(env);
                }
            }
        }

        private void MostrarOrigenNoSeleccionado()
        {
            lblDireccionOficina.ForeColor =
                Color.DarkOrange;

            lblDireccionOficina.Text =
                "⚠ DEBE SELECCIONAR UN ORIGEN";
        }

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            if (listaLoteEnvios.Count == 0)
            {
                MessageBox.Show(
                    "El lote está vacío. Por favor añada al menos un envío.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidarRemitenteYOrigen())
                return;

            if (cmbEmpresa.SelectedItem is not EmpresaOca empresaSeleccionada)
            {
                MessageBox.Show(
                    "Debe seleccionar una empresa válida.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var erroresLote = new List<string>();
            for (int i = 0; i < listaLoteEnvios.Count; i++)
            {
                List<string> erroresEnvio = EnvioOcaValidator.ValidarEnvio(listaLoteEnvios[i]);
                erroresLote.AddRange(erroresEnvio.Select(error => $"Envío {i + 1}: {error}"));
            }

            if (erroresLote.Count > 0)
            {
                MessageBox.Show(
                    "No se puede confirmar el lote. Revise los siguientes datos:\n\n- " + string.Join("\n- ", erroresLote),
                    "Lote incompleto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string apRem = txtRemitenteApellido.Text.Trim();
            string nomRem = txtRemitenteNombre.Text.Trim();

            string remitente =
                $"{apRem} {nomRem}".Trim();

            if (string.IsNullOrWhiteSpace(remitente))
            {
                remitente = Environment.UserName;
            }

            try
            {
                btnGenerar.Enabled = false;
                btnGenerar.Text = "Transmitiendo...";

                lblStatus.Text = "Conectando con OCA...";
                lblStatus.ForeColor = Color.Blue;

                var loteParaEnviar =
                    listaLoteEnvios.ToList();

                var origen =
                    ObtenerOrigenSeleccionado();

                OcaResponse ocaRespuesta =
                    await Program.OcaService.GenerarLoteRealAsync(
                        empresaSeleccionada,
                        origen,
                        apRem,
                        nomRem,
                        loteParaEnviar);

                if (ocaRespuesta.TieneErrores)
                {
                    lblStatus.Text = "Falló la transmisión.";
                    lblStatus.ForeColor = Color.Red;

                    MessageBox.Show(
                        $"OCA rechazó el envío:\n{ocaRespuesta.MensajeError}",
                        "Error de API",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                // ==========================
                // DATOS DE ORIGEN AUDITORÍA
                // ==========================

                string tipoOrigen;
                string origenUtilizado;

                if (_direccionManual != null)
                {
                    tipoOrigen = "MANUAL";
                    origenUtilizado =
                        _direccionManual.DireccionCompleta;
                }
                else
                {
                    tipoOrigen = "OFICINA";

                    origenUtilizado =
                        _oficinaSeleccionada?.DisplayCombo
                        ?? "NO DEFINIDO";
                }

                // ==========================
                // AUDITORÍA
                // ==========================

                foreach (var envio in loteParaEnviar)
                {
                    string direccionCompleta =
                        $"{envio.Calle} {envio.Numero} {envio.Piso}".Trim();

                    var infoGuia =
                        ocaRespuesta.EnviosGenerados.FirstOrDefault(g =>
                            g.NumeroRemito.TrimStart('0') ==
                                envio.Remito.TrimStart('0')
                            ||
                            g.NumeroRemito ==
                                envio.Remito);

                    string trackingNumber =
                        infoGuia != null &&
                        !string.IsNullOrWhiteSpace(infoGuia.NumeroEnvio)
                            ? infoGuia.NumeroEnvio
                            : "S/D";

                    string ordenRetiro =
                        !string.IsNullOrWhiteSpace(infoGuia?.OrdenRetiro)
                            ? infoGuia.OrdenRetiro
                            : (!string.IsNullOrWhiteSpace(
                                    ocaRespuesta.CodigoOperacion)
                                ? ocaRespuesta.CodigoOperacion
                                : "");

                    string destFinalAuditoria =
                        $"{envio.NombreDestinatario} " +
                        $"({direccionCompleta}, {envio.Localidad}) " +
                        $"[OR: {ordenRetiro} | " +
                        $"Tracking: {trackingNumber} | " +
                        $"Bultos: {envio.BultosTotales}]";

                    Program.AuditoriaService.RegistrarGeneracionEtiqueta(
                        empresa: empresaSeleccionada.Nombre,
                        nroOrdenOca: trackingNumber,
                        remitente: remitente,
                        destinatario: destFinalAuditoria,
                        estado: "Generado Lote OK",
                        tipoOrigen: tipoOrigen,
                        origenUtilizado: origenUtilizado
                    );
                }

                int totalPaquetesLote =
                    loteParaEnviar.Sum(x => x.BultosTotales);

                lblStatus.ForeColor = Color.Green;

                lblStatus.Text =
                    $"¡Éxito! Operación: {ocaRespuesta.CodigoOperacion} " +
                    $"({ocaRespuesta.EnviosGenerados.Count} guías / " +
                    $"{totalPaquetesLote} paquetes).";

                string msgBoxOp =
                    string.IsNullOrWhiteSpace(
                        ocaRespuesta.CodigoOperacion)
                        ? "(Individuales)"
                        : ocaRespuesta.CodigoOperacion;

                MessageBox.Show(
                    $"Transmisión del lote generada exitosamente.\n" +
                    $"N° Operación: {msgBoxOp}\n" +
                    $"Destinatarios: {ocaRespuesta.EnviosGenerados.Count}\n" +
                    $"Total Etiquetas a imprimir: {totalPaquetesLote}",
                    "Transmisión Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                listaLoteEnvios.Clear();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error interno.";

            }
        }
    }
}
