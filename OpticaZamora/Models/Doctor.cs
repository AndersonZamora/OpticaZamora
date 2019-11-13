using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class Doctor
    {
        public string IdDoctor { get; set; } = Guid.NewGuid().ToString();
        public string Codigo { get; set; } 
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Celular { get; set; }
        public string Especialidad { get; set; }
        //Datos de la cuenta
        public string Username { get; set; }
        public string Password { get; set; }
        public Estado Estado { get; set; }
        //Relacion

    }
}