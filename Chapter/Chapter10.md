# 10. 데이터바인딩이란?

- [+데이터 바인딩+]이란, [+컨르롤+] 또는 [+엘리먼트+]를 [-데이터를 연결시키는 기술-]이다.
- 데이터 바인딩은 Source, Target 필요
  - Source : 데이터 (ViewModel)
  - Target : 컨트롤 (Control)
- 양방향일 경우 소스 타켓 정의 모호할 수 있음
- 모든 바인딩에는 Source 객체/속성, Target 객체/속성 있음
- Target 객체 : 바인딩할 속성 (데이터를 렌더링하는 UI 컨트롤을 소유하는 객체)
- Source 객체 : Binding Source 속성, ViewModel 클래스인 경우 DataContext 속성으로 지정
- Binding.Source 속성을 통해 지정되는 원본 개체없이 정의된 바인딩은 대상 개체의 DataContext 를 원본으로 사용
- DataContext 값은 한 컨트롤에서 다른 컨트롤로 비주얼 트리 아래 상속되는데 하위 객체에서 사용 가능
- 이벤트 핸들러를 대체할 수 있음
  - C# 코드를 줄이는 역할
  - XAML에서 정의된 데이터 바인딩은 C# 코드 비하인드 파일에서 이벤트 핸들러를 정의할 필요 없음

### 실습

- 데이터 바인딩에 대한 방향을 설정할 수 있다.
  - OneWay : 단방향
  - TwoWay : 양방향
  ```xml
  <StackPanel Orientation="Vertical" Margin="20">
      <TextBox Name="txt1" Text="{Binding Mode=OneWay}"/>
      <TextBox Name="txt2" Text="{Binding Source={x:Reference txt1}, Path=Text, UpdateSourceTrigger=PropertyChanged}"/>
  </StackPanel>
  ```
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_10.WpfDataBinding.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_10.WpfDataBinding"
        mc:Ignorable="d"
        Title="MainWindow" Height="230" Width="284">
    <StackPanel Orientation="Vertical" Margin="20">
        <Label Content="Which city do you love"/>
        <CheckBox Content="SEOUL" IsChecked="{Binding Seoul}"/>
        <CheckBox Content="JEJOO" IsChecked="{Binding Jejoo}"/>
        <CheckBox Content="INCHEON" IsChecked="{Binding Incheon}"/>
        <Button Content="제출" Click="Sumit_Click"/>
        <TextBox Name="txt1" Text="{Binding Mode=OneWay}"/>
        <TextBox x:Name="txt2" Text="{Binding Text, Source={x:Reference txt1}, UpdateSourceTrigger=PropertyChanged}"/>
    </StackPanel>

</Window>
```
</details>

- 코드를 다음과 같이 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
using System;
//...//
using System.Windows.Shapes;

namespace _10.WpfDataBinding
{
    public partial class MainWindow : Window
    {
        //UI 컨트롤에서 바인딩으로 사용할 소스 속성들
        public bool Seoul { get; set; }
        public bool Jejoo { get; set; }
        public bool Incheon { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //바인딩의 소스객체, UI컨트롤에서 별도의 소스 지정없이 사용 가능
            //Window의 하위객체에서 소스 속성으로 사용 가능
            this.DataContext = this;

        }

        private void Sumit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format($"SEOUL : {Seoul}, JEJOO : {Jejoo}, INCHEON : {Incheon}"));
        }

    }
}
```
</details>


### 결과

- <img src="https://user-images.githubusercontent.com/66783849/190459887-42fe4bdf-e886-4c25-9500-e881c491f2ff.png" width="30%">
