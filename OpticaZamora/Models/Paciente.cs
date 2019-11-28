using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Models
{
    public class Paciente
    {
        public string IdPaciente { get; set; } = Guid.NewGuid().ToString();
        public TipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Edad { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public Genero TipoGenero { get; set; }
        public string Celular { get; set; }
        //Relacion
    }
}