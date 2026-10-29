using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using EnviosOcaApp.Models;
using EnviosOcaApp.Services;
using EnviosOcaApp.Views;

namespace EnviosOcaApp
{
    internal static class Program
    {
        public static AppSettings ConfiguracionActual { get; private set; } = new AppSettings();
        public static ExcelAuditoriaService AuditoriaService { get; private set; } = null!;
        public static OcaRestService OcaService { get; private set; } = null!;
        public static InactividadService InactividadService { get; private set; } = null!;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private const int SW_RESTORE = 9;

        [STAThread]
        static void Main()
        {
            // Restricción de instancia única: solo una sesión por usuario de Windows a la vez
            string mutexName = $"Global\\EnviosOcaApp_SingleInstance_{Environment.UserName}";
            bool esPrimeraInstancia;
            Mutex? mutex = null;

            try
            {
                mutex = new Mutex(true, mutexName, out esPrimeraInstancia);
            }
            catch (AbandonedMutexException)
            {
                esPrimeraInstancia = true;
            }

            if (!esPrimeraInstancia)
            {
                TraerInstanciaExistenteAlFrente();
                MessageBox.Show(
                    "La aplicación de Envíos OCA ya se encuentra abierta y en ejecución en este equipo.",
                    "Atención - Sesión en curso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                InicializarConfiguracion();

                AuditoriaService = new ExcelAuditoriaService(ConfiguracionActual);
                OcaService = new OcaRestService(ConfiguracionActual);
                InactividadService = new InactividadService(ConfiguracionActual.MinutosInactividadDesconexion);

                ApplicationConfiguration.Initialize();

                // Iniciar monitoreo global de inactividad
                InactividadService.Iniciar();

                Application.Run(new Form1());
            }
            finally
            {
                if (mutex != null)
                {
                    try { mutex.ReleaseMutex(); } catch { }
                    mutex.Dispose();
                }
            }
        }

        private static void TraerInstanciaExistenteAlFrente()
        {
            try
            {
                var procesoActual = Process.GetCurrentProcess();
                var procesos = Process.GetProcessesByName(procesoActual.ProcessName);
                foreach (var p in procesos)
                {
                    if (p.Id != procesoActual.Id && p.MainWindowHandle != IntPtr.Zero)
                    {
                        ShowWindowAsync(p.MainWindowHandle, SW_RESTORE);
                        SetForegroundWindow(p.MainWindowHandle);
                        break;
                    }
                }
            }
            catch { }
        }

        private static void InicializarConfiguracion()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string currentDir = Directory.GetCurrentDirectory();

            string[] candidatas = new[]
            {
                Path.Combine(baseDir, "Resources", "appsettings.json"),
                Path.Combine(currentDir, "Resources", "appsettings.json"),
                Path.Combine(baseDir, "appsettings.json"),
                Path.Combine(currentDir, "appsettings.json")
            };

            string? rutaEncontrada = null;
            foreach (var ruta in candidatas)
            {
                if (File.Exists(ruta))
                {
                    rutaEncontrada = ruta;
                    break;
                }
            }

            var builder = new ConfigurationBuilder();
            if (rutaEncontrada != null)
            {
                builder.SetBasePath(Path.GetDirectoryName(rutaEncontrada)!)
                       .AddJsonFile(Path.GetFileName(rutaEncontrada), optional: false, reloadOnChange: true);
            }
            else
            {
                builder.SetBasePath(Path.Combine(baseDir, "Resources"))
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            }

            var configRoot = builder.Build();
            configRoot.GetSection("AppConfig").Bind(ConfiguracionActual);
        }
    }
}