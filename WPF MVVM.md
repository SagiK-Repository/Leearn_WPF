# 00. Binding

<details>
<summary>MainView.xaml</summary>

```xml
<Window x:Class="_0.Binding.MainView"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
      xmlns:local="clr-namespace:_0.Binding"
      mc:Ignorable="d" d:DataContext="{d:DesignInstance local:MainView}"
      Title="주소록 관리 v0.1" Height="328" Width="525"
        WindowStartupLocation="CenterScreen" WindowStyle="ThreeDBorderWindow">

    <Grid>
        <DataGrid HorizontalAlignment="Center" Height="234" Width="480" Margin="0,9,0,41"
                  SelectedIndex="{Binding Path=SelectedIndex, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay }"
                  ItemsSource="{Binding Path=Persons, UpdateSourceTrigger=PropertyChanged, Mode=OneWay}"
                  AutoGenerateColumns="False" SelectionMode="Single" IsReadOnly="True">
            
            <DataGrid.Columns>
                
                <DataGridTextColumn Header="이름" Binding="{Binding Path=Name}" Width="100"/>
                <DataGridTextColumn Header="성별" Binding="{Binding Path=Gender}"/>
                <DataGridTextColumn Header="전화번호" Binding="{Binding Path=PhoneNumber}" Width="150"/>
                <DataGridTextColumn Header="주소" Binding="{Binding Path=Address}" Width="*"/>

            </DataGrid.Columns>
            
       
        </DataGrid>

        <Button Content="추가" Command="{Binding Path=AddCommand}" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="176,249,0,0" Width="75" />
        <Button Content="삭제" Command="{Binding Path=DeleteCommand}" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="256,249,0,0" Width="75" />
        <Button Content="변경" Command="{Binding Path=ModifyCommand}" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="337,249,0,0" Width="75" />
        <Button Content="종료" Command="{Binding Path=ExitCommand}" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="416,249,0,0" Width="75" />

    </Grid>
</Window>
```
</details> 

<details>
<summary>MainView.xaml.cs</summary>

```cs
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace _0.Binding
{
    public partial class MainView : Window, INotifyPropertyChanged
    {
        #region INotifyCollectionChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> Persons { get; set; }


        // Command 선언
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand ModifyCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        
        public MainView()
        {
            InitializeComponent();

            DataContext = this;
            Persons = new ObservableCollection<Person>();

            #region TestData

            Persons.Add(new Person() { Address = "test1", Name = "홍길동1", Gender = true, PhoneNumber = "1111-1111" });
            Persons.Add(new Person() { Address = "test2", Name = "홍길동2", Gender = true, PhoneNumber = "2222-2222" });
            Persons.Add(new Person() { Address = "test3", Name = "홍길동3", Gender = true, PhoneNumber = "3333-3333" });
            Persons.Add(new Person() { Address = "test4", Name = "홍길동4", Gender = true, PhoneNumber = "4444-4444" });

            #endregion

            AddCommand = new DelegateCommand(_addCommandAction);
            DeleteCommand = new DelegateCommand(_deleteCommandAction);
            ModifyCommand = new DelegateCommand(_modifyCommandAction);
            ExitCommand = new DelegateCommand(_exitCommandAction);

        }

        // Command를 연결할 Method를 구현
        private void _modifyCommandAction(object obj)
        {
            if (SelectedIndex < 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.", "주소록 v0.1", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var selectData = Persons[SelectedIndex];
            var modifyData = new Person(selectData);

            AddView modify = new AddView(modifyData, AddView.ViewType.Modify);
            modify.PersonData = new Person(modifyData);
            if (true == modify.ShowDialog())
                Persons[SelectedIndex] = modify.PersonData;
        }

        private void _deleteCommandAction(object obj)
        {
            if (SelectedIndex < 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.", "주소록 v0.1", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Persons.RemoveAt(SelectedIndex);
        }

        
        private void _exitCommandAction(object obj)
        {
            this.Close();
        }

        private void  _addCommandAction(object obj)
        {
            AddView add = new AddView();
            if (true == add.ShowDialog())
                Persons.Add(add.PersonData);
        }


    }
}
```
</details> 

<details>
<summary>AddView.xaml</summary>

```xml
<Window x:Class="_0.Binding.AddView"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
      xmlns:local="clr-namespace:_0.Binding"
      mc:Ignorable="d" 
      Title="{Binding Path=Caption, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Height="300" Width="300">

    <Grid>
        <Label Content="이름" Margin="10,10,0,0" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <TextBox Text ="{Binding Path=PersonData.Name, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" TextWrapping="Wrap" Margin="73, 12, 0, 0" Height="23" Width="209" HorizontalAlignment="Left" VerticalAlignment="Top"/>

        <Label Content="성별" Margin="10,45,0,0" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <TextBox Text ="{Binding Path=PersonData.Gender, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" TextWrapping="Wrap" Margin="73, 45, 0, 0" Height="23" Width="209" HorizontalAlignment="Left" VerticalAlignment="Top"/>

        <Label Content="전화번호" Margin="10,84,0,0" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <TextBox Text ="{Binding Path=PersonData.PhoneNumber, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" TextWrapping="Wrap" Margin="73, 84, 0, 0" Height="23" Width="209" HorizontalAlignment="Left" VerticalAlignment="Top"/>

        <Label Content="주소" Margin="10,126,0,0" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <TextBox Text ="{Binding Path=PersonData.Address, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" TextWrapping="Wrap" Margin="73, 126, 0, 0" Height="23" Width="209" HorizontalAlignment="Left" VerticalAlignment="Top"/>

        <Button Content="확인" Command="{Binding OkCommand}" Margin="127, 240, 0, 0" Width="75" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <Button Content="취소" Command="{Binding CancleCommand}" Margin="207, 240, 0, 0" Width="75" HorizontalAlignment="Left" VerticalAlignment="Top"/>
    </Grid>
</Window>
```
</details> 

