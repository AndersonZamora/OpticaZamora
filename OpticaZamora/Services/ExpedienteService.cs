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
    public class ExpedienteService : IExpedienteService
    {
        private OpticaContext Context;
        public ExpedienteService()
        {
            Context = new OpticaContext();
        }
        [Authorize]
        public void AddAExpediente(Expediente expediente)
        {
            Context.Expediente.Add(expediente);
            expediente.Fecha = DateTime.Now;
            Context.SaveChanges();
        }
        [Authorize]
        public Expediente ExpedientePaciente(string IdExpediente)
        {
            Expediente expediente = null;

            try
            {
                expediente = Context.Expediente.Where(o => o.IdExpediente == IdExpediente).Include(o => o.Paciente).Include(o =>o.Doctor).FirstOrDefault();
                if (expediente == null)
                {
                    return expediente = null;
                }else if (expediente != null)
                {
                    return expediente;
                }

            }
            catch(Exception) { }

            return expediente;

        }

        public Expediente GetListaExp(string Id)
        {

            Expediente expediente = null;
            try
            {
               expediente = Context.Expediente.Where(o => o.PacienteId == Id).Include(a => a.Paciente).FirstOrDefault();
             //   expediente = Context.Expediente.Include(a => a.Paciente).SingleOrDefault(a => a.PacienteId == Id);
                
                if (expediente == null)
                {
                    return expediente = null;
                }
                else if (expediente != null)
                {
                    return expediente;
                }
            }
            catch (Exception) { }

            return expediente;
        }

        [Authorize]
        public List<Expediente> GetListaExpedientes(string Id)
        {
            List<Expediente> expediente = null;

            try
            {
                expediente = Context.Expediente.Where(o => o.PacienteId == Id).ToList();
                if(expediente == null)
                {
                    return expediente = null;
                }else if (expediente != null)
                {
                    return expediente;
                }
            }
            catch(Exception e) { }

            return expediente;
        }
        [Authorize]
        public IEnumerable<Expediente> GetRetornarListaExpedientes(string tit, string criterio)
        {
            Expediente expediente = null;

            var query = from p in Context.Expediente.Include(a => a.Doctor).Include(a => a.Paciente)
                        select p;
            if (!string.IsNullOrEmpty(tit))
            {
                query = from p in query
                        where p.Paciente.Nombres.ToUpper().Contains(tit.ToUpper()) ||
                              p.Paciente.Apellidos.ToUpper().Contains(tit.ToUpper()) ||
                              p.Paciente.NumeroDocumento.ToUpper().Contains(tit.ToUpper()) ||
                              p.CodigoExpediente.ToUpper().Contains(tit.ToUpper()) ||
                              p.Doctor.Nombres.ToUpper().Contains(tit.ToUpper())
                        select p;
            }
            return query;
        }
    }
}