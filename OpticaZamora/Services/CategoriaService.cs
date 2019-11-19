using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OpticaZamora.Services
{
    public class CategoriaService : ICategoriaService
    {

        private OpticaContext Context;
       
        public CategoriaService(OpticaContext Context)
        {
            this.Context = Context;
        }
        [Authorize]
        public bool AddCategoria(Categoria categoria)
        {
            Context.Categorias.Add(categoria);
            Context.SaveChanges();
            return true;
        }
        [Authorize]
        public Categoria CategoriaModificar(string IdCategoria)
        {
            Categoria categorias = null;
            try
            {
                categorias = Context.Categorias.Where(o => o.IdCategoria == IdCategoria).First();
                return categorias;
            }
            catch (Exception) { }
            return categorias;
        }
        [Authorize]
        public IEnumerable<Categoria> GetRetornarListaCategoria(string tit)
        {
            var query = from p in Context.Categorias
                        select p;

            if (!string.IsNullOrEmpty(tit))
            {
                query = from p in query
                        where p.Nombre.ToUpper().Contains(tit.ToUpper())
                        select p;
            }
            return query;
        }
        [Authorize]
        [Authorize]
        public bool UpdateCategoria(Categoria categoria)
        {
            var CategoriaBD = Context.Categorias.Where(o => o.IdCategoria == categoria.IdCategoria).First();

            CategoriaBD.Nombre = categoria.Nombre;
            Context.SaveChanges();
            return true;
        }
        public void logOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}