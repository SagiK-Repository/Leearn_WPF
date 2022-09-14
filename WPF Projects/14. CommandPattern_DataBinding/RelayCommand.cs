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
