using System;
using System.Windows;
using Application = System.Windows.Application;

namespace _3_7.WPF_Application_Class
{
    class MyWindow : Window
    {
        public MyWindow()
        {
            Title = "My Program Window";
            Width = 300;
            Height = 200;
            Content = "this is application handles the startup event.";
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MyWindow win = new MyWindow();
            Application app = new Application();
            app.Startup += App_Startup;
            app.Run(win);
        }

        private static void App_Startup(object sender, StartupEventArgs e)
        {
            MessageBox.Show("The application is starting", "Starting Message");
        }
    }

}
