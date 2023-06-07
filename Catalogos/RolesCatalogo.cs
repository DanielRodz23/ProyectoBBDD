using ProyectoBBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBBDD.Catalogos
{
    public class RolesCatalogo
    {
        TiendaContext context = new TiendaContext();
        public IEnumerable<Roles> Roles()
        {
            return context.Roles.OrderBy(x => x.Nombre);
        }
    }
}
