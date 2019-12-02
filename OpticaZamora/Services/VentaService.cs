using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace OpticaZamora.Services
{
    public class VentaService : IVentaService
    {
        readonly OpticaContext Context;
        public VentaService(OpticaContext Context)
        {
            this.Context = Context;
        }
        public bool AddVenta(Sale sale, List<DetalleVenta> Detalles)
        {
            if(sale.IdSALE == null)
                return false;
            foreach (var dvent in Detalles)
            {
                dvent.VentaId = sale.IdSALE;
            }
            Context.DetalleVentas.AddRange(Detalles);
            Context.Sales.Add(sale);
            Context.SaveChanges();
            return true;
        }

        public IEnumerable<Producto> GetProductosDeBaseDeDatos(string id)
        {
            var productos = Context.Productos.Include(o => o.Categoria).AsQueryable();
            return productos.Where(o => o.IdProducto == id).ToList();
        }

        public List<Paciente> Pacientes()
        {
            return Context.Pacientes.ToList();
        }

        public List<Producto> Productos()
        {
            var productos = Context.Productos.Include(o => o.Categoria).ToList();
            return productos;
        }

        public List<Sale> Ventas()
        {
            var ventas = Context.Sales.Include(a => a.Paciente).AsQueryable();
            return ventas.ToList();
        }
    }
}