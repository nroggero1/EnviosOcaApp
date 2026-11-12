using System.Collections.Generic;

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

                var partes = new List<string>();
                if (!string.IsNullOrWhiteSpace(domicilio))
                    partes.Add(domicilio);
                if (!string.IsNullOrWhiteSpace(Localidad))
                    partes.Add(Localidad);
                if (!string.IsNullOrWhiteSpace(Provincia))
                    partes.Add(Provincia);
                if (!string.IsNullOrWhiteSpace(CP))
                    partes.Add($"CP {CP}");

                return string.Join(" - ", partes);
            }
        }

        public string DisplayCombo
        {
            get
            {
                if (Codigo == "__SELECCIONAR__" || EsIngresoManual)
                    return Nombre;

                string empresa = string.IsNullOrWhiteSpace(EmpresaAbreviada)
                    ? string.Empty
                    : $"[{EmpresaAbreviada}] ";
                string codigo = string.IsNullOrWhiteSpace(Codigo)
                    ? string.Empty
                    : $" ({Codigo})";
                string direccion = string.IsNullOrWhiteSpace(DireccionCompleta)
                    ? string.Empty
                    : $" - {DireccionCompleta}";

                return $"{empresa}{Nombre}{codigo}{direccion}";
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