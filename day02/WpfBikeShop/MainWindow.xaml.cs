using System;
using System.Windows;
using System.Windows.Media;
using static WpfBikeShop.Car;


namespace WpfBikeShop
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitClass();
        }

        private void InitClass()
        {
            Human driver = new Human
            {
                FirstName = "Nick",
                HasDrivingLicense = true
            };

            Car car = new Car();
            car.Speed=100;
            car.color = Colors.Tomato;
            car.Driver = driver;
        }
    }
}
