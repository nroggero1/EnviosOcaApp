using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnviosOcaApp
{
    partial class Form1
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
            pnlMenuLateral = new Panel();
            btnGestionUsuarios = new Button();
            btnAuditoria = new Button();
            btnImprimirEtiquetas = new Button();
            btnGenerarEnvios = new Button();
            pnlLogo = new Panel();
            pictureBoxLogo = new PictureBox();
            pnlContenedor = new Panel();
            pnlMenuLateral.SuspendLayout();
            pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlMenuLateral
            // 
            pnlMenuLateral.BackColor = Color.FromArgb(167, 3, 85);
            pnlMenuLateral.Controls.Add(btnGestionUsuarios);
            pnlMenuLateral.Controls.Add(btnAuditoria);
            pnlMenuLateral.Controls.Add(btnImprimirEtiquetas);
            pnlMenuLateral.Controls.Add(btnGenerarEnvios);
            pnlMenuLateral.Controls.Add(pnlLogo);
            pnlMenuLateral.Dock = DockStyle.Left;
            pnlMenuLateral.Location = new Point(0, 0);
            pnlMenuLateral.Margin = new Padding(3, 4, 3, 4);
            pnlMenuLateral.Name = "pnlMenuLateral";
            pnlMenuLateral.Size = new Size(229, 748);
            pnlMenuLateral.TabIndex = 0;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Dock = DockStyle.Top;
            btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            btnGestionUsuarios.FlatStyle = FlatStyle.Flat;
            btnGestionUsuarios.Font = new Font("Microsoft Sans Serif", 10F);
            btnGestionUsuarios.ForeColor = Color.White;
            btnGestionUsuarios.Location = new Point(0, 292);
            btnGestionUsuarios.Margin = new Padding(3, 4, 3, 4);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Padding = new Padding(11, 0, 0, 0);
            btnGestionUsuarios.Size = new Size(229, 53);
            btnGestionUsuarios.TabIndex = 4;
            btnGestionUsuarios.Text = "Gestión de Usuarios";
            btnGestionUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionUsuarios.UseVisualStyleBackColor = true;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnAuditoria
            // 
            btnAuditoria.Dock = DockStyle.Top;
            btnAuditoria.FlatAppearance.BorderSize = 0;
            btnAuditoria.FlatStyle = FlatStyle.Flat;
            btnAuditoria.Font = new Font("Microsoft Sans Serif", 10F);
            btnAuditoria.ForeColor = Color.White;
            btnAuditoria.Location = new Point(0, 239);
            btnAuditoria.Margin = new Padding(3, 4, 3, 4);
            btnAuditoria.Name = "btnAuditoria";
            btnAuditoria.Padding = new Padding(11, 0, 0, 0);
            btnAuditoria.Size = new Size(229, 53);
            btnAuditoria.TabIndex = 3;
            btnAuditoria.Text = "Historial y Seguimiento";
            btnAuditoria.TextAlign = ContentAlignment.MiddleLeft;
            btnAuditoria.UseVisualStyleBackColor = true;
            btnAuditoria.Click += btnAuditoria_Click;
            // 
            // btnImprimirEtiquetas
            // 
            btnImprimirEtiquetas.Dock = DockStyle.Top;
            btnImprimirEtiquetas.FlatAppearance.BorderSize = 0;
            btnImprimirEtiquetas.FlatStyle = FlatStyle.Flat;
            btnImprimirEtiquetas.Font = new Font("Microsoft Sans Serif", 10F);
            btnImprimirEtiquetas.ForeColor = Color.White;
            btnImprimirEtiquetas.Location = new Point(0, 186);
            btnImprimirEtiquetas.Margin = new Padding(3, 4, 3, 4);
            btnImprimirEtiquetas.Name = "btnImprimirEtiquetas";
            btnImprimirEtiquetas.Padding = new Padding(11, 0, 0, 0);
            btnImprimirEtiquetas.Size = new Size(229, 53);
            btnImprimirEtiquetas.TabIndex = 2;
            btnImprimirEtiquetas.Text = "Impresión de Etiquetas";
            btnImprimirEtiquetas.TextAlign = ContentAlignment.MiddleLeft;
            btnImprimirEtiquetas.UseVisualStyleBackColor = true;
            btnImprimirEtiquetas.Click += btnImprimirEtiquetas_Click;
            // 
            // btnGenerarEnvios
            // 
            btnGenerarEnvios.Dock = DockStyle.Top;
            btnGenerarEnvios.FlatAppearance.BorderSize = 0;
            btnGenerarEnvios.FlatStyle = FlatStyle.Flat;
            btnGenerarEnvios.Font = new Font("Microsoft Sans Serif", 10F);
            btnGenerarEnvios.ForeColor = Color.White;
            btnGenerarEnvios.Location = new Point(0, 133);
            btnGenerarEnvios.Margin = new Padding(3, 4, 3, 4);
            btnGenerarEnvios.Name = "btnGenerarEnvios";
            btnGenerarEnvios.Padding = new Padding(11, 0, 0, 0);
            btnGenerarEnvios.Size = new Size(229, 53);
            btnGenerarEnvios.TabIndex = 1;
            btnGenerarEnvios.Text = "Generación de Envío";
            btnGenerarEnvios.TextAlign = ContentAlignment.MiddleLeft;
            btnGenerarEnvios.UseVisualStyleBackColor = true;
            btnGenerarEnvios.Click += btnGenerarEnvios_Click;
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(pictureBoxLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Margin = new Padding(3, 4, 3, 4);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(229, 133);
            pnlLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(0, 13);
            pictureBoxLogo.Margin = new Padding(3, 4, 3, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(229, 98);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // pnlContenedor
            // 
            pnlContenedor.BackColor = Color.FromArgb(246, 246, 247);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(229, 0);
            pnlContenedor.Margin = new Padding(3, 4, 3, 4);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(781, 748);
            pnlContenedor.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 748);
            Controls.Add(pnlContenedor);
            Controls.Add(pnlMenuLateral);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 651);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal - Envios OCA";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            pnlMenuLateral.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMenuLateral;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button btnGenerarEnvios;
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.Button btnImprimirEtiquetas;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}


