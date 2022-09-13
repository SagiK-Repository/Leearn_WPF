using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.WPF_Example
{
    public enum DutyType
    {
        Inner, Outside
    }

    public class Duty
    {
        private string _name; // 직무명
        private DutyType _dutyType; // 직무 타입, 내근, 외근

        public Duty() { }
        public Duty(string name, DutyType dutyType)
        {
            _name = name;
            _dutyType = dutyType;
        }

        public string DutyName
        {
            get { return _name; }
            set { _name = value; }
        }

        public DutyType DutyType
        {
            get { return _dutyType; }
            set { _dutyType = value; }
        }

    }


    public class Duties : ObservableCollection<Duty>
    {
        public Duties() {
            Add(new Duty("SALES", DutyType.Outside));
            Add(new Duty("LOGISTICS", DutyType.Outside));
            Add(new Duty("IT", DutyType.Inner));
            Add(new Duty("MARKETING", DutyType.Inner));
            Add(new Duty("HR", DutyType.Inner));
            Add(new Duty("PROPOTION", DutyType.Outside));
        }
    }

}
