namespace EnviosOcaApp.Models
{
    public class AppSettings
    {
        public string EntornoActual { get; set; } = string.Empty;
        public bool EsProduccion { get; set; } = true;
        public string OcaApiUrl { get; set; } = string.Empty;
        public string DirectorioAuditoriaEtiquetas { get; set; } = string.Empty;
        public string DirectorioAuditoriaNavegacion { get; set; } = string.Empty;

        public string OcaBaseUrl => !string.IsNullOrWhiteSpace(OcaApiUrl)
            ? OcaApiUrl
            : (EsProduccion
                ? "https://webservice.oca.com.ar/epak_tracking/Oep_TrackEPak.asmx"
                : "https://integraciones.ocadev.com.ar/epak_tracking_test/Oep_TrackEPak.asmx");
    }
}
