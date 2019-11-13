using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB.Map
{
    public class MapDoctor : EntityTypeConfiguration<Doctor>
    {
        public MapDoctor()
        {
            ToTable("Doctor");
            HasKey(d => d.IdDoctor);

        }
    }
}