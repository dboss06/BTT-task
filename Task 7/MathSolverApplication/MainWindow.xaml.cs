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

namespace MathSolverApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateQuadratic(object sender, RoutedEventArgs e)
        {
            try {
                double a = Double.Parse(txtA.Text);
                double b = Double.Parse(txtB.Text);
                double c = Double.Parse(txtC.Text);

                if (a == 0)
                {
                    txtQuadResult.Text = "Error: 'a' cannot be zero in a quadratic equation.";
                    return;
                }

                double discriminant = (Math.Pow(b, 2)) - (4 * a * c);

                if (discriminant > 0)
                {
                    double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

                    txtQuadResult.Text = $"Two Real Roots:\n\n" + $"x1 = {x1:F4}\n" + $"x2 = {x2:F4}\n\n" + $"Discriminant = {discriminant:F4}";
                }
                else if (discriminant == 0)
                {
                    double x = -b / (2 * a);

                    txtQuadResult.Text = $"One Real Root:\n\n" + $"x = {x:F4}\n\n" + $"Discriminant = {discriminant:F4}";

                }
                else
                {
                    double realPart = -b / (2 * a);
                    double imaginaryPart = Math.Sqrt(discriminant) / (2 * a);

                    txtQuadResult.Text = $"Two Complex Roots:\n\n" + $"x₁ = {realPart:F4} + {imaginaryPart:F4}i\n" + $"x₂ = {realPart:F4} - {imaginaryPart:F4}i\n\n" + $"Discriminant = {discriminant:F4}";

                }

            }
            catch(FormatException)
            {
                txtQuadResult.Text = "Error: Please enter valid numeric values for a, b, and c.";
            }
            catch(Exception ex)
            {
                txtQuadResult.Text = $"Error: {ex.Message}";
            }
        }
        private void CalculateArea(object sender, RoutedEventArgs e)
        {
            try
            {
                double r = Double.Parse(txtR.Text);
                double pi = Math.PI;

                if (r < 0)
                {
                    txtAreaResult.Text = "Error: Radius cannot be negative.";
                    return;
                }

                double Area = pi * Math.Pow(r, 2);

                txtAreaResult.Text = $"The area of a circle with radius {r:F2} is:\n\n" + $"Area = {Area:F4} square units";

            }
            catch (FormatException)
            {
                txtAreaResult.Text = "Error: Please enter valid numeric values for radius r.";
            }
            catch (Exception ex)
            {
                txtAreaResult.Text = $"Error: {ex.Message}";
            }
        }
        private void CalculatePythagoras(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = Double.Parse(txta.Text);
                double b = Double.Parse(txtb.Text);


                double csquared = (Math.Pow(a, 2)) + (Math.Pow(b, 2));
                double c = Math.Sqrt(csquared);


                txtPythagorasResult.Text = $"C² is {csquared} and C is {c}";

            }
            catch (FormatException)
            {
                txtPythagorasResult.Text = "Error: Please enter valid numeric values for a² and b²";
            }
            catch (Exception ex)
            {
                txtPythagorasResult.Text = $"Error: {ex.Message}";
            }
        }
    }
}