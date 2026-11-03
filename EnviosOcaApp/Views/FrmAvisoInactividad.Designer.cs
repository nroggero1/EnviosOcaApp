namespace EnviosOcaApp.Views
{
    partial class FrmAvisoInactividad
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
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblMensaje = new Label();
            lblContador = new Label();
            btnContinuar = new Button();
            btnCerrar = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(243, 156, 18);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(480, 45);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(188, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "⚠️ Sesión Inactiva";
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 10F);
            lblMensaje.ForeColor = Color.FromArgb(50, 50, 50);
            lblMensaje.Location = new Point(20, 60);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(440, 45);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "No se ha registrado actividad en la aplicación durante 30 minutos.\r\nPor seguridad, la aplicación se cerrará en:";
            // 
            // lblContador
            // 
            lblContador.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblContador.ForeColor = Color.FromArgb(192, 57, 43);
            lblContador.Location = new Point(20, 110);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(440, 30);
            lblContador.TabIndex = 2;
            lblContador.Text = "30 minutos";
            lblContador.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.FromArgb(41, 128, 185);
            btnContinuar.Cursor = Cursors.Hand;
            btnContinuar.DialogResult = DialogResult.OK;
            btnContinuar.FlatAppearance.BorderSize = 0;
            btnContinuar.FlatStyle = FlatStyle.Flat;
            btnContinuar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnContinuar.ForeColor = Color.White;
            btnContinuar.Location = new Point(145, 155);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(180, 35);
            btnContinuar.TabIndex = 3;
            btnContinuar.Text = "Continuar Trabajando";
            btnContinuar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(236, 240, 241);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.DialogResult = DialogResult.Abort;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 9F);
            btnCerrar.ForeColor = Color.FromArgb(44, 62, 80);
            btnCerrar.Location = new Point(335, 155);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(125, 35);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar Ahora";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // FrmAvisoInactividad
            // 
            AcceptButton = btnContinuar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(480, 205);
            ControlBox = false;
            Controls.Add(btnCerrar);
            Controls.Add(btnContinuar);
            Controls.Add(lblContador);
            Controls.Add(lblMensaje);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAvisoInactividad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alerta de Inactividad - Desconexión Automática";
            TopMost = true;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
