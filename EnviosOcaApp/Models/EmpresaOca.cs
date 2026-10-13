namespace EnviosOcaApp.Models
{
    public class EmpresaOca
    {
        public string Nombre { get; set; } = string.Empty;
        public string Cuit { get; set; } = string.Empty;
        public string Operativa { get; set; } = string.Empty;
        
        // --- Exigidos por el XML de OCA (Datos "ocultos" para el operador) ---
        public string NroCuenta { get; set; } = string.Empty;
        public string CentroCosto { get; set; } = string.Empty;
        public string CalleOrigen { get; set; } = string.Empty;
        public string NumeroOrigen { get; set; } = string.Empty;
        public string LocalidadOrigen { get; set; } = string.Empty;
        public string ProvinciaOrigen { get; set; } = string.Empty;
        public string CpOrigen { get; set; } = string.Empty;
        public string ContactoOrigen { get; set; } = "CORRESPONSALIA";
        public string Usuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Sobrescribimos ToString para que el ComboBox muestre el Nombre directamente
        public override string ToString()
        {
            return Nombre;
        }
    }
}