<details>
<summary>AddView.xaml.cs</summary>

```cs
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace _0.Binding
{
    public partial class AddView : Window, INotifyPropertyChanged
    {

        #region INotifyCollectionChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public enum ViewType
        {
            Add,
            Modify
        }

        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                OnPropertyChanged();
            }
        }

        public Person PersonData { get; set; }
        public DelegateCommand OkCommand { get; set; }
        public DelegateCommand CancleCommand { get; set; }

        public AddView(Person modifyData = null, ViewType type = ViewType.Add)
        {
            InitializeComponent();
            DataContext = this;

            if (type == ViewType.Add)
            {
                Caption = "추가";
                PersonData = new Person();
            }
            else if (type == ViewType.Modify)
            {
                Caption = "변경";
                PersonData = modifyData;
            }
            else
            {
                Caption = "추가";
                PersonData = new Person();
            }

            OkCommand = new DelegateCommand(_okCommandAction);
            CancleCommand = new DelegateCommand(_cancleCommandAction);
        }


        private void _cancleCommandAction(object obj)
        {
            DialogResult = false;
            this.Close();
        }

        private void _okCommandAction(object obj)
        {
            DialogResult = true;
            this.Close();
        }



    }
}
```
</details> 

<details>
<summary>Person.cs</summary>

```cs
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _0.Binding
{
    public class Person : INotifyPropertyChanged
    {

        // INotifyPropertyChanged : 속성 값이 변경되었음을 클라이언트에 알립니다.
        #region INotifyCollectionChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(); // 값이 변화되면 Event 실행 = UI에 변화된 값 변경
            }
        }

        private bool _gender;

        public bool Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public Person()
        {

        }

        public Person(Person input)
        {
            _name = input.Name;
            _gender = input.Gender;
            _phoneNumber = input.PhoneNumber;
            _address = input.Address;
        }
    }
}
```
</details> 

<details>
<summary>DelegateCommand.cs</summary>

```cs
using System;
using System.Windows.Input;

namespace _0.Binding
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExcute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute)
            : this(execute, null) 
        {
        }

        public DelegateCommand(Action<object> execute,
            Predicate<object> canExcute)
        {
            _execute = execute;
            _canExcute = canExcute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExcute == null)
            {
                return true;
            }

            return _canExcute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }



    }
}
```
</details> 



<br><br>



# 01. MVVM

<details>
<summary>AddView.xaml , Addview.xaml.cs</summary>

```xml
<Window x:Class="_1.MVVM.AddView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_1.MVVM"
        mc:Ignorable="d" d:DataContext="{d:DesignInstance local:AddView}"
        Title="{Binding Path=Cpation, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Height="300" Width="300"
        WindowStartupLocation="CenterScreen" WindowStyle="ToolWindow"
        Name="AddViewParam">
    
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="4"/>
            <ColumnDefinition Width="60"/>
            <ColumnDefinition Width="4"/>
            <ColumnDefinition Width="53"/>
            <ColumnDefinition Width="75"/>
            <ColumnDefinition Width="4"/>
            <ColumnDefinition Width="75"/>
            <ColumnDefinition Width="4"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="4"/>
            <RowDefinition Height="24"/>
            <RowDefinition Height="4"/>
            <RowDefinition Height="24"/>
            <RowDefinition Height="4"/>
            <RowDefinition Height="24"/>
            <RowDefinition Height="4"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="4"/>
            <RowDefinition Height="24"/>
            <RowDefinition Height="4"/>
        </Grid.RowDefinitions>

        <Label Content="이름" VerticalAlignment="Stretch" Grid.Column="1" Grid.Row="1"/>
        <TextBox TextWrapping="Wrap" Grid.Column="3" Grid.Row="1" Grid.ColumnSpan="4"
                  Text="{Binding Path=PersonData.Name, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
        
        <Label Content="성별" Grid.Column="1" Grid.Row="3"/>
        <TextBox TextWrapping="Wrap" Grid.Column="3" Grid.Row="3" Grid.ColumnSpan="4"
                  Text="{Binding Path=PersonData.Gender, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
        
        <Label Content="전화번호" Grid.Column="1" Grid.Row="5"/>
        <TextBox TextWrapping="Wrap" Grid.Column="3" Grid.Row="5" Grid.ColumnSpan="4"
                  Text="{Binding Path=PersonData.PhoneNumber, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
        
        <Label Content="주소" VerticalAlignment="Stretch" Grid.Column="1" Grid.Row="7"/>
        <TextBox TextWrapping="Wrap" Grid.Column="3" Grid.Row="7" Grid.ColumnSpan="4"
                  Text="{Binding Path=PersonData.Address, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>

        <Button IsDefault="True" Content="확인" Grid.Column="4" Grid.Row="9"
                Command="{Binding Path=OkCommand}"
                CommandParameter="{Binding ElementName=AddViewParam}"/>
        <Button Content="취소" Grid.Column="6" Grid.Row="9"
                Command="{Binding Path=CancelCommand}"
                CommandParameter="{Binding ElementName=AddViewParam}"/>

    </Grid>
</Window>
```

```cs
using System.Windows;

namespace _1.MVVM
{
    public partial class AddView : Window, IDialogView
    {
        public AddView(AddViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
```
</details> 

<details>
<summary>AddViewModel.cs</summary>

