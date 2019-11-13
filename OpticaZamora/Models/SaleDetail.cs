using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class SaleDetail
    {
        public string IdSaleDatail { get; set; } = Guid.NewGuid().ToString();
        public Sale Sale { get; set; }
        public string SaleId { get; set; }
        public Producto Producto { get; set; }
        public string ProductoId { get; set; }
        public string Cantidad { get; set; }
    }
}