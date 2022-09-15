# 17. WPF MVVM ListCollectionView 실습

- ListCollectionView 클래스는 List를 구현하는 컬렉션에 대한 컬렉션의 뷰를 나타낸다.
  - 컬렉션의 정렬, 필터링(검색), 탐색(앞/뒤/맨앞/맨뒤) 기능을 구현할 수 있다.

### MVVM

- 디자인 패턴에는 MVC, MVP, MVVM패턴들이 존재한다.
  - 각각 역할을 분리하여 관리하는데, 유지보수와 개발 효율이 좋아진다.<br><br>
- MVC 패턴은 Model+View+Controller를 합친 용어이다.  
  <img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2F7IE8f%2FbtqBRvw9sFF%2FAGLRdsOLuvNZ9okmGOlkx1%2Fimg.png" width="50%">
  - Model : 어플리케이션에 사용되는 데이터와 그 데이터를 처리하는 부분이다.
  - View : 사용자에게 보여지는 UI부분이다.
  - Controller : 사용자의 입력(Action)을 받고 처리하는 부분이다.
  - 동작은 다음과 같이 진행한다.
    1. 사용자의 Action들은 Controller에 들어온다.
    2. Controller는 사용자의 Action을 확인하고, Model을 업데이트 한다.
    3. Controller는 Model을 나타내줄 View를 선택한다.
    4. View는 Model을 이용하여 화면을 나타낸다.
    - MVC에서 View가 업데이트 되는 방법
      - View가 Model을 이용하여 직접 업데이트 하는 방법
      - Model에서 View에게 Notify하여 업데이트 하는 방법
      - View가 Polling으로 주기적으로 Model의 변경을 감지하여 업데이트 하는 방법
  - 특징
    - Controller는 여러개의 View를 선택할 수 있는 1:n 구조다.
    - Controller는 View를 선택할 뿐 직접 업데이트 하지 않는다. (View는 Controller를 알지 못한다.)
  - 장점
    - 널리 사용되고 있는 패턴이고, 가장 단순하다.
  - 단점
    - View와 Model 사이의 의존성이 높다.
    - 이는 어플리케이션이 커질수록 복잡하고 유지보수가 어려워진다. <br><br>
- MVP 패턴은 Model + View + Presenter를 합친 용어이다. Model과 View는 MVC 패턴과 동일하고, Controller 대신 Presenter가 존재한다.  
  <img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2FclZlsT%2FbtqBTLzeUCL%2FIDA8Ga6Yarndgr88g9Nkhk%2Fimg.png" width="50%">
  - Model : 어플리케이션에 사용되는 데이터와 그 데이터를 처리하는 부분이다.
  - View : 사용자에게 보여지는 UI부분이다.
  - Presenter : View에서 요청한 정보로 Model을 가공하여 View에 전달해 주는 부분이다.
  - 동작은 다음과 같이 진행한다.
    1. 사용자의 Action들은 View를 통해 들어온다.
    2. View는 데이터를 Presenter에 요청한다.
    3. Presenter는 Model에게 데이터를 요청한다.
    4. Model은 Presenter에서 요청받은 데이터를 응답한다.
    5. Presenter는 View에게 데이터를 응답한다.
    6. View는 Presenter가 응답한 데이터를 이용하여 화면을 나타낸다.
  - 특징
    - Presenter는 View와 Model의 인스턴스를 가지고 있어 둘을 연결하는 접착제 역할을 한다.
    - Presenter와 View는 1:1 관계이다.
  - 장점
    - View와 Model의 의존성이 없다. (Presenter를 통해서만 데이터를 전달 받기 때문)
  - 단점
    - View와 Presenter 사이의 의존성이 높다.
    - 어플리케이션이 복잡해 질 수록 View와 Presenter 사이의 의존성이 강해지는 단점이 있다. <br><br>
