# 8. 의존프로퍼티, 의존속성

- XAML, C# 코드 비하인드에서 사용 가능하며 의존속성 값이 변경되면 자동으로 어떤 것을 로드되게 하거나 랜더링 되도록 할 수 있다.
- 어떤 속성을 애니메이션 시키거나 데이터 바인딩 하려면 그 속성은 반드시 의존 속성이어야 한다.
- 기본 제공되는 UI 컨트롤은 대부분 의존 속성이다.
- FrameworkElement, Control 등과 같이 DependencyObejct 에서 파생된 클래스에서만 정의할 수 있다.
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- Context 메뉴를 만든다.
  - MainWindow 클릭 > 속성 창 > 기타 > Context Menu 새로만들기 클릭
- UI를 구성한다.
<details><summary>MainWindow.xml</summary>

```xml
<Window x:Class="_08.DependencyProperty.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_08.DependencyProperty"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Window.ContextMenu>
        <ContextMenu MenuItem.Click="ContextMenu_Click">
            <MenuItem Header="YELLOW"/>
            <MenuItem Header="GREEN"/>
            <MenuItem Header="BLUE"/>
        </ContextMenu>
    </Window.ContextMenu>
    <TextBox x:Name="textBox1" HorizontalAlignment="Left" Height="37" Margin="234,188,0,0" TextWrapping="Wrap" Text="TextBox" VerticalAlignment="Top" Width="355"/>
</Window>
```
</details>
- 코드를 다음과 같이 구성한다.
<details><summary>MainWindow.xml.cs</summary>

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

namespace _08.wpfDependencyProperty
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

        // DependencyProperty(MyProperty)를 위한 래퍼속성 MyColor
        // 이 래퍼속성은 System.Windows.DependencyObject 클래스의 GetValue()와 SetValue() 메서드를 이용해 get, set을 정의해야 한다.
        public string MyColor
        {
            get { return (string)GetValue(MyProperty); }
            set { SetValue(MyProperty, value); }
        }

        // 의존속성 MyProperty
        // 수정이 불가하도록 의존속성 읽기전용으로 선언
        public static readonly DependencyProperty MyProperty = DependencyProperty.Register(
            "MyColor",          // 읜존속성으로 등록될 속성
            typeof(string),     // 등록할 의존속성 타입
            typeof(MainWindow), // 의존속성을 소유하게될 owner
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged))); // 속성값 변경시 호출될 메소드
                                                                                              // 프로퍼티 값의 변경에 따른 callback 메소드 등 새로운 속성을 추가하기 위해 
                                                                                              // FrameworkPropertyMetadata를 인자 값으로 전달할 수 있다.
        private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow win = d as MainWindow;
            SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewValue.ToString());
            win.Background = brush;
            win.Title = (e.OldValue == null) ? "이전배경색 없음" : "배경색 : " + e.OldValue.ToString();
            win.textBox1.Text = e.NewValue.ToString();
        }

        private void ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            string str = (e.Source as MenuItem).Header as string;
            MyColor = str;
        }

    }
}
```
</details>




### 결과

- <img src="https://user-images.githubusercontent.com/66783849/190459730-262426e9-effc-46a2-b676-c32692b72dc1.png" width="70%">
