using System;
using System.Collections.Generic;
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
    public partial class TransfomrerSetting : UserControl
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

        public static double nominalPower { get; set; } = 40;
        public static double nominalHightVoltage { get; set; } = 115;
        public static double nominalMediumVoltage { get; set; } = 38.5;
        public static double nominalLowerVoltage { get; set; } = 11;

        public static int settingCountRPNHight { get; set; } = 19;
        public static double stepRPNHight { get; set; } = 1.78;

        public static int settingCountRPNMedium { get; set; } = 5;
        public static double stepRPNMedium { get; set; } = 2.5;
    }
}
