using System;
using System.Windows;

namespace _2_3.Window_Style_WPF
{
    class MyWindow : Window
    {
        public MyWindow(WindowStyle a)
        {
            Width = 300;
            Height = 200;
            Title = "WindowStyles";

            Content = WindowStyle.ToString();
            // WindowStyle = WindowStyle.None;
            WindowStyle = a;
        }
    }

    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // SingleBorderWindow : 단일 테두리가 있는 창
            MyWindow myWin0 = new MyWindow(WindowStyle.SingleBorderWindow);
            // ThreeDBorderWindow : 창이 3차원 테두리
            MyWindow myWin1 = new MyWindow(WindowStyle.ThreeDBorderWindow);
            // ToolWindow : 고정된 도구창(최대화, 최소화 할 수 없다.)
            MyWindow myWin2 = new MyWindow(WindowStyle.ToolWindow);
            // None : 클라이언트 영역만 표시, 제목 표시줄과 테두리는 표시되지 않는다.
            MyWindow myWin3 = new MyWindow(WindowStyle.None);
            // myWin.WindowStyle = WindowStyle.None;

            myWin0.Show();
            myWin1.Show();
            myWin2.Show();
            myWin3.Show();

            Application myApp = new Application();
            myApp.Run(myWin0);
            myApp.Run(myWin1);
            myApp.Run(myWin2);
            myApp.Run(myWin3);
        }
    }
}
