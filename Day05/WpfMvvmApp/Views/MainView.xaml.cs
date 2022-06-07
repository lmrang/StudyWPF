using MahApps.Metro.Controls;
using WpfMvvmApp.ViewModels;

namespace WpfMvvmApp
{
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}
