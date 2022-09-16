using System;
using System.Windows;


namespace _2_2.Window_Class_WPF
{
    class MyWindow : Window
    {
        public MyWindow()
        {
            Width = 300;
            Height = 200;
            Title = "my simple window";
            Content = "hi there!";
        }
    }

    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MyWindow myWin = new MyWindow();
            myWin.Show();

            Application myApp = new Application();
            myApp.Run(myWin);
        }
    }
}
