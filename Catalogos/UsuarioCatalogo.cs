using Microsoft.EntityFrameworkCore;
using ProyectoBBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoBBDD.Catalogos
{
    public class UsuarioCatalogo
    {
        TiendaContext context = new();
        Regex regular;
        string patroncorreo = @"[a-zA-Z0-9._]+@(gmail|outlook|yahoo|hotmail|itesrc|rcarbonifera)+\.(com|org|edu|tecnm)+(\.[a-z]{2})?";
        public IEnumerable<Usuarios> GetUsuarios()
        {
            return context.Usuarios.OrderBy(x=>x.Nombre);
        }
        public IEnumerable<Usuarios> GetUsuarioId(int id)
        {
            return context.Usuarios.Where(x => x.Id == id);
        }
        public Usuarios? GetUsuario(string correo)
        {
            return context.Usuarios.FirstOrDefault(x => x.Correo == correo);
        }

        public int spIniciarSesion(string correo, string password)
        {
            string cadena = $"select fnIniciarSesion('{correo}','{password}')";
            var y = ((IEnumerable<int>)context.Database.SqlQueryRaw<int>(cadena, correo, password)
                .AsAsyncEnumerable<int>()).First();
            if (y == 1)
            {
                var us = context.Usuarios.Include(x => x.IdrolNavigation).FirstOrDefault(x => x.Correo == correo);
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
        public void Agregar(Usuarios u)
        {
            context.Add(u);
            context.SaveChanges();
        }
        public void Eliminar(Usuarios u)
        {
            context.Remove(u);
            context.SaveChanges();
        }
        public void Editar(Usuarios u)
        {
            context.Update(u);
            context.SaveChanges();
            //context.Entry(u).Reload();
        }
        public bool Validar(Usuarios u, out List<string> errores)
        {


            errores = new List<string>();
            if (string.IsNullOrWhiteSpace(u.Nombre))
                errores.Add("No has introducido el nombre.");
            if (u.Nombre != null && u.Nombre.Length > 80)
                errores.Add("Los caracteres permitidos para el nombre es de 80.");
            if (string.IsNullOrWhiteSpace(u.Contrasena))
                errores.Add("Debes ingresar una contrasena.");
            if (u.Contrasena != null && u.Contrasena.Length > 10)
            {

                errores.Add("La contrasena tiene un maximo 10 caracteres");

            }

            if (string.IsNullOrWhiteSpace(u.Correo))
                errores.Add("Debes ingresar un correo.");
            if (u.Correo != null)
            {
                regular = new Regex(patroncorreo);
                if (!regular.IsMatch(u.Correo))
                    errores.Add("Verifica que el correo no contenga " +
                        "caracteres especiales y que el " +
                        "dominio sea uno de estos: " +
                        "gmail,outlook,yahoo,hotmail,itesrc,rcarbonifera y " +
                        "con un dominio de nivel superior como:com,org,edu,tecnm");

                }
                if (context.Usuarios.Any(x => x.Correo == u.Correo && x.Id != u.Id))
                    errores.Add("El correo ya esta registrado a otro usuario.");
                if (errores.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
