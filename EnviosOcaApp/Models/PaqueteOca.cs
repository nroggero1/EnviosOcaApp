namespace EnviosOcaApp.Models
{
    public class PaqueteOca
    {
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }
        public decimal Peso { get; set; }
        public decimal Valor { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}
