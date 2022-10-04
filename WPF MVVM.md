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


# 02. 