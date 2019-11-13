using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class Sys
    {
        public string IdUsuario { get; set; } = Guid.NewGuid().ToString();
        //Datos Basicos
        public string Name{ get; set; }
        public string Surname { get; set; }
        public TipoDocumento TypeDocument { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime DateBirth { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }

        //Datos de Usuario
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}