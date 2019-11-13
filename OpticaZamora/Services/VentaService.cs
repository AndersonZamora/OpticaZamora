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
        public VentaService()
        {
            Context = new OpticaContext();
        }

        public void AddVenta(Sale sale, List<DetalleVenta> Detalles)
        {
            foreach (var dvent in Detalles)
            {
                dvent.VentaId = sale.IdSALE;
            }

            Context.DetalleVentas.AddRange(Detalles);
            Context.Sales.Add(sale);
            Context.SaveChanges();
        }

        //[Authorize]
        //public IEnumerable<Venta> GetRetornarListaVentas(string tit)
        //{
        //    var   query = from p in Context.Ventas.Include(o => o.Producto.Categoria).Include(o => o.Paciente)
        //                    select p;
        //    return query;
        //}
        public List<Sale> Ventas()
        {
            var ventas = Context.Sales.Include(a => a.Paciente).AsQueryable();
            return ventas.ToList();
        }
    }
}