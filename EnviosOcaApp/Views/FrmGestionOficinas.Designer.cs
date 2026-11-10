namespace EnviosOcaApp.Views
{
    partial class FrmGestionOficinas
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
            panelHeader = new Panel();
            lblTitulo = new Label();

            dgvOficinas = new DataGridView();

            grpDatos = new GroupBox();

            lblCodigo = new Label();
            txtCodigo = new TextBox();

            lblNombre = new Label();
            txtNombre = new TextBox();

            lblCalle = new Label();
            txtCalle = new TextBox();

            lblNumero = new Label();
            txtNumero = new TextBox();

            lblPiso = new Label();
            txtPiso = new TextBox();

            lblLocalidad = new Label();
            txtLocalidad = new TextBox();

            lblProvincia = new Label();
            txtProvincia = new TextBox();

            lblCP = new Label();
            txtCP = new TextBox();

            chkActiva = new CheckBox();

            btnNuevo = new Button();
            btnGuardar = new Button();
            btnDesactivar = new Button();

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOficinas).BeginInit();
            grpDatos.SuspendLayout();

            SuspendLayout();

            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(246, 246, 247);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 50;
            panelHeader.Controls.Add(lblTitulo);

            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font =
                new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(167, 3, 85);

            lblTitulo.Location = new Point(20, 13);

            lblTitulo.Text =
                "Gestión de Oficinas y Sucursales";

            //
            // dgvOficinas
            //
            dgvOficinas.AllowUserToAddRows = false;
            dgvOficinas.AllowUserToDeleteRows = false;

            dgvOficinas.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvOficinas.Location =
                new Point(20, 70);

            dgvOficinas.Size =
                new Size(940, 250);

            dgvOficinas.MultiSelect = false;

            dgvOficinas.ReadOnly = true;

            dgvOficinas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvOficinas.SelectionChanged +=
                dgvOficinas_SelectionChanged;

            //
            // grpDatos
            //
            grpDatos.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            grpDatos.Location =
                new Point(20, 335);

            grpDatos.Size =
                new Size(940, 180);

            grpDatos.Text =
                "Datos de la Oficina";

            //
            // Codigo
            //
            lblCodigo.Location = new Point(20, 35);
            lblCodigo.Size = new Size(80, 25);
            lblCodigo.Text = "Código:";

            txtCodigo.Location = new Point(110, 32);
            txtCodigo.Size = new Size(180, 23);

            //
            // Nombre
            //
            lblNombre.Location = new Point(330, 35);
            lblNombre.Size = new Size(80, 25);
            lblNombre.Text = "Nombre:";

            txtNombre.Location = new Point(420, 32);
            txtNombre.Size = new Size(250, 23);

            //
            // Calle
            //
            lblCalle.Location = new Point(20, 70);
            lblCalle.Size = new Size(80, 25);
            lblCalle.Text = "Calle:";

            txtCalle.Location = new Point(110, 67);
            txtCalle.Size = new Size(180, 23);

            //
            // Numero
            //
            lblNumero.Location = new Point(330, 70);
            lblNumero.Size = new Size(80, 25);
            lblNumero.Text = "Número:";

            txtNumero.Location = new Point(420, 67);
            txtNumero.Size = new Size(120, 23);

            //
            // Piso
            //
            lblPiso.Location = new Point(20, 105);
            lblPiso.Size = new Size(80, 25);
            lblPiso.Text = "Piso:";

            txtPiso.Location = new Point(110, 102);
            txtPiso.Size = new Size(180, 23);

            //
            // Localidad
            //
            lblLocalidad.Location = new Point(330, 105);
            lblLocalidad.Size = new Size(80, 25);
            lblLocalidad.Text = "Localidad:";

            txtLocalidad.Location = new Point(420, 102);
            txtLocalidad.Size = new Size(250, 23);

            //
            // Provincia
            //
            lblProvincia.Location = new Point(20, 140);
            lblProvincia.Size = new Size(80, 25);
            lblProvincia.Text = "Provincia:";

            txtProvincia.Location = new Point(110, 137);
            txtProvincia.Size = new Size(180, 23);

            //
            // CP
            //
            lblCP.Location = new Point(330, 140);
            lblCP.Size = new Size(80, 25);
            lblCP.Text = "CP:";

            txtCP.Location = new Point(420, 137);
            txtCP.Size = new Size(120, 23);

            //
            // chkActiva
            //
            chkActiva.AutoSize = true;
            chkActiva.Location = new Point(720, 35);
            chkActiva.Text = "Oficina Activa";

            //
            // btnNuevo
            //
            btnNuevo.Location = new Point(20, 530);
            btnNuevo.Size = new Size(100, 35);
            btnNuevo.Text = "Nuevo";

            btnNuevo.Click += btnNuevo_Click;

            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(130, 530);
            btnGuardar.Size = new Size(100, 35);

            btnGuardar.Text = "Guardar";

            btnGuardar.BackColor =
                Color.FromArgb(167, 3, 85);

            btnGuardar.ForeColor =
                Color.White;

            btnGuardar.FlatStyle =
                FlatStyle.Flat;

            btnGuardar.FlatAppearance.BorderSize = 0;

            btnGuardar.Click += btnGuardar_Click;

            //
            // btnDesactivar
            //
            btnDesactivar.Location = new Point(240, 530);
            btnDesactivar.Size = new Size(120, 35);

            btnDesactivar.Text = "Desactivar";

            btnDesactivar.BackColor =
                Color.FromArgb(192, 57, 43);

            btnDesactivar.ForeColor =
                Color.White;

            btnDesactivar.FlatStyle =
                FlatStyle.Flat;

            btnDesactivar.FlatAppearance.BorderSize = 0;

            btnDesactivar.Click += btnDesactivar_Click;

            grpDatos.Controls.Add(lblCodigo);
            grpDatos.Controls.Add(txtCodigo);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblCalle);
            grpDatos.Controls.Add(txtCalle);
            grpDatos.Controls.Add(lblNumero);
            grpDatos.Controls.Add(txtNumero);
            grpDatos.Controls.Add(lblPiso);
            grpDatos.Controls.Add(txtPiso);
            grpDatos.Controls.Add(lblLocalidad);
            grpDatos.Controls.Add(txtLocalidad);
            grpDatos.Controls.Add(lblProvincia);
            grpDatos.Controls.Add(txtProvincia);
            grpDatos.Controls.Add(lblCP);
            grpDatos.Controls.Add(txtCP);
            grpDatos.Controls.Add(chkActiva);

            //
            // Form
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor = Color.White;

            ClientSize = new Size(980, 590);

            Controls.Add(btnDesactivar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(grpDatos);
            Controls.Add(dgvOficinas);
            Controls.Add(panelHeader);

            Name = "FrmGestionOficinas";

            Text = "Gestión de Oficinas";

            Load += FrmGestionOficinas_Load;

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)dgvOficinas).EndInit();

            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();

            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;

        private DataGridView dgvOficinas;

        private GroupBox grpDatos;

        private Label lblCodigo;
        private Label lblNombre;
        private Label lblCalle;
        private Label lblNumero;
        private Label lblPiso;
        private Label lblLocalidad;
        private Label lblProvincia;
        private Label lblCP;

        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtCalle;
        private TextBox txtNumero;
        private TextBox txtPiso;
        private TextBox txtLocalidad;
        private TextBox txtProvincia;
        private TextBox txtCP;

        private CheckBox chkActiva;

        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnDesactivar;
    }
}