```cs
using ReactiveUI;
using System.Reactive;
using System.Windows.Input;

namespace _1.MVVM
{
    public class AddViewModel : ReactiveObject
    {
        public enum ViewType
        {
            Add,
            Modify
        }
        private string _caption;

        public string Caption
        {
            get { return _caption; }
            set { this.RaiseAndSetIfChanged(ref _caption, value); }
        }

        public Person PersonData { get; set; }
        public ICommand OkCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public AddViewModel(Person Data = null, ViewType type = ViewType.Add)
        {
            if (type == ViewType.Add)
            {
                Caption = "추가";
                PersonData = Data;
            }
            else if (type == ViewType.Modify)
            {
                Caption = "변경";
                PersonData = Data;
            }
            else
            {
                Caption = "추가";
                PersonData = new Person();
            }

            OkCommand = ReactiveCommand.Create<IDialogView, Unit>(view => _okCommandAction(view));
            CancelCommand = ReactiveCommand.Create<IDialogView, Unit>(view => _cancleCommandAction(view));
        }

        private Unit _cancleCommandAction(IDialogView view)
        {
            view.DialogResult = false;
            view.Close();
            return Unit.Default;
        }

        private Unit _okCommandAction(IDialogView view)
        {
            view.DialogResult = true;
            view.Close();
            return Unit.Default;
        }
    }
}

```
</details> 

<details>
<summary>App.xaml, App.xaml.cs</summary>

```xml
<Application x:Class="_1.MVVM.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:_1.MVVM"
             > <!--StartupUri="MainView.xaml"-->
    <Application.Resources>
         
    </Application.Resources>
</Application>
```

```cs
using System.Windows;

namespace _1.MVVM
{
    public partial class App : Application
    {
        // MainView에 MainViewModel을 알려준다.
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IMessageBoxService messageBoxService = new MessageBoxService();
            MainViewModel mainViewModel = new MainViewModel(messageBoxService, _createAddView);
            MainView mainView = new MainView(mainViewModel);
            mainView.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        private IDialogView _createAddView(Person modifyData, AddViewModel.ViewType type = AddViewModel.ViewType.Add)
        {
            var viewModel = new AddViewModel(modifyData, type); // MainViewModel에서 AddView를 생성할 수 있도록 _createAddView Method를 추가한다. 
            return new AddView(viewModel);
        }
    }
}
```
</details> 

<details>
<summary>IDialogView.cs</summary>

```cs
namespace _1.MVVM
{
    // Dialg의 속성을 상속받기 위한 Interface
    public interface IDialogView
    {
        bool? ShowDialog();

        bool? DialogResult { get; set; }

        void Show();

        void Close();
    }
}
```
</details> 

<details>
<summary>IMessageBoxService.cs</summary>

```cs
using System.Windows;

namespace _1.MVVM
{
    // MessageBox를 사용하기 위한 Interface
    public interface IMessageBoxService
    {
        MessageBoxResult Show(string messageBoxText);
        MessageBoxResult Show(string messageBoxText, string caption);
        MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon);
        MessageBoxResult Show(System.Windows.Window owner, string messageBoxText);
        MessageBoxResult Show(System.Windows.Window owner, string messageBoxText, string caption);
        MessageBoxResult Show(System.Windows.Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon);
        MessageBoxResult Show(DependencyObject owner, string messageBoxText);
        MessageBoxResult Show(DependencyObject owner, string messageBoxText, string cpaion);
        MessageBoxResult Show(DependencyObject owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon);
        MessageBoxResult Show(IWindowView owner, string messageBoxTextm, string caption, MessageBoxButton button, MessageBoxImage icon);
    }
}
```
</details> 

<details>
<summary>IWindowView.cs</summary>

```cs
using System.Windows;

namespace _1.MVVM
{
    // 윈도우 속성을 상속받기 위한 Interface
    public interface IWindowView
    {
        void Show();

        void Close();

        Visibility Visibility { get; set; }
    }
}
```
</details> 

<details>
<summary>MainView.xaml, MainView.xaml.cs</summary>

```xml
<Window x:Class="_1.MVVM.MainView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_1.MVVM"
        xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
        mc:Ignorable="d" d:DataContext="{d:DesignInstance local:MainViewModel}"
        Title="주소록 관리 v1.0" Height="328" Width="525"
        WindowStartupLocation="CenterScreen" Name="MainViewParam">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="4"/>
            <ColumnDefinition Width="182"/>
            <ColumnDefinition Width="75"/>
            <ColumnDefinition Width="4"/>
            <ColumnDefinition Width="75"/>
            <ColumnDefinition Width="4"/>
            <ColumnDefinition Width="75"/>
            <ColumnDefinition Width="4"/>
            <ColumnDefinition Width="75"/>
            <ColumnDefinition Width="4"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="4"/>
            <RowDefinition Height="244"/>
            <RowDefinition Height="4"/>
            <RowDefinition Height="20"/>
            <RowDefinition Height="4"/>
        </Grid.RowDefinitions>

        <DataGrid Grid.Row="1" Grid.Column="1" Grid.ColumnSpan="8"
                  HorizontalAlignment="Stretch" VerticalAlignment="Stretch"
                  SelectionMode="Single" AutoGenerateColumns="False" AlternationCount="2"
                  AlternatingRowBackground="Gainsboro" IsReadOnly="True"
                  Name="PersonsParam"
                  ItemsSource="{Binding Path=Persons, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="MouseDoubleClick">
                    <i:InvokeCommandAction Command="{Binding ModifyCommand}" CommandParameter="{Binding ElementName=PersonsParam, Path=SelectedIndex}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
            <DataGrid.Columns>
                <DataGridTextColumn Header="이름" Binding="{Binding Path=Name}" Width="100"/>
                <DataGridTextColumn Header="성별" Binding="{Binding Path=Gender}"/>
                <DataGridTextColumn Header="전화번호" Binding="{Binding Path=PhoneNumber}" Width="100"/>
                <DataGridTextColumn Header="주소" Binding="{Binding Path=Address}" Width="200"/>
            </DataGrid.Columns>
        </DataGrid>

        <Button Content="추가" Width="75" Grid.Row="3" Grid.Column="2" Command="{Binding Path=AddCommand}"/>
        <Button Content="변경" Width="75" Grid.Row="3" Grid.Column="6" Command="{Binding Path=ModifyCommand}" CommandParameter="{Binding ElementName=PersonsParam, Path=SelectedIndex}"/>
        <Button Content="삭제" Width="75" Grid.Row="3" Grid.Column="4" Command="{Binding Path=DeleteCommand}" CommandParameter="{Binding ElementName=PersonsParam, Path=SelectedIndex}"/>
        <Button Content="종료" Width="75" Grid.Row="3" Grid.Column="8" Command="{Binding Path=ExitCommand}"   CommandParameter="{Binding ElementName=PersonsParam, Path=SelectedIndex}"/>

    </Grid>
</Window>
```

