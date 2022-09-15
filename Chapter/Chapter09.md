# 9. WPF 이벤트라우팅 (버블링, 터널링, 다이렉트)

- [+이벤트 라우팅+]은 [+어떤 이벤트가 컨트롤의 하위 또는 상위로 전달 되는 것+]
- 이벤트가 발생시 [+상위로 전달+]되는 경우를 [-버블링 이벤트-] (WPF 이벤트는 자동 버블링 설정) 라고 한다.
- 이벤트가 발생사 [+하위로 전달자식+]되는 경우를 [-터널링 이벤트-] (접두사 preview; PreviewMouseDown, PreviewDragDown 등) 라고 한다.
- 하나의 엘리먼트에서만 발생할시, [+다이렉트 이벤트+]라고 한다.

<br>

### 터널링 이벤트

- 최상위 부모 컨트롤로부터 자신까지 이벤트 진행
- 이벤트가 자식 요소에게 전달되기 전에 부모 이벤트가 먼저 호출되므로 부모 이벤트가 먼저 호출할 수 있는 기회를 제공
- 자식의 이벤트 발생을 막거나 자식 이벤트 처리 전에 부모 요소가 수행 작업 할 경우
- 이벤트 핸들러 메소드는 RoutedEventArgs 매개변수를 가지는데 Source 속성을 통해 실제 이벤트를 발생시킨 요소에 대한 참조를 제공하며, 이 속성은 여러 요소에서 발생한 이벤트를 동일한 방법으로 처리하고자 할 때 유용
  <img src="http://wish.mirero.co.kr/mirero/education/newface-group/newface/donggye.jang/uploads/494121373483f3a3f1af4605af4c4474/image.png" width="70%">

<br>

### 이벤트 라우팅 - 버블링 실습

- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_09.wpfRoutedEvent.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_09.wpfRoutedEvent"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800"
        ButtonBase.Click="Window_Click">
    <Grid>
        <StackPanel Margin="20" ButtonBase.Click="StackPanel_Click">
            <StackPanel Margin="10">
                <TextBlock Name="txt1" FontSize="18" Margin="5" Text="TextBlock 1"/>
                <TextBlock Name="txt2" FontSize="18" Margin="5" Text="TextBlock 2"/>
                <TextBlock Name="txt3" FontSize="18" Margin="5" Text="TextBlock 3"/>
            </StackPanel>
            <Button Margin="10" Content="Click me" Click="Button_Click" Width="80"/>
        </StackPanel>
    </Grid>


</Window>
```
</details>

- 코드를 다음과 같이 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
using System;
using System.Windows;

namespace _09.wpfRoutedEvent
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
            txt1.Text = "Button is Clicked";
            e.Handled = true;
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            txt2.Text = "Click event is bubbled to Stack Panel";
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            txt3.Text = "Click event is bubbled to Window";
        }

    }
}
```
</details>


### 이벤트 라우팅 - 터널링 실습

- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_09.wpfRoutedEvent.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_09.wpfRoutedEvent"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800"
        ButtonBase.Click="Window_Click">
    <Grid>
        <StackPanel Margin="20" ButtonBase.Click="StackPanel_Click">
            <StackPanel Margin="10">
                <TextBlock Name="txt1" FontSize="18" Margin="5" Text="TextBlock 1"/>
                <TextBlock Name="txt2" FontSize="18" Margin="5" Text="TextBlock 2"/>
                <TextBlock Name="txt3" FontSize="18" Margin="5" Text="TextBlock 3"/>
            </StackPanel>
            <Button Margin="10" Content="Click me" Click="Button_Click" Width="80"/>
        </StackPanel>
    </Grid>


</Window>
```
</details>

- 코드를 다음과 같이 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
using System;
using System.Windows;

namespace _09.wpfRoutedEvent
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
            txt1.Text = "Button is Clicked";
            e.Handled = true;
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            txt2.Text = "Click event is bubbled to Stack Panel";
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            txt3.Text = "Click event is bubbled to Window";
        }

    }
}
```
</details>
