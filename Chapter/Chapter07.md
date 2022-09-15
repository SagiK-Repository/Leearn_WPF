# 7. ListBox와 LINQ쿼리데이터바인딩, 새창띄우기, 이벤트 및 델리게이트를 통한 메인 윈도우리스트박스리프레쉬

- 새 창으로 직무 타입(외근/내근)등록, 리스트 박스로 모니터링 관리 WPF 만들기
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("Duty.cs") > 추가
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > WPF > WPF > 이름 변경 ("SubWindow.xaml") > 추가
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_07.WPF_Example.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_07.WPF_Example"
        mc:Ignorable="d"
        Title="MainWindow" Height="521" Width="451">
    <Window.Resources>
        <local:Duties x:Key="duties"/>
        <!--Duties 클래스를 로컬로 등록-->
        <DataTemplate x:Key="MyTemplate">
            <!--데이터 탬플릿-->
            <Border Name ="border">
                <!--선-->
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition/>
                        <RowDefinition/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Row="0" Grid.Column="0" Text="Duty Name:"/>
                    <TextBlock Grid.Row="0" Grid.Column="1" Text="{Binding Path=DutyName}"/>
                    <TextBlock Grid.Row="1" Grid.Column="0" Text="DutyType:"/>
                    <TextBlock Grid.Row="1" Grid.Column="1" Text="{Binding Path=DutyType}"/>
                    <Separator Grid.Row="2" Grid.ColumnSpan="2"/>
                </Grid>
            </Border>
        </DataTemplate>
        <LinearGradientBrush x:Key="GrayBlueGradientBrush" StartPoint="0,0" EndPoint="1,1">
            <!--브러쉬-->
            <GradientStop Color="DarkGray" Offset="0" />
            <GradientStop Color="#CCCCFF" Offset="0.5" />
            <GradientStop Color="DarkGray" Offset="1" />
        </LinearGradientBrush>
        <Style TargetType="{x:Type Button}">
            <!--버튼 전용 스타일-->
            <Setter Property="Background" Value="{StaticResource GrayBlueGradientBrush}"/>
            <Setter Property="Width" Value="80"/>
            <Setter Property="Margin" Value="10"/>
        </Style>
    </Window.Resources>
    <StackPanel>
        <Button x:Name="Add" Click="Add_Click">직무 추가</Button>
        <TextBlock Margin="10,0,0,0">직무타입을 선택 하세요.</TextBlock>
        <ListBox Name="myListBox1" SelectionChanged="OnSelected" SelectedIndex="0" Margin="10,0,10,0">
            <ListBoxItem>Inner</ListBoxItem>
            <ListBoxItem>OutSide</ListBoxItem>
        </ListBox>
        <TextBlock Margin="10,10,0,-10">직무</TextBlock>
        <ListBox Width="400" Margin="10" Name="myListBox2"
                 HorizontalAlignment="Stretch"
                 ItemsSource="{Binding}"
                 ItemTemplate="{StaticResource MyTemplate}"
                 SelectionChanged="OnSelected2"/>
    </StackPanel>
</Window>
```

</details>
- 코드를 다음과 같이 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
using System;
using System.Windows;

namespace _07.WPF_Example
{
    /// <summary>
    /// SubWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubWindow : Window
    {
        // 메인 윈도우의 하단 ListBox를 Refresh하기 위한 델리게이트. 직무추가 버튼 클릭할 때 이벤트 할당
        public Delegate UpdateActor;

        public SubWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rdoInner.IsChecked == false && rdoOutside.IsChecked == false)
            {
                MessageBox.Show("내근 또는 외근을 선택하세요.", "항목선택");
                return;
            }

            DutyType dutyType = (rdoInner.IsChecked == true) ? DutyType.Inner : DutyType.OutSide;

            MainWindow._duties.Add(new Duty(txtDutyName.Text, dutyType));


            UpdateActor.DynamicInvoke(dutyType);

            MessageBox.Show("저장OK!", "저장확인");
            this.Close();

        }
    }
}
```

