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
            if (string.IsNullOrWhiteSpace(RutaArchivoUsuarios))
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "usuarios.json");

            if (Path.IsPathRooted(RutaArchivoUsuarios))
                return RutaArchivoUsuarios;

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RutaArchivoUsuarios);
        }

        public string ObtenerRutaEmpresasCompleta()
        {
            if (string.IsNullOrWhiteSpace(RutaArchivoEmpresas))
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "empresas.json");

            if (Path.IsPathRooted(RutaArchivoEmpresas))
                return RutaArchivoEmpresas;

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RutaArchivoEmpresas);
        }

        public string ObtenerDirectorioEtiquetasPdf()
        {
            if (!string.IsNullOrWhiteSpace(DirectorioDescargaEtiquetasPdf))
            {
                if (Path.IsPathRooted(DirectorioDescargaEtiquetasPdf))
                    return DirectorioDescargaEtiquetasPdf;

                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DirectorioDescargaEtiquetasPdf);
            }

            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Etiquetas_OCA");
        }
    }
}