- MVVM 패턴은 Model + View + View Model를 합친 용어이다. Model과 View은 다른 패턴과 동일하다.  
  <img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2FCiXz0%2FbtqBQ1iMiVT%2FstaXr7UO95opKgXEU01EY0%2Fimg.png" width="50%">
  - Model : 어플리케이션에 사용되는 데이터와 그 데이터를 처리하는 부분이다.
  - View : 사용자에게 보여지는 UI부분이다.
  - View Model : View를 표현하기 위해 만든 View를 위한 Model이다. View를 나타내 주기 위한 Model이자 View를 나타내기 위한 데이터 처리를 하는 부분입니다.
  - 동작은 다음과 같이 진행한다.
    1. 사용자의 Action들은 View를 통해 들어온다.
    2. View에 Action이 들어오면, Command 패턴으로 View Model에 Action을 전달한다.
    3. View Model은 Model에게 데이터를 요청한다.
    4. Model은 View Model에게 요청받은 데이터를 응답한다.
    5. View Model은 응답 받은 데이터를 가공하여 저장한다.
    6. View는 View Model과 Data Binding하여 화면을 나타낸다.
  - 특징
    - MVVM 패턴은 Command 패턴과 Data Binding 두 가지 패턴을 사용하여 구현되었다.
    - Command 패턴과 Data Binding을 이용하여 View와 View Model 사이의 의존성을 없앴다.
    - View Model과 View는 1:n 관계이다.
  - 장점
    - MVVM 패턴은 View와 Model 사이의 의존성이 없다.
    - Command 패턴과 Data Binding을 사용하여 View와 View Model 사이의 의존성 또한 없앤 디자인패턴이다.
    - 각각의 부분은 독립적이기 때문에 모듈화 하여 개발할 수 있다.
  - 단점
    - View Model의 설계가 쉽지 않다.

<br><br>

### 실습
- 실습 목표
  - 사원의 목록을 ListBox에 출력한다.
  - 상단의 버튼을 통해 정렬 기능을 구현한다.
  - 하단의 버튼을 통해 탐색, 필터링(검색) 기능을 구현한다.
- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- MVVM 패턴은 다음과 같다.
  - <img src="http://wish.mirero.co.kr/mirero/education/newface-group/newface/donggye.jang/uploads/b983870dad274c9bdaf8cd60ee650edb/image.png" width="70%">
- MainWindow.xaml 및 MainWindow.xaml.cs는 View에 해당한다.
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("Emp.cs") > 추가 (Model에 해당한다.)
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("EmpViewModel.cs") > 추가 (ViewModel에 해당한다.)
- Model(Emp.cs)를 구성한다.
<details><summary>Emp.cs</summary>

```cs
using System.ComponentModel;

namespace _17.WPF_MVVM_ListCollectionView
{
    // Model : 값 (프로퍼티) 이 바뀌면 UI Control 에 값이 바뀐 것을 통지 해주어야 함
    // (ViewModel로 알림) (EmpViewModel)

    class Emp : INotifyPropertyChanged // ViewModel로 값이 바뀌었다는 것을 알려주기 위함
    {
        private int _empNo;
        private string _eName;
        private string _job;

        // PropertyChangedEventHandler : 구성 요소에서 속성이 변경될 때 발생하는 PropertyChanged 이벤트를 처리할 메서드를 나타낸다.
        public event PropertyChangedEventHandler PropertyChanged;

        //3개의 속성 EmpNo, EName, Job
        public int EmpNo // _empNo 변수를 Handling
        {
            get { return _empNo; }
            set
            {
                _empNo = value;
                //OnPropertyChanged("EmpNo"); // OnPropertyChanged 메소드를 부름, 속성의 이름을 전달
            }
        }

        public string EName // _eName 변수를 Handling
        {
            get { return _eName; }
            set
            {
                _eName = value;
                //OnPropertyChanged("EName");
            }
        }

        public string Job // _job 변수를 Handling
        {
            get { return _job; }
            set
            {
                _job = value;
                //OnPropertyChanged("Job");
            }
        }

        // 프로퍼티들이 각각 변경될 때마다 수행되어 PropertyChanged 이벤트를 호출 (속성 값이 변경됨을 알림) (생략 가능)
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                // 속성값이 변하였음을 알린다.
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            //또는 PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //private void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(name));
        //    }
        //}
    }
}
```
</details>

