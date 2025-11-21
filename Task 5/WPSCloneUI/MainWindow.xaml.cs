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

namespace WPSCloneUI
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

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                BtnMaximize_Click(sender, e);
            }
            else
            {
                this.DragMove();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void CloseWarningBanner_Click(object sender, RoutedEventArgs e)
        {
            warningBanner.Visibility = Visibility.Collapsed;
        }
        // Zoom In
        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (zoomSlider.Value < 500)
            {
                zoomSlider.Value += 10;
            }
        }

        // Zoom Out
        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (zoomSlider.Value > 10)
            {
                zoomSlider.Value -= 10;
            }
        }

        // Zoom Slider Changed
        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (zoomPercentageText != null)
            {
                zoomPercentageText.Text = $"{(int)zoomSlider.Value}%";
            }
        }

        // Zoom Percentage Click (could open dropdown)
        private void ZoomPercentage_Click(object sender, RoutedEventArgs e)
        {
            // You can implement a dropdown menu here
            MessageBox.Show("Zoom options would appear here");
        }
    }
}