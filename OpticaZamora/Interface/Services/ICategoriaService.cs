using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetRetornarListaCategoria(string tit);
        Boolean AddCategoria(Categoria categoria);
        Categoria CategoriaModificar(string IdCategoria);
        Boolean UpdateCategoria(Categoria categoria);
        void logOff();


    }
}
