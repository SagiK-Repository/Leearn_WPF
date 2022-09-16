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

### 0. Summary(요약)

- <img src="" width="70%">

<br>

### 1. Application, Window의 UI 구조

- Application 및 Window 각각의 방법을 비교한다.
- Program.cs
  ```cs
  using System;
  using System.Windows;
  using System.Windows.Controls;
  
  namespace _4_1.WPF__Win
  {
      class MyWindow : Window
      {
          public MyWindow()
          {
              Width = 300;
              Height = 200;
              StackPanel sp = new StackPanel();
              Button btn = new Button();
              TextBlock txt = new TextBlock();
  
              btn.Content = "Click Me";
              txt.Text = "illustrated WPF";
              sp.Children.Add(txt);
              sp.Children.Add(btn);
              Content = sp;
          }
      }
  
      internal class Program
      {
          [STAThread]
          static void Main(string[] args)
          {
              Application app = new Application();
              MyWindow win = new MyWindow();
              app.Run(win);
          }
      }
  }
  ```
- MainWindow.xaml
  ```xml
  <Window x:Class="_4_1_WPF_App_Win.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:_4_1_WPF_App_Win"
          mc:Ignorable="d"
          Title="MainWindow" Height="200" Width="300">
      <StackPanel>
          <TextBlock>Illustrated WPF</TextBlock>
          <Button>Click Me</Button>
      </StackPanel>
  </Window>
  ```
- XAML 파일로 UI구조를 설계한다면 더 간단해진다.


<br>

### 2. Attribute(속성) 추가 방법 4가지

- Object Element Syntax
  - `<Button Width="100" Height="50"> Click ME </Button>`
- Attribute Syntax
  - `<Button Width="100" Height="50"> </Button>`
  - `<Button Width="100" Height="50" />`
- Property Element Syntax : 속성들이 많아지면 복잡해지기 때문에 계층구조로 볼 수 있게 한다.
  ```xml
  <Button>
    <Button.Background>
        <LinearGradientBru Comsh StartPostiom="0,0" EndPoint="1,1">
            <GrandientStop Color="Red" Offsrt="0.0">
            <GrandientStop Color="Blue" Offsrt="1.0">
        </LinearGradientBrush/>
    </Button.Background>
    Click Me
  </Button>
  ```
- 부모의 속성을 사용할 때 Attached Property를 쓴다. `<Button Grid.Row="2"> Click </Button>`
- 2.1와 같이 프로젝트를 구성한다.
- 기본 Control들을 사용하기 위한 namespace
  - `xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"`는 namespace를 나타낸다. (System.Windows, System.Windows.Controls/Automation...)
  - `xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`는 System.Windows.Markup를 나타낸다.
  - x: => 프로젝트 템플릿, 샘플 코드 및 언어 기능의 설명서
  - d: => 디자이너 네임스페이스
  - mc: => 태그 호환성을 위해 사용된다.
- MainWindow.xaml
  ```xml
  <Window x:Class="_4_2.WPF_XAML_Attribute.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:_4_2.WPF_XAML_Attribute"
          mc:Ignorable="d"
          Title="MainWindow" Height="450" Width="800">
      <Grid>
          <Grid.RowDefinitions>
              <RowDefinition/>
              <RowDefinition/>
              <RowDefinition/>
              <RowDefinition/>
          </Grid.RowDefinitions>
          <Button Grid.Row="1" Grid.RowSpan="2">
              <Button.Background>
                  <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
                      <GradientStop Color="Red" Offset="0.0"/>
                      <GradientStop Color="Blue" Offset="1.0"/>
                  </LinearGradientBrush>
              </Button.Background>
              Click Me
          </Button>
      </Grid>
  </Window>
  ```
- 결과  
  <img src="">

<br>

### 3. Code-Behind 및 Object Names

- Button에 속성값으로 이름을 설정하는 방법 : `<Button Name = "myButton"> Hi </Button>`
- Name이 없는 클래스는 `<Button x:Name = "myButton"> Hi </Button>`
  - x:Name => code-behind에서 해당 item을 참조할 수 있는 field를 만들어 준다.
- MainWindow.xaml
  ```xml
  ...
        Title="MainWindow" Height="450" Width="800">
      <Grid>
          <Button Name="myButton"/>
      </Grid>
  </Window>
  ```
- MainWindow.xaml.cs
  ```cs
  using System.Windows;
  
  namespace _4_3.WPF_XAML_ObjectName
  {
      public partial class MainWindow : Window
      {
          public MainWindow()
          {
              InitializeComponent();
  
              this.myButton.Content = "Hi There";
          }
      }
  }
  ```
