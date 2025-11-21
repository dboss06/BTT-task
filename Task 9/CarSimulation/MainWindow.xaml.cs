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
using System.Windows.Threading;

namespace CarSimulation
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer carTimer;
        private double carX;
        private double carY;
        private double angle = 0;
        private int currentGear = 1;
        private int speed = 2;
        private double trackWidth;
        private double trackHeight;
        private double trackMargin = 100;
        private enum MovementState { Top, Right, Bottom, Left }
        private MovementState currentState = MovementState.Top;

        private double startX = 100;
        private double startY = 50;
        public MainWindow()
        {
            InitializeComponent();
            carTimer = new DispatcherTimer();
            carTimer.Interval = TimeSpan.FromMilliseconds(20);
            carTimer.Tick += CarTimer_Tick;

            carX = startX;
            carY = startY;

            this.Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            trackWidth = trackCanvas.ActualWidth - trackMargin * 2;
            trackHeight = trackCanvas.ActualHeight - trackMargin * 2;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            carTimer.Start();
            btnPlay.IsEnabled = false;
            btnBrake.IsEnabled = true;
            btnMove.IsEnabled = false;
        }

        private void BtnBrake_Click(object sender, RoutedEventArgs e)
        {
            carTimer.Stop();
            btnBrake.IsEnabled = false;
            btnMove.IsEnabled = true;
        }
        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            carTimer.Start();
            btnBrake.IsEnabled = true;
            btnMove.IsEnabled = false;
        }
        private void BtnLaunch_Click(object sender, RoutedEventArgs e)
        {
            carTimer.Stop();

            carX = startX;
            carY = startY;
            angle = 0;
            currentState = MovementState.Top;

            Canvas.SetLeft(car, carX);
            Canvas.SetTop(car, carY);

            car.RenderTransform = new RotateTransform(0, car.Width / 2, car.Height / 2);

            btnPlay.IsEnabled = true;
            btnBrake.IsEnabled = false;
            btnMove.IsEnabled = false;
        }

        private void Gear_Changed(object sender, RoutedEventArgs e)
        {
            if (gear1.IsChecked == true)
                currentGear = 1;
            else if (gear2.IsChecked == true)
                currentGear = 2;
            else if (gear3.IsChecked == true)
                currentGear = 3;
            else if (gear4.IsChecked == true)
                currentGear = 4;

            speed = currentGear * 2;
            speedDisplay.Text = (currentGear * 40).ToString();
        }

        private void CarTimer_Tick(object sender, EventArgs e)
        {
            switch (currentState)
            {
                case MovementState.Top:
                    carX += speed;
                    angle = 0;

                    if (carX >= trackCanvas.ActualWidth - trackMargin - car.Width)
                    {
                        currentState = MovementState.Right;
                        carX = trackCanvas.ActualWidth - trackMargin - car.Width;
                    }
                    break;
                case MovementState.Right:
                    carY += speed;
                    angle = 90;

                    if (carX >= trackCanvas.ActualHeight - trackMargin - car.Height)
                    {
                        currentState = MovementState.Bottom;
                        carX = trackCanvas.ActualHeight - trackMargin - car.Height;
                    }
                    break;
                case MovementState.Bottom:
                    carX -= speed;
                    angle = 180;

                    if (carX <= trackMargin)
                    {
                        currentState = MovementState.Left;
                        carX = trackMargin;
                    }
                    break;
                case MovementState.Left:
                    carY -= speed;
                    angle = 270;

                    if (carY <= trackMargin)
                    {
                        currentState = MovementState.Top;
                        carY = trackMargin;
                    }
                    break;
            }
            Canvas.SetLeft(car, carX);
            Canvas.SetTop(car, carY);

            car.RenderTransform = new RotateTransform(angle, car.Width / 2, car.Height / 2);
        }
    }
}