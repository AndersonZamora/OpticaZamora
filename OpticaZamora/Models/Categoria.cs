using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class Categoria
    {
        public string IdCategoria { get; set; } = Guid.NewGuid().ToString();
        public string Nombre { get; set; }

        //Relacion

    }
}