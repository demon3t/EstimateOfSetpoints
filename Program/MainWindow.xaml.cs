using HandyControl.Tools;
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

namespace Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("ru");
        }

        #region TabControl #1

        #region Переключение типа трансформатора
        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            TransformerData.type = TransformerData.TypeTransformer.Double;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор";
            nominalMediumVoltage.IsEnabled = false;
            settingCountRPNMedium.IsEnabled = false;
            stepRPNMedium.IsEnabled = false;
        }
        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            TransformerData.type = TransformerData.TypeTransformer.Split;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор с расщеплённой обмоткой стороны НН";
            nominalMediumVoltage.IsEnabled = true;
            settingCountRPNMedium.IsEnabled = false;
            stepRPNMedium.IsEnabled = false;
        }
        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            TransformerData.type = TransformerData.TypeTransformer.Triple;
            SelectTypeTransformer.Content = "Трёхобмоточный трансформатор";
            nominalMediumVoltage.IsEnabled = true;
            settingCountRPNMedium.IsEnabled = true;
            stepRPNMedium.IsEnabled = true;
        }
        #endregion
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(((TextBox)sender).Text, out double result))
                return;

            switch (((TextBox)sender).Name)
            {
                case "nominalPower":
                    {
                        TransformerData.nominalPower = result;
                        break;
                    }
                case "nominalHightVoltage":
                    {
                        TransformerData.nominalHightVoltage = result;
                        break;
                    }
                case "nominalMediumVoltage":
                    {
                        TransformerData.nominalMediumVoltage = result;
                        break;
                    }
                case "nominalLowerVoltage":
                    {
                        TransformerData.nominalLowerVoltage = result;
                        break;
                    }
                case "settingCountRPNHight":
                    {
                        TransformerData.settingCountRPNHight = (int)result;
                        break;
                    }
                case "stepRPNHight":
                    {
                        TransformerData.stepRPNHight = result;
                        break;
                    }
                case "settingCountRPNMedium":
                    {
                        TransformerData.settingCountRPNMedium = (int)result;
                        break;
                    }
                case "stepRPNMedium":
                    {
                        TransformerData.stepRPNMedium = result;
                        break;
                    }
            }
        }


        private bool ChckReadyList_1()
        {
            if (nominalPower.Text.Length < 1)
                return false;

            if (nominalHightVoltage.Text.Length < 1)
                return false;

            if (nominalMediumVoltage.Text.Length < 1 && TransformerData.type != TransformerData.TypeTransformer.Double)
                return false;

            if (nominalLowerVoltage.Text.Length < 1)
                return false;

            if (settingCountRPNHight.Text.Length < 1)
                return false;

            if (stepRPNHight.Text.Length < 1)
                return false;

            if (settingCountRPNMedium.Text.Length < 1 && TransformerData.type == TransformerData.TypeTransformer.Triple)
                return false;

            if (stepRPNMedium.Text.Length < 1 && TransformerData.type == TransformerData.TypeTransformer.Triple)
                return false;

            return true;
        }

        #endregion


        #region TabControl #2

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(((TextBox)sender).Text, out double result))
                return;


            switch (((TextBox)sender).Name)
            {
                case "nominalPower":
                    {
                        TransformerData.nominalPower = result;
                        break;
                    }
                case "nominalHightVoltage":
                    {
                        TransformerData.nominalHightVoltage = result;
                        break;
                    }
                case "nominalMediumVoltage":
                    {
                        TransformerData.nominalMediumVoltage = result;
                        break;
                    }
                case "nominalLowerVoltage":
                    {
                        TransformerData.nominalLowerVoltage = result;
                        break;
                    }
                case "settingCountRPNHight":
                    {
                        TransformerData.settingCountRPNHight = (int)result;
                        break;
                    }
                case "stepRPNHight":
                    {
                        TransformerData.stepRPNHight = result;
                        break;
                    }
                case "settingCountRPNMedium":
                    {
                        TransformerData.settingCountRPNMedium = (int)result;
                        break;
                    }
                case "stepRPNMedium":
                    {
                        TransformerData.stepRPNMedium = result;
                        break;
                    }
            }
        }
        #endregion



        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)  // меняет ТОЧКУ на ЗАПЯТУЮ и запрещает повторную их запись
        {
            if (!(Char.IsDigit(e.Text, 0) || e.Text == "." || e.Text == ","))
            {
                e.Handled = true;
                return;
            }

            TextBox textBox = sender as TextBox;
            if (textBox != null)
                if ((e.Text == "." || e.Text == ",") && (textBox.Text.Contains(",") || textBox.Text.Contains(".")))
                {
                    e.Handled = true;
                    return;
                }


        }

        private void TextBox_PreviewTextInputNoDouble(object sender, System.Windows.Input.TextCompositionEventArgs e) // запрещает запись НЕ ЧИСЕЛ в Текстбокс
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                return;
            }

        }
        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) // запрещает запись ПРОБЕЛА в Текстбокс
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) // выделяет всё содержимое записанное в Текстбоксе
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
                textBox.SelectAll();

        }
    }
}
