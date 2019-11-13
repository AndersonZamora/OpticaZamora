using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB.Map
{
    public class MapPaciente : EntityTypeConfiguration<Paciente>
    {
        public MapPaciente()
        {
            ToTable("Paciente");
            HasKey(p => p.IdPaciente);
        }
    }
}