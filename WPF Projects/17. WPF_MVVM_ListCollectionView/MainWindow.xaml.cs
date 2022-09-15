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