```cs
using System.Windows;
// Tools > NuGet Package에 접속하여  System.Windows.Interactivity를 활용한다
// System.Windows.Interactivity 사용하기 위해 Expression.Blend.Sdk선택한다. : 

namespace _1.MVVM
{
    public partial class MainView : Window, IWindowView
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel; // MainView와 MainViewModel의 연결
        }
    }
}
```
</details> 

<details>
<summary>MainViewModel.cs</summary>

```cs
using ReactiveUI; // MVVM패턴을 지원하는 프레임워크 (Tools > NuGet Package에 접속하여 ReactiveUI.WPF를 활용한다)
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using System.Windows.Input;

namespace _1.MVVM
{
    public class MainViewModel : ReactiveObject
    {
        public ObservableCollection<Person> Persons { get; set; } 


        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private readonly IMessageBoxService _messageBoxService;
        private readonly Func<Person, AddViewModel.ViewType, IDialogView> _createAddView;

        public MainViewModel(IMessageBoxService messageBoxService, Func<Person, AddViewModel.ViewType, IDialogView> createAddView) {
            _messageBoxService = messageBoxService;
            _createAddView = createAddView;
            Persons = new ObservableCollection<Person>();

            _initCommand();
            _initTestData();
        }

        private void _initCommand()
        {
            Persons.Add(new Person() { Address = "test1", Name = "홍길동1", Gender = true, PhoneNumber = "1" });
            Persons.Add(new Person() { Address = "test2", Name = "홍길동2", Gender = true, PhoneNumber = "2" });
            Persons.Add(new Person() { Address = "test3", Name = "홍길동3", Gender = true, PhoneNumber = "3" });
            Persons.Add(new Person() { Address = "test4", Name = "홍길동4", Gender = true, PhoneNumber = "4" });
        }

        private void _initTestData()
        {
            AddCommand = ReactiveCommand.Create(_addCommandAction);
            DeleteCommand = ReactiveCommand.Create<int, Unit>(index => _deleteCommandAction(index));
            ModifyCommand = ReactiveCommand.Create<int, Unit>(index => _modifyCommandAction(index));
            ExitCommand = ReactiveCommand.Create<IWindowView, Unit>(view => _exitCommandAction(view));
        }

        private Unit _exitCommandAction(IWindowView view)
        {
            view.Close();
            return Unit.Default;
        }

        private Unit _modifyCommandAction(int selectedIndex)
        {
            if( selectedIndex < 0)
            {
                _messageBoxService.Show("선택된 데이터가 없습니다", "주소록 v1.0", MessageBoxButton.OK, MessageBoxImage.Information);
                return Unit.Default;
            }

            var modifyData = new Person(Persons[selectedIndex]);

            IDialogView view = _createAddView(modifyData, AddViewModel.ViewType.Modify);
            if( true == view.ShowDialog() )
                Persons[selectedIndex] = modifyData;

            return Unit.Default;

        }

        private void _addCommandAction()
        {
            var addData = new Person();

            IDialogView view = _createAddView(addData, AddViewModel.ViewType.Add);
            if (true == view.ShowDialog())
                Persons.Add(addData);
        }

        private Unit _deleteCommandAction(int selectedIndex)
        {
            if (selectedIndex < 0)
            {
                _messageBoxService.Show("선택된 데이터가 없습니다", "주소록 v1.0", MessageBoxButton.OK, MessageBoxImage.Information);
                return Unit.Default;
            }

            var Result = _messageBoxService.Show("선택된 데이터를 삭제하시겠습니까?", "주소록 v1.0", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Cancel)
                return Unit.Default;

            Persons.RemoveAt(selectedIndex);
            return Unit.Default;
        }
    }
}
```
</details> 

<details>
<summary>MessageBoxService.cs</summary>

```cs
using System.Windows;

namespace _1.MVVM
{
    internal class MessageBoxService : IMessageBoxService
    {
        public MessageBoxResult Show(string messageBoxText)
        {
            return MessageBox.Show(messageBoxText);
        }

        public MessageBoxResult Show(string messageBoxText, string caption)
        {
            return MessageBox.Show(messageBoxText, caption);
        }

        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return MessageBox.Show(messageBoxText, caption, button, icon);
        }

        public MessageBoxResult Show(Window owner, string messageBoxText)
        {
            return MessageBox.Show(owner, messageBoxText);
        }

        public MessageBoxResult Show(Window owner, string messageBoxText, string caption)
        {
            return MessageBox.Show(owner, messageBoxText, caption);
        }

        public MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return MessageBox.Show(owner, messageBoxText, caption, button, icon);
        }

        public MessageBoxResult Show(DependencyObject owner, string messageBoxText)
        {
            Window parentWindow = Window.GetWindow(owner);
            return Show(parentWindow, messageBoxText);
        }
        
        public MessageBoxResult Show(DependencyObject owner, string messageBoxText, string caption)
        {
            Window parentWindow = Window.GetWindow(owner);
            return Show(parentWindow, messageBoxText, caption);
        }

        public MessageBoxResult Show(DependencyObject owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            Window parentWindow = Window.GetWindow(owner);
            return Show(parentWindow, messageBoxText, caption, button, icon);
        }

        public MessageBoxResult Show(IWindowView owner, string messageBoxTextm, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            Window window = owner as Window;
            return Show(window, messageBoxTextm, caption, button, icon);
        }
    }
}
```
</details> 

