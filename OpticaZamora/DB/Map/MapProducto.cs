using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB.Map
{
    public class MapProducto : EntityTypeConfiguration<Producto>
    {
        public MapProducto()
        {
            ToTable("Producto");
            HasKey(p => p.IdProducto);

            HasRequired(s => s.Categoria)
                .WithMany()
                .HasForeignKey(c => c.CategoriaId);
        }
    }
}