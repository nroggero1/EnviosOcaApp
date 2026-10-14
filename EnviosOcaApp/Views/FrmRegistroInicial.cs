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
    public partial class FrmRegistroInicial : Form
    {
        public UsuarioApp? NuevoUsuario { get; private set; }

        public FrmRegistroInicial()
        {
            InitializeComponent();
        }

        private void FrmRegistroInicial_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Environment.UserName.ToUpper();
            CargarEmpresas();
            OrganizarLayout();
            UiHelper.ForzarMayusculasEnControles(this);
        }

        private void OrganizarLayout()
        {
            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 5,
                AutoSize = true,
                Padding = new Padding(15)
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            lblMensaje.Text = "¡Bienvenido! Es tu primer ingreso al sistema. Por favor completá tus datos de usuario:";
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font(lblMensaje.Font, FontStyle.Bold);
            tlp.Controls.Add(lblMensaje, 0, 0);
            tlp.SetColumnSpan(lblMensaje, 2);

            lblUsername.Text = "Usuario Windows:"; 
            lblUsername.Dock = DockStyle.Fill; 
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            txtUsername.Dock = DockStyle.Fill; 
            txtUsername.ReadOnly = true;
            txtUsername.CharacterCasing = CharacterCasing.Upper;
            tlp.Controls.Add(lblUsername, 0, 1); 
            tlp.Controls.Add(txtUsername, 1, 1);

            lblNombre.Text = "Nombre:"; 
            lblNombre.Dock = DockStyle.Fill; 
            lblNombre.TextAlign = ContentAlignment.MiddleLeft;
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            tlp.Controls.Add(lblNombre, 0, 2); 
            tlp.Controls.Add(txtNombre, 1, 2);

            lblApellido.Text = "Apellido:"; 
            lblApellido.Dock = DockStyle.Fill; 
            lblApellido.TextAlign = ContentAlignment.MiddleLeft;
            txtApellido.Dock = DockStyle.Fill;
            txtApellido.CharacterCasing = CharacterCasing.Upper;
            tlp.Controls.Add(lblApellido, 0, 3); 
            tlp.Controls.Add(txtApellido, 1, 3);

            lblEmpresa.Text = "Empresa Defecto:"; 
            lblEmpresa.Dock = DockStyle.Fill; 
            lblEmpresa.TextAlign = ContentAlignment.MiddleLeft;
            cmbEmpresa.Dock = DockStyle.Fill; 
            cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            tlp.Controls.Add(lblEmpresa, 0, 4); 
            tlp.Controls.Add(cmbEmpresa, 1, 4);

            var tlpMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            
            tlp.Dock = DockStyle.Fill;
            tlpMain.Controls.Add(tlp, 0, 0);

            btnGuardar.Text = "Comenzar";
            btnGuardar.Anchor = AnchorStyles.Right;
            var pnlBotones = new FlowLayoutPanel 
            { 
                FlowDirection = FlowDirection.RightToLeft, 
                Dock = DockStyle.Fill, 
                AutoSize = true, 
                Padding = new Padding(10) 
            };
            pnlBotones.Controls.Add(btnGuardar);
            tlpMain.Controls.Add(pnlBotones, 0, 1);

            this.Controls.Clear();
            this.Controls.Add(tlpMain);
        }

        private void CargarEmpresas()
        {
            string empPath = Program.ConfiguracionActual.ObtenerRutaEmpresasCompleta();
            if (File.Exists(empPath))
            {
                string json = File.ReadAllText(empPath);
                var empresas = JsonSerializer.Deserialize<List<EmpresaOca>>(json) ?? new List<EmpresaOca>();
                foreach (var emp in empresas)
                {
                    cmbEmpresa.Items.Add(emp.Nombre.ToUpper());
                }
                if (cmbEmpresa.Items.Count > 0) cmbEmpresa.SelectedIndex = 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, completá tu nombre y apellido.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NuevoUsuario = new UsuarioApp
            {
                UsernameWindows = txtUsername.Text.Trim().ToUpper(),
                Nombre = txtNombre.Text.Trim().ToUpper(),
                Apellido = txtApellido.Text.Trim().ToUpper(),
                EmpresaDefecto = cmbEmpresa.Text.Trim().ToUpper(),
                EsAdministrador = false
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
