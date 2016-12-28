using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for CuInfo.xaml
    /// </summary>
    public partial class CuInfo : Page
    {
        public CuInfo()
        {
            InitializeComponent();
            this.CI_Header.Content = App.Manager.MainCache.tempCustomer.Name;
            this.CI_ID.Content = App.Manager.MainCache.tempCustomer.ID;
            this.CI_Phone.Content = App.Manager.MainCache.tempCustomer.Phone;
            this.CI_Address.Content = App.Manager.MainCache.tempCustomer.Address;
            this.CI_Email.Content = App.Manager.MainCache.tempCustomer.Email;
            this.CI_Notes.Content = App.Manager.MainCache.tempCustomer.Notes;
            _IList = new ObservableCollection<Invoice>();
            foreach (string s in App.Manager.MainCache.tempCustomer.CustomerInvoices)
            {
                Invoice _i = App.LoadInvoice(s);
                _IList.Add(_i);
            }
            this.CI_InvoiceView.ItemsSource = _IList;
        }
        private static ObservableCollection<Invoice> _IList { get; set; }
        private void PI_AddNoteButt_Click(object sender, RoutedEventArgs e)
        {
            App.Manager.MainCache.tempCustomer.AddNote(this.CI_NewNote.Text);
            this.CI_Notes.Content = this.CI_NewNote.Text;
        }

        private void NP_Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp.Close();
            App.MainW.MP.pp = null;
        }

        private void ShowInvoice(object sender, RoutedEventArgs e)
        {

            Invoice _i = (Invoice)this.CI_InvoiceView.SelectedItem;
            App.VisibleInvoice = _i;
            App.MainW.MP.Page_IV.PP_IP = new InvoicePopup();
            App.MainW.MP.Page_IV.PP_IP.Show();
            ViewPopup.IsOpen = false;
            App.MainW.MP.pp.Close();
            App.MainW.MP.pp = null;
        }

        private void RemoveInvoice(object sender, RoutedEventArgs e)
        {
            Invoice _tI = (Invoice)this.CI_InvoiceView.SelectedItem;
            App.Manager.MainCache.tempCustomer.CustomerInvoices.Remove("InvoiceID" + _tI.ID.ToString() + ".inv");
        }
        private void On_RightClick(object sender, RoutedEventArgs e)
        {
            if (CI_InvoiceView.SelectedItem != null)
            {
                ViewPopup.IsOpen = true;
            }
        }
    }
}
