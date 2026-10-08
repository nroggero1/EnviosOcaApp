using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EnviosOcaApp.Models;

namespace EnviosOcaApp.Views
{
    public partial class FrmGeneracionEnvio : Form
    {
        private BindingList<PaqueteOca> listaPaquetesActual;
        private BindingList<EnvioOca> listaLoteEnvios;

        public FrmGeneracionEnvio()
        {
            InitializeComponent();
            listaPaquetesActual = new BindingList<PaqueteOca>();
            listaLoteEnvios = new BindingList<EnvioOca>();
        }

        private CheckBox chkPrioritario;
        private CheckBox chkSeguro;

        private void FrmGeneracionEnvio_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = Environment.UserName;

            // Agregamos programáticamente los CheckBoxes para no tocar el Designer.cs
            chkPrioritario = new CheckBox { Text = "Envío Prioritario", AutoSize = true, Location = new System.Drawing.Point(10, 190) };
            chkSeguro = new CheckBox { Text = "Asegurar Envío", AutoSize = true, Location = new System.Drawing.Point(150, 190) };
            grpDestino.Controls.Add(chkPrioritario);
            grpDestino.Controls.Add(chkSeguro);

            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "empresas.json");
            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                var empresas = System.Text.Json.JsonSerializer.Deserialize<List<EmpresaOca>>(json);
                cmbEmpresa.DataSource = empresas;
                cmbEmpresa.DisplayMember = "Nombre";
            }

            dgvPaquetes.DataSource = listaPaquetesActual;
            dgvLoteEnvios.DataSource = listaLoteEnvios;
        }

        private void btnAgregarPaquete_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAlto.Text, out decimal alto) ||
                !decimal.TryParse(txtAncho.Text, out decimal ancho) ||
                !decimal.TryParse(txtLargo.Text, out decimal largo) ||
                !decimal.TryParse(txtPeso.Text, out decimal peso) ||
                !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                MessageBox.Show("Verifique que las dimensiones, peso y valor sean numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var paquete = new PaqueteOca
            {
                Alto = alto,
                Ancho = ancho,
                Largo = largo,
                Peso = peso,
                Valor = valor,
                Observaciones = txtObservaciones.Text
            };

            listaPaquetesActual.Add(paquete);

            // Limpiamos observaciones
            txtObservaciones.Clear();
        }

        private void btnQuitarPaquete_Click(object sender, EventArgs e)
        {
            if (dgvPaquetes.SelectedRows.Count > 0)
            {
                var paquetesParaEliminar = new List<PaqueteOca>();
                foreach (DataGridViewRow row in dgvPaquetes.SelectedRows)
                {
                    if (!row.IsNewRow && row.DataBoundItem is PaqueteOca pq)
                    {
                        paquetesParaEliminar.Add(pq);
                    }
                }

                foreach (var pq in paquetesParaEliminar)
                {
                    listaPaquetesActual.Remove(pq);
                }
            }
        }

        private void btnAgregarEnvioAlLote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestinatario.Text) || listaPaquetesActual.Count == 0)
            {
                MessageBox.Show("Debe indicar al menos un destinatario y un bulto.", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idOperativa = 283231; // Default: Estándar Sin Seguro
            if (chkPrioritario.Checked && chkSeguro.Checked) idOperativa = 416557; // Prioritario con seguro
            else if (!chkPrioritario.Checked && chkSeguro.Checked) idOperativa = 416558; // Estándar con seguro
            else if (chkPrioritario.Checked && !chkSeguro.Checked) idOperativa = 283228; // Prioritario sin seguro
            else if (!chkPrioritario.Checked && !chkSeguro.Checked) idOperativa = 283231; // Estándar sin seguro

            var envio = new EnvioOca
            {
                IdOperativa = idOperativa,
                Remito = txtRemito.Text,
                NombreDestinatario = txtDestinatario.Text,
                Calle = txtCalle.Text,
                Numero = txtNumero.Text,
                Piso = txtPiso.Text,
                Localidad = txtLocalidad.Text,
                Provincia = txtProvincia.Text,
                CP = txtCP.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                Paquetes = listaPaquetesActual.ToList()
            };

            listaLoteEnvios.Add(envio);

            // Limpiamos los campos del destino
            txtRemito.Clear();
            txtDestinatario.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            txtPiso.Clear();
            txtLocalidad.Clear();
            txtProvincia.Clear();
            txtCP.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            listaPaquetesActual.Clear();
            
            // Foco a Remito
            txtRemito.Focus();
        }

        private void btnQuitarEnvio_Click(object sender, EventArgs e)
        {
            if (dgvLoteEnvios.SelectedRows.Count > 0)
            {
                var enviosParaEliminar = new List<EnvioOca>();
                foreach (DataGridViewRow row in dgvLoteEnvios.SelectedRows)
                {
                    if (!row.IsNewRow && row.DataBoundItem is EnvioOca env)
                    {
                        enviosParaEliminar.Add(env);
                    }
                }

                foreach (var env in enviosParaEliminar)
                {
                    listaLoteEnvios.Remove(env);
                }
            }
        }

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            if (listaLoteEnvios.Count == 0)
            {
                MessageBox.Show("El lote está vacío. Por favor añada al menos un envío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEmpresa.SelectedItem is not EmpresaOca empresaSeleccionada)
            {
                MessageBox.Show("Debe seleccionar una empresa válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string remitente = txtRemitente.Text;

            try
            {
                btnGenerar.Enabled = false;
                btnGenerar.Text = "Transmitiendo...";
                lblStatus.Text = "Conectando con OCA...";
                lblStatus.ForeColor = Color.Blue;
                
                var loteParaEnviar = listaLoteEnvios.ToList();

                // 1. Llamamos al servicio OCA y obtenemos el objeto de respuesta completo (LLAMADA REAL)
                OcaResponse ocaRespuesta = await Program.OcaService.GenerarLoteRealAsync(empresaSeleccionada, remitente, loteParaEnviar);

                if (ocaRespuesta.TieneErrores)
                {
                    lblStatus.Text = "Falló la transmisión.";
                    lblStatus.ForeColor = Color.Red;
                    MessageBox.Show($"OCA rechazó el envío: {ocaRespuesta.MensajeError}", "Error de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Transmisión exitosa. Loggeamos en el Excel
                foreach (var envio in loteParaEnviar)
                {
                    string direccionCompleta = $"{envio.Calle} {envio.Numero} {envio.Piso}".Trim();
                    
                    // Buscamos la guía generada para este remito particular en la respuesta de OCA
                    var infoGuia = ocaRespuesta.EnviosGenerados.FirstOrDefault(g => 
                        g.NumeroRemito.TrimStart('0') == envio.Remito.TrimStart('0') || 
                        g.NumeroRemito == envio.Remito);
                        
                    string trackingNumber = infoGuia != null && !string.IsNullOrWhiteSpace(infoGuia.NumeroEnvio) ? infoGuia.NumeroEnvio : "S/D";

                    string destFinalAuditoria = $"{envio.NombreDestinatario} ({direccionCompleta}, {envio.Localidad}) [Tracking: {trackingNumber} | Bultos: {envio.BultosTotales}]";

                    Program.AuditoriaService.RegistrarGeneracionEtiqueta(
                        empresa: empresaSeleccionada.Nombre,
                        nroOrdenOca: trackingNumber, // Usamos el Tracking de 19 digitos (vital para imprimir)
                        remitente: remitente,
                        destinatario: destFinalAuditoria,
                        estado: "Generado Lote OK"
                    );
                }

                int totalPaquetesLote = loteParaEnviar.Sum(x => x.BultosTotales);

                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = $"¡Éxito! Operación: {ocaRespuesta.CodigoOperacion} ({ocaRespuesta.EnviosGenerados.Count} guías / {totalPaquetesLote} paquetes).";
                
                string msgBoxOp = string.IsNullOrWhiteSpace(ocaRespuesta.CodigoOperacion) ? "(Individuales)" : ocaRespuesta.CodigoOperacion;

                MessageBox.Show($"Transmisión del Lote generada exitosamente.\nN° Operación: {msgBoxOp}\nDestinatarios: {ocaRespuesta.EnviosGenerados.Count}\nTotal Etiquetas a imprimir: {totalPaquetesLote}", "Transmisión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listaLoteEnvios.Clear();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error interno.";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Ocurrió un error inesperado:\n{ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerar.Enabled = true;
                btnGenerar.Text = "Transmitir Lote OCA";
            }
        }
    }
}
