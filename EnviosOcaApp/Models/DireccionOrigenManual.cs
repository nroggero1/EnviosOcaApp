namespace EnviosOcaApp.Models
{
    public class DireccionOrigenManual
    {
        public string Calle { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Piso { get; set; } = "";
        public string Localidad { get; set; } = "";
        public string Provincia { get; set; } = "";
        public string CP { get; set; } = "";

        public string DireccionCompleta =>
            $"{Calle} {Numero} {Piso}".Trim()
            + Environment.NewLine +
            $"{Localidad} - {Provincia}"
            + Environment.NewLine +
            $"CP {CP}";
    }
}
