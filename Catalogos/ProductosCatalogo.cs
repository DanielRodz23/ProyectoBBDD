using Microsoft.EntityFrameworkCore.Infrastructure;
using ProyectoBBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoBBDD.Catalogos
{
    public class ProductosCatalogo
    {
        TiendaContext context = new TiendaContext();
        Regex regular;
        string patronsku = @"[0-9]*$";
        public IEnumerable<Productos> GetProductos()
        {
            return context.Productos.OrderBy(x => x.Nombre);
        }
        public void Agregar(Productos p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void Eliminar(Productos p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
        public void Editar(Productos p)
        {
            context.Update(p);
            context.SaveChanges();
            //context.Entry(u).Reload();
        }
        public bool Validar(Productos p, out List<string> errores)
        {
            regular=new Regex(patronsku);

            errores = new List<string>();
            if (p.Sku == 0)
                errores.Add("No has ingresado un SKU");
            if (p.Sku != 0 && !regular.IsMatch(p.Sku.ToString()))
                errores.Add("El SKu debe estar compuesto solo por numeros.");
            if (string.IsNullOrWhiteSpace(p.Nombre))
                errores.Add("No has introducido el nombre.");
            if (p.Nombre != null && p.Nombre.Length > 80)
                errores.Add("Los caracteres permitidos para el nombre es de 80.");
            if (p.Precio == null)
                errores.Add("Debe ingresar un Precio.");
            if (p.Precio != null && p.Precio > 9999.99m)
                errores.Add("El Precio que ingreso es demasiado grande");
            if (p.Descripcion == null)
                errores.Add("Debe ingresar una descripcion");
            if (p.Imagen == null)
                errores.Add("Debe ingresar una imagen de producto");


            //if (string.IsNullOrWhiteSpace(u.Correo))
            //    errores.Add("Debes ingresar un correo.");
            //if (u.Correo != null)
            //{
            //    regular = new Regex(patroncorreo);
            //    if (!regular.IsMatch(u.Correo))
            //        errores.Add("Verifica que el correo no contenga " +
            //            "caracteres especiales y que el " +
            //            "dominio sea uno de estos: " +
            //            "gmail,outlook,yahoo,hotmail,itesrc,rcarbonifera y " +
            //            "con un dominio de nivel superior como:com,org,edu,tecnm");

            ////}
            //if (context.Usuarios.Any(x => x.Correo == u.Correo && x.Id != u.Id))
            //    errores.Add("El correo ya esta registrado a otro usuario.");
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
