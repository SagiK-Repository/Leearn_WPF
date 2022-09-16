## 목적 
- wiki 의 WPF 내용을 학습합니다.

<br>

## 목표 
- [ ] [Ch 01. WPF 소개]
- [ ] [Ch 02. WPF 프로그래밍 개요]
- [ ] [Ch 03. WPF Architecture 및 어플리케이션]
- [ ] [Ch 04. XAML]
- [ ] [Ch 05. Layout]
- [ ] [Ch 06. Content 및 Control]
- [ ] [Ch 07. Dependency Property]
- [ ] [Ch 08. Data Binding]
- [ ] [Ch 09. Routing Events 및 Command]
- [ ] [Ch 10. 다양한 Control 및 Element]
- [ ] [Ch 11. Resources]
- [ ] [Ch 12. Styles]
- [ ] [Ch 13. Control Templates]
- [ ] [Ch 14. Page Navigation 프로그램]
- [ ] [Ch 15. 다양한 Data Binding]
- [ ] [Ch 16. Tree, Tab, 그 외 다른 Control들]
- [ ] [Ch 17. Text 및 Documents]
- [ ] [Ch 18. WPF의 Graphic]
- [ ] [Ch 19. Animation]
- [ ] [Ch 20. Audio 및 Video]
- [ ] [교육 관련 총평(비평)]

<br>

## 출처
- http://wish.mirero.co.kr/mirero/education/newface-group/newface/juhyung.park/-/issues/1
- http://build.mirero.co.kr:8099/articles/WPF/Chapter1/Chapter1.html

<br>

## 참여자
@ByungEun.Kim @JungOk.Kim @SeungHa.Lee @ChangBum.Kwon



---


# Ch 01. WPF 소개

### 0. Summary(요약)

- <img src="" width="70%">

<br>

### 1. WPF?

- [-WPF(Windows Presentation Foundation)-]를 통해 시각적으로 뛰어난 환경을 통해 [+Windows용 데스크톱 클라이언트 응용프로그램+]을 만들 수 있다.
- WPF는 최신 그래픽 하드웨어를 활용하도록 작성된 독립적인 벡터 기반 렌더링 엔진으로써 다음을 포함하는 포괄적인 응용프로그램 개발한다.
  - XAML(Extensible Application Markup Language)
    - XAML(eXtensible Application Markup Language) 이라는 새로운 마크업 언어를 사용하여 그래픽 설계를 코딩 구현과 분리할 수 있다.
  - Documents 및 Fonts(텍스트 및 입력체계)
    - Flow document는 창의 크기와 모양에 따라 텍스트가 배치될 수 있다.
    - HTML처럼 창 크기를 변경하면 새로운 크기와 모양에 맞게 텍스트가 재조정되고 배치된다.
    - Fixed document는 Adobe PDF 문서와 유사하다. 텍스트와 모든 서식은 최종 사용자가 고정하고 변경할 수 없다.
  - 컨트롤
  - 데이터 바인딩
  - 레이아웃
  - 2차원 및 3차원 그래픽 : WPF는 Vector-Graphic 2D 및 3D 형상에 대한 지원이 내장되어 있다.
  - 애니메이션 : 애니메이션에 대한 지원도 내장되어 있다.
  - 스타일 : Style은 요소의 속성 설정 집합이다. 
  - Control Templates
    - 템플릿은 Style과 유사하다. 컨트롤의 표시 방법을 결정한다.
    - 표준 Windows 컨트롤의 모양은 운영체제에 내장되어 있으며 다른 모양의 컨트롤을 원한다면 Template으로 변경할 수 있다.
  - 미디어
- .NET Framework에 포함되어 있어, .NET Framework 클래스 라이브러리의 다른 요소를 통합하는 응용프로그램을 빌드할 수 있다.

<br>

### Vector Graphic