<details>
<summary>Person.cs</summary>

```cs
using ReactiveUI;

namespace _1.MVVM
{
    public class Person : ReactiveObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
        }
        private bool _gender;
        public bool Gender
        {
            get { return _gender; }
            set { this.RaiseAndSetIfChanged(ref _gender, value); }
        }
        private string _phoneNumer;
        public string PhoneNumber
        {
            get { return _phoneNumer; }
            set { this.RaiseAndSetIfChanged(ref _phoneNumer, value); }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { this.RaiseAndSetIfChanged(ref _address, value); }
        }

        public Person()
        {
        }

        public Person(Person input)
        {
            _address = input.Address;
            _gender = input.Gender;
            _name = input.Name;
            _phoneNumer = input.PhoneNumber;
        }
    }
}
```
</details> 

<br><br>


# 02. DevExpress.ReactiveUI

- DevExpress
  - WinForms, MVC, WPF 등 디자인을 편리하게 작성 할 수 있는 .NET 기반의 컴포넌트 라이브러리
  - DevExpress를 사용함으로써 보다 심미적인 UI 설계 가능
- ReactiveUI
  - .NET 플랫폼을 위한 반응형 Model-View-ViewModel 프레임워크
  - RX(Reactive Extension)를 이용해 objec간 복잡한 interactions을 선언적으로 등록해서 사용함으로, 기존 event 방식 프로그램의 단점을 극복할 수 있도록함
  - ※ Reactive Extension : Observer 패턴, Iterator 패턴과 함수형 프로그래밍의 조합
- [DevExpress 설치](https://www.devexpress.com/)
- 기존의 1)MVVM 프로젝트에 이어서 활용한다.
- 다음 내용을 참조 추가한다. (참조 추가 > 어셈블리 > 확장)
  - DevExpress.Data.Desktop.v22.1
  - DevExpress.Data.v22.1
  - DevExpress.Mvvm.v22.1
  - DevExpress.Printing.v22.1.Core
  - DevExpress.Xpf.Core.v22.1
  - DevExpress.Xpf.Grid.v22.1
  - DevExpress.Xpf.Grid.v22.1.Core
  - DevExpress.Xpf.LayoutControl.v22.1

<details>
<summary>AddView.xaml , Addview.xaml.cs</summary>

```xml
<dx:DXWindow x:Class="_1.MVVM.AddView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:dxlc="http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol"
        xmlns:dx="http://schemas.devexpress.com/winfx/2008/xaml/core"
        xmlns:local="clr-namespace:_1.MVVM"
        mc:Ignorable="d" d:DataContext="{d:DesignInstance local:AddView}"
        Title="{Binding Path=Caption, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Height="300" Width="300"
        WindowStartupLocation="CenterScreen" WindowStyle="ToolWindow"
        Name="AddViewParam">
    <dxlc:LayoutControl Orientation="Vertical" Padding="4">

        <dxlc:LayoutGroup Orientation="Vertical">
            <dxlc:LayoutItem Label="이름" VerticalAlignment="Top">
                <TextBox Text="{Binding Path=PersonData.Name, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
            </dxlc:LayoutItem>
            <dxlc:LayoutItem Label="성별" VerticalAlignment="Top">
                <TextBox Text="{Binding Path=PersonData.Gender, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
            </dxlc:LayoutItem>
            <dxlc:LayoutItem Label="전화번호" VerticalAlignment="Top">
                <TextBox Text="{Binding Path=PersonData.PhoneNumber, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
            </dxlc:LayoutItem>
            <dxlc:LayoutItem Label="주소" VerticalAlignment="Stretch">
                <TextBox Text="{Binding Path=PersonData.Address, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
            </dxlc:LayoutItem>
        </dxlc:LayoutGroup>

        <dxlc:LayoutGroup VerticalAlignment="Bottom" HorizontalAlignment="Right" Height="20">
            <Button Content="확인" Command="{Binding Path=OkCommand}" CommandParameter="{Binding ElementName=AddViewParam}" Width="75"/>
            <Button Content="취소" Command="{Binding Path=CancelCommand}" CommandParameter="{Binding ElementName=AddViewParam}" Width="75"/>
        </dxlc:LayoutGroup>
        
    </dxlc:LayoutControl>
</dx:DXWindow>

```

```cs
using DevExpress.Xpf.Core;
using System.Windows;

namespace _1.MVVM
{
    public partial class AddView : DXWindow, IDialogView
    {
        public AddView(AddViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

```
</details> 

<details>
<summary>AddViewModel.cs</summary>

```cs
using ReactiveUI;
using System.Reactive;
using System.Windows.Input;

namespace _1.MVVM
{
    public class AddViewModel : ReactiveObject
    {
        public enum ViewType
        {
            Add,
            Modify
        }
        private string _caption;

        public string Caption
        {
            get { return _caption; }
            set { this.RaiseAndSetIfChanged(ref _caption, value); }
        }

        public Person PersonData { get; set; }
        public ICommand OkCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public AddViewModel(Person Data = null, ViewType type = ViewType.Add)
        {
            if (type == ViewType.Add)
            {
                Caption = "추가";
                PersonData = Data;
            }
            else if (type == ViewType.Modify)
            {
                Caption = "변경";
                PersonData = Data;
            }
            else
            {
                Caption = "추가";
                PersonData = new Person();
            }

            OkCommand = ReactiveCommand.Create<IDialogView, Unit>(view => _okCommandAction(view));
            CancelCommand = ReactiveCommand.Create<IDialogView, Unit>(view => _cancleCommandAction(view));
        }

        private Unit _cancleCommandAction(IDialogView view)
        {
            view.DialogResult = false;
            view.Close();
            return Unit.Default;
        }

        private Unit _okCommandAction(IDialogView view)
        {
            view.DialogResult = true;
            view.Close();
            return Unit.Default;
        }
    }
}

```
</details> 

