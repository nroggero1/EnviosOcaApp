using System.Collections.Generic;

namespace EnviosOcaApp.Models
{
    // Representa la respuesta global de la API de OCA
    public class OcaResponse
    {
        public bool TieneErrores { get; set; }
        public string MensajeError { get; set; } = string.Empty;

        // Número principal del lote devuelto por OCA
        public string CodigoOperacion { get; set; } = string.Empty; 
        
        // Detalle de cada guía/etiqueta generada
        public List<OcaEnvioGenerado> EnviosGenerados { get; set; } = new List<OcaEnvioGenerado>();
    }

    // Representa cada etiqueta devuelta en el XML
    public class OcaEnvioGenerado
    {
        public string NumeroRemito { get; set; } = string.Empty; // Nuestro ID interno enviado
        public string NumeroEnvio { get; set; } = string.Empty;  // El Nro de Tracking de OCA (Ej: 34650000...)
    }
}