- ViewModel(EmpViewModel.cs)을 구성한다.
<details><summary>EmpViewModel.cs</summary>

```cs
using System.Collections.ObjectModel;

namespace _17.WPF_MVVM_ListCollectionView
{
    // ViewModel
    // Model의 바뀐 값을 데이터바인딩으로 UI에 표시해줌
    // ObservableCollection<Emp> : List<>와 동일한 역할이나, 값이 들어오고 나갈 때 변경사항을 자동으로 통제해줌
    class EmpViewModel : ObservableCollection<Emp> 
    {
        public EmpViewModel()
        {
            // ObservableCollection에 Add 진행
            // View 쪽에서 EmpNo, EName, Job을 Data Binding 되고 있기에 자동으로 통제
            Add(new Emp() { EmpNo = 1, EName = "김길동", Job = "Salesman" });
            Add(new Emp() { EmpNo = 2, EName = "박길동", Job = "Clerk" });
            Add(new Emp() { EmpNo = 3, EName = "정길동", Job = "Clerk" });
            Add(new Emp() { EmpNo = 4, EName = "남길동", Job = "Clerk" });
            Add(new Emp() { EmpNo = 5, EName = "황길동", Job = "Salesman" });
            Add(new Emp() { EmpNo = 6, EName = "홍길동", Job = "Manager" });
        }
    }

}
```
</details>

- View(UI)를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_17.WPF_MVVM_ListCollectionView.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_17.WPF_MVVM_ListCollectionView"
        mc:Ignorable="d"
        Title="MainWindow" Height="285" Width="421">
    <!--Window.Resources로 미리 자원 등록-->
    <Window.Resources> 
        <!--EmpViewModel 자원을 "emps"로 등록-->
        <local:EmpViewModel x:Key="emps"/>
        <!--"template 라는 이름으로 DataTemplate를 등록-->
        <!--Column 표를 만드는 틀을 정의한다.-->
        <DataTemplate x:Key="template">
            <Grid Width="400">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="100"/>
                    <ColumnDefinition Width="150"/>
                    <ColumnDefinition Width="150"/>
                </Grid.ColumnDefinitions>
                <TextBlock Text="{Binding Path=EmpNo}"/>
                <TextBlock Grid.Column="1" Text="{Binding Path=EName}"/>
                <TextBlock Grid.Column="2" Text="{Binding Path=Job}"/>
            </Grid>
        </DataTemplate>
    </Window.Resources>
    <!--StackPanel 객체에 emps 소스 할당-->
    <StackPanel Name="rootElement"
                DataContext="{Binding Source={StaticResource emps}}" 
                DataContextChanged="MainWindow_DataContextChanged">
        <Grid Width="400">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="100"/>
                <ColumnDefinition Width="150"/>
                <ColumnDefinition Width="150"/>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition/>
                <RowDefinition/>
                <RowDefinition/>
                <RowDefinition Height="20"/>
                <RowDefinition/>
                <RowDefinition/>
            </Grid.RowDefinitions>
            <TextBlock HorizontalAlignment="Center" Grid.ColumnSpan="3">사원 리스트</TextBlock>
            <Button Grid.Row="1" Grid.Column="0" Name="btnEmpNo" Content="EmpNo" Click="OnClick"></Button>
            <Button Grid.Row="1" Grid.Column="1" Name="btnEName" Content="EName" Click="OnClick"></Button>
            <Button Grid.Row="1" Grid.Column="2" Name="btnJob" Content="Job" Click="OnClick"></Button>
            <ListBox Grid.Row="2" Grid.ColumnSpan="3" Name="empListBox" 
                    ItemsSource="{Binding Source={StaticResource emps}}" 
                    ItemTemplate="{StaticResource template}"
                    IsSynchronizedWithCurrentItem="True"
                    ScrollViewer.HorizontalScrollBarVisibility="Disabled"/>
            <TextBlock Foreground="Blue" Grid.Row="3" Grid.ColumnSpan="3">이전/이후/데이터필터링</TextBlock>
            <Button Grid.Row="4" Grid.Column="0" Name="Previous" Click="OnMove">Previous</Button>
            <Button Grid.Row="4" Grid.Column="1" Name="Next" Click="OnMove">Next</Button>
            <Button Grid.Row="4" Grid.Column="2" Name="Filter" Click="OnFilter">Show only Manager</Button>

            <TextBlock Grid.Row="5" Grid.Column="0" Name="tblEmpNo" Text="{Binding Path=EmpNo}"/>
            <TextBlock Grid.Row="5" Grid.Column="1" Name="tblEName" Text="{Binding Path=EName}"/>
            <TextBlock Grid.Row="5" Grid.Column="2" Name="tblJob" Text="{Binding Path=Job}"/>

        </Grid>
    </StackPanel>
   
