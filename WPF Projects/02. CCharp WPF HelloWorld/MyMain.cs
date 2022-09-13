using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _02.CCharp_WPF_HelloWorld
{
    internal class MyMain : Application
    {
        [STAThread] // Single Thread
        public static void Main()
        {
            MyMain app = new MyMain();
            app.ShutdownMode = ShutdownMode.OnMainWindowClose; // 메인이 닫히면 다 함께 닫힌다.
            app.Run(); // 프로그램 시작
        }

        // Application의 내용을 재정의, 화면을 띄우기 위함
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Main Window
            Window mainWindow = new Window();
            mainWindow.Title = "WPF Sample(Main)";
            mainWindow.MouseDown += WinMouseDown;
            mainWindow.Show();

            // Sub Window
            for(int i = 0; i < 2; i++)
            {
                Window win = new Window();
                win.Title = "Extra Window No." + (i + 1);
                win.ShowInTaskbar = false; // Task바(작업 표시줄)에 하나만 나타난다.
                win.Owner = mainWindow; // 부모 창을 지정. 부모가 닫히면 자식도 닫힌다.
                win.Show();
            }
        }

        void WinMouseDown(Object sender, MouseEventArgs args)
        {
            Window win = new Window();
            win.Title = "Modal Dialogbox";
            win.Width = 400;
            win.Height = 200;

            Button b = new Button();
            b.Content = "Click Me!";
            b.Click += Button_Click;

            win.Content = b;
            win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Click!", sender.ToString());
        }
    }
}
