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
  | ------------------ | ---------------- |
  | Ampersand(&)       | \&amp;           |
  | Less than(<)       | \&lt;            |
  | Greater than(>)    | \&gt;            |
  | Nonebreaking space | \&nbsp;          |
  | Apostrophe(')      | \&apos;          |
  | Quotation mark(")  | \&quot;          |
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

- <img src="" width="70%">

<br>

### 1. 다양한 콘텐츠 적용 가능

- Control은 사용자가 상호작용할 수 있는 UI이다.
- <img src="" width="50%">

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
  | Name                  | Method or Property | Purposes                                                                        |
  | --------------------- | ------------------ | ------------------------------------------------------------------------------- |
  | Show                  | Method             | 창을 연 후 새로 열린 창이 닫힐 때까지 기다리지 않고 반환된다.                   |
  | ShowDialog            | Method             | 창을 연 후 새로 열린 창이 닫힌 경우에만 반환된다.                               |
  | Hide                  | Method             | 창이 표시되지 않게 한다.                                                        |
  | Topmost               | Property           | 창을 맨 위에 표시할지 여부를 설정한다. 맨위에 있으면 true, 그렇지 않으면 false. |
  | ShowInTaskBar         | Property           | 창이 작업표시줄에 있으면 true, 그렇지 않으면 false.                             |
  | WindowStartupLocation | Property           | 창이 처음 표시될때의 위치를 설정한다.                                           |

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

### 실습 2-2 HeaderedContentControl - GroupBox Element2

- xaml 코드를 통해 다음과 같이 구성할 수 있다.
  ```xml
  <GroupBox Margin="5" Grid.Row="2" Grid.Column="2">
      <GroupBox.Header>
          <Image Margin="3" HorizontalAlignment="Left" Height="50" Source="3-5.jpg">
          </Image>
      </GroupBox.Header>
      <StackPanel>
          <Button Margin="3">Btn 1</Button>
          <Button Margin="3">Btn 2</Button>
      </StackPanel>
  </GroupBox>
  ```
- 결과  
  <img src="/uploads/e88a955bf812116c26ab96dd17f5f653/image.png">



<br>

### 실습 2-3 HeaderedContentControl - Expander Control

- Expander Control은 button을 클릭하여 내용을 표시하거나 숨길 수 있는 GroupBox와 같다.
- GroupBox와 같이 Header와 Content를 포함한다.
- xaml을 다음과 같이 작성한다.
  ```xml
  <Grid Grid.Row="2" Grid.Column="3">
      <Expander Header="Important Buttons">
          <ScrollViewer>
              <StackPanel>
                  <Button>Button 1</Button>
                  <Button>Button 2</Button>
                  <Button>Button 3</Button>
                  <Button>Button 4</Button>
                  <Button>Button 5</Button>
                  <Button>Button 6</Button>
              </StackPanel>
          </ScrollViewer>
      </Expander>
  </Grid>
  ```
- 결과  
  <img src="/uploads/867db0cfbc2e64070aeca53150d363fa/image.png">

<br>

### ItemsControl

- ContentControl 클래스는 하나의 content item만 포함할 수 있지만, ItemsControl 클래스는 원하는 수의 content item들을 가질 수 있다.

<br>

### 실습 2-4 ItemsControl - ListBox Control

- ListBox는 사용자에게 표시되는 item들의 모음으로 사용자가 하나 이상의 항목을 선택할 수 있다.
- 명시적으로 ListBoxItems 를 생성하지 않더라도 ListBox에 item을 배치할 수 있다. (TextBlock, Button 등)
- xaml 코드를 통해 다음과 같이 구현한다.
  ```xml
  <ListBox Grid.Row="2" Grid.Column="4">
      <ListBoxItem>Sweetie</ListBoxItem>
      <ListBoxItem>Darwin</ListBoxItem>
      <ListBoxItem>Florence</ListBoxItem>
      <TextBlock>Sweetie</TextBlock>
      <TextBlock>Darwin</TextBlock>
      <Button>Florence</Button>
  </ListBox>
  ```
- 결과  
  <img src="/uploads/72f7398708fdb5edc03297bfc759b539/image.png">

<br>

### 실습 3-0 ItemsControl - Checking the Selection

- 사용자가 ListBox에서 item을 선택한 경우, ListBox의 SelectedItem 속성을 사용하여 선택한 항목을 확인할 수 있다.
- 이 속성은 처음 선택한 항목에 대한 개체 참조를 반환하거나 항목이 선택되지 않은 경우에 null을 반환한다.
- xaml 코드를 통해 다음과 같이 구현한다.
  ```xml
  <StackPanel Grid.Row="3" Grid.Column="0">
      <ListBox Name="listboxCats" HorizontalAlignment="Left" Width="100">
          <ListBoxItem>Sweetie</ListBoxItem>
          <ListBoxItem>Darwin</ListBoxItem>
          <ListBoxItem>Florence</ListBoxItem>
      </ListBox>
      <Button Click="Button_Click30" HorizontalAlignment="Left" 
          Width="100" Padding="10,3" Margin="0,5">Enter</Button>
  </StackPanel>
  ```
- MainWindow.xaml.cs 코드는 다음과 같이 구현한다.
  ```cs
  private void Button_Click30(object sender, RoutedEventArgs e)
  {
      object obj = listboxCats.SelectedItem;
      string selected = (obj == null)
          ? "No item selected."
          : (string)((ListBoxItem)obj).Content;
  
      MessageBox.Show(selected, "Selected Item");
  }
  ```
- 결과  
  <img src="/uploads/01bd1080688f2b0e26df27426319c56f/image.png">

<br>


### 실습 3-1 ItemsControl - Notification of Changed Selection

- ListBox에서 선택한 item이 변경될 때마다 ListBox의 SelectionChanged 이벤트가 발생한다. 
- code-behind에서 이벤트 핸들러를 생성할 때 이벤트 핸들러의 이름을 이벤트에 할당할 수 있으며 이벤트가 발생할 때 이벤트 핸들러를 호출한다.
- xaml 코드를 통해 다음과 같이 구현한다.
  ```xml
  <StackPanel Grid.Row="3" Grid.Column="1">
      <ListBox Name="listboxDogs"
           HorizontalAlignment="Left" Width="100"
           SelectionChanged="listboxDogs_SelectionChanged">
          <ListBoxItem>Princess</ListBoxItem>
          <ListBoxItem>Avonlea</ListBoxItem>
          <ListBoxItem>Brumby</ListBoxItem>
      </ListBox>
  </StackPanel>
  ```
- MainWindow.xaml.cs 코드를 통해 다음과 같이 구현한다.
  ```cs
  private void listboxDogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
      ListBox lb = sender as ListBox;
      ListBoxItem lbi = lb.SelectedItem as ListBoxItem;
      MessageBox.Show(lbi.Content.ToString(), "Dog Selected");
  }
  ```
- 결과  
  <img src="/uploads/14c5d93621eda0c88a8c7927d22cfbda/image.png">

<br>


### 실습 3-2 ItemsControl - Multiple Selections

- ListBox에서 여러 개의 item들을 선택 가능하게 하는 옵션들이 있다. SelectionMode 속성을 사용한다.
  - Single : 사용자가 item을 하나만 선택할 수 있다. Default.
  - Extended
    - 첫 번째 item 이후에 추가 item을 선택하려면 Ctrl키를 누른 상태에서 item을 선택해야 한다.
    - item의 범위를 선택하려면 처음 항목을 선택하고 Shift키를 누른 상태에서 마지막 항목을 선택해야 한다.
  - Multiple : 사용자는 클릭하기만 하면 여러 item을 선택할 수 있고, 특수키를 누르지 않아도 된다.
- xaml 코드를 통해 다음과 같이 구현한다.
  ```xml
  <StackPanel Grid.Row="3" Grid.Column="2">
      <ListBox Name="listboxCatss" HorizontalAlignment="Left" Width="100" SelectionMode="Multiple">
          <ListBoxItem>Sweetie</ListBoxItem>
          <ListBoxItem>Darwin</ListBoxItem>
          <ListBoxItem>Florence</ListBoxItem>
      </ListBox>
      <Button Click="Button_Click32" HorizontalAlignment="Left" 
          Width="100" Padding="10,3" Margin="0,5">Enter</Button>
  </StackPanel>
  ```
- MainWindow.xaml.cs 코드를 다음과 같이 구현한다.
  ```cs
  private void Button_Click32(object sender, RoutedEventArgs e)
  {
      foreach (ListBoxItem item in listboxCatss.Items)
      {
          if (item.IsSelected)
              MessageBox.Show((string)item.Content, "Is Selected");
      }
  }
  ```
- 결과  
  <img src="(/uploads/69097050e5952bdf1674022dbbc21aeb/image.png">

<br>


### 실습 3-3 ItemsControl - ComboBox Control

- ComboBox는 선택한 item 하나만 표시하는 ListBox와 같다.
- 끝에 있는 화살표를 클릭하면 list box가 컨트롤에서 drop 되어서 사용자가 목록에서 다른 item을 선택할 수 있다.
- xaml 코드를 통해 다음과 같이 구현한다.
  ```xml
  <Canvas Grid.Row="3" Grid.Column="3">
      <ComboBox Name="Example" SelectedIndex="0" Width="134">
          <ComboBoxItem>First Item</ComboBoxItem>
          <ComboBoxItem>Second Item</ComboBoxItem>
          <ComboBoxItem>Third Item</ComboBoxItem>
      </ComboBox>
      <Button Padding="10,3" Canvas.Right="5" Canvas.Bottom="5"
      HorizontalAlignment="Right" Click="Button_Click33">Enter</Button>
  </Canvas>
  ```
- MainWindow.xaml.cs 코드를 다음과 같이 구현한다.
  ```cs
  private void Button_Click33(object sender, RoutedEventArgs e)
  {
      MessageBox.Show(Example.SelectionBoxItem.ToString(), "Selected");
  }
  ```
- 결과  
  <img src="/uploads/9316f67e97ecc329d895970e83b45e2b/image.png">

<br>


### 실습 3-4 ItemsControl - Selecting and Entering Items

- xaml 코드를 통해 다음과 같이 구현한다.
  ```xml
  <Canvas Grid.Row="3" Grid.Column="4">
      <ComboBox Name="Example0" SelectedIndex="0" Width="134" IsEditable="true">
          <ComboBoxItem>First Item</ComboBoxItem>
          <ComboBoxItem>Second Item</ComboBoxItem>
          <ComboBoxItem>Third Item</ComboBoxItem>
      </ComboBox>
      <Button Padding="10,3" Canvas.Right="5" Canvas.Bottom="5"
      HorizontalAlignment="Right" Click="Button_Click34">Enter</Button>
  </Canvas>
  ```
- MainWindow.xaml.cs 코드를 다음과 같이 구현한다.
  ```cs
  private void Button_Click34(object sender, RoutedEventArgs e)
  {
      MessageBox.Show(Example0.Text.ToString(), "Selected");
  }
  ```
- 결과  
  <img src="/uploads/8e60bb55123b1e32713caa6268db6e67/image.png">

<br>

### 실습 종합

<details><summary>종합</summary>


- xaml
  ```xml
  <Window x:Class="_6.WPF_Content_Control.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:_6.WPF_Content_Control"
          mc:Ignorable="d"
          Title="MainWindow" Height="450" Width="800">
      <Grid ShowGridLines="True">
          <Grid.RowDefinitions>
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
          </Grid.ColumnDefinitions>
  
          <!--0-0 Image Element-->
          <Grid Grid.Row="0" Grid.Column="0">
              <Image Source="3-5.jpg"/>
          </Grid>
  
          <!--0-1 ContentControls - Label Control-->
          <StackPanel Grid.Row="0" Grid.Column="1">
              <Label Content="WPF Example Image" FontWeight="Bold"/>
              <Label>
                  <Image Source="3-5.jpg"></Image>
              </Label>
          </StackPanel>
  
          <!--0-2 ContentControls - Label Control - Accelerator key-->
          <StackPanel Grid.Row="0" Grid.Column="2">
              <Label Target="{Binding ElementName=firstName}">_First Name:</Label>
              <TextBox Name="firstName"></TextBox>
  
              <Label Target="{Binding ElementName=lastName}">_Last Name:</Label>
              <TextBox Name="lastName"></TextBox>
          </StackPanel>
  
          <!--03 Button Control-->
          <StackPanel Grid.Row="0" Grid.Column="3">
              <Button Click="Button_Click">Click Me</Button>
          </StackPanel>
  
          <!--04 CheckBox, RadioButton Controls-->
          <StackPanel Grid.Row="0" Grid.Column="4">
              <CheckBox Name="cb1" Margin="5,10,0,0">Option 1</CheckBox>
              <CheckBox Name="cb2" Margin="5,0,0,0">Option 2</CheckBox>
              <RadioButton Name="rb1" Margin="5,10,0,0">One of Three</RadioButton>
              <RadioButton Name="rb2" Margin="5,0,0,0">Two of Three</RadioButton>
              <RadioButton Name="rb3" Margin="5,0,0,0">Three of Three</RadioButton>
          </StackPanel>
  
          <!--10 Grouping RadioButtons-->
          <StackPanel Grid.Row="1" Grid.Column="0">
              <RadioButton Margin="5,0,5,0">Default1</RadioButton>
              <RadioButton Margin="5,0">Default2</RadioButton>
  
              <RadioButton GroupName="Group1" Margin="5,7,5,0">Group1-1</RadioButton>
              <RadioButton GroupName="Group1" Margin="5,0">Group1-2</RadioButton>
  
              <RadioButton GroupName="Group2" Margin="5,7,5,0">Group2-1</RadioButton>
              <RadioButton GroupName="Group2" Margin="5,0">Group2-1</RadioButton>
          </StackPanel>
  
          <!--11 Window Ownership-->
          <Grid Grid.Row="1" Grid.Column="1">
              <Button Click="Button_Click1" VerticalAlignment="Top">
                  Create Other Windows
              </Button>
          </Grid>
  
          <!--12 Modal Dialog Boxes-->
          <Grid Grid.Row="1" Grid.Column="2">
              <Button Click="Button_Click2" VerticalAlignment="Top">
                  Create Dialog
              </Button>
          </Grid>
  
          <!--13 MessageBox Dialog Box-->
          <StackPanel Grid.Row="1" Grid.Column="3">
              <Button Click="Button_Click4">MessageBox</Button>
          </StackPanel>
  
          <!--14 ScrollViewer-->
          <Grid Grid.Row="1" Grid.Column="4">
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
  
          <!--20 ScrollViewer Image-->
          <Grid Grid.Row="2" Grid.Column="0">
              <ScrollViewer>
                  <Image Source="Pictures/2-2.jpg"/>
              </ScrollViewer>
          </Grid>
  
          <!--21 HeaderedContentControl - GroupBox Element-->
          <GroupBox Header="Grouped Things" Margin="5" Grid.Row="2" Grid.Column="1">
              <StackPanel>
                  <Image Margin="3" HorizontalAlignment="Left" Height="50" Source="3-5.jpg">
                  </Image>
                  <Button Margin="3">Btn 1</Button>
                  <Button Margin="3">Btn 2</Button>
              </StackPanel>
          </GroupBox>
          
          <!--22 HeaderedContentControl - GroupBox Element 2-->
          <GroupBox Margin="5" Grid.Row="2" Grid.Column="2">
              <GroupBox.Header>
                  <Image Margin="3" HorizontalAlignment="Left" Height="50" Source="3-5.jpg">
                  </Image>
              </GroupBox.Header>
              <StackPanel>
                  <Button Margin="3">Btn 1</Button>
                  <Button Margin="3">Btn 2</Button>
              </StackPanel>
          </GroupBox>
  
          <!--23 HeaderedContentControl - Expander Control-->
          <Grid Grid.Row="2" Grid.Column="3">
              <Expander Header="Important Buttons">
                  <ScrollViewer>
                      <StackPanel>
                          <Button>Button 1</Button>
                          <Button>Button 2</Button>
                          <Button>Button 3</Button>
                          <Button>Button 4</Button>
                          <Button>Button 5</Button>
                          <Button>Button 6</Button>
                      </StackPanel>
                  </ScrollViewer>
              </Expander>
          </Grid>
  
          <!--24 ItemsControl - ListBox Control -->
          <ListBox Grid.Row="2" Grid.Column="4">
              <ListBoxItem>Sweetie</ListBoxItem>
              <ListBoxItem>Darwin</ListBoxItem>
              <ListBoxItem>Florence</ListBoxItem>
              <TextBlock>Sweetie</TextBlock>
              <TextBlock>Darwin</TextBlock>
              <Button>Florence</Button>
          </ListBox>
  
          <!--30 ItemsControl - Checking the Selection -->
          <StackPanel Grid.Row="3" Grid.Column="0">
              <ListBox Name="listboxCats" HorizontalAlignment="Left" Width="100">
                  <ListBoxItem>Sweetie</ListBoxItem>
                  <ListBoxItem>Darwin</ListBoxItem>
                  <ListBoxItem>Florence</ListBoxItem>
              </ListBox>
              <Button Click="Button_Click30" HorizontalAlignment="Left" 
                  Width="100" Padding="10,3" Margin="0,5">Enter</Button>
          </StackPanel>
  
          <!--31 ItemsControl - Notification of Changed Selection -->
          <StackPanel Grid.Row="3" Grid.Column="1">
              <ListBox Name="listboxDogs"
                   HorizontalAlignment="Left" Width="100"
                   SelectionChanged="listboxDogs_SelectionChanged">
                  <ListBoxItem>Princess</ListBoxItem>
                  <ListBoxItem>Avonlea</ListBoxItem>
                  <ListBoxItem>Brumby</ListBoxItem>
              </ListBox>
          </StackPanel>
  
          <!--32 ItemsControl - Multiple Selections -->
          <StackPanel Grid.Row="3" Grid.Column="2">
              <ListBox Name="listboxCatss" HorizontalAlignment="Left" Width="100" SelectionMode="Multiple">
                  <ListBoxItem>Sweetie</ListBoxItem>
                  <ListBoxItem>Darwin</ListBoxItem>
                  <ListBoxItem>Florence</ListBoxItem>
              </ListBox>
              <Button Click="Button_Click32" HorizontalAlignment="Left" 
                  Width="100" Padding="10,3" Margin="0,5">Enter</Button>
          </StackPanel>
  
          <!--33 ItemsControl - ComboBox Control -->
          <Canvas Grid.Row="3" Grid.Column="3">
              <ComboBox Name="Example" SelectedIndex="0" Width="134">
                  <ComboBoxItem>First Item</ComboBoxItem>
                  <ComboBoxItem>Second Item</ComboBoxItem>
                  <ComboBoxItem>Third Item</ComboBoxItem>
              </ComboBox>
              <Button Padding="10,3" Canvas.Right="5" Canvas.Bottom="5"
              HorizontalAlignment="Right" Click="Button_Click33">Enter</Button>
          </Canvas>
  
          <!--34 ItemsControl - ComboBox Control -->
          <Canvas Grid.Row="3" Grid.Column="4">
              <ComboBox Name="Example0" SelectedIndex="0" Width="134" IsEditable="true">
                  <ComboBoxItem>First Item</ComboBoxItem>
                  <ComboBoxItem>Second Item</ComboBoxItem>
                  <ComboBoxItem>Third Item</ComboBoxItem>
              </ComboBox>
              <Button Padding="10,3" Canvas.Right="5" Canvas.Bottom="5"
              HorizontalAlignment="Right" Click="Button_Click34">Enter</Button>
          </Canvas>
  
  
      </Grid>
  </Window>

  ```
- xaml.cs
  ```cs
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Media;

  namespace _6.WPF_Content_Control
  {
      /// <summary>
      /// MainWindow.xaml에 대한 상호 작용 논리
      /// </summary>
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
  
          private void Button_Click1(object sender, RoutedEventArgs e)
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
  
          private void Button_Click2(object sender, RoutedEventArgs e)
          {
              MyDialog dlg = new MyDialog();
              string result = (true == dlg.ShowDialog())
                  ? "Ok Clicked."
                  : "Cancel";
              MessageBox.Show(result, "Result");
          }
  
          private void Button_Click4(object sender, RoutedEventArgs e)
          {
              MessageBox.Show(
                  "The Button has been clicked",
                  "Button Message",
                  MessageBoxButton.OKCancel,
                  MessageBoxImage.Information);
          }
  
          private void Button_Click30(object sender, RoutedEventArgs e)
          {
              object obj = listboxCats.SelectedItem;
              string selected = (obj == null)
                  ? "No item selected."
                  : (string)((ListBoxItem)obj).Content;
  
              MessageBox.Show(selected, "Selected Item");
          }
  
          private void listboxDogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              ListBox lb = sender as ListBox;
              ListBoxItem lbi = lb.SelectedItem as ListBoxItem;
              MessageBox.Show(lbi.Content.ToString(), "Dog Selected");
          }
  
          private void Button_Click32(object sender, RoutedEventArgs e)
          {
              foreach (ListBoxItem item in listboxCatss.Items)
              {
                  if (item.IsSelected)
                      MessageBox.Show((string)item.Content, "Is Selected");
              }
          }
  
          private void Button_Click33(object sender, RoutedEventArgs e)
          {
              MessageBox.Show(Example.SelectionBoxItem.ToString(), "Selected");
          }
  
          private void Button_Click34(object sender, RoutedEventArgs e)
          {
              MessageBox.Show(Example0.Text.ToString(), "Selected");
          }
      }
  }
  ```

</details>


<br><br><br>

# Ch 07. Dependency Property

### 0. Summary(요약)

- <img src="" width="70%">

<br>

### 1. Property와 새로운 패러다임

- 표준속성 (Property)
  - 속성(Property)은 일반적으로 클래스의 private field와 연결되며 다른 클래스에 해당 field를 접근할 수 있게 한다. 이 field를 backing field라고 한다.
  - 속성은 클래스의 functional member이다. 즉, 코드를 실행한다.
    - 값을 속성에 할당할 때, 이 값은 set accessor(접근자) 에게 전달되며 일반적으로 backing field에 할당된다.
    - 속성에서 읽어올 때 get accessor(접근자) 는 backing field에 반환된다.
  - get, set 접근자는 backing field를 설정 및 반환뿐만 아니라 어떤 코드를 넣던지 실행할 수 있다. 유일한 제약조건은 get접근자가 값을 반환(return) 해야 하고 올바른 type이어야 한다는 것이다.
  - 예시  
    ```cs
    class MyClass {
      private int _myProp; // Backing field
      public int MyProp { get; set; } // Property
    }
    ```
- 의존 속성(Dependency Property)
  - WPF는 simple field를 사용하지 않는 새로운 패턴을 도입하고 기능을 추가한다.
  - 새로운 유형의 Property를 Dependency Property(의존 속성)라고 한다.
    - Dependency property의 값은 simple field에 저장되지 않지만, 필요에 의해 결정된다.
    - Dependency property의 값은 코드에서 새 값을 할당하지 않더라도 특정 시간에 default값, 데이터 바인딩, 다른 속성들의 값, 사용자 기본 설정 및 기타 다른 요인에 따라 달라질 수 있다.
    - WPF property system은 모든 Element를 추적하고 이러한 속성들을 호출할 때 값을 결정하는 역할을 한다.
    - 코드나 마크업(XAML)에서 dependency property를 사용하는 구문은 dependency property가 아닌 속성을 사용하는 구문과 동일하다. 이 책의 시작부터 본 WPF 대부분의 속성이 dependency 속성이었다.

<br>

### 예제 1 Dependency Property

- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <GroupBox FontWeight="Bold" Grid.Row="0" Grid.Column="0">
      <GroupBox.Header>
          Buttons
      </GroupBox.Header>
      <StackPanel>
          <Button FontWeight="Medium">Button1</Button>
          <Button>Button2</Button>
      </StackPanel>
  </GroupBox>
  ```
- 다음과 같이 WPF Property System에서 Bold의 값 을 상속받는다.  
  <img src="/uploads/e55442793e77c11d83ac3114ff3069ae/image.png" width="50%">

<br>

### 2. Property 값 결정

- Dependency property(의존 속성)의 값을 결정하려면 WPF property system이 가능한 여러 평가를 수행해야 한다.
  <img src="/uploads/9d53a3608966d8ad01f2d86cb2d74244/image.png" width="50%">

<br>

### 3. Dependency Property의 Infrastructure

- Dependency property 아키텍처는 DependencyProperty 및 DependencyObject 두 클래스의 협업을 기반으로 한다.
  - DependencyProperty 클래스의 인스턴스를 dependency property identifier라고 하며, 특정 의존 속성의 특성을 나타낸다. 이 값은 속성값이 아니라 속성에 대한 특성 또는 metadata를 나타낸다.
  - DependencyObject 클래스의 object에는 WPF property 시스템과 상호작용하여 특정 의존 속성의 값을 가져오고 설정하는 infrastructure가 포함되어있다.

<br>

### 4. 사용자 정의 Dependency Property

- MainWindow.xaml.cs를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      //Dependency Property Field
      // 클래스는 의존 속성 식별자에 대한 참조를 포함할 의존 속성 유형의 필드를 선언해야 한다.
      public static readonly DependencyProperty SidesProperty;
      //Dependency Property CLR Wrapper
      public int Sides
      {
          get { return (int)GetValue(SidesProperty); }
          set { SetValue(SidesProperty, value); }
      }
      static MainWindow()  //Static Constructor
      {
          // 인스턴스 할당하는 방법
          // FrameworkPropertyMetadat 객체를 생성하고 의존 속성을 관리하는 방법을 설명하는 객체의 속성을 설정한다.
          FrameworkPropertyMetadata md = new FrameworkPropertyMetadata();
          // md.AffectsArrange = true; // 의존 속성이 layout 프로세스의 정렬 단계에 영향을 주는지 여부를 지정한다.
          // md.AffectsMeasure = true; // layout 프로세스의 측정 단계에 영향을 주는지 여부를 지정한다.
          // md.AffectsParentArrange = true; // 부모 요소 layout의 측정단계에 잠재적으로 영향을 주는지 여부를 지정한다.
          // md.AffectsRender = true; // 표준 정렬이나 측정 문제 이외의 이유로 요소의 다시 그리기가 필요한지 여부를 지정한다.
          // md.BindsTwoWayByDefault = true; // 속성이 기본적으로 양방향으로 바인드 하는지의 여부를 지정한다.
          // md.DefaultValue = (object)??; // 속성 값을 설정하는 다른 요소가 없는 경우 의존 속성의 기본값을 지정한다.
          // md.Inherits = true; // 의존속성의 값이 상속되는지 여부를 지정한다.
          // md.PropertyChangedCallback = (PropertyChangedCallback)??; // 의존 속성의 유효한 속성 값이 변경될 때 호출되는 콜백을 나타낸다.
          md.PropertyChangedCallback = OnSidesChanged;  //Set Callback
          // 의존 속성 identifier object를 가져오려면 WPF 속성 시스템에 의존 속성을 등록해야 한다.
          SidesProperty = DependencyProperty.Register(
              "Sides", // Dependency Property Field Name, 속성 필드의 이름
              typeof(int), // Type of the Property, bool int 등과 같이 의존속성의 type
              typeof(MainWindow), // Type of Property Owner, 의존 속성을 선언하는 클래스의 type
              md); // Reference to Metadata, 메타데이터에 대한 참조
      }
      public MainWindow() //Instance Constructor
      {
          InitializeComponent();
      }
      private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
          int SideCount;
          bool success = int.TryParse(input.Text, out SideCount);
          if (success && SideCount > 2 && 1000 > SideCount)
              Sides = SideCount;
      }
      static void OnSidesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
      {
          MainWindow win = obj as MainWindow;
          if (win == null || win.poly == null)
              return;
          const int n = 1; // 크기 배수
          const int xCenter = 65;
          const int yCenter = 50;
          const int radius = 40;
          double rads = Math.PI / win.Sides * 2;
          win.poly.Points.Clear();
          win.poly.Points.Add(new Point((xCenter + radius) * n, yCenter * n));
          for (double i = 1; i <= win.Sides - 1; i++)
          {
              double x = (Math.Cos(rads * i) * radius) + xCenter;
              double y = (Math.Sin(rads * i) * radius) + yCenter;
              win.poly.Points.Add(new Point(n * x, n * y));
          }
      }
  }
  ```
- xml을 다음과 같이 선언한다.
  ```xml
  <StackPanel>
      <TextBox TextChanged="TextBox_TextChanged" Name="input">
          0
      </TextBox>
      <Grid>
          <Polygon Name="poly" Stroke="Black" Fill="LightGray"/>
      </Grid>
  </StackPanel>
  ```

<br>

### 예제 3 : Attached Property 생성하기

- 일반 dependency property에는 GetValue와 SetValue 호출에 대한 CLR property wrapper가 있다.
- Attached property에는 GetXXX와 SetXXX 형식의 static 메서드가 있다.
- GetXXX, SetXXX 메서드가 GetValue 와 SetValue 메서드를 호출하려면 대상 객체가 DependencyObject에서 파생되어야 한다.
- xaml 코드는 다음과 같이 구성한다.
  ```xml
  <StackPanel>
     <TextBlock Name="txt1">Holder 1</TextBlock>
     <TextBlock Name="txt2">Holder 2</TextBlock>
  </StackPanel>
  ```
- IntStorage.cs 코드를 다음과 같이 구성한다.
  ```cs
  public class IntStorage : DependencyObject
  {
  }
  ```
- MinWindow.xaml.cs 코드는 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public static readonly DependencyProperty CountProperty;

      static MainWindow()     // Static Constructor
      {
          CountProperty = DependencyProperty.RegisterAttached("Count", typeof(int), typeof(MainWindow));
      }

      public static int GetCount(IntStorage ints)
      {
          return (int)ints.GetValue(CountProperty);
      }

      public static void SetCount(IntStorage ints, int value)
      {
          ints.SetValue(CountProperty, value);
      }

      public MainWindow()      // Instance Constructor
      {
          InitializeComponent();

          IntStorage is1 = new IntStorage();  // Create Targets.
          IntStorage is2 = new IntStorage();

          SetCount(is1, 28);                // Store Values.
          SetCount(is2, 500);
          int i1 = GetCount(is1);           // Retrieve the values.
          int i2 = GetCount(is2);

          txt1.Text = i1.ToString();          // Display the values.
          txt2.Text = i2.ToString();
      }
  }
  ```

<br>

### 예제 4. Dependency property를 사용하여 타이머를 만든다.

- 일반 dependency property에는 GetValue와 SetValue 호출에 대한 CLR property wrapper가 있다.
- Attached property에는 GetXXX와 SetXXX 형식의 static 메서드가 있다.
- GetXXX, SetXXX 메서드가 GetValue 와 SetValue 메서드를 호출하려면 대상 객체가 DependencyObject에서 파생되어야 한다.
- xaml 코드는 다음과 같이 구성한다.
  ```xml
  <Grid>
      <Viewbox>
          <TextBlock Text="{Binding ElementName=myWindow, Path=Counter}"/>
      </Viewbox>
  </Grid>
  ```
- MinWindow.xaml.cs 코드는 다음과 같이 구성한다.
  ```cs
  using System;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Threading;
  
  namespace _7.Dependenc_Property
  {
      public partial class MainWindow : Window
      {
  
          public MainWindow() //Instance Constructor
          {
              InitializeComponent();

              // DispatcherTimer를 사용하여 타이머 기능을 만든다
              DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1),   DispatcherPriority.Normal,
                delegate
                {
                    int newvalue = 0;
                    if (Counter == int.MaxValue)
                    {
                        newvalue = 0;
                    }
                    else
                    {
                        newvalue = Counter + 1;
                    }
                    SetValue(CounterProperty, newvalue);
                }, Dispatcher);
  
          }
  
          // 예제 4
  
          // propdp를 입력하고 Tab키를 두 번 누른다. 아래 내용 자동 입력된다.
          // Dependency property의 이름을 Counter로 수정
          // ownerclass를 MainWindow로 변경
  
          public int Counter
          {
              get { return (int)GetValue(CounterProperty); }
              set { SetValue(CounterProperty, value); }
          }
  
          // Using a DependencyProperty as the backing store for MyProperty.  This enables   animation, styling, binding, etc...
          public static readonly DependencyProperty CounterProperty =
              DependencyProperty.Register("Counter", typeof(int), typeof(MainWindow), new   PropertyMetadata(0));
  
      }
  }
  ```
- 결과  
  <img src="/uploads/3cb045a3ef99135bdc7542adf9b2490e/image.png">

<br>

### 종합

- xaml 코드는 다음과 같이 구성한다.
  ```xml
  <Window x:Class="_7.Dependenc_Property.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:_7.Dependenc_Property"
          mc:Ignorable="d"
          x:Name="myWindow"
          Title="MainWindow" Height="200" Width="800">
      <Grid ShowGridLines="True">
          <Grid.ColumnDefinitions>
              <ColumnDefinition/>
              <ColumnDefinition/>
              <ColumnDefinition/>
              <ColumnDefinition/>
          </Grid.ColumnDefinitions>
  
          <!-- 예제 0 - 1. Property와 새로운 패러다임 - 의존속성 -->
          <GroupBox FontWeight="Bold" Grid.Column="0">
              <GroupBox.Header>
                  Buttons
              </GroupBox.Header>
              <StackPanel>
                  <Button FontWeight="Medium">Button1</Button>
                  <Button>Button2</Button>
              </StackPanel>
          </GroupBox>
  
          <!-- 예제 1 - 4. 사용자 정의 Dependency Property -->
          <StackPanel Grid.Column="1">
              <TextBox TextChanged="TextBox_TextChanged" Name="input">
                  0
              </TextBox>
              <Grid>
                  <Polygon Name="poly" Stroke="Black" Fill="LightGray"/>
              </Grid>
          </StackPanel>
  
          <!-- 예제 3. Attached Property 생성하기 -->
          <StackPanel Grid.Column="2">
              <TextBlock Name="txt1">Holder 1</TextBlock>
              <TextBlock Name="txt2">Holder 2</TextBlock>
          </StackPanel>
  
          <!-- 예제 4.  Dependency property를 사용하여 만드는 타이머 -->
          <Grid Grid.Column="3">
              <Viewbox>
                  <TextBlock Text="{Binding ElementName=myWindow, Path=Counter}"/>
              </Viewbox>
          </Grid>
  
  
      </Grid>
  </Window>
  ```
- MinWindow.xaml.cs 코드는 다음과 같이 구성한다.
  ```cs
  using System;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Threading;
  
  namespace _7.Dependenc_Property
  {
      public partial class MainWindow : Window
      {
  
          //Dependency Property Field
          // 클래스는 의존 속성 식별자에 대한 참조를 포함할 의존 속성 유형의 필드를 선언해야 한다.
          public static readonly DependencyProperty SidesProperty;
  
          //Dependency Property CLR Wrapper
          public int Sides
          {
              get { return (int)GetValue(SidesProperty); }
              set { SetValue(SidesProperty, value); }
          }
  
          static MainWindow()  //Static Constructor
          {
              // 인스턴스 할당하는 방법
              // FrameworkPropertyMetadat 객체를 생성하고 의존 속성을 관리하는 방법을 설명하는 객체의 속성을 설정한다.
              FrameworkPropertyMetadata md = new FrameworkPropertyMetadata();
  
              // md.AffectsArrange = true; // 의존 속성이 layout 프로세스의 정렬 단계에 영향을 주는지 여부를 지정한다.
              // md.AffectsMeasure = true; // layout 프로세스의 측정 단계에 영향을 주는지 여부를 지정한다.
              // md.AffectsParentArrange = true; // 부모 요소 layout의 측정단계에 잠재적으로 영향을 주는지 여부를 지정한다.
              // md.AffectsRender = true; // 표준 정렬이나 측정 문제 이외의 이유로 요소의 다시 그리기가 필요한지 여부를 지정한다.
              // md.BindsTwoWayByDefault = true; // 속성이 기본적으로 양방향으로 바인드 하는지의 여부를 지정한다.
              // md.DefaultValue = (object)??; // 속성 값을 설정하는 다른 요소가 없는 경우 의존 속성의 기본값을 지정한다.
              // md.Inherits = true; // 의존속성의 값이 상속되는지 여부를 지정한다.
              // md.PropertyChangedCallback = (PropertyChangedCallback)??; // 의존 속성의 유효한 속성 값이 변경될 때 호출되는 콜백을 나타낸다.
  
              md.PropertyChangedCallback = OnSidesChanged;  //Set Callback
  
              // 의존 속성 identifier object를 가져오려면 WPF 속성 시스템에 의존 속성을 등록해야 한다.
              SidesProperty = DependencyProperty.Register(
                  "Sides", // Dependency Property Field Name, 속성 필드의 이름
                  typeof(int), // Type of the Property, bool int 등과 같이 의존속성의 type
                  typeof(MainWindow), // Type of Property Owner, 의존 속성을 선언하는 클래스의 type
                  md); // Reference to Metadata, 메타데이터에 대한 참조
  
  
              // 예제 3
              CountProperty = DependencyProperty.RegisterAttached("Count", typeof(int), typeof(MainWindow));
          }
  
  
          public MainWindow() //Instance Constructor
          {
              InitializeComponent();
  
              // 예제 3
               IntStorage is1 = new IntStorage();  // Create Targets.
               IntStorage is2 = new IntStorage();
  
               SetCount(is1, 28);                // Store Values.
               SetCount(is2, 500);
               int i1 = GetCount(is1);           // Retrieve the values.
               int i2 = GetCount(is2);
  
               txt1.Text = i1.ToString();          // Display the values.
               txt2.Text = i2.ToString();
  
  
              // 예제 4
              // DispatcherTimer를 사용하여 타이머 기능을 만든다
              DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal,
                delegate
                {
                    int newvalue = 0;
                    if (Counter == int.MaxValue)
                    {
                        newvalue = 0;
                    }
                    else
                    {
                        newvalue = Counter + 1;
                    }
                    SetValue(CounterProperty, newvalue);
                }, Dispatcher);
  
          }
  
          private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
          {
              int SideCount;
              bool success = int.TryParse(input.Text, out SideCount);
              if (success && SideCount > 2 && 1000 > SideCount)
                  Sides = SideCount;
          }
  
          static void OnSidesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
          {
              MainWindow win = obj as MainWindow;
              if (win == null || win.poly == null)
                  return;
  
              const int n = 1; // 크기 배수
              const int xCenter = 65;
              const int yCenter = 50;
              const int radius = 40;
              double rads = Math.PI / win.Sides * 2;
  
              win.poly.Points.Clear();
              win.poly.Points.Add(new Point((xCenter + radius) * n, yCenter * n));
              for (double i = 1; i <= win.Sides - 1; i++)
              {
                  double x = (Math.Cos(rads * i) * radius) + xCenter;
                  double y = (Math.Sin(rads * i) * radius) + yCenter;
                  win.poly.Points.Add(new Point(n * x, n * y));
              }
          }
  
          // 예제 3
  
          public static readonly DependencyProperty CountProperty;
  
          public static int GetCount(IntStorage ints)
          {
              return (int)ints.GetValue(CountProperty);
          }
  
          public static void SetCount(IntStorage ints, int value)
          {
              ints.SetValue(CountProperty, value);
          }
  
  
          // 예제 4
  
          // propdp를 입력하고 Tab키를 두 번 누른다.
          // Dependency property의 이름을 Counter로 수정
          // ownerclass를 MainWindow로 변경
  
          public int Counter
          {
              get { return (int)GetValue(CounterProperty); }
              set { SetValue(CounterProperty, value); }
          }
  
          // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
          public static readonly DependencyProperty CounterProperty =
              DependencyProperty.Register("Counter", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
  
      }
  }
  ```
- IntStorage.cs 코드를 다음과 같이 구성한다.
  ```cs
  using System.Windows;
  
  namespace _7.Dependenc_Property
  {
      public class IntStorage : DependencyObject
      {
      }
  }
  ```

<br><br><br>



# Ch 08. Data Binding

### 0. Summary(요약)

- <img src="/uploads/a264d77f5a547b90ddeee5dc5fb49c0e/image.png" width="70%">

<br>

### 1. Binding이란? - Slider와 TextBox Binding

- Slider가 움직이면서 그 위치를 TextBox에 표시하는 WPF를 만들어본다.
  - Slider에 대한 이벤트 핸들러를 작성하여 위치가 변경될 때마다 핸들러를 호출하고 TextBox를 업데이트할 수 있다. 이 방법은 이벤트 핸들러 코드를 작성하여 적절한 이벤트와 연결을 해야 한다.
  - 하지만, 데이터 바인딩을 통해 보다 더 간편한 방법으로 연결한다.
  - 데이터 바인딩은 두 개체의 연결로, 두 개체 중 하나는 항상 다른 개체의 값으로 최신 상태를 유지한다. 데이터 바인딩을 사용하면 TextBox.Text 속성과 Slider.Value 속성 간의 연결을 생성하면 된다. WPF는 업데이트가 발생할 때 자동으로 처리한다.
- xaml 예제
  ```xml
  <StackPanel>
      <TextBox Margin="10" Text="{Binding ElementName=sldrSlider, Path=Value}"/>
      <Slider Name="sldrSlider" TickPlacement="TopLeft" Margin="10"/>
      <!--<Slider Name="sldrSlider"... Value="10"/>-->
  </StackPanel>
  ```
- Binding markup extension을 사용하여 XAML에서 바인딩을 만들거나, code-behind에 바인딩을 만들 수 있다.
- 이때 TextBox는 Source, Slider는 Target이 된다.
- 한 속성은 source property라고 하고, 다른 하나는 target property라고 한다.  
  <img src="/uploads/a1e980e502d1c563731b6744d889be49/image.png" width="70%">
- 바인딩을 통해 source property를 target property와 연결한다.  
  ```xml
  <TextBox Text="{Binding ElementName=sldrSlider, Path=Value}"/>
  ```
  - ElementName 파라미터 : 바인딩 되는 컨트롤의 이름이다.
  - Path 파라미터 : 바인딩 작업의 대상이 되는 요소의 속성이다.
  - Markup extension안에는 따옴표(")를 사용하지 않는다.
  - 파라미터들은 콤마(,) 로 구분한다.
- 결과  
  <img src="/uploads/2eb628087985b54f55ceb6ec315ecef3/image.png">

<br>

### 2. Code-behind에서 바인딩

- TextBox의 문자열이 바뀔 때마다 Label의 문자열도 업데이트 되게 한다.
- 이때, XAML에서 진행하는 것이 아닌, Code-behind에서 진행한다.
- xaml은 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="0" Grid.Column="1">
      <Label Name="displayText"/>
      <TextBox Name="sourceInfo"/>
  </StackPanel>
  ```
