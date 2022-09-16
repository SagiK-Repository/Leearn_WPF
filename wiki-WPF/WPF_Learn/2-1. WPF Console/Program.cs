using System;
using System.Windows; // Windows 참조

namespace _2_1.WPF_Console
{
    internal class Program
    {
        [STAThread] // 싱글 쓰레드
        static void Main(string[] args)
        {
            Window myWin = new Window();
            myWin.Title = "my simple window"; //원도우 창 이름
            myWin.Content = "hi there!"; // 윈도우 폼 내용

            Application myApp = new Application();
            myApp.Run(myWin);
        }
    }
}
