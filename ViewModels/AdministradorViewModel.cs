﻿using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoBBDD.Catalogos;
using ProyectoBBDD.Models;
using ProyectoBBDD.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoBBDD.ViewModels
{
    public class AdministradorViewModel : INotifyPropertyChanged
    {
        //public PrincipalViewModel Principal { get; set; } = new PrincipalViewModel();
        ProductosCatalogo productosCatalogo = new ProductosCatalogo();
        UsuarioCatalogo usuariosCatalogo = new UsuarioCatalogo();
        RolesCatalogo rolesCatalogo = new RolesCatalogo();
        RegistrosCatalogo registroscatalogo = new RegistrosCatalogo();
        public Productos? producto { get; set; }
        public Usuarios? usuario { get; set; }
        public Roles? Rol { get; set; } = new Roles();
        public Registrocompras? registrocompras { get; set; } = new();
        public string Error { get; set; } = "";
        public ObservableCollection<Productos> productos { get; set; } = new ObservableCollection<Productos>();
        public ObservableCollection<Usuarios> usuarios { get; set; } = new ObservableCollection<Usuarios>();
        public ObservableCollection<Roles> ListaRoles { get; set; } = new ObservableCollection<Roles>();
        public List<Compra> ListaRegistros { get; set; } = new List<Compra>();
        public List<Registrocompras> ListaRegistrosCompletos { get; set; } = new();
        public bool HayDatos { get; set; }=false;

        public ModoVistas Modo { get; set; }
        public ICommand VerRegistrarProductoCommand { get; set; }
        public ICommand RegistrarProductoCommand { get; set; }
        public ICommand VerEliminarProductoCommand { get; set; }
        public ICommand EliminarProductoCommand { get; set; }
        public ICommand VerEditarProductoCommand { get; set; }
        public ICommand EditarProductoCommand { get; set; }
        public ICommand VerRegistrarUsuarioCommand { get; set; }
        public ICommand RegistrarUsuarioCommand { get; set; }
        public ICommand VerEliminarUsuarioCommand { get; set; }
        public ICommand EliminarUsuarioCommand { get; set; }
        public ICommand VerEditarUsuarioCommand { get; set; }
        public ICommand EditarUsuarioCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public ICommand VerAdmUsuariosCommand { get; set; }
        public ICommand VerAdmProductosCommand { get; set; }
        public ICommand RegresarVerUsuariosCommand { get; set; }
        public ICommand CancelarVerUsuarioCommand { get; set; }
        public ICommand CancelarEditarCommand { get; set; }
        public ICommand VerRegistrosComprasCommand { get; set; }
        public ICommand VerRegistroDeUsuarioCommand { get; set; }

        public AdministradorViewModel()
        {
            //Ver productos o usuarios
            VerAdmUsuariosCommand = new RelayCommand(VerUsuarios);
            VerAdmProductosCommand = new RelayCommand(VerProductos);

            //Metodos para productos
            VerRegistrarProductoCommand = new RelayCommand(VerRegistrarProducto);
            RegistrarProductoCommand = new RelayCommand(RegistrarProducto);
            VerEliminarProductoCommand = new RelayCommand<int>(VerEliminarProducto);
            EliminarProductoCommand = new RelayCommand(EliminarProducto);
            VerEditarProductoCommand = new RelayCommand<int>(VerEditarProducto);
            EditarProductoCommand = new RelayCommand(EditarProducto);

            CancelarEditarCommand = new RelayCommand(CancelarEditar);

            //Metodos para usuarios
            VerRegistrarUsuarioCommand = new RelayCommand(verRegistrarUsuario);
            RegistrarUsuarioCommand = new RelayCommand(RegistrarUsuario);
            VerEliminarUsuarioCommand = new RelayCommand<int>(VerEliminarUsuario);
            EliminarUsuarioCommand = new RelayCommand(EliminarUsuario);
            VerEditarUsuarioCommand = new RelayCommand<int>(VerEditarUsuario);
            EditarUsuarioCommand = new RelayCommand(EditarUsuario);
            VerRegistroDeUsuarioCommand = new RelayCommand<int>(VerRegistroDeUsuario);

            RegresarVerUsuariosCommand = new RelayCommand(RegresarVerUsuarios);
            CancelarVerUsuarioCommand = new RelayCommand(CancelarVerUsuarios);
            //Metodos generales
            CancelarCommand = new RelayCommand(CancelarVerProductos);
            VerRegistrosComprasCommand = new RelayCommand(VerRegistrosCompras);

            //VerRegistroDeUsuario(5);

            CargarRoles();
            CargarUsuarios();
            CargarProductos();
            VerProductos();
            Actualizar();
        }

        private void VerRegistroDeUsuario(int id)
        {
            //Cambiar vista
            Modo = ModoVistas.VerRegistroPorCliente;
            //Cargar Datos
            var temp = usuariosCatalogo.GetUsuarioId(id);
            ListaRegistrosCompletos.Clear();
            if (!(temp.Registrocompras.Count == 0))
            {
                HayDatos = true;
                foreach (var item in temp.Registrocompras)
                {
                    ListaRegistrosCompletos.Add(item);
                }
            }
            else
            {
                HayDatos = false;
            }
            Actualizar();
        }
        void CargarTodosLosRegistros()
        {
            ListaRegistros.Clear();
            ListaRegistros = registroscatalogo.GetRegistros();
        }
        private void VerRegistrosCompras()
        {
            CargarTodosLosRegistros();
            Modo = ModoVistas.VerRegistrosCompras;
            Actualizar();
        }

        private void CancelarEditar()
        {
            if (producto != null)
            {
                productosCatalogo.Recargar(producto);
                CancelarVerProductos();
            }
        }

        private void CancelarVerUsuarios()
        {
            if (usuario != null)
            {
                usuariosCatalogo.Recargar(usuario);
                RegresarVerUsuarios();
            }
        }

        private void RegresarVerUsuarios()
        {
            Modo = ModoVistas.VerAdmUsuarios;
            usuario = new();
            Actualizar();
        }

        void CargarRoles()
        {
            ListaRoles.Clear();
            foreach (var item in rolesCatalogo.GetRoles())
            {
                ListaRoles.Add(item);
            }
            Actualizar();
        }
        private void VerProductos()
        {
            CargarProductos();
            Modo = ModoVistas.VerAdministrador;
            Actualizar();
        }

        private void VerUsuarios()
        {
            CargarUsuarios();
            Modo = ModoVistas.VerAdmUsuarios;
            Actualizar();
        }

        private void CargarUsuarios()
        {
            usuarios.Clear();
            foreach (var item in usuariosCatalogo.GetUsuarios())
            {
                usuarios.Add(item);
            }
            Actualizar();
        }

        private void EditarUsuario()
        {
            if (usuario != null)
            {
                if (usuariosCatalogo.Validar(usuario, out List<string> errores))
                {
                    usuariosCatalogo.Editar(usuario);
                    CargarUsuarios();
                    usuario = new();
                    Modo = ModoVistas.VerAdmUsuarios;
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

        private void VerEditarUsuario(int obj)
        {
            usuario = usuariosCatalogo.GetUsuarioId(obj);
            Modo = ModoVistas.VerEditarUsuario;
            Actualizar();
        }

        private void EliminarUsuario()
        {
            if (usuario != null)
            {
                usuariosCatalogo.Eliminar(usuario);
                Modo = ModoVistas.VerAdministrador;
                CargarUsuarios();
                Actualizar();
            }
        }

        private void VerEliminarUsuario(int obj)
        {
            usuario = usuariosCatalogo.GetUsuarioId(obj);
            Modo = ModoVistas.VerEliminarUsuario;
            Actualizar();
        }

        private void RegistrarUsuario()
        {
            if (usuario != null)
            {
                if (usuariosCatalogo.Validar(usuario, out List<string> errores))
                {
                    usuariosCatalogo.Agregar(usuario);
                    CargarUsuarios();
                    usuario = new();
                    Modo = ModoVistas.VerAdmUsuarios;
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

        private void verRegistrarUsuario()
        {
            usuario = new();
            Modo = ModoVistas.VerRegistrarUsuario;
            Actualizar();
        }

        private void CancelarVerProductos()
        {

            Modo = ModoVistas.VerAdministrador;
            Actualizar();
        }

        private void EditarProducto()
        {
            if (producto != null)
            {
                if (productosCatalogo.Validar(producto, out List<string> errores))
                {
                    productosCatalogo.Editar(producto);
                    CargarProductos();
                    producto = new();
                    Modo = ModoVistas.VerAdministrador;
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

        private void VerEditarProducto(int id)
        {
            producto = productosCatalogo.GetProductoId(id);
            Modo = ModoVistas.VerEditarProducto;
            Actualizar();
        }

        private void EliminarProducto()
        {
            if (producto != null)
            {
                productosCatalogo.Eliminar(producto);
                CargarProductos();
                Modo = ModoVistas.VerAdministrador;
                Actualizar();
            }
        }

        private void VerEliminarProducto(int id)
        {
            producto = productosCatalogo.GetProductoId(id);
            Modo = ModoVistas.VerEliminarProducto;
            Actualizar();
        }

        private void RegistrarProducto()
        {
            if (producto != null)
            {
                if (productosCatalogo.Validar(producto, out List<string> errores))
                {
                    productosCatalogo.Agregar(producto);
                    CargarProductos();
                    producto = new();
                    Modo = ModoVistas.VerAdministrador;
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

        private void VerRegistrarProducto()
        {
            producto = new();
            Modo = ModoVistas.VerRegistrarProducto;
            //Principal.Modo = ModoVistas.VerRegistrarProducto;
            Actualizar();
        }

        private void CargarProductos()
        {
            productos.Clear();
            foreach (var item in productosCatalogo.GetProductos())
            {
                productos.Add(item);
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
