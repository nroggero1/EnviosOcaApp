using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using EnviosOcaApp.Models;

namespace EnviosOcaApp.Views
{
    public partial class FrmGestionUsuarios : Form
    {
        private List<UsuarioApp> _usuarios = new List<UsuarioApp>();
        private readonly string _usersPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "usuarios.json");

        public FrmGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            OrganizarLayout();
            CargarUsuarios();
            CargarEmpresas();
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

            lblUsername.Text = "Username Windows:"; lblUsername.AutoSize = true; lblUsername.Dock = DockStyle.Fill; lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            txtUsername.Dock = DockStyle.Fill;
            lblNombre.Text = "Nombre:"; lblNombre.AutoSize = true; lblNombre.Dock = DockStyle.Fill; lblNombre.TextAlign = ContentAlignment.MiddleLeft;
            txtNombre.Dock = DockStyle.Fill;
            lblApellido.Text = "Apellido:"; lblApellido.AutoSize = true; lblApellido.Dock = DockStyle.Fill; lblApellido.TextAlign = ContentAlignment.MiddleLeft;
            txtApellido.Dock = DockStyle.Fill;
            lblEmpresa.Text = "Empresa Defecto:"; lblEmpresa.AutoSize = true; lblEmpresa.Dock = DockStyle.Fill; lblEmpresa.TextAlign = ContentAlignment.MiddleLeft;
            cmbEmpresa.Dock = DockStyle.Fill; cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            chkAdmin.Text = "Es Administrador"; chkAdmin.AutoSize = true; chkAdmin.Dock = DockStyle.Fill;
            chkAdmin.TextAlign = ContentAlignment.MiddleLeft; chkAdmin.CheckAlign = ContentAlignment.MiddleLeft;

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
                AutoSize = true
            };
            btnNuevo.Text = "Nuevo"; btnNuevo.AutoSize = true;
            btnGuardar.Text = "Guardar"; btnGuardar.AutoSize = true;
            btnEliminar.Text = "Eliminar"; btnEliminar.AutoSize = true;
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
            string empPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "empresas.json");
            if (File.Exists(empPath))
            {
                string json = File.ReadAllText(empPath);
                var empresas = JsonSerializer.Deserialize<List<EmpresaOca>>(json) ?? new List<EmpresaOca>();
                foreach (var emp in empresas)
                {
                    cmbEmpresa.Items.Add(emp.Nombre);
                }
            }
        }

        private void GuardarUsuarios()
        {
            string json = JsonSerializer.Serialize(_usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_usersPath, json);
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
                MessageBox.Show("El Username es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = _usuarios.FirstOrDefault(u => u.UsernameWindows.Equals(txtUsername.Text, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                user = new UsuarioApp { UsernameWindows = txtUsername.Text };
                _usuarios.Add(user);
            }

            user.Nombre = txtNombre.Text;
            user.Apellido = txtApellido.Text;
            user.EmpresaDefecto = cmbEmpresa.Text;
            user.EsAdministrador = chkAdmin.Checked;

            GuardarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) return;

            var result = MessageBox.Show("¿Desea eliminar el usuario " + txtUsername.Text + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _usuarios.RemoveAll(u => u.UsernameWindows.Equals(txtUsername.Text, StringComparison.OrdinalIgnoreCase));
                GuardarUsuarios();
                btnNuevo_Click(null, null);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvUsuarios.ClearSelection();
            txtUsername.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            cmbEmpresa.SelectedIndex = -1;
            chkAdmin.Checked = false;
            txtUsername.Focus();
        }
    }
}

