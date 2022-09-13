# 2. WPF XAML HellowWorld

- Visual Studio > 새 프로젝트 > WPF 애플리케이션(응용프로그램) > 프로젝트 이름 변경 > 완료
- App.xaml파일 : 기본 설정 파일
  ```xml
  <Window x:Class="_00._HellowWorld.MainWindow"
          <!--주석 내용 프레젠 테이션을 위한 기본 네임스페이스
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:_00._HellowWorld"
          mc:Ignorable="d"
          Title="MainWindow" Height="450" Width="800">
      <Grid>
          <Label Content="Enter a Name?" HorizontalAlignment="Left" Margin="39,34,0,0" VerticalAlignment="Top"/>
  
      </Grid>
  </Window>
  ```
- MainWindow.xaml.cs 파일 : UI 구성
  ```cs
  namespace _00._HellowWorld
  {
      public partial class MainWindow : Window
      {
          public MainWindow()
          {
              InitializeComponent(); // 기본적인 UI 초기화
          }
      }
  }
  ```
- 중요부분  
  <img src="https://docs.microsoft.com/ko-kr/dotnet/desktop/wpf/get-started/media/create-app-visual-studio/netdesktop-6.0/vs-main-window.png?view=netdesktop-6.0" width="70%">
  1. 솔루션 탐색기
  2. 속성
  3. 도구상자
  4. XAML 디자이너
  5. XAML 코드 편집기
- 왼쪽 도구상자 창을 활용하여 기본 UI를 구성한다.
  - Label - 속성 - 이름 : "label", Content : "Enter a Name ?"
  - TextBox - 이름 : "textBox"
  - button - 속성 - 이름 : "button", Content : "Click Me!"
  - TextBlock - 속성 - 이름 : "textBlock", Content : "Hello World!"
  ```xml
  <Window x:Class="_00._HellowWorld.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:_00._HellowWorld"
          mc:Ignorable="d"
          Title="MainWindow" Height="225" Width="454">
      <Grid>
          <Label x:Name="lable" Content="Enter a Name?" HorizontalAlignment="Left"   Margin="39,34,0,0" VerticalAlignment="Top"/>
        <TextBox x:Name="textBox" HorizontalAlignment="Left" Height="26"   Margin="139,34,0,0" TextWrapping="Wrap" Text="TextBox" VerticalAlignment="Top" Width="115"/>
        <Button x:Name="button" Content="Click Me!" HorizontalAlignment="Left"   Height="26" Margin="259,34,0,0" VerticalAlignment="Top" Width="103"/>
        <TextBlock x:Name="textBlock" HorizontalAlignment="Left" Height="26"   Margin="39,79,0,0" TextWrapping="Wrap" Text="Hello World!" VerticalAlignment="Top" Width="323"/>

      </Grid>
  </Window> 
  ```
- Button UI를 클릭 > 속성 > 번개표시 > Click 더블 클릭
- 코드를 다음과 같이 구성한다.
  <details><summary>xml 구성</summary>
  
  ```xml
  <Window x:Class="_00._HellowWorld.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:_00._HellowWorld"
          mc:Ignorable="d"
          Title="MainWindow" Height="225" Width="454">
      <Grid>
          <Label x:Name="lable" Content="Enter a Name?" HorizontalAlignment="Left" Margin="39,34,0,0" VerticalAlignment="Top"/>
          <TextBox x:Name="textBox" HorizontalAlignment="Left" Height="26" Margin="139,34,0,0" TextWrapping="Wrap" Text="TextBox" VerticalAlignment="Top" Width="115"/>
          <Button x:Name="button" Content="Click Me!" HorizontalAlignment="Left" Height="26" Margin="259,34,0,0" VerticalAlignment="Top" Width="103"/>
          <TextBlock x:Name="textBlock" HorizontalAlignment="Left" Height="26" Margin="39,79,0,0" TextWrapping="Wrap" Text="Hello World!" VerticalAlignment="Top" Width="323"/>
  
      </Grid>
  </Window> 

  ```
  </details>
- 코드를 다음과 같이 구성한다.
  <details><summary>cs 구성</summary>
  
  ```cs
  namespace _00._HellowWorld
  {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
          public MainWindow()
          {
              InitializeComponent();
          }
  
          private void Button_Click(object sender, RoutedEventArgs e)
          {
              MessageBox.Show(textBox.Text + "님 환영합니다.", "Hello World!");
          }
  
          private void TextBlockMouseLeftButtonUp(object sender, RoutedEventArgs e)
          {
              MessageBox.Show("Hi There!", "Hello World", MessageBoxButton.OK, MessageBoxImage.Information);
          }
  
          private void button_Click_1(object sender, RoutedEventArgs e)
          {
              MessageBox.Show(textBox.Text + "님 환영합니다.", "Hello World!");
          }
      }
  }
  ```
  </details>