</details>
- Duty.cs를 다음과 같이 구성한다.
<details><summary>Duty.cs</summary>

```cs
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.WPF_Example
{
    public enum DutyType
    {
        Inner, OutSide
    }

    public class Duty
    {
        private string _name; // 직무명
        private DutyType _dutyType; // 직무 타입, 내근, 외근

        public Duty() { }
        public Duty(string name, DutyType dutyType)
        {
            _name = name;
            _dutyType = dutyType;
        }

        public string DutyName
        {
            get { return _name; }
            set { _name = value; }
        }

        public DutyType DutyType
        {
            get { return _dutyType; }
            set { _dutyType = value; }
        }
    }

    public class Duties : ObservableCollection<Duty> // ObservableCollection : 커렉션에 값이 변결될 때 자동 감지
    {
        public Duties() {
            Add(new Duty("SALES", DutyType.OutSide));
            Add(new Duty("LOGISTICS", DutyType.OutSide));
            Add(new Duty("IT", DutyType.Inner));
            Add(new Duty("MARKETING", DutyType.Inner));
            Add(new Duty("HR", DutyType.Inner));
            Add(new Duty("PROPOTION", DutyType.OutSide));
        }
    }

}

```

</details>
- SubWindow.xaml를 다음과 같이 구성한다.
<details><summary>SubWindow.xaml</summary>

```cs
<Window x:Class="_07.WPF_Example.SubWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_07.WPF_Example"
        mc:Ignorable="d"
        Title="SubWindow" Height="268" Width="388">
    <Grid Margin="10">
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="40"/>
            <RowDefinition Height="40"/>
            <RowDefinition Height="40"/>
        </Grid.RowDefinitions>
        <TextBlock FontSize="20" Grid.ColumnSpan="3" HorizontalAlignment="Center" VerticalAlignment="Center">직무 등록</TextBlock>
        <TextBlock Grid.Row="1" Margin="10" VerticalAlignment="Center">직무명</TextBlock>
        <TextBox x:Name="txtDutyName" Grid.Row="1" Margin="10" Grid.Column="1" Grid.ColumnSpan="2" VerticalAlignment="Center"></TextBox>
        <TextBlock Margin="10" Grid.Row="2" VerticalAlignment="Center">직무타입</TextBlock>
        <RadioButton x:Name="rdoInner" Grid.Row="2" Grid.Column="1" HorizontalAlignment="Center" VerticalAlignment="Center">내근</RadioButton>
        <RadioButton x:Name="rdoOutside" Grid.Row="2" Grid.Column="2" HorizontalAlignment="Center" VerticalAlignment="Center">외근</RadioButton>
        <Button Grid.Column="1" Grid.Row="2" Width="88" HorizontalAlignment="Center" Click="Button_Click" Height="22" Margin="16,93,16,-74">저장</Button>

    </Grid>

</Window>
```
</details>
- SubWindow.xaml.cs를 다음과 같이 구성한다.
<details><summary>SubWindow.xaml.cs</summary>

```cs
using System;
using System.Windows;

namespace _07.WPF_Example
{
    /// <summary>
    /// SubWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubWindow : Window
    {
        // 메인 윈도우의 하단 ListBox를 Refresh하기 위한 델리게이트. 직무추가 버튼 클릭할 때 이벤트 할당
        public Delegate UpdateActor;

        public SubWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rdoInner.IsChecked == false && rdoOutside.IsChecked == false)
            {
                MessageBox.Show("내근 또는 외근을 선택하세요.", "항목선택");
                return;
            }

            DutyType dutyType = (rdoInner.IsChecked == true) ? DutyType.Inner : DutyType.OutSide;

            MainWindow._duties.Add(new Duty(txtDutyName.Text, dutyType));


            UpdateActor.DynamicInvoke(dutyType);

            MessageBox.Show("저장OK!", "저장확인");
            this.Close();

        }
    }
}
```
</details>

        
### 결과
<img src="https://user-images.githubusercontent.com/66783849/190459571-3e748911-6b8a-4af1-be8e-fda00852c942.png" width="70%">
