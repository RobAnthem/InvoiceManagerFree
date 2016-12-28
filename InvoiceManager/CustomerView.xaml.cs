using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Page
    {
        public CustomerView()
        {
            InitializeComponent();
            this.CustomerViewBox.ItemsSource = App.Manager.MainCache.CustomerCache;
        }
        public ObservableCollection<Customer> tClist { get; set; }
        private void PV_Button_Add(object sender, RoutedEventArgs e)
        {

        }
        private void On_RightClick(object sender, RoutedEventArgs e)
        {
            if (CustomerViewBox.SelectedItem != null)
            {
                this.ViewPopup.IsOpen = true;
            }
        }

        private void CustomerInfo_Click(object sender, RoutedEventArgs e)
        {
            Customer c = (Customer)CustomerViewBox.SelectedItem;
            App.Manager.MainCache.tempCustomer = c;
            App.MainW.MP.pp = new Popup("CuInfo.xaml");
            App.MainW.MP.pp.Show();
            ViewPopup.IsOpen = false;

        }

        private void CustomerRemove_Click(object sender, RoutedEventArgs e)
        {

            if (CustomerViewBox.SelectedItem != null)
            {
                App.Manager.MainCache.Remove(CustomerViewBox.SelectedItem);
                ViewPopup.IsOpen = false;

            }
        }

        private void PopUpSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tClist = new ObservableCollection<Customer>();
            if (!string.IsNullOrWhiteSpace(PopUpSearchBox.Text))
            {
                this.CustomerViewBox.ItemsSource = null;
                tClist.Clear();
                this.CustomerViewBox.ItemsSource = tClist;
                foreach (Customer c in App.Manager.MainCache.CustomerCache)
                {
                    if (c.Name.Contains(this.PopUpSearchBox.Text) || c.Phone.Contains(this.PopUpSearchBox.Text) || c.Address.Contains(this.PopUpSearchBox.Text))
                    {
                        tClist.Add(c);
                    }
                }
            }
            else
            {
                tClist.Clear();
                this.CustomerViewBox.ItemsSource = App.Manager.MainCache.CustomerCache;
            }
        }
    }
}
