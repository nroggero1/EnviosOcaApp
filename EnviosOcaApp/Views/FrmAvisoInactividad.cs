using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnviosOcaApp.Views
{
    public class FrmAvisoInactividad : Form
    {
        private int _segundosRestantes = 20;
        private readonly System.Windows.Forms.Timer _timerCuentaRegresiva;
        private readonly Label _lblContador;

        public FrmAvisoInactividad(int minutosInactivo = 30)
        {
            Width = 480;
            Height = 240;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alerta de Inactividad - Desconexión Automática";
            TopMost = true;
            ControlBox = false;
            BackColor = Color.White;

            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 45,
                BackColor = Color.FromArgb(243, 156, 18) // Alerta ámbar
            };

            var lblTitulo = new Label
            {
                Text = "⚠️ Sesión Inactiva",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 10),
                AutoSize = true
            };
            pnlHeader.Controls.Add(lblTitulo);

            var lblMensaje = new Label
            {
                Text = $"No se ha registrado actividad en la aplicación durante {minutosInactivo} minutos.\nPor seguridad, la aplicación se cerrará en:",
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(50, 50, 50),
                Location = new Point(20, 60),
                Size = new Size(430, 45)
            };

            _lblContador = new Label
            {
                Text = $"{_segundosRestantes} segundos",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(192, 57, 43),
                Location = new Point(20, 110),
                Size = new Size(430, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var btnContinuar = new Button
            {
                Text = "Continuar Trabajando",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(135, 155),
                Size = new Size(180, 35),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnContinuar.FlatAppearance.BorderSize = 0;

            var btnCerrar = new Button
            {
                Text = "Cerrar Ahora",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                BackColor = Color.FromArgb(236, 240, 241),
                ForeColor = Color.FromArgb(44, 62, 80),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(325, 155),
                Size = new Size(125, 35),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Abort
            };
            btnCerrar.FlatAppearance.BorderSize = 0;

            Controls.Add(pnlHeader);
            Controls.Add(lblMensaje);
            Controls.Add(_lblContador);
            Controls.Add(btnContinuar);
            Controls.Add(btnCerrar);

            AcceptButton = btnContinuar;

            _timerCuentaRegresiva = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            _timerCuentaRegresiva.Tick += (s, e) =>
            {
                _segundosRestantes--;
                if (_segundosRestantes <= 0)
                {
                    _timerCuentaRegresiva.Stop();
                    DialogResult = DialogResult.Abort;
                    Close();
                }
                else
                {
                    _lblContador.Text = $"{_segundosRestantes} segundos";
                }
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _timerCuentaRegresiva.Start();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerCuentaRegresiva.Stop();
            _timerCuentaRegresiva.Dispose();
            base.OnFormClosed(e);
        }
    }
}
