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
            UiHelper.ForzarMayusculasEnControles(this);

            // Verificación estricta de seguridad: solo los administradores pueden ver y editar usuarios
            if (!EsUsuarioAdminActual())
            {
                MessageBox.Show("Acceso denegado. Solo los administradores pueden acceder y gestionar este módulo.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            OrganizarLayout();
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

        private void OrganizarLayout()
        {
            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4,
                AutoSize = true,
                Padding = new Padding(10)
            };

            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            lblUsername.Text = "Username Windows:"; 
            lblUsername.AutoSize = true; 
            lblUsername.Dock = DockStyle.Fill; 
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.CharacterCasing = CharacterCasing.Upper;

            lblNombre.Text = "Nombre:"; 
            lblNombre.AutoSize = true; 
            lblNombre.Dock = DockStyle.Fill; 
            lblNombre.TextAlign = ContentAlignment.MiddleLeft;
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.CharacterCasing = CharacterCasing.Upper;

            lblApellido.Text = "Apellido:"; 
            lblApellido.AutoSize = true; 
            lblApellido.Dock = DockStyle.Fill; 
            lblApellido.TextAlign = ContentAlignment.MiddleLeft;
            txtApellido.Dock = DockStyle.Fill;
            txtApellido.CharacterCasing = CharacterCasing.Upper;

            lblEmpresa.Text = "Empresa Defecto:"; 
            lblEmpresa.AutoSize = true; 
            lblEmpresa.Dock = DockStyle.Fill; 
            lblEmpresa.TextAlign = ContentAlignment.MiddleLeft;
            cmbEmpresa.Dock = DockStyle.Fill; 
            cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;

            chkAdmin.Text = "Es Administrador"; 
            chkAdmin.AutoSize = true; 
            chkAdmin.Dock = DockStyle.Fill;
            chkAdmin.TextAlign = ContentAlignment.MiddleLeft; 
            chkAdmin.CheckAlign = ContentAlignment.MiddleLeft;
            chkAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            tlp.Controls.Add(lblUsername, 0, 0);
            tlp.Controls.Add(txtUsername, 1, 0);
            
            tlp.Controls.Add(lblNombre, 0, 1);
            tlp.Controls.Add(txtNombre, 1, 1);
            tlp.Controls.Add(lblApellido, 2, 1);
            tlp.Controls.Add(txtApellido, 3, 1);

            tlp.Controls.Add(lblEmpresa, 0, 2);
            tlp.Controls.Add(cmbEmpresa, 1, 2);
            tlp.Controls.Add(chkAdmin, 2, 2);
            tlp.SetColumnSpan(chkAdmin, 2);

            var panelBotones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Padding = new Padding(0, 8, 0, 0)
            };

            btnNuevo.Text = "Nuevo"; 
            btnNuevo.AutoSize = true;
            btnNuevo.Cursor = Cursors.Hand;

            btnGuardar.Text = "Guardar"; 
            btnGuardar.AutoSize = true;
            btnGuardar.BackColor = Color.FromArgb(167, 3, 85);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = Cursors.Hand;

            btnEliminar.Text = "Eliminar"; 
            btnEliminar.AutoSize = true;
            btnEliminar.BackColor = Color.FromArgb(192, 57, 43);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Cursor = Cursors.Hand;

            panelBotones.Controls.Add(btnNuevo);
            panelBotones.Controls.Add(btnGuardar);
            panelBotones.Controls.Add(btnEliminar);

            tlp.Controls.Add(panelBotones, 0, 3);
            tlp.SetColumnSpan(panelBotones, 4);

            grpDatos.Controls.Clear();
            grpDatos.Controls.Add(tlp);
            grpDatos.AutoSize = true;
            grpDatos.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            var tlpMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                Padding = new Padding(10)
            };
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            dgvUsuarios.Dock = DockStyle.Fill;
            grpDatos.Dock = DockStyle.Fill;

            tlpMain.Controls.Add(lblTitulo, 0, 0);
            tlpMain.Controls.Add(dgvUsuarios, 0, 1);
            tlpMain.Controls.Add(grpDatos, 0, 2);

            this.Controls.Clear();
            this.Controls.Add(tlpMain);
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
