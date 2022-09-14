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

namespace _13.wpfDataBinding___2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel v = new ViewModel();
            this.DataContext = v;
        }

        //MessageBox 출력
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel v = this.DataContext as ViewModel;
            MessageBox.Show(v.LastName + "," + v.FirstName);
        }

        //이름을 홍길동으로 변경, ViewModel 변경
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ViewModel v = this.DataContext as ViewModel;
            v.LastName = "홍";
            v.FirstName = "길동";
        }

    }
}