<details>
<summary>App.xaml, App.xaml.cs</summary>

```xml
<Application x:Class="_1.MVVM.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:_1.MVVM"
             > <!--StartupUri="MainView.xaml"-->
    <Application.Resources>
         
    </Application.Resources>
</Application>
```

```cs
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;

namespace _1.MVVM
{
    public partial class App : Application
    {
        // MainView에 MainViewModel을 알려준다.
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationThemeHelper.ApplicationThemeName = Theme.VS2017BlueName; //테마를 설정한다.
            IMessageBoxService messageBoxService = new DXMessageBoxService();
            MainViewModel mainViewModel = new MainViewModel(messageBoxService, _createAddView);
            MainView mainView = new MainView(mainViewModel);
            mainView.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        private IDialogView _createAddView(Person modifyData, AddViewModel.ViewType type = AddViewModel.ViewType.Add)
        {
            IMessageBoxService messageBoxService = new DXMessageBoxService();
            var viewModel = new AddViewModel(modifyData, type); // MainViewModel에서 AddView를 생성할 수 있도록 _createAddView Method를 추가한다. 
            return new AddView(viewModel);
        }
    }
}

```
</details> 

<details>
<summary>IDialogView.cs</summary>

```cs
namespace _1.MVVM
{
    // Dialg의 속성을 상속받기 위한 Interface
    public interface IDialogView
    {
        bool? ShowDialog();

        bool? DialogResult { get; set; }

        void Show();

        void Close();
    }
}
```
</details> 

<details>
<summary>IWindowView.cs</summary>

```cs
using System.Windows;

namespace _1.MVVM
{
    // 윈도우 속성을 상속받기 위한 Interface
    public interface IWindowView
    {
        void Show();

        void Close();

        Visibility Visibility { get; set; }
    }
}
```
</details> 

<details>
<summary>MainView.xaml, MainView.xaml.cs</summary>

```xml
<dx:DXWindow x:Class="_1.MVVM.MainView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:dxlc="http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol"
        xmlns:dxg="http://schemas.devexpress.com/winfx/2008/xaml/grid"
        xmlns:dxmvvm="http://schemas.devexpress.com/winfx/2008/xaml/mvvm"
        xmlns:dx="http://schemas.devexpress.com/winfx/2008/xaml/core"
        xmlns:local="clr-namespace:_1.MVVM"
        xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
        mc:Ignorable="d" d:DataContext="{d:DesignInstance local:MainViewModel}"
        Title="주소록 관리 v1.0" Height="350" Width="600"
        WindowStartupLocation="CenterScreen" Name="MainViewParam">
    <!--d:DataContext="{d:DesignInstance local:MainViewModel}"-->
    <dxlc:LayoutControl Orientation="Vertical" Padding="4">
        <dxg:GridControl EnableSmartColumnsGeneration="True" Name="PersonsParam" ItemsSource="{Binding Path=Persons, UpdateSourceTrigger=PropertyChanged, Mode=OneWay}">

            <dxmvvm:Interaction.Behaviors>
                <dxmvvm:EventToCommand EventName="MouseDoubleClick" Command="{Binding Path=ModifyCommand}"
                                       CommandParameter="{Binding ElementName=PersonsParam, Path=SelectedItem}"/>

                <dxmvvm:EventToCommand EventName="MouseMove" Command="{Binding Path=MouseMoveCommand}"
                                       PassEventArgsToCommand="True">
                    <dxmvvm:EventToCommand.EventArgsConverter>
                        <local:MouseEventConverter/>
                    </dxmvvm:EventToCommand.EventArgsConverter>
                </dxmvvm:EventToCommand>

            </dxmvvm:Interaction.Behaviors>
            
            <dxg:GridControl.Columns>
                <dxg:GridColumn Header="이름" FieldName="Name" ReadOnly="True" HorizontalHeaderContentAlignment="Center"/>
                <dxg:GridColumn Header="성별" FieldName="Gender" ReadOnly="True" HorizontalHeaderContentAlignment="Center"/>
                <dxg:GridColumn Header="전화번호" FieldName="Phonenumber" ReadOnly="True" HorizontalHeaderContentAlignment="Center"/>
                <dxg:GridColumn Header="주소" FieldName="Adress" ReadOnly="True" HorizontalHeaderContentAlignment="Center"/>
            </dxg:GridControl.Columns>

            <dxg:GridControl.View>
                <dxg:TableView AllowPerPixelScrolling="False" AllowHorizontalScrollingVirtualization="False"
                               AllowCascadeUpdate="False" AllowEditing="False"
                               ShowAutoFilterRow="False" ShowTotalSummary="False" ShowGroupPanel="False"
                               UseAnimationWhenExpanding="False"
                               NewItemRowPosition="None"
                               ScrollingMode="Smart"
                               AutoWidth="True"
                               NavigationStyle="Row"
                               FadeSelectionOnLostFocus="False"/>
            </dxg:GridControl.View>
            
        </dxg:GridControl>


        <dxlc:LayoutGroup VerticalAlignment="Bottom" Height="24">
            <dxlc:LayoutGroup HorizontalAlignment="Left" VerticalAlignment="Center">

                <dxlc:LayoutItem Label="Mouse X">
                    <TextBox Text="{Binding Path=MouseX, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Width="50"/>
                </dxlc:LayoutItem>

                <dxlc:LayoutItem Label="Mouse Y">
                    <TextBox Text="{Binding Path=MouseY, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Width="50"/>
                </dxlc:LayoutItem>

            </dxlc:LayoutGroup>

            <dxlc:LayoutGroup HorizontalAlignment="Right">
                <Button Command="{Binding Path=AddCommand}" Content="추가" Width="75"/>
                <Button Command="{Binding Path=ModifyCommand}" Content="변경" CommandParameter="{Binding ElementName=PersonsParam, Path=SelectedItem}" Width="75"/>
                <Button Command="{Binding Path=DeleteCommand}" Content="삭제" CommandParameter="{Binding ElementName=PersonsParam, Path=SelectedItem}" Width="75"/>
                <Button Command="{Binding ExitCommand}" Content="종료" CommandParameter="{Binding ElementName=MainViewParam}" Width="75"/>
            </dxlc:LayoutGroup>

        </dxlc:LayoutGroup>

    </dxlc:LayoutControl>
</dx:DXWindow>

```

