namespace EnviosOcaApp.Views
{
    partial class FrmRegistroInicial
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
            lblMensaje = new System.Windows.Forms.Label();
            lblUsername = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            lblNombre = new System.Windows.Forms.Label();
            txtNombre = new System.Windows.Forms.TextBox();
            lblApellido = new System.Windows.Forms.Label();
            txtApellido = new System.Windows.Forms.TextBox();
            lblEmpresa = new System.Windows.Forms.Label();
            cmbEmpresa = new System.Windows.Forms.ComboBox();
            btnGuardar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = false;
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(167, 3, 85);
            lblMensaje.Location = new System.Drawing.Point(30, 20);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(460, 45);
            lblMensaje.TabIndex = 0;
            lblMensaje.Text = "¡Bienvenido! Es tu primer ingreso al sistema.\r\nPor favor completá tus datos de usuario:";
            // 
            // lblUsername
            // 
            lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblUsername.Location = new System.Drawing.Point(30, 78);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(130, 25);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Usuario Windows:";
            lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = System.Drawing.SystemColors.Control;
            txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtUsername.Location = new System.Drawing.Point(165, 78);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new System.Drawing.Size(325, 27);
            txtUsername.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblNombre.Location = new System.Drawing.Point(30, 118);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(130, 25);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNombre
            // 
            txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtNombre.Location = new System.Drawing.Point(165, 118);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(325, 27);
            txtNombre.TabIndex = 4;
            // 
            // lblApellido
            // 
            lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblApellido.Location = new System.Drawing.Point(30, 158);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new System.Drawing.Size(130, 25);
            lblApellido.TabIndex = 5;
            lblApellido.Text = "Apellido:";
            lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtApellido
            // 
            txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtApellido.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtApellido.Location = new System.Drawing.Point(165, 158);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new System.Drawing.Size(325, 27);
            txtApellido.TabIndex = 6;
            // 
            // lblEmpresa
            // 
            lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblEmpresa.Location = new System.Drawing.Point(30, 198);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new System.Drawing.Size(130, 25);
            lblEmpresa.TabIndex = 7;
            lblEmpresa.Text = "Empresa Defecto:";
            lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbEmpresa.FormattingEnabled = true;
            cmbEmpresa.Location = new System.Drawing.Point(165, 198);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new System.Drawing.Size(325, 28);
            cmbEmpresa.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(167, 3, 85);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(340, 248);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(150, 38);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Comenzar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmRegistroInicial
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(520, 310);
            Controls.Add(lblMensaje);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblEmpresa);
            Controls.Add(cmbEmpresa);
            Controls.Add(btnGuardar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistroInicial";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Registro Inicial de Usuario - Envíos OCA";
            Load += FrmRegistroInicial_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Button btnGuardar;
    }
}
