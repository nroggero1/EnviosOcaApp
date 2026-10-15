using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using EnviosOcaApp.Models;
using EnviosOcaApp.Utils;

namespace EnviosOcaApp.Views
{
    public partial class FrmGestionUsuarios : Form
    {
        private List<UsuarioApp> _usuarios = new List<UsuarioApp>();
        private readonly string _usersPath = Program.ConfiguracionActual.ObtenerRutaUsuariosCompleta();

        public FrmGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode)
                return;

            UiHelper.ForzarMayusculasEnControles(this);

            // Verificación estricta de seguridad: solo los administradores pueden ver y editar usuarios
            if (!EsUsuarioAdminActual())
            {
                MessageBox.Show("Acceso denegado. Solo los administradores pueden acceder y gestionar este módulo.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            CargarUsuarios();
            CargarEmpresas();
        }

        private bool EsUsuarioAdminActual()
        {
            try
            {
                if (File.Exists(_usersPath))
                {
                    string json = File.ReadAllText(_usersPath);
                    var usuarios = JsonSerializer.Deserialize<List<UsuarioApp>>(json);
                    var currentUser = usuarios?.FirstOrDefault(u => u.UsernameWindows.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase));
                    return currentUser != null && currentUser.EsAdministrador;
                }
            }
            catch { }
            return false;
        }

        private void CargarUsuarios()
        {
            if (File.Exists(_usersPath))
            {
                string json = File.ReadAllText(_usersPath);
                _usuarios = JsonSerializer.Deserialize<List<UsuarioApp>>(json) ?? new List<UsuarioApp>();
            }
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = _usuarios;
        }

        private void CargarEmpresas()
        {
            string empPath = Program.ConfiguracionActual.ObtenerRutaEmpresasCompleta();
            if (File.Exists(empPath))
            {
                string json = File.ReadAllText(empPath);
                var empresas = JsonSerializer.Deserialize<List<EmpresaOca>>(json) ?? new List<EmpresaOca>();
                cmbEmpresa.Items.Clear();
                foreach (var emp in empresas)
                {
                    cmbEmpresa.Items.Add(emp.Nombre.ToUpper());
                }
            }
        }

        private void GuardarUsuarios()
        {
            string json = JsonSerializer.Serialize(_usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_usersPath, json);

            // Sincronizar con el directorio base de proyecto si existe
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "usuarios.json");
            if (File.Exists(sourcePath) && !sourcePath.Equals(_usersPath, StringComparison.OrdinalIgnoreCase))
            {
                try { File.WriteAllText(sourcePath, json); } catch { }
            }

            CargarUsuarios();
            MessageBox.Show("Usuarios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var user = (UsuarioApp)dgvUsuarios.SelectedRows[0].DataBoundItem;
                txtUsername.Text = user.UsernameWindows;
                txtNombre.Text = user.Nombre;
                txtApellido.Text = user.Apellido;
                cmbEmpresa.Text = user.EmpresaDefecto;
                chkAdmin.Checked = user.EsAdministrador;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El Username de Windows es obligatorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El Nombre y Apellido son obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text.Trim().ToUpper();
            string nombre = txtNombre.Text.Trim().ToUpper();
            string apellido = txtApellido.Text.Trim().ToUpper();
            string empresa = cmbEmpresa.Text.Trim().ToUpper();
            bool esAdmin = chkAdmin.Checked;

            var user = _usuarios.FirstOrDefault(u => u.UsernameWindows.Equals(username, StringComparison.OrdinalIgnoreCase));

            // Salvaguarda: No permitir quitar permisos al único administrador
            if (user != null && user.EsAdministrador && !esAdmin)
            {
                int totalAdmins = _usuarios.Count(u => u.EsAdministrador);
                if (totalAdmins <= 1)
                {
                    MessageBox.Show("No se pueden revocar los permisos de administrador al único administrador del sistema.", "Operación Denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chkAdmin.Checked = true;
                    return;
                }
            }

            // Criterio de registro único: si no existe se añade, si existe se actualiza
            if (user == null)
            {
                user = new UsuarioApp { UsernameWindows = username };
                _usuarios.Add(user);
            }

            user.UsernameWindows = username;
            user.Nombre = nombre;
            user.Apellido = apellido;
            user.EmpresaDefecto = empresa;
            user.EsAdministrador = esAdmin;

            GuardarUsuarios();
            Program.AuditoriaService.RegistrarNavegacion("Gestión de Usuarios", $"Guardado de usuario: {username} (Admin: {esAdmin})");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) return;

            string username = txtUsername.Text.Trim().ToUpper();

            // No permitir auto-eliminarse
            if (username.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No podés eliminar tu propia cuenta de usuario mientras tenés la sesión activa.", "Operación Denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _usuarios.FirstOrDefault(u => u.UsernameWindows.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user != null && user.EsAdministrador && _usuarios.Count(u => u.EsAdministrador) <= 1)
            {
                MessageBox.Show("No se puede eliminar al único administrador del sistema.", "Operación Denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"¿Desea eliminar el usuario {username} del sistema?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _usuarios.RemoveAll(u => u.UsernameWindows.Equals(username, StringComparison.OrdinalIgnoreCase));
                GuardarUsuarios();
                Program.AuditoriaService.RegistrarNavegacion("Gestión de Usuarios", $"Usuario eliminado: {username}");
                btnNuevo_Click(null, null);
            }
        }

        private void btnNuevo_Click(object? sender, EventArgs? e)
        {
            dgvUsuarios.ClearSelection();
            txtUsername.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            cmbEmpresa.SelectedIndex = cmbEmpresa.Items.Count > 0 ? 0 : -1;
            chkAdmin.Checked = false;
            txtUsername.Focus();
        }
    }
}
