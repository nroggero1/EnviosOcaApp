using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EnviosOcaApp.Utils;
using EnviosOcaApp.Views;

namespace EnviosOcaApp
{
    public partial class Form1 : Form
    {
        private Form? formularioActivo = null;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Program.AuditoriaService?.RegistrarNavegacion("Sesión", "Cierre voluntario de la aplicación por el usuario");
            }
            else if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                // Cierre programado (por ejemplo, desconexión por inactividad) ya registrado por InactividadService
            }
            else
            {
                Program.AuditoriaService?.RegistrarNavegacion("Sesión", $"Cierre de aplicación (Motivo: {e.CloseReason})");
            }
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

            // Forzar que todos los inputs del formulario hijo manejen mayúsculas
            UiHelper.ForzarMayusculasEnControles(formHijo);

            formHijo.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.AuditoriaService?.RegistrarNavegacion("Sesión", $"Inicio de sesión / Apertura de la aplicación ({Environment.UserName})");

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

            UiHelper.ForzarMayusculasEnControles(this);

            ValidarPermisosUsuario();

            // Abrir el módulo de generación por defecto al iniciar
            AbrirFormularioHijo(new FrmGeneracionEnvio());
        }

        private bool EsUsuarioActualAdmin()
        {
            string usersPath = Program.ConfiguracionActual.ObtenerRutaUsuariosCompleta();
            if (File.Exists(usersPath))
            {
                string json = File.ReadAllText(usersPath);
                var usuarios = System.Text.Json.JsonSerializer.Deserialize<System.Collections.Generic.List<EnviosOcaApp.Models.UsuarioApp>>(json);
                var currentUser = usuarios?.FirstOrDefault(u => u.UsernameWindows.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase));
                return currentUser != null && currentUser.EsAdministrador;
            }
            return false;
        }

        private void ValidarPermisosUsuario()
        {
            btnGestionUsuarios.Visible = false;
            string usersPath = Program.ConfiguracionActual.ObtenerRutaUsuariosCompleta();
            
            var usuarios = new System.Collections.Generic.List<EnviosOcaApp.Models.UsuarioApp>();
            
            if (File.Exists(usersPath))
            {
                string json = File.ReadAllText(usersPath);
                usuarios = System.Text.Json.JsonSerializer.Deserialize<System.Collections.Generic.List<EnviosOcaApp.Models.UsuarioApp>>(json) ?? usuarios;
            }

            var currentUser = usuarios.FirstOrDefault(u => u.UsernameWindows.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase));
            
            if (currentUser == null)
            {
                using (var frmRegistro = new Views.FrmRegistroInicial())
                {
                    if (frmRegistro.ShowDialog() == DialogResult.OK && frmRegistro.NuevoUsuario != null)
                    {
                        currentUser = frmRegistro.NuevoUsuario;

                        // Criterio de registro único: no duplicar el username
                        var existente = usuarios.FirstOrDefault(u => u.UsernameWindows.Equals(currentUser.UsernameWindows, StringComparison.OrdinalIgnoreCase));
                        if (existente == null)
                        {
                            usuarios.Add(currentUser);
                        }
                        else
                        {
                            existente.Nombre = currentUser.Nombre;
                            existente.Apellido = currentUser.Apellido;
                            existente.EmpresaDefecto = currentUser.EmpresaDefecto;
                            currentUser = existente;
                        }

                        string newJson = System.Text.Json.JsonSerializer.Serialize(usuarios, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                        
                        Directory.CreateDirectory(Path.GetDirectoryName(usersPath)!);
                        File.WriteAllText(usersPath, newJson);

                        // Sincronizar también con la carpeta del proyecto si existe
                        string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "usuarios.json");
                        if (File.Exists(sourcePath) && !sourcePath.Equals(usersPath, StringComparison.OrdinalIgnoreCase))
                        {
                            try { File.WriteAllText(sourcePath, newJson); } catch { }
                        }

                        Program.AuditoriaService.RegistrarNavegacion("Registro Inicial", $"Registro de nuevo usuario: {currentUser.UsernameWindows} ({currentUser.Apellido} {currentUser.Nombre})");
                    }
                    else
                    {
                        MessageBox.Show("Es obligatorio completar el registro inicial para utilizar el sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (!EsUsuarioActualAdmin())
            {
                MessageBox.Show("Acceso denegado. Este módulo está restringido exclusivamente a administradores.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Program.AuditoriaService.RegistrarNavegacion("Gestión de Usuarios", "Ingreso al módulo");
            AbrirFormularioHijo(new Views.FrmGestionUsuarios());
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

        public void NavegarASeguimiento(string? codigoTracking = null)
        {
            Program.AuditoriaService.RegistrarNavegacion("Auditoría y Seguimiento", $"Navegación automática a seguimiento: {codigoTracking}");
            var frm = new FrmSeguimiento();
            AbrirFormularioHijo(frm);
            if (!string.IsNullOrWhiteSpace(codigoTracking))
            {
                frm.ConsultarTracking(codigoTracking);
            }
        }
    }
}
