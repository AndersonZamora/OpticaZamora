using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class Sale
    {
        public string IdSALE { get; set; } = Guid.NewGuid().ToString();
        public Paciente Paciente { get; set; }
        public string PacienteId { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public string Total { get; set; }
    }
}