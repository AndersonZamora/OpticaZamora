using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface
{
    public interface IProdcutoService
    {
        IEnumerable<Producto> GetRetornarListaProducto(string criterio);
        void AddProducto(Producto producto);
        Producto ProductoModificar(string IdProducto);
        void UpdateProducto(Producto producto);
    }
}
