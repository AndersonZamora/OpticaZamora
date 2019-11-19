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
        Boolean AddProducto(Producto producto);
        Producto ProductoModificar(string IdProducto);
        Boolean UpdateProducto(Producto producto);
    }
}
