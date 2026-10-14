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
            lblMensaje = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblEmpresa = new Label();
            cmbEmpresa = new ComboBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblMensaje
            // 
            lblMensaje.Location = new Point(0, 0);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(100, 23);
            lblMensaje.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(0, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(0, 0);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 27);
            txtUsername.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(0, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(0, 0);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 27);
            txtNombre.TabIndex = 0;
            // 
            // lblApellido
            // 
            lblApellido.Location = new Point(0, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(100, 23);
            lblApellido.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(0, 0);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 27);
            txtApellido.TabIndex = 0;
            // 
            // lblEmpresa
            // 
            lblEmpresa.Location = new Point(0, 0);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new Size(100, 23);
            lblEmpresa.TabIndex = 0;
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.Location = new Point(0, 0);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new Size(121, 28);
            cmbEmpresa.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(0, 0);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 0;
            // 
            // FrmRegistroInicial
            // 
            ClientSize = new Size(572, 435);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistroInicial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro Inicial - Envíos OCA";
            Load += FrmRegistroInicial_Load;
            ResumeLayout(false);
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
