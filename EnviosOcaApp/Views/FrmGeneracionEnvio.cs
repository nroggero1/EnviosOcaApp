using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EnviosOcaApp.Models;

namespace EnviosOcaApp.Views
{
    public partial class FrmGeneracionEnvio : Form
    {
        private BindingList<PaqueteOca> listaPaquetesActual;
        private BindingList<EnvioOca> listaLoteEnvios;
        private TableLayoutPanel? _tlpOrigen;
        private Label lblRemitenteApellido = new Label { Text = "Ap. Remitente:", AutoSize = true };
        private TextBox txtRemitenteApellido = new TextBox();
        private Label lblRemitenteNombre = new Label { Text = "Nom. Remitente:", AutoSize = true };
        private TextBox txtRemitenteNombre = new TextBox();

        public FrmGeneracionEnvio()
        {
            InitializeComponent();
            listaPaquetesActual = new BindingList<PaqueteOca>();
            listaLoteEnvios = new BindingList<EnvioOca>();
            OrganizarLayoutResponsivo();
        }

        private void OrganizarLayoutResponsivo()
        {
            // Layout de Datos Globales manejado ahora en ConfigurarLayoutDatosGlobales()
            var tlpGlobal = (TableLayoutPanel)this.Controls.Find("tlpGlobal", true)[0];

            // 1. Recreamos el layout de Destino con una TableLayoutPanel de 6 columnas (4 filas)
            var tlpDestino = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 6,
                RowCount = 4,
                AutoSize = true,
                Padding = new Padding(5)
            };
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));

            for (int i = 0; i < 4; i++) 
            {
                tlpDestino.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            // Ocultar campos de Remito y Teléfono en la interfaz
            lblRemito.Visible = false;
            txtRemito.Visible = false;
            lblTelefono.Visible = false;
            txtTelefono.Visible = false;

            // Fila 0: Destinatario
            tlpDestino.Controls.Add(lblDestinatario, 0, 0);
            tlpDestino.Controls.Add(txtDestinatario, 1, 0);
            tlpDestino.SetColumnSpan(txtDestinatario, 5);
            txtDestinatario.Dock = DockStyle.Fill;

            // Fila 1: Calle, Número, Piso
            tlpDestino.Controls.Add(lblCalle, 0, 1);
            tlpDestino.Controls.Add(txtCalle, 1, 1);
            txtCalle.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblNumero, 2, 1);
            tlpDestino.Controls.Add(txtNumero, 3, 1);
            txtNumero.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblPiso, 4, 1);
            tlpDestino.Controls.Add(txtPiso, 5, 1);
            txtPiso.Dock = DockStyle.Fill;

            // Fila 2: Localidad, Provincia, CP
            tlpDestino.Controls.Add(lblLocalidad, 0, 2);
            tlpDestino.Controls.Add(txtLocalidad, 1, 2);
            txtLocalidad.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblProvincia, 2, 2);
            tlpDestino.Controls.Add(txtProvincia, 3, 2);
            txtProvincia.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblCP, 4, 2);
            tlpDestino.Controls.Add(txtCP, 5, 2);
            txtCP.Dock = DockStyle.Fill;

            // Fila 3: Contacto (Email)
            tlpDestino.Controls.Add(lblEmail, 0, 3);
            tlpDestino.Controls.Add(txtEmail, 1, 3);
            tlpDestino.SetColumnSpan(txtEmail, 5);
            txtEmail.Dock = DockStyle.Fill;

            foreach (Control c in tlpDestino.Controls) {
                if (c is Label lbl) {
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            var grpComposicion = (GroupBox)this.Controls.Find("grpComposicion", true)[0];
            var grpDestino = (GroupBox)grpComposicion.Controls.Find("grpDestino", true)[0];
            grpDestino.Controls.Clear();
            grpDestino.Controls.Add(tlpDestino);

            // 2. Recreamos el layout de Paquete
            var tlpPaquete = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                AutoSize = false,
                Padding = new Padding(4)
            };
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            // Fila 0: Selector de Tamaño de Bulto
            lblTamanoPaquete = new Label { Text = "Tamaño Bulto:", AutoSize = true };
            cmbTamanoPaquete = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill
            };
            tlpPaquete.Controls.Add(lblTamanoPaquete, 0, 0);
            tlpPaquete.Controls.Add(cmbTamanoPaquete, 1, 0);
            tlpPaquete.SetColumnSpan(cmbTamanoPaquete, 3);

            // Fila 1: Dimensiones y Peso
            var flpDim = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(0), WrapContents = false };
            txtAlto.Width = 40; txtAncho.Width = 40; txtLargo.Width = 40;
            flpDim.Controls.Add(txtAlto);
            flpDim.Controls.Add(new Label { Text = "x", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
            flpDim.Controls.Add(txtAncho);
            flpDim.Controls.Add(new Label { Text = "x", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
            flpDim.Controls.Add(txtLargo);
            lblDimensiones.Text = "Dimensiones (cm):";

            tlpPaquete.Controls.Add(lblDimensiones, 0, 1);
            tlpPaquete.Controls.Add(flpDim, 1, 1);

            tlpPaquete.Controls.Add(lblPeso, 2, 1);
            tlpPaquete.Controls.Add(txtPeso, 3, 1);
            txtPeso.Dock = DockStyle.Fill;

            // Fila 2: Valor y Observaciones
            tlpPaquete.Controls.Add(lblValor, 0, 2);
            tlpPaquete.Controls.Add(txtValor, 1, 2);
            txtValor.Dock = DockStyle.Fill;

            tlpPaquete.Controls.Add(lblObservaciones, 2, 2);
            tlpPaquete.Controls.Add(txtObservaciones, 3, 2);
            txtObservaciones.Dock = DockStyle.Fill;

            // Fila 3: Seguro y Botones
            var flpOpciones = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = false };
            chkPrioritario = new CheckBox { Text = "Envío Prioritario", AutoSize = true, Checked = true, Visible = false };
            chkSeguro = new CheckBox { Text = "Asegurar Envío", AutoSize = true, Checked = false };
            // El check prioritario no se muestra (default = TRUE && visible = false)
            flpOpciones.Controls.Add(chkSeguro);
            tlpPaquete.Controls.Add(flpOpciones, 0, 3);
            tlpPaquete.SetColumnSpan(flpOpciones, 2);

            txtValor.TextChanged -= TxtValor_TextChanged;
            txtValor.TextChanged += TxtValor_TextChanged;
            chkSeguro.CheckedChanged -= ChkSeguro_CheckedChanged;
            chkSeguro.CheckedChanged += ChkSeguro_CheckedChanged;

            var flpBotones = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlowDirection = FlowDirection.RightToLeft, WrapContents = false };
            flpBotones.Controls.Add(btnQuitarPaquete);
            flpBotones.Controls.Add(btnAgregarPaquete);
            tlpPaquete.Controls.Add(flpBotones, 2, 3);
            tlpPaquete.SetColumnSpan(flpBotones, 2);

            // Fila 4: Grilla
            dgvPaquetes.MinimumSize = new Size(0, 100);
            tlpPaquete.Controls.Add(dgvPaquetes, 0, 4);
            tlpPaquete.SetColumnSpan(dgvPaquetes, 4);
            dgvPaquetes.Dock = DockStyle.Fill;
            dgvPaquetes.Visible = true;
            dgvPaquetes.BringToFront();

            foreach (Control c in tlpPaquete.Controls) {
                if (c is Label lbl) {
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            var grpPaquete = (GroupBox)grpComposicion.Controls.Find("grpPaquete", true)[0];
            grpPaquete.Controls.Clear();
            grpPaquete.Controls.Add(tlpPaquete);

            cmbTamanoPaquete.SelectedIndexChanged -= CmbTamanoPaquete_SelectedIndexChanged;
            cmbTamanoPaquete.SelectedIndexChanged += CmbTamanoPaquete_SelectedIndexChanged;
        }

        private CheckBox chkPrioritario = null!;
        private CheckBox chkSeguro = null!;
        private Label lblTamanoPaquete = null!;
        private ComboBox cmbTamanoPaquete = null!;
        private bool _actualizandoSeguro = false;

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
            var tlpOperador = new TableLayoutPanel { 
                Dock = DockStyle.Fill, 
                ColumnCount = 2, 
                RowCount = 1,
                Padding = new Padding(0, 12, 0, 0) // Empuja hacia abajo para alejar del borde superior del GroupBox
            };
            tlpOperador.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpOperador.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            
            lblUsuario.AutoSize = true;
            lblUsuario.Anchor = AnchorStyles.Left; // Esto centra verticalmente de forma automática
            lblUsuario.Margin = new Padding(10, 3, 3, 3);
            
            txtUsuario.Dock = DockStyle.None;
            txtUsuario.Anchor = AnchorStyles.Left | AnchorStyles.Right; // Centra verticalmente y expande a los lados
            txtUsuario.Margin = new Padding(3, 3, 15, 3);
            
            tlpOperador.Controls.Add(lblUsuario, 0, 0);
            tlpOperador.Controls.Add(txtUsuario, 1, 0);
            grpOperador.Controls.Add(tlpOperador);

            // grpOrigen
            grpOrigen.Controls.Clear();
            _tlpOrigen = new TableLayoutPanel { 
                Dock = DockStyle.Fill, 
                ColumnCount = 4, 
                RowCount = 2,
                Padding = new Padding(0, 4, 0, 0)
            };
            _tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            _tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            _tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tlpOrigen.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _tlpOrigen.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            lblEmpresa.AutoSize = true;
            lblEmpresa.Anchor = AnchorStyles.Left;
            lblEmpresa.Margin = new Padding(8, 2, 3, 2);
            
            cmbEmpresa.Dock = DockStyle.None;
            cmbEmpresa.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbEmpresa.Margin = new Padding(3, 2, 10, 2);
            
            lblRemitenteApellido.AutoSize = true;
            lblRemitenteApellido.Anchor = AnchorStyles.Left;
            lblRemitenteApellido.Margin = new Padding(8, 2, 3, 2);
            lblRemitenteApellido.Text = "Ap. Remitente:";
            
            txtRemitenteApellido.Dock = DockStyle.None;
            txtRemitenteApellido.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtRemitenteApellido.Margin = new Padding(3, 2, 10, 2);
            
            lblRemitenteNombre.AutoSize = true;
            lblRemitenteNombre.Anchor = AnchorStyles.Left;
            lblRemitenteNombre.Margin = new Padding(8, 2, 3, 2);
            lblRemitenteNombre.Text = "Nom. Remitente:";
            
            txtRemitenteNombre.Dock = DockStyle.None;
            txtRemitenteNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtRemitenteNombre.Margin = new Padding(3, 2, 10, 2);

            _tlpOrigen.Controls.Add(lblEmpresa, 0, 0);
            _tlpOrigen.Controls.Add(cmbEmpresa, 1, 0);
            _tlpOrigen.SetColumnSpan(cmbEmpresa, 3);

            _tlpOrigen.Controls.Add(lblRemitenteApellido, 0, 1);
            _tlpOrigen.Controls.Add(txtRemitenteApellido, 1, 1);
            _tlpOrigen.Controls.Add(lblRemitenteNombre, 2, 1);
            _tlpOrigen.Controls.Add(txtRemitenteNombre, 3, 1);

            grpOrigen.Controls.Add(_tlpOrigen);
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
            }

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

        private void btnAgregarEnvioAlLote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestinatario.Text) || listaPaquetesActual.Count == 0)
            {
                MessageBox.Show("Debe indicar al menos un destinatario y un bulto.", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                NombreDestinatario = txtDestinatario.Text,
                Calle = txtCalle.Text,
                Numero = txtNumero.Text,
                Piso = txtPiso.Text,
                Localidad = txtLocalidad.Text,
                Provincia = txtProvincia.Text,
                CP = txtCP.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                Paquetes = listaPaquetesActual.ToList()
            };

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

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            if (listaLoteEnvios.Count == 0)
            {
                MessageBox.Show("El lote estÃ¡ vacÃ­o. Por favor aÃ±ada al menos un envÃ­o.", "AtenciÃ³n", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEmpresa.SelectedItem is not EmpresaOca empresaSeleccionada)
            {
                MessageBox.Show("Debe seleccionar una empresa vÃ¡lida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string apRem = txtRemitenteApellido.Text.Trim();
            string nomRem = txtRemitenteNombre.Text.Trim();
            string remitente = $"{apRem} {nomRem}".Trim();
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
                
                var loteParaEnviar = listaLoteEnvios.ToList();

                // 1. Llamamos al servicio OCA y obtenemos el objeto de respuesta completo (LLAMADA REAL)
                OcaResponse ocaRespuesta = await Program.OcaService.GenerarLoteRealAsync(empresaSeleccionada, apRem, nomRem, loteParaEnviar);

                if (ocaRespuesta.TieneErrores)
                {
                    lblStatus.Text = "FallÃ³ la transmisiÃ³n.";
                    lblStatus.ForeColor = Color.Red;
                    MessageBox.Show($"OCA rechazÃ³ el envÃ­o: {ocaRespuesta.MensajeError}", "Error de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. TransmisiÃ³n exitosa. Loggeamos en el Excel
                foreach (var envio in loteParaEnviar)
                {
                    string direccionCompleta = $"{envio.Calle} {envio.Numero} {envio.Piso}".Trim();
                    
                    // Buscamos la guía generada para este remito particular en la respuesta de OCA
                    var infoGuia = ocaRespuesta.EnviosGenerados.FirstOrDefault(g => 
                        g.NumeroRemito.TrimStart('0') == envio.Remito.TrimStart('0') || 
                        g.NumeroRemito == envio.Remito);
                        
                    string trackingNumber = infoGuia != null && !string.IsNullOrWhiteSpace(infoGuia.NumeroEnvio) ? infoGuia.NumeroEnvio : "S/D";
                    string ordenRetiro = !string.IsNullOrWhiteSpace(infoGuia?.OrdenRetiro) 
                        ? infoGuia.OrdenRetiro 
                        : (!string.IsNullOrWhiteSpace(ocaRespuesta.CodigoOperacion) ? ocaRespuesta.CodigoOperacion : "");

                    string destFinalAuditoria = $"{envio.NombreDestinatario} ({direccionCompleta}, {envio.Localidad}) [OR: {ordenRetiro} | Tracking: {trackingNumber} | Bultos: {envio.BultosTotales}]";

                    Program.AuditoriaService.RegistrarGeneracionEtiqueta(
                        empresa: empresaSeleccionada.Nombre,
                        nroOrdenOca: trackingNumber, // Usamos el Tracking de 19 digitos (vital para imprimir)
                        remitente: remitente,
                        destinatario: destFinalAuditoria,
                        estado: "Generado Lote OK"
                    );
                }

                int totalPaquetesLote = loteParaEnviar.Sum(x => x.BultosTotales);

                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = $"Â¡Ã‰xito! OperaciÃ³n: {ocaRespuesta.CodigoOperacion} ({ocaRespuesta.EnviosGenerados.Count} guÃ­as / {totalPaquetesLote} paquetes).";
                
                string msgBoxOp = string.IsNullOrWhiteSpace(ocaRespuesta.CodigoOperacion) ? "(Individuales)" : ocaRespuesta.CodigoOperacion;

                MessageBox.Show($"TransmisiÃ³n del Lote generada exitosamente.\nNÂ° OperaciÃ³n: {msgBoxOp}\nDestinatarios: {ocaRespuesta.EnviosGenerados.Count}\nTotal Etiquetas a imprimir: {totalPaquetesLote}", "TransmisiÃ³n Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listaLoteEnvios.Clear();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error interno.";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"OcurriÃ³ un error inesperado:\n{ex.Message}", "Error CrÃ­tico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerar.Enabled = true;
                btnGenerar.Text = "Transmitir Lote OCA";
            }
        }
    }
}








