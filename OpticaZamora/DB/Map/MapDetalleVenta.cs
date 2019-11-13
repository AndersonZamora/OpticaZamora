using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB.Map
{
    public class MapDetalleVenta : EntityTypeConfiguration<DetalleVenta>
    {
        public MapDetalleVenta()
        {
            ToTable("DetalleVenta");
            HasKey(dt => dt.Id);
        }
    }
}