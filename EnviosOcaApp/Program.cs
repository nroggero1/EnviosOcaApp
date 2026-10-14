using System;
using System.IO;
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
        public static ExcelAuditoriaService AuditoriaService { get; private set; }
        public static OcaRestService OcaService { get; private set; }
        public static InactividadService InactividadService { get; private set; }

        [STAThread]
        static void Main()
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