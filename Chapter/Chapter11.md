# 12. WPF DataContext 데이터 바인딩

- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("Emp.cs") > 추가
- Console을 키기 위해서 다음과 같은 과정을 거친다.
  - 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 속성 > 애플리케이션 > 출력형식 > 콘솔 애플리케이션 선택
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_12.wpfDataContext_DataBinding.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_12.wpfDataContext_DataBinding"
        mc:Ignorable="d"
        Title="MainWindow" Height="133" Width="276">
    <Grid x:Name="Grid1">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <TextBlock Grid.Column="0" Grid.Row="0">Name :</TextBlock>
        <TextBlock Grid.Column="0" Grid.Row="1">City :</TextBlock>
        <TextBox x:Name="TextBox1" Grid.Column="1" Grid.Row="0" Text="{Binding Path=Ename}"></TextBox>
        <!--Target, Source : Ename-->
        <TextBox x:Name="TextBox2" Grid.Column="1" Grid.Row="1" Text="{Binding Path=City}"></TextBox>
        <!--Target, Source : City-->
        <Button Grid.Column="1" Grid.Row="2" Name="button1" Click="button1_Click">Control to Context</Button>
    </Grid>
</Window>
```
</details>
- Emp.cs 코드를 다음과 같이 구성한다.
<details><summary>Emp.cs</summary>

```cs
namespace _12.wpfDataContext_DataBinding
{
    internal class Emp
    {
        public string Ename { get; set; }
        public string City { get; set; }
    }
}
```
</details>
- 코드를 다음과 같이 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
namespace _12.wpfDataContext_DataBinding
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Emp e = new Emp()
            {
                Ename = "홍길동",
                City = "서울"
            };
            this.DataContext = e; // DataContext로 Emp e 지정
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Emp emp = this.DataContext as Emp;
            Console.WriteLine(emp.Ename);
            Console.WriteLine(emp.City);
        }
    }
}

```
</details>
