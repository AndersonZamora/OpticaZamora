using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB.Map
{
    public class MapCategoria : EntityTypeConfiguration<Categoria>
    {
        public MapCategoria()
        {
            ToTable("Categoria");
            HasKey(c => c.IdCategoria);

        }
    }
}