namespace EnviosOcaApp.Views
{
    partial class FrmGestionUsuarios
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tlpMain = new TableLayoutPanel();
            lblTitulo = new Label();
            dgvUsuarios = new DataGridView();
            grpDatos = new GroupBox();
            tlpDatos = new TableLayoutPanel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblEmpresa = new Label();
            cmbEmpresa = new ComboBox();
            chkAdmin = new CheckBox();
            pnlBotones = new FlowLayoutPanel();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            grpDatos.SuspendLayout();
            tlpDatos.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(lblTitulo, 0, 0);
            tlpMain.Controls.Add(dgvUsuarios, 0, 1);
            tlpMain.Controls.Add(grpDatos, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(12);
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 185F));
            tlpMain.Size = new Size(834, 561);
            tlpMain.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitulo.Location = new Point(15, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(804, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión y Administración de Usuarios";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.Location = new Point(15, 50);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(804, 311);
            dgvUsuarios.TabIndex = 1;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(tlpDatos);
            grpDatos.Dock = DockStyle.Fill;
            grpDatos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDatos.ForeColor = Color.FromArgb(44, 62, 80);
            grpDatos.Location = new Point(15, 367);
            grpDatos.Name = "grpDatos";
            grpDatos.Padding = new Padding(10);
            grpDatos.Size = new Size(804, 179);
            grpDatos.TabIndex = 2;
            grpDatos.TabStop = false;
            grpDatos.Text = "Detalle y Modificación de Usuario";
            // 
            // tlpDatos
            // 
            tlpDatos.ColumnCount = 4;
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDatos.Controls.Add(lblUsername, 0, 0);
            tlpDatos.Controls.Add(txtUsername, 1, 0);
            tlpDatos.Controls.Add(lblNombre, 0, 1);
            tlpDatos.Controls.Add(txtNombre, 1, 1);
            tlpDatos.Controls.Add(lblApellido, 2, 1);
            tlpDatos.Controls.Add(txtApellido, 3, 1);
            tlpDatos.Controls.Add(lblEmpresa, 0, 2);
            tlpDatos.Controls.Add(cmbEmpresa, 1, 2);
            tlpDatos.Controls.Add(chkAdmin, 2, 2);
            tlpDatos.Controls.Add(pnlBotones, 0, 3);
            tlpDatos.Dock = DockStyle.Fill;
            tlpDatos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tlpDatos.Location = new Point(10, 30);
            tlpDatos.Name = "tlpDatos";
            tlpDatos.RowCount = 4;
            tlpDatos.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpDatos.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpDatos.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpDatos.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tlpDatos.Size = new Size(784, 139);
            tlpDatos.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Dock = DockStyle.Fill;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.Black;
            lblUsername.Location = new Point(3, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(134, 32);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username Windows:";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            txtUsername.CharacterCasing = CharacterCasing.Upper;
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(143, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(251, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Dock = DockStyle.Fill;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.Black;
            lblNombre.Location = new Point(3, 32);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(134, 32);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            lblNombre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNombre
            // 
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(143, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(251, 27);
            txtNombre.TabIndex = 3;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Dock = DockStyle.Fill;
            lblApellido.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApellido.ForeColor = Color.Black;
            lblApellido.Location = new Point(400, 32);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(124, 32);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido:";
            lblApellido.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtApellido
            // 
            txtApellido.CharacterCasing = CharacterCasing.Upper;
            txtApellido.Dock = DockStyle.Fill;
            txtApellido.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(530, 35);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(251, 27);
            txtApellido.TabIndex = 5;
            // 
            // lblEmpresa
            // 
            lblEmpresa.AutoSize = true;
            lblEmpresa.Dock = DockStyle.Fill;
            lblEmpresa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmpresa.ForeColor = Color.Black;
            lblEmpresa.Location = new Point(3, 64);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new Size(134, 32);
            lblEmpresa.TabIndex = 6;
            lblEmpresa.Text = "Empresa Defecto:";
            lblEmpresa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.Dock = DockStyle.Fill;
            cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpresa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEmpresa.FormattingEnabled = true;
            cmbEmpresa.Location = new Point(143, 67);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new Size(251, 28);
            cmbEmpresa.TabIndex = 7;
            // 
            // chkAdmin
            // 
            chkAdmin.AutoSize = true;
            tlpDatos.SetColumnSpan(chkAdmin, 2);
            chkAdmin.Dock = DockStyle.Fill;
            chkAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkAdmin.ForeColor = Color.FromArgb(44, 62, 80);
            chkAdmin.Location = new Point(400, 67);
            chkAdmin.Name = "chkAdmin";
            chkAdmin.Size = new Size(381, 26);
            chkAdmin.TabIndex = 8;
            chkAdmin.Text = "Es Administrador del Sistema";
            chkAdmin.UseVisualStyleBackColor = true;
            // 
            // pnlBotones
            // 
            tlpDatos.SetColumnSpan(pnlBotones, 4);
            pnlBotones.Controls.Add(btnNuevo);
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Dock = DockStyle.Fill;
            pnlBotones.Location = new Point(3, 99);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Padding = new Padding(0, 4, 0, 0);
            pnlBotones.Size = new Size(778, 37);
            pnlBotones.TabIndex = 9;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(235, 235, 235);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.Black;
            btnNuevo.Location = new Point(3, 7);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(95, 28);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(167, 3, 85);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(104, 7);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 28);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(192, 57, 43);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(230, 7);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 28);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FrmGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(834, 561);
            Controls.Add(tlpMain);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(700, 480);
            Name = "FrmGestionUsuarios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Usuarios";
            Load += FrmGestionUsuarios_Load;
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            grpDatos.ResumeLayout(false);
            tlpDatos.ResumeLayout(false);
            tlpDatos.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
    }
}
