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
        // variables to save input values
        Double numberOne ;
        Double numberTwo ;
        Double result ;
        string operatorInput = null;

        // use a state machine model that contains 3 states
        string state = "numberInputting";

        //string[] states = {"numberInputting", "operatorInputted", "calculated" };
        //string[] operatorOptions = {"+", "-", "×", "÷" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ce_click(object sender, RoutedEventArgs e)
        {
            // clear the textBox2 and show 0
            textBox_Result.Clear();
            textBox_Result.Text = "0";
        }

        private void c_click(object sender, RoutedEventArgs e)
        {
            textBox_Result.Clear();
            textBox_Result.Text = "0";
            history_Record.Clear();
            // initialize all the variables
            numberTwo = 0.0;
            numberOne = 0.0;
            result = 0.0;
            operatorInput = null;
            state = "numberInputting";
        }

        private void neg_click(object sender, RoutedEventArgs e)
        {
            // -/+ convert
            if (textBox_Result.Text.Contains("-"))
            {
                textBox_Result.Text = textBox_Result.Text.Substring(1);
            }
            else
            {
                // 0 cannot be negative
                if (textBox_Result.Text != "0")
                {
                    textBox_Result.Text = "-" + textBox_Result.Text;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (state)
            {
                case "operatorInputted":
                    // start to input numberTwo after the input of operators
                    textBox_Result.Clear();
                    state = "numberInputting";
                    break;
                case "calculated":
                    // one calculation completed
                    c_click(sender, e);
                    break;
                default:
                    break;
            }
            input_number(button);
        }

        private void input_number(Button button)
        {
            if (textBox_Result.Text == "0" && (string)button.Content != ".")
            {
                textBox_Result.Clear();
            }
            // dot de-duplication
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
            Button button = (Button)sender;
            switch (state)
            {
                case "numberInputting":
                    // numberOne inputted
                    if (operatorInput == null)
                    {
                        numberOne = Double.Parse(textBox_Result.Text);
                        history_Record.Text = numberOne.ToString() + (string)button.Content;
                        state = "operatorInputted";
                    }
                    // numberTwo inputted
                    else
                    {
                        numberTwo = Double.Parse(textBox_Result.Text);
                        calculate();
                        textBox_Result.Text = result.ToString();
                        numberOne = result;

                        history_Record.Text = numberOne.ToString() + (string)button.Content;
                        state = "calculated";
                    }
                    break;
                // multiple operator input
                case "operatorInputted":
                    history_Record.Text = numberOne.ToString() + (string)button.Content;
                    state = "operatorInputted";
                    break;
                case "calculated":
                    textBox_Result.Text = result.ToString();
                    history_Record.Text = numberOne.ToString() + (string)button.Content;
                    state = "operatorInputted";
                    break;
                default:
                    break;
            }
            operatorInput = (string)button.Content;
        }

        private void calculate_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (state)
            {
                case "numberInputting":
                    // end with numberTwo
                    if (operatorInput != null)
                    {
                        numberTwo = Double.Parse(textBox_Result.Text);
                        history_Record.Text = numberOne.ToString() + operatorInput + numberTwo.ToString() + "=";
                        calculate();
                        textBox_Result.Text = result.ToString();
                        numberOne = result;
                        state = "calculated";
                    }
                    // end with numberOne
                    else
                    {
                        numberOne = Double.Parse(textBox_Result.Text);
                        history_Record.Text = numberOne.ToString() + "=";
                        state = "calculated";
                    }                    
                    break;
                case "operatorInputted":
                    // "=" make numberTwo as numberOne, and calculate
                    numberOne = Double.Parse(textBox_Result.Text);
                    numberTwo = numberOne;
                    calculate();
                    textBox_Result.Text = result.ToString();
                    history_Record.Text = numberOne.ToString() + operatorInput + numberTwo.ToString() + "=";
                    numberOne = result;
                    state = "calculated";
                    break;
                case "calculated":
                    calculate();
                    numberOne = result;
                    textBox_Result.Text = result.ToString();
                    history_Record.Text = numberOne.ToString() + operatorInput + numberTwo.ToString() + "=";
                    
                    break;
                default:
                    break;
            }
            // after calculation, numberOne equals result, numberTwo is unchanged.
            }

        private void calculate()
        {
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
                default:
                    break;
            }
            
        }

        private void del_click(object sender, RoutedEventArgs e)
        {
            if (textBox_Result.Text.Length == 1)
            {
                textBox_Result.Text = "0";
            }
            else if (textBox_Result.Text.Length > 1 && textBox_Result.Text != "0")
            {
                textBox_Result.Text = textBox_Result.Text.Remove(textBox_Result.Text.Length - 1);
            }
        }
    }
}
