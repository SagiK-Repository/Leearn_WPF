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