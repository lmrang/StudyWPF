using System.Windows.Media;

namespace WpfBikeShop
{
    public class Car : Notifier
    {
        public Car()
        {
        }
        private double speed;
        public double Speed {
            get { return speed; } 
            set
            {
                speed = value;
                OnPropertyChanged("Speed");  //스피트 속성의 값이 변경되었습니다!
            }
        }
        public Color color { get; set; }
        public Human Driver { get; set; }

        public class Human
        {
            public string FirstName { get; set; }
            public bool HasDrivingLicense { get; set; }
        }
    }
}