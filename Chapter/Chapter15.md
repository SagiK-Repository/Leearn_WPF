# 15. Command 패턴 HelloWorld, 데이터바인딩

- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("MainWindowViewModel.cs") > 추가
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("RelayCommand.cs") > 추가
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_15.Command_Pattern_HelloWorld.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_15.Command_Pattern_HelloWorld"
        mc:Ignorable="d"
        Title="MainWindow" Height="145" Width="373">
    <Window.DataContext>
        <local:MainWindowViewModel/>
    </Window.DataContext>
    <Grid>  
        <TextBox x:Name="textBox" HorizontalAlignment="Left" Height="23" Text="" VerticalAlignment="Top" Width="126" Margin="74,51,0,0"/>
        <Button Content="Click" Height="23" HorizontalAlignment="Left" Margin="215,51,0,0" Name="btnClick" VerticalAlignment="Top" Width="87" 
                Command="{Binding ButtonCommand}" CommandParameter="{Binding Text, ElementName=textBox}"/>
    </Grid>

</Window>
```
</details>

- MainWindowViewModel.cs 코드를 구성한다.
<details><summary>MainWindowViewModel.cs</summary>

```cs
using System.Windows.Input;
using System.Windows;

namespace _15.Command_Pattern_HelloWorld
{
    class MainWindowViewModel
    {
        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }

        public MainWindowViewModel()
        {
            // Command Set
            ButtonCommand = new RelayCommand(ShowMessage);
            // ButtonCommand = new RelayCommand(new Action<object>(ShowMessage));
        }

        public void ShowMessage(object param)
        {
            MessageBox.Show("Hi~ " + param.ToString());
        }
    }

}
```
</details>

- RelayCommand.cs 코드를 구성한다.
<details><summary>RelayCommand.cs</summary>

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _15.Command_Pattern_HelloWorld
{
    internal class RelayCommand : ICommand
    {
        private Action<object> _action;

        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter);
        }
        #endregion
    }
}
```
</details>

  ### 결과

- <img src="https://user-images.githubusercontent.com/66783849/190461352-18fdd0fb-05a3-451c-9f45-afb617051f05.png" width="70%">
