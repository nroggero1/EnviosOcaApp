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
            this.pnlMenuLateral = new System.Windows.Forms.Panel();
            this.btnAuditoria = new System.Windows.Forms.Button();
            this.btnImprimirEtiquetas = new System.Windows.Forms.Button();
            this.btnGenerarEnvios = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlMenuLateral.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenuLateral
            // 
            this.pnlMenuLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(3)))), ((int)(((byte)(85)))));
            this.pnlMenuLateral.Controls.Add(this.btnAuditoria);
            this.pnlMenuLateral.Controls.Add(this.btnImprimirEtiquetas);
            this.pnlMenuLateral.Controls.Add(this.btnGenerarEnvios);
            this.pnlMenuLateral.Controls.Add(this.pnlLogo);
            this.pnlMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuLateral.Name = "pnlMenuLateral";
            this.pnlMenuLateral.Size = new System.Drawing.Size(200, 561);
            this.pnlMenuLateral.TabIndex = 0;
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAuditoria.FlatAppearance.BorderSize = 0;
            this.btnAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAuditoria.ForeColor = System.Drawing.Color.White;
            this.btnAuditoria.Location = new System.Drawing.Point(0, 180);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAuditoria.Size = new System.Drawing.Size(200, 40);
            this.btnAuditoria.TabIndex = 3;
            this.btnAuditoria.Text = "Historial y Seguimiento";
            this.btnAuditoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditoria.UseVisualStyleBackColor = true;
            this.btnAuditoria.Click += new System.EventHandler(this.btnAuditoria_Click);
            // 
            // btnImprimirEtiquetas
            // 
            this.btnImprimirEtiquetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImprimirEtiquetas.FlatAppearance.BorderSize = 0;
            this.btnImprimirEtiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirEtiquetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImprimirEtiquetas.ForeColor = System.Drawing.Color.White;
            this.btnImprimirEtiquetas.Location = new System.Drawing.Point(0, 140);
            this.btnImprimirEtiquetas.Name = "btnImprimirEtiquetas";
            this.btnImprimirEtiquetas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnImprimirEtiquetas.Size = new System.Drawing.Size(200, 40);
            this.btnImprimirEtiquetas.TabIndex = 2;
            this.btnImprimirEtiquetas.Text = "Impresión de Etiquetas";
            this.btnImprimirEtiquetas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirEtiquetas.UseVisualStyleBackColor = true;
            this.btnImprimirEtiquetas.Click += new System.EventHandler(this.btnImprimirEtiquetas_Click);
            // 
            // btnGenerarEnvios
            // 
            this.btnGenerarEnvios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenerarEnvios.FlatAppearance.BorderSize = 0;
            this.btnGenerarEnvios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarEnvios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGenerarEnvios.ForeColor = System.Drawing.Color.White;
            this.btnGenerarEnvios.Location = new System.Drawing.Point(0, 100);
            this.btnGenerarEnvios.Name = "btnGenerarEnvios";
            this.btnGenerarEnvios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGenerarEnvios.Size = new System.Drawing.Size(200, 40);
            this.btnGenerarEnvios.TabIndex = 1;
            this.btnGenerarEnvios.Text = "Generación de Envío";
            this.btnGenerarEnvios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarEnvios.UseVisualStyleBackColor = true;
            this.btnGenerarEnvios.Click += new System.EventHandler(this.btnGenerarEnvios_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.pictureBoxLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(200, 100);
            this.pnlLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(10, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(180, 60);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(200, 0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(684, 561);
            this.pnlContenedor.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenuLateral);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Text = "Menú Principal - Envios OCA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMenuLateral.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMenuLateral;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button btnGenerarEnvios;
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.Button btnImprimirEtiquetas;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}
