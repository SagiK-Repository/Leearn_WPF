using System.Windows.Input;
using System.Windows;

namespace _15.Command_Pattern_HelloWorld
{
    class MainWindowViewModel
    {
        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }

        public MainWindowViewModel()
        {
            // Command Set
            ButtonCommand = new RelayCommand(ShowMessage);
            // ButtonCommand = new RelayCommand(new Action<object>(ShowMessage));
        }

        public void ShowMessage(object param)
        {
            MessageBox.Show("Hi~ " + param.ToString());
        }
    }

}
