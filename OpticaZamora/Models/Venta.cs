using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class Venta
    {

        public string IdVenta { get; set; } = Guid.NewGuid().ToString(); ///Listo
        public string NumeroVneta { get; set; } = "COD" + Codigo(); ///Listo
        public DateTime Fecha { get; set; }  ///Listo

        public Producto Producto { get; set; }
        public string ProductoId { get; set; }///Listo
        public string NombreProducto { get; set; }///Listo
        public string CategoriaProducto { get; set; }///Listo

        public Paciente Paciente { get; set; }
        public string PacienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }

        public string Total { get; set; }

        public EstadoPago EstadoPago { get; set; }

        public static string Codigo()
        {
            Random rdn = new Random();
            string a = Convert.ToString(rdn.Next(10000, 100000));
            string b = Convert.ToString(rdn.Next(10000, 100000));
            return a.ToString() + b.ToString();
        }
    }
}