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
            lblRemitente = new Label();
            txtRemitente = new TextBox();
            lblOficina = new Label();
            cmbOficina = new ComboBox();
            lblDireccionOficina = new Label();
            lblRemitenteApellido = new Label();
            txtRemitenteApellido = new TextBox();
            lblRemitenteNombre = new Label();
            txtRemitenteNombre = new TextBox();
            grpComposicion = new GroupBox();
            btnAgregarEnvioAlLote = new Button();
            tlpComposicion = new TableLayoutPanel();
            grpDestino = new GroupBox();
            lblDestinatario = new Label();
            txtDestinatario = new TextBox();
            lblRemito = new Label();
            txtRemito = new TextBox();
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
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            grpPaquete = new GroupBox();
            lblTamanoPaquete = new Label();
            cmbTamanoPaquete = new ComboBox();
            lblDimensiones = new Label();
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
            dgvPaquetes = new DataGridView();
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
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(246, 246, 247);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1106, 67);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(167, 3, 85);
            lblTitulo.Location = new Point(23, 17);
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
            grpOperador.Location = new Point(3, 4);
            grpOperador.Margin = new Padding(3, 4, 3, 4);
            grpOperador.Name = "grpOperador";
            grpOperador.Padding = new Padding(3, 4, 3, 4);
            grpOperador.Size = new Size(533, 172);
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
            txtUsuario.Size = new Size(396, 27);
            txtUsuario.TabIndex = 0;
            // 
            // tlpGlobal
            // 
            tlpGlobal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpGlobal.ColumnCount = 2;
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlpGlobal.Controls.Add(grpOperador, 0, 0);
            tlpGlobal.Controls.Add(grpOrigen, 1, 0);
            tlpGlobal.Location = new Point(14, 75);
            tlpGlobal.Margin = new Padding(3, 4, 3, 4);
            tlpGlobal.Name = "tlpGlobal";
            tlpGlobal.RowCount = 1;
            tlpGlobal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpGlobal.Size = new Size(1078, 180);
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
            grpOrigen.Location = new Point(542, 4);
            grpOrigen.Margin = new Padding(3, 4, 3, 4);
            grpOrigen.Name = "grpOrigen";
            grpOrigen.Padding = new Padding(3, 4, 3, 4);
            grpOrigen.Size = new Size(533, 172);
            grpOrigen.TabIndex = 2;
            grpOrigen.TabStop = false;
            grpOrigen.Text = "Datos Globales: Origen del Lote";
            // 
            // lblEmpresa
            // 
            lblEmpresa.AutoSize = true;
            lblEmpresa.Location = new Point(11, 40);
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
            cmbEmpresa.Location = new Point(91, 36);
            cmbEmpresa.Margin = new Padding(3, 4, 3, 4);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new Size(148, 28);
            cmbEmpresa.TabIndex = 0;
            // 
            // lblRemitente
            // 
            lblRemitente.AutoSize = true;
            lblRemitente.Location = new Point(240, 40);
            lblRemitente.Name = "lblRemitente";
            lblRemitente.Size = new Size(80, 20);
            lblRemitente.TabIndex = 2;
            lblRemitente.Text = "Remitente:";
            // 
            // txtRemitente
            // 
            txtRemitente.Location = new Point(320, 36);
            txtRemitente.Margin = new Padding(3, 4, 3, 4);
            txtRemitente.Name = "txtRemitente";
            txtRemitente.Size = new Size(182, 27);
            txtRemitente.TabIndex = 1;
            // 
            // grpComposicion
            // 
            grpComposicion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpComposicion.Controls.Add(tlpComposicion);
            grpComposicion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpComposicion.Location = new Point(17, 265);
            grpComposicion.Margin = new Padding(3, 4, 3, 4);
            grpComposicion.Name = "grpComposicion";
            grpComposicion.Padding = new Padding(3, 4, 3, 4);
            grpComposicion.Size = new Size(1075, 430);
            grpComposicion.TabIndex = 3;
            grpComposicion.TabStop = false;
            grpComposicion.Text = "1. Composición de Envío Individual";
            // 
            // btnAgregarEnvioAlLote
            // 
            btnAgregarEnvioAlLote.Anchor = AnchorStyles.Bottom;
            btnAgregarEnvioAlLote.BackColor = Color.LightBlue;
            btnAgregarEnvioAlLote.FlatStyle = FlatStyle.Flat;
            btnAgregarEnvioAlLote.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregarEnvioAlLote.ForeColor = Color.Black;
            btnAgregarEnvioAlLote.Location = new Point(423, 382);
            btnAgregarEnvioAlLote.Margin = new Padding(3, 4, 3, 4);
            btnAgregarEnvioAlLote.Name = "btnAgregarEnvioAlLote";
            btnAgregarEnvioAlLote.Size = new Size(229, 38);
            btnAgregarEnvioAlLote.TabIndex = 21;
            btnAgregarEnvioAlLote.Text = "👇 Añadir envío al Lote 👇";
            btnAgregarEnvioAlLote.UseVisualStyleBackColor = false;
            btnAgregarEnvioAlLote.Click += btnAgregarEnvioAlLote_Click;
            // 
            // tlpComposicion
            // 
            tlpComposicion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpComposicion.ColumnCount = 2;
            tlpComposicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpComposicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tlpComposicion.Controls.Add(grpDestino, 0, 0);
            tlpComposicion.Controls.Add(grpPaquete, 1, 0);
            tlpComposicion.Font = new Font("Segoe UI", 9F);
            tlpComposicion.Location = new Point(7, 29);
            tlpComposicion.Margin = new Padding(3, 4, 3, 4);
            tlpComposicion.Name = "tlpComposicion";
            tlpComposicion.RowCount = 1;
            tlpComposicion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpComposicion.Size = new Size(1061, 345);
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
            grpDestino.Padding = new Padding(3, 4, 3, 4);
            grpDestino.Size = new Size(471, 337);
            grpDestino.TabIndex = 0;
            grpDestino.TabStop = false;
            grpDestino.Text = "Datos del destinatario";
            // 
            // lblDestinatario
            // 
            lblDestinatario.AutoSize = true;
            lblDestinatario.Location = new Point(11, 73);
            lblDestinatario.Name = "lblDestinatario";
            lblDestinatario.Size = new Size(89, 20);
            lblDestinatario.TabIndex = 0;
            lblDestinatario.Text = "Nombre/Rz:";
            // 
            // txtDestinatario
            // 
            txtDestinatario.Location = new Point(120, 69);
            txtDestinatario.Margin = new Padding(3, 4, 3, 4);
            txtDestinatario.Name = "txtDestinatario";
            txtDestinatario.Size = new Size(319, 27);
            txtDestinatario.TabIndex = 3;
            // 
            // lblRemito
            // 
            lblRemito.AutoSize = true;
            lblRemito.Location = new Point(11, 33);
            lblRemito.Name = "lblRemito";
            lblRemito.Size = new Size(88, 20);
            lblRemito.TabIndex = 4;
            lblRemito.Text = "Ref/Remito:";
            // 
            // txtRemito
            // 
            txtRemito.Location = new Point(120, 29);
            txtRemito.Margin = new Padding(3, 4, 3, 4);
            txtRemito.Name = "txtRemito";
            txtRemito.Size = new Size(319, 27);
            txtRemito.TabIndex = 2;
            // 
            // lblCalle
            // 
            lblCalle.AutoSize = true;
            lblCalle.Location = new Point(11, 113);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(45, 20);
            lblCalle.TabIndex = 2;
            lblCalle.Text = "Calle:";
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(69, 109);
            txtCalle.Margin = new Padding(3, 4, 3, 4);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(114, 27);
            txtCalle.TabIndex = 4;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(194, 113);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(37, 20);
            lblNumero.TabIndex = 4;
            lblNumero.Text = "Nro:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(246, 109);
            txtNumero.Margin = new Padding(3, 4, 3, 4);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(45, 27);
            txtNumero.TabIndex = 5;
            // 
            // lblPiso
            // 
            lblPiso.AutoSize = true;
            lblPiso.Location = new Point(303, 113);
            lblPiso.Name = "lblPiso";
            lblPiso.Size = new Size(39, 20);
            lblPiso.TabIndex = 6;
            lblPiso.Text = "Piso:";
            // 
            // txtPiso
            // 
            txtPiso.Location = new Point(354, 109);
            txtPiso.Margin = new Padding(3, 4, 3, 4);
            txtPiso.Name = "txtPiso";
            txtPiso.Size = new Size(45, 27);
            txtPiso.TabIndex = 6;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(11, 153);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(77, 20);
            lblLocalidad.TabIndex = 8;
            lblLocalidad.Text = "Localidad:";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(103, 149);
            txtLocalidad.Margin = new Padding(3, 4, 3, 4);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(114, 27);
            txtLocalidad.TabIndex = 7;
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(223, 153);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(41, 20);
            lblProvincia.TabIndex = 10;
            lblProvincia.Text = "Prov:";
            // 
            // txtProvincia
            // 
            txtProvincia.Location = new Point(274, 149);
            txtProvincia.Margin = new Padding(3, 4, 3, 4);
            txtProvincia.Name = "txtProvincia";
            txtProvincia.Size = new Size(79, 27);
            txtProvincia.TabIndex = 8;
            // 
            // lblCP
            // 
            lblCP.AutoSize = true;
            lblCP.Location = new Point(360, 153);
            lblCP.Name = "lblCP";
            lblCP.Size = new Size(29, 20);
            lblCP.TabIndex = 12;
            lblCP.Text = "CP:";
            // 
            // txtCP
            // 
            txtCP.Location = new Point(400, 149);
            txtCP.Margin = new Padding(3, 4, 3, 4);
            txtCP.Name = "txtCP";
            txtCP.Size = new Size(45, 27);
            txtCP.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(11, 193);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 20);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(80, 189);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(148, 27);
            txtEmail.TabIndex = 10;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(234, 193);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(31, 20);
            lblTelefono.TabIndex = 16;
            lblTelefono.Text = "Tel:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(280, 189);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 27);
            txtTelefono.TabIndex = 11;
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
            grpPaquete.Location = new Point(480, 4);
            grpPaquete.Margin = new Padding(3, 4, 3, 4);
            grpPaquete.Name = "grpPaquete";
            grpPaquete.Padding = new Padding(3, 4, 3, 4);
            grpPaquete.Size = new Size(578, 337);
            grpPaquete.TabIndex = 1;
            grpPaquete.TabStop = false;
            grpPaquete.Text = "Bultos del Envío (Paquetes)";
            // 
            // lblDimensiones
            // 
            lblDimensiones.AutoSize = true;
            lblDimensiones.Location = new Point(11, 33);
            lblDimensiones.Name = "lblDimensiones";
            lblDimensiones.Size = new Size(184, 20);
            lblDimensiones.TabIndex = 0;
            lblDimensiones.Text = "Alto x Ancho x Largo (cm):";
            // 
            // txtAlto
            // 
            txtAlto.Location = new Point(229, 29);
            txtAlto.Margin = new Padding(3, 4, 3, 4);
            txtAlto.Name = "txtAlto";
            txtAlto.Size = new Size(39, 27);
            txtAlto.TabIndex = 12;
            txtAlto.Text = "10";
            // 
            // txtAncho
            // 
            txtAncho.Location = new Point(274, 29);
            txtAncho.Margin = new Padding(3, 4, 3, 4);
            txtAncho.Name = "txtAncho";
            txtAncho.Size = new Size(39, 27);
            txtAncho.TabIndex = 13;
            txtAncho.Text = "10";
            // 
            // txtLargo
            // 
            txtLargo.Location = new Point(320, 29);
            txtLargo.Margin = new Padding(3, 4, 3, 4);
            txtLargo.Name = "txtLargo";
            txtLargo.Size = new Size(39, 27);
            txtLargo.TabIndex = 14;
            txtLargo.Text = "10";
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(371, 33);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(72, 20);
            lblPeso.TabIndex = 4;
            lblPeso.Text = "Peso (kg):";
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(457, 29);
            txtPeso.Margin = new Padding(3, 4, 3, 4);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(45, 27);
            txtPeso.TabIndex = 15;
            txtPeso.Text = "1";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(11, 73);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(58, 20);
            lblValor.TabIndex = 6;
            lblValor.Text = "Valor $:";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(86, 69);
            txtValor.Margin = new Padding(3, 4, 3, 4);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(57, 27);
            txtValor.TabIndex = 16;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(154, 73);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(108, 20);
            lblObservaciones.TabIndex = 8;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(286, 69);
            txtObservaciones.Margin = new Padding(3, 4, 3, 4);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(171, 27);
            txtObservaciones.TabIndex = 17;
            // 
            // btnAgregarPaquete
            // 
            btnAgregarPaquete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarPaquete.Location = new Point(240, 113);
            btnAgregarPaquete.Margin = new Padding(3, 4, 3, 4);
            btnAgregarPaquete.Name = "btnAgregarPaquete";
            btnAgregarPaquete.Size = new Size(114, 33);
            btnAgregarPaquete.TabIndex = 18;
            btnAgregarPaquete.Text = "+ Bulto";
            btnAgregarPaquete.UseVisualStyleBackColor = true;
            btnAgregarPaquete.Click += btnAgregarPaquete_Click;
            // 
            // btnQuitarPaquete
            // 
            btnQuitarPaquete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarPaquete.Location = new Point(365, 113);
            btnQuitarPaquete.Margin = new Padding(3, 4, 3, 4);
            btnQuitarPaquete.Name = "btnQuitarPaquete";
            btnQuitarPaquete.Size = new Size(103, 33);
            btnQuitarPaquete.TabIndex = 19;
            btnQuitarPaquete.Text = "- Quitar";
            btnQuitarPaquete.UseVisualStyleBackColor = true;
            btnQuitarPaquete.Click += btnQuitarPaquete_Click;
            // 
            // dgvPaquetes
            // 
            dgvPaquetes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPaquetes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaquetes.Location = new Point(11, 153);
            dgvPaquetes.Margin = new Padding(3, 4, 3, 4);
            dgvPaquetes.Name = "dgvPaquetes";
            dgvPaquetes.RowHeadersWidth = 51;
            dgvPaquetes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaquetes.Size = new Size(560, 212);
            dgvPaquetes.TabIndex = 20;
            // 
            // grpLote
            // 
            grpLote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpLote.Controls.Add(dgvLoteEnvios);
            grpLote.Controls.Add(btnQuitarEnvio);
            grpLote.Controls.Add(btnGenerar);
            grpLote.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpLote.Location = new Point(17, 700);
            grpLote.Margin = new Padding(3, 4, 3, 4);
            grpLote.Name = "grpLote";
            grpLote.Padding = new Padding(3, 4, 3, 4);
            grpLote.Size = new Size(1075, 374);
            grpLote.TabIndex = 4;
            grpLote.TabStop = false;
            grpLote.Text = "2. Lote (Envíos listos para confirmar)";
            // 
            // dgvLoteEnvios
            // 
            dgvLoteEnvios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLoteEnvios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoteEnvios.Font = new Font("Segoe UI", 9F);
            dgvLoteEnvios.Location = new Point(11, 26);
            dgvLoteEnvios.Margin = new Padding(3, 4, 3, 4);
            dgvLoteEnvios.Name = "dgvLoteEnvios";
            dgvLoteEnvios.ReadOnly = true;
            dgvLoteEnvios.RowHeadersWidth = 51;
            dgvLoteEnvios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoteEnvios.Size = new Size(911, 337);
            dgvLoteEnvios.TabIndex = 22;
            // 
            // btnQuitarEnvio
            // 
            btnQuitarEnvio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarEnvio.Font = new Font("Segoe UI", 9F);
            btnQuitarEnvio.Location = new Point(934, 26);
            btnQuitarEnvio.Margin = new Padding(3, 4, 3, 4);
            btnQuitarEnvio.Name = "btnQuitarEnvio";
            btnQuitarEnvio.Size = new Size(131, 35);
            btnQuitarEnvio.TabIndex = 23;
            btnQuitarEnvio.Text = "Quitar sel.";
            btnQuitarEnvio.UseVisualStyleBackColor = true;
            btnQuitarEnvio.Click += btnQuitarEnvio_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGenerar.BackColor = Color.FromArgb(167, 3, 85);
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Location = new Point(863, 1084);
            btnGenerar.Margin = new Padding(3, 4, 3, 4);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(229, 45);
            btnGenerar.TabIndex = 24;
            btnGenerar.Text = "Confirmar lote";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(23, 1129);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 18);
            lblStatus.TabIndex = 5;
            // Base layout visible in the WinForms designer. Runtime layout keeps its responsive behavior.
            //
            // Final layout geometry
            //
            panelHeader.Location = new Point(2, 2);
            panelHeader.Size = new Size(1128, 38);
            lblTitulo.Location = new Point(14, 6);

            tlpGlobal.Location = new Point(2, 42);
            tlpGlobal.Margin = new Padding(0);
            tlpGlobal.Size = new Size(1128, 132);
            tlpGlobal.ColumnStyles.Clear();
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            grpOperador.Margin = new Padding(2);
            grpOrigen.Margin = new Padding(2);

            lblRemitente.Visible = false;
            txtRemitente.Visible = false;
            lblOficina.AutoSize = true;
            lblOficina.Location = new Point(8, 47);
            lblOficina.Text = "Oficina:";
            cmbOficina.DropDownStyle = ComboBoxStyle.DropDown;
            cmbOficina.Location = new Point(98, 44);
            cmbOficina.Size = new Size(620, 28);
            lblDireccionOficina.AutoSize = false;
            lblDireccionOficina.Location = new Point(12, 72);
            lblDireccionOficina.Size = new Size(704, 20);
            lblRemitenteApellido.AutoSize = true;
            lblRemitenteApellido.Location = new Point(8, 101);
            lblRemitenteApellido.Text = "Ap. Remitente:";
            txtRemitenteApellido.Location = new Point(98, 98);
            txtRemitenteApellido.Size = new Size(250, 27);
            lblRemitenteNombre.AutoSize = true;
            lblRemitenteNombre.Location = new Point(356, 101);
            lblRemitenteNombre.Text = "Nom. Remitente:";
            txtRemitenteNombre.Location = new Point(465, 98);
            txtRemitenteNombre.Size = new Size(253, 27);
            lblEmpresa.Location = new Point(8, 22);
            cmbEmpresa.Location = new Point(98, 19);
            cmbEmpresa.Size = new Size(620, 28);
            lblDireccionOficina.Location = new Point(12, 72);
            lblDireccionOficina.Size = new Size(704, 20);
            lblDireccionOficina.Text = "Dirección de la oficina seleccionada";

            grpComposicion.Location = new Point(2, 176);
            grpComposicion.Margin = new Padding(2);
            grpComposicion.Size = new Size(1128, 326);
            tlpComposicion.Dock = DockStyle.Fill;
            tlpComposicion.Location = new Point(4, 22);
            tlpComposicion.Margin = new Padding(0);
            tlpComposicion.Size = new Size(1120, 300);
            tlpComposicion.ColumnStyles.Clear();
            tlpComposicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpComposicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grpDestino.Padding = new Padding(6);
            grpPaquete.Padding = new Padding(6);

            lblRemito.Visible = false;
            txtRemito.Visible = false;
            lblTelefono.Visible = false;
            txtTelefono.Visible = false;
            lblDestinatario.Location = new Point(9, 25);
            txtDestinatario.Location = new Point(112, 22);
            txtDestinatario.Size = new Size(422, 27);
            lblCalle.Location = new Point(9, 57);
            txtCalle.Location = new Point(112, 54);
            txtCalle.Size = new Size(422, 27);
            lblNumero.Location = new Point(9, 89);
            txtNumero.Location = new Point(112, 86);
            txtNumero.Size = new Size(194, 27);
            lblPiso.Location = new Point(312, 89);
            txtPiso.Location = new Point(360, 86);
            txtPiso.Size = new Size(174, 27);
            lblLocalidad.Location = new Point(9, 121);
            txtLocalidad.Location = new Point(112, 118);
            txtLocalidad.Size = new Size(422, 27);
            lblProvincia.Location = new Point(9, 153);
            txtProvincia.Location = new Point(112, 150);
            txtProvincia.Size = new Size(194, 27);
            lblCP.Location = new Point(312, 153);
            txtCP.Location = new Point(360, 150);
            txtCP.Size = new Size(174, 27);
            lblEmail.Location = new Point(9, 185);
            txtEmail.Location = new Point(112, 182);
            txtEmail.Size = new Size(422, 27);

            lblTamanoPaquete.Location = new Point(9, 25);
            lblTamanoPaquete.Text = "Tamaño Bulto:";
            lblTamanoPaquete.AutoSize = true;
            cmbTamanoPaquete.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTamanoPaquete.Location = new Point(112, 22);
            cmbTamanoPaquete.Size = new Size(422, 28);
            lblDimensiones.Location = new Point(9, 57);
            lblDimensiones.Text = "Dim. (cm):";
            txtAlto.Location = new Point(112, 54);
            txtAlto.Size = new Size(40, 27);
            lblMultiplicadorDimensiones1.AutoSize = true;
            lblMultiplicadorDimensiones1.Location = new Point(155, 57);
            lblMultiplicadorDimensiones1.Text = "x";
            txtAncho.Location = new Point(170, 54);
            txtAncho.Size = new Size(40, 27);
            lblMultiplicadorDimensiones2.AutoSize = true;
            lblMultiplicadorDimensiones2.Location = new Point(213, 57);
            lblMultiplicadorDimensiones2.Text = "x";
            txtLargo.Location = new Point(228, 54);
            txtLargo.Size = new Size(40, 27);
            lblPeso.Location = new Point(276, 57);
            txtPeso.Location = new Point(330, 54);
            txtPeso.Size = new Size(204, 27);
            lblValor.Location = new Point(9, 89);
            txtValor.Location = new Point(112, 86);
            txtValor.Size = new Size(150, 27);
            lblObservaciones.Location = new Point(276, 89);
            txtObservaciones.Location = new Point(371, 86);
            txtObservaciones.Size = new Size(163, 27);
            chkSeguro.AutoSize = true;
            chkSeguro.Location = new Point(9, 119);
            chkSeguro.Text = "Asegurar Envío";
            btnAgregarPaquete.Location = new Point(209, 115);
            btnAgregarPaquete.Size = new Size(92, 26);
            btnQuitarPaquete.Location = new Point(307, 115);
            btnQuitarPaquete.Size = new Size(86, 26);
            btnAgregarEnvioAlLote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarEnvioAlLote.Location = new Point(397, 115);
            btnAgregarEnvioAlLote.Size = new Size(140, 26);
            btnAgregarEnvioAlLote.Text = "Agregar al lote";
            dgvPaquetes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPaquetes.Location = new Point(9, 149);
            dgvPaquetes.Size = new Size(525, 144);

            grpLote.Location = new Point(2, 504);
            grpLote.Margin = new Padding(2);
            grpLote.Size = new Size(1128, 148);
            dgvLoteEnvios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLoteEnvios.Location = new Point(9, 22);
            dgvLoteEnvios.Size = new Size(970, 114);
            btnQuitarEnvio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarEnvio.Location = new Point(986, 22);
            btnQuitarEnvio.Size = new Size(130, 26);
            btnGenerar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGenerar.Location = new Point(986, 53);
            btnGenerar.Size = new Size(130, 26);
            lblStatus.Location = new Point(7, 657);
            lblStatus.Size = new Size(1120, 30);
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            layoutPrincipal.ColumnCount = 1;
            layoutPrincipal.RowCount = 5;
            layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 132F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            layoutPrincipal.Controls.Add(panelHeader, 0, 0);
            layoutPrincipal.Controls.Add(tlpGlobal, 0, 1);
            layoutPrincipal.Controls.Add(grpComposicion, 0, 2);
            layoutPrincipal.Controls.Add(grpLote, 0, 3);
            panelAcciones.ColumnCount = 1;
            panelAcciones.RowCount = 1;
            panelAcciones.Dock = DockStyle.Fill;
            panelAcciones.Controls.Add(lblStatus, 0, 0);
            layoutPrincipal.Controls.Add(panelAcciones, 0, 4);
            layoutPrincipal.Padding = new Padding(5);
            layoutPrincipal.Margin = new Padding(0);
            layoutPrincipal.Dock = DockStyle.Fill;
            panelHeader.Dock = DockStyle.Fill;
            tlpGlobal.Dock = DockStyle.Fill;
            grpComposicion.Dock = DockStyle.Fill;
            grpLote.Dock = DockStyle.Fill;
            lblStatus.Dock = DockStyle.Fill;

            // 
            // FrmGeneracionEnvio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = false;
            BackColor = Color.White;
            ClientSize = new Size(1132, 697);
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
            ResumeLayout(false);
            PerformLayout();
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

