namespace EnviosOcaApp.Models
{
    public class TipoBultoOca
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }
        public decimal PesoMaximo { get; set; }
        public bool EsPersonalizado { get; set; }

        public override string ToString()
        {
            if (EsPersonalizado)
                return $"{Id}- OTRO (INGRESAR DIMENSIONES Y PESO)";

            return $"{Id}- {Nombre} / {Alto:0.#}*{Ancho:0.#}*{Largo:0.#} / {PesoMaximo:0.#}KG";
        }

        public static List<TipoBultoOca> ObtenerTiposPredefinidos()
        {
            return new List<TipoBultoOca>
            {
                new TipoBultoOca { Id = 1, Nombre = "EXTRA CHICO", Alto = 15, Ancho = 10, Largo = 10, PesoMaximo = 2, EsPersonalizado = false },
                new TipoBultoOca { Id = 2, Nombre = "CHICA", Alto = 20, Ancho = 15, Largo = 10, PesoMaximo = 5, EsPersonalizado = false },
                new TipoBultoOca { Id = 3, Nombre = "MEDIANA", Alto = 25, Ancho = 20, Largo = 15, PesoMaximo = 10, EsPersonalizado = false },
                new TipoBultoOca { Id = 4, Nombre = "GRANDE", Alto = 30, Ancho = 25, Largo = 20, PesoMaximo = 15, EsPersonalizado = false },
                new TipoBultoOca { Id = 5, Nombre = "EXTRA GRANDE", Alto = 40, Ancho = 30, Largo = 25, PesoMaximo = 20, EsPersonalizado = false },
                new TipoBultoOca { Id = 6, Nombre = "JUMBO", Alto = 50, Ancho = 40, Largo = 30, PesoMaximo = 25, EsPersonalizado = false },
                new TipoBultoOca { Id = 7, Nombre = "OTRO", Alto = 0, Ancho = 0, Largo = 0, PesoMaximo = 0, EsPersonalizado = true }
            };
        }
    }
}
