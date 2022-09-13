# WPF 멀티스레드 프로그래밍

- [+멀티스레드+]란 여러 개의 스레드가 동시에 특정 코드블럭을 실행하는 것이다.
- 모든 [+WPF 프로그램+]은 최소한의 렌더링을 위한 [+백그라운드 스레드+]와 [+UI 스레드+] 두개의 스레드로 기동된다.
- WPF는 기본적으로 STA(Single Thread Aprtment) 모델을 지원한다.
 -하나의 스레드는 전체 응용 프로그램에서 실행되고 모든 WPF 객체를 소유하고 있고 TextBox같은 WPF UIElements 요소들은 스레드 선호도라는 것이 있어 다른 스레드와 상호작용 할 수 없다.
- 화면을 그리는 스레드는 컨트롤을 소유하고 다른 스레드에서는 직접 접근할 수 없도록 되어있다. 이를 [+스레드 선호도+]라 한다.

<br>

### Background Worker를 이용한 WPF 멀티스레드 프로그래밍

- Windows 응용 프로그램 멀티 스레딩에서 가장 어려운 개념은 [-다른 스레드에서 UI를 변경할 수 없다-]는 것이다. 대신 [+UI 스레드에서 메소드를 호출+]해야 원하는 변경이 이루어진다.
- 백그라운드 워커는 System.ComponentModel 아래의 클래스로 코드를 별도의 스레드에서 동시에 비동기적으로 실행하게 해준다.
- 응용 프로그램의 기본 스레드와 자동으로 동기화 해준다.
- 호출 스레드는 정상적으로 실행되고 백그라운드 워커는 백그라운드에서 비동기적으로 실행된다.

<br>

### 실습
- 숫자를 입력하면 백그라운드 워커를 통해 ProgressBar에 진행사항을 표시하고, 리스트 박스에 짝수들을 출력, 그 합을 구해 출력한다.
  - WPF멀티스레드, 백그라운드워커, BackgroundWorker, ProgressBar를 활용한다.
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- UI를 구성한다.  
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_04.WPF_MultiThread_Programming.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_04.WPF_MultiThread_Programming"
        mc:Ignorable="d"
        Title="MainWindow" Height="386" Width="514">
    <Grid>
        <Label x:Name="label" Content="숫자를 입력하시오" HorizontalAlignment="Left" Margin="51,48,0,0" VerticalAlignment="Top"/>
        <TextBox x:Name="textNumber" HorizontalAlignment="Left" Height="26" Margin="166,48,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="74"/>
        <Button x:Name="buttonStart" Content="시작" HorizontalAlignment="Left" Height="26" Margin="245,48,0,0" VerticalAlignment="Top" Width="97"/>
        <Button x:Name="buttonCancle" Content="중지" HorizontalAlignment="Left" Height="26" Margin="347,48,0,0" VerticalAlignment="Top" Width="97"/>
        <ProgressBar x:Name="progressBar" HorizontalAlignment="Left" Height="38" Margin="51,90,0,0" VerticalAlignment="Top" Width="393" ValueChanged="ProgressBar_ValueChanged"/>
        <ListBox x:Name="listboxNumber" HorizontalAlignment="Left" Height="179" Margin="51,145,0,0" VerticalAlignment="Top" Width="152" d:ItemsSource="{d:SampleData ItemCount=5}"/>
        <Label x:Name="label2" Content="합계는?" HorizontalAlignment="Left" Height="27" Margin="225,148,0,0" VerticalAlignment="Top" Width="53"/>
        <Label x:Name="lableSum" Content="text" HorizontalAlignment="Left" Margin="294,148,0,0" VerticalAlignment="Top" Width="150"/>

    </Grid>
</Window>
```
</details>

- 다음과 같이 코드를 넣는다. (버튼 2개에 대한 Click 이벤트를 만든다.)
<details><summary>Name</summary>

```cs
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
                    Thread.Sleep(100);
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
    }
}
```
</details>

### 결과

![04](https://user-images.githubusercontent.com/66783849/189935314-683e808e-a24e-4cfc-aa73-c49a63313113.png)
