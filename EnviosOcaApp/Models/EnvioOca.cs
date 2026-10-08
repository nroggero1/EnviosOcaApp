using System.Collections.Generic;

namespace EnviosOcaApp.Models
{
    public class EnvioOca
    {
        public string Remito { get; set; } = string.Empty;
        public string NombreDestinatario { get; set; } = string.Empty;
        public string Calle { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Piso { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string CP { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int IdOperativa { get; set; }

        // Lista de paquetes (bultos) que corresponden exclusivamente a este envío
        public List<PaqueteOca> Paquetes { get; set; } = new List<PaqueteOca>();

        // Propiedades de Solo Lectura para mostrar cómodamente en la grilla maestra del Lote
        public string DestinatarioResumen => $"{NombreDestinatario} ({Localidad}, {Provincia})";
        public int BultosTotales => Paquetes.Count;
    }
}
