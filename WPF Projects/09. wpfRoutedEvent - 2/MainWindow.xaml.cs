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

namespace _09.wpfRoutedEvent___2
{
    public partial class MainWindow : Window
    {
        private string _mouseActivity = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _mouseActivity = "PreviewMouseDown Window \n";
            MessageBox.Show(_mouseActivity);
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _mouseActivity = "PreviewMouseDown StackPanel \n";
            MessageBox.Show(_mouseActivity);
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _mouseActivity = "PreviewMouseDown Button \n";
            MessageBox.Show(_mouseActivity);
        }

    }
}
