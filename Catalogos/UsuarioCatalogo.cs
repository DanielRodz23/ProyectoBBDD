using Microsoft.EntityFrameworkCore;
using ProyectoBBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
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
        public Usuarios? GetUsuario(string nombre)
        {
            return context.Usuarios.FirstOrDefault(x => x.Nombre == nombre);
        }

        public int spIniciarSesion(string nombre, string password)
        {
            string cadena = $"select fnIniciarSesion('{nombre}','{password}')";
            var y = ((IEnumerable<int>)context.Database.SqlQueryRaw<int>(cadena, nombre, password)
                .AsAsyncEnumerable<int>()).First();
            if (y == 1)
            {
                var us = context.Usuarios.Include(x => x.IdrolNavigation).FirstOrDefault(x => x.Nombre == nombre);
                if (us != null)
                    EstablecerTipoUsuario(us);
            }
            return y;
        }

        private void EstablecerTipoUsuario(Usuarios us)
        {
            GenericIdentity user = new GenericIdentity(us.Nombre);
            if (us != null)
            {
                string[] roles = new string[] { us.IdrolNavigation.Nombre };
                GenericPrincipal usprincipal = new GenericPrincipal(user, roles);
                Thread.CurrentPrincipal = usprincipal;
            }
        }
    }
}
