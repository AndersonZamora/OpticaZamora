using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface
{
    public interface IVentaService
    {
        bool AddVenta(Sale sale, List<DetalleVenta> Detalles);
        IEnumerable<Producto> GetProductosDeBaseDeDatos(string id);
        List<Paciente> Pacientes();
        List<Producto> Productos();
        List<Sale> Ventas();
    }
}
