using System;
using System.Drawing;
using System.Windows.Forms;
using EnviosOcaApp.Views;

namespace EnviosOcaApp
{
    public partial class Form1 : Form
    {
        private Form? formularioActivo = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void AbrirFormularioHijo(Form formHijo)
        {
            if (formularioActivo != null)
                formularioActivo.Close();

            formularioActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(formHijo);
            pnlContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (var stream = assembly.GetManifestResourceStream("EnviosOcaApp.Resources.PictureBox.png"))
                {
                    if (stream != null)
                    {
                        pictureBoxLogo.Image = Image.FromStream(stream);
                    }
                }
            }
            catch { /* Ignorar si no carga temporalmente */ }

            // Abrir el módulo de generación por defecto al iniciar
            AbrirFormularioHijo(new FrmGeneracionEnvio());
        }

        private void btnGenerarEnvios_Click(object sender, EventArgs e)
        {
            Program.AuditoriaService.RegistrarNavegacion("Generación de Envíos", "Ingreso al módulo");
            AbrirFormularioHijo(new FrmGeneracionEnvio());
        }

        private void btnImprimirEtiquetas_Click(object sender, EventArgs e)
        {
            Program.AuditoriaService.RegistrarNavegacion("Impresión de Etiquetas", "Ingreso al módulo");
            AbrirFormularioHijo(new FrmImpresionEtiquetas());
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            Program.AuditoriaService.RegistrarNavegacion("Auditoría y Seguimiento", "Ingreso al módulo");
            AbrirFormularioHijo(new FrmSeguimiento());
        }
    }
}
