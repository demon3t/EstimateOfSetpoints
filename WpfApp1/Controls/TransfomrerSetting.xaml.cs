using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Controls
{
    /// <summary>
    /// Логика взаимодействия для TransfomrerSetting.xaml
    /// </summary>
    public partial class TransfomrerSetting : UserControl, IValueConverter
    {

        public TransfomrerSetting()
        {
            InitializeComponent();
        }
        public enum TypeTransformer
        {
            Double = 1,
            Split = 2,
            Triple = 3
        }
        public static TypeTransformer type { get; set; }

        public static double nominalPower { get; set; }
        public static double nominalHightVoltage { get; set; }
        public static double nominalMediumVoltage { get; set; }
        public static double nominalLowerVoltage { get; set; }

        public static int settingCountRPNHight { get; set; }
        public static double stepRPNHight { get; set; }

        public static int settingCountRPNMedium { get; set; }
        public static double stepRPNMedium { get; set; }


        public static readonly DependencyProperty TestikProperty = DependencyProperty.Register(
            "Testik", typeof(string), typeof(string));

        public string Testik
        {
            get => (string)GetValue(TestikProperty);
            set => SetValue(TestikProperty, value);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return double.Parse(value.ToString());
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                return value.ToString();
            }
            return value;
        }
    }
}
