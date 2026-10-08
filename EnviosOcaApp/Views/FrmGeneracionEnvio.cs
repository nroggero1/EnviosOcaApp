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

        public FrmGeneracionEnvio()
        {
            InitializeComponent();
            listaPaquetesActual = new BindingList<PaqueteOca>();
            listaLoteEnvios = new BindingList<EnvioOca>();
            OrganizarLayoutResponsivo();
        }

        private void OrganizarLayoutResponsivo()
        {
            // 0. Recreamos el layout de Operador
            var tlpOperador = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                AutoSize = true,
                Padding = new Padding(5)
            };
            tlpOperador.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpOperador.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tlpOperador.Controls.Add(lblUsuario, 0, 0);
            tlpOperador.Controls.Add(txtUsuario, 1, 0);
            txtUsuario.Dock = DockStyle.Fill;

            // 0.1 Recreamos el layout de Origen
            var tlpOrigen = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 6,
                RowCount = 1,
                AutoSize = true,
                Padding = new Padding(5)
            };
            tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpOrigen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));

            tlpOrigen.Controls.Add(lblEmpresa, 0, 0);
            tlpOrigen.Controls.Add(cmbEmpresa, 1, 0);
            cmbEmpresa.Dock = DockStyle.Fill;

            tlpOrigen.Controls.Add(lblApellidoRemitente, 2, 0);
            tlpOrigen.Controls.Add(txtApellidoRemitente, 3, 0);
            txtApellidoRemitente.Dock = DockStyle.Fill;

            tlpOrigen.Controls.Add(lblNombreRemitente, 4, 0);
            tlpOrigen.Controls.Add(txtNombreRemitente, 5, 0);
            txtNombreRemitente.Dock = DockStyle.Fill;

            foreach (Control c in tlpOperador.Controls) {
                if (c is Label lbl) {
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            foreach (Control c in tlpOrigen.Controls) {
                if (c is Label lbl) {
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            var tlpGlobal = (TableLayoutPanel)this.Controls.Find("tlpGlobal", true)[0];
            var grpOperador = (GroupBox)tlpGlobal.Controls.Find("grpOperador", true)[0];
            grpOperador.Controls.Clear();
            grpOperador.Controls.Add(tlpOperador);

            var grpOrigen = (GroupBox)tlpGlobal.Controls.Find("grpOrigen", true)[0];
            grpOrigen.Controls.Clear();
            grpOrigen.Controls.Add(tlpOrigen);

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
            chkPrioritario = new CheckBox { Text = "Envío Prioritario", AutoSize = true };
            chkSeguro = new CheckBox { Text = "Asegurar Envío", AutoSize = true };
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
        private TextBox txtNombreRemitente = new TextBox();
        private TextBox txtApellidoRemitente = new TextBox();
        private Label lblNombreRemitente = new Label { Text = "Nombre:", AutoSize = true };
        private Label lblApellidoRemitente = new Label { Text = "Apellido:", AutoSize = true };

        private void FrmGeneracionEnvio_Load(object sender, EventArgs e)
        {
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
            if (System.IO.File.Exists(usersPath))
            {
                string jsonUsers = System.IO.File.ReadAllText(usersPath);
                var usuarios = System.Text.Json.JsonSerializer.Deserialize<List<UsuarioApp>>(jsonUsers);
                
                if (usuarios != null)
                {
                    var currentUser = usuarios.FirstOrDefault(u => u.UsernameWindows.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase));
                    if (currentUser != null)
                    {
                        txtNombreRemitente.Text = currentUser.Nombre;
                        txtApellidoRemitente.Text = currentUser.Apellido;

                        foreach (var item in cmbEmpresa.Items)
                        {
                            if (item is EmpresaOca emp && emp.Nombre.Equals(currentUser.EmpresaDefecto, StringComparison.OrdinalIgnoreCase))
                            {
                                cmbEmpresa.SelectedItem = item;
                                break;
                            }
                        }

                        if (!currentUser.EsAdministrador)
                        {
                            txtNombreRemitente.ReadOnly = true;
                            txtApellidoRemitente.ReadOnly = true;
                            cmbEmpresa.Enabled = false;
                        }
                    }
                }
            }

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
                MessageBox.Show("Verifique que las dimensiones, peso y valor sean numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            int idOperativa = 283231; // Default: Estándar Sin Seguro
            if (chkPrioritario.Checked && chkSeguro.Checked) idOperativa = 416557; // Prioritario con seguro
            else if (!chkPrioritario.Checked && chkSeguro.Checked) idOperativa = 416558; // Estándar con seguro
            else if (chkPrioritario.Checked && !chkSeguro.Checked) idOperativa = 283228; // Prioritario sin seguro
            else if (!chkPrioritario.Checked && !chkSeguro.Checked) idOperativa = 283231; // Estándar sin seguro

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
                MessageBox.Show("El lote está vacío. Por favor añada al menos un envío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEmpresa.SelectedItem is not EmpresaOca empresaSeleccionada)
            {
                MessageBox.Show("Debe seleccionar una empresa válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string remitente = $"{txtApellidoRemitente.Text.Trim()} {txtNombreRemitente.Text.Trim()}".Trim();

            try
            {
                btnGenerar.Enabled = false;
                btnGenerar.Text = "Transmitiendo...";
                lblStatus.Text = "Conectando con OCA...";
                lblStatus.ForeColor = Color.Blue;
                
                var loteParaEnviar = listaLoteEnvios.ToList();

                // 1. Llamamos al servicio OCA y obtenemos el objeto de respuesta completo (LLAMADA REAL)
                OcaResponse ocaRespuesta = await Program.OcaService.GenerarLoteRealAsync(empresaSeleccionada, remitente, loteParaEnviar);

                if (ocaRespuesta.TieneErrores)
                {
                    lblStatus.Text = "Falló la transmisión.";
                    lblStatus.ForeColor = Color.Red;
                    MessageBox.Show($"OCA rechazó el envío: {ocaRespuesta.MensajeError}", "Error de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Transmisión exitosa. Loggeamos en el Excel
                foreach (var envio in loteParaEnviar)
                {
                    string direccionCompleta = $"{envio.Calle} {envio.Numero} {envio.Piso}".Trim();
                    
                    // Buscamos la guía generada para este remito particular en la respuesta de OCA
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
                lblStatus.Text = $"¡Éxito! Operación: {ocaRespuesta.CodigoOperacion} ({ocaRespuesta.EnviosGenerados.Count} guías / {totalPaquetesLote} paquetes).";
                
                string msgBoxOp = string.IsNullOrWhiteSpace(ocaRespuesta.CodigoOperacion) ? "(Individuales)" : ocaRespuesta.CodigoOperacion;

                MessageBox.Show($"Transmisión del Lote generada exitosamente.\nN° Operación: {msgBoxOp}\nDestinatarios: {ocaRespuesta.EnviosGenerados.Count}\nTotal Etiquetas a imprimir: {totalPaquetesLote}", "Transmisión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listaLoteEnvios.Clear();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error interno.";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Ocurrió un error inesperado:\n{ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerar.Enabled = true;
                btnGenerar.Text = "Transmitir Lote OCA";
            }
        }
    }
}
