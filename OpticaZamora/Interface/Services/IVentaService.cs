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
        IEnumerable<Venta> GetRetornarListaVentas(string tit);
        void AddVenta(Sale sale, List<DetalleVenta> Detalles);
        List<Sale> Ventas();
    }
}