- Code-behind(MainWindow.xaml.cs)에서 해당 item을 참조할 수 있다.
- 결과  
  <img src="">

<br>

### 4. 다른 namespace 에서 class 사용하는 방법

- MainWindow.xaml에서 namespace를 참조하여 클래스를 구성한다.
- MainWindow.xaml.cs
  ```cs
  using System.Windows;
  
  namespace _4_3.WPF_XAML_ObjectName
  {
      public partial class MainWindow : Window
      {
          public MainWindow()
          {
              InitializeComponent();
  
              this.myButton.Content = "Hi There";
          }
      }
  }
  ```
- MainWindow.xaml
  ```xml
  <Window x:Class="_4_4.WPS_namespace_Class.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:ctl="clr-namespace:_4_4.WPS_namespace_Class"
          mc:Ignorable="d"
          Title="MainWindow" Height="450" Width="800">
      <Grid>
          <ctl:Mybutton>Hi There</ctl:Mybutton>
      </Grid>
  </Window>
  ```
- `xmlns:ctl="clr-namespace:_4_4.WPS_namespace_Class"`를 통해서 namespace "_4_4.WPS_namespace_Class"를 "ctl"이라는 이름으로 사용하여, `<ctl:Mybutton>Hi There</ctl:Mybutton>`를 통해 클래스를 사용하였다.
- 실행 결과  
  <img src="">

<br>

### 5. Markup Extensions

- Markup Extensions을 통해 사용자 지정 태그 확장한다.
  - `<Button Style="{StaticResource SomeStyle}">Click Me</Button>`
- MarkupExtension클래스를 상속받고 ProvideValues라는 추상 메소드를 Override 해주는 것으로 구현한다.
- 2가지 형태가 존재한다.
  - 생성자 parameter를 넣는 방법
    - `{ExtensionsClass Param1, Param2, ...}`
  - 속성/값 쌍을 넣는 방법
    - `{ExtensionsClass Property1=value1, Property2=value2, ...}`
- 3-1와 같은 프로젝트를 구성한다.
- MainWindow.xaml
  ```xml
  ...
          xmlns:stl="clr-namespace:MarkupExtensions"
          mc:Ignorable="d"
          Title="MainWindow" Height="450" Width="800">
      <Grid>
          <StackPanel>
              <Button Content="{stl:ShowTime First}"></Button>
              <Button Content="{stl:ShowTime Header=Second}"></Button>
          </StackPanel>
      </Grid>
  </Window>
  ```
- MainWindow.xaml.cs
  ```cs
  using System;
  using System.Windows;
  using System.Windows.Markup;
  
  namespace MarkupExtensions
  {
      class ShowTime : MarkupExtension
      {
          private string header = string.Empty;
          public string Header
          {
              get { return header; }
              set { header = value; }
          }
          public ShowTime() { }
          public ShowTime(string input)
          {
              header = input;
          }
          public override object ProvideValue(IServiceProvider serviceProvider)
          {
              return string.Format("{0}: {1}", header, DateTime.Now.ToLongTimeString());
          }
      }
  }
  ```
- 결과  
  <img src="">


<br>

### 6. White Space

- "<"나 "'"와 같은 특수문자를 출력한다.
- 생략된 공백을 나타낸다.
- `xml:space = "preserve"`를 속성으로 추가하면 공백이 생략되지 않는다.
  - `<Button xml:space = "preserve"> Click    Me </Button>`
