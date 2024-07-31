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

namespace ITMO.WpfApp.Cs.Control.Calculator
{

    public partial class MainWindow : Window
    {
        private double _result;
        private string _operator;
        private bool _isNewEntry;

        

        public MainWindow()
        {
            InitializeComponent();
            _result = 0;
            _operator = string.Empty;
            _isNewEntry = false;
        }



        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (_isNewEntry)
                {
                    ResultTextBox.Text = button.Content.ToString();
                    _isNewEntry = false;
                }
                else
                {
                    ResultTextBox.Text += button.Content.ToString();
                }
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultTextBox.Text, out double number))
            {
                _result = number;
                var button = sender as Button;
                _operator = button.Content.ToString();
                _isNewEntry = true;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Clear();
            _result = 0;
            _operator = string.Empty;
            _isNewEntry = false;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultTextBox.Text, out double number))
            {
                switch (_operator)
                {
                    case "+":
                        _result += number;
                        break;
                    case "-":
                        _result -= number;
                        break;
                    case "*":
                        _result *= number;
                        break;
                    case "/":
                        if (number != 0)
                            _result /= number;
                        else
                            MessageBox.Show("Деление на ноль невозможно.");
                        break;
                    case "^": 
                        _result = Math.Pow(_result,number);
                        break;



                }
                ResultTextBox.Text = _result.ToString();
                _operator = string.Empty;
                _isNewEntry = true;



            }
            

        }

        private void RootButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(ResultTextBox.Text, out double number))
            {
                _result = Math.Sqrt(number); 
                ResultTextBox.Text = _result.ToString();
                _isNewEntry = true;
            }
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (double.TryParse(ResultTextBox.Text, out _result))
                {
                    _operator = button.Content.ToString(); 
                    _isNewEntry = true;
                }
            }
        }
    }
}
