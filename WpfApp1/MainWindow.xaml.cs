using Calculation;
using HandyControl.Tools;
using System.Windows;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Transformer transformer = new Transformer()
        {
            type = Transformer.TypeTransformer.Double,
            nominalPower = 40,
            nominalHightVoltage = 115,
            nominalMediumVoltage = 38.5,
            nominalLowerVoltage = 11,
        };
        public MainWindow()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("ru");
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            transformer.type = Transformer.TypeTransformer.Double;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор";
        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            transformer.type = Transformer.TypeTransformer.Split;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор с расщеплённой обмоткой стороны НН";
        }
        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            transformer.type = Transformer.TypeTransformer.Triple;
            SelectTypeTransformer.Content = "Трёххобмоточный трансформатор";
        }
    }
}
