using EnviosOcaApp.Models;
using EnviosOcaApp.Utils;
using System.Text.Json;

namespace EnviosOcaApp.Views
{
    public partial class FrmGestionOficinas : Form
    {
        private List<OficinaSucursal> _oficinas = new();
        private readonly string _path =
            Program.ConfiguracionActual.ObtenerRutaOficinasCompleta();

        public FrmGestionOficinas()
        {
            InitializeComponent();
            OrganizarLayoutResponsivo();
        }

        private void OrganizarLayoutResponsivo()
        {
            var layoutDatos = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                Padding = new Padding(4),
                Margin = new Padding(0)
            };
            layoutDatos.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layoutDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutDatos.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layoutDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            for (int i = 0; i < 5; i++)
                layoutDatos.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            Control[,] campos =
            {
                { lblCodigo, txtCodigo, lblNombre, txtNombre },
                { lblCalle, txtCalle, lblNumero, txtNumero },
                { lblPiso, txtPiso, lblLocalidad, txtLocalidad },
                { lblProvincia, txtProvincia, lblCP, txtCP }
            };

            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    Control control = campos[row, column];
                    control.Margin = new Padding(3, 1, 3, 1);
                    if (control is Label label)
                    {
                        label.Dock = DockStyle.Fill;
                        label.TextAlign = ContentAlignment.MiddleLeft;
                    }
                    else
                    {
                        control.Dock = DockStyle.Fill;
                    }
                    layoutDatos.Controls.Add(control, column, row);
                }
            }

            chkActiva.Margin = new Padding(3, 1, 3, 1);
            chkActiva.Anchor = AnchorStyles.Left;
            layoutDatos.Controls.Add(chkActiva, 0, 4);
            layoutDatos.SetColumnSpan(chkActiva, 4);

            grpDatos.Controls.Clear();
            grpDatos.Dock = DockStyle.Fill;
            grpDatos.Margin = new Padding(2);
            grpDatos.Controls.Add(layoutDatos);

            var acciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Margin = new Padding(0),
                Padding = new Padding(2)
            };
            foreach (Button boton in new[] { btnNuevo, btnGuardar, btnDesactivar })
            {
                boton.Margin = new Padding(2);
                acciones.Controls.Add(boton);
            }

            var layoutPrincipal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(8),
                Margin = new Padding(0)
            };
            layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 188F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));

            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Margin = new Padding(2);
            lblTitulo.Location = new Point(14, 6);
            dgvOficinas.Dock = DockStyle.Fill;
            dgvOficinas.Margin = new Padding(2);

            layoutPrincipal.Controls.Add(panelHeader, 0, 0);
            layoutPrincipal.Controls.Add(dgvOficinas, 0, 1);
            layoutPrincipal.Controls.Add(grpDatos, 0, 2);
            layoutPrincipal.Controls.Add(acciones, 0, 3);

            Controls.Clear();
            Controls.Add(layoutPrincipal);
        }

        private void FrmGestionOficinas_Load(object sender, EventArgs e)
        {
            if (!EsUsuarioAdminActual())
            {
                MessageBox.Show(
                    "Solo los administradores pueden gestionar oficinas.",
                    "Seguridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                BeginInvoke(new Action(() => Close()));
                return;
            }

            UiHelper.ForzarMayusculasEnControles(this);

            CargarOficinas();
        }

        private bool EsUsuarioAdminActual()
        {
            try
            {
                string path =
                    Program.ConfiguracionActual.ObtenerRutaUsuariosCompleta();

                if (!File.Exists(path))
                    return false;

                string json = File.ReadAllText(path);

                var usuarios =
                    JsonSerializer.Deserialize<List<UsuarioApp>>(json)
                    ?? new List<UsuarioApp>();

                var actual =
                    usuarios.FirstOrDefault(x =>
                        x.UsernameWindows.Equals(
                            Environment.UserName,
                            StringComparison.OrdinalIgnoreCase));

                return actual?.EsAdministrador ?? false;
            }
            catch
            {
                return false;
            }
        }

        private void CargarOficinas()
        {
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);

                _oficinas =
                    JsonSerializer.Deserialize<List<OficinaSucursal>>(json)
                    ?? new List<OficinaSucursal>();
            }

            dgvOficinas.DataSource = null;
            dgvOficinas.DataSource = _oficinas;
        }

        private void GuardarOficinas()
        {
            string json =
                JsonSerializer.Serialize(
                    _oficinas,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

            File.WriteAllText(_path, json);

            CargarOficinas();

            MessageBox.Show(
                "Oficinas guardadas correctamente.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void dgvOficinas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOficinas.SelectedRows.Count == 0)
                return;

            var oficina =
                (OficinaSucursal)dgvOficinas.SelectedRows[0].DataBoundItem;

            txtCodigo.Text = oficina.Codigo;
            txtNombre.Text = oficina.Nombre;
            txtCalle.Text = oficina.Calle;
            txtNumero.Text = oficina.Numero;
            txtPiso.Text = oficina.Piso;
            txtLocalidad.Text = oficina.Localidad;
            txtProvincia.Text = oficina.Provincia;
            txtCP.Text = oficina.CP;
            chkActiva.Checked = oficina.Activa;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            txtPiso.Clear();
            txtLocalidad.Clear();
            txtProvincia.Clear();
            txtCP.Clear();
            chkActiva.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Código obligatorio.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Nombre obligatorio.");
                return;
            }

            string codigo = txtCodigo.Text.Trim().ToUpper();

            var oficina =
                _oficinas.FirstOrDefault(x =>
                    x.Codigo.Equals(
                        codigo,
                        StringComparison.OrdinalIgnoreCase));

            if (oficina == null)
            {
                oficina = new OficinaSucursal();
                _oficinas.Add(oficina);
            }

            oficina.Codigo = codigo;
            oficina.Nombre = txtNombre.Text.Trim().ToUpper();
            oficina.Calle = txtCalle.Text.Trim().ToUpper();
            oficina.Numero = txtNumero.Text.Trim().ToUpper();
            oficina.Piso = txtPiso.Text.Trim().ToUpper();
            oficina.Localidad = txtLocalidad.Text.Trim().ToUpper();
            oficina.Provincia = txtProvincia.Text.Trim().ToUpper();
            oficina.CP = txtCP.Text.Trim().ToUpper();
            oficina.Activa = chkActiva.Checked;

            GuardarOficinas();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvOficinas.SelectedRows.Count == 0)
                return;

            var oficina =
                (OficinaSucursal)dgvOficinas.SelectedRows[0].DataBoundItem;

            oficina.Activa = false;

            GuardarOficinas();
        }
    }
}