using System;
using System.Windows;

namespace _07.WPF_Example
{
    /// <summary>
    /// SubWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubWindow : Window
    {
        // 메인 윈도우의 하단 ListBox를 Refresh하기 위한 델리게이트. 직무추가 버튼 클릭할 때 이벤트 할당
        public Delegate UpdateActor;

        public SubWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rdoInner.IsChecked == false && rdoOutside.IsChecked == false)
            {
                MessageBox.Show("내근 또는 외근을 선택하세요.", "항목선택");
                return;
            }

            DutyType dutyType = (rdoInner.IsChecked == true) ? DutyType.Inner : DutyType.OutSide;

            MainWindow._duties.Add(new Duty(txtDutyName.Text, dutyType));


            UpdateActor.DynamicInvoke(dutyType);

            MessageBox.Show("저장OK!", "저장확인");
            this.Close();

        }
    }
}
