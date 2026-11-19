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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlMenuLateral = new Panel();
            btnGestionOficinas = new Button();
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
            pnlMenuLateral.Controls.Add(btnGestionOficinas);
            pnlMenuLateral.Controls.Add(btnGestionUsuarios);
            pnlMenuLateral.Controls.Add(btnAuditoria);
            pnlMenuLateral.Controls.Add(btnImprimirEtiquetas);
            pnlMenuLateral.Controls.Add(btnGenerarEnvios);
            pnlMenuLateral.Controls.Add(pnlLogo);
            pnlMenuLateral.Dock = DockStyle.Left;
            pnlMenuLateral.Location = new Point(0, 0);
            pnlMenuLateral.Name = "pnlMenuLateral";
            pnlMenuLateral.Size = new Size(236, 577);
            pnlMenuLateral.TabIndex = 0;
            // 
            // btnGestionOficinas
            // 
            btnGestionOficinas.Dock = DockStyle.Top;
            btnGestionOficinas.FlatAppearance.BorderSize = 0;
            btnGestionOficinas.FlatStyle = FlatStyle.Flat;
            btnGestionOficinas.Font = new Font("Microsoft Sans Serif", 6.4F);
            btnGestionOficinas.ForeColor = Color.White;
            btnGestionOficinas.Location = new Point(0, 260);
            btnGestionOficinas.Name = "btnGestionOficinas";
            btnGestionOficinas.Padding = new Padding(10, 0, 0, 0);
            btnGestionOficinas.Size = new Size(236, 40);
            btnGestionOficinas.TabIndex = 5;
            btnGestionOficinas.Text = "Gestión de Oficinas";
            btnGestionOficinas.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionOficinas.UseVisualStyleBackColor = true;
            btnGestionOficinas.Click += btnGestionOficinas_Click;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Dock = DockStyle.Top;
            btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            btnGestionUsuarios.FlatStyle = FlatStyle.Flat;
            btnGestionUsuarios.Font = new Font("Microsoft Sans Serif", 6.4F);
            btnGestionUsuarios.ForeColor = Color.White;
            btnGestionUsuarios.Location = new Point(0, 220);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Padding = new Padding(10, 0, 0, 0);
            btnGestionUsuarios.Size = new Size(236, 40);
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
            btnAuditoria.Font = new Font("Microsoft Sans Serif", 6.4F);
            btnAuditoria.ForeColor = Color.White;
            btnAuditoria.Location = new Point(0, 180);
            btnAuditoria.Name = "btnAuditoria";
            btnAuditoria.Padding = new Padding(10, 0, 0, 0);
            btnAuditoria.Size = new Size(236, 40);
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
            btnImprimirEtiquetas.Font = new Font("Microsoft Sans Serif", 6.4F);
            btnImprimirEtiquetas.ForeColor = Color.White;
            btnImprimirEtiquetas.Location = new Point(0, 140);
            btnImprimirEtiquetas.Name = "btnImprimirEtiquetas";
            btnImprimirEtiquetas.Padding = new Padding(10, 0, 0, 0);
            btnImprimirEtiquetas.Size = new Size(236, 40);
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
            btnGenerarEnvios.Font = new Font("Microsoft Sans Serif", 6.4F);
            btnGenerarEnvios.ForeColor = Color.White;
            btnGenerarEnvios.Location = new Point(0, 100);
            btnGenerarEnvios.Name = "btnGenerarEnvios";
            btnGenerarEnvios.Padding = new Padding(10, 0, 0, 0);
            btnGenerarEnvios.Size = new Size(236, 40);
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
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(236, 100);
            pnlLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(0, 7);
            pictureBoxLogo.Margin = new Padding(3, 2, 3, 2);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(236, 64);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // pnlContenedor
            // 
            pnlContenedor.BackColor = Color.FromArgb(246, 246, 247);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(236, 0);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(652, 577);
            pnlContenedor.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 577);
            Controls.Add(pnlContenedor);
            Controls.Add(pnlMenuLateral);
            MinimumSize = new Size(667, 387);
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
        private Button btnGestionOficinas;
    }
}