</Window>
```
</details>

- View(UI)를 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace _17.WPF_MVVM_ListCollectionView
{
    public partial class MainWindow : Window
    {
        private ListCollectionView _MyCollectionView; // 컬렉션의 정렬, 필터링, 탐색 기능을 구현 가능하도록 지원
        private Emp _emp;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void MainWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            // StackPanel의 DataContext로 지정된 emps 컬렉션을 소스로 ListCollectionView 생성하여 정렬, 탐색, 필터링 기능 등 구현
            _MyCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(rootElement.DataContext);
        }

        // ListBox 상단 정렬 기능
        private void OnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            // View 클리어
            _MyCollectionView.SortDescriptions.Clear();

            switch (btn.Name)
            {
                case "btnEmpNo":
                    _MyCollectionView.SortDescriptions.Add(new SortDescription("EmpNo", ListSortDirection.Ascending));
                    break; // Ascending : 오름차순
                case "btnEName":
                    _MyCollectionView.SortDescriptions.Add(new SortDescription("EName", ListSortDirection.Ascending));
                    break;
                case "btnJob":
                    _MyCollectionView.SortDescriptions.Add(new SortDescription("Job", ListSortDirection.Ascending));
                    break;
                default:
                    break;
            }

        }

        // Previous, Next 처리
        private void OnMove(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            
            switch (btn.Name)
            {
                case "Previous":
                    if (_MyCollectionView.MoveCurrentToPrevious())
                        _emp = _MyCollectionView.CurrentAddItem as Emp;
                    else // 이동
                        _MyCollectionView.MoveCurrentToFirst();
                    break;
                case "Next":
                    if (_MyCollectionView.MoveCurrentToNext())
                        _emp = _MyCollectionView.CurrentAddItem as Emp;
                    else
                        _MyCollectionView.MoveCurrentToLast();
                    break;
                default:
                    break;
            }
        }

        // manager만 필터링 (토글)
        private void OnFilter(object sender, RoutedEventArgs e)
        {
            switch (_MyCollectionView.Filter)
            {
                // Filter 델리게이트는 보여줄 데이터인지 아닌지 판단할 수 있는 메소드 참조
                case null:
                    _MyCollectionView.Filter = IsManager; // manager만
                    break; // Filter : delegate
                default:
                    _MyCollectionView.Filter = null; // 전체 토글
                    break;
            }
        }

        private bool IsManager(object obj)
        {
            Emp emp = obj as Emp;

            if (emp.Job == "Manager") return true;
            else return false;

            //return emp?.Job == "Manager";
        }


    }
}

```
</details>


### 결과

- <img src="https://user-images.githubusercontent.com/66783849/190461672-a81cf89e-f183-48ad-ac6e-363880f6e5a7.png" width="70%">
