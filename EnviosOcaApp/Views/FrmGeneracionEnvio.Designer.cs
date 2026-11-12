using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnviosOcaApp.Views
{
    partial class FrmGeneracionEnvio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitulo = new Label();
            grpOperador = new GroupBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            tlpGlobal = new TableLayoutPanel();
            grpOrigen = new GroupBox();
            lblEmpresa = new Label();
            cmbEmpresa = new ComboBox();
            lblOficina = new Label();
            cmbOficina = new ComboBox();
            lblDireccionOficina = new Label();
            lblRemitenteApellido = new Label();
            txtRemitenteApellido = new TextBox();
            lblRemitenteNombre = new Label();
            txtRemitenteNombre = new TextBox();
            lblRemitente = new Label();
            txtRemitente = new TextBox();
            grpComposicion = new GroupBox();
            tlpComposicion = new TableLayoutPanel();
            grpDestino = new GroupBox();
            lblDestinatario = new Label();
            txtDestinatario = new TextBox();
            lblCalle = new Label();
            txtCalle = new TextBox();
            lblNumero = new Label();
            txtNumero = new TextBox();
            lblPiso = new Label();
            txtPiso = new TextBox();
            lblLocalidad = new Label();
            txtLocalidad = new TextBox();
            lblProvincia = new Label();
            txtProvincia = new TextBox();
            lblCP = new Label();
            txtCP = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            grpPaquete = new GroupBox();
            lblDimensiones = new Label();
            lblTamanoPaquete = new Label();
            cmbTamanoPaquete = new ComboBox();
            txtAlto = new TextBox();
            txtAncho = new TextBox();
            txtLargo = new TextBox();
            lblMultiplicadorDimensiones1 = new Label();
            lblMultiplicadorDimensiones2 = new Label();
            lblPeso = new Label();
            txtPeso = new TextBox();
            lblValor = new Label();
            txtValor = new TextBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            chkSeguro = new CheckBox();
            btnAgregarPaquete = new Button();
            btnQuitarPaquete = new Button();
            btnAgregarEnvioAlLote = new Button();
            dgvPaquetes = new DataGridView();
            lblRemito = new Label();
            txtRemito = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            grpLote = new GroupBox();
            dgvLoteEnvios = new DataGridView();
            btnQuitarEnvio = new Button();
            btnGenerar = new Button();
            lblStatus = new Label();
            panelAcciones = new TableLayoutPanel();
            layoutPrincipal = new TableLayoutPanel();
            panelHeader.SuspendLayout();
            grpOperador.SuspendLayout();
            tlpGlobal.SuspendLayout();
            grpOrigen.SuspendLayout();
            grpComposicion.SuspendLayout();
            tlpComposicion.SuspendLayout();
            grpDestino.SuspendLayout();
            grpPaquete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaquetes).BeginInit();
            grpLote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoteEnvios).BeginInit();
            panelAcciones.SuspendLayout();
            layoutPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(246, 246, 247);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(8, 9);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1115, 35);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 17.5F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(167, 3, 85);
            lblTitulo.Location = new Point(14, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(549, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Generación de Envíos OCA (Multidestinatario)";
            // 
            // grpOperador
            // 
            grpOperador.Controls.Add(lblUsuario);
            grpOperador.Controls.Add(txtUsuario);
            grpOperador.Dock = DockStyle.Fill;
            grpOperador.Location = new Point(2, 3);
            grpOperador.Margin = new Padding(2, 3, 2, 3);
            grpOperador.Name = "grpOperador";
            grpOperador.Padding = new Padding(3, 4, 3, 4);
            grpOperador.Size = new Size(388, 126);
            grpOperador.TabIndex = 1;
            grpOperador.TabStop = false;
            grpOperador.Text = "Datos Globales: Operador";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(23, 40);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsuario.Enabled = false;
            txtUsuario.Location = new Point(114, 36);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.ReadOnly = true;
            txtUsuario.Size = new Size(250, 23);
            txtUsuario.TabIndex = 0;
            // 
            // tlpGlobal
            // 
            tlpGlobal.ColumnCount = 2;
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlpGlobal.Controls.Add(grpOperador, 0, 0);
            tlpGlobal.Controls.Add(grpOrigen, 1, 0);
            tlpGlobal.Dock = DockStyle.Fill;
            tlpGlobal.Location = new Point(5, 48);
            tlpGlobal.Margin = new Padding(0);
            tlpGlobal.Name = "tlpGlobal";
            tlpGlobal.RowCount = 1;
            tlpGlobal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpGlobal.Size = new Size(1121, 132);
            tlpGlobal.TabIndex = 0;
            // 
            // grpOrigen
            // 
            grpOrigen.Controls.Add(lblEmpresa);
            grpOrigen.Controls.Add(cmbEmpresa);
            grpOrigen.Controls.Add(lblOficina);
            grpOrigen.Controls.Add(cmbOficina);
            grpOrigen.Controls.Add(lblDireccionOficina);
            grpOrigen.Controls.Add(lblRemitenteApellido);
            grpOrigen.Controls.Add(txtRemitenteApellido);
            grpOrigen.Controls.Add(lblRemitenteNombre);
            grpOrigen.Controls.Add(txtRemitenteNombre);
            grpOrigen.Dock = DockStyle.Fill;
            grpOrigen.Location = new Point(394, 3);
            grpOrigen.Margin = new Padding(2, 3, 2, 3);
            grpOrigen.Name = "grpOrigen";
            grpOrigen.Padding = new Padding(3, 4, 3, 4);
            grpOrigen.Size = new Size(725, 126);
            grpOrigen.TabIndex = 2;
            grpOrigen.TabStop = false;
            grpOrigen.Text = "Datos Globales: Origen del Lote";
            // 
            // lblEmpresa
            // 
            lblEmpresa.AutoSize = true;
            lblEmpresa.Location = new Point(8, 21);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new Size(69, 20);
            lblEmpresa.TabIndex = 0;
            lblEmpresa.Text = "Empresa:";
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpresa.FormattingEnabled = true;
            cmbEmpresa.Location = new Point(98, 19);
            cmbEmpresa.Margin = new Padding(3, 4, 3, 4);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new Size(812, 28);
            cmbEmpresa.TabIndex = 0;
            // 
            // lblOficina
            // 
            lblOficina.AutoSize = true;
            lblOficina.Location = new Point(8, 47);
            lblOficina.Name = "lblOficina";
            lblOficina.Size = new Size(59, 20);
            lblOficina.TabIndex = 1;
            lblOficina.Text = "Oficina:";
            // 
            // cmbOficina
            // 
            cmbOficina.Location = new Point(98, 44);
            cmbOficina.Name = "cmbOficina";
            cmbOficina.Size = new Size(620, 28);
            cmbOficina.TabIndex = 2;
            // 
            // lblDireccionOficina
            // 
            lblDireccionOficina.Location = new Point(11, 72);
            lblDireccionOficina.Name = "lblDireccionOficina";
            lblDireccionOficina.Size = new Size(704, 20);
            lblDireccionOficina.TabIndex = 3;
            lblDireccionOficina.Text = "Dirección de la oficina seleccionada";
            // 
            // lblRemitenteApellido
            // 
            lblRemitenteApellido.AutoSize = true;
            lblRemitenteApellido.Location = new Point(8, 101);
            lblRemitenteApellido.Name = "lblRemitenteApellido";
            lblRemitenteApellido.Size = new Size(106, 20);
            lblRemitenteApellido.TabIndex = 4;
            lblRemitenteApellido.Text = "Ap. Remitente:";
            // 
            // txtRemitenteApellido
            // 
            txtRemitenteApellido.Location = new Point(98, 99);
            txtRemitenteApellido.Name = "txtRemitenteApellido";
            txtRemitenteApellido.Size = new Size(250, 23);
            txtRemitenteApellido.TabIndex = 5;
            // 
            // lblRemitenteNombre
            // 
            lblRemitenteNombre.AutoSize = true;
            lblRemitenteNombre.Location = new Point(357, 101);
            lblRemitenteNombre.Name = "lblRemitenteNombre";
            lblRemitenteNombre.Size = new Size(120, 20);
            lblRemitenteNombre.TabIndex = 6;
            lblRemitenteNombre.Text = "Nom. Remitente:";
            // 
            // txtRemitenteNombre
            // 
            txtRemitenteNombre.Location = new Point(465, 99);
            txtRemitenteNombre.Name = "txtRemitenteNombre";
            txtRemitenteNombre.Size = new Size(253, 23);
            txtRemitenteNombre.TabIndex = 7;
            // 
            // lblRemitente
            // 
            lblRemitente.AutoSize = true;
            lblRemitente.Location = new Point(240, 40);
            lblRemitente.Name = "lblRemitente";
            lblRemitente.Size = new Size(80, 20);
            lblRemitente.TabIndex = 2;
            lblRemitente.Text = "Remitente:";
            lblRemitente.Visible = false;
            // 
            // txtRemitente
            // 
            txtRemitente.Location = new Point(320, 36);
            txtRemitente.Margin = new Padding(3, 4, 3, 4);
            txtRemitente.Name = "txtRemitente";
            txtRemitente.Size = new Size(182, 27);
            txtRemitente.TabIndex = 1;
            txtRemitente.Visible = false;
            // 
            // grpComposicion
            // 
            grpComposicion.Controls.Add(tlpComposicion);
            grpComposicion.Dock = DockStyle.Fill;
            grpComposicion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            grpComposicion.Location = new Point(7, 183);
            grpComposicion.Margin = new Padding(2, 3, 2, 3);
            grpComposicion.Name = "grpComposicion";
            grpComposicion.Padding = new Padding(3, 4, 3, 4);
            grpComposicion.Size = new Size(1117, 327);
            grpComposicion.TabIndex = 3;
            grpComposicion.TabStop = false;
            grpComposicion.Text = "1. Composición de Envío Individual";
            // 
            // tlpComposicion
            // 
            tlpComposicion.ColumnCount = 2;
            tlpComposicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpComposicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpComposicion.Controls.Add(grpDestino, 0, 0);
            tlpComposicion.Controls.Add(grpPaquete, 1, 0);
            tlpComposicion.Dock = DockStyle.Fill;
            tlpComposicion.Font = new Font("Segoe UI", 11.25F);
            tlpComposicion.Location = new Point(3, 24);
            tlpComposicion.Margin = new Padding(0);
            tlpComposicion.Name = "tlpComposicion";
            tlpComposicion.RowCount = 1;
            tlpComposicion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpComposicion.Size = new Size(1111, 299);
            tlpComposicion.TabIndex = 0;
            // 
            // grpDestino
            // 
            grpDestino.Controls.Add(lblDestinatario);
            grpDestino.Controls.Add(txtDestinatario);
            grpDestino.Controls.Add(lblCalle);
            grpDestino.Controls.Add(txtCalle);
            grpDestino.Controls.Add(lblNumero);
            grpDestino.Controls.Add(txtNumero);
            grpDestino.Controls.Add(lblPiso);
            grpDestino.Controls.Add(txtPiso);
            grpDestino.Controls.Add(lblLocalidad);
            grpDestino.Controls.Add(txtLocalidad);
            grpDestino.Controls.Add(lblProvincia);
            grpDestino.Controls.Add(txtProvincia);
            grpDestino.Controls.Add(lblCP);
            grpDestino.Controls.Add(txtCP);
            grpDestino.Controls.Add(lblEmail);
            grpDestino.Controls.Add(txtEmail);
            grpDestino.Dock = DockStyle.Fill;
            grpDestino.Location = new Point(3, 4);
            grpDestino.Margin = new Padding(3, 4, 3, 4);
            grpDestino.Name = "grpDestino";
            grpDestino.Padding = new Padding(6, 5, 6, 5);
            grpDestino.Size = new Size(549, 291);
            grpDestino.TabIndex = 0;
            grpDestino.TabStop = false;
            grpDestino.Text = "Datos del destinatario";
            // 
            // lblDestinatario
            // 
            lblDestinatario.AutoSize = true;
            lblDestinatario.Location = new Point(9, 25);
            lblDestinatario.Name = "lblDestinatario";
            lblDestinatario.Size = new Size(89, 20);
            lblDestinatario.TabIndex = 0;
            lblDestinatario.Text = "Nombre/Rz:";
            // 
            // txtDestinatario
            // 
            txtDestinatario.Location = new Point(112, 21);
            txtDestinatario.Margin = new Padding(3, 4, 3, 4);
            txtDestinatario.Name = "txtDestinatario";
            txtDestinatario.Size = new Size(422, 27);
            txtDestinatario.TabIndex = 3;
            // 
            // lblCalle
            // 
            lblCalle.AutoSize = true;
            lblCalle.Location = new Point(9, 57);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(45, 20);
            lblCalle.TabIndex = 2;
            lblCalle.Text = "Calle:";
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(112, 53);
            txtCalle.Margin = new Padding(3, 4, 3, 4);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(422, 27);
            txtCalle.TabIndex = 4;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(9, 89);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(37, 20);
            lblNumero.TabIndex = 4;
            lblNumero.Text = "Nro:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(112, 85);
            txtNumero.Margin = new Padding(3, 4, 3, 4);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(194, 27);
            txtNumero.TabIndex = 5;
            // 
            // lblPiso
            // 
            lblPiso.AutoSize = true;
            lblPiso.Location = new Point(312, 89);
            lblPiso.Name = "lblPiso";
            lblPiso.Size = new Size(39, 20);
            lblPiso.TabIndex = 6;
            lblPiso.Text = "Piso:";
            // 
            // txtPiso
            // 
            txtPiso.Location = new Point(360, 85);
            txtPiso.Margin = new Padding(3, 4, 3, 4);
            txtPiso.Name = "txtPiso";
            txtPiso.Size = new Size(174, 27);
            txtPiso.TabIndex = 6;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(9, 121);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(77, 20);
            lblLocalidad.TabIndex = 8;
            lblLocalidad.Text = "Localidad:";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(112, 117);
            txtLocalidad.Margin = new Padding(3, 4, 3, 4);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(422, 27);
            txtLocalidad.TabIndex = 7;
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(9, 153);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(41, 20);
            lblProvincia.TabIndex = 10;
            lblProvincia.Text = "Prov:";
            // 
            // txtProvincia
            // 
            txtProvincia.Location = new Point(112, 149);
            txtProvincia.Margin = new Padding(3, 4, 3, 4);
            txtProvincia.Name = "txtProvincia";
            txtProvincia.Size = new Size(194, 27);
            txtProvincia.TabIndex = 8;
            // 
            // lblCP
            // 
            lblCP.AutoSize = true;
            lblCP.Location = new Point(312, 153);
            lblCP.Name = "lblCP";
            lblCP.Size = new Size(29, 20);
            lblCP.TabIndex = 12;
            lblCP.Text = "CP:";
            // 
            // txtCP
            // 
            txtCP.Location = new Point(360, 149);
            txtCP.Margin = new Padding(3, 4, 3, 4);
            txtCP.Name = "txtCP";
            txtCP.Size = new Size(174, 27);
            txtCP.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(9, 185);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 20);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(112, 181);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(422, 27);
            txtEmail.TabIndex = 10;
            // 
            // grpPaquete
            // 
            grpPaquete.Controls.Add(lblDimensiones);
            grpPaquete.Controls.Add(lblTamanoPaquete);
            grpPaquete.Controls.Add(cmbTamanoPaquete);
            grpPaquete.Controls.Add(txtAlto);
            grpPaquete.Controls.Add(txtAncho);
            grpPaquete.Controls.Add(txtLargo);
            grpPaquete.Controls.Add(lblMultiplicadorDimensiones1);
            grpPaquete.Controls.Add(lblMultiplicadorDimensiones2);
            grpPaquete.Controls.Add(lblPeso);
            grpPaquete.Controls.Add(txtPeso);
            grpPaquete.Controls.Add(lblValor);
            grpPaquete.Controls.Add(txtValor);
            grpPaquete.Controls.Add(lblObservaciones);
            grpPaquete.Controls.Add(txtObservaciones);
            grpPaquete.Controls.Add(chkSeguro);
            grpPaquete.Controls.Add(btnAgregarPaquete);
            grpPaquete.Controls.Add(btnQuitarPaquete);
            grpPaquete.Controls.Add(btnAgregarEnvioAlLote);
            grpPaquete.Controls.Add(dgvPaquetes);
            grpPaquete.Dock = DockStyle.Fill;
            grpPaquete.Location = new Point(558, 4);
            grpPaquete.Margin = new Padding(3, 4, 3, 4);
            grpPaquete.Name = "grpPaquete";
            grpPaquete.Padding = new Padding(6, 5, 6, 5);
            grpPaquete.Size = new Size(550, 291);
            grpPaquete.TabIndex = 1;
            grpPaquete.TabStop = false;
            grpPaquete.Text = "Bultos del Envío (Paquetes)";
            // 
            // lblDimensiones
            // 
            lblDimensiones.AutoSize = true;
            lblDimensiones.Location = new Point(9, 57);
            lblDimensiones.Name = "lblDimensiones";
            lblDimensiones.Size = new Size(77, 20);
            lblDimensiones.TabIndex = 0;
            lblDimensiones.Text = "Dim. (cm):";
            // 
            // lblTamanoPaquete
            // 
            lblTamanoPaquete.AutoSize = true;
            lblTamanoPaquete.Location = new Point(9, 25);
            lblTamanoPaquete.Name = "lblTamanoPaquete";
            lblTamanoPaquete.Size = new Size(103, 20);
            lblTamanoPaquete.TabIndex = 1;
            lblTamanoPaquete.Text = "Tamaño Bulto:";
            // 
            // cmbTamanoPaquete
            // 
            cmbTamanoPaquete.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTamanoPaquete.Location = new Point(112, 21);
            cmbTamanoPaquete.Name = "cmbTamanoPaquete";
            cmbTamanoPaquete.Size = new Size(422, 28);
            cmbTamanoPaquete.TabIndex = 2;
            // 
            // txtAlto
            // 
            txtAlto.Location = new Point(112, 53);
            txtAlto.Margin = new Padding(3, 4, 3, 4);
            txtAlto.Name = "txtAlto";
            txtAlto.Size = new Size(41, 27);
            txtAlto.TabIndex = 12;
            txtAlto.Text = "10";
            // 
            // txtAncho
            // 
            txtAncho.Location = new Point(170, 53);
            txtAncho.Margin = new Padding(3, 4, 3, 4);
            txtAncho.Name = "txtAncho";
            txtAncho.Size = new Size(41, 27);
            txtAncho.TabIndex = 13;
            txtAncho.Text = "10";
            // 
            // txtLargo
            // 
            txtLargo.Location = new Point(229, 53);
            txtLargo.Margin = new Padding(3, 4, 3, 4);
            txtLargo.Name = "txtLargo";
            txtLargo.Size = new Size(41, 27);
            txtLargo.TabIndex = 14;
            txtLargo.Text = "10";
            // 
            // lblMultiplicadorDimensiones1
            // 
            lblMultiplicadorDimensiones1.AutoSize = true;
            lblMultiplicadorDimensiones1.Location = new Point(155, 57);
            lblMultiplicadorDimensiones1.Name = "lblMultiplicadorDimensiones1";
            lblMultiplicadorDimensiones1.Size = new Size(16, 20);
            lblMultiplicadorDimensiones1.TabIndex = 15;
            lblMultiplicadorDimensiones1.Text = "x";
            // 
            // lblMultiplicadorDimensiones2
            // 
            lblMultiplicadorDimensiones2.AutoSize = true;
            lblMultiplicadorDimensiones2.Location = new Point(213, 57);
            lblMultiplicadorDimensiones2.Name = "lblMultiplicadorDimensiones2";
            lblMultiplicadorDimensiones2.Size = new Size(16, 20);
            lblMultiplicadorDimensiones2.TabIndex = 16;
            lblMultiplicadorDimensiones2.Text = "x";
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(277, 57);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(72, 20);
            lblPeso.TabIndex = 4;
            lblPeso.Text = "Peso (kg):";
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(330, 53);
            txtPeso.Margin = new Padding(3, 4, 3, 4);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(204, 27);
            txtPeso.TabIndex = 15;
            txtPeso.Text = "1";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(9, 89);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(58, 20);
            lblValor.TabIndex = 6;
            lblValor.Text = "Valor $:";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(112, 85);
            txtValor.Margin = new Padding(3, 4, 3, 4);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(150, 27);
            txtValor.TabIndex = 16;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(277, 89);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(108, 20);
            lblObservaciones.TabIndex = 8;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(371, 85);
            txtObservaciones.Margin = new Padding(3, 4, 3, 4);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(163, 27);
            txtObservaciones.TabIndex = 17;
            // 
            // chkSeguro
            // 
            chkSeguro.AutoSize = true;
            chkSeguro.Location = new Point(9, 119);
            chkSeguro.Name = "chkSeguro";
            chkSeguro.Size = new Size(130, 24);
            chkSeguro.TabIndex = 18;
            chkSeguro.Text = "Asegurar Envío";
            // 
            // btnAgregarPaquete
            // 
            btnAgregarPaquete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarPaquete.Location = new Point(180, 115);
            btnAgregarPaquete.Margin = new Padding(3, 4, 3, 4);
            btnAgregarPaquete.Name = "btnAgregarPaquete";
            btnAgregarPaquete.Size = new Size(91, 33);
            btnAgregarPaquete.TabIndex = 18;
            btnAgregarPaquete.Text = "+ Bulto";
            btnAgregarPaquete.UseVisualStyleBackColor = true;
            btnAgregarPaquete.Click += btnAgregarPaquete_Click;
            // 
            // btnQuitarPaquete
            // 
            btnQuitarPaquete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarPaquete.Location = new Point(278, 115);
            btnQuitarPaquete.Margin = new Padding(3, 4, 3, 4);
            btnQuitarPaquete.Name = "btnQuitarPaquete";
            btnQuitarPaquete.Size = new Size(86, 33);
            btnQuitarPaquete.TabIndex = 19;
            btnQuitarPaquete.Text = "- Quitar";
            btnQuitarPaquete.UseVisualStyleBackColor = true;
            btnQuitarPaquete.Click += btnQuitarPaquete_Click;
            // 
            // btnAgregarEnvioAlLote
            // 
            btnAgregarEnvioAlLote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarEnvioAlLote.BackColor = Color.LightBlue;
            btnAgregarEnvioAlLote.FlatStyle = FlatStyle.Flat;
            btnAgregarEnvioAlLote.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnAgregarEnvioAlLote.ForeColor = Color.Black;
            btnAgregarEnvioAlLote.Location = new Point(368, 115);
            btnAgregarEnvioAlLote.Margin = new Padding(3, 4, 3, 4);
            btnAgregarEnvioAlLote.Name = "btnAgregarEnvioAlLote";
            btnAgregarEnvioAlLote.Size = new Size(139, 33);
            btnAgregarEnvioAlLote.TabIndex = 21;
            btnAgregarEnvioAlLote.Text = "Agregar al lote";
            btnAgregarEnvioAlLote.UseVisualStyleBackColor = false;
            btnAgregarEnvioAlLote.Click += btnAgregarEnvioAlLote_Click;
            // 
            // dgvPaquetes
            // 
            dgvPaquetes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPaquetes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaquetes.Location = new Point(9, 149);
            dgvPaquetes.Margin = new Padding(3, 4, 3, 4);
            dgvPaquetes.Name = "dgvPaquetes";
            dgvPaquetes.RowHeadersWidth = 51;
            dgvPaquetes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaquetes.Size = new Size(496, 99);
            dgvPaquetes.TabIndex = 20;
            // 
            // lblRemito
            // 
            lblRemito.AutoSize = true;
            lblRemito.Location = new Point(11, 33);
            lblRemito.Name = "lblRemito";
            lblRemito.Size = new Size(88, 20);
            lblRemito.TabIndex = 4;
            lblRemito.Text = "Ref/Remito:";
            lblRemito.Visible = false;
            // 
            // txtRemito
            // 
            txtRemito.Location = new Point(120, 29);
            txtRemito.Margin = new Padding(3, 4, 3, 4);
            txtRemito.Name = "txtRemito";
            txtRemito.Size = new Size(319, 27);
            txtRemito.TabIndex = 2;
            txtRemito.Visible = false;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(234, 193);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(31, 20);
            lblTelefono.TabIndex = 16;
            lblTelefono.Text = "Tel:";
            lblTelefono.Visible = false;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(280, 189);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 27);
            txtTelefono.TabIndex = 11;
            txtTelefono.Visible = false;
            // 
            // grpLote
            // 
            grpLote.Controls.Add(dgvLoteEnvios);
            grpLote.Controls.Add(btnQuitarEnvio);
            grpLote.Controls.Add(btnGenerar);
            grpLote.Dock = DockStyle.Fill;
            grpLote.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            grpLote.Location = new Point(7, 516);
            grpLote.Margin = new Padding(2, 3, 2, 3);
            grpLote.Name = "grpLote";
            grpLote.Padding = new Padding(3, 4, 3, 4);
            grpLote.Size = new Size(1117, 137);
            grpLote.TabIndex = 4;
            grpLote.TabStop = false;
            grpLote.Text = "2. Lote (Envíos listos para confirmar)";
            // 
            // dgvLoteEnvios
            // 
            dgvLoteEnvios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLoteEnvios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoteEnvios.Font = new Font("Segoe UI", 11.25F);
            dgvLoteEnvios.Location = new Point(9, 21);
            dgvLoteEnvios.Margin = new Padding(3, 4, 3, 4);
            dgvLoteEnvios.Name = "dgvLoteEnvios";
            dgvLoteEnvios.ReadOnly = true;
            dgvLoteEnvios.RowHeadersWidth = 51;
            dgvLoteEnvios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoteEnvios.Size = new Size(958, 108);
            dgvLoteEnvios.TabIndex = 22;
            // 
            // btnQuitarEnvio
            // 
            btnQuitarEnvio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarEnvio.Font = new Font("Segoe UI", 11.25F);
            btnQuitarEnvio.Location = new Point(974, 21);
            btnQuitarEnvio.Margin = new Padding(3, 4, 3, 4);
            btnQuitarEnvio.Name = "btnQuitarEnvio";
            btnQuitarEnvio.Size = new Size(130, 39);
            btnQuitarEnvio.TabIndex = 23;
            btnQuitarEnvio.Text = "Quitar sel.";
            btnQuitarEnvio.UseVisualStyleBackColor = true;
            btnQuitarEnvio.Click += btnQuitarEnvio_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerar.BackColor = Color.FromArgb(167, 3, 85);
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Location = new Point(974, 68);
            btnGenerar.Margin = new Padding(3, 4, 3, 4);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(130, 35);
            btnGenerar.TabIndex = 24;
            btnGenerar.Text = "Confirmar lote";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(3, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1109, 31);
            lblStatus.TabIndex = 5;
            // 
            // panelAcciones
            // 
            panelAcciones.ColumnCount = 1;
            panelAcciones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1115F));
            panelAcciones.Controls.Add(lblStatus, 0, 0);
            panelAcciones.Dock = DockStyle.Fill;
            panelAcciones.Location = new Point(8, 659);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.RowCount = 1;
            panelAcciones.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            panelAcciones.Size = new Size(1115, 30);
            panelAcciones.TabIndex = 5;
            // 
            // layoutPrincipal
            // 
            layoutPrincipal.ColumnCount = 1;
            layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPrincipal.Controls.Add(panelHeader, 0, 0);
            layoutPrincipal.Controls.Add(tlpGlobal, 0, 1);
            layoutPrincipal.Controls.Add(grpComposicion, 0, 2);
            layoutPrincipal.Controls.Add(grpLote, 0, 3);
            layoutPrincipal.Controls.Add(panelAcciones, 0, 4);
            layoutPrincipal.Dock = DockStyle.Fill;
            layoutPrincipal.Location = new Point(0, 0);
            layoutPrincipal.Margin = new Padding(0);
            layoutPrincipal.Name = "layoutPrincipal";
            layoutPrincipal.Padding = new Padding(5, 5, 5, 5);
            layoutPrincipal.RowCount = 5;
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 132F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutPrincipal.Size = new Size(1131, 697);
            layoutPrincipal.TabIndex = 0;
            // 
            // FrmGeneracionEnvio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1131, 697);
            Controls.Add(layoutPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmGeneracionEnvio";
            Text = "Generación de Envíos";
            Load += FrmGeneracionEnvio_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpOperador.ResumeLayout(false);
            grpOperador.PerformLayout();
            tlpGlobal.ResumeLayout(false);
            grpOrigen.ResumeLayout(false);
            grpOrigen.PerformLayout();
            grpComposicion.ResumeLayout(false);
            tlpComposicion.ResumeLayout(false);
            grpDestino.ResumeLayout(false);
            grpDestino.PerformLayout();
            grpPaquete.ResumeLayout(false);
            grpPaquete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaquetes).EndInit();
            grpLote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoteEnvios).EndInit();
            panelAcciones.ResumeLayout(false);
            panelAcciones.PerformLayout();
            layoutPrincipal.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        
        private System.Windows.Forms.TableLayoutPanel tlpGlobal;
        private System.Windows.Forms.GroupBox grpOperador;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.GroupBox grpOrigen;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label lblRemitente;
        private System.Windows.Forms.TextBox txtRemitente;
        private System.Windows.Forms.Label lblOficina;
        private System.Windows.Forms.ComboBox cmbOficina;
        private System.Windows.Forms.Label lblDireccionOficina;
        private System.Windows.Forms.Label lblRemitenteApellido;
        private System.Windows.Forms.TextBox txtRemitenteApellido;
        private System.Windows.Forms.Label lblRemitenteNombre;
        private System.Windows.Forms.TextBox txtRemitenteNombre;

        private System.Windows.Forms.GroupBox grpComposicion;
        private System.Windows.Forms.TableLayoutPanel tlpComposicion;
        private System.Windows.Forms.GroupBox grpDestino;
        private System.Windows.Forms.Label lblDestinatario;
        private System.Windows.Forms.TextBox txtDestinatario;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblRemito;
        private System.Windows.Forms.TextBox txtRemito;
        
        private System.Windows.Forms.GroupBox grpPaquete;
        private System.Windows.Forms.Label lblTamanoPaquete;
        private System.Windows.Forms.ComboBox cmbTamanoPaquete;
        private System.Windows.Forms.CheckBox chkSeguro;
        private System.Windows.Forms.Label lblDimensiones;
        private System.Windows.Forms.TextBox txtAlto;
        private System.Windows.Forms.TextBox txtAncho;
        private System.Windows.Forms.TextBox txtLargo;
        private System.Windows.Forms.Label lblMultiplicadorDimensiones1;
        private System.Windows.Forms.Label lblMultiplicadorDimensiones2;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnAgregarPaquete;
        private System.Windows.Forms.Button btnQuitarPaquete;
        private System.Windows.Forms.DataGridView dgvPaquetes;
        private System.Windows.Forms.Button btnAgregarEnvioAlLote;

        private System.Windows.Forms.GroupBox grpLote;
        private System.Windows.Forms.DataGridView dgvLoteEnvios;
        private System.Windows.Forms.Button btnQuitarEnvio;
        
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TableLayoutPanel panelAcciones;
        private System.Windows.Forms.TableLayoutPanel layoutPrincipal;
    }
}