- xaml.cs은 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public MainWindow()
      {
          InitializeComponent();

          Binding myBinding = new Binding();    // Create the Binding
          myBinding.Source = sourceInfo;        // Set the Source
          myBinding.Path = new PropertyPath("Text");   // Set the Path

          //Connect the Source and the Target.
          displayText.SetBinding(Label.ContentProperty, myBinding);
      }
  }
  ```
- 결과  
  <img src="/uploads/152794bc299c925ec8da9fda0aad3759/image.png">


<br>

### 3. 바인딩 방향

- 바인딩 개체의 Mode 속성을 다음 값 중 하나로 설정하여 업데이트 방향을 설정할 수 있다.
  - OneWay : Source가 바뀌면 target을 업데이트한다.
  - TwoWay : 양방향. Source가 바뀌면 target을 업데이트하고, target이 바뀌면 source를 업데이트한다.
  - OneWayToSource : Target이 바뀌면 source를 업데이트한다.
  - OneTime : Target을 한 번만 source의 초기값으로 업데이트하고 이후에는 다시 target을 업데이트하지 않는다.
  - Default : Target의 default 바인딩 모드를 사용한다.
- 1번 예제에서 xaml 내용을 수정하여 방향을 설정해본다.  
  ```xml
  <TextBox Margin="10" Text="{Binding ElementName=sldrSlider1, Path=Value, Mode=TwoWay}"/>
  ```
- TwoWay의 경우 TextBox를 수정하거나 Slider를 움직이면 서로 값이 업데이트 됨을 알 수 있다.
  ```xml
  <TextBox Margin="10" Text="{Binding ElementName=sldrSlider1, Path=Value, Mode=OneWay}"/>
  ```
- OneWay는 Slider(source) -> TextBox(target)의 바인딩만 허용된다.
  ```xml
  <TextBox Margin="10" Text="{Binding ElementName=sldrSlider1, Path=Value, Mode=OneWayToSource}"/>
  ```
- OneWayToSource는 TextBox(target) -> Slider(source)의 바인딩만 허용된다.
- 결과  
  <img src="/uploads/c23c018a9cc7c97433a9fd4279cbaff6/image.png">


<br>

### 4. Trigger

- 앞 예제는 Slider를 움직이면 TextBox의 값은 바로 업데이트되었지만, TextBox의 값을 바꾸면 포커스를 바꿀 때까지 Slider는 변하지 않았다.
- 이러한 차이는 업데이트 방향과, 바인딩 개체의 UpdateSourceTrigger의 값에 따라 달라진다.  
  <img src="/uploads/444ac643d7a17449c2a81ea1aa30b2de/image.png" width="70%">
- TwoWay와 OneWayToSource 모드의 경우, UpdateSourceTrigger 속성을 설정하여 target에서 source로의 업데이트 동작을 지정할 수 있다.
  - PropertyChanged
  - LostFocus
  - Explicit
- xaml을 다음과 같이 수정하여 TextBox-Slider간의 실시간 업데이트가 됨을 확인한다.
  ```xml
  <TextBox Margin="10" Text="{Binding ElementName=sldrSlider, Path=Value, UpdateSourceTrigger=PropertyChanged}"/>
  ```
- 결과  
  <img src="/uploads/fd688c77d813a183c633f96c6e7aabb2/image.png">

<br>

### 4-1. Trigger Button Binding

- 버튼을 누르면 업데이트 되는 바인딩을 구성해본다.
- xaml을 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="0" Grid.Column="3">
      <TextBox Name="tbValue" Margin="10" Text="{Binding ElementName=sldrSlider2, Path=Value, UpdateSourceTrigger=Explicit}"/>
      <Slider Name="sldrSlider2" TickPlacement="TopLeft" Margin="10"/>
      <Button Click="Button_Click03">Trigger</Button>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  private void Button_Click(object sender, RoutedEventArgs e)
  {
      BindingExpression be = tbValue.GetBindingExpression(TextBox.TextProperty);
      be.UpdateSource();
  }
  ```
