using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Calculator
{
    internal class CalcViewModel : INotifyPropertyChanged // 값이 바뀌었다는 것을 알려주기 위함
    {

        #region 속성

        string inputString = ""; //출력될 문자들을 담아둘 변수
        string displayText = ""; //계산기화면의 출력 텍스트박스에 대응되는 필드

        public string Op { get; set; } //Operator "사칙연산"이 저장
        public double? Op1 { get; set; } //Operand1 먼저 입력한 숫자 저장 ( "3" + 2 = )

        public ICommand Append { protected set; get; } // 자릿수 늘리기
        public ICommand Backspace { protected set; get; }
        public ICommand Clear { protected set; get; }
        public ICommand ClearEntry { protected set; get; }
        public ICommand Reversal { protected set; get; }
        public ICommand Operator { protected set; get; } // 사칙연산
        public ICommand Calculate { protected set; get; } // =


        public string InputString
        {
            internal set
            {
                if (inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged("InputString");
                    if (value != "")
                    {
                        //숫자를 여러개 입력하면 계속 화면에 출력하기 위해
                        DisplayText = value;
                    }
                }
            }
            get { return inputString; }
        }

        //계산기의 출력창과 바인딩된 속성
        public string DisplayText
        {
            internal set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
            get { return displayText; }
        }

        #endregion

        #region 생성자

        //생성자, 명령객체들을 초기화
        //명령객체들은 UI쪽 버튼의 Command에 바인딩 되어 있다.
        public CalcViewModel()
        {
            //이벤트 핸들러 정의
            //숫자 버튼을 클릭할 때 실행
            this.Append = new Append(this);

            //백스페이스 버튼을 클릭할 때 실행, 한글자 삭제
            this.Backspace = new Backspace(this);

            //출력화면 클리어
            this.Clear = new Clear(this);

            //+, -, *, / 등 ㅇ연산자 클릭할 때 실행
            this.Operator = new Operator(this);

            // = 버튼을 클릭할 때 실행
            this.Calculate = new Calculate(this);

            this.ClearEntry = new ClearEntry(this);
            
            this.Reversal = new Reversal(this);
        }

        #endregion

        #region 이벤트핸들러

        //View와 바인딩된 속성값이 바뀔 때 이를 WPF에게 알리기 위한 이벤트
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region 이벤트

        // 프로퍼티들이 각각 변경될 때마다 수행되어 PropertyChanged 이벤트를 호출 (속성 값이 변경됨을 알림) (생략 가능)
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                // 속성값이 변하였음을 알린다.
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //또는 PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}
