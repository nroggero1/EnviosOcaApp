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

            // 1. Recreamos el layout de Destino con una TableLayoutPanel de 6 columnas
            var tlpDestino = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 6,
                RowCount = 5,
                AutoSize = true,
                Padding = new Padding(5)
            };
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpDestino.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));

            for (int i = 0; i < 5; i++) 
            {
                tlpDestino.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            // Fila 0
            tlpDestino.Controls.Add(lblRemito, 0, 0);
            tlpDestino.Controls.Add(txtRemito, 1, 0);
            tlpDestino.SetColumnSpan(txtRemito, 5);
            txtRemito.Dock = DockStyle.Fill;

            // Fila 1
            tlpDestino.Controls.Add(lblDestinatario, 0, 1);
            tlpDestino.Controls.Add(txtDestinatario, 1, 1);
            tlpDestino.SetColumnSpan(txtDestinatario, 5);
            txtDestinatario.Dock = DockStyle.Fill;

            // Fila 2
            tlpDestino.Controls.Add(lblCalle, 0, 2);
            tlpDestino.Controls.Add(txtCalle, 1, 2);
            txtCalle.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblNumero, 2, 2);
            tlpDestino.Controls.Add(txtNumero, 3, 2);
            txtNumero.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblPiso, 4, 2);
            tlpDestino.Controls.Add(txtPiso, 5, 2);
            txtPiso.Dock = DockStyle.Fill;

            // Fila 3
            tlpDestino.Controls.Add(lblLocalidad, 0, 3);
            tlpDestino.Controls.Add(txtLocalidad, 1, 3);
            txtLocalidad.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblProvincia, 2, 3);
            tlpDestino.Controls.Add(txtProvincia, 3, 3);
            txtProvincia.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblCP, 4, 3);
            tlpDestino.Controls.Add(txtCP, 5, 3);
            txtCP.Dock = DockStyle.Fill;

            // Fila 4
            tlpDestino.Controls.Add(lblEmail, 0, 4);
            tlpDestino.Controls.Add(txtEmail, 1, 4);
            tlpDestino.SetColumnSpan(txtEmail, 3);
            txtEmail.Dock = DockStyle.Fill;
            tlpDestino.Controls.Add(lblTelefono, 4, 4);
            tlpDestino.Controls.Add(txtTelefono, 5, 4);
            txtTelefono.Dock = DockStyle.Fill;

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
                RowCount = 4,
                AutoSize = true,
                Padding = new Padding(5)
            };
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpPaquete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpPaquete.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            var flpDim = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(0), WrapContents = false };
            txtAlto.Width = 40; txtAncho.Width = 40; txtLargo.Width = 40;
            flpDim.Controls.Add(txtAlto);
            flpDim.Controls.Add(new Label { Text = "x", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
            flpDim.Controls.Add(txtAncho);
            flpDim.Controls.Add(new Label { Text = "x", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
            flpDim.Controls.Add(txtLargo);
            lblDimensiones.Text = "Dimensiones (cm):";

            tlpPaquete.Controls.Add(lblDimensiones, 0, 0);
            tlpPaquete.Controls.Add(flpDim, 1, 0);

            tlpPaquete.Controls.Add(lblPeso, 2, 0);
            tlpPaquete.Controls.Add(txtPeso, 3, 0);
            txtPeso.Dock = DockStyle.Fill;

            tlpPaquete.Controls.Add(lblValor, 0, 1);
            tlpPaquete.Controls.Add(txtValor, 1, 1);
            txtValor.Dock = DockStyle.Fill;

            tlpPaquete.Controls.Add(lblObservaciones, 2, 1);
            tlpPaquete.Controls.Add(txtObservaciones, 3, 1);
            txtObservaciones.Dock = DockStyle.Fill;

            var flpOpciones = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = false };
            chkPrioritario = new CheckBox { Text = "EnvÃ­o Prioritario", AutoSize = true };
            chkSeguro = new CheckBox { Text = "Asegurar EnvÃ­o", AutoSize = true };
            flpOpciones.Controls.Add(chkPrioritario);
            flpOpciones.Controls.Add(chkSeguro);
            tlpPaquete.Controls.Add(flpOpciones, 0, 2);
            tlpPaquete.SetColumnSpan(flpOpciones, 2);

            var flpBotones = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlowDirection = FlowDirection.RightToLeft, WrapContents = false };
            flpBotones.Controls.Add(btnQuitarPaquete);
            flpBotones.Controls.Add(btnAgregarPaquete);
            tlpPaquete.Controls.Add(flpBotones, 2, 2);
            tlpPaquete.SetColumnSpan(flpBotones, 2);

            tlpPaquete.Controls.Add(dgvPaquetes, 0, 3);
            tlpPaquete.SetColumnSpan(dgvPaquetes, 4);
            dgvPaquetes.Dock = DockStyle.Fill;

            foreach (Control c in tlpPaquete.Controls) {
                if (c is Label lbl) {
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            var grpPaquete = (GroupBox)grpComposicion.Controls.Find("grpPaquete", true)[0];
            grpPaquete.Controls.Clear();
            grpPaquete.Controls.Add(tlpPaquete);
        }

        private CheckBox chkPrioritario;
        private CheckBox chkSeguro;

        
        
        

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
            ConfigurarLayoutDatosGlobales();
            txtUsuario.Text = Environment.UserName;

            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "empresas.json");
            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                var empresas = System.Text.Json.JsonSerializer.Deserialize<List<EmpresaOca>>(json);
                cmbEmpresa.DataSource = empresas;
                cmbEmpresa.DisplayMember = "Nombre";
            }

            // CARGAR CONFIGURACIÓN DE USUARIO ACTUAL
            string usersPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "usuarios.json");
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

            dgvPaquetes.DataSource = listaPaquetesActual;
            dgvLoteEnvios.DataSource = listaLoteEnvios;
        }

        private void btnAgregarPaquete_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAlto.Text, out decimal alto) ||
                !decimal.TryParse(txtAncho.Text, out decimal ancho) ||
                !decimal.TryParse(txtLargo.Text, out decimal largo) ||
                !decimal.TryParse(txtPeso.Text, out decimal peso) ||
                !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                MessageBox.Show("Verifique que las dimensiones, peso y valor sean numÃ©ricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var paquete = new PaqueteOca
            {
                Alto = alto,
                Ancho = ancho,
                Largo = largo,
                Peso = peso,
                Valor = valor,
                Observaciones = txtObservaciones.Text
            };

            listaPaquetesActual.Add(paquete);

            // Limpiamos observaciones
            txtObservaciones.Clear();
        }

        private void btnQuitarPaquete_Click(object sender, EventArgs e)
        {
            if (dgvPaquetes.SelectedRows.Count > 0)
            {
                var paquetesParaEliminar = new List<PaqueteOca>();
                foreach (DataGridViewRow row in dgvPaquetes.SelectedRows)
                {
                    if (!row.IsNewRow && row.DataBoundItem is PaqueteOca pq)
                    {
                        paquetesParaEliminar.Add(pq);
                    }
                }

                foreach (var pq in paquetesParaEliminar)
                {
                    listaPaquetesActual.Remove(pq);
                }
            }
        }

        private void btnAgregarEnvioAlLote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestinatario.Text) || listaPaquetesActual.Count == 0)
            {
                MessageBox.Show("Debe indicar al menos un destinatario y un bulto.", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idOperativa = 283231; // Default: EstÃ¡ndar Sin Seguro
            if (chkPrioritario.Checked && chkSeguro.Checked) idOperativa = 416557; // Prioritario con seguro
            else if (!chkPrioritario.Checked && chkSeguro.Checked) idOperativa = 416558; // EstÃ¡ndar con seguro
            else if (chkPrioritario.Checked && !chkSeguro.Checked) idOperativa = 283228; // Prioritario sin seguro
            else if (!chkPrioritario.Checked && !chkSeguro.Checked) idOperativa = 283231; // EstÃ¡ndar sin seguro

            var envio = new EnvioOca
            {
                IdOperativa = idOperativa,
                Remito = txtRemito.Text,
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
            txtRemito.Clear();
            txtDestinatario.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            txtPiso.Clear();
            txtLocalidad.Clear();
            txtProvincia.Clear();
            txtCP.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            listaPaquetesActual.Clear();
            
            // Foco a Remito
            txtRemito.Focus();
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
                    
                    // Buscamos la guÃ­a generada para este remito particular en la respuesta de OCA
                    var infoGuia = ocaRespuesta.EnviosGenerados.FirstOrDefault(g => 
                        g.NumeroRemito.TrimStart('0') == envio.Remito.TrimStart('0') || 
                        g.NumeroRemito == envio.Remito);
                        
                    string trackingNumber = infoGuia != null && !string.IsNullOrWhiteSpace(infoGuia.NumeroEnvio) ? infoGuia.NumeroEnvio : "S/D";

                    string destFinalAuditoria = $"{envio.NombreDestinatario} ({direccionCompleta}, {envio.Localidad}) [Tracking: {trackingNumber} | Bultos: {envio.BultosTotales}]";

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








