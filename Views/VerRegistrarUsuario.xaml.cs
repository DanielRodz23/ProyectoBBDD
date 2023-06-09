using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoBBDD.Views
{
    /// <summary>
    /// Lógica de interacción para VerRegistrarUsuario.xaml
    /// </summary>
    public partial class VerRegistrarUsuario : UserControl
    {
        public VerRegistrarUsuario()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtPasswordR.Text = "";
            txtPasswordR.Text = pwb2.Password;
            pwb2.Clear();
        }
    }
}
