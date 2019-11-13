using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB.Map
{
    public class MapExpediente : EntityTypeConfiguration<Expediente>
    {
        public MapExpediente()
        {
            ToTable("Expediente");
            HasKey(e => e.IdExpediente);

            HasRequired(a => a.Paciente)
                .WithMany()
                .HasForeignKey(a => a.PacienteId);

            HasRequired(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId);
        }
    }
}