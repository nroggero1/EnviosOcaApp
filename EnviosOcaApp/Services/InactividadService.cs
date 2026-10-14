using System;
using System.Drawing;
using System.Windows.Forms;
using EnviosOcaApp.Views;

namespace EnviosOcaApp.Services
{
    public class InactividadService : IMessageFilter, IDisposable
    {
        private readonly int _minutosTimeout;
        private readonly System.Windows.Forms.Timer _timerChequeo;
        private DateTime _ultimaActividad;
        private Point _ultimoCursorPos;
        private bool _avisoAbierto = false;
        private bool _activo = false;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_MBUTTONDOWN = 0x0207;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_MOUSEHWHEEL = 0x020E;

        public InactividadService(int minutosTimeout = 30)
        {
            _minutosTimeout = minutosTimeout <= 0 ? 30 : minutosTimeout;
            _ultimaActividad = DateTime.Now;
            _ultimoCursorPos = Cursor.Position;

            _timerChequeo = new System.Windows.Forms.Timer
            {
                Interval = 5000 // Chequear cada 5 segundos
            };
            _timerChequeo.Tick += TimerChequeo_Tick;
        }

        public void Iniciar()
        {
            if (_activo) return;

            _ultimaActividad = DateTime.Now;
            _ultimoCursorPos = Cursor.Position;
            _avisoAbierto = false;
            _activo = true;

            Application.AddMessageFilter(this);
            _timerChequeo.Start();
        }

        public void Detener()
        {
            if (!_activo) return;

            _timerChequeo.Stop();
            Application.RemoveMessageFilter(this);
            _activo = false;
        }

        public void RegistrarActividadManual()
        {
            _ultimaActividad = DateTime.Now;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (!_activo) return false;

            if (m.Msg == WM_MOUSEMOVE)
            {
                var posActual = Cursor.Position;
                if (posActual != _ultimoCursorPos)
                {
                    _ultimoCursorPos = posActual;
                    _ultimaActividad = DateTime.Now;
                }
            }
            else if (m.Msg == WM_KEYDOWN || m.Msg == WM_KEYUP ||
                     m.Msg == WM_SYSKEYDOWN || m.Msg == WM_SYSKEYUP ||
                     m.Msg == WM_LBUTTONDOWN || m.Msg == WM_RBUTTONDOWN ||
                     m.Msg == WM_MBUTTONDOWN || m.Msg == WM_MOUSEWHEEL ||
                     m.Msg == WM_MOUSEHWHEEL)
            {
                _ultimaActividad = DateTime.Now;
            }

            return false;
        }

        private void TimerChequeo_Tick(object? sender, EventArgs e)
        {
            if (!_activo || _avisoAbierto) return;

            var transcurrido = DateTime.Now - _ultimaActividad;
            if (transcurrido.TotalMinutes >= _minutosTimeout)
            {
                _avisoAbierto = true;
                _timerChequeo.Stop();

                try
                {
                    using var frmAviso = new FrmAvisoInactividad(_minutosTimeout);
                    var resultado = frmAviso.ShowDialog();

                    if (resultado == DialogResult.Abort || resultado == DialogResult.Cancel)
                    {
                        Program.AuditoriaService?.RegistrarNavegacion("Seguridad", $"Desconexión automática por {_minutosTimeout} minutos de inactividad");
                        Detener();
                        Application.Exit();
                    }
                    else
                    {
                        // El usuario confirmó que desea continuar trabajando
                        _ultimaActividad = DateTime.Now;
                        _ultimoCursorPos = Cursor.Position;
                        _avisoAbierto = false;
                        _timerChequeo.Start();
                    }
                }
                catch
                {
                    // En caso de cualquier error al mostrar diálogo, cerrar por seguridad
                    Application.Exit();
                }
            }
        }

        public void Dispose()
        {
            Detener();
            _timerChequeo.Dispose();
        }
    }
}