- 특수문자는 다음으로 대체한다.
  | Character          | Character Entity |
  |--------------------|------------------|
  | Ampersand(&)       | \&amp;            |
  | Less than(<)       | \&lt;             |
  | Greater than(>)    | \&gt;             |
  | Nonebreaking space | \&nbsp;           |
  | Apostrophe(')      | \&apos;           |
  | Quotation mark(")  | \&quot;           |
- MainWindow.xaml
  ```xml
  ...
        Title="MainWindow" Height="450" Width="800">
    <StackPanel>
        <Button>Click &amp;Me</Button>
        <Button>Click               &lt;Me&gt;</Button>
        <Button>Click   &apos;Me&apos;</Button>
        <Button xml:space ="preserve">Click       &quot;Me&quot;</Button>
        <Button xml:space ="preserve">Click
        Me</Button>
    </StackPanel>
</Window>
  ```
- 결과  
  <img src="">


<br><br><br>



# Ch 05. Layout

### 0. Summary(요약)

- <img src="/uploads/a5a1330819eb09f39399c08de6e139d3/image.png" width="70%">

### 1. Layout 프로세스

- Layout Process 는 크게 두 단계로 나눌 수 있다.
  - Measure : 트리의 Window, Panel, child elements들의 사이즈를 측정한다.
    - 재귀적순서로 트리의 요소들이 동작하고 child 요소가 부모에게 이상적인 사이즈 값을 반환해준다.
  - Arrange : 부모가 자식들로부터 사이즈를 받으면, 실제로 각자에게 얼마를 줄지 계산해서 적당한 위치에 자식들을 위치시킨다.

- MainWindow.xaml
  ```xml
  <Window x:Class="_5.WPF_Layout.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_5.WPF_Layout"
        mc:Ignorable="d"
        Title="MainWindow" Height="900" Width="1800">
    <Grid ShowGridLines="True">
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        
        <!--Element 크기 설정-->
        <StackPanel Grid.Row="0" Grid.Column="0" >
            <!--Width가 125보다 작아지지 않고, 200보다 커지지 않는다.-->
            <Button MinWidth="125" MaxWidth="200">MinWidth="125" MaxWidth="200"</Button>
            <!--이미지의 Width는 반드시 150이다-->
            <Image Width="150" Source="3-5.jpg"></Image>
            <Button>Long Button String</Button>
        </StackPanel>

        <!--HorizontalAlignment 속성-->
        <StackPanel Grid.Row="0" Grid.Column="1">
            <Button>HorizontalAlignment</Button>
            <Button HorizontalAlignment="Left">Left</Button>
            <Button HorizontalAlignment="Center">Center</Button>
            <Button HorizontalAlignment="Right">Right</Button>
            <Button HorizontalAlignment="Stretch">HorizontalAlignment="Stretch"</Button>
        </StackPanel>

        <!--VeticalAlignment 속성-->
        <StackPanel Orientation="Horizontal" Grid.Row="0" Grid.Column="2">
            <Button VerticalAlignment="Top">Top</Button>
            <Button VerticalAlignment="Center">Center</Button>
            <Button VerticalAlignment="Bottom">Bottom</Button>
            <Button VerticalAlignment="Stretch">Stretch</Button>
        </StackPanel>

        <!--HorizontalContentAlignment 속성-->
        <StackPanel Grid.Row="0" Grid.Column="3">
            <Button>HorizontalContentAlignment</Button>
            <Button HorizontalContentAlignment="Left">HorizontalContentAlignment="Left"</Button>
            <Button HorizontalContentAlignment="Center">HorizontalContentAlignment="Center"</Button>
            <Button HorizontalContentAlignment="Right">HorizontalContentAlignment="Right"</Button>
            <Button HorizontalContentAlignment="Stretch">HorizontalContentAlignment="Stretch?"</Button>
        </StackPanel>

        <!--VerticalContentAlignment 속성-->
        <StackPanel Orientation="Horizontal" Grid.Row="0" Grid.Column="4">
            <Button VerticalContentAlignment="Top">Top</Button>
            <Button VerticalContentAlignment="Center">Center</Button>
            <Button VerticalContentAlignment="Bottom">Bottom</Button>
            <Button VerticalContentAlignment="Stretch">Stretch?</Button>
        </StackPanel>

        <!--ContentAlignment를 Stretch로 설정했을 때-->
        <StackPanel Orientation="Horizontal" Grid.Row="0" Grid.Column="5">
            <Button VerticalContentAlignment="Top">Top</Button>
            <Button VerticalContentAlignment="Center">Center</Button>
            <Button VerticalContentAlignment="Bottom">Bottom</Button>
            <Button VerticalContentAlignment="Stretch" Background="Aqua">
                <Button Margin="15">
                    Stretch?
                </Button>
            </Button>
        </StackPanel>

        <!--Visibility 속성 : Visible-->
        <StackPanel Grid.Row="1" Grid.Column="0">
            <Button Visibility="Visible">Visible</Button>
            <Button>Visibility="Visible"</Button>
        </StackPanel>

        <!--Visible 속성 : Hidden-->
        <StackPanel Grid.Row="1" Grid.Column="1">
            <Button Visibility="Hidden">Hidden</Button>
            <Button>Visibility="Hidden"</Button>
        </StackPanel>

        <!--Visible 속성 : Collapsed-->
        <StackPanel Grid.Row="1" Grid.Column="2">
            <Button Visibility="Collapsed">Collapsed</Button>
            <Button>Visibility="Collapsed"</Button>
        </StackPanel>
        
        <!--Padding-->
        <StackPanel Grid.Row="1" Grid.Column="3">
            <Button Padding="10">Padding="10"</Button>
            <Button Padding="10">Padding="10"</Button>
        </StackPanel>

        <!--Margin-->
        <StackPanel Grid.Row="1" Grid.Column="4">
            <Button Margin="10">Margin="10"</Button>
            <Button Margin="10">Margin="10"</Button>
        </StackPanel>
        
        <!--Padding & Margin-->
        <StackPanel Grid.Row="1" Grid.Column="5">
            <Button Padding="10" Margin="10">Padding="10" Margin="10"</Button>
            <Button Padding="10" Margin="10">Padding="10" Margin="10"</Button>
        </StackPanel>

        <!--Padding & Margin = "좌우, 상하"-->
        <StackPanel Grid.Row="2" Grid.Column="0">
            <Button Padding="5,10" Margin="5,20">Padding="5,10" Margin="5,20"</Button>
            <Button Padding="5,10" Margin="5,20">Padding="5,10" Margin="5,20"</Button>
        </StackPanel>

        <!--Padding & Margin = "좌, 상, 우, 하"-->
        <StackPanel Grid.Row="2" Grid.Column="1">
            <Button Padding="5,0,10,15">Padding="5,0,10,15"</Button>
            <Button Padding="5,0,20,30">Padding="5,0,20,30"</Button>
            <Button Padding="50,50,0,0">Padding="50,50,0,0"</Button>
        </StackPanel>


        <!--StackPanel-->
        <StackPanel Grid.Row="2" Grid.Column="2">
            <Button>StackPanel Btn1</Button>
            <Button>StackPanel Btn2</Button>
            <Button>StackPanel Btn3</Button>
            <Button>StackPanel Btn4</Button>
            <Button>StackPanel Btn5</Button>
            <Button>StackPanel Btn6</Button>
        </StackPanel>
        
        <!--WrapPanel-->
        <WrapPanel ItemHeight="90" Grid.Row="2" Grid.Column="3">
            <Button>Button 1</Button>
            <Button VerticalAlignment="Top">WrapPanel</Button>
            <Button VerticalAlignment="Center">Button 3</Button>
            <Button VerticalAlignment="Bottom">Button 4</Button>
            <Button VerticalAlignment="Stretch">Button 5</Button>
        </WrapPanel>

        <!--DockPanel-->
        <DockPanel LastChildFill="False" Grid.Row="2" Grid.Column="4">
            <Button>DockPanel</Button>
            <Button>Button 2</Button>
            <Button DockPanel.Dock="Top">DockPanel.Dock="Top"</Button>
            <Button DockPanel.Dock="Right">"Right'</Button>
        </DockPanel>

        <DockPanel LastChildFill="False" Grid.Row="2" Grid.Column="5">
            <Button DockPanel.Dock="Top">Btn 1</Button>
            <Button DockPanel.Dock="Right">Btn 2</Button>
            <Button DockPanel.Dock="Bottom">Btn 3</Button>
            <Button DockPanel.Dock="Left">Btn 4</Button>
            <Button DockPanel.Dock="Top">DockPanel 5</Button>
            <Button DockPanel.Dock="Right">Btn 6</Button>
            <Button DockPanel.Dock="Bottom">Btn 7</Button>
            <Button DockPanel.Dock="Left">Btn 8</Button>
            <Button DockPanel.Dock="Top">Btn 9</Button>
            <Button DockPanel.Dock="Right">Btn 10</Button>
            <Button DockPanel.Dock="Bottom">Btn 11</Button>
            <Button DockPanel.Dock="Left">Btn 12</Button>
        </DockPanel>

        <!--Grid-->
        <Grid Grid.Row="3" Grid.Column="0">
            <Grid.RowDefinitions>
                <RowDefinition/>
                <RowDefinition/>
                <RowDefinition/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Button Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="2">Button1</Button>
            <Button Grid.Row="1" Grid.Column="1" Grid.ColumnSpan="2" Grid.RowSpan="2">Button2</Button>
            <Button Grid.Row="2" Grid.Column="0" Grid.ColumnSpan="2">Button3</Button>
        </Grid>

        <!--Grid Absolute Sizing : Height와 Width 속성으로 설정-->
        <Grid Grid.Row="3" Grid.Column="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="60"/>
                <RowDefinition/>
                <RowDefinition/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="35"/>
                <ColumnDefinition Width="150"/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Button Grid.Row="0" Grid.Column="0">Grid</Button>
            <Button Grid.Row="1" Grid.Column="1">Button2</Button>
        </Grid>

        <!--Grid Automatic Sizing : 셀 Content에 맞게 설정-->
        <Grid ShowGridLines="True" Grid.Row="3" Grid.Column="2">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition/>
                <RowDefinition/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Button Grid.Row="0" Grid.Column="0">Grid Auto</Button>
            <Button Grid.Row="1" Grid.Column="1">Long Button Name</Button>
        </Grid>

        <!--Grid Proportional Sizing : 사용가능한 공간을 비례적으로 행과 열을 나눔-->
        <Grid ShowGridLines="True" Grid.Row="3" Grid.Column="3">
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Button Grid.Row="0" Grid.Column="0">Grid</Button>
            <Button Grid.Row="1" Grid.Column="1">Height="*"</Button>
        </Grid>

        <!--Grid Proportional Sizing-->
        <Grid Grid.Row="3" Grid.Column="4">
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="2*"/>
                <ColumnDefinition Width="3*"/>
                <ColumnDefinition Width="5*"/>
            </Grid.ColumnDefinitions>
            <Button Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="2">Height="*"</Button>
            <Button Grid.Row="1" Grid.Column="1" Grid.ColumnSpan="2" Grid.RowSpan="2">Width="2*,3*,5*"</Button>
        </Grid>

        <!--Splitter Bars-->
        <Grid Grid.Row="3" Grid.Column="5">
            <Grid.RowDefinitions>
                <RowDefinition/>
                <RowDefinition/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Button Grid.Row="0" Grid.Column="0">Button1</Button>
            <Button Grid.Row="1" Grid.Column="0">Button2</Button>
            <GridSplitter Grid.Row="0" Grid.Column="1"
  					Width="3"
  					Grid.RowSpan="2"
  					Background="Pink"
  					HorizontalAlignment="Center"
  					VerticalAlignment="Stretch">
            </GridSplitter>
            <Button Grid.Row="0" Grid.Column="2">GridSplitter</Button>
            <Button Grid.Row="1" Grid.Column="2">GridSplitter</Button>
        </Grid>

        <!--Shared Size Groups-->
        <Grid Grid.IsSharedSizeScope="True" Grid.Row="4" Grid.Column="0">
            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto" SharedSizeGroup="Column0"></ColumnDefinition>
                <ColumnDefinition Width="Auto"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="Auto" SharedSizeGroup="Column0"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <Button Grid.Row="0" Grid.Column="0">Button1</Button>
            <Button Grid.Row="1" Grid.Column="3">Button2</Button>
            <GridSplitter Grid.Row="0" Grid.Column="1"
                      Width="3"
                      Grid.RowSpan="2"
                      Background="Pink"
                      HorizontalAlignment="Center"
                      VerticalAlignment="Stretch">
            </GridSplitter>
        </Grid>


        <!--Canvas-->
        <Canvas Grid.Row="4" Grid.Column="1">
            <Button Canvas.Top="20" Canvas.Left="30" Canvas.ZIndex="5">Canvas.ZIndex="5"</Button>
            <Button Canvas.Top="20" Canvas.Right="30" Canvas.ZIndex="3">Canvas.ZIndex="3"</Button>
            <Button Canvas.Bottom="20" Canvas.Left="30">Canvas.ZIndex="0"</Button>
            <Button Canvas.Bottom="20" Canvas.Right="30">Canvas.ZIndex="0"</Button>
        </Canvas>


        <!--Canvas : 좌표계를 사용하여 원하는 위치에 요소를 배치한다.-->
        <Canvas Grid.Row="4" Grid.Column="2">
            <Button Canvas.Top="20" Canvas.Left="30" >Canvas.ZIndex="0"</Button>
            <Button Canvas.Top="20" Canvas.Right="30" >Canvas.ZIndex="0"</Button>
            <Button Canvas.Bottom="20" Canvas.Left="30">Canvas.ZIndex="0"</Button>
            <Button Canvas.Bottom="20" Canvas.Right="30">Canvas.ZIndex="0"</Button>
        </Canvas>


        <!--UniformGrid : UniformGrid의 모양이나 크기를 변경할지라도 항상 다른 셀들과 크기가 같다.-->
        <UniformGrid Rows="2" Columns="2" Grid.Row="4" Grid.Column="3">
            <Button>Button 1</Button>
            <Button>Button 2</Button>
            <Button>Button 3</Button>
            <Button>Button 4</Button>
        </UniformGrid>

        <!--Q1. 버튼 두 개를 생성하여 Button2를 클릭하면 Button1이 나타나고,
        Button2를 한번 더 클릭하면 Button1이 안보이게 하는 프로그램을 만든다.-->
        <StackPanel Grid.Row="4" Grid.Column="4">
            <Button Visibility="Hidden" Name="ErasableButton">Button1</Button>
            <Button Click="Button_Click">Hidden or Visible</Button>
        </StackPanel>
      </Grid>
  </Window>
  ```
- 결과  
  <img src="/uploads/4059d1e4cfadfc90b16ad8717bdfadf9/image.png">

<br><br><br>

# Ch 06. Content 및 Control

### 0. Summary(요약)

- <img src="http://build.mirero.co.kr:8099/images/WPF/chapter6/summary.jpg" width="70%">

<br>

### 1. 다양한 콘텐츠 적용 가능

- Control은 사용자가 상호작용할 수 있는 UI이다.
- <img src="http://build.mirero.co.kr:8099/images/WPF/chapter6/6_1.jpg" width="50%">

<br>

### 실습 0-0 Image Element

- Image를 솔루션 탐색기에 존재하는 프로젝트 경로에 넣는다. (폴더경로 포함)
- xaml 코드를 통해 이미지를 출력할 수 있다.
  ```xml
  <Grid>
    <Image Source="3-5.jpg"/>
    <Image Source="Pictures/3-5.jpg"/>
  </Grid>
  ```
- MainWindow.xaml.cs로도 이미지를 출력할 수 있다. (위 코드와 동일)
  ```cs
  public partial class MainWindow : Window
  {
      public MainWindow()
      {
          InitializeComponent();
          Uri uri = new Uri("Pictures/3-5.jpg", UriKind.Relative);
          BitmapImage bitmap = new BitmapImage(uri);
          Image image = new Image();
          image.Source = bitmap;

          Grid grid = new Grid();
          grid.Children.Add(image);
          Grid.SetRow(image, 0);
          Grid.SetColumn(image, 0);

          Content = grid;
      }
  }
  ```
- 결과  
  <img src="/uploads/57879142d4ea02d040fbfc0cf77994d4/image.png">

<br>

### 실습 0-1 ContentControls - Label Control

- Image를 솔루션 탐색기에 존재하는 프로젝트 경로에 넣는다. (폴더경로 포함)
  ```xml
    <StackPanel>
        <Label Content="WPF Example Image" FontWeight="Bold"/>
        <Label>
            <Image Source="3-5.jpg"></Image>
        </Label>
    </StackPanel>
  ```
- 결과  
  <img src="/uploads/7caf95a33096c8f42b24bcbf4818cf93/image.png">

<br>

### 실습 0-2 ContentControls - Label Control - Accelerator key

- Content 앞에 '_'를 넣으면 F가 Accelerator key로 할당되어 사용자가 firstName 요소를 가져올 수 있다. <kbd>Alt</kbd>+<kbd>F</kbd>를 누르면 커서가 firtstName 요소로 간다.
  ```xml
    <StackPanel>
        <Label Target="{Binding ElementName=firstName}">_First Name:</Label>
        <TextBox Name="firstName"></TextBox>

        <Label Target="{Binding ElementName=lastName}">_Last Name:</Label>
        <TextBox Name="lastName"></TextBox>
    </StackPanel>
  ```
- 결과  
  <img src="/uploads/d0049889bf2384258df51523067da92a/image.png">

<br>

### 실습 0-3 ContentControls - Button Control

- 버튼 이벤트 핸들러는 code-behind에 추가해야 한다.
- xaml 코드를 통해 버튼을 구성할 수 있다.
  ```xml
    <StackPanel>
        <Button Click="Button_Click">Click Me</Button>
    </StackPanel>
  ```
- MainWindow.xaml.cs로 이벤트를 구성한다.
  ```cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Button has been clicked", "Button Message");
        }
    }  
  ```
- 결과  
  <img src="/uploads/86c13813f0bb9cda514ad9af79478d8b/image.png">

<br>


### 실습 0-4 ContentControls - CheckBox, RadioButton Controls

- CheckBox나 RadioButton은 상태를 유지하는 Control이다.
- RadioButton은 선택되면 다른 RadioButton의 IsChecked상태가 unchecked가 된다.
- IsChecked 속성 : code-behind에서 라디오 버튼이나 체크박스가 체크가 되어있는지 확인할 수 있다.
- xaml 코드를 통해 CheckBox, RadioButton를 구성할 수 있다.
  ```xml
    <StackPanel>
        <CheckBox Name="cb1" Margin="5,10,0,0">Option 1</CheckBox>
        <CheckBox Name="cb2" Margin="5,0,0,0">Option 2</CheckBox>
        <RadioButton Name="rb1" Margin="5,10,0,0">One of Three</RadioButton>
        <RadioButton Name="rb2" Margin="5,0,0,0">Two of Three</RadioButton>
        <RadioButton Name="rb3" Margin="5,0,0,0">Three of Three</RadioButton>
    </StackPanel>
  ```
- 결과  
  <img src="/uploads/390ca50852012d110988f388ed6e61d6/image.png">

<br>


### 실습 1-0 ContentControls - Grouping RadioButtons

- Default로는 모든 RadioButton들은 부모 요소와 같은 그룹에 속해있다.
- GroupName 속성을 사용하여 그룹을 지정한다. (String)
- xaml 코드를 통해 Grouping RadioButtons를 구성할 수 있다.
  ```xml
     <StackPanel>
         <RadioButton Margin="5,0,5,0">Default1</RadioButton>
         <RadioButton Margin="5,0">Default2</RadioButton>

         <RadioButton GroupName="Group1" Margin="5,7,5,0">Group1-1</RadioButton>
         <RadioButton GroupName="Group1" Margin="5,0">Group1-2</RadioButton>

         <RadioButton GroupName="Group2" Margin="5,7,5,0">Group2-1</RadioButton>
         <RadioButton GroupName="Group2" Margin="5,0">Group2-1</RadioButton>
     </StackPanel>
  ```
- 결과  
  <img src="/uploads/cd1208ed68278e14b0959bea922a37f3/image.png">

<br>

### Window 클래스

- Window 클래스는 ContentControl 클래스의 상속을 받는다.
  | Name                  | Method or Property | Purposes                                            |
  |-----------------------|--------------------|-----------------------------------------------------|
  | Show                  | Method             | 창을 연 후 새로 열린 창이 닫힐 때까지 기다리지 않고 반환된다.                |
  | ShowDialog            | Method             | 창을 연 후 새로 열린 창이 닫힌 경우에만 반환된다.                       |
  | Hide                  | Method             | 창이 표시되지 않게 한다.                                      |
  | Topmost               | Property           | 창을 맨 위에 표시할지 여부를 설정한다. 맨위에 있으면 true, 그렇지 않으면 false. |
  | ShowInTaskBar         | Property           | 창이 작업표시줄에 있으면 true, 그렇지 않으면 false.                  |
  | WindowStartupLocation | Property           | 창이 처음 표시될때의 위치를 설정한다.                               |

<br>


### 실습 1-1 Window Ownership

- 프로그램은 여러 개의 Window 창을 생성할 수 있다.
- 윈도우들은 독립적이거나, 다른 윈도우창을 소유할 수 있다. (Child Window 설정)
- Child Window를 만들기 위해서는, Owner 속성을 owner window로 참조해 주면 된다.
- xaml 코드를 통해 버튼을 하나 구성한다.
  ```xml
    <Grid>
        <Button Click="Button_Click" VerticalAlignment="Top">
            Create Other Windows
        </Button>
    </Grid>
  ```
- MainWindow.xaml.cs로 Button_Click 이벤트를 구성한다.
  ```cs
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Window w1 = new Window();
        w1.Background = Brushes.AliceBlue;
        w1.Title = "Win 1";
        w1.Height = 120;
        w1.Width = 250;
        w1.Content = "Independent Window";
        w1.Show();
        
        Window w2 = new Window();
        w2.Background = Brushes.PaleVioletRed;
        w2.Title = "Win 2";
        w2.Height = 120;
        w2.Width = 250;
        w2.Content = "ChildWindow";
        w2.Owner = this;
        w2.Show();
    }
  ```
- 결과
  - MainWindow를 닫으면 Win2도 닫히고, 최소화시키면 Win2도 최소화 되는 것을 확인다.  
  <img src="/uploads/faefb1e0cac96f9210e94bc55f16e290/image.png">

<br>


### 실습 1-2 Window - Modal Dialog Boxes

- Modal dialog(Modal dialog box)는 특정 정보를 표시하거나 사용자로부터 정보를 수집하는 데 초점을 맞춘 창이다.
- Show()를 호출하여 표시하는 방법 대신, ShowDialog() 메소드를 사용한다.
- Modal dialog이 실행되면 다른 작업을 못한다. dialog 창을 닫으면 다른 작업을 시작할 수 있다.
- 프로젝트 > 추가 > 새항목 > 창(WPF) > XAML이름은 "MyDialog"로 한다.
- MainWindow.xaml 코드를 통해 버튼을 구성한다.
  ```xml
    <Grid>
        <Button Click="Button_Click" VerticalAlignment="Top">
            Create Dialog
        </Button>
    </Grid>
  ```
- MainWindow.xaml.cs로 Button_Click 이벤트를 구성한다.
  ```cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyDialog dlg = new MyDialog();
            string result = (true == dlg.ShowDialog())
                ? "Ok Clicked."
                : "Cancel";
            MessageBox.Show(result, "Result"); 
        }
    }
  ```
- MyDialog.xaml
  ```xml
    <Grid>
        <Button Click="Button_Click" VerticalAlignment="Top">
            Create Dialog
        </Button>
    </Grid>
  ```
- MainWindow.xaml.cs로 Button_Click 이벤트를 구성한다.
  ```cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyDialog dlg = new MyDialog();
            string result = (true == dlg.ShowDialog())
                ? "Ok Clicked."
                : "Cancel";
            MessageBox.Show(result, "Result"); 
        }
    }
  ```
- 결과  
  <img src="/uploads/4cdc0b8cae73786e2d4e8121dcd14835/image.png">  
  <img src="/uploads/38358edf1a4a0e8719f564aa5d1dbd9e/image.png">

<br>


### 실습 1-3 Window - MessageBox Dialog Box

- MessageBox 클래스는 사용자에게 메시지, 오류 또는 경고를 표시한다.
- modal box이기 때문에 프로그램을 계속하기 전에 대화상자에 주소를 지정해야 한다.
- xaml 코드를 통해 버튼을 구성한다.
  ```xml
    <StackPanel>
        <Button Click="Button_Click">Click Me</Button>
    </StackPanel>
  ```
- MainWindow.xaml.cs로 이벤트를 구성한다.
  ```cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Button has been clicked", "Button Message", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }
    }  
  ```
- 결과  
  <img src="/uploads/2ec15d2534e00c39e5dc4aa985025330/image.png">

<br>


### 실습 1-4 Window - ScrollViewer

- ScrollViewer는 Content가 너무 커서 할당된 영역에 표시할 수 없는 경우 스크롤 막대를 Content element에 추가한다.
- xaml 코드를 통해 스크롤을 구성할 수 있다.
  ```xml
    <Grid>
        <ScrollViewer>
            <StackPanel>
                <Button>Button1</Button>
                <Button>Button2</Button>
                <Button>Button3</Button>
                <Button>Button4</Button>
                <Button>Button5</Button>
                <Button>Button6</Button>
                <Button>Button7</Button>
                <Button>Button8</Button>
                <Button>Button9</Button>
            </StackPanel>
        </ScrollViewer>
    </Grid>
  ```
- 결과  
  <img src="/uploads/9c032bcd0e846babf03bc0feb9ccca42/image.png">

<br>


### 실습 2-0 Window - ScrollViewer Image

- ScrollViewer에 Image포함.
- xaml 코드를 통해 스크롤 이미지를 구성할 수 있다.
  ```xml
     <Grid>
         <ScrollViewer>
             <Image Source="ChurchSmall.jpg"/>
         </ScrollViewer>
     </Grid>
  ```
- 결과  
  <img src="/uploads/18f964fef6537c03cd102c36af2c6da8/image.png">

<br>

### HeaderedContentControl

- HeaderedContentControl 클래스는 ContentControl 클래스에서 파생된다.
- Header 속성의 content는 main content의 제목으로 사용된다.

<br>

### 실습 2-1 HeaderedContentControl - GroupBox Element

- GroupBox는 content 주변에 테두리를 배치하고 header를 왼쪽 상단에 배치한다.
- GroupBox에서 BorderThickness 및 Background를 설정할 수 있다.
- 헤더 자체에 content가 포함될 수 있다.
- xaml 코드를 통해 버튼을 구성할 수 있다.
  ```xml
    <GroupBox Header="Grouped Things" Margin="5">
        <StackPanel>
            <Image Margin="3" HorizontalAlignment="Left" Height="50" Source="3-5.jpg">
            </Image>
            <Button Margin="3">Btn 1</Button>
            <Button Margin="3">Btn 2</Button>
        </StackPanel>
    </GroupBox>
  ```
- 결과  
  <img src="/uploads/d486cf6cab38503a7a1162291fe44ad5/image.png">

<br>


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

