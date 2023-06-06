using ProyectoBBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBBDD.Catalogos
{
    public class UsuarioCatalogo
    {
        TiendaContext context = new();
        public IEnumerable<Usuarios> GetUsuarios()
        {
            return context.Usuarios.OrderBy(x=>x.Nombre);
        }
    }
}
