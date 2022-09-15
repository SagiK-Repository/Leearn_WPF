# 14. Command 패턴, 데이터바인딩 개요 | command pattern UML

### WPF Command 패턴의 이해

- 전통적인 이벤트 기반 프로그램은 이벤트 처리 핸들러를 재사용하거나 단위 테스트를 어렵게 한다.
- XAML UI에서 버튼 클릭 시, MVVM에서는 Click 이벤트 핸들러를 이용하기 보다는 Command를 이용하기를 권장한다.
  - 여러 버튼에서 하나의 Command를 공유할 수 있으므로 [+모든 컨트롤마다 Click 이벤트를 만드는 방법 보다는 +][-효율적-]이기 때문이다.
- WPF의 명령(Command)은 ICommand 인터페이스를 구현하여 만든다.
  - ICommand는 다음을 제공한다.
    - Excute 메소드 : [+실제 처리해야 하는 작업+]을 기술한다. 
    - CanExecute 메소드 : [+명령 사용 가능여부를 결정+] 할 때 사용된다. (false : Execute 메소드는 호출되지 않는다)  
      (이 메소드는 키보드 GET 포커스, LOST 포커스, 마우스 업과 같은 UI 상호 작용 중에 대부분 발생한다)
    - CanExecuteChanged 이벤트 : CanExecute 메소드가 호출되어 CanExecute의 상태가 변경되면 CanExecuteChanged 이벤트가 발생, WPF는 CanExecute를 호출하고 Command에 연결된 컨트롤의 상태를 변경한다.
  ```cs
  public event EventHandler CanExecuteChanged
  {
      add { CommandManager.RequerySuggested += value; };
      remove { CommandManager.RequerySuggested -= value };
  }
  ```
- [+CommandManager.RequerySueggested 이벤트+]는 [+CanExecute 메소드를 강제로 실행+]할 수 있다.
- [+CanExecuteChanged 이벤트+]는 CommandManager.RequerySuggested 에 위임되어 [+모든 종류의 UI 상호작용을 통해 변경사항이 호출되는 정확한 알림 제공+]한다.
- RequerySuggested 이벤트의 [+CommandManager.InvalidateRequerySuggested() 를 호출+]하여 [+CommandManager.RequerySuggested 이벤트를 발생하도록 할 수 있다.+]
  ```cs
  private void dispatcherTimer_Tick(object sender, EventArgs e)
  {
      lblSeconds.Content = DateTime.Now.Second;
      CommandManager.InvalidateRequerySuggested();
  }
  ```

<br>

### 실습

- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("Emp.cs") > 추가
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("ViewModel.cs") > 추가
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("MainWindowViewModel.cs") > 추가
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("RelayCommand.cs") > 추가
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_14.CommandPattern_DataBinding.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_14.CommandPattern_DataBinding"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Window.DataContext>
        <local:MainWindowViewModel/>
    </Window.DataContext>
    <StackPanel>
        <TextBlock>사원 이름을 입력하세요.</TextBlock>
        <TextBox x:Name="txtName" Text="{Binding SelectedEmp.Ename}"/>
        <Button Command="{Binding AddEmpCommand}" CommandParameter="{Binding Text, ElementName=txtName}">Add</Button>
        <ListBox ItemsSource="{Binding Emps}" SelectedItem="{Binding SelectedEmp}" DisplayMemberPath="Ename" x:Name="empListBox"/>
        <Label x:Name="label" Content="{Binding SelectedEmp, ElementName=empListBox}" HorizontalAlignment="Center" Height="40" Margin="10,0,0,0" Width="137"/>
    </StackPanel>

</Window>
```
</details>

- Emp.cs 코드를 구성한다.
<details><summary>Emp.cs</summary>

```cs
// using 없음
class Emp
{
    public string Ename { get; set; }
    public string Job { get; set; }

