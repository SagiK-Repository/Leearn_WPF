using System;
using System.Windows.Input;
using System.Windows.Media.Converters;

namespace WPF_Calculator
{
    class Append : ICommand
    {
        private CalcViewModel _viewModel;
        public event EventHandler CanExecuteChanged;
        public Append(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter) // 커멘드 여부
        {
            return true;
        }

        public void Execute(object parameter) // 커멘드가 호출되면 Excute 실행
        {
            _viewModel.InputString += parameter; // 값 부여
        }
    }

    class CalcCommand : ICommand
    {
        private CalcViewModel _viewModel;
        public event EventHandler CanExecuteChanged;
        public CalcCommand(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
        }
    }


    class Backspace : ICommand
    {
        private CalcViewModel _viewModel;
        public Backspace(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            // CanExecute 조건에 따라 버튼 활성화
            add { CommandManager.RequerySuggested += value; }
            // CanExecute 조건에 따라 버튼 비활성화
            remove { CommandManager.RequerySuggested -= value; } 
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.DisplayText.Length > 0; //조건
        }

        public void Execute(object parameter)
        {
            int length = _viewModel.InputString.Length - 1;

            if (length > 0)
            {
                // 맨 뒷자리 글자를 하나 자른다
                _viewModel.InputString = _viewModel.InputString.Substring(0, length);
            }
            else
            {
                _viewModel.InputString = _viewModel.DisplayText = "";
            }


        }
    }


    class Clear : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Clear(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.DisplayText.Length > 0;
        }

        public void Execute(object parameter)
        {
            _viewModel.InputString = _viewModel.DisplayText = "";
            _viewModel.Op1 = null;
        }
    }


    class Operator : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public Operator(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string op = parameter.ToString(); // 입력한 사칙연산 들어온다.
            double op1;
            if (double.TryParse(_viewModel.InputString, out op1))
            {
                _viewModel.Op1 = op1;
                _viewModel.Op = op;
                _viewModel.InputString = ""; // 3 + 를 누르면, DisplayText는 3, InputText는 Clear
            }else if (_viewModel.InputString == "" && op == "-")
            {
                _viewModel.InputString = "-";
            }
        }
    }


    class Calculate : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Calculate(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            double op2;
            return _viewModel.Op1 != null && double.TryParse(_viewModel.InputString, out op2);
        }

        public void Execute(object parameter)
        {
            double op2 = double.Parse(_viewModel.InputString);
            _viewModel.InputString = calculate(_viewModel.Op, (double)_viewModel.Op1, op2).ToString();
        }

        private static double calculate(string op, double op1, double op2)
        {
            switch (op)
            {
                case "+": return op1 + op2;
                case "-": return op1 - op2;
                case "*": return op1 * op2;
                case "/": return op1 / op2;
                default: return 0;
            }
        }

    }

    class ClearEntry : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ClearEntry(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.DisplayText.Length > 0;
        }

        public void Execute(object parameter)
        {
            _viewModel.InputString = _viewModel.DisplayText = "";
        }
    }

    class Reversal : ICommand
    {
        private CalcViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Reversal(CalcViewModel ViewModel)
        {
            this._viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.InputString.Length > 0;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.InputString.Substring(0, 1) != "-" )
            {
                _viewModel.InputString = _viewModel.InputString.Insert(0, "-");
                //_viewModel.InputString = "-" + _viewModel.InputString;
            }
            else
            {
                // "-"가 존재할 경우, 첫 글자를 자른다.
                _viewModel.InputString = _viewModel.InputString.Substring(1, _viewModel.InputString.Length-1);
            }

        }
    }

}
