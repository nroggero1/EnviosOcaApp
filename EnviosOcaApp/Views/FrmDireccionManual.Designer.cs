namespace EnviosOcaApp.Views
{
    partial class FrmDireccionManual
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblCalle = new Label();
            lblNumero = new Label();
            lblPiso = new Label();
            lblLocalidad = new Label();
            lblProvincia = new Label();
            lblCP = new Label();

            txtCalle = new TextBox();
            txtNumero = new TextBox();
            txtPiso = new TextBox();
            txtLocalidad = new TextBox();
            txtProvincia = new TextBox();
            txtCP = new TextBox();

            btnAceptar = new Button();
            btnCancelar = new Button();

            SuspendLayout();

            //
            // Labels
            //
            lblCalle.Text = "Calle:";
            lblNumero.Text = "Número:";
            lblPiso.Text = "Piso:";
            lblLocalidad.Text = "Localidad:";
            lblProvincia.Text = "Provincia:";
            lblCP.Text = "CP:";

            lblCalle.Location = new Point(20, 20);
            lblNumero.Location = new Point(20, 60);
            lblPiso.Location = new Point(20, 100);
            lblLocalidad.Location = new Point(20, 140);
            lblProvincia.Location = new Point(20, 180);
            lblCP.Location = new Point(20, 220);

            //
            // TextBoxes
            //
            txtCalle.Location = new Point(120, 17);
            txtNumero.Location = new Point(120, 57);
            txtPiso.Location = new Point(120, 97);
            txtLocalidad.Location = new Point(120, 137);
            txtProvincia.Location = new Point(120, 177);
            txtCP.Location = new Point(120, 217);

            txtCalle.Size = new Size(260, 23);
            txtNumero.Size = new Size(120, 23);
            txtPiso.Size = new Size(120, 23);
            txtLocalidad.Size = new Size(260, 23);
            txtProvincia.Size = new Size(260, 23);
            txtCP.Size = new Size(120, 23);

            txtCalle.CharacterCasing = CharacterCasing.Upper;
            txtLocalidad.CharacterCasing = CharacterCasing.Upper;
            txtProvincia.CharacterCasing = CharacterCasing.Upper;

            txtCP.MaxLength = 8;
            txtNumero.MaxLength = 10;
            txtPiso.MaxLength = 10;

            //
            // btnAceptar
            //
            btnAceptar.Text = "Aceptar";
            btnAceptar.Location =
                new Point(120, 280);

            btnAceptar.Size =
                new Size(100, 35);

            btnAceptar.BackColor =
                Color.FromArgb(167, 3, 85);

            btnAceptar.ForeColor =
                Color.White;

            btnAceptar.FlatStyle =
                FlatStyle.Flat;

            btnAceptar.Click +=
                btnAceptar_Click;

            //
            // btnCancelar
            //
            btnCancelar.Text = "Cancelar";

            btnCancelar.Location =
                new Point(240, 280);

            btnCancelar.Size =
                new Size(100, 35);

            btnCancelar.Click +=
                btnCancelar_Click;

            //
            // Form
            //
            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(420, 350);

            Controls.Add(lblCalle);
            Controls.Add(lblNumero);
            Controls.Add(lblPiso);
            Controls.Add(lblLocalidad);
            Controls.Add(lblProvincia);
            Controls.Add(lblCP);

            Controls.Add(txtCalle);
            Controls.Add(txtNumero);
            Controls.Add(txtPiso);
            Controls.Add(txtLocalidad);
            Controls.Add(txtProvincia);
            Controls.Add(txtCP);

            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);

            FormBorderStyle =
                FormBorderStyle.FixedDialog;

            MaximizeBox = false;
            MinimizeBox = false;

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "Ingreso Manual de Dirección";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCalle;
        private Label lblNumero;
        private Label lblPiso;
        private Label lblLocalidad;
        private Label lblProvincia;
        private Label lblCP;

        private TextBox txtCalle;
        private TextBox txtNumero;
        private TextBox txtPiso;
        private TextBox txtLocalidad;
        private TextBox txtProvincia;
        private TextBox txtCP;

        private Button btnAceptar;
        private Button btnCancelar;
    }
}