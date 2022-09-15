# 11. 데이터바인딩 실습, DataBinding Mode
- 소스와 타겟의 의미는 소스 속성의 변화를 타겟의 속성에 반영되도록 하는 의미를 담고 있는데 바인딩 모드는 4가지이다.
  - OneWay : Source가 Target으로 단방향 바인딩 설정된다.
  - TwoWay : Source와 Target 양방향 바인딩 설정된다. (지정하지 않으면 TwoWay이다.)
  - OneTime : Target이 Source로부터 초기화 되지만 소스의 변화가 계속 반영되지 않고 초기 한 번만 반영된다.
  - OneWayToSource : Source, Target의 의미가 반대가 되도록 타겟이 소스를 갱신하는 모양이다.
  ```xml
  <Label Name="label" Content="대한민국" HorizontalAlignment="Center" BorderBrush="Black" BorderThickness="2"/> <!--Source-->
  <TextBox Margin="24" Text="{Binding ElementName=label, Path=Content, UpdateSourceTrigger=PropertyChanged}"/> <!--Target--> <!-- 객체 : label, 속성 content -->
  
  <TextBox Margin="24" Text="{Binding x:Reference label, Path=Content, UpdateSourceTrigger=PropertyChanged}"/> <!-- x:Reference 가능 -->
  
  <!-- 또는 -->
  <TextBox Name="txt1" Margin="24" />
  <Label HorizontalAlignment="Center" BorderBrush="Black" BorderThickness="2" Content="{Binding ElementName=txt1, Path=Text}" />
  ```

<br>

### XAML 바인딩

- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_11.wpfDataBinding.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_11.wpfDataBinding"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <StackPanel>
        <!--Binding Target-->
        <!--UpdateSourceTrigger는 타겟이 소스를 갱신하는 타이밍을 지정-->
        <!--TextBox인 경우 LostFocus가 기본이므로 값이 바뀔때마다 갱신하기 위해 PropertyChanged로 설정-->
        <TextBox Margin="24" Text="{Binding ElementName=label, Path=Content, UpdateSourceTrigger=PropertyChanged, Mode = TwoWay}"/> <!--Target-->
        <Label Name="label" Content="대한민국" HorizontalAlignment="Center" BorderBrush="Black" BorderThickness="2"/> <!--Source-->
    </StackPanel>
</Window>
```
</details>

##### 방향 별 동작 결과
- OneWay : 작동 안됨, 최초 받음("대한민국")
- TwoWay : 작동됨
- OneTime : 최초 받음("대한민국")
- OneWayToSource : 작동 안됨, 최초 못 받음(" ")


<br>

### C# 바인딩

- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- UI를 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
namespace _11.wpfDataBinding___2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Binding bind = new Binding();
            bind.Source = text;
            bind.Path = new PropertyPath(TextBox.TextProperty);

            label.SetBinding(Label.ContentProperty, bind);
        }
    }
}
```
</details>

### 결과

- <img src="https://user-images.githubusercontent.com/66783849/190459887-42fe4bdf-e886-4c25-9500-e881c491f2ff.png" width="30%">
