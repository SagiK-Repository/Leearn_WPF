using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace _04.WPF_MultiThread_Programming
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        // 백그라운드 워커 선언
        private BackgroundWorker myThread;

        // 짝수의 합을 저장할 인스턴스 변수
        int sum = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // 백그라운드 워커 초기화
            myThread = new BackgroundWorker()
            {
                WorkerReportsProgress = true, // 작업의 진행율이 바뀔 때 ProgressChanged 이벤트 발생 여부
                WorkerSupportsCancellation = true // 작업 취소 가능 여부
            };

            // 해야할 작업을 실행할 메소드 정의
            myThread.DoWork += myThread_DoWork;

            // UI 족에 진행사항을 보여주기 위해 WorkReportsProgress 속성값이 true 일때만 이벤트 발생
            myThread.ProgressChanged += myThread_ProgressChanged;

            // 작업이 완료되었을 때 실행할 콜백 메소드 정의
            myThread.RunWorkerCompleted += myThread_RunWorkerCompleted;

            MessageBox.Show("Worker 초기화");
        }

        // 백그라운드 워커가 실행하는 작업
        // DoWork 이벤트 처리 메소드에서 IsNumber.Items.Add(i)와 같은 코드를 직접 실행시키면 "InvalidOperationException"오류 발생
        private void myThread_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = (int)e.Argument;
            
            for (int i = 1; i <= count; i++)
            {
                if (myThread.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    Thread.Sleep(5);
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        (ThreadStart)delegate ()
                        {
                            if (i % 2 == 0)
                            {
                                sum += i;
                                e.Result = sum;
                                listboxNumber.Items.Add(i); // 짝수만 담는다.
                            }
                        }
                      );

                    myThread.ReportProgress(i);
                }
            }
        }

        // 작업 완료
        private void myThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) MessageBox.Show("작업 취소...");
            else if (e.Error != null) MessageBox.Show("에러 발생..." + e.Error);
            else
            {
                lableSum.Content = ((int)e.Result).ToString();
                MessageBox.Show("작업 완료!!");
            }
        }

        // 작업의 진행률이 바뀔 때 발생
        private void myThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            int num;

            if (!int.TryParse(textNumber.Text, out num))
            {
                MessageBox.Show("숫자를 입력하세요!");
                return;
            }

            progressBar.Maximum = num;
            listboxNumber.Items.Clear();
            myThread.RunWorkerAsync(num);
        }

        private void buttonCancle_Click(object sender, RoutedEventArgs e)
        {
            myThread.CancelAsync();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