```cs
using System.Windows;
// Tools > NuGet Package에 접속하여  System.Windows.Interactivity를 활용한다
// System.Windows.Interactivity 사용하기 위해 Expression.Blend.Sdk선택한다. : 
using DevExpress.Xpf.Core;


namespace _1.MVVM
{
    public partial class MainView : DXWindow, IWindowView
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel; // MainView와 MainViewModel의 연결
        }
    }
}

```
</details> 

<details>
<summary>MainViewModel.cs</summary>

```cs
using DevExpress.Mvvm;
using ReactiveUI; // MVVM패턴을 지원하는 프레임워크 (Tools > NuGet Package에 접속하여 ReactiveUI.WPF를 활용한다)
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using System.Windows.Input;

namespace _1.MVVM
{
    public class MainViewModel : ReactiveObject
    {
        public ObservableCollection<Person> Persons { get; set; }


        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand MouseMoveCommand { get; private set; }

        private string _mouseX;
        public string MouseX
        {
            get { return _mouseX; }
            set { this.RaiseAndSetIfChanged(ref _mouseX, value); }
        }
        private string _mouseY;
        public string MouseY
        {
            get { return _mouseY; }
            set { this.RaiseAndSetIfChanged(ref _mouseY, value); }
        }

        private readonly IMessageBoxService _messageBoxService;
        private readonly Func<Person, AddViewModel.ViewType, IDialogView> _createAddView;

        public MainViewModel(IMessageBoxService messageBoxService, Func<Person, AddViewModel.ViewType, IDialogView> createAddView)
        {
            _messageBoxService = messageBoxService;
            _createAddView = createAddView;
            Persons = new ObservableCollection<Person>();

            _initCommand();
            _initTestData();
        }

        private void _initCommand()
        {
            Persons.Add(new Person() { Address = "test1", Name = "홍길동1", Gender = true, PhoneNumber = "1" });
            Persons.Add(new Person() { Address = "test2", Name = "홍길동2", Gender = true, PhoneNumber = "2" });
            Persons.Add(new Person() { Address = "test3", Name = "홍길동3", Gender = true, PhoneNumber = "3" });
            Persons.Add(new Person() { Address = "test4", Name = "홍길동4", Gender = true, PhoneNumber = "4" });
        }

        private void _initTestData()
        {
            AddCommand = ReactiveCommand.Create(_addCommandAction);
            DeleteCommand = ReactiveCommand.Create<Person, Unit>(index => _deleteCommandAction(index));
            ModifyCommand = ReactiveCommand.Create<Person, Unit>(index => _modifyCommandAction(index));
            ExitCommand = ReactiveCommand.Create<IWindowView, Unit>(view => _exitCommandAction(view));
            MouseMoveCommand = ReactiveCommand.Create<Point, Unit>(args => _mouseMoveCommand(args));
        }

        private Unit _mouseMoveCommand(Point currentPoint)
        {
            MouseX = String.Format("{0}", currentPoint.X);
            MouseY = String.Format("{0}", currentPoint.Y);
            return Unit.Default;
        }

        private Unit _exitCommandAction(IWindowView view)
        {
            view.Close();
            return Unit.Default;
        }

        private Unit _modifyCommandAction(Person selectedItem)
        {
            if (selectedItem == null)
            {
                _messageBoxService.Show("선택된 데이터가 없습니다", "주소록 v1.0", MessageBoxButton.OK, MessageBoxImage.Information);
                return Unit.Default;
            }

            var modifyData = new Person(selectedItem);

            IDialogView view = _createAddView(modifyData, AddViewModel.ViewType.Modify);
            if (true == view.ShowDialog())
            {
                var selectIndex = Persons.IndexOf(selectedItem);
                Persons[selectIndex] = modifyData;
            }

            return Unit.Default;

        }

        private void _addCommandAction()
        {
            var addData = new Person();

            IDialogView view = _createAddView(addData, AddViewModel.ViewType.Add);
            if (true == view.ShowDialog())
                Persons.Add(addData);
        }

        private Unit _deleteCommandAction(Person selectedItem)
        {
            if (selectedItem == null)
            {
                _messageBoxService.Show("선택된 데이터가 없습니다", "주소록 v1.0", MessageBoxButton.OK, MessageBoxImage.Information);
                return Unit.Default;
            }

            var Result = _messageBoxService.Show("선택된 데이터를 삭제하시겠습니까?", "주소록 v1.0", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Cancel)
                return Unit.Default;

            Persons.Remove(selectedItem);
            return Unit.Default;
        }
    }
}

```
</details> 

<details>
<summary>MouseEventConverter.cs</summary>

```cs
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;
using System;
using System.Linq;
using System.Windows.Input;

namespace _1.MVVM
{
    internal class MouseEventConverter : EventArgsConverterBase<MouseEventArgs>
    {
        protected override object Convert(object sender, MouseEventArgs args)
        {
            var grid = sender as GridControl;

            return args.GetPosition(grid);
        }
    }
}
```
</details> 

<details>
<summary>Person.cs</summary>

