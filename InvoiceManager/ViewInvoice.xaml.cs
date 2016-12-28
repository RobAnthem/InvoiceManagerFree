using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for ViewInvoice.xaml
    /// </summary>
    public partial class ViewInvoice : Page
    {
        public ViewInvoice()
        {
            InitializeComponent();
            this.VI_CompanySlogan.Content = App.Manager.company.Slogan;
            this.VI_CompanyName.Content = App.Manager.company.Name;
            this.VI_CompanyAddress.Content = App.Manager.company.Address;
            this.VI_CompanyPhone.Content = App.Manager.company.Phone;
            this.LogoImage.Source = new BitmapImage(new Uri(App.Manager.company.Logo));
            this.VI_InvoiceID.Content = App.VisibleInvoice.ID;
            this.VI_Cashier.Content = App.VisibleInvoice.UserInfo.Name;
            this.VI_Type.Content = App.VisibleInvoice.Type;
            this.VI_PayType.Content = App.VisibleInvoice.Method;
            this.VI_Date.Content = App.VisibleInvoice.Date;
            string[] n = App.VisibleInvoice.CusInfo.Name.Split(' ');
            this.VI_FirstName.Content = n[0];
            this.VI_LastName.Content = n[1];
            this.VI_Phone.Content = App.VisibleInvoice.CusInfo.Phone;
            this.VI_ITax.Content = App.VisibleInvoice.Tax;
            this.VI_ITotal.Content = App.VisibleInvoice.Value;
            this.VI_Address.Content = App.VisibleInvoice.CusInfo.Address;
            this.VI_Email.Content = App.VisibleInvoice.CusInfo.Email;
            this.VI_IOption.Content = App.VisibleInvoice.Custom;
            this.VI_Custom.Content = App.VisibleInvoice.CusInfo.OptionValue;
            if (App.VisibleInvoice.Edit == true) { this.VI_Edit.Content = App.VisibleInvoice.EditDate; this.VI_Edit.Visibility = Visibility.Visible; }
            if (App.VisibleInvoice.Type == "Estimate") { this.VI_SetInvoice.Visibility = Visibility.Visible; this.VI_PayMethod.Visibility = Visibility.Visible; }
            //if (App.Manager.Options["CustomerParam"] == true) { this.VI_Custom.Content = App.VisibleInvoice.CusInfo.OptionValue;}
            this.VI_ServiceView.ItemsSource = App.VisibleInvoice.SSales;
            this.VI_ProductView.ItemsSource = App.VisibleInvoice.PSales;
            this.NI_ProductTotal.Content = App.VisibleInvoice.ProVal;
            this.NI_ServiceTotal.Content = App.VisibleInvoice.SerVal;
            if (App.Manager.ComplexOptions.ContainsKey("CustomerParam") && App.Manager.ComplexOptions["CustomerParam"].Bool == true)
            {
                this.VI_Custom.Visibility = Visibility.Visible;
                this.VI_CustomerOptionLabel.Visibility = Visibility.Visible;
                if (string.IsNullOrWhiteSpace(App.VisibleInvoice.CusInfo.OptionValue))
                {
                    this.VI_CustomerOptionLabel.Content = App.VisibleInvoice.CusInfo.OptionValue;
                }
            }
            if (App.Manager.ComplexOptions.ContainsKey("InvoiceParam") && App.Manager.ComplexOptions["InvoiceParam"].Bool == true)
            {
                this.NI_InvoiceOptionLabel.Visibility = Visibility.Visible;
                this.VI_IOption.Visibility = Visibility.Visible;
                if (string.IsNullOrWhiteSpace(App.VisibleInvoice.CusInfo.OptionValue))
                {
                    this.VI_IOption.Content = App.VisibleInvoice.Custom;
                }
            }
            if (App.Manager.Options.ContainsKey("EstimatesOption") && App.Manager.Options["EstimatesOption"] == true && App.VisibleInvoice.Type == "Estimate")
            {
                this.VI_SetInvoice.Visibility = Visibility.Visible;
                this.VI_PayMethod.Visibility = Visibility.Visible;
                this.VI_PayType.Visibility = Visibility.Hidden;
                this.UpdateButt.Visibility = Visibility.Visible;
            }
            if (App.Manager.ComplexOptions.ContainsKey("InvoiceParam") && App.Manager.ComplexOptions["InvoiceParam"].Bool == true)
            {
                this.VI_Custom.Visibility = Visibility.Visible;
                this.NI_InvoiceOptionLabel.Visibility = Visibility.Visible;
            }
        }
        private void PrintPage(object sender, RoutedEventArgs e)
        {
            PrintDialog PrintPage = new PrintDialog();
            if (PrintPage.ShowDialog() == true)
                PrintPage.PrintVisual(App.MainW.MP.Page_IV.PP_IP.IP_Frame, "Print Invoice");
        }
        private void CloseInvoice(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.Page_IV.PP_IP.WinSelf.Close();
        }

        private void UpdateInvoice(object sender, RoutedEventArgs e)
        {
            if (this.VI_SetInvoice.IsChecked == true)
            {
                if (!string.IsNullOrWhiteSpace(this.VI_PayMethod.Text))
                {
                    App.VisibleInvoice.Method = this.VI_PayMethod.Text;
                    App.VisibleInvoice.Type = "Invoice";
                    App.VisibleInvoice.Write();
                }
            }
        }
    }
}
