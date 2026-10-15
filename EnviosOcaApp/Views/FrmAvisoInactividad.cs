using System;
using System.Windows.Forms;

namespace EnviosOcaApp.Views
{
    public partial class FrmAvisoInactividad : Form
    {
        private int _segundosRestantes = 20;
        private readonly System.Windows.Forms.Timer _timerCuentaRegresiva;

        public FrmAvisoInactividad() : this(30)
        {
        }

        public FrmAvisoInactividad(int minutosInactivo)
        {
            InitializeComponent();

            lblMensaje.Text = $"No se ha registrado actividad en la aplicación durante {minutosInactivo} minutos.\r\nPor seguridad, la aplicación se cerrará en:";
            lblContador.Text = $"{_segundosRestantes} segundos";

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
                    lblContador.Text = $"{_segundosRestantes} segundos";
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
