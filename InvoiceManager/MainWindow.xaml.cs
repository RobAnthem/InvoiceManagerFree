using System.Windows.Navigation;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainPage MP;
        public MainWindow()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
            App.MainW = this;
        }


    }
}