```cs
using ReactiveUI;

namespace _1.MVVM
{
    public class Person : ReactiveObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
        }
        private bool _gender;
        public bool Gender
        {
            get { return _gender; }
            set { this.RaiseAndSetIfChanged(ref _gender, value); }
        }
        private string _phoneNumer;
        public string PhoneNumber
        {
            get { return _phoneNumer; }
            set { this.RaiseAndSetIfChanged(ref _phoneNumer, value); }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { this.RaiseAndSetIfChanged(ref _address, value); }
        }

        public Person()
        {
        }

        public Person(Person input)
        {
            _address = input.Address;
            _gender = input.Gender;
            _name = input.Name;
            _phoneNumer = input.PhoneNumber;
        }
    }
}
```
</details> 

<br><br>


# 03. DevExpress


- 기존의 1)MVVM 프로젝트에 이어서 활용한다.
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > NuGet 패키지 관리 > "ReactiveUI"를 Install한다.
- 다음 내용은 이전과 같다.
  - MouseEventConverter.cs
  - IDialogView.cs
  - IWindowView.cs
  - AddView.xaml.cs
  - App.xaml
  - App.xaml.cs
  - MainView.xaml.cs

<br>

<details>
<summary>Person.cs</summary>

```cs
using DevExpress.Mvvm;

namespace _1.MVVM
{
    public class Person : BindableBase
    {
        public string Name
        {
            get { return GetProperty(()=> Name); }
            set { SetProperty(() => Name, value); }
        }
        public bool Gender
        {
            get { return GetProperty(() => Gender); }
            set { SetProperty(() => Gender, value); }
        }
        public string PhoneNumber
        {
            get { return GetProperty(()=> PhoneNumber); }
            set { SetProperty(() => PhoneNumber, value); }
        }
        public string Address
        {
            get { return GetProperty(() => Address); }
            set { SetProperty(() => Address, value); }
        }

        public Person()
        {
        }

        public Person(Person input)
        {
            Address = input.Address;
            Gender = input.Gender;
            Name = input.Name;
            PhoneNumber = input.PhoneNumber;
        }
    }
}

```
</details> 

<details>
<summary>AddViewModel.cs</summary>

```cs
using DevExpress.Mvvm;
using ReactiveUI;
using System.Reactive;
using System.Windows.Input;

namespace _1.MVVM
{
    public class AddViewModel : ViewModelBase
    {
        public enum ViewType
        {
            Add,
            Modify
        }
        public string Caption
        {
            get { return GetProperty(() => Caption); }
            set { SetProperty(() => Caption, value); }
        }

        public Person PersonData 
        {
            get { return GetProperty(() => PersonData); }
            set { SetProperty(() => PersonData, value); }
        }
        public ICommand OkCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public AddViewModel(Person Data = null, ViewType type = ViewType.Add)
        {
            if (type == ViewType.Add)
            {
                Caption = "추가";
                PersonData = Data;
            }
            else if (type == ViewType.Modify)
            {
                Caption = "변경";
                PersonData = Data;
            }
            else
            {
                Caption = "추가";
                PersonData = new Person();
            }

            OkCommand = new DelegateCommand<IDialogView>(view => _okCommandAction(view));
            CancelCommand = new DelegateCommand<IDialogView>(view => _cancleCommandAction(view));
        }

        private void _cancleCommandAction(IDialogView view)
        {
            view.DialogResult = false;
            view.Close();
        }

        private void _okCommandAction(IDialogView view)
        {
            view.DialogResult = true;
            view.Close();
        }
    }
}
```
</details> 



# 정리

- View
  - MainView
  - Addview
- ViewModel
  - MainViewModel
  - AddViewModel
- Model
  - Person

### 전송

- View > ViewModel : DataBinding and Commands
- View < ViewModel : Send Notification
- ViewModel > Model : ViewModel Updates the Model
- Model > ViewModel : Send Notifications


<br><br><br><br>



# :bookmark_tabs: 교육 관련 총평(비평)

>>>

WPF에 대해 기초를 아주 잘 설명해주는 내용이었습니다.  
WPF를 처음 접할 때 가장 도움이 되는 내용이었습니다. 이전에 교육 받았던 [WPF 프로그래밍 강의 학습하고 내용 정리합니다](http://wish.mirero.co.kr/mirero/education/newface-group/newface/juhyung.park/-/issues/13)보다 [-먼저 교육받으면 좋다-]고 생각했습니다.  

C#을 처음 배운지 별로 안되었고, C#을 활용하면서 WPF에 대해서 배웠기에 C#을 활용해보는 훈련도 되었고, WPF에 대해 알아가면서 교육 진행하였습니다.  
덕분에, [+C#에 대해서도 감을 잡을 수 있었고+], [+WPF에 대해서도 정리하면서 감을 잡을 수 있었습니다.+]  

WPF에 대해서 잘 제어하고 원하는대로 목표한 것을 만들어낼 수 있도록, 개인적으로 WPF 관련 프로그램을 만들어보면서 WPF를 더욱 알아가는 제가 되겠습니다. 그렇게 해서 업무중에 WPF 관련해서 지체가 되지 않도록 하겠습니다! 빨리 WPF을 활용하여 다양한 표현을 할 수 있게 되었으면 좋겠습니다.  

  <br>

이번에 공부할 때 시간 소요를 관리하면서 공부를 하였습니다. 다음과 같이 시간소요가 되었습니다.  
### WPF MVVM  ---- 목표 : 1일(8h), 한개 프로젝트 2h 이내
Ch 01.  Bingding ------------------------ 5h
Ch 02.  MVVM -------------------------- 3h
Ch 03.  DevExpress .ReactiveUI--------- 4h
Ch 04.  DevExpress---------------------- 30m

- 한 챕터당 평균 1h 30m (89.6m) 소요
- 소요시간 : 1792m, 29.86h, 하루 8h 소요하면 학습시간은 3.73d 소요했습니다.
- 기술 세미나나 다른 특별 시간을 제외해서 고려하였기에, [+4~5d까지 소요할 수 있을 것+]으로 보입니다.

>>>

@ByungEun.Kim @JungOk.Kim @SeungHa.Lee @ChangBum.Kwon