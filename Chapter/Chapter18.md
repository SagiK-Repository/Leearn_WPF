# 18. WPF MVVM 계산기

- MVVM, Command, 데이터바인딩을 이용하여 계산기를 만든다.
- 특히 윈도우 10에서 기본 제공되는 계산기를 모방하여 제작해본다.  
  <img src="" width="">

### 실습
- 실습 목표
  - 사원의 목록을 ListBox에 출력한다.
  - 상단의 버튼을 통해 정렬 기능을 구현한다.
  - 하단의 버튼을 통해 탐색, 필터링(검색) 기능을 구현한다.
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- MainWindow.xaml 및 MainWindow.xaml.cs는 View에 해당한다.
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("CalcCommand.cs") > 추가 (Model에 해당한다.)
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("CalcViewModel.cs") > 추가 (ViewModel에 해당한다.)
- CalcViewModel.cs를 구성한다.
<details><summary>CalcViewModel.cs</summary>

```cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Calculator
{
    internal class CalcViewModel : INotifyPropertyChanged // 값이 바뀌었다는 것을 알려주기 위함
    {

        #region 속성

        string inputString = ""; //출력될 문자들을 담아둘 변수
        string displayText = ""; //계산기화면의 출력 텍스트박스에 대응되는 필드

        public string Op { get; set; } //Operator "사칙연산"이 저장
        public double? Op1 { get; set; } //Operand1 먼저 입력한 숫자 저장 ( "3" + 2 = )

        public ICommand Append { protected set; get; } // 자릿수 늘리기
        public ICommand Backspace { protected set; get; }
        public ICommand Clear { protected set; get; }
        public ICommand ClearEntry { protected set; get; }
        public ICommand Reversal { protected set; get; }
        public ICommand Operator { protected set; get; } // 사칙연산
        public ICommand Calculate { protected set; get; } // =


        public string InputString
        {
            internal set
            {
                if (inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged("InputString");
                    if (value != "")
                    {
                        //숫자를 여러개 입력하면 계속 화면에 출력하기 위해
                        DisplayText = value;
                    }
                }
            }
            get { return inputString; }
        }

        //계산기의 출력창과 바인딩된 속성
        public string DisplayText
        {
            internal set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
            get { return displayText; }
        }

        #endregion

        #region 생성자

        //생성자, 명령객체들을 초기화
        //명령객체들은 UI쪽 버튼의 Command에 바인딩 되어 있다.
        public CalcViewModel()
        {
            //이벤트 핸들러 정의
            //숫자 버튼을 클릭할 때 실행
            this.Append = new Append(this);

            //백스페이스 버튼을 클릭할 때 실행, 한글자 삭제
            this.Backspace = new Backspace(this);

            //출력화면 클리어
            this.Clear = new Clear(this);

            //+, -, *, / 등 ㅇ연산자 클릭할 때 실행
            this.Operator = new Operator(this);

            // = 버튼을 클릭할 때 실행
            this.Calculate = new Calculate(this);

            this.ClearEntry = new ClearEntry(this);
            
            this.Reversal = new Reversal(this);
        }

        #endregion

        #region 이벤트핸들러

        //View와 바인딩된 속성값이 바뀔 때 이를 WPF에게 알리기 위한 이벤트
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region 이벤트

        // 프로퍼티들이 각각 변경될 때마다 수행되어 PropertyChanged 이벤트를 호출 (속성 값이 변경됨을 알림) (생략 가능)
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                // 속성값이 변하였음을 알린다.
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //또는 PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}
```
</details>

- CalcCommand.cs를 구성한다.
<details><summary>Emp.cs</summary>

```cs
using System;
using System.Windows.Input;
using System.Windows.Media.Converters;

namespace WPF_Calculator
{
    class Append : ICommand
    {
        private CalcViewModel _viewModel;
        public event EventHandler CanExecuteChanged;
        public Append(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter) // 커멘드 여부
        {
            return true;
        }

        public void Execute(object parameter) // 커멘드가 호출되면 Excute 실행
        {
            _viewModel.InputString += parameter; // 값 부여
        }
    }

    class CalcCommand : ICommand
    {
        private CalcViewModel _viewModel;
        public event EventHandler CanExecuteChanged;
        public CalcCommand(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
        }
    }


    class Backspace : ICommand
    {
        private CalcViewModel _viewModel;
        public Backspace(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            // CanExecute 조건에 따라 버튼 활성화
            add { CommandManager.RequerySuggested += value; }
            // CanExecute 조건에 따라 버튼 비활성화
            remove { CommandManager.RequerySuggested -= value; } 
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.DisplayText.Length > 0; //조건
        }

        public void Execute(object parameter)
        {
            int length = _viewModel.InputString.Length - 1;

            if (length > 0)
            {
                // 맨 뒷자리 글자를 하나 자른다
                _viewModel.InputString = _viewModel.InputString.Substring(0, length);
            }
            else
            {
                _viewModel.InputString = _viewModel.DisplayText = "";
            }


        }
    }


    class Clear : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Clear(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.DisplayText.Length > 0;
        }

        public void Execute(object parameter)
        {
            _viewModel.InputString = _viewModel.DisplayText = "";
            _viewModel.Op1 = null;
        }
    }


    class Operator : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public Operator(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string op = parameter.ToString(); // 입력한 사칙연산 들어온다.
            double op1;
            if (double.TryParse(_viewModel.InputString, out op1))
            {
                _viewModel.Op1 = op1;
                _viewModel.Op = op;
                _viewModel.InputString = ""; // 3 + 를 누르면, DisplayText는 3, InputText는 Clear
            }else if (_viewModel.InputString == "" && op == "-")
            {
                _viewModel.InputString = "-";
            }
        }
    }


    class Calculate : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Calculate(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            double op2;
            return _viewModel.Op1 != null && double.TryParse(_viewModel.InputString, out op2);
        }

        public void Execute(object parameter)
        {
            double op2 = double.Parse(_viewModel.InputString);
            _viewModel.InputString = calculate(_viewModel.Op, (double)_viewModel.Op1, op2).ToString();
        }

        private static double calculate(string op, double op1, double op2)
        {
            switch (op)
            {
                case "+": return op1 + op2;
                case "-": return op1 - op2;
                case "*": return op1 * op2;
                case "/": return op1 / op2;
                default: return 0;
            }
        }

    }

    class ClearEntry : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ClearEntry(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.DisplayText.Length > 0;
        }

        public void Execute(object parameter)
        {
            _viewModel.InputString = _viewModel.DisplayText = "";
        }
    }

    class Reversal : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Reversal(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.InputString.Length > 0;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.InputString.Substring(0, 1) != "-" )
            {
                _viewModel.InputString = _viewModel.InputString.Insert(0, "-");
                //_viewModel.InputString = "-" + _viewModel.InputString;
            }
            else
            {
                // "-"가 존재할 경우, 첫 글자를 자른다.
                _viewModel.InputString = _viewModel.InputString.Substring(1, _viewModel.InputString.Length-1);
            }

        }
    }

}
```
</details>

- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```cs
<Window x:Class="WPF_Calculator.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WPF_Calculator"
        mc:Ignorable="d"
        Title="MainWindow" Height="170" Width="174" Background="#FF1F1F1F">
    <Grid VerticalAlignment="Top" HorizontalAlignment="Center" Height="120" Margin="0,10,0,0" >
        <Grid.RowDefinitions>
            <RowDefinition Height="20"/>
            <RowDefinition Height="20"/>
            <RowDefinition Height="20"/>
            <RowDefinition Height="20"/>
            <RowDefinition Height="20"/>
            <RowDefinition Height="20"/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="40"/>
            <ColumnDefinition Width="40"/>
            <ColumnDefinition Width="40"/>
            <ColumnDefinition Width="40"/>
        </Grid.ColumnDefinitions>
        <Grid Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="4">
            <Border BorderThickness="1">
                <TextBlock FontSize="15" VerticalAlignment="Center" HorizontalAlignment="Right"
                           Text="{Binding DisplayText}" Foreground="#FFEDEDED" Margin="0,0,10,0"/>
            </Border>
        </Grid>
        <!--Number-->
        <Button Content="7" CommandParameter="7" Command="{Binding Append}" Grid.Row="2" Grid.Column="0" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="8" CommandParameter="8" Command="{Binding Append}" Grid.Row="2" Grid.Column="1" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="9" CommandParameter="9" Command="{Binding Append}" Grid.Row="2" Grid.Column="2" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="4" CommandParameter="4" Command="{Binding Append}" Grid.Row="3" Grid.Column="0" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="5" CommandParameter="5" Command="{Binding Append}" Grid.Row="3" Grid.Column="1" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="6" CommandParameter="6" Command="{Binding Append}" Grid.Row="3" Grid.Column="2" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="1" CommandParameter="1" Command="{Binding Append}" Grid.Row="4" Grid.Column="0" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="2" CommandParameter="2" Command="{Binding Append}" Grid.Row="4" Grid.Column="1" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="3" CommandParameter="3" Command="{Binding Append}" Grid.Row="4" Grid.Column="2" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="0" CommandParameter="0" Command="{Binding Append}" Grid.Row="5" Grid.Column="1" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>

        <!--Arithmetic Operation-->
        <Button Content="+" CommandParameter="+" Command="{Binding Operator}" Grid.Row="4" Grid.Column="3" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="-" CommandParameter="-" Command="{Binding Operator}" Grid.Row="3" Grid.Column="3" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="x" CommandParameter="*" Command="{Binding Operator}" Grid.Row="2" Grid.Column="3" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="÷" CommandParameter="/" Command="{Binding Operator}" Grid.Row="1" Grid.Column="3" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="=" CommandParameter="=" Command="{Binding Calculate}" Grid.Row="5" Grid.Column="3" Margin="1,1,1,1" Background="#FF7B7B7B" BorderBrush="#FF7B7B7B" Foreground="White"/>
        <Button Content="." CommandParameter="." Command="{Binding Append}" Grid.Row="5" Grid.Column="2" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="±"  Command="{Binding Reversal}" Grid.Row="5" Grid.Column="0" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="CE" Command="{Binding ClearEntry}" Grid.Row="1" Grid.Column="0" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="C" Command="{Binding Clear}" Grid.Row="1" Grid.Column="1" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>
        <Button Content="←" Command="{Binding Backspace}" Grid.Row="1" Grid.Column="2" Margin="1,1,1,1" Background="Black" BorderBrush="Black" Foreground="#FFEDEDED"/>

    </Grid>
</Window>
```
</details>

- UI를 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
using System.Windows;

namespace WPF_Calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //데이터 바인딩 소스 객체로 CalcViewModel를 지정
            this.DataContext = new CalcViewModel();
        }
    }
}
```
</details>


### 결과

- <img src="" width="">

