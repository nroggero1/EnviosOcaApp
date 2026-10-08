namespace EnviosOcaApp.Views
{
    partial class FrmSeguimiento
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
            this.tabControlAuditoria = new System.Windows.Forms.TabControl();
            this.tabOca = new System.Windows.Forms.TabPage();
            this.dgvTrackingOca = new System.Windows.Forms.DataGridView();
            this.panelTopOca = new System.Windows.Forms.Panel();
            this.lblEstadoTracking = new System.Windows.Forms.Label();
            this.btnBuscarTracking = new System.Windows.Forms.Button();
            this.txtTracking = new System.Windows.Forms.TextBox();
            this.lblIngresoTracking = new System.Windows.Forms.Label();
            this.tabAuditoria = new System.Windows.Forms.TabPage();
            this.dgvAuditoriaInterna = new System.Windows.Forms.DataGridView();
            this.tabControlAuditoria.SuspendLayout();
            this.tabOca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingOca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaInterna)).BeginInit();
            this.panelTopOca.SuspendLayout();
            this.SuspendLayout();
            
            // tabControlAuditoria
            this.tabControlAuditoria.Controls.Add(this.tabOca);
            this.tabControlAuditoria.Controls.Add(this.tabAuditoria);
            this.tabControlAuditoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAuditoria.Location = new System.Drawing.Point(0, 0);
            this.tabControlAuditoria.Name = "tabControlAuditoria";
            this.tabControlAuditoria.SelectedIndex = 0;
            this.tabControlAuditoria.Size = new System.Drawing.Size(800, 450);
            
            // tabOca
            this.tabOca.Controls.Add(this.dgvTrackingOca);
            this.tabOca.Controls.Add(this.panelTopOca);
            this.tabOca.Location = new System.Drawing.Point(4, 24);
            this.tabOca.Name = "tabOca";
            this.tabOca.Padding = new System.Windows.Forms.Padding(3);
            this.tabOca.Size = new System.Drawing.Size(792, 422);
            this.tabOca.Text = "Seguimiento de Etiquetas OCA";
            this.tabOca.UseVisualStyleBackColor = true;
            
            // dgvTrackingOca
            this.dgvTrackingOca.AllowUserToAddRows = false;
            this.dgvTrackingOca.AllowUserToDeleteRows = false;
            this.dgvTrackingOca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackingOca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrackingOca.Location = new System.Drawing.Point(3, 53);
            this.dgvTrackingOca.Name = "dgvTrackingOca";
            this.dgvTrackingOca.ReadOnly = true;
            this.dgvTrackingOca.Size = new System.Drawing.Size(786, 366);
            
            // panelTopOca
            this.panelTopOca.Controls.Add(this.lblEstadoTracking);
            this.panelTopOca.Controls.Add(this.btnBuscarTracking);
            this.panelTopOca.Controls.Add(this.txtTracking);
            this.panelTopOca.Controls.Add(this.lblIngresoTracking);
            this.panelTopOca.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopOca.Location = new System.Drawing.Point(3, 3);
            this.panelTopOca.Name = "panelTopOca";
            this.panelTopOca.Size = new System.Drawing.Size(786, 50);
            
            // lblEstadoTracking
            this.lblEstadoTracking.AutoSize = true;
            this.lblEstadoTracking.Location = new System.Drawing.Point(400, 18);
            this.lblEstadoTracking.Name = "lblEstadoTracking";
            this.lblEstadoTracking.Size = new System.Drawing.Size(0, 15);
            
            // btnBuscarTracking
            this.btnBuscarTracking.Location = new System.Drawing.Point(300, 14);
            this.btnBuscarTracking.Name = "btnBuscarTracking";
            this.btnBuscarTracking.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarTracking.Text = "Buscar";
            this.btnBuscarTracking.UseVisualStyleBackColor = true;
            this.btnBuscarTracking.Click += new System.EventHandler(this.btnBuscarTracking_Click);
            
            // txtTracking
            this.txtTracking.Location = new System.Drawing.Point(140, 15);
            this.txtTracking.Name = "txtTracking";
            this.txtTracking.Size = new System.Drawing.Size(150, 23);
            
            // lblIngresoTracking
            this.lblIngresoTracking.AutoSize = true;
            this.lblIngresoTracking.Location = new System.Drawing.Point(15, 18);
            this.lblIngresoTracking.Name = "lblIngresoTracking";
            this.lblIngresoTracking.Size = new System.Drawing.Size(117, 15);
            this.lblIngresoTracking.Text = "Nro Tracking/Orden:";
            
            // tabAuditoria
            this.tabAuditoria.Controls.Add(this.dgvAuditoriaInterna);
            this.tabAuditoria.Location = new System.Drawing.Point(4, 24);
            this.tabAuditoria.Name = "tabAuditoria";
            this.tabAuditoria.Padding = new System.Windows.Forms.Padding(3);
            this.tabAuditoria.Size = new System.Drawing.Size(792, 422);
            this.tabAuditoria.Text = "Historial de Etiquetas";
            this.tabAuditoria.UseVisualStyleBackColor = true;
            
            // dgvAuditoriaInterna
            this.dgvAuditoriaInterna.AllowUserToAddRows = false;
            this.dgvAuditoriaInterna.AllowUserToDeleteRows = false;
            this.dgvAuditoriaInterna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoriaInterna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuditoriaInterna.Location = new System.Drawing.Point(3, 3);
            this.dgvAuditoriaInterna.Name = "dgvAuditoriaInterna";
            this.dgvAuditoriaInterna.ReadOnly = true;
            this.dgvAuditoriaInterna.Size = new System.Drawing.Size(786, 416);
            this.dgvAuditoriaInterna.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuditoriaInterna_CellDoubleClick);
            
            // FrmSeguimiento
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlAuditoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeguimiento";
            this.Text = "Seguimiento";
            this.Load += new System.EventHandler(this.FrmSeguimiento_Load);
            this.tabControlAuditoria.ResumeLayout(false);
            this.tabOca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingOca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaInterna)).EndInit();
            this.panelTopOca.ResumeLayout(false);
            this.panelTopOca.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlAuditoria;
        private System.Windows.Forms.TabPage tabOca;
        private System.Windows.Forms.TabPage tabAuditoria;
        private System.Windows.Forms.DataGridView dgvTrackingOca;
        private System.Windows.Forms.DataGridView dgvAuditoriaInterna;
        private System.Windows.Forms.Panel panelTopOca;
        private System.Windows.Forms.Button btnBuscarTracking;
        private System.Windows.Forms.TextBox txtTracking;
        private System.Windows.Forms.Label lblIngresoTracking;
        private System.Windows.Forms.Label lblEstadoTracking;
    }
}
