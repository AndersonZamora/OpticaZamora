using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class DetalleVenta
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string VentaId { get; set; } 
        public string Cantidad { get; set; }
        public string ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoCategoria { get; set; }
        public string ProductoPrecio { get; set; }
        public string Total { get; set; }
    }
}