- WPF는 벡터 그래픽을 사용하도록 권장한다.
- WPF의 핵심은 최신 그래픽 하드웨어를 활용하도록 작성된 해상도 독립적인 벡터 기반 렌더링 엔진이다.
- Vector Graphics 파일 확장자(.svg, .cgm, .pdf, .eps, .hpgl, .swf)
- Bitmap Image 파일 확장자(.jpg, .tiff, .gif, .png, .pcx, .bmp, .dib)

<br>

### 독립적인 DPI 시스템을 사용한다.

<img src="" width="70%">

- WPF는 실제 픽셀 밀도를 사용하여 UI를 배치하는 대신 독립적인 픽셀 dpi를 사용한다.
- 픽셀의 밀도가 더 높아져 더 자세하게 렌더링 된다.

<br>

### .NET의 WPF

<img src="" width="70%">

- WPF는 .NET 3.0에서 처음으로 출시된 네 가지 구성 요소 중 하나이다.
- WPF의 목적은 풍부한 시각적 콘텐츠를 가진 프로그램을 구축하기 위한 프레임워크이다.

<br>

### Silverlight

- WPF와 Silverlight는 둘 다 XAML 기반 플랫폼이다.
  - 차이점
    - WPF는 애플 운영체제나 리눅스와 같은 [-다른 플랫폼에서 실행되도록 설계되지 않은-] [+윈도우즈 기반+]의 Rich Client Technology이다.
    - Silverlight는 브라우저가 실행되는 운영체제와 관계없는 웹 어플리케이션을 위해 설계되었다.
    - Silverlight는 웹 어플리케이션을 위해 설계되었다. (Adobe의 Flash 브라우저 플러그인과 유사)
    - Silverlight는 브라우저 플러그인이기 때문에 WPF와 달리 런타임 크기가 매우 작고, API와 기능들이 WPF의 서브셋이기 때문에 WPF의 경량화된 버전이라고 볼 수 있다.

<br><br><br>

# Ch 02. WPF 프로그래밍 개요

### 0. Summary(요약)

- <img src="" width="70%">

<br>

### 1. WPF 프로젝트 생성 방법 - 콘솔 앱으로 생성하기

- Visual Studio > 새 프로젝트 > 콘솔 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- 솔루션 탐색기 > 참조 > 오른쪽 마우스 > 참조 추가 > 어셈블리 > WindowBase, PresentationCore, PresentationFrameWork 체크
- 프로젝트 > 오른쪽 마우스 클릭 > 속성 > 애플리케이션(응용프로그램) > 출력형식 > Windows 애플리케이션(응용프로그램)으로 변경
- Porgram.cs 코드를 다음과 같이 구성한다.
  ```cs
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
  ```
- 결과  
  <img src="">
- 윈도우 화면은 다음과 같이 구성한다.  
  <img src="" width="50%">


<br>

### 2. Window 클래스를 상속받은 MyWindow 클래스로 윈도우 앱 만들기

- 2-1과 마찬가지로 프로젝트를 구성한다.
- Program.cs 코드를 다음과 같이 구성한다.
  ```cs
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
  ```
- 결과  
  <img src="">
- Window는 다음과 같은 속성들로 구성되어 있다.  
  <img src="" width="30%">


<br>

### 3. WindowStyle

- 2-1과 마찬가지로 프로젝트를 구성한다.
- Window Styles에 따라 다양한 창을 만들 수 있다.
- Program.cs 코드를 다음과 같이 구성한다.
  ```cs
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
  ```
- 결과  
  <img src="" width="70%">

<br>

### 4. 버튼 만들기

- 2-1과 마찬가지로 프로젝트를 구성한다.
- using System.Window.Control 추가하여 구성한다.
- Program.cs 코드를 다음과 같이 구성한다.
  ```cs
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
  ```
- 결과  
  <img src="" width="70%">


<br><br><br>

# Ch 03. WPF Architecture 및 어플리케이션

### 0. Summary(요약)

- <img src="" width="70%">

<br>

### 1. WPF Project

- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- App.xaml 파일과 App.xaml.cs 파일이 App을 수행
- MainWindow.xaml 파일과 MainWindow.xaml.cs 파일이 MainWindow를 수행한다.
- Visual Studio에서 Default로 두 개의 XAML 파일을 생성한다.
  - MainWindow.xaml
  - App.xaml
- Logical Tree와 Visual Tree는 다음과 같이 구성된다.
  - Logical Tree(논리적 트리)  
    <img src="" width="70%">
  - Visual Tree(시각적 트리) (디버깅 모드에서 확인 가능)  
    <img src="" width="70%">


<br>

### 2. XAML 및 C# 프로그램의 컴파일 과정

- <img src="" width="70%">
- XAML 파일은 컴파일하면 BAML(XAML을 Binary로 표현한 파일)과 .g.cs파일이 만들어진다.
- C# 파일과 BAML파일로 exe를 만든다. (XAML파일에 직접 접근하는 것이 아니라, BAML 파일을 사용한다)
- UI 트리는 어셈블리의 MainWindow BAML이 로드한 MainWindow 클래스에서 InitializeComponent 메서드를 호출할 때 생성된다.


<br>

### 3. WPF Architecture (WPF 구조)

- <img src="" width="70%">
- 상위의 서비스를 사용하는 계층, Direct와 플랫폼의 하위 계층, 두 계층 사이를 번역하는 계층
  - Managed WPF Layer : 직접 서비스를 노출하는 부분이다.
    - Window Base : Application과 Window 클래스이다.
  - Media Integration Layer : Unmanaged code, Direct3D로 렌더링을 하는 부분이다.
- WPF는 최상위 윈도우만 제외하고 나머지 컨트롤이나 Shape 등은 Direct3D를 이용해서 그린다.

<br>

### 4. UI 속성

- ContentControl 클래스에는 Button 클래스와 Window클래스가 포함되어있다.
- Children속성은 Panel 클래스를 상속받았다.

<br>

### 5. Window 클래스

- Window 클래스중에 SolidColorBrush, LinearGradientBrush, RadialGradientBrush를 다루어 본다.
- 2.1로 프로젝트를 구성한다.
  ```cs
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
              Width = 300; Height = 200;
  
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
              myWin0.Show(); myWin1.Show(); myWin2.Show(); myWin3.Show(); myWin4.Show(); myWin5.Show();
  
              Application myApp = new Application();
              myApp.Run(myWin0); myApp.Run(myWin1); myApp.Run(myWin2); myApp.Run(myWin3); myApp.Run(myWin4); myApp.Run(myWin5);
  
          }
      }
  }
  ```
- 결과  
  <img src="" width="70%">

<br>

### 6. Application 클래스

<img src="" width="70%">  

- Run() : WPF 응용프로그램 시작
- Run(Window) : 지정된 Window창을 열고 시작

<br>

### 7. 이미지 핸들러

- Ch 09를 참고할 것.
- 2.1를 통해 프로젝트를 만든다.
  ```cs
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
  ```
- 결과
  <img src="" width="70%">

<br><br><br>

# Ch 04. XAML

<br><br><br>

# Ch 05. Layout

<br><br><br>

# Ch 06. Content 및 Control

<br><br><br>

# Ch 07. Dependency Property

<br><br><br>

# Ch 08. Data Binding

<br><br><br>

# Ch 09. Routing Events 및 Command

<br><br><br>

# Ch 10. 다양한 Control 및 Element

<br><br><br>

# Ch 11. Resources

<br><br><br>

# Ch 12. Styles

<br><br><br>

# Ch 13. Control Templates

<br><br><br>

# Ch 14. Page Navigation 프로그램

<br><br><br>

# Ch 15. 다양한 Data Binding

<br><br><br>

# Ch 16. Tree, Tab, 그 외 다른 Control들

<br><br><br>

# Ch 17. Text 및 Documents

<br><br><br>

# Ch 18. WPF의 Graphic

<br><br><br>

# Ch 19. Animation

<br><br><br>

# Ch 20. Audio 및 Video

<br><br><br>

