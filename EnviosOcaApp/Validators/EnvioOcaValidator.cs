using EnviosOcaApp.Models;

namespace EnviosOcaApp.Validators
{
    public static class EnvioOcaValidator
    {
        public static List<string> ValidarRemitente(
            EmpresaOca empresa,
            string? apellido,
            string? nombre)
        {
            var errores = new List<string>();

            AgregarErrorCampoObligatorio(errores, "Número de cuenta OCA", empresa.NroCuenta, 10);
            AgregarErrorCampoObligatorio(errores, "Centro de costo", empresa.CentroCosto, 10);

            if (string.IsNullOrWhiteSpace(apellido))
                errores.Add("Debe completar el apellido del remitente.");

            if (string.IsNullOrWhiteSpace(nombre))
                errores.Add("Debe completar el nombre del remitente.");

            return errores;
        }

        public static List<string> ValidarOrigen(
            (string Calle, string Numero, string Piso, string Localidad, string Provincia, string CP) origen)
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(origen.Calle))
                errores.Add("Calle de origen: es obligatorio.");
            AgregarErrorCampoObligatorio(errores, "Número de origen", origen.Numero, 5);
            AgregarErrorCampoObligatorio(errores, "Código postal de origen", origen.CP, 4);
            AgregarErrorCampoObligatorio(errores, "Localidad de origen", origen.Localidad, 30);
            AgregarErrorCampoObligatorio(errores, "Provincia de origen", origen.Provincia, 30);

            return errores;
        }

        public static List<string> ValidarEnvio(EnvioOca envio)
        {
            var errores = new List<string>();

            AgregarErrorCampoObligatorio(errores, "Remito", envio.Remito, 30);

            string nombreCompleto = envio.NombreDestinatario?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombreCompleto))
            {
                errores.Add("Nombre/Razón social del destinatario: es obligatorio.");
            }
            else
            {
                string apellido = nombreCompleto;
                string nombre = "Destinatario";
                if (nombreCompleto.Contains(' '))
                {
                    var partes = nombreCompleto.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    apellido = partes[0].Trim();
                    nombre = partes[1].Trim();
                }

                AgregarErrorCampoObligatorio(errores, "Apellido del destinatario", apellido, 30);
                AgregarErrorCampoObligatorio(errores, "Nombre del destinatario", nombre, 30);
            }

            AgregarErrorCampoObligatorio(errores, "Calle del destinatario", envio.Calle, 30);
            AgregarErrorCampoObligatorio(errores, "Número del destinatario", envio.Numero, 5);
            AgregarErrorCampoObligatorio(errores, "Localidad del destinatario", envio.Localidad, 30);
            AgregarErrorCampoObligatorio(errores, "Provincia del destinatario", envio.Provincia, 30);
            AgregarErrorCampoObligatorio(errores, "Código postal del destinatario", envio.CP, 4);

            if (!string.IsNullOrWhiteSpace(envio.Piso) && envio.Piso.Trim().Length > 6)
                errores.Add("Piso del destinatario: no puede superar 6 caracteres.");

            if (!string.IsNullOrWhiteSpace(envio.Telefono) && envio.Telefono.Trim().Length > 30)
                errores.Add("Teléfono del destinatario: no puede superar 30 caracteres.");

            if (!string.IsNullOrWhiteSpace(envio.Email) && envio.Email.Trim().Length > 100)
                errores.Add("Correo electrónico del destinatario: no puede superar 100 caracteres.");

            if (envio.Paquetes == null || envio.Paquetes.Count == 0)
                errores.Add("El envío debe contener al menos un bulto.");

            return errores;
        }

        private static void AgregarErrorCampoObligatorio(
            List<string> errores,
            string campo,
            string? valor,
            int longitudMaxima)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                errores.Add($"{campo}: es obligatorio.");
            }
            else if (valor.Trim().Length > longitudMaxima)
            {
                errores.Add($"{campo}: no puede superar {longitudMaxima} caracteres.");
            }
        }
    }
}