    public override string ToString()
    {
        return "[" + Ename + "," + Job + "]";
    }
}
```
</details>

- ViewModel.cs 코드를 구성한다.
<details><summary>ViewModel.cs</summary>

```cs
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _14.CommandPattern_DataBinding
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Emp _selectedEmp;

        public event PropertyChangedEventHandler PropertyChanged;

        public Emp SelectedEmp
        {
            get { return _selectedEmp; }
            set
            {
                _selectedEmp = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddEmpCommand { get; set; }

        //
        public ObservableCollection<Emp> Emps { get; set; }


        public ViewModel()
        {
            Emps = new ObservableCollection<Emp>();
            Emps.Add(new Emp { Ename = "홍길동", Job = "Salesman" });
            Emps.Add(new Emp { Ename = "김길동", Job = "Clerk" });
            Emps.Add(new Emp { Ename = "정길동", Job = "Manager" });
            Emps.Add(new Emp { Ename = "박길동", Job = "Salesman" });
            Emps.Add(new Emp { Ename = "성길동", Job = "Clerk" });

            AddEmpCommand = new RelayCommand(AddEmp);

        }

        // RelayCommand 의 Execute 메소드에 의해 실행
        private void AddEmp(object obj)
        {
            Emps.Add(new Emp { Ename = obj.ToString(), Job = "New Job" });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
```
</details>

- MainWindowViewModel.cs 코드를 구성한다.
<details><summary>MainWindowViewModel.cs</summary>

```cs
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _14.CommandPattern_DataBinding
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private Emp _SelectedEmp;
        public Emp SelectedEmp
        {
            get
            {
                return _SelectedEmp;
            }
            set
            {
                _SelectedEmp = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string Pname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Pname));
        }

        public RelayCommand AddEmpCommand { get; set; }

        public ObservableCollection<Emp> Emps { get; set; }
        public MainWindowViewModel()
        {
            Emps = new ObservableCollection<Emp>();
            Emps.Add(new Emp { Ename = "홍길동", Job = "Salesman" });
            Emps.Add(new Emp { Ename = "김길동", Job = "Clerk" });
            Emps.Add(new Emp { Ename = "정길동", Job = "Manager" });
            Emps.Add(new Emp { Ename = "박길동", Job = "Salesman" });
            Emps.Add(new Emp { Ename = "성길동", Job = "Clerk" });

            AddEmpCommand = new RelayCommand(AddEmp);
        }

        public void AddEmp(object param)
        {
            Emps.Add(new Emp { Ename = param.ToString(), Job = "New Job" });
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

namespace _14.CommandPattern_DataBinding
{
    internal class RelayCommand : ICommand
    {
        //지역변수, 델리게이트
        Func<object, bool> canExecute;
        Action<object> executeAction;

        //생성자
        public RelayCommand(Action<object> executeAction) : this(executeAction, null)
        {
        }

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.executeAction = executeAction ?? throw new ArgumentException("Execute Action was null for ICommand");
            this.canExecute = canExecute; //이 예제에서는 NULL
        }

        //CanExecute 메소드는 명령을 사용 가능하게 하거나 사용 불가능하게 할 때
        //WPF에 의해 호출
        //예제와 같은 사용자 정의 명령의 경우 CanExecute 메서드가 알아서 호출되지 않으므로
        //CanExecuteChanged 이벤트를 CommandManager의 RequerySuggested 이벤트에 연결하면 된다.
        public bool CanExecute(object param)
        {
            //사원 이름을 입력하지 않으면 Add 버튼은 비활성화 된다.
            if (param?.ToString().Length == 0) return false;

            //canExecute는 Func 델리게이트이고 본 예제에서는 NULL로 넘어온다.
            //그러므로 result는 true가 리턴된다.
            bool result = this.canExecute == null ? true : this.canExecute.Invoke(param);
            return result;
        }

        //실제 실행될 명령은 executeAction 델리게이트가 참조하고 있는
        //MainWindowViewModel의 AddEmp 메소드이다.
        public void Execute(object param)
        {
            this.executeAction.Invoke(param);
        }

        //CanExecuteChanged 이벤트를 CommandManager의 RequerySuggested 이벤트에 연결하면
        //CanExecute 메소드가 호출되어 CanExecute의 상태가 변경되고 이때
        //CanExecuteChanged 이벤트가 발생하고 WPF는 CanExecute를 호출하고 Command에 연결된 컨트롤의 상태를 변경한다.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

}
```
</details>

- MainWindow.xaml.cs 코드를 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
using System.Windows;

namespace _14.CommandPattern_DataBinding
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
    }
}
```
</details>

### 결과

- <img src="https://user-images.githubusercontent.com/66783849/190461158-b932c2ea-c1c2-4aa8-8f43-888b395c0755.png" width="70%">
