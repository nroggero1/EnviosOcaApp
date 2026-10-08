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

        [STAThread]
        static void Main()
        {
            InicializarConfiguracion();

            AuditoriaService = new ExcelAuditoriaService(ConfiguracionActual);
            OcaService = new OcaRestService(ConfiguracionActual);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void InicializarConfiguracion()
        {
            var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

            var configRoot = builder.Build();
            configRoot.GetSection("AppConfig").Bind(ConfiguracionActual);
        }
    }
}