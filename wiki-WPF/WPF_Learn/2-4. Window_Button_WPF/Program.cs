using System;
using System.Windows;
using System.Windows.Controls;

namespace _2_4.Window_Button_WPF
{

    // 기초 버튼
    class MyWindow : Window
    {
        public MyWindow()
        {
            Title = "My Program Window";
            Width = 300;
            Height = 200;

            Button btn = new Button();    // Create a button.
            btn.Content = "Click Me";     // Set the button's text.

            Content = btn;
        }
    }

    // 가로맞춤, 세로맞춤 속성 추가
    class ButtonWindow : Window
    {
        public ButtonWindow(HorizontalAlignment h)
        {
            Title = "My Program Window";
            Width = 300;
            Height = 200;

            Button btn = new Button();    // Create a button.
            btn.HorizontalAlignment = h;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Content = "Click Me";     // Set the button's text.

            Content = btn;
        }
    }

    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // 기본 버튼
            MyWindow myWin0 = new MyWindow();

            // 가로맞춤, 세로맞춤 속성 추가
            ButtonWindow myWin1 = new ButtonWindow(HorizontalAlignment.Center);

            ButtonWindow myWin2 = new ButtonWindow(HorizontalAlignment.Left);

            ButtonWindow myWin3 = new ButtonWindow(HorizontalAlignment.Right);

            ButtonWindow myWin4 = new ButtonWindow(HorizontalAlignment.Stretch);

            myWin0.Show();
            myWin1.Show();
            myWin2.Show();
            myWin3.Show();
            myWin4.Show();

            Application myApp = new Application();
            myApp.Run(myWin0);
            myApp.Run(myWin1);
            myApp.Run(myWin2);
            myApp.Run(myWin3);
            myApp.Run(myWin4);
        }
    }
}
