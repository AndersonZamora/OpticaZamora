using OpticaZamora.DB;
using OpticaZamora.Interface.List;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.SessionState;

namespace OpticaZamora.List
{
    public class SessionList : ISessionList
    {
        HttpSessionState Session;
        private OpticaContext Context;
        public dynamic ViewBag;
        public SessionList()
        {
            Context = new OpticaContext();
        }
        public void SetListaSucursales()
        {
            //var sucursales = Context.Sucursals;
            //Session = HttpContext.Current.Session;
            //Session["Sucursal"] = new SelectList(sucursales, "IdSucursal", "Nombre");
        }

        public void SetListaSucursalesBi()
        {
            var pacientes = Context.Pacientes;

            Session = HttpContext.Current.Session;
            Session["Pacientes"] = new SelectList(pacientes, "IdPaciente", "Nombres");
        }

        public List<Producto> GetProductosDeBaseDeDatos()
        {
            var prodcutos = Context.Productos.Include(a => a.Categoria).ToList();
            return prodcutos;
        }

        public List<Doctor> SetListaDocotores()
        {
            var doctores = Context.Doctores.ToList();
            return doctores;
        }

        public List<Paciente> SetListaPaciente(string IdPaciente)
        {
            var paciente = Context.Pacientes.Where(o => o.IdPaciente == IdPaciente).ToList();
            return paciente;
        }

        public List<Expediente> GetExpedientes(string IdPaciente)
        {
            var expediente = Context.Expediente.Where(o => o.PacienteId == IdPaciente).Include(o => o.Paciente).Include(o => o.Doctor).ToList();
            return expediente;
        }

        public IEnumerable<Expediente> GetListaExpedientes(string IdPaciente)
        {
            throw new NotImplementedException();
        }
    }
}