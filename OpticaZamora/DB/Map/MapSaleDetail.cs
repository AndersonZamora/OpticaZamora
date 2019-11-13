using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB.Map
{
    public class MapSaleDetail : EntityTypeConfiguration<SaleDetail>
    {
        public MapSaleDetail()
        {
            ToTable("SaleDetail");
            HasKey(sd => sd.IdSaleDatail);

            HasRequired(v => v.Sale)
                .WithMany()
                .HasForeignKey(a => a.SaleId);

            HasRequired(p => p.Producto)
                .WithMany()
                .HasForeignKey(p => p.ProductoId);
        }
    }
}