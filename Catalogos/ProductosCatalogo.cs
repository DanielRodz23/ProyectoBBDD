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
        string patronskuystock = @"[0-9]*$";
        string patronurl = @"^(https?://)?(www\.)?\S+\.(jpg|jpeg|png|gif)$";
        public IEnumerable<Productos> GetProductos()
        {
            return context.Productos.OrderBy(x => x.Nombre);
        }
        public IEnumerable<Productos> GetProductoId(int id) {
            return context.Productos.Where(x=>x.Id == id);
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
            regular=new Regex(patronskuystock);

            errores = new List<string>();
            if (p.Sku == 0)
                errores.Add("No has ingresado un SKU");
            if (p.Sku != 0 && !regular.IsMatch(p.Sku.ToString()))
                errores.Add("El SKu debe estar compuesto solo por numeros.");
            if (string.IsNullOrWhiteSpace(p.Nombre))
                errores.Add("No has introducido el nombre.");
            if (p.Nombre != null && p.Nombre.Length > 80)
                errores.Add("Los caracteres permitidos para el nombre es de 80.");
            if (p.Precio ==0)
                errores.Add("Debe ingresar un Precio.");
            if (p.Precio != 0 && p.Precio > 9999.99m)
                errores.Add("El Precio que ingreso es demasiado grande");
            if (p.Descripcion == null)
                errores.Add("Debe ingresar una descripcion");
            if (p.Imagen == null)
                errores.Add("Debe ingresar una imagen de producto");
            if (p.Imagen != null)
            {
                regular = new Regex(patronurl);
                if (!regular.IsMatch(p.Imagen))
                    errores.Add("Debe ingresar un aurl de imagen valida");
            }
            if (p.Stock == 0)
                errores.Add("Debe ingresar como minimo 1 unidad de stock");
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
