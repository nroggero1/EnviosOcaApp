using EnviosOcaApp.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EnviosOcaApp.Utils
{
    public static class OficinaSucursalFilter
    {
        public static List<OficinaSucursal> FiltrarPorEmpresa(
            IEnumerable<OficinaSucursal> oficinas,
            string? empresa)
        {
            if (string.IsNullOrWhiteSpace(empresa))
                return new List<OficinaSucursal>();

            CompareInfo comparador = CultureInfo.CurrentCulture.CompareInfo;
            const CompareOptions opciones =
                CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace;

            return oficinas
                .Where(oficina =>
                    oficina.Activa
                    && comparador.Compare(
                        oficina.Empresa,
                        empresa,
                        opciones) == 0)
                .ToList();
        }

        public static bool Matches(OficinaSucursal oficina, string texto)
        {
            string[] terminos = texto.Split(
                (char[]?)null,
                StringSplitOptions.RemoveEmptyEntries
                    | StringSplitOptions.TrimEntries);
            string datosOficina = string.Join(
                " ",
                oficina.Empresa,
                oficina.EmpresaAbreviada,
                oficina.Nombre,
                oficina.Codigo,
                oficina.Calle,
                oficina.Numero,
                oficina.Piso,
                oficina.DireccionCompleta,
                oficina.Localidad,
                oficina.Provincia,
                oficina.CP);
            CompareInfo comparador = CultureInfo.CurrentCulture.CompareInfo;
            const CompareOptions opciones =
                CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace;

            return terminos.All(termino =>
                comparador.IndexOf(datosOficina, termino, opciones) >= 0);
        }
    }
}
