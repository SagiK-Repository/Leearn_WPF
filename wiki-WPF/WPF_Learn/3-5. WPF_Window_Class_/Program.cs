using System;
using System.Windows.Media;
using System.Windows;

namespace _3_5.WPF_Window_Class_
{
    // Color Window
    class ColorWindow : Window
    {
        public ColorWindow(Brush b)
        {
            Title = "My Simple Window";
            Content = "Hi~ There~!";
            Width = 300;
            Height = 200;

            Background = b;
            Foreground = Brushes.Blue;
        }
    }

    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            // SolidColorBrush : 단색
            // 기본 단색
            ColorWindow myWin0 = new ColorWindow(Brushes.Beige);

            Color myColor = new Color();
            myColor.A = 255; // 0~255의 불투명한 정도
            myColor.R = 100; // 0~255의 red
            myColor.G = 150; // 0~255의 green
            myColor.B = 200; // 0~255의 blue
            ColorWindow myWin1 = new ColorWindow(new SolidColorBrush(myColor));
            // SolidColorBrush scb = new SolidColorBrush(myColor);
            // SolidColorBrushs myWin0 = new SolidColorBrushs(sb);


            //LinearGradientBrush : 선형 그라데이션
            Point startPoint = new Point(0, 0); // 왼쪽 위 시작점 (높이와 너비는 0~1)
            Point endPoint = new Point(1, 1); // 오른쪽 아래 종료점

            ColorWindow myWin2 = new ColorWindow(
                new LinearGradientBrush(Colors.White, Colors.MistyRose, startPoint, endPoint)
                );

            LinearGradientBrush lgb = new LinearGradientBrush();
            lgb.StartPoint = new Point(0, 0);
            lgb.EndPoint = new Point(1, 1);
            lgb.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0)); // Step 위치별 색 지정
            lgb.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            lgb.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            lgb.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));

            ColorWindow myWin3 = new ColorWindow(lgb);


            // RadialGradientBrush : 방사형 그라데이션
            ColorWindow myWin4 = new ColorWindow(
                new RadialGradientBrush(Colors.White, Colors.Aquamarine)
                );

            RadialGradientBrush rgb = new RadialGradientBrush();
            rgb.GradientOrigin = new Point(0.5, 0.5); // Gradiation 시작점 위치 비율
            rgb.Center = new Point(0.5, 0.5); // Gradiation 범위 중심 위치 비율
            rgb.RadiusX = 0.5; // Gradiation 가로 길이
            rgb.RadiusY = 0.5; // Gradiation 세로 길이
            rgb.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0)); // Step 위치별 색 지정
            rgb.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            rgb.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            rgb.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));

            ColorWindow myWin5 = new ColorWindow(rgb);
            myWin0.Show();
            myWin1.Show();
            myWin2.Show();
            myWin3.Show();
            myWin4.Show();
            myWin5.Show();

            Application myApp = new Application();
            myApp.Run(myWin0);
            myApp.Run(myWin1);
            myApp.Run(myWin2);
            myApp.Run(myWin3);
            myApp.Run(myWin4);
            myApp.Run(myWin5);

        }
    }
}
