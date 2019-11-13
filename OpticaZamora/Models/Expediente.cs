using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class Expediente
    {
        public string IdExpediente { get; set; } = Guid.NewGuid().ToString(); ///Listo
        public string CodigoExpediente { get; set; } = "COD" + Codigo(); ///Listo

        public DateTime Fecha { get; set; } = DateTime.Today;
        public string DEsfera { get; set; }
        public string DCilindro { get; set; }
        public string DEje { get; set; }

        public string IEsfera { get; set; }
        public string ICilindro { get; set; }
        public string IEje { get; set; }
        public string Recomendacion { get; set; }

        public string AnchuraTotal { get; set; }
        public string Puente { get; set; }
        public string Calibre { get; set; }
        public string LongitudVarilla { get; set; }
        public Doctor Doctor { get; set; }
        public string DoctorId { get; set; }
        public Paciente Paciente { get; set; }
        public string PacienteId { get; set; }
        public static string Codigo()
        {
            Random rdn = new Random();
            string a = Convert.ToString(rdn.Next(10000, 100000));
            string b = Convert.ToString(rdn.Next(10000, 100000));
            return a.ToString() + b.ToString();
        }
    }
}