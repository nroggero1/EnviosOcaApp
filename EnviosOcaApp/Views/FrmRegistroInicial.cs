using System;
using System.Collections.Generic;
using System.IO;
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
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode)
                return;

            txtUsername.Text = Environment.UserName.ToUpper();
            CargarEmpresas();
            UiHelper.ForzarMayusculasEnControles(this);
            txtNombre.Focus();
        }

        private void CargarEmpresas()
        {
            cmbEmpresa.Items.Clear();
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

            if (cmbEmpresa.SelectedItem == null && cmbEmpresa.Items.Count > 0)
            {
                cmbEmpresa.SelectedIndex = 0;
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
