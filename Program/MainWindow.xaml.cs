using HandyControl.Tools;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        private void TabItem1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MW.MaxHeight = 570;
            MW.MinHeight = 570;
            MW.Height = 570;
        }

        #region Переключение типа трансформатора
        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            TransformerData.type = TransformerData.TypeTransformer.Double;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор";
            nominalMediumVoltage.IsEnabled = false;
            settingCountRPNMedium.IsEnabled = false;
            stepRPNMedium.IsEnabled = false;

            _MaxCurrentMildleKZ_ToHight.IsEnabled = false;
            _MaxCurrentMildleKZ.IsEnabled = false;

            Middle1.Opacity = 0.5;
            _MaxCurrentMildle.IsEnabled = false;

            if (Calcul.bmrz == Calcul.BMRZ.Second || TransformerData.type == TransformerData.TypeTransformer.Double)
            {
                Middle2.Opacity = 0.5;
                _PTNMedium.IsEnabled = false;
                Middle3.Opacity = 0.5;
                r_PTNMedium.IsEnabled = false;
            }
            else
            {
                Middle2.Opacity = 1;
                _PTNMedium.IsEnabled = true;
                Middle3.Opacity = 1;
                r_PTNMedium.IsEnabled = true;
            }
        }
        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            TransformerData.type = TransformerData.TypeTransformer.Split;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор с расщеплённой обмоткой стороны НН";

            nominalMediumVoltage.IsEnabled = true;
            settingCountRPNMedium.IsEnabled = false;
            stepRPNMedium.IsEnabled = false;

            _MaxCurrentMildleKZ_ToHight.IsEnabled = true;
            _MaxCurrentMildleKZ.IsEnabled = true;

            Middle1.Opacity = 1;
            _MaxCurrentMildle.IsEnabled = true;

            if (Calcul.bmrz == Calcul.BMRZ.Second || TransformerData.type == TransformerData.TypeTransformer.Double)
            {
                Middle2.Opacity = 0.5;
                _PTNMedium.IsEnabled = false;
                Middle3.Opacity = 0.5;
                r_PTNMedium.IsEnabled = false;
            }
            else
            {
                Middle2.Opacity = 1;
                _PTNMedium.IsEnabled = true;
                Middle3.Opacity = 1;
                r_PTNMedium.IsEnabled = true;
            }
        }
        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            TransformerData.type = TransformerData.TypeTransformer.Triple;
            SelectTypeTransformer.Content = "Трёхобмоточный трансформатор";

            nominalMediumVoltage.IsEnabled = true;
            settingCountRPNMedium.IsEnabled = true;
            stepRPNMedium.IsEnabled = true;

            _MaxCurrentMildleKZ_ToHight.IsEnabled = true;
            _MaxCurrentMildleKZ.IsEnabled = true;

            Middle1.Opacity = 1;
            _MaxCurrentMildle.IsEnabled = true;

            if (Calcul.bmrz == Calcul.BMRZ.Second || TransformerData.type == TransformerData.TypeTransformer.Double)
            {
                Middle2.Opacity = 0.5;
                _PTNMedium.IsEnabled = false;
                Middle3.Opacity = 0.5;
                r_PTNMedium.IsEnabled = false;
            }
            else
            {
                Middle2.Opacity = 1;
                _PTNMedium.IsEnabled = true;
                Middle3.Opacity = 1;
                r_PTNMedium.IsEnabled = true;
            }
        }
        #endregion

        #region Переключение типа БМРЗ
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Calcul.bmrz = Calcul.BMRZ.First;
            SelectTypeBMRZ.Content = "БМРЗ-ТД-10(11,00,01)-30-21";

            if (Calcul.bmrz == Calcul.BMRZ.Second || TransformerData.type == TransformerData.TypeTransformer.Double)
            {
                Middle2.Opacity = 0.5;
                _PTNMedium.IsEnabled = false;
                Middle3.Opacity = 0.5;
                r_PTNMedium.IsEnabled = false;
            }
            else
            {
                Middle2.Opacity = 1;
                _PTNMedium.IsEnabled = true;
                Middle3.Opacity = 1;
                r_PTNMedium.IsEnabled = true;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Calcul.bmrz = Calcul.BMRZ.Second;
            SelectTypeBMRZ.Content = "БМРЗ-ТД-12(13,02,03)-20-21";

            if (Calcul.bmrz == Calcul.BMRZ.Second || TransformerData.type == TransformerData.TypeTransformer.Double)
            {
                Middle2.Opacity = 0.5;
                _PTNMedium.IsEnabled = false;
                Middle3.Opacity = 0.5;
                r_PTNMedium.IsEnabled = false;
            }
            else
            {
                Middle2.Opacity = 1;
                _PTNMedium.IsEnabled = true;
                Middle3.Opacity = 1;
                r_PTNMedium.IsEnabled = true;
            }
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

        #endregion

        #region TabControl #2

        private void TabItem2_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MW.MaxHeight = 600;
            MW.MinHeight = 600;
            MW.Height = 600;
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(((TextBox)sender).Text, out double result))
                return;


            switch (((TextBox)sender).Name)
            {
                case "TTKVN":
                    {
                        TT.transfCoeffHight = result;
                        break;
                    }
                case "TTKMV":
                    {
                        TT.transfCoeffMedium = result;
                        break;
                    }
                case "TTKLV":
                    {
                        TT.transfCoeffLower = result;
                        break;
                    }
                case "_Emax":
                    {
                        TT.Emax = result;
                        break;
                    }
                case "_Emin":
                    {
                        TT.Emin = result;
                        break;
                    }
                case "_E05":
                    {
                        TT.E0_5 = result;
                        break;
                    }
                case "_Erabmax":
                    {
                        TT.Erab_max = result;
                        break;
                    }
                case "_E15":
                    {
                        TT.E1_5 = result;
                        break;
                    }
                case "_MaxCurrentHightKZ":
                    {
                        Currents.MaxCurrentHightKZ = result;
                        break;
                    }
                case "_MaxCurrentMildleKZ":
                    {
                        Currents.MaxCurrentMildleKZ = result;
                        break;
                    }
                case "_MaxCurrentLowerKZ":
                    {
                        Currents.MaxCurrentLowerKZ = result;
                        break;
                    }
                case "_MaxCurrentHightKZ_ToHight":
                    {
                        Currents.MaxCurrentHightKZ_ToHight = result;
                        break;
                    }
                case "_MaxCurrentMildleKZ_ToHight":
                    {
                        Currents.MaxCurrentMildleKZ_ToHight = result;
                        break;
                    }
                case "_MaxCurrentLowerKZ_ToHight":
                    {
                        Currents.MaxCurrentLowerKZ_ToHight = result;
                        break;
                    }
                case "_MinCurrentOtherKZ":
                    {
                        Currents.MinCurrentOtherKZToHight = result;
                        break;
                    }
                case "_MaxCurrentTSNKZ":
                    {
                        Currents.MaxCurrentTSN = result;
                        break;
                    }
                case "_WorkCurrentTSN":
                    {
                        Currents.WorkCurrentTSN = result;
                        break;
                    }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.IsChecked == true)
                {
                    _MaxCurrentTSNKZ.IsEnabled = true;
                    _WorkCurrentTSN.IsEnabled = true;
                    Currents.tsn = Currents.TSN.Yes;
                }
                else
                {
                    _MaxCurrentTSNKZ.IsEnabled = false;
                    _WorkCurrentTSN.IsEnabled = false;
                    Currents.tsn = Currents.TSN.No;
                }
            }
        }
        #endregion

        #region TabControl #3


        private void TabItem3_Result_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MW.MaxHeight = 620;
            MW.MinHeight = 620;
            MW.Height = 620;


            Calculing();
        }


        #endregion


        private void Calculing()
        {
            Calcul.Go();

            #region Номинатьные токи сторон
            _MaxCurrentHight.Text = Calcul.NominalCurrentHight.ToString();
            _MaxCurrentMildle.Text = Calcul.NominalCurrentMedium.ToString();
            _MaxCurrentLower.Text = Calcul.NominalCurrentLower.ToString();
            #endregion

            #region ПТН

            _PTNHigth.Text = Calcul.NominalCurrentHightPTN;

            _PTNMedium.Text = Calcul.NominalCurrentMediunPTN;

            _PTNLower.Text = Calcul.NominalCurrentLowerPTN;

            if (_PTNHigth.Text != "ПТН не выбран")
            {
                _PTNHigth.Background = double.Parse(_PTNHigth.Text) < 2 ?
                    double.Parse(_PTNHigth.Text) <= 3 * Calcul.NominalCurrentHight / TT.transfCoeffHight ? Brushes.LightGreen : Brushes.IndianRed :
                    double.Parse(_PTNHigth.Text) <= 6 * Calcul.NominalCurrentHight / TT.transfCoeffHight ? Brushes.LightGreen : Brushes.IndianRed;
            }
            else
            {
                _PTNHigth.Background = Brushes.IndianRed;
            }

            if (_PTNMedium.Text != "ПТН не выбран" && _PTNMedium.Text != " ")
            {
                _PTNMedium.Background = double.Parse(_PTNMedium.Text) < 2 ?
                double.Parse(_PTNMedium.Text) <= 3 * Calcul.NominalCurrentMedium / TT.transfCoeffMedium ? Brushes.LightGreen : Brushes.IndianRed :
                double.Parse(_PTNMedium.Text) <= 6 * Calcul.NominalCurrentMedium / TT.transfCoeffMedium ? Brushes.LightGreen : Brushes.IndianRed;

            }
            else if (_PTNMedium.Text == " ")
            {

            }
            else
            {
                _PTNMedium.Background = Brushes.IndianRed;
            }

            if (_PTNLower.Text != "ПТН не выбран")
            {
                _PTNLower.Background = double.Parse(_PTNLower.Text) < 2 ?
            double.Parse(_PTNLower.Text) <= 3 * Calcul.NominalCurrentLower / TT.transfCoeffLower ? Brushes.LightGreen : Brushes.IndianRed :
            double.Parse(_PTNLower.Text) <= 6 * Calcul.NominalCurrentLower / TT.transfCoeffLower ? Brushes.LightGreen : Brushes.IndianRed;
            }
            else
            {
                _PTNLower.Background = Brushes.IndianRed;
            }

            #endregion

            #region ДТО

            _MaximumUnbalanceCurrent.Text = Calcul.MaximumUnbalanceCurrent.ToString();

            if (_DTOTriggerSetpoint != null)
                _DTOTriggerSetpoint.Text = Calcul.DTOTriggerSetpoint.ToString();

            #endregion

            #region Грубый огран ДЗТ
            if (_Rought_InitialCurrent != null)
                _Rought_InitialCurrent.Text = Calcul.Rought_InitialCurrent.ToString();
            if (_Rought_InitialCurrent_1_5 != null)
                _Rought_InitialCurrent_1_5.Text = Calcul.Rought_InitialCurrent_1_5.ToString();
            if (_Rought_SecondDecelerationCoefficient != null)
                _Rought_SecondDecelerationCoefficient.Text = Calcul.Rought_SecondDecelerationCoefficient.ToString();
            if (_Rought_MaxiBrakingCurrent != null)
                _Rought_MaxiBrakingCurrent.Text = Calcul.Rought_MaxiBrakingCurrent.ToString();
            if (_Rought_ThirdDecelerationCoefficient != null)
                _Rought_ThirdDecelerationCoefficient.Text = Calcul.Rought_ThirdDecelerationCoefficient.ToString();

            #endregion

            #region Грубый огран ДЗТ
            if (_Sensitive_InitialCurrent != null)
                _Sensitive_InitialCurrent.Text = Calcul.Sensitive_InitialCurrent.ToString();
            if (_Sensitive_InitialCurrent_1_5 != null)
                _Sensitive_InitialCurrent_1_5.Text = Calcul.Sensitive_InitialCurrent_1_5.ToString();
            if (_Sensitive_SecondDecelerationCoefficient != null)
                _Sensitive_SecondDecelerationCoefficient.Text = Calcul.Sensitive_SecondDecelerationCoefficient.ToString();
            if (_Sensitive_MaxiBrakingCurrent != null)
                _Sensitive_MaxiBrakingCurrent.Text = Calcul.Sensitive_MaxUnbalanceCurrent.ToString();
            if (_Sensitive_ThirdDecelerationCoefficient != null)
                _Sensitive_ThirdDecelerationCoefficient.Text = Calcul.Sensitive_ThirdDecelerationCoefficient.ToString();

            #endregion

            #region Проверка чувствительности и сигнализация
            if (_SensitivityCoefficient != null)
                _SensitivityCoefficient.Text = Calcul.SensitivityCoefficient.ToString();
            if (_UnbalanceAlarmRate != null)
                _UnbalanceAlarmRate.Text = Calcul.UnbalanceAlarmRate.ToString();

            if (Calcul.SensitivityCoefficient < 1.5 && _SensitivityCoefficient != null)
            {
                _SensitivityCoefficient.Background = Brushes.IndianRed;
            }
            else if (Calcul.SensitivityCoefficient >= 1.5 && Calcul.SensitivityCoefficient < 2 && _SensitivityCoefficient != null)
            {
                _SensitivityCoefficient.Background = Brushes.Yellow;
            }
            else if (Calcul.SensitivityCoefficient >= 2 && _SensitivityCoefficient != null)
            {
                _SensitivityCoefficient.Background = Brushes.LightGreen;
            }


            #endregion

            #region Уставки защиты

            if (r_PTNHigth != null)
                r_PTNHigth.Text = _PTNHigth.Text;

            if (r_PTNMedium != null)
                r_PTNMedium.Text = _PTNMedium.Text;

            if (r_PTNLower != null)
                r_PTNLower.Text = _PTNLower.Text;

            if (r_DTOTriggerSetpoint != null)
                r_DTOTriggerSetpoint.Text = _DTOTriggerSetpoint.Text;

            if (r_UnbalanceAlarmRate != null)
                r_UnbalanceAlarmRate.Text = _UnbalanceAlarmRate.Text;

            if (r_Rought_InitialCurrent != null)
                r_Rought_InitialCurrent.Text = _Rought_InitialCurrent.Text;

            if (r_Rought_SecondDecelerationCoefficient != null)
                r_Rought_SecondDecelerationCoefficient.Text = _Rought_SecondDecelerationCoefficient.Text;

            if (r_Rought_ThirdDecelerationCoefficient != null)
                r_Rought_ThirdDecelerationCoefficient.Text = _Rought_ThirdDecelerationCoefficient.Text;

            if (r_Sensitive_InitialCurrent != null)
                r_Sensitive_InitialCurrent.Text = _Sensitive_InitialCurrent.Text;

            if (r_Sensitive_SecondDecelerationCoefficient != null)
                r_Sensitive_SecondDecelerationCoefficient.Text = _Sensitive_SecondDecelerationCoefficient.Text;

            if (r_Sensitive_ThirdDecelerationCoefficient != null)
                r_Sensitive_ThirdDecelerationCoefficient.Text = _Sensitive_ThirdDecelerationCoefficient.Text;

            #endregion
        }


        internal void ShowGrafic()
        {
            var Blue = new Chart(
                new double[]
                {   
                    0,
                    0.5,
                    1.5,
                    Calcul.Rought_MaxiBrakingCurrent
                },
                new double[]
                {
                    Calcul.Rought_InitialCurrent,
                    Calcul.Rought_InitialCurrent,
                    Calcul.Rought_InitialCurrent + (1.5 - 0.5) * Calcul.Rought_SecondDecelerationCoefficient,
                    Calcul.DTOTriggerSetpoint
                },
                Brushes.Blue );

            var Green = new Chart(
                new double[]
                {
                    0,
                    0.5,
                    1.5,
                    (1.5 * Calcul.Sensitive_ThirdDecelerationCoefficient + Calcul.DTOTriggerSetpoint - (Calcul.Sensitive_InitialCurrent + (1.5 - 0.5) * Calcul.Sensitive_SecondDecelerationCoefficient)) / Calcul.Sensitive_ThirdDecelerationCoefficient
                },
                new double[]
                {
                    Calcul.Sensitive_InitialCurrent,
                    Calcul.Sensitive_InitialCurrent,
                    Calcul.Sensitive_InitialCurrent + (1.5 - 0.5) * Calcul.Sensitive_SecondDecelerationCoefficient,
                    (Calcul.Sensitive_InitialCurrent + (1.5 - 0.5) * Calcul.Sensitive_SecondDecelerationCoefficient) +  ((1.5 * Calcul.Sensitive_ThirdDecelerationCoefficient + Calcul.DTOTriggerSetpoint - (Calcul.Sensitive_InitialCurrent + (1.5 - 0.5) * Calcul.Sensitive_SecondDecelerationCoefficient))/ Calcul.Sensitive_ThirdDecelerationCoefficient - 1.5) * Calcul.Sensitive_ThirdDecelerationCoefficient
                },
                Brushes.Green );


            var Red = new Chart(
                new double[]
                {
                    0,
                    Math.Round((1.5 * Calcul.Sensitive_ThirdDecelerationCoefficient + Calcul.DTOTriggerSetpoint - (Calcul.Sensitive_InitialCurrent + (1.5 - 0.5) * Calcul.Sensitive_SecondDecelerationCoefficient)) / Calcul.Sensitive_ThirdDecelerationCoefficient, 0, MidpointRounding.ToPositiveInfinity) >
                    Math.Round((1.5 * Calcul.Rought_ThirdDecelerationCoefficient + Calcul.DTOTriggerSetpoint - (Calcul.Rought_InitialCurrent + (1.5 - 0.5) * Calcul.Rought_SecondDecelerationCoefficient)) / Calcul.Rought_ThirdDecelerationCoefficient, 0, MidpointRounding.ToPositiveInfinity) ?
                    Math.Round((1.5 * Calcul.Sensitive_ThirdDecelerationCoefficient + Calcul.DTOTriggerSetpoint - (Calcul.Sensitive_InitialCurrent + (1.5 - 0.5) * Calcul.Sensitive_SecondDecelerationCoefficient)) / Calcul.Sensitive_ThirdDecelerationCoefficient, 0, MidpointRounding.ToPositiveInfinity) :
                    Math.Round((1.5 * Calcul.Rought_ThirdDecelerationCoefficient + Calcul.DTOTriggerSetpoint - (Calcul.Rought_InitialCurrent + (1.5 - 0.5) * Calcul.Rought_SecondDecelerationCoefficient)) / Calcul.Rought_ThirdDecelerationCoefficient, 0, MidpointRounding.ToPositiveInfinity)
                },
                new double[]
                {
                    Calcul.DTOTriggerSetpoint,
                    Calcul.DTOTriggerSetpoint
                },
                Brushes.Red );


            Diagramma taskWindow = new Diagramma();
            taskWindow.Show();
            taskWindow.Drawn(Blue, Green, Red);
        }


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

        private void _BTN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(((TextBox)sender).Text, out double result))
                return;

            switch (((TextBox)sender).Name)
            {
                case "_BTN":
                    {
                        DTO.BTN = result;
                        break;
                    }
            }
            Calculing();
        }

        private void _DZTRough_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(((TextBox)sender).Text, out double result))
                return;

            switch (((TextBox)sender).Name)
            {
                case "_DZTRough":
                    {
                        DZT.DZTRough = result;
                        break;
                    }
            }
            Calculing();
        }

        private void _DZTSensitive_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(((TextBox)sender).Text, out double result))
                return;

            switch (((TextBox)sender).Name)
            {
                case "_DZTSensitive":
                    {
                        DZT.DZTSensitive = result;
                        break;
                    }
            }
            Calculing();
        }

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Calcul.round = 1;
            Calculing();
        }

        private void TextBlock_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Calcul.round = 2;
            Calculing();
        }

        private void TextBlock_PreviewMouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            Calcul.round = 3;
            Calculing();
        }

        private void TextBlock_PreviewMouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            Calcul.round = 4;
            Calculing();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShowGrafic();
        }
    }
}