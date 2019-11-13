using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB.Map
{
    public class MapVenta : EntityTypeConfiguration<Venta>
    {
        public MapVenta()
        {
            ToTable("Venta");
            HasKey(a => a.IdVenta);

            HasRequired(a => a.Producto)
                .WithMany()
                .HasForeignKey(a => a.ProductoId);
            HasRequired(a => a.Paciente)
                .WithMany()
                .HasForeignKey(a => a.PacienteId);
        }
    }
}