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
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblMensaje = new System.Windows.Forms.Label();
            lblContador = new System.Windows.Forms.Label();
            btnContinuar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(480, 45);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(15, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(182, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "⚠️ Sesión Inactiva";
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblMensaje.Location = new System.Drawing.Point(20, 60);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(440, 45);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "No se ha registrado actividad en la aplicación durante 30 minutos.\r\nPor seguridad, la aplicación se cerrará en:";
            // 
            // lblContador
            // 
            lblContador.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblContador.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            lblContador.Location = new System.Drawing.Point(20, 110);
            lblContador.Name = "lblContador";
            lblContador.Size = new System.Drawing.Size(440, 30);
            lblContador.TabIndex = 2;
            lblContador.Text = "20 segundos";
            lblContador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnContinuar.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnContinuar.FlatAppearance.BorderSize = 0;
            btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnContinuar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnContinuar.ForeColor = System.Drawing.Color.White;
            btnContinuar.Location = new System.Drawing.Point(145, 155);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new System.Drawing.Size(180, 35);
            btnContinuar.TabIndex = 3;
            btnContinuar.Text = "Continuar Trabajando";
            btnContinuar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnCerrar.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            btnCerrar.Location = new System.Drawing.Point(335, 155);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(125, 35);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar Ahora";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // FrmAvisoInactividad
            // 
            AcceptButton = btnContinuar;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(480, 205);
            ControlBox = false;
            Controls.Add(btnCerrar);
            Controls.Add(btnContinuar);
            Controls.Add(lblContador);
            Controls.Add(lblMensaje);
            Controls.Add(pnlHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAvisoInactividad";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
