using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnviosOcaApp.Views
{
    partial class FrmImpresionEtiquetas
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
            this.grpBusqueda = new System.Windows.Forms.GroupBox();
            this.lblTracking = new System.Windows.Forms.Label();
            this.txtTracking = new System.Windows.Forms.TextBox();
            this.btnImprimirDirecto = new System.Windows.Forms.Button();
            this.grpRecientes = new System.Windows.Forms.GroupBox();
            this.dgvRecientes = new System.Windows.Forms.DataGridView();
            this.btnImprimirSeleccionado = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();

            this.panelHeader.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            this.grpRecientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecientes)).BeginInit();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 50);
            this.panelHeader.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(3)))), ((int)(((byte)(85)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(260, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Impresión de Etiquetas OCA";

            // grpBusqueda
            this.grpBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBusqueda.Controls.Add(this.lblTracking);
            this.grpBusqueda.Controls.Add(this.txtTracking);
            this.grpBusqueda.Controls.Add(this.btnImprimirDirecto);
            this.grpBusqueda.Location = new System.Drawing.Point(20, 70);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(760, 70);
            this.grpBusqueda.TabIndex = 1;
            this.grpBusqueda.TabStop = false;
            this.grpBusqueda.Text = "Búsqueda Manual";

            // lblTracking
            this.lblTracking.AutoSize = true;
            this.lblTracking.Location = new System.Drawing.Point(20, 30);
            this.lblTracking.Name = "lblTracking";
            this.lblTracking.Size = new System.Drawing.Size(145, 15);
            this.lblTracking.TabIndex = 0;
            this.lblTracking.Text = "Nro Orden/Tracking OCA:";

            // txtTracking
            this.txtTracking.Location = new System.Drawing.Point(170, 27);
            this.txtTracking.Name = "txtTracking";
            this.txtTracking.Size = new System.Drawing.Size(300, 23);
            this.txtTracking.TabIndex = 1;

            // btnImprimirDirecto
            this.btnImprimirDirecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(3)))), ((int)(((byte)(85)))));
            this.btnImprimirDirecto.FlatAppearance.BorderSize = 0;
            this.btnImprimirDirecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirDirecto.ForeColor = System.Drawing.Color.White;
            this.btnImprimirDirecto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImprimirDirecto.Location = new System.Drawing.Point(490, 25);
            this.btnImprimirDirecto.Name = "btnImprimirDirecto";
            this.btnImprimirDirecto.Size = new System.Drawing.Size(130, 27);
            this.btnImprimirDirecto.TabIndex = 2;
            this.btnImprimirDirecto.Text = "Descargar Etiqueta";
            this.btnImprimirDirecto.UseVisualStyleBackColor = false;
            this.btnImprimirDirecto.Click += new System.EventHandler(this.btnImprimirDirecto_Click);

            // grpRecientes
            this.grpRecientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRecientes.Controls.Add(this.btnRefrescar);
            this.grpRecientes.Controls.Add(this.dgvRecientes);
            this.grpRecientes.Controls.Add(this.btnImprimirSeleccionado);
            this.grpRecientes.Location = new System.Drawing.Point(20, 160);
            this.grpRecientes.Name = "grpRecientes";
            this.grpRecientes.Size = new System.Drawing.Size(760, 320);
            this.grpRecientes.TabIndex = 2;
            this.grpRecientes.TabStop = false;
            this.grpRecientes.Text = "Últimos Envíos Generados (Mes Actual)";

            // btnRefrescar
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.Location = new System.Drawing.Point(660, 20);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(85, 25);
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // dgvRecientes
            this.dgvRecientes.AllowUserToAddRows = false;
            this.dgvRecientes.AllowUserToDeleteRows = false;
            this.dgvRecientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecientes.Location = new System.Drawing.Point(15, 55);
            this.dgvRecientes.MultiSelect = false;
            this.dgvRecientes.Name = "dgvRecientes";
            this.dgvRecientes.ReadOnly = true;
            this.dgvRecientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecientes.Size = new System.Drawing.Size(730, 205);
            this.dgvRecientes.TabIndex = 0;

            // btnImprimirSeleccionado
            this.btnImprimirSeleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirSeleccionado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(3)))), ((int)(((byte)(85)))));
            this.btnImprimirSeleccionado.FlatAppearance.BorderSize = 0;
            this.btnImprimirSeleccionado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirSeleccionado.ForeColor = System.Drawing.Color.White;
            this.btnImprimirSeleccionado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImprimirSeleccionado.Location = new System.Drawing.Point(545, 270);
            this.btnImprimirSeleccionado.Name = "btnImprimirSeleccionado";
            this.btnImprimirSeleccionado.Size = new System.Drawing.Size(200, 35);
            this.btnImprimirSeleccionado.TabIndex = 3;
            this.btnImprimirSeleccionado.Text = "Imprimir Seleccionado";
            this.btnImprimirSeleccionado.UseVisualStyleBackColor = false;
            this.btnImprimirSeleccionado.Click += new System.EventHandler(this.btnImprimirSeleccionado_Click);

            // lblStatus
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(20, 500);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 6;

            // FrmImpresionEtiquetas
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 540);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpRecientes);
            this.Controls.Add(this.grpBusqueda);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmImpresionEtiquetas";
            this.Text = "Impresión de Etiquetas";
            this.Load += new System.EventHandler(this.FrmImpresionEtiquetas_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            this.grpRecientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpBusqueda;
        private System.Windows.Forms.Label lblTracking;
        private System.Windows.Forms.TextBox txtTracking;
        private System.Windows.Forms.Button btnImprimirDirecto;
        private System.Windows.Forms.GroupBox grpRecientes;
        private System.Windows.Forms.DataGridView dgvRecientes;
        private System.Windows.Forms.Button btnImprimirSeleccionado;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblStatus;
    }
}
