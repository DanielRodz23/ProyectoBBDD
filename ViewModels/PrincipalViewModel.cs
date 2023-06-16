using GalaSoft.MvvmLight.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoBBDD.Catalogos;
using ProyectoBBDD.Models;
using ProyectoBBDD.Views;
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
        public ModoVistas Modo { get; set; }
        //LoginView view;
        public string Error { get; set; }
        public string Titulo { get; set; }
        public ICommand IniciarSesionCommand { get; set; }
        public ICommand CerrarSesionCommand { get; set; }
        public bool EstaConectado => Usuario.Id != 0;
        public ICommand VerRegistrarUsuarioCommand { get; set; }
        public ICommand RegistrarUsuarioCommand { get; set; }
        UsuarioCatalogo catalagous = new UsuarioCatalogo();
        public PrincipalViewModel()
        {
            Titulo = "Iniciar sesión";
            CerrarSesionCommand = new RelayCommand(CerrarSesion);
            IniciarSesionCommand = new RelayCommand(IniciarSesion);

            VerRegistrarUsuarioCommand = new RelayCommand(VerRegistrarUsuario);
            RegistrarUsuarioCommand = new RelayCommand(RegistrarUsuario);
            Usuario = new();
            Modo = ModoVistas.LoginView;
            Actualizar();
        }

        private void RegistrarUsuario()
        {

            if (Usuario != null)
            {
                if (catalagous.Validar(Usuario, out List<string> errores))
                {
                    catalagous.Agregar(Usuario);

                    Usuario = new();
                    Modo = ModoVistas.LoginView;
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
            Titulo = "Inicio de sesión";
            Usuario = new();
            Modo = ModoVistas.LoginView;
            Actualizar();
        }

        private void IniciarSesion()
        {
            if (Usuario != null)
            {
                var inicio = catalagous.spIniciarSesion(Usuario.Correo, Usuario.Contrasena);
                if (inicio == 1)
                {
                    var usuario = catalagous.GetUsuario(Usuario.Correo);
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
            this.Titulo = "Sesión de cliente";
            Modo = ModoVistas.VerCliente;
            Actualizar();
        }
        [Authorize(Roles = "Administrador")]
        private void AccionesUsuarioAdministrador()
        {
            this.Titulo = "Sesión de administrador";
            Modo = ModoVistas.VerAdministrador;
            Actualizar();
        }

        private void VerRegistrarUsuario()
        {
            Usuario = new()
            {
                Idrol = 2
            };
            Modo = ModoVistas.VerRegistrarUsuario;
            Actualizar();
        }
        public void Actualizar(string? p = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
