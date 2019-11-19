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
        private OpticaContext Context;
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
        public List<Sale> Ventas()
        {
            var ventas = Context.Sales.Include(a => a.Paciente).AsQueryable();
            return ventas.ToList();
        }
    }
}