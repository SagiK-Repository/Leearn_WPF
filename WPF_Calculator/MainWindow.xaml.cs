using System.Windows;

namespace WPF_Calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //데이터 바인딩 소스 객체로 CalcViewModel를 지정
            this.DataContext = new CalcViewModel();
        }
    }
}
