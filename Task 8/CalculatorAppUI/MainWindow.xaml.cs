using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _firstNumber = 0;
        private string _operator = "";
        private bool _isNewEntry = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string buttonText = button.Content.ToString();

            if (DisplayTextBox.Text == "0" || _isNewEntry)
            {
                DisplayTextBox.Text = buttonText;
                _isNewEntry = false;
            }
            else
            {
                DisplayTextBox.Text += buttonText;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            _operator = button.Content.ToString();
            _firstNumber = double.Parse(DisplayTextBox.Text);
            _isNewEntry = true;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e) {
            double secondNumber;
            double result = 0;

            try
            {
                secondNumber = double.Parse(DisplayTextBox.Text);
                switch (_operator)
                {
                    case "+":
                        result = _firstNumber + secondNumber;
                        break;
                    case "-":
                        result = _firstNumber - secondNumber;
                        break;
                    case "*":
                        result = _firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            DisplayTextBox.Text = "Cannot Divide by 0";
                        }
                        result = _firstNumber / secondNumber;
                        break;
                }
                DisplayTextBox.Text = result.ToString();
                _isNewEntry = true;
            }
            catch
            {
                DisplayTextBox.Text = "Error";
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            DisplayTextBox.Text = "0";
            _firstNumber = 0;
            _operator = "";
            _isNewEntry = false;
        }
        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (DisplayTextBox.Text.Length > 0 && DisplayTextBox.Text != "0")
            {
                DisplayTextBox.Text = DisplayTextBox.Text.Substring(0,DisplayTextBox.Text.Length - 1);
                if(DisplayTextBox.Text.Length == 0)
                {
                    DisplayTextBox.Text = "0";
                }
            }
        }
        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value = double.Parse(DisplayTextBox.Text);
                value /= 100;
                DisplayTextBox.Text = value.ToString();
            }
            catch
            {
                DisplayTextBox.Text = "Error";
            }
        }
        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value = double.Parse(DisplayTextBox.Text);
                value *= -1;
                DisplayTextBox.Text = value.ToString();
            }
            catch
            {
                DisplayTextBox.Text = "Error";
            }
        }
    }

    
}