using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB.Map
{
    public class MapSale : EntityTypeConfiguration<Sale>
    {
        public MapSale()
        {
            ToTable("Sale");
            HasKey(s => s.IdSALE);

            HasRequired(a => a.Paciente)
                .WithMany()
                .HasForeignKey(a => a.PacienteId);
        }
    }
}
