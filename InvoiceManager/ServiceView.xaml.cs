using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for ServiceView.xaml
    /// </summary>
    public partial class ServiceView : Page
    {
        public ServiceView()
        {
            InitializeComponent();
            this.ServiceViewBox.ItemsSource = App.Manager.MainCache.ServiceCache;

        }
        public ObservableCollection<Service> tSlist { get; set; }

        private void PV_Button_Add(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanAddPS == true)
            {
                App.MainW.MP.pp = new Popup("NewService.xaml");
                App.MainW.MP.pp.Show();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp = new Popup("ServiceInfo.xaml", (Service)this.ServiceViewBox.SelectedItem);
            App.MainW.MP.pp.Show();
            this.ViewPopup.IsOpen = false;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanDeletelPS == true)
            {
                App.Manager.MainCache.Remove((Service)this.ServiceViewBox.SelectedItem);
                this.ViewPopup.IsOpen = false;
            }
        }
        private void ServiceView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ServiceViewBox.SelectedItem != null) {ViewPopup.IsOpen = true; }
        }

        private void PopUpSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.tSlist = new ObservableCollection<Service>();
            if (!string.IsNullOrWhiteSpace(PopUpSearchBox.Text))
            {
                this.ServiceViewBox.ItemsSource = null;
                this.tSlist.Clear();
                this.ServiceViewBox.ItemsSource = this.tSlist;
                foreach (Service _c in App.Manager.MainCache.ServiceCache)
                {
                    if (_c.Name.Contains(this.PopUpSearchBox.Text) || _c.Type.Contains(this.PopUpSearchBox.Text))
                    {
                        this.tSlist.Add(_c);
                    }
                }
            }
            else
            {
                this.tSlist.Clear();
                this.ServiceViewBox.ItemsSource = App.Manager.MainCache.ServiceCache;
            }
        }
    }
}
