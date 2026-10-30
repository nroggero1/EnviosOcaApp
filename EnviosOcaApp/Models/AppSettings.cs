using System;
using System.IO;

namespace EnviosOcaApp.Models
{
    public class AppSettings
    {
        public string EntornoActual { get; set; } = "PRODUCCION";
        public bool EsProduccion { get; set; } = true;
        public string OcaApiUrl { get; set; } = string.Empty;
        public int MinutosInactividadDesconexion { get; set; } = 30;

        // -------------------------------------------------------------
        // RUTAS CENTRALIZADAS DEL SISTEMA
        // -------------------------------------------------------------
        /// <summary>
        /// Carpeta donde se guardan y leen los libros Excel de auditoría de envíos (auditoria_YYYY_MM.xlsx).
        /// Puede ser una ruta absoluta local o una ruta de red (UNC: \\Servidor\Carpeta).
        /// </summary>
        public string DirectorioAuditoriaEtiquetas { get; set; } = string.Empty;

        /// <summary>
        /// Carpeta donde se registran los logs de navegación y auditoría de eventos en CSV (navegacion_YYYY_MM.csv).
        /// </summary>
        public string DirectorioAuditoriaNavegacion { get; set; } = string.Empty;

        /// <summary>
        /// Carpeta donde se descargan y abren las etiquetas en formato PDF generadas por OCA.
        /// Si está vacía, se utilizará por defecto la carpeta "Etiquetas_OCA" en el Escritorio.
        /// </summary>
        public string DirectorioDescargaEtiquetasPdf { get; set; } = string.Empty;

        /// <summary>
        /// Ruta al archivo JSON con la nómina de usuarios del sistema y roles de administrador.
        /// Puede ser ruta relativa (Resources\usuarios.json) o ruta absoluta/de red.
        /// </summary>
        public string RutaArchivoUsuarios { get; set; } = "Resources\\usuarios.json";

        /// <summary>
        /// Ruta al archivo JSON con las empresas y cuentas operativas de OCA habilitadas.
        /// Puede ser ruta relativa (Resources\empresas.json) o ruta absoluta/de red.
        /// </summary>
        public string RutaArchivoEmpresas { get; set; } = "Resources\\empresas.json";

        public string OcaBaseUrl => !string.IsNullOrWhiteSpace(OcaApiUrl)
            ? OcaApiUrl
            : (EsProduccion
                ? "https://webservice.oca.com.ar/epak_tracking/Oep_TrackEPak.asmx"
                : "https://integraciones.ocadev.com.ar/epak_tracking_test/Oep_TrackEPak.asmx");

        public string ObtenerRutaUsuariosCompleta()
        {
            return ResolverRutaDinamica(RutaArchivoUsuarios, Path.Combine("Resources", "usuarios.json"));
        }

        public string ObtenerRutaEmpresasCompleta()
        {
            return ResolverRutaDinamica(RutaArchivoEmpresas, Path.Combine("Resources", "empresas.json"));
        }

        public string ObtenerDirectorioEtiquetasPdf()
        {
            if (!string.IsNullOrWhiteSpace(DirectorioDescargaEtiquetasPdf))
            {
                string expandida = Environment.ExpandEnvironmentVariables(DirectorioDescargaEtiquetasPdf);
                if (Path.IsPathRooted(expandida))
                    return expandida;

                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, expandida);
            }

            // Ruta dinámica por defecto para cada usuario: Descargas de su perfil Windows
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (!string.IsNullOrWhiteSpace(userProfile))
            {
                return Path.Combine(userProfile, "Downloads", "Etiquetas_OCA");
            }

            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Etiquetas_OCA");
        }

        public string ObtenerDirectorioAuditoriaEtiquetas()
        {
            return ResolverRutaDinamica(DirectorioAuditoriaEtiquetas, Path.Combine("Auditoria", "Etiquetas"));
        }

        public string ObtenerDirectorioAuditoriaNavegacion()
        {
            return ResolverRutaDinamica(DirectorioAuditoriaNavegacion, Path.Combine("Auditoria", "Navegacion"));
        }

        private string ResolverRutaDinamica(string? ruta, string fallbackRelativo)
        {
            string valor = string.IsNullOrWhiteSpace(ruta) ? fallbackRelativo : ruta;
            string expandida = Environment.ExpandEnvironmentVariables(valor);

            // Salvaguarda para entornos donde %OneDriveCommercial% no esté explícitamente seteado
            if (expandida.Contains("%OneDriveCommercial%", StringComparison.OrdinalIgnoreCase))
            {
                string? oneDrive = Environment.GetEnvironmentVariable("OneDriveCommercial") 
                    ?? Environment.GetEnvironmentVariable("OneDrive");

                if (string.IsNullOrWhiteSpace(oneDrive))
                {
                    string sancorFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive - Grupo Sancor Seguros");
                    if (Directory.Exists(sancorFolder))
                    {
                        oneDrive = sancorFolder;
                    }
                }

                if (!string.IsNullOrWhiteSpace(oneDrive))
                {
                    expandida = expandida.Replace("%OneDriveCommercial%", oneDrive, StringComparison.OrdinalIgnoreCase);
                }
            }

            if (Path.IsPathRooted(expandida))
                return expandida;

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string currentDir = Directory.GetCurrentDirectory();

            string candidateCurrent = Path.Combine(currentDir, expandida);
            if (Directory.Exists(candidateCurrent) || File.Exists(candidateCurrent))
                return candidateCurrent;

            string candidateBase = Path.Combine(baseDir, expandida);
            if (Directory.Exists(candidateBase) || File.Exists(candidateBase))
                return candidateBase;

            return candidateBase;
        }
    }
}
