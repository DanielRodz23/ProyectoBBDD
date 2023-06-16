using ProyectoBBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ProyectoBBDD.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ProyectoBBDD.Catalogos
{
    public class RegistrosCatalogo
    {
        TiendaContext context=new TiendaContext();
        public List<Compra> GetRegistros()
        {
            var query = from rc in context.Registrocompras
                        join u in context.Usuarios on rc.IdUsuario equals u.Id
                        join p in context.Productos on rc.IdProducto equals p.Id
                        select new Compra
                        {
                            Usuario = u.Nombre,
                            Producto = p.Nombre,
                            Cantidad = rc.Cantidad
                        };
            return query.ToList();
        }
        public IEnumerable<Registrocompras> Lista()
        {
            return context.Registrocompras.Include(x => x.IdProductoNavigation)
                .ThenInclude(y => y.Registrocompras)
                .ThenInclude(z => z.IdUsuarioNavigation);
        }
        //public IEnumerable<Registrocompras> GetRegistro
    }
}
