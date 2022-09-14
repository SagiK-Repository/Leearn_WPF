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

namespace _07.WPF_Example
{



    public partial class MainWindow : Window
    {
        internal static Duties _duties = new Duties();

        public delegate void RefreshList(DutyType dutyType); // delegate 정의
        public event RefreshList RefreshListEvent; // 이벤트 정의


        public MainWindow()
        {
            InitializeComponent();
        }

        // 상단 ListBox의 항목(직무타입)을 선택했을 때
        private void OnSelected(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                string dutyType = ((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString();

                DataContext = from duty in _duties
                              where duty.DutyType.ToString() == dutyType
                              select duty;
            }
        }

        // 하단 ListBox의 항목(직무타입)을 선택했을 때
        private void OnSelected2(object sender, SelectionChangedEventArgs e)
        {
            var duty = (Duty)myListBox2.SelectedItem;
            //string value = duty == null ? "No selection" : duty.ToString();

            MessageBox.Show(duty.DutyName + "::" + duty.DutyType, "선택한 직무");
        }

        // 직무 추가 버튼 클릭했을 때 새창 띄움
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();

            RefreshListEvent += new RefreshList(RefreshListBox); // 이벤트 초기화
            subWindow.UpdateActor = RefreshListEvent; // 이벤트 할당
            subWindow.Show();
        }

        private void RefreshListBox(DutyType dutyType)
        {
            myListBox1.SelectedItem = null;
            myListBox1.SelectedIndex = (dutyType == DutyType.Inner) ? 0 : 1;
        }


    }
}
