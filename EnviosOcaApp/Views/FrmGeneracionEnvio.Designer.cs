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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpOperador = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.tlpGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.grpOrigen = new System.Windows.Forms.GroupBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.lblRemitente = new System.Windows.Forms.Label();
            this.txtRemitente = new System.Windows.Forms.TextBox();
            this.grpComposicion = new System.Windows.Forms.GroupBox();
            this.tlpComposicion = new System.Windows.Forms.TableLayoutPanel();
            this.grpDestino = new System.Windows.Forms.GroupBox();
            this.lblDestinatario = new System.Windows.Forms.Label();
            this.txtDestinatario = new System.Windows.Forms.TextBox();
            this.lblRemito = new System.Windows.Forms.Label();
            this.txtRemito = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblPiso = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.grpPaquete = new System.Windows.Forms.GroupBox();
            this.lblDimensiones = new System.Windows.Forms.Label();
            this.txtAlto = new System.Windows.Forms.TextBox();
            this.txtAncho = new System.Windows.Forms.TextBox();
            this.txtLargo = new System.Windows.Forms.TextBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnAgregarPaquete = new System.Windows.Forms.Button();
            this.btnQuitarPaquete = new System.Windows.Forms.Button();
            this.dgvPaquetes = new System.Windows.Forms.DataGridView();
            this.btnAgregarEnvioAlLote = new System.Windows.Forms.Button();
            this.grpLote = new System.Windows.Forms.GroupBox();
            this.dgvLoteEnvios = new System.Windows.Forms.DataGridView();
            this.btnQuitarEnvio = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.grpOperador.SuspendLayout();
            this.tlpGlobal.SuspendLayout();
            this.grpOrigen.SuspendLayout();
            this.grpComposicion.SuspendLayout();
            this.tlpComposicion.SuspendLayout();
            this.grpDestino.SuspendLayout();
            this.grpPaquete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquetes)).BeginInit();
            this.grpLote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoteEnvios)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(950, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(3)))), ((int)(((byte)(85)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(417, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Generación de Envíos OCA (Multidestinatario)";
            // 
            // tlpGlobal
            // 
            this.tlpGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpGlobal.ColumnCount = 2;
            this.tlpGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGlobal.Controls.Add(this.grpOperador, 0, 0);
            this.tlpGlobal.Controls.Add(this.grpOrigen, 1, 0);
            this.tlpGlobal.Location = new System.Drawing.Point(12, 56);
            this.tlpGlobal.Name = "tlpGlobal";
            this.tlpGlobal.RowCount = 1;
            this.tlpGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGlobal.Size = new System.Drawing.Size(926, 80);
            this.tlpGlobal.TabIndex = 0;
            // 
            // grpOperador
            // 
            this.grpOperador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOperador.Controls.Add(this.lblUsuario);
            this.grpOperador.Controls.Add(this.txtUsuario);
            this.grpOperador.Location = new System.Drawing.Point(3, 3);
            this.grpOperador.Name = "grpOperador";
            this.grpOperador.Size = new System.Drawing.Size(457, 74);
            this.grpOperador.TabIndex = 1;
            this.grpOperador.TabStop = false;
            this.grpOperador.Text = "Datos Globales: Operador (Auditoría)";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(20, 30);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 15);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(100, 27);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(337, 23);
            this.txtUsuario.TabIndex = 0;
            // 
            // grpOrigen
            // 
            this.grpOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOrigen.Controls.Add(this.lblEmpresa);
            this.grpOrigen.Controls.Add(this.cmbEmpresa);
            this.grpOrigen.Controls.Add(this.lblRemitente);
            this.grpOrigen.Controls.Add(this.txtRemitente);
            this.grpOrigen.Location = new System.Drawing.Point(466, 3);
            this.grpOrigen.Name = "grpOrigen";
            this.grpOrigen.Size = new System.Drawing.Size(457, 74);
            this.grpOrigen.TabIndex = 2;
            this.grpOrigen.TabStop = false;
            this.grpOrigen.Text = "Datos Globales: Origen del Lote";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(10, 30);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(55, 15);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(80, 27);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(120, 23);
            this.cmbEmpresa.TabIndex = 0;
            // 
            // lblRemitente
            // 
            this.lblRemitente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemitente.AutoSize = true;
            this.lblRemitente.Location = new System.Drawing.Point(210, 30);
            this.lblRemitente.Name = "lblRemitente";
            this.lblRemitente.Size = new System.Drawing.Size(65, 15);
            this.lblRemitente.TabIndex = 2;
            this.lblRemitente.Text = "Remitente:";
            // 
            // txtRemitente
            // 
            this.txtRemitente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemitente.Location = new System.Drawing.Point(280, 27);
            this.txtRemitente.Name = "txtRemitente";
            this.txtRemitente.Size = new System.Drawing.Size(160, 23);
            this.txtRemitente.TabIndex = 1;
            // 
            // grpComposicion
            // 
            this.grpComposicion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpComposicion.Controls.Add(this.btnAgregarEnvioAlLote);
            this.grpComposicion.Controls.Add(this.tlpComposicion);
            this.grpComposicion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpComposicion.Location = new System.Drawing.Point(15, 142);
            this.grpComposicion.Name = "grpComposicion";
            this.grpComposicion.Size = new System.Drawing.Size(923, 270);
            this.grpComposicion.TabIndex = 3;
            this.grpComposicion.TabStop = false;
            this.grpComposicion.Text = "1. Composición de Envío Individual";
            // 
            // tlpComposicion
            // 
            this.tlpComposicion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpComposicion.ColumnCount = 2;
            this.tlpComposicion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpComposicion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpComposicion.Controls.Add(this.grpDestino, 0, 0);
            this.tlpComposicion.Controls.Add(this.grpPaquete, 1, 0);
            this.tlpComposicion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tlpComposicion.Location = new System.Drawing.Point(6, 22);
            this.tlpComposicion.Name = "tlpComposicion";
            this.tlpComposicion.RowCount = 1;
            this.tlpComposicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpComposicion.Size = new System.Drawing.Size(911, 205);
            this.tlpComposicion.TabIndex = 0;
            // 
            // grpDestino
            // 
            this.grpDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDestino.Controls.Add(this.lblDestinatario);
            this.grpDestino.Controls.Add(this.txtDestinatario);
            this.grpDestino.Controls.Add(this.lblRemito);
            this.grpDestino.Controls.Add(this.txtRemito);
            this.grpDestino.Controls.Add(this.lblCalle);
            this.grpDestino.Controls.Add(this.txtCalle);
            this.grpDestino.Controls.Add(this.lblNumero);
            this.grpDestino.Controls.Add(this.txtNumero);
            this.grpDestino.Controls.Add(this.lblPiso);
            this.grpDestino.Controls.Add(this.txtPiso);
            this.grpDestino.Controls.Add(this.lblLocalidad);
            this.grpDestino.Controls.Add(this.txtLocalidad);
            this.grpDestino.Controls.Add(this.lblProvincia);
            this.grpDestino.Controls.Add(this.txtProvincia);
            this.grpDestino.Controls.Add(this.lblCP);
            this.grpDestino.Controls.Add(this.txtCP);
            this.grpDestino.Controls.Add(this.lblEmail);
            this.grpDestino.Controls.Add(this.txtEmail);
            this.grpDestino.Controls.Add(this.lblTelefono);
            this.grpDestino.Controls.Add(this.txtTelefono);
            this.grpDestino.Location = new System.Drawing.Point(3, 3);
            this.grpDestino.Name = "grpDestino";
            this.grpDestino.Size = new System.Drawing.Size(403, 199);
            this.grpDestino.TabIndex = 0;
            this.grpDestino.TabStop = false;
            this.grpDestino.Text = "Datos del Destinatario y Referencia";
            // 
            // lblRemito
            // 
            this.lblRemito.AutoSize = true;
            this.lblRemito.Location = new System.Drawing.Point(10, 25);
            this.lblRemito.Name = "lblRemito";
            this.lblRemito.Size = new System.Drawing.Size(71, 15);
            this.lblRemito.TabIndex = 4;
            this.lblRemito.Text = "Ref/Remito:";
            // 
            // txtRemito
            // 
            this.txtRemito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemito.Location = new System.Drawing.Point(90, 22);
            this.txtRemito.Name = "txtRemito";
            this.txtRemito.Size = new System.Drawing.Size(300, 23);
            this.txtRemito.TabIndex = 2;
            // 
            // lblDestinatario
            // 
            this.lblDestinatario.AutoSize = true;
            this.lblDestinatario.Location = new System.Drawing.Point(10, 55);
            this.lblDestinatario.Name = "lblDestinatario";
            this.lblDestinatario.Size = new System.Drawing.Size(73, 15);
            this.lblDestinatario.TabIndex = 0;
            this.lblDestinatario.Text = "Nombre/Rz:";
            // 
            // txtDestinatario
            // 
            this.txtDestinatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinatario.Location = new System.Drawing.Point(90, 52);
            this.txtDestinatario.Name = "txtDestinatario";
            this.txtDestinatario.Size = new System.Drawing.Size(300, 23);
            this.txtDestinatario.TabIndex = 3;
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(10, 85);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(36, 15);
            this.lblCalle.TabIndex = 2;
            this.lblCalle.Text = "Calle:";
            // 
            // txtCalle
            // 
            this.txtCalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCalle.Location = new System.Drawing.Point(90, 82);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(120, 23);
            this.txtCalle.TabIndex = 4;
            // 
            // lblNumero
            // 
            this.lblNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(215, 85);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(36, 15);
            this.lblNumero.TabIndex = 4;
            this.lblNumero.Text = "Nro:";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.Location = new System.Drawing.Point(250, 82);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(50, 23);
            this.txtNumero.TabIndex = 5;
            // 
            // lblPiso
            // 
            this.lblPiso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(305, 85);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(32, 15);
            this.lblPiso.TabIndex = 6;
            this.lblPiso.Text = "Piso:";
            // 
            // txtPiso
            // 
            this.txtPiso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPiso.Location = new System.Drawing.Point(340, 82);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(50, 23);
            this.txtPiso.TabIndex = 6;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(10, 115);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(61, 15);
            this.lblLocalidad.TabIndex = 8;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalidad.Location = new System.Drawing.Point(90, 112);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 23);
            this.txtLocalidad.TabIndex = 7;
            // 
            // lblProvincia
            // 
            this.lblProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(195, 115);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(36, 15);
            this.lblProvincia.TabIndex = 10;
            this.lblProvincia.Text = "Prov:";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvincia.Location = new System.Drawing.Point(235, 112);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(80, 23);
            this.txtProvincia.TabIndex = 8;
            // 
            // lblCP
            // 
            this.lblCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCP.AutoSize = true;
            this.lblCP.Location = new System.Drawing.Point(320, 115);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(25, 15);
            this.lblCP.TabIndex = 12;
            this.lblCP.Text = "CP:";
            // 
            // txtCP
            // 
            this.txtCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCP.Location = new System.Drawing.Point(350, 112);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(40, 23);
            this.txtCP.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(10, 145);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 15);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(90, 142);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(140, 23);
            this.txtEmail.TabIndex = 10;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(235, 145);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(28, 15);
            this.lblTelefono.TabIndex = 16;
            this.lblTelefono.Text = "Tel:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.Location = new System.Drawing.Point(270, 142);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(120, 23);
            this.txtTelefono.TabIndex = 11;
            // 
            // grpPaquete
            // 
            this.grpPaquete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPaquete.Controls.Add(this.lblDimensiones);
            this.grpPaquete.Controls.Add(this.txtAlto);
            this.grpPaquete.Controls.Add(this.txtAncho);
            this.grpPaquete.Controls.Add(this.txtLargo);
            this.grpPaquete.Controls.Add(this.lblPeso);
            this.grpPaquete.Controls.Add(this.txtPeso);
            this.grpPaquete.Controls.Add(this.lblValor);
            this.grpPaquete.Controls.Add(this.txtValor);
            this.grpPaquete.Controls.Add(this.lblObservaciones);
            this.grpPaquete.Controls.Add(this.txtObservaciones);
            this.grpPaquete.Controls.Add(this.btnAgregarPaquete);
            this.grpPaquete.Controls.Add(this.btnQuitarPaquete);
            this.grpPaquete.Controls.Add(this.dgvPaquetes);
            this.grpPaquete.Location = new System.Drawing.Point(412, 3);
            this.grpPaquete.Name = "grpPaquete";
            this.grpPaquete.Size = new System.Drawing.Size(496, 199);
            this.grpPaquete.TabIndex = 1;
            this.grpPaquete.TabStop = false;
            this.grpPaquete.Text = "Bultos del Envío (Paquetes)";
            // 
            // lblDimensiones
            // 
            this.lblDimensiones.AutoSize = true;
            this.lblDimensiones.Location = new System.Drawing.Point(10, 25);
            this.lblDimensiones.Name = "lblDimensiones";
            this.lblDimensiones.Size = new System.Drawing.Size(155, 15);
            this.lblDimensiones.TabIndex = 0;
            this.lblDimensiones.Text = "Alto x Ancho x Largo (cm):";
            // 
            // txtAlto
            // 
            this.txtAlto.Location = new System.Drawing.Point(170, 22);
            this.txtAlto.Name = "txtAlto";
            this.txtAlto.Size = new System.Drawing.Size(35, 23);
            this.txtAlto.TabIndex = 12;
            this.txtAlto.Text = "10";
            // 
            // txtAncho
            // 
            this.txtAncho.Location = new System.Drawing.Point(210, 22);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(35, 23);
            this.txtAncho.TabIndex = 13;
            this.txtAncho.Text = "10";
            // 
            // txtLargo
            // 
            this.txtLargo.Location = new System.Drawing.Point(250, 22);
            this.txtLargo.Name = "txtLargo";
            this.txtLargo.Size = new System.Drawing.Size(35, 23);
            this.txtLargo.TabIndex = 14;
            this.txtLargo.Text = "10";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(295, 25);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(59, 15);
            this.lblPeso.TabIndex = 4;
            this.lblPeso.Text = "Peso (kg):";
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(355, 22);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(40, 23);
            this.txtPeso.TabIndex = 15;
            this.txtPeso.Text = "1";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(400, 25);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(52, 15);
            this.lblValor.TabIndex = 6;
            this.lblValor.Text = "Valor $:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(450, 22);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(40, 23);
            this.txtValor.TabIndex = 16;
            this.txtValor.Text = "0";
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(10, 55);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(88, 15);
            this.lblObservaciones.TabIndex = 8;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(100, 52);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(185, 23);
            this.txtObservaciones.TabIndex = 17;
            // 
            // btnAgregarPaquete
            // 
            this.btnAgregarPaquete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarPaquete.Location = new System.Drawing.Point(295, 51);
            this.btnAgregarPaquete.Name = "btnAgregarPaquete";
            this.btnAgregarPaquete.Size = new System.Drawing.Size(100, 25);
            this.btnAgregarPaquete.TabIndex = 18;
            this.btnAgregarPaquete.Text = "+ Bulto";
            this.btnAgregarPaquete.UseVisualStyleBackColor = true;
            this.btnAgregarPaquete.Click += new System.EventHandler(this.btnAgregarPaquete_Click);
            // 
            // btnQuitarPaquete
            // 
            this.btnQuitarPaquete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarPaquete.Location = new System.Drawing.Point(400, 51);
            this.btnQuitarPaquete.Name = "btnQuitarPaquete";
            this.btnQuitarPaquete.Size = new System.Drawing.Size(90, 25);
            this.btnQuitarPaquete.TabIndex = 19;
            this.btnQuitarPaquete.Text = "- Quitar";
            this.btnQuitarPaquete.UseVisualStyleBackColor = true;
            this.btnQuitarPaquete.Click += new System.EventHandler(this.btnQuitarPaquete_Click);
            // 
            // dgvPaquetes
            // 
            this.dgvPaquetes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaquetes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaquetes.Location = new System.Drawing.Point(10, 85);
            this.dgvPaquetes.Name = "dgvPaquetes";
            this.dgvPaquetes.ReadOnly = true;
            this.dgvPaquetes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaquetes.Size = new System.Drawing.Size(480, 105);
            this.dgvPaquetes.TabIndex = 20;
            // 
            // btnAgregarEnvioAlLote
            // 
            this.btnAgregarEnvioAlLote.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregarEnvioAlLote.BackColor = System.Drawing.Color.LightBlue;
            this.btnAgregarEnvioAlLote.FlatAppearance.BorderSize = 1;
            this.btnAgregarEnvioAlLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEnvioAlLote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarEnvioAlLote.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarEnvioAlLote.Location = new System.Drawing.Point(361, 230);
            this.btnAgregarEnvioAlLote.Name = "btnAgregarEnvioAlLote";
            this.btnAgregarEnvioAlLote.Size = new System.Drawing.Size(200, 30);
            this.btnAgregarEnvioAlLote.TabIndex = 21;
            this.btnAgregarEnvioAlLote.Text = "👇 Añadir Envío al Lote 👇";
            this.btnAgregarEnvioAlLote.UseVisualStyleBackColor = false;
            this.btnAgregarEnvioAlLote.Click += new System.EventHandler(this.btnAgregarEnvioAlLote_Click);
            // 
            // grpLote
            // 
            this.grpLote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLote.Controls.Add(this.dgvLoteEnvios);
            this.grpLote.Controls.Add(this.btnQuitarEnvio);
            this.grpLote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpLote.Location = new System.Drawing.Point(15, 420);
            this.grpLote.Name = "grpLote";
            this.grpLote.Size = new System.Drawing.Size(923, 200);
            this.grpLote.TabIndex = 4;
            this.grpLote.TabStop = false;
            this.grpLote.Text = "2. Lote Masivo (Envíos listos para transmitir)";
            // 
            // dgvLoteEnvios
            // 
            this.dgvLoteEnvios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoteEnvios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoteEnvios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvLoteEnvios.Location = new System.Drawing.Point(10, 22);
            this.dgvLoteEnvios.Name = "dgvLoteEnvios";
            this.dgvLoteEnvios.ReadOnly = true;
            this.dgvLoteEnvios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoteEnvios.Size = new System.Drawing.Size(780, 168);
            this.dgvLoteEnvios.TabIndex = 22;
            // 
            // btnQuitarEnvio
            // 
            this.btnQuitarEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarEnvio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnQuitarEnvio.Location = new System.Drawing.Point(800, 22);
            this.btnQuitarEnvio.Name = "btnQuitarEnvio";
            this.btnQuitarEnvio.Size = new System.Drawing.Size(115, 30);
            this.btnQuitarEnvio.TabIndex = 23;
            this.btnQuitarEnvio.Text = "Quitar Sel.";
            this.btnQuitarEnvio.UseVisualStyleBackColor = true;
            this.btnQuitarEnvio.Click += new System.EventHandler(this.btnQuitarEnvio_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(3)))), ((int)(((byte)(85)))));
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(738, 630);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(200, 40);
            this.btnGenerar.TabIndex = 24;
            this.btnGenerar.Text = "Transmitir Lote OCA";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(20, 640);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 5;
            // 
            // FrmGeneracionEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 690);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.grpLote);
            this.Controls.Add(this.grpComposicion);
            this.Controls.Add(this.tlpGlobal);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGeneracionEnvio";
            this.Text = "Generación de Envíos";
            this.Load += new System.EventHandler(this.FrmGeneracionEnvio_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.grpOperador.ResumeLayout(false);
            this.grpOperador.PerformLayout();
            this.tlpGlobal.ResumeLayout(false);
            this.grpOrigen.ResumeLayout(false);
            this.grpOrigen.PerformLayout();
            this.grpComposicion.ResumeLayout(false);
            this.tlpComposicion.ResumeLayout(false);
            this.grpDestino.ResumeLayout(false);
            this.grpDestino.PerformLayout();
            this.grpPaquete.ResumeLayout(false);
            this.grpPaquete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquetes)).EndInit();
            this.grpLote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoteEnvios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
