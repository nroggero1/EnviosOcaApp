namespace EnviosOcaApp.Models
{
    public class OficinaSucursal
    {
        public string Codigo { get; set; } = "";

        public string Empresa { get; set; } = "";

        public string Nombre { get; set; } = "";

        public string Calle { get; set; } = "";

        public string Numero { get; set; } = "";

        public string Piso { get; set; } = "";

        public string Localidad { get; set; } = "";

        public string Provincia { get; set; } = "";

        public string CP { get; set; } = "";

        public bool Activa { get; set; } = true;





        public string EmpresaAbreviada
        {
            get
            {
                return Empresa switch
                {
                    "SANCOR SEGUROS" => "SS",
                    "PREVENCION ART" => "ART",
                    "PREVENCION SALUD" => "PS",
                    _ => Empresa
                };
            }
        }

        public string DireccionCompleta
        {
            get
            {
                string domicilio =
                    $"{Calle} {Numero} {Piso}".Trim();

                return
                    $"{domicilio} - " +
                    $"{Localidad} - " +
                    $"{Provincia} - CP {CP}";
            }
        }

        public string DisplayCombo
        {
            get
            {
                return
                    $"[{EmpresaAbreviada}] " +
                    $"{Nombre} | " +
                    $"{Calle} {Numero} | " +
                    $"{Localidad} | " +
                    $"{Codigo}";
            }
        }

        public bool EsIngresoManual
        {
            get
            {
                return Codigo == "__MANUAL__";
            }
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}