- 결과  
  <img src="/uploads/25fbdd79cf7ca5c0fd5ee6fbe5f546b3/image.png">

<br>

### 5. Data Converters

- DataConverter를 활용해 Binding되는 값을 변환시킬 수 있다.
- 기존의 예제에서 Slider를 움직이면 TextBox에 소수점 14자리 까지 포함하여 나타내는데, Data Converter를 활용하면 소수점 2자리까지 표현할 수 있다.
- ValueConversion 클래스의 구조는 다음과 같다.  
  <img src="/uploads/f0d73ffc58243fff4b808137e75924a6/image.png" width="70%">
  - Convert()는 Source -> Target 방향으로 변환이 필요할 때 호출된다.
  - ConvertBack()는 Target -> Source 방향으로 변환이 필요할 때 호출된다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel>
      <TextBox Margin="10">
          <TextBox.Text>
              <Binding ElementName="sldrSlider" Path="Value">
                 <Binding.Converter>
                      <local:DisplayTwoDecPlaces/>
                  </Binding.Converter>
             </Binding>
          </TextBox.Text>
      </TextBox>
      <Slider Name="sldrSlider" TickPlacement="TopLeft" Margin="10"/>
  </StackPanel>

  <!--또는-->

  <Window.Resources>
      <ResourceDictionary>
          <local:DisplayTwoDecPlaces x:Key="displayTwoDecPlaces"/>
      </ResourceDictionary>
  </Window.Resources>
 
  <StackPanel>
      <TextBox Margin="10" Text="{Binding ElementName=sldrSlider, Path=Value, Converter={StaticResource displayTwoDecPlaces}}"/>
      <Slider Name="sldrSlider" TickPlacement="TopLeft" Margin="10"/>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  [ValueConversion(typeof(double), typeof(string))]
  public class DisplayTwoDecPlaces : IValueConverter
  {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
          double dValue = (double)value;
          return dValue.ToString("F2"); // 소수점 2자리 수
      }
  
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
          double dValue;
          double.TryParse((string)value, out dValue);
          return dValue;
      }
  }
  ```
- 결과  
  <img src="/uploads/5650c72a2090382cfc4c6afa055c7d78/image.png">

<br>

### 6. 여러 개의 속성에 Binding

- Dependency 속성은 수에 관계없이 동시에 여러 개를 바인딩 할 수 있다.
- 한 개의 Label에 2개의 ComboBox가 있다. 이 2개의 ComboBox는 각각 다른 속성을 Label에 부여하는 바인딩을 만들어본다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="1" Grid.Column="1">
      
      <Label Name="displayText06" Margin="5" FontSize="16" Content="My Test"
             FontFamily="{Binding ElementName=fontBox, Path=Text}"
             FontWeight="{Binding ElementName=weightBox, Path=Text}"/>
  
      <ComboBox Name="fontBox" SelectedIndex="0" Margin="5,0,5,2">
          <ComboBoxItem>ARIAL</ComboBoxItem>
          <ComboBoxItem>Couier New</ComboBoxItem>
      </ComboBox>
  
      <ComboBox Name="weightBox" SelectedIndex="0" Margin="5,0,5,2">
          <ComboBoxItem>Normal</ComboBoxItem>
          <ComboBoxItem>Bold</ComboBoxItem>
      </ComboBox>
      
  </StackPanel>
  ```
