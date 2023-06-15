﻿using ProyectoBBDD.ViewModels;
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

namespace ProyectoBBDD.Views.ClienteViews
{
    /// <summary>
    /// Lógica de interacción para VerComprarProducto.xaml
    /// </summary>
    public partial class VerComprarProducto : UserControl
    {
        public VerComprarProducto()
        {
            InitializeComponent();
            NumericUpDownTextBox.Text = "0";
        }
        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(NumericUpDownTextBox.Text);
            value++;
            NumericUpDownTextBox.Text = value.ToString();
        }

        private void DecrementButton_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(NumericUpDownTextBox.Text);
            if (value > 0)
                value--;
            NumericUpDownTextBox.Text = value.ToString();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    txtCantidad.Text= string.Empty;
        //    txtCantidad.Text=NumericUpDownTextBox.Text;
        //    NumericUpDownTextBox.Clear();
        //}
    }
}
