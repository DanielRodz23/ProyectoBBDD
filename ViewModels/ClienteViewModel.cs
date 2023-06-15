using GalaSoft.MvvmLight.Command;
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

namespace ProyectoBBDD.ViewModels
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        ProductosCatalogo productosCatalogo = new ProductosCatalogo();
        UsuarioCatalogo usuarioCatalogo = new UsuarioCatalogo();

        public string Error { get; set; }
        public ModoVistas Modo { get; set; }
        public Usuarios? usuario { get; set; }
        public Productos? Productos { get; set; }
        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                Actualizar();
            }
        }
        public ObservableCollection<Productos> ListaProductos { get; set; } = new ObservableCollection<Productos>();
        public ICommand VerEditarUsuarioCommand { get; set; }
        public ICommand VerComprarProductoCommand { get; set; }
        public ICommand ComprarProductoCommand { get; set; }
        public ICommand EditarUsuarioCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public ICommand RegresarCommand { get; set; }


        public ClienteViewModel()
        {
            VerEditarUsuarioCommand = new RelayCommand<int>(VerEditarUsuario);
            VerComprarProductoCommand = new RelayCommand<int>(verComprarProducto);
            ComprarProductoCommand = new RelayCommand<Usuarios>(ComprarProducto);
            EditarUsuarioCommand = new RelayCommand(EditarUsuario);
            CancelarCommand = new RelayCommand(Cancelar);
            RegresarCommand = new RelayCommand(Regresar);
            Modo = ModoVistas.VerCliente;
            CargarProductos();
            Actualizar();
        }

        private void verComprarProducto(int obj)
        {
            Productos = productosCatalogo.GetProductoId(obj);
            Modo = ModoVistas.VerComprarProducto;
            Actualizar();
        }

        private void Cancelar()
        {
            if (usuario != null)
            {
                usuarioCatalogo.Recargar(usuario);
                Regresar();
            }
        }

        private void Regresar()
        {
            Modo = ModoVistas.VerCliente;
            Actualizar();
        }

        private void EditarUsuario()
        {
            if (usuario != null)
            {
                if (usuarioCatalogo.Validar(usuario, out List<string> errores))
                {
                    usuarioCatalogo.Editar(usuario);

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

        private void ComprarProducto(Usuarios obj)
        {
            Cantidad = 0;
            Error = "";
            if (Productos != null && Cantidad != 0)
            {
                usuarioCatalogo.ComprarProducto(Productos, obj, Cantidad);
                CargarProductos();
                Regresar();
            }
            else
            {
                Error = "La cantidad no puede ser 0";
                Actualizar() ;
            }

        }

        private void VerEditarUsuario(int obj)
        {
            usuario = usuarioCatalogo.GetUsuarioId(obj);
            Modo = ModoVistas.VerEditarUsuario;
            Actualizar();
        }

        private void CargarProductos()
        {
            ListaProductos.Clear();
            foreach (var item in productosCatalogo.GetProductos())
            {
                ListaProductos.Add(item);
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
