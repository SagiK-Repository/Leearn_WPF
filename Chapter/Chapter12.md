# 13. WPF 데이터바이딩 (3)
- [+인터페이스 INotyfyPropertChanged+], [+이벤트 PropertyChanged+]를 [-활용한 데이터바인딩-]을 진행한다.
- 다수의 프로퍼티를 다루는 경우 용이하다.
- WPF 데이터 바인딩은 이벤트가 INotifyPropertyChanged 인터페이스를 구현한 클래스 안에 정의되어 있으면 이벤트를 찾는데 소스 객체의 속성 값의 변경을 통지하기 위해서 이 인터페이스를 상속받아 구현하고 PropertyChangedEventHandler 델리케이트를 기본으로 하는 PropertyChanged 이벤트를 정의해야 한다.
- PropertyChanged 이벤트를 발생시킬 때 처음 인자는 this이며 두번째 인자는 PropertyChangedEventArgs 타입의 객체이다.
- PropertyChangedEventArgs는 string 타입의 PropertyName 이라는 프로퍼티가 정의되어 있고 프로퍼티를 구별하기 위해 사용한다.
- PropertyChangedEventArgs를 new 하면서 프로퍼티 이름을 넣어준다.
- CallerMemberName 어트리뷰트를 통해 어느 프로퍼티에서 PropertyChanged 이벤트가 발생했는지 확인 가능하다.

### 실습

- Visual Studio > 새 프로젝트 > WPF 앱(.NET Framework) > 프로젝트 이름 변경 > 완료
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("ViewModel.cs") > 추가
- 솔루션 탐색기 > 프로젝트 > 오른쪽 마우스 > 추가 > 새항목 > C# > 코드 > 클래스 > 이름 변경 ("User.cs") > 추가
  - User 모델을 상속받은 ViewModel 객체가 데이터 바인딩의 소스 객체가 된다.
- UI를 구성한다.
<details><summary>MainWindow.xaml</summary>

```xml
<Window x:Class="_13.wpfDataBinding___2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_13.wpfDataBinding___2"
        mc:Ignorable="d"
        Title="MainWindow" Height="192" Width="501">
    <Grid HorizontalAlignment="Left" Height="155" Margin="10,10,0,0" VerticalAlignment="Top" Width="480">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="113*"/>
            <ColumnDefinition Width="127*"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Label Content="FirstName" HorizontalAlignment="Left" Height="32" Margin="10,10,0,0" VerticalAlignment="Top" Width="200"/>
        <Label Content="LastName" HorizontalAlignment="Left" Height="32" Margin="10,10,0,0" VerticalAlignment="Top" Width="200" Grid.Row="1"/>
        <TextBox Grid.Column="1" HorizontalAlignment="Left" Height="32" Margin="44,10,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="148" Text="{Binding FirstName}"/>
        <TextBox Grid.Column="1" HorizontalAlignment="Left" Height="32" Margin="44,10,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="148" Grid.Row="1" Text="{Binding LastName}"/>
        <Button Content="보기" HorizontalAlignment="Left" Margin="31,21,0,0" Grid.Row="2" VerticalAlignment="Top" Width="75" Grid.Column="1" Click="button_Click"/>
        <Button Content="이름변경" HorizontalAlignment="Left" Margin="151,21,0,0" Grid.Row="2" VerticalAlignment="Top" Width="75" Grid.Column="1" Click="button1_Click"/>
    </Grid>
</Window>
```
</details>

- User.cs를 다음과 같이 구성한다.
<details><summary>User.cs</summary>

```cs
namespace _13.wpfDataBinding___2
{
    class User : INotifyPropertyChanged
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            // PropertyChanged?.Invoe(this, new PropertyChangedEventArgs(propertyname)); //대신 가능
        }
    }

}
```
</details>

- 다음과 같이 ViewModel.cs를 구성한다.
<details><summary>ViewModel.cs</summary>

```cs
namespace _13.wpfDataBinding___2
{
    internal class ViewModel : User
    {
        public ViewModel()
        {
            FirstName = "KIL-DONG";
            LastName = "KIM";
        }
    }

}
```
</details>

- 다음과 같이 MainWindow.xaml.cs를 구성한다.
<details><summary>MainWindow.xaml.cs</summary>

```cs
namespace _13.wpfDataBinding___2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel v = new ViewModel();
            this.DataContext = v;
        }

        //MessageBox 출력
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel v = this.DataContext as ViewModel;
            MessageBox.Show(v.LastName + "," + v.FirstName);
        }

        //이름을 홍길동으로 변경, ViewModel 변경
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ViewModel v = this.DataContext as ViewModel;
            v.LastName = "홍";
            v.FirstName = "길동";
        }

    }
}
```
</details>

