using GalaSoft.MvvmLight.Command;
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
        ProductosCatalogo productosCatalogo = new ProductosCatalogo();
        public Productos? producto { get; set; }
        public string Error { get; set; } = "";
        public ObservableCollection<Productos> productos { get; set; }=new ObservableCollection<Productos>();
        public ModoVistas Modo {  get; set; }
        public ICommand VerRegistrarProductoCommand { get; set; }
        public ICommand RegistrarProductoCommand { get; set; }
        public ICommand VerEliminarProductoCommand { get; set; }
        public ICommand EliminarProductoCommand { get; set; }
        public ICommand VerEditarProductoCommand { get; set; }
        public ICommand EditarProductoCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        
        public AdministradorViewModel()
        {
            VerRegistrarProductoCommand = new RelayCommand(VerRegistrarProducto);
            RegistrarProductoCommand = new RelayCommand(RegistrarProducto);
            VerEliminarProductoCommand = new RelayCommand(VerEliminarProducto);
            EliminarProductoCommand = new RelayCommand(EliminarProducto);
            VerEditarProductoCommand = new RelayCommand(VerEditarProducto);
            EditarProductoCommand = new RelayCommand(EditarProducto);
            CancelarCommand = new RelayCommand(Cancelar);
            CargarProductos();
            Actualizar();
        }

        private void Cancelar()
        {
            Modo = ModoVistas.VerAdministrador;
            Actualizar();
        }

        private void EditarProducto()
        {
            throw new NotImplementedException();
        }

        private void VerEditarProducto()
        {
            Modo = ModoVistas.VerEditarProducto;
            Actualizar();
        }

        private void EliminarProducto()
        {
            
        }

        private void VerEliminarProducto()
        {
            Modo=ModoVistas.VerEliminarProducto;
            Actualizar();
        }

        private void RegistrarProducto()
        {
            if (producto != null)
            {
                if (productosCatalogo.Validar(producto, out List<string> errores))
                {
                    productosCatalogo.Agregar(producto);
                    
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
            Modo=ModoVistas.VerRegistrarProducto;
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
