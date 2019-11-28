using OpticaZamora.DB.Map;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpticaZamora.DB
{
    public class OpticaContext : DbContext
    {

        public virtual DbSet<Sys> Syss { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Doctor> Doctores { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Expediente> Expediente { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }
 
        public virtual DbSet<Sale> Sales { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new MapSys());
            modelBuilder.Configurations.Add(new MapCategoria());
            modelBuilder.Configurations.Add(new MapDoctor());
            modelBuilder.Configurations.Add(new MapPaciente());
            modelBuilder.Configurations.Add(new MapProducto());
            modelBuilder.Configurations.Add(new MapExpediente());
            modelBuilder.Configurations.Add(new MapDetalleVenta());
            modelBuilder.Configurations.Add(new MapSale());
        }
    }
}