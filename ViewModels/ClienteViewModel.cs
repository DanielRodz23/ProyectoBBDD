using GalaSoft.MvvmLight.Command;
using ProyectoBBDD.Catalogos;
using ProyectoBBDD.Models;
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
    public class ClienteViewModel:INotifyPropertyChanged
    {
        ProductosCatalogo productosCatalogo=new ProductosCatalogo();
        UsuarioCatalogo usuarioCatalogo = new UsuarioCatalogo();

       

        public Usuarios? usuario { get; set; }
        public Productos? Productos { get; set; }
        public ObservableCollection<Productos> ListaProductos { get; set; } =new ObservableCollection<Productos>();
        public ICommand VerEditarUsuarioCommad { get; set; }
        public ICommand ComprarProductoCommand {get;set;}
        public ICommand EditarUsuarioCommand {get;set;}
        
        //public ICommand VerEditarUsuario {get;set;}
        //public ICommand VerEditarUsuario {get;set;}
        //public ICommand VerEditarUsuario {get;set;}
        //public ICommand VerEditarUsuario {get;set;}
        public ClienteViewModel()
        {
            VerEditarUsuarioCommad = new RelayCommand<int>(VerEditarUsuario);
            ComprarProductoCommand = new RelayCommand(ComprarProducto);
            EditarUsuarioCommand = new RelayCommand(EditarUsuario);
            CargarProductos();
            Actualizar();
        }

        private void EditarUsuario()
        {
            throw new NotImplementedException();
        }

        private void ComprarProducto()
        {
            throw new NotImplementedException();
        }

        private void VerEditarUsuario(int obj)
        {
            throw new NotImplementedException();
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
