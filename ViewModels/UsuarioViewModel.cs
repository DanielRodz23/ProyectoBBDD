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
        UsuarioCatalogo usuarioCatalogo { get; set; }

        public UsuarioViewModel()
        {
            Usuario = usuarioCatalogo.GetUsuarios().FirstOrDefault();
        }
        private void Actualizar(string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