- 결과  
  <img src="/uploads/f4ebbeaa07f7a7de584e7d1ce1cd9765/image.png">

<br>

### 6-1. 예제 Text & Size

- 한 개의 Label에 한 개의 TextBox를 갖는다.
- TextBox에 입력된 값은 Label에 입력되고, 크기 또한 TextBox에 입력된 값으로 지정한다.
- 즉, 내용과 크기를 동시에 지정한다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel>
      <Label Name="displayText" Margin="5"/>
      <TextBox Name="SourceInfo">10</TextBox>
  </StackPanel>
  ```
- xaml.cs를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public MainWindow()
      {
          InitializeComponent();

          Binding bindingShared = new Binding();
          bindingShared.Source = SourceInfo;
          bindingShared.Path = new PropertyPath("Text");

          displayText.SetBinding(Label.ContentProperty, bindingShared);
          displayText.SetBinding(Label.FontSizeProperty, bindingShared);
      }
  }
  ```
- 결과  
  <img src="/uploads/ab565a9979002453a6db118676fd668b/image.png">

### 6-2. 예제 Text & Size in XAML

- 예제 6-1을 xaml에서만 구성할 수 있다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel>
      <Label Name="displayText" Margin="5"
          FontSize="{Binding ElementName=sourceInfo, Path=Text}"
          Content="{Binding ElementName=sourceInfo, Path=Text }"/>
      <TextBox Name="sourceInfo">10</TextBox>
  </StackPanel>
  ```
- 결과  
  <img src="/uploads/963705e21db0772a489e244f81d11741/image.png">

<br>

### 7. MultiBinding

- 여러 속성을 하나의 컨트롤에 바인딩 해야 할 경우 MultiBinding을 사용한다.
  - 이때 사용하는 Converter는 IMultiValueConverter를 상속받는 converter이다.
  - Convert() 메소드에서 values 배열에 변환할 데이터가 들어온다.
- FirstName과 LastName을 입력하면 FullName이 완성되는 프로그램을 구성해본다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <Window.Resources>
      <ResourceDictionary>
          <local:TextConverter x:Key="TextConverter"/>
      </ResourceDictionary>
  </Window.Resources>

  <StackPanel Margin="10" Grid.Row="1" Grid.Column="4">

      <TextBlock Text="First Name" VerticalAlignment="Top"/>
      <TextBox x:Name="txtFirstName" VerticalAlignment="Top" Width="120"/>
      
      <TextBlock Text="Last Name" VerticalAlignment="Top" Margin="0 10 0 0"/>
      <TextBox x:Name="txtLastName" VerticalAlignment="Top" Width="120" Margin="0 0 0 10"/>
      
      <TextBlock Text="Full Name" VerticalAlignment="Top"/>
      <TextBox VerticalAlignment="Top" Width="200">

          <TextBox.Text>
              <MultiBinding Converter="{StaticResource TextConverter}" UpdateSourceTrigger="PropertyChanged">
                  <Binding ElementName="txtFirstName" Path="Text" />
                  <Binding ElementName="txtLastName" Path="Text" />
              </MultiBinding>
          </TextBox.Text>

      </TextBox>

  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public class TextConverter : IMultiValueConverter
  {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
          string one = values[0] as string;
          string two = values[1] as string;
          if (!string.IsNullOrEmpty(one) && !string.IsNullOrEmpty(two))
          {
              return one + two;
          }
          return null;
      }
  
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
      {
          return null;
      }
  }
  ```
- 결과  
  <img src="/uploads/3587356b396f1cae51075b95ac866538/image.png">

<br>

### 8. Binding 제거

