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
