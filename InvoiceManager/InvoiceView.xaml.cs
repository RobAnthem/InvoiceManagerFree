using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for InvoiceView.xaml
    /// </summary>
    public partial class InvoiceView : Page
    {
        public InvoiceView()
        {

            InitializeComponent();
            InvoiceViewbox.ItemsSource = App.Manager.MainCache.InvoiceCache;
            App.MainW.MP.Page_IV = this;
            if (App.Manager.Options.ContainsKey("EstimatesOption") && App.Manager.Options["EstimatesOption"] == true)
            {
                this.IV_EstOnly.Visibility = Visibility.Visible;
            }
        }
        public ObservableCollection<ListCache> _tIlist { get; set; }
        public InvoicePopup PP_IP { get; set; }
        private void IV_New_Click(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanWrite == true)
            {
                App.MainW.MP.ViewControl.SelectedIndex = 5;
                App.MainW.MP.IFrame.Source = new Uri("NewInvoice.xaml", UriKind.Relative);
            }
        }
        private void InvoiceInfo_Click(object sender, RoutedEventArgs e)
        {
            ListCache i = (ListCache)this.InvoiceViewbox.SelectedItem;
            App.VisibleInvoice = App.LoadInvoice("data/invoices/InvoiceID" + i.ID.ToString() + ".inv");
            if (this.PP_IP != null)
                this.PP_IP.Close();
            this.PP_IP = new InvoicePopup();
            this.PP_IP.Show();
            ViewPopup.IsOpen = false;
        }

        private void Remove_Invoice(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanAddPS == true)
            {
                if (InvoiceViewbox.SelectedItem != null)
                {
                    ListCache l = (ListCache)this.InvoiceViewbox.SelectedItem;
                    App.Manager.MainCache.Remove(l);
                }
            }
        }

        private void On_RightClick(object sender, MouseButtonEventArgs e)
        {
            if (InvoiceViewbox.SelectedItem != null)
            {
                ViewPopup.IsOpen = true;
            }
        }

        private void PopUpSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _tIlist = new ObservableCollection<ListCache>();
            if (!string.IsNullOrWhiteSpace(PopUpSearchBox.Text))
            {
                this.InvoiceViewbox.ItemsSource = null;
                _tIlist.Clear();
                this.InvoiceViewbox.ItemsSource = _tIlist;
                foreach (ListCache c in App.Manager.MainCache.InvoiceCache)
                {
                    if (c.Name.Contains(this.PopUpSearchBox.Text) || c.Phone.Contains(this.PopUpSearchBox.Text) || c.Date.ToString().Contains(this.PopUpSearchBox.Text))
                    {
                        _tIlist.Add(c);
                    }
                }
            }
            else
            {
                _tIlist.Clear();
                this.InvoiceViewbox.ItemsSource = App.Manager.MainCache.InvoiceCache;
            }
        }

        private void IV_EstOnly_Checked(object sender, RoutedEventArgs e)
        {
            if (this.IV_EstOnly.IsChecked == true)
            {
                _tIlist = new ObservableCollection<ListCache>();
                foreach (ListCache item in App.Manager.MainCache.InvoiceCache)
                {
                    if (item.Type == "Estimate")
                    {
                        _tIlist.Add(item);
                    }
                }
                this.InvoiceViewbox.ItemsSource = _tIlist;

            }
            if (this.IV_EstOnly.IsChecked == false)
            {
                this.InvoiceViewbox.ItemsSource = App.Manager.MainCache.InvoiceCache;
            }
        }
    }
}