- ClearBinding 메서드를 사용하여 특정 바인딩을 제거하고, ClearAllBinding 메서드를 사용하여 모든 바인딩을 제거할 수 있다.
- (예제 6)에 Binding을 지우거나 모든 Binding을 지울 수 있는 예제를 만들어본다.
- FontFamily 바인딩을 지우거나, 모두 지우거나가 가능하다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="2" Grid.Column="0">
      <Label Name="displayText20" Margin="5" FontSize="16"
         Content="My Text"
         FontFamily="{Binding ElementName=fontBox, Path=Text}"
         FontWeight="{Binding ElementName=weightBox, Path=Text}"/>
      
      <Grid>
          <Grid.ColumnDefinitions>
              <ColumnDefinition></ColumnDefinition>
              <ColumnDefinition></ColumnDefinition>
          </Grid.ColumnDefinitions>
          
          <StackPanel>
              <ComboBox Name="fontBox20" SelectedIndex="0" Margin="5,0,5,2">
                  <ComboBoxItem>Arial</ComboBoxItem>
                  <ComboBoxItem>Courier New</ComboBoxItem>
              </ComboBox>
              <ComboBox Name="weightBox20" SelectedIndex="0" Margin="5,0,5,  2">
                <ComboBoxItem>Normal</ComboBoxItem>
                  <ComboBoxItem>Bold</ComboBoxItem>
              </ComboBox>
          </StackPanel>
  
          <StackPanel Grid.Column="1">
              <Button Name="ClearFont" Margin="5,0,5,2"
                  Click="ClearFont_Click">Clear Font</Button>
              <Button Name="ClearAll" Margin="5,0,5,2"
                  Click="ClearAll_Click">Clear All</Button>
              <Button Name="CreateBindings" Margin="5,0,5,2"
                  Click="CreateBindings_Click">Create Bindings</Button>
          </StackPanel>
      </Grid>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public MainWindow()
      {
          InitializeComponent();
      }
  
     // Clear the FontFamily binding.
      private void ClearFont_Click(object sender, RoutedEventArgs e)
      {
          BindingOperations.ClearBinding(displayText, FontFamilyProperty);
      }
  
     // Clear all the bindings.
      private void ClearAll_Click(object sender, RoutedEventArgs e)
      {
          BindingOperations.ClearAllBindings(displayText);
      }
  
     // Re-create the two bindings.
      private void CreateBindings_Click(object sender, RoutedEventArgs e)
      {
          //Create the FontFamily binding.
          Binding fontBinding = new Binding();
          fontBinding.Source = fontBox;
          fontBinding.Path = new PropertyPath("Text");
          fontBinding.Mode = BindingMode.OneWay;
          displayText.SetBinding(FontFamilyProperty, fontBinding);
  
         //Create the FontWeight binding.
          Binding weightBinding = new Binding();
          weightBinding.Source = weightBox;
          weightBinding.Path = new PropertyPath("Text");
          weightBinding.Mode = BindingMode.OneWay;
          displayText.SetBinding(FontWeightProperty, weightBinding);
      }
  }
  ```
- 결과  
  <img src="/uploads/9db58a084fefc8515f707ab0f292003f/image.png">


<br>

### 9. Binding Nonelement

- 간단한 클래스를 만들고 몇 가지 속성에 바인딩 하는 방법을 알아보자.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Orientation="Horizontal">
      <Label Name="lblFName" FontWeight="Bold"/>
      <Label Name="lblAge"/>
      <Label Name="lblColor"/>
  </StackPanel>  
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public MainWindow()
      {
          InitializeComponent();

          Person p = new Person("Shirley", 34, "Green");

          Binding nameBinding = new Binding("FirstName");
          nameBinding.Source = p;
          lblFName.SetBinding(ContentProperty, nameBinding);

          Binding ageBinding = new Binding("Age");
          ageBinding.Source = p;
          lblAge.SetBinding(ContentProperty, ageBinding);

          Binding colorBinding = new Binding("FavoriteColor");
          colorBinding.Source = p;
          lblColor.SetBinding(ContentProperty, colorBinding);
      }
  }

  class Person
  {
      public string FirstName { get; set; }
      public int Age { get; set; }
      public string FavoriteColor { get; set; }
  
      public Person(string fName, int age, string color)
      {
          FirstName = fName;
          Age = age;
          FavoriteColor = color;
      }
  }
  ```
- 결과  
  <img src="/uploads/77889dd075df7f99f92cb6f7d1a7640b/image.png">

<br>

### 10. Data Context

- 이전 예제의 code-behind의 각 데이터 바인딩에는 바인딩 객체를 생성하는 라인, Source를 설정하는 라인, BindingExpression을 생성하는 라인이 필요했다. 세 바인딩 모두 동일한 source 개체를 사용했다.
- 많은 바인딩에서 동일한 source 개체를 사용하는 경우 바인딩에 DataContext를 지정할 수 있다.
- 조건
  - 바인딩 되는 element의 트리의 상위에 있는 element의 DataContext 속성을 설정해야 한다.
  - 특정 바인딩의 Source를 재정의하지 않는 한 바인딩의 Source 속성을 설정하지 않는다.
  - 시스템에서 Source 속성에 대한 설정이 없는 바인딩 개체를 찾으면 element tree에서 DataContext property set을 사용하여 element를 찾는다. 찾으면 해당 값을 바인딩의 Source로 사용한다.
- 예제 9를 다음과 같이 수정할 수 있다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Orientation="Horizontal">
      <Label Name="lblFName" FontWeight="Bold"/>
      <Label Name="lblAge"/>
      <Label Name="lblColor"/>
  </StackPanel>  
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public MainWindow()
      {
          InitializeComponent();

          Person p = new Person("Shirley", 34, "Green");
          sp.DataContext = p; //Set the DataContext of the StackPanel

          Binding nameBinding = new Binding("FirstName");
          lblFName.SetBinding(ContentProperty, nameBinding);

          Binding ageBinding = new Binding("Age");
          lblAge.SetBinding(ContentProperty, ageBinding);

          Binding colorBinding = new Binding("FavoriteColor");
          lblColor.SetBinding(ContentProperty, colorBinding);
      }
  }

  class Person
  {
      public string FirstName { get; set; }
      public int Age { get; set; }
      public string FavoriteColor { get; set; }
  
      public Person(string fName, int age, string color)
      {
          FirstName = fName;
          Age = age;
          FavoriteColor = color;
      }
  }
  ```
- 결과  
  <img src="/uploads/77889dd075df7f99f92cb6f7d1a7640b/image.png">


<br>

### 12. Binding 및 ItemsContol

- ItemsControl에는 데이터 목록을 저장할 수 있는 Items, ItemSource가 있다. 
- ItemsSource 속성을 사용하여 외부 item 을 저장하고 사용하는 방법에 대해 알아본다.
- ComboBox에서 이름을 선택하면 상단에 정보를 표시해주는 예제를 만들어본다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel>
      <StackPanel Orientation="Horizontal" Margin="5,10" DataContext="{Binding ElementName=comboPeople, Path=SelectedItem}">
          <Label Name="lblFName" FontWeight="Bold"/>
          <Label Name="lblAge"/>
          <Label Name="lblColor"/>
      </StackPanel>
      <ComboBox Name="comboPeople" SelectedIndex="0" DisplayMemberPath="FirstName"/> <!-- Combo에 FirstName만 띄운다 -->
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public MainWindow()
      {
          InitializeComponent();

          Person[] people = { new Person( "Shirley", 34, "Green" ),
              new Person( "Roy", 36, "Blue" ),
              new Person( "Isabel", 25, "Orange" ),
              new Person( "Manuel", 27, "Red" ) };

          comboPeople.ItemsSource = people;

          Binding nameBinding = new Binding("FirstName");
          lblFName12.SetBinding(ContentProperty, nameBinding);

          Binding ageBinding = new Binding("Age");
          lblAge12.SetBinding(ContentProperty, ageBinding);

          Binding colorBinding = new Binding("FavoriteColor");
          lblColor12.SetBinding(ContentProperty, colorBinding);
      }
  }
  ```
- 결과  
  <img src="/uploads/c473cd54aab3d86ee8d00bddf6b4a74a/image.png">

<br>

### 예제 RBG 슬라이더 만들기

