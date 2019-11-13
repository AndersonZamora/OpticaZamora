using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class Producto
    {
        public string IdProducto { get; set; } = Guid.NewGuid().ToString();
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        //Realacion

        public Categoria Categoria { get; set; }
        public string CategoriaId { get; set; }  
    }

}