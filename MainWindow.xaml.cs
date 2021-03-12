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

namespace calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Double numberOne = 0.0;
        Double numberTwo = 0.0;
        //Double inputingNumber = 0.0;
        Double result = 0.0;
        string operatorInput = "";
        bool isCalculationPerformed = false;
        bool NumberInputed = false;
        string[] opts = { "+", "-", "×", "÷" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ce_click(object sender, RoutedEventArgs e)
        {
            // 仅归零textBox2
            textBox_Result.Clear();
            textBox_Result.Text = "0";
        }

        private void c_click(object sender, RoutedEventArgs e)
        {
            textBox_Result.Clear();
            textBox_Result.Text = "0";
            history_Record.Clear();
            // 初始化其余变量
            numberTwo = 0.0;
            numberOne = 0.0;
            result = 0.0;
            operatorInput = "";
            isCalculationPerformed = false;
            NumberInputed = false;
        }

        private void neg_click(object sender, RoutedEventArgs e)
        {
            if (textBox_Result.Text.Contains("-"))
            {
                textBox_Result.Text = textBox_Result.Text.Substring(1);
            }
            else
            {
                if (textBox_Result.Text != "0")
                {
                    textBox_Result.Text = "-" + textBox_Result.Text;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            // 一次计算完成后，初始化
            if (isCalculationPerformed)
            {
                c_click(sender, e);
            }

            // 当已有运算符但未执行计算时，输入第二个数时需要清空textbox2
            if (operatorInput != "" && NumberInputed == false)
            {
                textBox_Result.Clear();
                NumberInputed = true;
            }

            // 整数第一位不能为0，小数可以
            if (textBox_Result.Text == "0" && (string)button.Content != ".")
            {
                textBox_Result.Clear();
            }

            // dot deduplication
            if ((string)button.Content == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                {
                    textBox_Result.Text += (string)button.Content;
                }
            }
            else
            {
                textBox_Result.Text += (string)button.Content;
            }
        }


        private void operator_click(object sender, RoutedEventArgs e)
        {
            if (history_Record.Text.Length > 0 && opts.Contains(history_Record.Text.Substring(history_Record.Text.Length-1)) && !NumberInputed)
            {
                
                return;
            }
            else if (operatorInput != "")
            {
                if (!isCalculationPerformed)
                {
                    numberTwo = Double.Parse(textBox_Result.Text);

                    // 执行2数的计算
                    switch (operatorInput)
                    {
                        case "+":
                            result = numberOne + numberTwo;
                            break;
                        case "-":
                            result = numberOne - numberTwo;
                            break;
                        case "×":
                            result = numberOne * numberTwo;
                            break;
                        case "÷":
                            result = numberOne / numberTwo;
                            break;
                    }
                    operatorInput = "";
                }
                textBox_Result.Text = result.ToString();
                // isCalculationPerformed = true;
                NumberInputed = false;
                numberTwo = 0.0;
            }

            // 输入运算符时，生成第一个number
            numberOne = Double.Parse(textBox_Result.Text);
            // 记录运算符，并在history中加入运算符的显示
            Button button = (Button)sender;
            operatorInput = (string)button.Content;
            history_Record.Text = numberOne + operatorInput;
            isCalculationPerformed = false;
        }

        private void calculate_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            // 未输入operator就计算
            if (operatorInput == "")
            {
                history_Record.Text = textBox_Result.Text + "=";
                isCalculationPerformed = true;
            }
            else
            {
                // 点击=时生成第二个数
                if (!history_Record.Text.Contains("="))
                {
                    numberTwo = Double.Parse(textBox_Result.Text);
                }
                // 执行2数的计算
                switch (operatorInput)
                {
                    case "+":
                        result = numberOne + numberTwo;
                        break;
                    case "-":
                        result = numberOne - numberTwo;
                        break;
                    case "×":
                        result = numberOne * numberTwo;
                        break;
                    case "÷":
                        result = numberOne / numberTwo;
                        break;
                }
                textBox_Result.Text = result.ToString();
                // 一次计算后清空参数，numberOne存储上一次计算的结果
                history_Record.Text = numberOne.ToString() + operatorInput + numberTwo.ToString() + "=";
                numberOne = result;
                isCalculationPerformed = true;
                // = 去重
                if (!history_Record.Text.Contains("="))
                {
                    history_Record.Text = numberOne.ToString() + operatorInput + numberTwo.ToString() + "=";
                }
            }
        }
    }
}
