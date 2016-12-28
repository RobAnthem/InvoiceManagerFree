using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for SelectCustomer.xaml
    /// </summary>
    public partial class SelectCustomer : Page
    {
        public SelectCustomer()
        {
            InitializeComponent();
            this.PopUpSearchView.ItemsSource = App.Manager.MainCache.CustomerCache;
        }
        private void PopUpCancel_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp.Close();
            App.MainW.MP.pp = null;

        }
        public ObservableCollection<Customer> occ = new ObservableCollection<Customer>();
        private void PopUpAdd_Click(object sender, RoutedEventArgs e)
        {
            if (this.PopUpSearchView.SelectedItem != null)
            {
                App.Manager.MainCache.tempCustomer = (Customer)this.PopUpSearchView.SelectedItem;
                var pw = this.Parent as Window;
                App.MainW.MP.pp.Close();
                App.MainW.MP.pp = null;
                Customer c = App.Manager.MainCache.tempCustomer;
                string[] s = c.Name.Split(' ');
                string[] p = c.Phone.Split('-');
                App.MainW.MP.Page_NI.CustomerFirst.Text = s[0];
                if (s[1] != null) { App.MainW.MP.Page_NI.CustomerLast.Text = s[1]; }
                if (!string.IsNullOrWhiteSpace(p[0]) && !string.IsNullOrWhiteSpace(p[1]) && !string.IsNullOrWhiteSpace(p[2]) )
                {
                    App.MainW.MP.Page_NI.CustomerPhone.Text = p[0];
                    App.MainW.MP.Page_NI.CustomerPhone2.Text = p[1];
                    App.MainW.MP.Page_NI.CustomerPhone3.Text = p[2];
                }
                else
                {
                    App.MainW.MP.Page_NI.CustomerPhone.Text = "000";
                    App.MainW.MP.Page_NI.CustomerPhone2.Text = "000";
                    App.MainW.MP.Page_NI.CustomerPhone3.Text = "0000";
                }

                App.MainW.MP.Page_NI.CustomerAddress.Text = App.Manager.MainCache.tempCustomer.Address;
                App.MainW.MP.Page_NI.CustomerEmail.Text = App.Manager.MainCache.tempCustomer.Email;
            }
        }

        private void PopUpSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.PopUpSearchBox.Text != null || this.PopUpSearchBox.Text != " " || this.PopUpSearchBox.Text != "")
            {
                this.PopUpSearchView.ItemsSource = null;
                occ.Clear();
                this.PopUpSearchView.ItemsSource = occ;
                foreach (Customer c in App.Manager.MainCache.CustomerCache)
                {
                    if (c.Name.Contains(this.PopUpSearchBox.Text) || c.Phone.Contains(this.PopUpSearchBox.Text) || c.Address.Contains(this.PopUpSearchBox.Text))
                    {
                        occ.Add(c);
                    }
                }
            }
            else
            {
                this.PopUpSearchView.Items.Clear();
                occ.Clear();
                this.PopUpSearchView.ItemsSource = App.Manager.MainCache.CustomerCache;
            }

        }
    }
}
