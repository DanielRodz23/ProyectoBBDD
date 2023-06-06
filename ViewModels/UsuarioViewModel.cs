using ProyectoBBDD.Catalogos;
using ProyectoBBDD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBBDD.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        public Usuarios Usuario { get; set; } = new Usuarios();
        UsuarioCatalogo usuarioCatalogo = new UsuarioCatalogo();

        public UsuarioViewModel()
        {
            var x = usuarioCatalogo.GetUsuarios().FirstOrDefault();
            if (x != null)
            {
                Usuario = x;
            }
            Actualizar();
        }
        private void Actualizar(string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
