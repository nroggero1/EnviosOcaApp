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

            ValidarPermisosUsuario();

            // Abrir el mÃ³dulo de generaciÃ³n por defecto al iniciar
            AbrirFormularioHijo(new FrmGeneracionEnvio());
        }

                private void ValidarPermisosUsuario()
        {
            btnGestionUsuarios.Visible = false;
            string usersPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "usuarios.json");
            
            var usuarios = new System.Collections.Generic.List<EnviosOcaApp.Models.UsuarioApp>();
            
            if (System.IO.File.Exists(usersPath))
            {
                string json = System.IO.File.ReadAllText(usersPath);
                usuarios = System.Text.Json.JsonSerializer.Deserialize<System.Collections.Generic.List<EnviosOcaApp.Models.UsuarioApp>>(json) ?? usuarios;
            }

            var currentUser = System.Linq.Enumerable.FirstOrDefault(usuarios, u => u.UsernameWindows.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase));
            
            if (currentUser == null)
            {
                using (var frmRegistro = new Views.FrmRegistroInicial())
                {
                    if (frmRegistro.ShowDialog() == DialogResult.OK && frmRegistro.NuevoUsuario != null)
                    {
                        currentUser = frmRegistro.NuevoUsuario;
                        usuarios.Add(currentUser);
                        string newJson = System.Text.Json.JsonSerializer.Serialize(usuarios, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                        
                        // Ensure directory exists just in case
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(usersPath)!);
                        System.IO.File.WriteAllText(usersPath, newJson);
                    }
                    else
                    {
                        // User cancelled or closed the mandatory prompt. Exit app?
                        MessageBox.Show("Es obligatorio completar el registro inicial.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Environment.Exit(0);
                    }
                }
            }

            if (currentUser != null && currentUser.EsAdministrador)
            {
                btnGestionUsuarios.Visible = true;
            }
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            Program.AuditoriaService.RegistrarNavegacion("Gestión de Usuarios", "Ingreso al módulo");
            AbrirFormularioHijo(new Views.FrmGestionUsuarios());
        }

        private void btnGenerarEnvios_Click(object sender, EventArgs e)
        {
            Program.AuditoriaService.RegistrarNavegacion("GeneraciÃ³n de EnvÃ­os", "Ingreso al mÃ³dulo");
            AbrirFormularioHijo(new FrmGeneracionEnvio());
        }

        private void btnImprimirEtiquetas_Click(object sender, EventArgs e)
        {
            Program.AuditoriaService.RegistrarNavegacion("ImpresiÃ³n de Etiquetas", "Ingreso al mÃ³dulo");
            AbrirFormularioHijo(new FrmImpresionEtiquetas());
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            Program.AuditoriaService.RegistrarNavegacion("AuditorÃ­a y Seguimiento", "Ingreso al mÃ³dulo");
            AbrirFormularioHijo(new FrmSeguimiento());
        }
    }
}

