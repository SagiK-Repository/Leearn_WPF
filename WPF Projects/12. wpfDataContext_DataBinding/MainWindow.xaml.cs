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

namespace _12.wpfDataContext_DataBinding
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Emp e = new Emp()
            {
                Ename = "홍길동",
                City = "서울"
            };

            this.DataContext = e; // DataContext로 Emp e 지정

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Emp emp = this.DataContext as Emp;
            Console.WriteLine(emp.Ename);
            Console.WriteLine(emp.City);
        }
    }
}
