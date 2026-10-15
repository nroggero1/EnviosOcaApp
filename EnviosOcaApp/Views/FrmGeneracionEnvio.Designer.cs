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
            lblDimensiones = new Label();
            txtAlto = new TextBox();
            txtAncho = new TextBox();
            txtLargo = new TextBox();
            lblPeso = new Label();
            txtPeso = new TextBox();
            lblValor = new Label();
            txtValor = new TextBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            btnAgregarPaquete = new Button();
            btnQuitarPaquete = new Button();
            dgvPaquetes = new DataGridView();
            grpLote = new GroupBox();
            dgvLoteEnvios = new DataGridView();
            btnQuitarEnvio = new Button();
            btnGenerar = new Button();
            lblStatus = new Label();
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
            panelHeader.Size = new Size(1086, 67);
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
            grpOperador.Size = new Size(523, 99);
            grpOperador.TabIndex = 1;
            grpOperador.TabStop = false;
            grpOperador.Text = "Datos Globales: Operador (Auditoría)";
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
            txtUsuario.Size = new Size(386, 27);
            txtUsuario.TabIndex = 0;
            // 
            // tlpGlobal
            // 
            tlpGlobal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpGlobal.ColumnCount = 2;
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpGlobal.Controls.Add(grpOperador, 0, 0);
            tlpGlobal.Controls.Add(grpOrigen, 1, 0);
            tlpGlobal.Location = new Point(14, 75);
            tlpGlobal.Margin = new Padding(3, 4, 3, 4);
            tlpGlobal.Name = "tlpGlobal";
            tlpGlobal.RowCount = 1;
            tlpGlobal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpGlobal.Size = new Size(1058, 107);
            tlpGlobal.TabIndex = 0;
            // 
            // grpOrigen
            // 
            grpOrigen.Controls.Add(lblEmpresa);
            grpOrigen.Controls.Add(cmbEmpresa);
            grpOrigen.Controls.Add(lblRemitente);
            grpOrigen.Controls.Add(txtRemitente);
            grpOrigen.Dock = DockStyle.Fill;
            grpOrigen.Location = new Point(532, 4);
            grpOrigen.Margin = new Padding(3, 4, 3, 4);
            grpOrigen.Name = "grpOrigen";
            grpOrigen.Padding = new Padding(3, 4, 3, 4);
            grpOrigen.Size = new Size(523, 99);
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
            cmbEmpresa.Size = new Size(138, 28);
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
            grpComposicion.Controls.Add(btnAgregarEnvioAlLote);
            grpComposicion.Controls.Add(tlpComposicion);
            grpComposicion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpComposicion.Location = new Point(17, 189);
            grpComposicion.Margin = new Padding(3, 4, 3, 4);
            grpComposicion.Name = "grpComposicion";
            grpComposicion.Padding = new Padding(3, 4, 3, 4);
            grpComposicion.Size = new Size(1055, 430);
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
            btnAgregarEnvioAlLote.Location = new Point(413, 382);
            btnAgregarEnvioAlLote.Margin = new Padding(3, 4, 3, 4);
            btnAgregarEnvioAlLote.Name = "btnAgregarEnvioAlLote";
            btnAgregarEnvioAlLote.Size = new Size(229, 38);
            btnAgregarEnvioAlLote.TabIndex = 21;
            btnAgregarEnvioAlLote.Text = "👇 Añadir Envío al Lote 👇";
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
            tlpComposicion.Size = new Size(1041, 345);
            tlpComposicion.TabIndex = 0;
            // 
            // grpDestino
            // 
            grpDestino.Controls.Add(lblDestinatario);
            grpDestino.Controls.Add(txtDestinatario);
            grpDestino.Controls.Add(lblRemito);
            grpDestino.Controls.Add(txtRemito);
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
            grpDestino.Controls.Add(lblTelefono);
            grpDestino.Controls.Add(txtTelefono);
            grpDestino.Dock = DockStyle.Fill;
            grpDestino.Location = new Point(3, 4);
            grpDestino.Margin = new Padding(3, 4, 3, 4);
            grpDestino.Name = "grpDestino";
            grpDestino.Padding = new Padding(3, 4, 3, 4);
            grpDestino.Size = new Size(462, 265);
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
            grpPaquete.Controls.Add(txtAlto);
            grpPaquete.Controls.Add(txtAncho);
            grpPaquete.Controls.Add(txtLargo);
            grpPaquete.Controls.Add(lblPeso);
            grpPaquete.Controls.Add(txtPeso);
            grpPaquete.Controls.Add(lblValor);
            grpPaquete.Controls.Add(txtValor);
            grpPaquete.Controls.Add(lblObservaciones);
            grpPaquete.Controls.Add(txtObservaciones);
            grpPaquete.Controls.Add(btnAgregarPaquete);
            grpPaquete.Controls.Add(btnQuitarPaquete);
            grpPaquete.Controls.Add(dgvPaquetes);
            grpPaquete.Dock = DockStyle.Fill;
            grpPaquete.Location = new Point(471, 4);
            grpPaquete.Margin = new Padding(3, 4, 3, 4);
            grpPaquete.Name = "grpPaquete";
            grpPaquete.Padding = new Padding(3, 4, 3, 4);
            grpPaquete.Size = new Size(567, 265);
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
            txtValor.Text = "";
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
            btnAgregarPaquete.Location = new Point(229, 113);
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
            btnQuitarPaquete.Location = new Point(354, 113);
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
            dgvPaquetes.ReadOnly = false;
            dgvPaquetes.RowHeadersWidth = 51;
            dgvPaquetes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaquetes.Size = new Size(549, 140);
            dgvPaquetes.TabIndex = 20;
            // 
            // grpLote
            // 
            grpLote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpLote.Controls.Add(dgvLoteEnvios);
            grpLote.Controls.Add(btnQuitarEnvio);
            grpLote.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpLote.Location = new Point(17, 626);
            grpLote.Margin = new Padding(3, 4, 3, 4);
            grpLote.Name = "grpLote";
            grpLote.Padding = new Padding(3, 4, 3, 4);
            grpLote.Size = new Size(1055, 175);
            grpLote.TabIndex = 4;
            grpLote.TabStop = false;
            grpLote.Text = "2. Lote Masivo (Envíos listos para transmitir)";
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
            dgvLoteEnvios.Size = new Size(891, 138);
            dgvLoteEnvios.TabIndex = 22;
            // 
            // btnQuitarEnvio
            // 
            btnQuitarEnvio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarEnvio.Font = new Font("Segoe UI", 9F);
            btnQuitarEnvio.Location = new Point(914, 26);
            btnQuitarEnvio.Margin = new Padding(3, 4, 3, 4);
            btnQuitarEnvio.Name = "btnQuitarEnvio";
            btnQuitarEnvio.Size = new Size(131, 35);
            btnQuitarEnvio.TabIndex = 23;
            btnQuitarEnvio.Text = "Quitar Sel.";
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
            btnGenerar.Location = new Point(843, 808);
            btnGenerar.Margin = new Padding(3, 4, 3, 4);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(229, 45);
            btnGenerar.TabIndex = 24;
            btnGenerar.Text = "Transmitir Lote OCA";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(23, 820);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 18);
            lblStatus.TabIndex = 5;
            // 
            // FrmGeneracionEnvio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1086, 865);
            Controls.Add(lblStatus);
            Controls.Add(btnGenerar);
            Controls.Add(grpLote);
            Controls.Add(grpComposicion);
            Controls.Add(tlpGlobal);
            Controls.Add(panelHeader);
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
        private System.Windows.Forms.Label lblDimensiones;
        private System.Windows.Forms.TextBox txtAlto;
        private System.Windows.Forms.TextBox txtAncho;
        private System.Windows.Forms.TextBox txtLargo;
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
    }
}

