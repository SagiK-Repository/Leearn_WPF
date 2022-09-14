using System;
using System.Globalization;
using System.Windows.Data;

namespace _16.wpfIValueConverter
{
    // 데이터 바인딩은 기본 양방향이므로 양방향에 대한 함수 각각 존재

    internal class YesNoToBoolConverter : IValueConverter
    {
        // 소스 값이 타켓에 바인딩 되는 경우 호출 (TextBox -> TextBlock, TextBox -> CheckBox)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString().ToUpper())
            {
                case "YES": return true;
                case "NO": return false;
            }

            return false;
        }

        // 타겟 값이 역으로 소스에 바인딩 될 때 호출 (CheckBox -> TextBox)
        // 체크박스를 체그하거나 해제하였을 때
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value) return "YES";
                else return "NO";
            }

            return "NO";
        }

    }
}
