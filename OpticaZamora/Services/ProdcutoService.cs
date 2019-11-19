using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace OpticaZamora.Services
{
    public class ProdcutoService : IProdcutoService
    {
        private OpticaContext Context;
        public ProdcutoService(OpticaContext Context)
        {
            this.Context = Context;
        }
        [Authorize]
        public bool AddProducto(Producto producto)
        {
            Context.Productos.Add(producto);
            Context.SaveChanges();
            return true;
        }
        [Authorize]
        public IEnumerable<Producto> GetRetornarListaProducto(string criterio)
        {
            var query = Context.Productos.Include(a => a.Categoria).AsQueryable();
            if (!string.IsNullOrEmpty(criterio))
                query = from p in query
                        where p.Nombre.ToUpper().Contains(criterio.ToUpper())
                        select p;

            return query.ToList();
        }
        [Authorize]
        public Producto ProductoModificar(string IdProducto)
        {
            Producto productos = null; 
            try
            {
                productos = Context.Productos.Where(o => o.IdProducto == IdProducto).First();
                return productos;
            }
            catch (Exception) { }
            return productos;
        }
        [Authorize]
        public bool UpdateProducto(Producto producto)
        {
            var ProductoBD = Context.Productos.Where(o => o.IdProducto == producto.IdProducto).First();

            ProductoBD.CodigoProducto = producto.CodigoProducto;
            ProductoBD.Nombre = producto.Nombre;
            ProductoBD.Precio = producto.Precio;
            ProductoBD.Stock = producto.Stock;
            ProductoBD.Descripcion = producto.Descripcion;
            ProductoBD.CategoriaId = producto.CategoriaId;
            Context.SaveChanges();
            return true;
        }
    }
}