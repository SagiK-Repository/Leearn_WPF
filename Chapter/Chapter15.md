# 16. IValueConverter를 이용한 데이터바인딩, Data Type이 다른 경우의 Data Binding

- 데이터 바인딩 시, 소스와 타켓의 데이터 타입이 다른 경우가 존재한다.
  - ex) CheckBox 체크 여부에 따라 '예','아니오' 등 표시하는 경우, 데이터 타입이 다르다.
- [+타입의 변경+]을 위해 [+IValueConverter+]를 사용하며, IValueConverter 인터페이스를 구현하는 클래스가 [+소스와 타켓 사이의 값을 변환+]한다.
- WPF Value Converter는 IValueConverter 인터페이스 또는 IMultiValueConverter 인터페이스를 구현해야 한다.
  - Convert(), ConvertBack() 두가지 메소드를 구현하면 된다.


### 실습

- 문자열을 입력으로 받고, Boolean 값을 반환하는 간단한 변환기를 구현한다.
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("YesNoToBoolConverter.cs") > 추가
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```cs
<Window x:Class="_16.wpfIValueConverter.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_16.wpfIValueConverter"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Window.Resources>
        <local:YesNoToBoolConverter x:Key="converter" />
    </Window.Resources>
    <StackPanel>
        <TextBox Name="txtValue" Text="YES"/>
        <WrapPanel>
            <TextBlock Text="Current Value : "/>
            <TextBlock Text="{Binding ElementName=txtValue, Path=Text, Converter={StaticResource converter}}"/>
        </WrapPanel>
        <CheckBox Content="YES"  IsChecked="{Binding ElementName=txtValue, Path=Text, Converter={StaticResource converter}}" />
    </StackPanel>
</Window>
```
</details>

- YesNoToBoolConverter.cs 코드를 다음과 같이 구성한다.
<details><summary>YesNoToBoolConverter.cs</summary>

```cs
using System;
using System.Globalization;
using System.Windows.Data;

namespace _16.wpfIValueConverter
{
    // 데이터 바인딩은 기본 양방향이므로 양방향에 대한 함수 각각 존재

    internal class YesNoToBoolConverter : IValueConverter
    {
        // 소스 값이 타켓에 바인딩 되는 경우 호출 (TextBox -> TextBlock, TextBox -> CheckBox)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString().ToUpper())
            {
                case "YES": return true;
                case "NO": return false;
            }

            return false;
        }

        // 타겟 값이 역으로 소스에 바인딩 될 때 호출 (CheckBox -> TextBox)
        // 체크박스를 체그하거나 해제하였을 때
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value) return "YES";
                else return "NO";
            }

            return "NO";
        }

    }
}
```
</details>