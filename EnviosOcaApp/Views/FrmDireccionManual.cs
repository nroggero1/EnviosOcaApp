using EnviosOcaApp.Models;

namespace EnviosOcaApp.Views
{
    public partial class FrmDireccionManual : Form
    {
        public DireccionOrigenManual DireccionManual { get; private set; }
            = new DireccionOrigenManual();

        public string DireccionCompleta =>
            DireccionManual.DireccionCompleta;

        public FrmDireccionManual()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCalle.Text) ||
                string.IsNullOrWhiteSpace(txtNumero.Text) ||
                string.IsNullOrWhiteSpace(txtLocalidad.Text) ||
                string.IsNullOrWhiteSpace(txtProvincia.Text) ||
                string.IsNullOrWhiteSpace(txtCP.Text))
            {
                MessageBox.Show(
                    "Complete todos los campos obligatorios.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DireccionManual =
                new DireccionOrigenManual
                {
                    Calle = txtCalle.Text.Trim(),
                    Numero = txtNumero.Text.Trim(),
                    Piso = txtPiso.Text.Trim(),
                    Localidad = txtLocalidad.Text.Trim(),
                    Provincia = txtProvincia.Text.Trim(),
                    CP = txtCP.Text.Trim()
                };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}