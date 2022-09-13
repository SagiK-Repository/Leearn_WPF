# 5. WPF Trigger

### WPF 트리거(Trigger)란?

- [+Trigger+]는 [+어떤 조건, 이벤트+] 등이 주어졌을 때 [-묵시적으로 컨트롤의 상태 또는 이벤트 핸들러 등을 호출-]하는 기능을 의미한다.
- 즉, Trigger를 사용하면 엘리먼트의 프로퍼티나 데이터 바인딩, 이벤트에서 발생하는 변화에 엘리먼트와 컨트롤이 어떻게 반응할지를 정할 수 있다.
- Style의 Setter와 비교할 때 둘 다 프로퍼티를 설정하지만 Setter는 엘리먼트가 처음 생성되었을 때의 프로퍼티를 설정하며 Trigger는 프로퍼티가 변경되는 경우에 프로퍼티를 설정하는 점이 다르다.

<br>

### 프로퍼티 트리거

- TriggerBase중 가장 일반적인 파생클래스는 특정 프로퍼티의 변화에 내부에 정의한 Setter 컬렉션이 실행되는 트리거이다.
- 컨트롤이나 엘리먼트가 반응하는 방법을 정의하는 Trigger인데 대부분이 프로퍼티는 ImMouseOver 프로퍼티와 같은 사용자의 입력 프로퍼티를 포함하는데 이때 Trigger는 Setter에서 정의된 프로퍼티를 변경한다.

<br>

### 실습 1
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_05.WPF_Trigger.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_05.WPF_Trigger"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <TextBlock Name = "tblk1" Text="Hello, WPF world!" FontSize="30" HorizontalAlignment="Center" VerticalAlignment="Center">
            <TextBlock.Style>
                <Style TargetType="TextBlock">
                    <Setter Property="Foreground" Value="Green"></Setter>
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="true">
                            <Setter Property="Foreground" Value="Red" />
                            <Setter Property="TextDecorations" Value="Underline" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </TextBlock.Style>
        </TextBlock>
    </Grid>

</Window>
```

</details>

### 결과

![05-1](https://user-images.githubusercontent.com/66783849/189935610-1144e89c-441b-4f8a-90c4-88e1330d1689.png)


<br>



### 실습 2
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_05.WPF_Trigger.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_05.WPF_Trigger"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Window.Resources>
        <Style x:Key="MyStyle">
            <Setter Property="Control.Foreground" Value="Red" />
            <Setter Property="TextBlock.Text" Value="Hello WPF!"/>
            <Style.Triggers>
                <Trigger Property="Control.IsMouseOver" Value="true">
                    <Setter Property="Control.Foreground" Value="Blue"/>
                    <Setter Property="TextBlock.Text" Value="버튼으로 진입했습니다."/>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <StackPanel>
        <Button Width="100" Height="70"
                Style="{StaticResource MyStyle}" Content="Trigger"/>
        <TextBlock Style="{StaticResource MyStyle}" FontSize="30" HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </StackPanel>
</Window>
```

</details>


### 결과

![05-2](https://user-images.githubusercontent.com/66783849/189935706-b20bc8b1-d716-4a30-ae50-bf9edbaa0686.png)

