using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoBBDD.Catalogos;
using ProyectoBBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProyectoBBDD.ViewModels
{
    public class PrincipalViewModel
    {
        public Usuarios? Usuario { get; set; }
        public UserControl vista { get; set; }
        public string Modo { get; set; }
        //LoginView view;
        public string Error { get; set; }
        public ICommand IniciarSesionCommand { get; set; }
        public ICommand CerrarSesionCommand { get; set; }

        public ICommand VerRegistrarUsuarioCommand { get; set; }
        public ICommand RegistrarUsuarioCommand { get; set; }
        UsuarioCatalogo catalagous = new UsuarioCatalogo();
        public PrincipalViewModel()
        {
            CerrarSesionCommand = new RelayCommand(CerrarSesion);
            IniciarSesionCommand = new RelayCommand(IniciarSesion);

            VerRegistrarUsuarioCommand = new RelayCommand(VerRegistrarUsuario);
            RegistrarUsuarioCommand = new RelayCommand(RegistrarUsuario);
            Usuario = new();
            //view = new LoginView()
            //{
            //    DataContext = this
            //};

            //Vista = view;
            //Actualizar();
        }

        private void RegistrarUsuario()
        {
                //if (Usuario != null)
                //{
                //    if (catalagous.Validar(Usuario, out List<string> errores))
                //    {
                //        catalagous.Agregar(Usuario);
                //        EnviarCorreo();
                //        Usuario = new();
                //        vista = view;
                //        Actualizar();
                //    }
                //    else
                //    {

                //        foreach (var item in errores)
                //        {
                //            Error = $"{Error} {item} {Environment.NewLine}";
                //        }
                //        Actualizar();
                //    }
                //    Error = "";

                //}

            
        }

        private void CerrarSesion()
        {
            throw new NotImplementedException();
        }

        private void IniciarSesion()
        {
            throw new NotImplementedException();
        }

        private void VerRegistrarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
