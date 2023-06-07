using GalaSoft.MvvmLight.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoBBDD.Catalogos;
using ProyectoBBDD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProyectoBBDD.ViewModels
{
    public class PrincipalViewModel: INotifyPropertyChanged
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
            if (Usuario != null)
            {
                if (catalagous.Validar(Usuario, out List<string> errores))
                {
                    catalagous.Agregar(Usuario);
                   
                    Usuario = new();
                  
                    Actualizar();
                }
                else
                {

                    foreach (var item in errores)
                    {
                        Error = $"{Error} {item} {Environment.NewLine}";
                    }
                    Actualizar();
                }
                Error = "";

            }


        }

        private void CerrarSesion()
        {
            Usuario = new();
            
            Actualizar();
        }

        private void IniciarSesion()
        {
            if (Usuario != null)
            {
                var inicio = catalagous.spIniciarSesion(Usuario.Nombre, Usuario.Contrasena);
                if (inicio == 1)
                {
                    var usuario = catalagous.GetUsuario(Usuario.Nombre);
                    Usuario = usuario;
                    if (Thread.CurrentPrincipal != null)
                    {
                        if (Thread.CurrentPrincipal.IsInRole("Administrador"))
                            AccionesUsuarioAdministrador();
                        if (Thread.CurrentPrincipal.IsInRole("Cliente"))
                            AccionesUsuarioCliente();
                    }
                    //Vista = new UsuariosView();
                    //Actualizar();
                }
                else if (inicio == 2)
                {
                    Error = "Usuario no encontrado";
                }
                else
                {
                    Error = "Contraseña incorrecta";
                }

                Actualizar();
                Error = "";
            }
        }
        [Authorize(Roles = "Cliente")]
        private void AccionesUsuarioCliente()
        {
            throw new NotImplementedException();
        }
        [Authorize(Roles = "Administrador")]
        private void AccionesUsuarioAdministrador()
        {
            throw new NotImplementedException();
        }

        private void VerRegistrarUsuario()
        {
            Usuario = new();
            
            Actualizar();
        }
        public void Actualizar(string? p = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
