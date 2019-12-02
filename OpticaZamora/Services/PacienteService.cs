using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace OpticaZamora.Services
{
    public class PacienteService : IPacienteService
    {
        readonly OpticaContext Context;
        public PacienteService(OpticaContext Context)
        {
            this.Context = Context;
        }
        [Authorize]
        public IEnumerable<Paciente> GetRetornarListasPaciente(string titulo)
        {
            var query = from p in Context.Pacientes
                        select p;
            if (!string.IsNullOrEmpty(titulo))
            {
                query = from p in query
                        where p.Nombres.ToUpper().Contains(titulo.ToUpper()) ||
                              p.Apellidos.ToUpper().Contains(titulo.ToUpper()) ||
                              p.NumeroDocumento.ToUpper().Contains(titulo.ToUpper())

                        select p;
            }
            return query;
        }
        [Authorize]
        public bool AddPaciente(Paciente paciente)
        {
            Context.Pacientes.Add(paciente);
            Context.SaveChanges();
            return true;
        }
        [Authorize]
        public Paciente PacienteModificar(string IdPaciente)
        {
            Paciente paciente = null;
            try
            {
                paciente = Context.Pacientes.Where(p => p.IdPaciente == IdPaciente).First();
                return paciente;
            }
            catch (Exception ex) {
                ex.ToString();
            }
            return paciente;
        }
        [Authorize]
        public  bool UpdatePaciente(Paciente paciente)
        {
            var PacienteDB = Context.Pacientes.Where(o => o.IdPaciente == paciente.IdPaciente).First();

            PacienteDB.TipoDocumento = paciente.TipoDocumento;
            PacienteDB.NumeroDocumento = paciente.NumeroDocumento;
            PacienteDB.Nombres = paciente.Nombres;
            PacienteDB.Apellidos = paciente.Apellidos;
            PacienteDB.Edad = paciente.Edad;
            PacienteDB.Correo = paciente.Correo;
            PacienteDB.Direccion = paciente.Direccion;
            PacienteDB.TipoGenero = paciente.TipoGenero;
            PacienteDB.Celular = paciente.Celular;
            Context.SaveChanges();
            return true;
        }
        [Authorize]
        public void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}