- R, G, B값을 만들 수 있는 슬라이더를 세 개 만든다. 슬라이더의 Minimum값은 0이고, Maximum값은 255이다.
- 실제 색을 보여줄 Button의 Background 속성에 R,G,B값을 MultiBinding을 사용하여 Binding한다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="2" Grid.Column="4">

      <StackPanel Orientation="Horizontal" Margin="5">
          <TextBlock Text="R : "/>
          <Slider Width="130" Minimum="0" Maximum="255" x:Name="slider1"/>
      </StackPanel>
  
      <StackPanel Orientation="Horizontal" Margin="5">
          <TextBlock Text="G : "/>
          <Slider Width="130" Minimum="0" Maximum="255" x:Name="slider2"/>
      </StackPanel>
  
      <StackPanel Orientation="Horizontal" Margin="5">
          <TextBlock Text="B : "/>
          <Slider Width="130" Minimum="0" Maximum="255" x:Name="slider3"/>
      </StackPanel>
  
      <StackPanel Orientation="Horizontal" Margin="5">
          <TextBlock Text="R : " HorizontalAlignment="Center"/>
          <TextBox Width="25" x:Name="valueR" Text="{Binding ElementName=slider1, Path=Value, Converter={StaticResource DisplayInt}}"/>
          <TextBlock Text=" G : " HorizontalAlignment="Center"/>
          <TextBox Width="25" x:Name="valueG" Text="{Binding ElementName=slider2, Path=Value, Converter={StaticResource DisplayInt}}"/>
          <TextBlock Text=" B : " HorizontalAlignment="Center"/>
          <TextBox Width="25" x:Name="valueB" Text="{Binding ElementName=slider3, Path=Value, Converter={StaticResource DisplayInt}}"/>
      </StackPanel>
  
      <Button x:Name="colorButton" Height="30" Foreground="White" Content="COLOR">
          <Button.Background>
              <MultiBinding Converter="{StaticResource XAMLResourceColorConverter}">
                  <Binding ElementName="valueR" Path="Text"/>
                  <Binding ElementName="valueG" Path="Text"/>
                  <Binding ElementName="valueB" Path="Text"/>
              </MultiBinding>
          </Button.Background>
      </Button>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public class ColorConverter : IMultiValueConverter
  {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
          values[0] = Byte.Parse((string)values[0]);
          values[1] = Byte.Parse((string)values[1]);
          values[2] = Byte.Parse((string)values[2]);
          
          Color color = Color.FromRgb((byte)values[0], (byte)values[1], (byte)values[2]);
          SolidColorBrush bg = new SolidColorBrush(color);
          
          return bg;
      }

      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
      {
          throw new NotSupportedException("Cannot convert back");
      }
  }

  public class DisplayInt : IValueConverter
  {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
          double dValue = (double)value;
      
          if ((double)value < 10)
              return "  " + dValue.ToString("F0");
          else if ((double)value < 100 && (double)value > 10)
              return " " + dValue.ToString("F0");
          else
              return dValue.ToString("F0");
      }
      
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
          double dValue;
          double.TryParse((string)value, out dValue);
          return dValue;
      }
  }
  ```
- 결과  
  <img src="/uploads/bb60f4ffbc0a4b86228fdc8cf6c6f63f/image.png">

<br>


<br><br><br>

### 종합
- xaml
  ```xml
  <Window x:Class="_8.Data_Binding.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/  2006"
          xmlns:local="clr-namespace:_8.Data_Binding"
          mc:Ignorable="d"
          Title="MainWindow" Height="450" Width="800">
      <Window.Resources>
          <ResourceDictionary>
              <local:DisplayTwoDecPlaces x:Key="displayTwoDecPlaces"/>
              <local:TextConverter x:Key="TextConverter"/>
              <local:ColorConverter x:Key="XAMLResourceColorConverter"/>
              <local:DisplayInt x:Key="DisplayInt"/>
          </ResourceDictionary>
      </Window.Resources>
      <Grid ShowGridLines="True">
          <Grid.RowDefinitions>
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
          </Grid.ColumnDefinitions>
  
          <!-- 1. Binding이란? - Slider와 TextBox Binding -->
  
          <StackPanel Grid.Row="0" Grid.Column="0">
              <TextBox Margin="10" Text="{Binding ElementName=sldrSlider,   Path=Value}"/>
              <Slider Name="sldrSlider" TickPlacement="TopLeft" Margin="10"/>
          </StackPanel>
  
          <!-- 2. Code-behind에서 바인딩 -->
          <StackPanel Grid.Row="0" Grid.Column="1">
              <Label Content="Code-behind Binding"/>
              <Label Name="displayText"/>
              <TextBox Name="sourceInfo"/>
          </StackPanel>
  
          <!-- 3. 바인딩 방향 -->
          <StackPanel Grid.Row="0" Grid.Column="2">
              <Label Content="OneWay(text -> slider)"/>
              <TextBox Margin="10" Text="{Binding ElementName=sldrSlider1,   Path=Value, Mode=OneWay}"/>
              <Slider Name="sldrSlider1" TickPlacement="TopLeft" Margin="10"/  >
          </StackPanel>
  
          <!-- 4. Trigger -->
          <StackPanel Grid.Row="0" Grid.Column="3">
              <TextBox Margin="10" Text="{Binding ElementName=sldrSlider0,   Path=Value, UpdateSourceTrigger=PropertyChanged}"/>
              <Slider Name="sldrSlider0" TickPlacement="TopLeft" Margin="10"/  >
          </StackPanel>
  
          <!-- 4-1. Trigger Button Binding -->
          <StackPanel Grid.Row="0" Grid.Column="4">
              <TextBox Name="tbValue" Margin="10" Text="{Binding   ElementName=sldrSlider2, Path=Value,   UpdateSourceTrigger=Explicit}"/>
              <Slider Name="sldrSlider2" TickPlacement="TopLeft" Margin="10"/  >
              <Button Click="Button_Click03">Trigger</Button>
          </StackPanel>
  
          <!-- 5. Data Converters -->
          <StackPanel Grid.Row="1" Grid.Column="0">
              <TextBox Margin="10" Text="{Binding ElementName=sldrSlider5,   Path=Value
                  ,Converter={StaticResource displayTwoDecPlaces} }"/>
              <Slider Name="sldrSlider5" TickPlacement="TopLeft" Margin="10"/  >
          </StackPanel>
  
          <!-- 6. 여러 개의 속성에 Binding -->
  
          <StackPanel Grid.Row="1" Grid.Column="1">
              
              <Label Name="displayText06" Margin="5" FontSize="16"   Content="My Test"
                     FontFamily="{Binding ElementName=fontBox, Path=Text}"
                     FontWeight="{Binding ElementName=weightBox, Path=Text}"/  >
  
              <ComboBox Name="fontBox" SelectedIndex="0" Margin="5,0,5,2">
                  <ComboBoxItem>ARIAL</ComboBoxItem>
                  <ComboBoxItem>Couier New</ComboBoxItem>
              </ComboBox>
  
              <ComboBox Name="weightBox" SelectedIndex="0" Margin="5,0,5,2">
                  <ComboBoxItem>Normal</ComboBoxItem>
                  <ComboBoxItem>Bold</ComboBoxItem>
              </ComboBox>
              
          </StackPanel>
  
          <!-- 6-1. 예제 Text & Size -->
          <StackPanel Grid.Row="1" Grid.Column="2">
              <Label Name="displayText61" Margin="5"/>
              <TextBox Name="SourceInfo61">5</TextBox>
          </StackPanel>
          
          <!-- 6-2. 예제 Text & Size in xaml -->
          <StackPanel Grid.Row="1" Grid.Column="3">
              <Label Name="displayText63" Margin="5"
              FontSize="{Binding ElementName=SourceInfo63, Path=Text}"
              Content="{Binding ElementName=SourceInfo63, Path=Text }"/>
              <TextBox Name="SourceInfo63">10</TextBox>
          </StackPanel>
  
  
  
          <!-- 7. MultiBinding -->
          <StackPanel Margin="10" Grid.Row="1" Grid.Column="4">
              <TextBlock Text="First Name" VerticalAlignment="Top"/>
              <TextBox x:Name="txtFirstName" VerticalAlignment="Top"   Width="120"/>
              <TextBlock Text="Last Name" VerticalAlignment="Top" Margin="0   10 0 0"/>
              <TextBox x:Name="txtLastName" VerticalAlignment="Top"   Width="120" Margin="0 0 0 10"/>
              <TextBlock Text="Full Name" VerticalAlignment="Top"/>
              <TextBox VerticalAlignment="Top" Width="200">
                  <TextBox.Text>
                      <MultiBinding Converter="{StaticResource TextConverter}  " UpdateSourceTrigger="PropertyChanged">
                          <Binding ElementName="txtFirstName" Path="Text" />
                          <Binding ElementName="txtLastName" Path="Text" />
                      </MultiBinding>
                  </TextBox.Text>
              </TextBox>
          </StackPanel>
  
          <!-- 8. Binding 제거 -->
          <StackPanel Grid.Row="2" Grid.Column="0">
              <Label Name="displayText20" Margin="5" FontSize="16"
                 Content="My Text"
                 FontFamily="{Binding ElementName=fontBox, Path=Text}"
                 FontWeight="{Binding ElementName=weightBox, Path=Text}"/>
              
              <Grid>
                  <Grid.ColumnDefinitions>
                      <ColumnDefinition></ColumnDefinition>
                      <ColumnDefinition></ColumnDefinition>
                  </Grid.ColumnDefinitions>
                  
                  <StackPanel>
                      <ComboBox Name="fontBox20" SelectedIndex="0" Margin="5,  0,5,2">
                          <ComboBoxItem>Arial</ComboBoxItem>
                          <ComboBoxItem>Courier New</ComboBoxItem>
                      </ComboBox>
                      <ComboBox Name="weightBox20" SelectedIndex="0"   Margin="5,0,5,2">
                          <ComboBoxItem>Normal</ComboBoxItem>
                          <ComboBoxItem>Bold</ComboBoxItem>
                      </ComboBox>
                  </StackPanel>
  
                  <StackPanel Grid.Column="1">
                      <Button Name="ClearFont" Margin="5,0,5,2"
                          Click="ClearFont_Click">Clear Font</Button>
                      <Button Name="ClearAll" Margin="5,0,5,2"
                          Click="ClearAll_Click">Clear All</Button>
                      <Button Name="CreateBindings" Margin="5,0,5,2"
                          Click="CreateBindings_Click">Create Bindings</  Button>
                  </StackPanel>
              </Grid>
          </StackPanel>
  
  
          <!-- 9. Binding Nonelement -->
          <StackPanel Grid.Row="2" Grid.Column="1" Orientation="Horizontal">
              <Label Name="lblFName" FontWeight="Bold"/>
              <Label Name="lblAge"/>
              <Label Name="lblColor"/>
          </StackPanel>
  
          <!-- 10. Data Context -->
          <StackPanel Grid.Row="2" Grid.Column="2" Orientation="Horizontal"   Name="sp">
              <Label Name="lblFName10" FontWeight="Bold"/>
              <Label Name="lblAge10"/>
              <Label Name="lblColor10"/>
          </StackPanel>
  
  
          <!-- 12. Binding 및 ItemsContol -->
          <StackPanel Grid.Row="2" Grid.Column="3" >
              <StackPanel Orientation="Horizontal" Margin="5,10"   DataContext="{Binding ElementName=comboPeople,   Path=SelectedItem}">
                  <Label Name="lblFName12" FontWeight="Bold"/>
                  <Label Name="lblAge12"/>
                  <Label Name="lblColor12"/>
              </StackPanel>
              <ComboBox Name="comboPeople" SelectedIndex="0"   DisplayMemberPath="FirstName"/>
              <!-- Combo에 FirstName만 띄운다 -->
          </StackPanel>
  
          <!-- RGB Slider -->
          <StackPanel Grid.Row="2" Grid.Column="4">
  
              <StackPanel Orientation="Horizontal" Margin="5">
                  <TextBlock Text="R : "/>
                  <Slider Width="130" Minimum="0" Maximum="255"   x:Name="slider1"/>
              </StackPanel>
  
              <StackPanel Orientation="Horizontal" Margin="5">
                  <TextBlock Text="G : "/>
                  <Slider Width="130" Minimum="0" Maximum="255"   x:Name="slider2"/>
              </StackPanel>
          
              <StackPanel Orientation="Horizontal" Margin="5">
                  <TextBlock Text="B : "/>
                  <Slider Width="130" Minimum="0" Maximum="255"   x:Name="slider3"/>
              </StackPanel>
  
              <StackPanel Orientation="Horizontal" Margin="5">
                  <TextBlock Text="R : " HorizontalAlignment="Center"/>
                  <TextBox Width="25" x:Name="valueR" Text="{Binding   ElementName=slider1, Path=Value, Converter={StaticResource   DisplayInt}}"/>
                  <TextBlock Text=" G : " HorizontalAlignment="Center"/>
                  <TextBox Width="25" x:Name="valueG" Text="{Binding   ElementName=slider2, Path=Value, Converter={StaticResource   DisplayInt}}"/>
                  <TextBlock Text=" B : " HorizontalAlignment="Center"/>
                  <TextBox Width="25" x:Name="valueB" Text="{Binding   ElementName=slider3, Path=Value, Converter={StaticResource   DisplayInt}}"/>
              </StackPanel>
  
              <Button x:Name="colorButton" Height="30" Foreground="White"   Content="COLOR">
                  <Button.Background>
                      <MultiBinding Converter="{StaticResource   XAMLResourceColorConverter}">
                          <Binding ElementName="valueR" Path="Text"/>
                          <Binding ElementName="valueG" Path="Text"/>
                          <Binding ElementName="valueB" Path="Text"/>
                      </MultiBinding>
                  </Button.Background>
              </Button>
  
          </StackPanel>
  
  
      </Grid>
  </Window>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  using System.Windows;
  
  namespace _8.Data_Binding
  {
      public partial class MainWindow : Window
      {
          public MainWindow()
          {
              InitializeComponent();
  
              _02_CodeBehindBinding(); // chapter02
  
              _06_TextSize(); // Chapter06
  
              _09_BindingNonelement(); // Chapter09
  
              _10_DataContext(); // Chapter10
  
              _12_BindingItemsContol(); // Chapter12
  
          }
  
      }
  
  }
  ```
<br>


# Ch 09. Routing Events 및 Command

### 0. Summary(요약)

- <img src="/uploads/c6e9a0b75f76a8e520b1a065e2c37a68/image.png" width="70%">

### 1. Event란?

- Windows 프로그래밍은 이벤트 기반이다.
- 이벤트는 이벤트 핸들러 목록이 포함된 .NET 개체이다. 
- XAML에서 개체가 특정 이벤트를 처리하도록 지정하고 개체에 대한 이벤트 핸들러의 이름을 지정할 수 있다.
- Button 클래스에는 90개 이상의 이벤트가 연결될 수 있다. 
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="0" Grid.Column="0">
      <Button Name="myButton1" Padding="10"
  	Click ="myButton_Click1"
  	MouseEnter="myButton1_MouseEnter"
  	MouseLeave="myButton1_MouseLeave">Click Me</Button>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      private void myButton_Click1(object sender, RoutedEventArgs e)
      {
          string c = myButton1.Content.ToString();
          myButton1.Content = (c == "Clicked" || c == "Clicked Again")
          ? "Clicked Again"
          : "Clicked";
      }
  
      private void myButton1_MouseEnter(object sender, MouseEventArgs e)
      {
          myButton1.Content = "Mouse Over";
      }
  
      private void myButton1_MouseLeave(object sender, MouseEventArgs e)
      {
          myButton1.Content = "Click Me";
      }
  }
  ```
- 결과  
  <img src="/uploads/16edd4f8ffcc309b71d734330a2086d0/image.png">

<br>

### 2. Event Handler 구문과 의미

- 표준 이벤트 핸들러는 다음과 같은 특징을 가진다.
  - 리턴 타입은 void 이어야 한다.
  - 첫 번째 파라미터는 이벤트를 트리거 한 개체에 대한 참조이다. 
    - 일반적으로 sender가 지정된다.
    - 파라미터 타입은 object 이므로 object 멤버에 접근하려면 적절한 타입으로 다시 캐스팅해야 한다.
  - 두 번째 파라미터는 이벤트를 통해 전달되는 추가 정보를 포함할 수 있는 개체이다.
    - 이 파라미터의 타입은 EventArgs 또는 EventArgs의 하위 클래스이다.
  - `void myButton_MouseEnter ( object sender, MouseEventArgs e )`
- Attaching a Handler to an Event
  - XAML 또는 C#을 사용하여 이벤트 핸들러를 이벤트에 연결할 수 있다.
  - 이벤트 핸들러를 이벤트에 연결하는 것을 이벤트에 대한 subscribing 이라고한다.
  - 마크업이 아닌 코드행에 이벤트 핸들러를 연결하려면 다음과 같이 C#의 += 연산자를 사용한다.
  - `myButton.MouseEnter += myButton_MouseEnter;`

<br>

### 3. Routed Events 란?

- WPF는 라우팅 된 이벤트에 대해 세 가지 라우팅 전략을 사용한다.
  - Direct 라우팅 전략
    - 표준 CLR 이벤트 동작과 가장 유사하다.
    - element에 대해 이벤트가 발생하면, WPF는 이벤트를 발생시킨 element에서만 이벤트 핸들러를 확인한다.
  - Bubbling 라우팅 전략
    - 이벤트가 발생한 element를 먼저 확인한 후 트리 위쪽으로 이벤트를 전송하여 최상위 element로 이동한다.
    - 각 연속적인 element에서 이벤트가 발생하며 해당 element에 핸들러가 있으면 핸들러가 호출된다.
    - 예) Button -> Grif -> Window
  - Tunneling 라우팅 전략
    - 트리 맨 위에서 시작하여 아래로 진행되어 이벤트가 처음 발생한 element에 도달할 때까지 각 요소에 대한 이벤트가 일어난다.
    - 일반적으로, 내장된 WPF 터널링 이벤트의 이름은 Priview로 시작한다.
    - 예) Button <- Grif <- Window
- Handling Routed Event
  - 라우팅 된 이벤트의 첫 번째 핸들러는 기본적으로 CLR 이벤트의 핸들러와 동일하다.
  - `void myHandler ( object sender, RoutedEventArgs e )`
  - RoutedEventArgs 개체에는 라우팅 된 이벤트에서 중요한 정보를 가져오는 네 가지 속성이 있다.
    - Source : 이벤트를 발생시킨 개체에 대한 참조이고 이벤트를 처리하는데 필요한 정보를 가지고 있을 수 있다.
    - OriginalSource : 프로그래머들이 사용하는 element들은 실제로 우리가 일반적으로 신경 쓰지 않는 subelement들로 구성되어 있다. 실제로 클릭한 subelement에 대한 참조가 OriginalSource에 저장된다.
    - Handled : 이벤트 라우팅을 중지하려면 이 속성을 true로 설정할 수 있다. default 값은 false이다.
    - RoutedEvent : 하나의 이벤트가 아닌 여러개의 이벤트를 처리하는 것이 종종 유용하다. 이 경우 핸들러의 코드가 어떤 이벤트를 트리거 했는지 알아야 한다. 이 정보는 RoutedEvent 속성에서 가져올 수 있으며 이 속성은 호출된 원래 이벤트에 대한 참조를 반환한다.

<br>

### 3-1. Routed Events Bubbling 예제

- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Orientation="Horizontal"  Grid.Row="0" Grid.Column="1">
      <Border Name="myBorder31" BorderThickness="10" BorderBrush="BurlyWood"   MouseUp="myBorder31_MouseUp">
          <Label Name="myLabel31" Padding="10" MouseUp="myLabel31_MouseUp">
              <Image Name="cat31" Source="3-5.jpg" Stretch="None"   MouseUp="cat31_MouseUp"/>
          </Label>
      </Border>
      <StackPanel>
          <Button Width="100" Name="Clear31" Padding="10, 3"   Click="Clear31_Click">Clear</Button>
          <TextBlock Name="tb31" Margin="5 5 0 0"></TextBlock>
      </StackPanel>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      private void myBorder31_MouseUp(object sender, MouseButtonEventArgs e)
      {
          tb31.Text += "Border sees it.\r\n";
      }
  
      private void myLabel31_MouseUp(object sender, MouseButtonEventArgs e)
      {
          tb31.Text += "Label sees it.\r\n";
      }
  
      private void cat31_MouseUp(object sender, MouseButtonEventArgs e)
      {
          tb31.Text += "Image sees it.\r\n";
      }
  
      private void Clear31_Click(object sender, RoutedEventArgs e)
      {
          tb31.Text = "";
      }
  }
  ```
- 결과  
  <img src="/uploads/3e674571a0fbb0faa0d2032aff462ad3/image.png">

<br>

### 3-2. Routed Events Tunneling 예제

- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Orientation="Horizontal"  Grid.Row="0" Grid.Column="2">
      <Border Name="myBorder32" BorderThickness="10" BorderBrush="BurlyWood"
              MouseUp="myBorder32_MouseUp"   PreviewMouseUp="myBorder32_PreviewMouseUp">
          <Label Name="myLabel32" Padding="10"
                 MouseUp="myLabel32_MouseUp"   PreviewMouseUp="myLabel32_PreviewMouseUp">
              <Image Name="cat32" Source="3-5.jpg" Stretch="None"
                     MouseUp="cat32_MouseUp" PreviewMouseUp="cat32_PreviewMouseUp"/  >
          </Label>
      </Border>
      <StackPanel>
          <Button Width="100" Name="Clear32" Padding="10, 3"   Click="Clear32_Click">Clear</Button>
          <TextBlock Name="tb32" Margin="5 5 0 0"></TextBlock>
      </StackPanel>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      private void myBorder32_MouseUp(object sender, MouseButtonEventArgs e)
      {
          tb32.Text += "Bubbling : Border sees it.\r\n";
      }
  
      private void myLabel32_MouseUp(object sender, MouseButtonEventArgs e)
      {
          tb32.Text += "Bubbling : Label sees it.\r\n";
      }
  
      private void cat32_MouseUp(object sender, MouseButtonEventArgs e)
      {
          tb32.Text += "Bubbling : Image sees it.\r\n";
      }
  
  
      private void Clear32_Click(object sender, RoutedEventArgs e)
      {
          tb31.Text = "";
      }
  
  
      private void myBorder32_PreviewMouseUp(object sender, MouseButtonEventArgs e)
      {
          tb32.Text += "Tunneling : Border sees it.\r\n";
      }
  
      private void myLabel32_PreviewMouseUp(object sender, MouseButtonEventArgs e)
      {
          tb32.Text += "Tunneling : Label sees it.\r\n";
      }
  
      private void cat32_PreviewMouseUp(object sender, MouseButtonEventArgs e)
      {
          tb32.Text += "Tunneling : Image sees it.\r\n";
      }
  
  }
  ```
- 결과  
  <img src="/uploads/bad7e46e96a9af1a0c9eccb729cd8b63/image.png">

<br>

### 4. Command

- Target : TextBox
- Source : Button, MenuItem, 키보드 자르기
- 조건 : TextBox에서 선택한 텍스트가 있는 상태.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="1" Grid.Column="0">
      <Menu>
          <MenuItem Header="_Cut" Click="Button_Click4"/>
      </Menu>
      <TextBox Name="txtBox4" Margin="5" FontWeight="Bold"/>
      <Button Click="Button_Click4" FontWeight="Bold" Margin="5">Cut Text</Button>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      private void Button_Click4(object sender, RoutedEventArgs e)
      {
          if (txtBox4.SelectedText.Length <= 0)
              return;

          Clipboard.SetData(DataFormats.Text, (object)txtBox4.SelectedText);
          string pre = txtBox4.Text.Substring(0, txtBox4.SelectionStart);
          string post = txtBox4.Text.Substring(txtBox4.SelectionStart + txtBox4.SelectionLength);
          txtBox4.Text = txtBox4.Text = pre + post;
      }
  }
  ```
- 결과  
  <img src="/uploads/e6090c249c43bd271218cf1686c4146d/image.png">

<br>

### 5. Built-in Command 및 종류

- WPF는 직접 command를 작성하거나 built-in command를 사용할 수 있다.
  - Command Source로 설계된 컨트롤에는 Command와 CommandTarget 속성이 있다.
  - Command Target으로 설계된 컨트롤에는 built-in 바인딩과 built-in command 핸들러 코드가 있다.
- WPF는 5가지 클래스에 100개 이상의 build-in command를 제공한다.
  - ApplicationCommands : 클립보드 명령을 포함한 일반적인 Application command이다.
  - ComponentCommands : 프로그램 또는 구성 요소의 항목을 이동하고 선택하는 것을 나타낸다.
  - EditingCommands : 문서를 편집하는 것을 나타낸다.
  - MediaCommands : 미디어 Application 제어하는 것을 나타낸다.
  - NavigationCommands : 문서 이동에 사용되는 작업을 나타낸다.
- 예제 프로그램
  - Cut 버튼은 Cut command의 source이고 TextBox는 Command의 target이다.
  - Paste 버튼은 Paste command의 source이고 TextBox는 commmand의 target이다.
- 이 프로그램은 code-behind에서의 추가 없이 xaml에서만 만들 수 있다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="1" Grid.Column="1">
      <TextBox Name="cutFrom5"></TextBox>
      <TextBox Name="pasteTo5"></TextBox>
  
      <StackPanel Orientation="Horizontal">
          <Button Width="50"
              Command="ApplicationCommands.Cut"
              CommandTarget="{Binding ElementName=cutFrom5}">Cut</Button>
  
          <Button Width="50"
              Command="ApplicationCommands.Paste"
              CommandTarget="{Binding ElementName=pasteTo5}">Paste</Button>
      </StackPanel>
  </StackPanel>
  ```
- 결과  
  <img src="/uploads/c50645284b1fa58265df163918e31cc4/image.png">

<br>

### 5-1 예제 code-behind에서 command를 연결

- 예제 5에서 code-behind에서 command를 연결한다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="1" Grid.Column="2">
      <TextBox Name="cutFrom51"></TextBox>
      <TextBox Name="pasteTo51"></TextBox>

      <StackPanel Orientation="Horizontal">
          <Button Width="50" Name="btnCut51">Cut</Button>

          <Button Width="50" Name="btnPaste51">Paste</Button>
      </StackPanel>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public void _09_CodeBehindCommand()
      {
          btnCut51.Command = ApplicationCommands.Cut;
          btnCut51.CommandTarget = cutFrom51;

          btnPaste51.Command = ApplicationCommands.Paste;
          btnPaste51.CommandTarget = pasteTo51;
      }
  }
  ```
- 결과  
  <img src="/uploads/3301a4be6de6e8f7ccb551955f01a55e/image.png">


<br>

### 6. The RoutedCommand 클래스

- WPF command 아키텍처의 키는 RoutedCommand 클래스이다. 
- 사용자 고유의 command를 생성하려면 다음 섹션에서 볼 수 있듯이 이 클래스의 인스턴스를 만들고 구성하고 사용할 컨트롤에 바인딩 해야 한다.
- RoutedCommand 클래스에는 Execute 및 CanExecute라는 두 가지 주요 메서드가 있다.
  - Command source의 작업으로 인해 command가 호출될 때 Excute 메서드가 호출된다.
  - source가 command를 사용할 수 있는지를 확인하려는 경우 CanExecute 메서드가 호출된다.

<br>

### 7. Creating Custom Commands

- 다음 예제 프로그램을 구성한다.
  - Reverse 버튼은 Reverse command의 source이다.
  - TextBox는 command target이다.
  - 다른 command source는 키보드 제스처 Ctrl+R이다.
  - 명령이 실행되면 버튼이나 키보드 제스처로 TextBox의 텍스트가 반전된다.
  - TextBox에 텍스트가 없으면 버튼과 키보드 제스처가 비활성화된다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel Grid.Row="2" Grid.Column="0">
      <TextBox Name="txtBox" Margin="10 10"
           FontWeight="Bold" Background="Aqua"/>
      <Button Name="btnReverse" HorizontalAlignment="Center" Padding="10 3"
          FontWeight="Bold" Margin="10 0"/>
  </StackPanel>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public void _07_CreatingCustomCommands()
      {
          btnReverse.Command = ReverseCommand.Reverse;
          btnReverse.CommandTarget = txtBox;
          btnReverse.Content = ((RoutedUICommand)(btnReverse.Command)).Text;

          CommandBinding binding = new CommandBinding();
          binding.Command = ReverseCommand.Reverse;
          binding.Executed += ReverseString_Excuted;
          binding.CanExecute += ReverseString_CanExecute;

          CommandBindings.Add(binding);
      }

      public void ReverseString_CanExecute(object sender, CanExecuteRoutedEventArgs args)
      {
          args.CanExecute = txtBox.Text.Length > 0;
      }

      public void ReverseString_Excuted(object sender, ExecutedRoutedEventArgs args)
      {
          char[] temp = txtBox.Text.ToCharArray();
          Array.Reverse(temp);
          txtBox.Text = new string(temp);
      }

      public class ReverseCommand
      {
          private static RoutedUICommand reverse;

          public static RoutedUICommand Reverse
          { get { return reverse; } }

          static ReverseCommand()
          {
              InputGestureCollection gestures = new InputGestureCollection();
              gestures.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Control-R"));

              reverse = new RoutedUICommand("Reverse", "Reverse", typeof(ReverseCommand), gestures);
          }
      }

  }
  ```
- 결과  
  <img src="/uploads/5534e6627e1d768aaf9e6f922f4caea4/image.png">

<br>


## 종합

- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <Window x:Class="_9.RoutingEventAndCommand.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:_9.RoutingEventAndCommand"
          mc:Ignorable="d"
          Title="MainWindow" Height="450" Width="550">
      <Grid ShowGridLines="True">
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
  
          <!-- 1. Event란? -->
          <StackPanel Grid.Row="0" Grid.Column="0">
              <Button Name="myButton1" Padding="10"
  			Click ="myButton_Click1"
  			MouseEnter="myButton1_MouseEnter"
  			MouseLeave="myButton1_MouseLeave">Click Me</Button>
          </StackPanel>
  
          <!-- 3-1. Routed Events Bubbling 예제 -->
          <StackPanel Orientation="Horizontal"  Grid.Row="0" Grid.Column="1">
              <Border Name="myBorder31" BorderThickness="10"   BorderBrush="BurlyWood" MouseUp="myBorder31_MouseUp">
                  <Label Name="myLabel31" Padding="10" MouseUp="myLabel31_MouseUp">
                      <Image Name="cat31" Source="3-5.jpg" Stretch="None"   MouseUp="cat31_MouseUp"/>
                  </Label>
              </Border>
              <StackPanel>
                  <Button Width="100" Name="Clear31" Padding="10, 3"   Click="Clear31_Click">Clear</Button>
                  <TextBlock Name="tb31" Margin="5 5 0 0"></TextBlock>
              </StackPanel>
          </StackPanel>
  
  
          <!-- 3-2. Routed Events Tunneling 예제 -->
          <StackPanel Orientation="Horizontal" Grid.Row="0" Grid.Column="2">
              <Border Name="myBorder32" BorderThickness="10"   BorderBrush="BurlyWood"
                      MouseUp="myBorder32_MouseUp"   PreviewMouseUp="myBorder32_PreviewMouseUp">
                  <Label Name="myLabel32" Padding="10"
                         MouseUp="myLabel32_MouseUp"   PreviewMouseUp="myLabel32_PreviewMouseUp">
                      <Image Name="cat32" Source="3-5.jpg" Stretch="None"
                             MouseUp="cat32_MouseUp"   PreviewMouseUp="cat32_PreviewMouseUp"/>
                  </Label>
              </Border>
              <StackPanel>
                  <Button Width="100" Name="Clear32" Padding="10, 3"   Click="Clear32_Click">Clear</Button>
                  <TextBlock Name="tb32" Margin="5 5 0 0"></TextBlock>
              </StackPanel>
          </StackPanel>
  
          <!-- 4. Command -->
          <StackPanel Grid.Row="1" Grid.Column="0">
              <Menu>
                  <MenuItem Header="_Cut" Click="Button_Click4"/>
              </Menu>
              <TextBox Name="txtBox4" Margin="5" FontWeight="Bold"/>
              <Button Click="Button_Click4" FontWeight="Bold" Margin="5">Cut Text</  Button>
          </StackPanel>
  
          <!-- 5. Built-in Command 및 종류 -->
          <StackPanel Grid.Row="1" Grid.Column="1">
              <TextBox Name="cutFrom5"></TextBox>
              <TextBox Name="pasteTo5"></TextBox>
  
              <StackPanel Orientation="Horizontal">
                  <Button Width="50"
                      Command="ApplicationCommands.Cut"
                      CommandTarget="{Binding ElementName=cutFrom5}">Cut</Button>
  
                  <Button Width="50"
                      Command="ApplicationCommands.Paste"
                      CommandTarget="{Binding ElementName=pasteTo5}">Paste</Button>
              </StackPanel>
          </StackPanel>
  
  
          <!-- 5-1. code-behind에서 command를 연결 -->
          <StackPanel Grid.Row="1" Grid.Column="2">
              <TextBox Name="cutFrom51"></TextBox>
              <TextBox Name="pasteTo51"></TextBox>
  
              <StackPanel Orientation="Horizontal">
                  <Button Width="50" Name="btnCut51">Cut</Button>
  
                  <Button Width="50" Name="btnPaste51">Paste</Button>
              </StackPanel>
          </StackPanel>
  
          <!-- 7. Creating Custom Commands -->
          <StackPanel Grid.Row="2" Grid.Column="0">
              <TextBox Name="txtBox" Margin="10 10"
                   FontWeight="Bold" Background="Aqua"/>
              <Button Name="btnReverse" HorizontalAlignment="Center" Padding="10 3"
                  FontWeight="Bold" Margin="10 0"/>
          </StackPanel>
      </Grid>
  </Window>

  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
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
  
  namespace _9.RoutingEventAndCommand
  {
      public partial class MainWindow : Window
      {
          public MainWindow()
          {
              InitializeComponent();
  
  
              _09_CodeBehindCommand();
  
              _07_CreatingCustomCommands();
          }
  
      }
  }
  
  
  // 1. Event란?
  namespace _9.RoutingEventAndCommand
  {
      public partial class MainWindow : Window
      {
          private void myButton_Click1(object sender, RoutedEventArgs e)
          {
              string c = myButton1.Content.ToString();
              myButton1.Content = (c == "Clicked" || c == "Clicked Again")
              ? "Clicked Again"
              : "Clicked";
          }
  
          private void myButton1_MouseEnter(object sender, MouseEventArgs e)
          {
              myButton1.Content = "Mouse Over";
          }
  
          private void myButton1_MouseLeave(object sender, MouseEventArgs e)
          {
              myButton1.Content = "Click Me";
          }
      }
  }
  
  // 3-1. Routed Events Bubbling 예제
  namespace _9.RoutingEventAndCommand
  {
      public partial class MainWindow : Window
      {
          private void myBorder31_MouseUp(object sender, MouseButtonEventArgs e)
          {
              tb31.Text += "Border sees it.\r\n";
          }
  
          private void myLabel31_MouseUp(object sender, MouseButtonEventArgs e)
          {
              tb31.Text += "Label sees it.\r\n";
          }
  
          private void cat31_MouseUp(object sender, MouseButtonEventArgs e)
          {
              tb31.Text += "Image sees it.\r\n";
          }
  
          private void Clear31_Click(object sender, RoutedEventArgs e)
          {
              tb31.Text = "";
          }
      }
  }
  
  // 3-2. Routed Events Tunneling 예제
  namespace _9.RoutingEventAndCommand
  {
      public partial class MainWindow : Window
      {
          private void myBorder32_MouseUp(object sender, MouseButtonEventArgs e)
          {
              tb32.Text += "Bubbling : Border sees it.\r\n";
          }
  
          private void myLabel32_MouseUp(object sender, MouseButtonEventArgs e)
          {
              tb32.Text += "Bubbling : Label sees it.\r\n";
          }
  
          private void cat32_MouseUp(object sender, MouseButtonEventArgs e)
          {
              tb32.Text += "Bubbling : Image sees it.\r\n";
          }
  
  
          private void Clear32_Click(object sender, RoutedEventArgs e)
          {
              tb31.Text = "";
          }
  
  
          private void myBorder32_PreviewMouseUp(object sender,   MouseButtonEventArgs e)
          {
              tb32.Text += "Tunneling : Border sees it.\r\n";
          }
  
          private void myLabel32_PreviewMouseUp(object sender,   MouseButtonEventArgs e)
          {
              tb32.Text += "Tunneling : Label sees it.\r\n";
          }
  
          private void cat32_PreviewMouseUp(object sender, MouseButtonEventArgs e)
          {
              tb32.Text += "Tunneling : Image sees it.\r\n";
          }
  
      }
  }
  
  
  // 4. Command
  namespace _9.RoutingEventAndCommand
  {
      public partial class MainWindow : Window
      {
          private void Button_Click4(object sender, RoutedEventArgs e)
          {
              if (txtBox4.SelectedText.Length <= 0)
                  return;
  
              Clipboard.SetData(DataFormats.Text, (object)txtBox4.SelectedText);
              string pre = txtBox4.Text.Substring(0, txtBox4.SelectionStart);
              string post = txtBox4.Text.Substring(txtBox4.SelectionStart +   txtBox4.SelectionLength);
              txtBox4.Text = txtBox4.Text = pre + post;
          }
      }
  }
  
  
  // 5-1 예제 code-behind에서 command를 연결
  namespace _9.RoutingEventAndCommand
  {
      public partial class MainWindow : Window
      {
          public void _09_CodeBehindCommand()
          {
              btnCut51.Command = ApplicationCommands.Cut;
              btnCut51.CommandTarget = cutFrom51;
  
              btnPaste51.Command = ApplicationCommands.Paste;
              btnPaste51.CommandTarget = pasteTo51;
          }
      }
  }
  
  
  // 7. Creating Custom Commands
  namespace _9.RoutingEventAndCommand
  {
      public partial class MainWindow : Window
      {
          public void _07_CreatingCustomCommands()
          {
              btnReverse.Command = ReverseCommand.Reverse;
              btnReverse.CommandTarget = txtBox;
              btnReverse.Content = ((RoutedUICommand)(btnReverse.Command)).Text;
  
              CommandBinding binding = new CommandBinding();
              binding.Command = ReverseCommand.Reverse;
              binding.Executed += ReverseString_Excuted;
              binding.CanExecute += ReverseString_CanExecute;
  
              CommandBindings.Add(binding);
          }
  
          public void ReverseString_CanExecute(object sender,   CanExecuteRoutedEventArgs args)
          {
              args.CanExecute = txtBox.Text.Length > 0;
          }
  
          public void ReverseString_Excuted(object sender, ExecutedRoutedEventArgs   args)
          {
              char[] temp = txtBox.Text.ToCharArray();
              Array.Reverse(temp);
              txtBox.Text = new string(temp);
          }
  
          public class ReverseCommand
          {
              private static RoutedUICommand reverse;
  
              public static RoutedUICommand Reverse
              { get { return reverse; } }
  
              static ReverseCommand()
              {
                  InputGestureCollection gestures = new InputGestureCollection();
                  gestures.Add(new KeyGesture(Key.R, ModifierKeys.Control,   "Control-R"));
  
                  reverse = new RoutedUICommand("Reverse", "Reverse", typeof  (ReverseCommand), gestures);
              }
          }
  
      }
  }
  ```
- 결과  
  <img src="">

### 0. s

<br>

<br><br><br>

# Ch 10. 다양한 Control 및 Element

### 0. Summary(요약)

- <img src="/uploads/c17b0fffc1fb465cf3ea78e63327aaf1/image.png" width="70%">

<br>

### 1. TextBox

- TextBox는 사용자로부터 작은 크기의 텍스트를 검색하는 데 유용하다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel>
      <Label Target="{Binding ElementName=txtbxName1}">_Enter Your Name</Label>
      <TextBox Name="txtbxName1"/>
      <Button HorizontalAlignment="Right" Padding="10 3"
          Click="Button_Click1">Enter</Button>
  </StackPanel>

  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      private void Button_Click1(object sender, RoutedEventArgs e)
      {
          MessageBox.Show("You entered: " + txtbxName1.Text, "TextBox Message");
      }
  }
  ```
- 결과  
  <img src="/uploads/d0982c127b682c614215f47b7db5e433/image.png">

<br>

### 2. Menus

- Menus는 명령을 실행하거나 옵션을 설정하기 위해 사용자가 선택할 수 있는 옵션 목록이다. 
- Context menus는 특정 element와 연결된다.
  - 메뉴 항목 목록은 메뉴가 보일 때마다 표시되는 최상위 메뉴로 구성된다.
  - 각 MenuItem 개체에는 메뉴 item에 label을 지정하는 문자열이 포함된 header 속성이 있다.
  - 이벤트 핸들러를 MenuItem의 클릭 이벤트에 할당할 수 있다. 그러면 사용자가 메뉴 항목을 클릭할 때마다 핸들러를 실행한다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <Menu>
      <MenuItem Header="File">
          <MenuItem Header="New Game" Click="MenuItem2_Click"/>
          <MenuItem Header="Exit" Click="MenuItem2_Click_1"/>
      </MenuItem>
      <MenuItem Header="Help" Click="MenuItem2_Click_2"/>
  </Menu>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      private void MenuItem2_Click(object sender, RoutedEventArgs e)
      {
          MessageBox.Show("Clicked New Game", "Menu Info");
      }

      private void MenuItem2_Click_1(object sender, RoutedEventArgs e)
      {
          MessageBox.Show("Clicked Exit", "Menu Info");
      }

      private void MenuItem2_Click_2(object sender, RoutedEventArgs e)
      {
          MessageBox.Show("Clicked Help", "Menu Info");
      }
  }
  ```
- 결과  
  <img src="/uploads/850991dd06e37ec378af12bbfbdf8e1a/image.png">

<br>

### 2-1. MenuItem 선택

- MenuItem의 IsChecked 속성을 true로 설정하여 메뉴 라벨의 왼쪽에 체크 표시를 설정할 수 있다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <Menu>
      <MenuItem Header="File">
          <MenuItem Header="New Game" Click="MenuItem21_Click" 
        InputGestureText="Alt+N">
              <MenuItem.Icon>
                  <Image Source="card1.jpg"/>
              </MenuItem.Icon>
          </MenuItem>
          <MenuItem Header="Shuffle Sound" Click="MenuItem21_Click_1"
            IsChecked="True" InputGestureText="Alt+S"/>
      </MenuItem>
  </Menu>
  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {

      private void MenuItem21_Click(object sender, RoutedEventArgs e)
      {
          MessageBox.Show("Clicked New Game");
      }

      private void MenuItem21_Click_1(object sender, RoutedEventArgs e)
      {
          MessageBox.Show("Clicked Shuffle Sound");
      }
  }
  ```
- 결과  
  <img src="/uploads/5b7dd50d0a53ab1f73ce5c80d00e7985/image.png">


<br>

### 2-2. 다른 타입의 Menu Header 설정

- 지금까지 본 메뉴 label은 텍스트이지만, header 속성은 UIElement에서 파생된 모든 클래스의 개체를 할당할 수 있다. 
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <Menu Grid.Row="0" Grid.Column="3">
      <MenuItem Header="File">
          <MenuItem InputGestureText="Alt+K">
              <MenuItem.Header>
                  <Image Source="card1.jpg"/>
              </MenuItem.Header>
          </MenuItem>
          <MenuItem InputGestureText="Alt+Q">
              <MenuItem.Header>
                  <Image Source="card2.jpg"/>
              </MenuItem.Header>
          </MenuItem>
          <MenuItem InputGestureText="Alt+J">
              <MenuItem.Header>
                  <Image Source="card3.jpg"/>
              </MenuItem.Header>
          </MenuItem>
      </MenuItem>
  </Menu>
  ```
- 결과  
  <img src="/uploads/504ad2b56c015b787a9bd8749e36d63d/image.png">

<br>

### 2-3. MenuItem 에 Command 할당

- 키보드 단축키를 손으로 메뉴 항목에 연결하는 것은 번거로울 수 있다.
- 하지만 command에 연결하는 것은 쉽다.
- MenuItem의 Command 속성에 command를 할당하기만 하면 된다.
- Header의 텍스트를 command 이름의 텍스트로 자동 설정할 수 있다.
- xaml 코드를 다음과 같이 구성한다.
  ```xml
  <StackPanel>
      <Menu>
          <MenuItem Header="File">
              <MenuItem Command="ApplicationCommands.New"/>
              <MenuItem Command="ApplicationCommands.Open"/>
          </MenuItem>
      </Menu>
  </StackPanel>

  ```
- xaml.cs 코드를 다음과 같이 구성한다.
  ```cs
  public partial class MainWindow : Window
  {
      public void _2_3_MenuItemCommand()
      {
          CommandBinding nBinding = new CommandBinding();    //Binding for New
          nBinding.Command = ApplicationCommands.Open;
          nBinding.Executed += DoOpen_Executed;
          nBinding.CanExecute += DoOpen_CanExecute;

          CommandBinding oBinding = new CommandBinding();    //Binding for Open
          oBinding.Command = ApplicationCommands.New;
          oBinding.Executed += DoNew_Executed;
          oBinding.CanExecute += DoNew_CanExecute;

          CommandBindings.Add(nBinding);
          CommandBindings.Add(oBinding);
      }

      private void DoOpen_CanExecute(object sender, CanExecuteRoutedEventArgs e)
      {
          e.CanExecute = true;
      }

      private void DoOpen_Executed(object sender, ExecutedRoutedEventArgs e)
      {
          MessageBox.Show("Open Command Executed", "Command Info");
      }

      private void DoNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
      {
          e.CanExecute = true;
      }

      private void DoNew_Executed(object sender, ExecutedRoutedEventArgs e)
      {
          MessageBox.Show("New Command Executed", "Command Info");
      }
  }
  ```
- 결과  
  <img src="/uploads/b1ae2f4705d5add626ab11b18d26c12e/image.png">


<br>

### 0. s

<br>

### 0. s

<br>

### 0. s

<br>

### 0. s

<br>

### 0. s

<br>

### 0. s

<br>

### 0. s

<br>

### 0. s

<br>

### 0. s

<br>

### 0. s

<br>



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

