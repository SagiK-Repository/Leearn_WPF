# 6. WPF Trigger (2)

### 데이터 트리거

- DataTrigger 클래스는 이전의 프로퍼티 트리거의 Property를 바인딩으로 대신하는 것을 제외하고는 Trigger와 유사한데 바인딩은 다른 엘리먼트를 참조한다.
- DataTrigger는 바인딩 되는 값이 특정 값을 가질 때 프로퍼티를 설정할 수 있게 해준다.
- 요소로 표시하며 트리거는 의존속성이 아닌 속성에 사용된다.
- Model View View Model(MVVM) 디자인 패턴을 사용하여 데이터 바인딩을 사용하는 경우 이상적이다.

<br>

### 실습 1
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_06.WPF_Trigger__2____1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_06.WPF_Trigger__2____1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Window.Resources>
        <Style x:Key="MyStyle" TargetType="TextBlock">
            <Setter Property="Visibility" Value="Visible"/> <!--보이게-->
            <Style.Triggers>
                <DataTrigger Binding="{Binding ElementName=cb1, Path=IsChecked}" Value="True"> <!--if와 동일-->
                    <Setter Property="Visibility" Value="Hidden"/> <!--숨기기-->
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <StackPanel>
        <CheckBox Name="cb1" Content="Click Me!" FontSize="20"/>
        <TextBlock Text="Hello WPF!" FontSize="20" Style="{StaticResource MyStyle}"/>
    </StackPanel>

</Window>

```

</details>

### 결과사진

![06-1](https://user-images.githubusercontent.com/66783849/189936244-659439f7-db6f-43c3-b071-08e7bc3a8df2.png)



<br>


### 실습 2
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_06.WPF_Trigger__2____2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_06.WPF_Trigger__2____2"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Window.Resources>
        <Style TargetType="{x:Type ProgressBar}"> <!--Style을 특정 타입으로 지정할 수 있다.-->
            <Setter Property="Foreground" Value="Blue"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding TheValue}" Value="20"> <!--PrograssBar의 최소 : 10, 최대 : 20-->
                    <Setter Property="Foreground" Value="Red"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions> 
            <RowDefinition/> <!--행이 3개-->
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Slider x:Name="MySlider" Margin="5" Minimum="10" Maximum="20" Value="{Binding TheValue}"/>
        <ProgressBar Grid.Row="1" Minimum="10" Maximum="20" Value="{Binding TheValue}"/>
        <TextBox Grid.Row="2" Text="{Binding TheValue}"/>
    </Grid>

</Window>
```

</details>
- 코드를 다음과 같이 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
namespace _06.WPF_Trigger__2____2
{
    
    public class DataObject
    {
        public int TheValue { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataObject(); // DataContext : Window 소스매트를 지정
        }
    }
}
```

</details>

### 결과 사진

![06-2](https://user-images.githubusercontent.com/66783849/189936310-5fd69835-878d-464b-a30a-30c4b1b51d10.png)
