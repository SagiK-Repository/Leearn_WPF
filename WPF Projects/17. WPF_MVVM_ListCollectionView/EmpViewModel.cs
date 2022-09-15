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
