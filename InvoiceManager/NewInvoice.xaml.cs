using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for NewInvoice.xaml
    /// </summary>
    public partial class NewInvoice : Page
    {
        public NewInvoice()
        {
            InitializeComponent();
            App.MainW.MP.Page_NI = this;
            NI_CompanyName.Content = App.Manager.company.Name;
            NI_CompanyPhone.Content = App.Manager.company.Phone;
            NI_CompanyAddress.Content = App.Manager.company.Address;
            NI_CompanySlogan.Content = App.Manager.company.Slogan;
            LogoImage.Source = new BitmapImage(new Uri(App.Manager.company.Logo));
            NI_InvoiceID.Content = App.Manager.MainCache.InvoiceIDRef;
            NI_Cashier.Content = App.Manager.ActiveUser.Name;
            CustomerFirst = this.NI_CustomerFirst;
            CustomerLast = this.NI_CustomerLast;
            CustomerAddress = this.NI_CustomerAddress;
            CustomerPhone = this.NI_CustomerPhone;
            CustomerPhone2 = this.NI_CustomerPhone2;
            CustomerPhone3 = this.NI_CustomerPhone3;
            CustomerEmail = this.NI_CustomerEmail;
            CLabel_Product = this.NI_ProductTotal;
            CLabel_Service = this.NI_ServiceTotal;
            CLabel_Tax = this.NI_ITax;
            CLabel_Total = this.NI_ITotal;
            this.NI_ProductView.ItemsSource = App.Manager.MainCache.tempProducts;
            this.NI_ServiceView.ItemsSource = App.Manager.MainCache.tempServices;
            if (App.Manager.ComplexOptions.ContainsKey("CustomerParam") && App.Manager.ComplexOptions["CustomerParam"].Bool == true)
            {
                this.NI_CustomerOption.Visibility = Visibility.Visible;
                this.NI_CustomerOptionLabel.Visibility = Visibility.Visible;
                this.NI_CustomerOptionLabel.Content = App.Manager.ComplexOptions["CustomerParam"].Name;

            }
            if (App.Manager.Options.ContainsKey("EstimatesOption") && App.Manager.Options["EstimatesOption"] == true)
            {
                this.NI_InvoiceType.IsEnabled = true;
            }
            if (App.Manager.ComplexOptions.ContainsKey("InvoiceParam") && App.Manager.ComplexOptions["InvoiceParam"].Bool == true)
            {
                this.NI_InvoiceOption.Visibility = Visibility.Visible;
                this.NI_InvoiceOptionLabel.Visibility = Visibility.Visible;
                this.NI_InvoiceOptionLabel.Content = App.Manager.ComplexOptions["CustomerParam"].Name;
            }

        }
        public TextBox CustomerFirst { get; set; }
        public TextBox CustomerLast { get; set; }
        public TextBox CustomerAddress { get; set; }
        public TextBox CustomerPhone { get; set; }
        public TextBox CustomerPhone2 { get; set; }
        public TextBox CustomerPhone3 { get; set; }
        public TextBox CustomerEmail { get; set; }
        public Label CLabel_Service { get; set; }
        public Label CLabel_Product { get; set; }
        public Label CLabel_Total { get; set; }
        public Label CLabel_Tax { get; set; }
        public double TotalCost { get; set; }
        public double TaxCost { get; set; }
        public double ProCost { get; set; }
        public double SerCost { get; set; }
        public double ServiceCost { get; set; }
        public double ProductCost { get; set; }
        private void NI_Button_ProductAdd_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp = new Popup("FindProduct.xaml");
            App.MainW.MP.pp.Show();
        }
        private void NI_Button_AddCustomer_Copy_Click(object sender, RoutedEventArgs e)
        {
            {
                bool _check = true;
                Dictionary<string, object> _tCache = new Dictionary<string, object>();
                if (string.IsNullOrWhiteSpace(NI_InvoiceType.Text)) { _tCache.Add("Type", "Invoice"); }
                else { _tCache.Add("Type", NI_InvoiceType.Text.ToString()); }
                if (App.Manager.ComplexOptions.ContainsKey("InvoiceOption"))
                {
                    if (App.Manager.ComplexOptions["InvoiceOption"].Bool == true)
                    {
                        _tCache.Add(App.Manager.ComplexOptions["InvoiceOption"].Name, NI_InvoiceOption.Text);
                    }
                }

                _tCache.Add("Value", TotalCost);
                _tCache.Add("ProductVal", ProductCost);
                _tCache.Add("ServiceVal", ServiceCost);
                _tCache.Add("Tax", TaxCost);
                _tCache.Add("Method", NI_PayMethod.Text);
                if (App.Manager.ComplexOptions.ContainsKey("InvoiceParam") && App.Manager.ComplexOptions["InvoiceParam"].Bool == true 
                    && !string.IsNullOrWhiteSpace(this.NI_InvoiceOption.Text))
                {
                    _tCache.Add("OptionVal", this.NI_InvoiceOption.Text);
                }
                if (App.Manager.MainCache.tempCustomer == null || !App.Manager.MainCache.tempCustomer.Name.Contains(NI_CustomerFirst.Text + " " + NI_CustomerLast.Text))
                {
                    Dictionary<string, object> cCache = new Dictionary<string, object>();
                    cCache.Add("Name", NI_CustomerFirst.Text + " " + NI_CustomerLast.Text);
                    cCache.Add("Address", NI_CustomerAddress.Text);
                    cCache.Add("Phone", NI_CustomerPhone.Text + "-" + NI_CustomerPhone2.Text + "-" + NI_CustomerPhone3.Text);
                    cCache.Add("Email", NI_CustomerEmail.Text);
                    App.Manager.MainCache.tempCustomer = new Customer(cCache);
                    if (App.Manager.ComplexOptions.ContainsKey("CustomerParam") && App.Manager.ComplexOptions["CustomerParam"].Bool == true
                        && !string.IsNullOrWhiteSpace(this.NI_CustomerOption.Text))
                    {
                        cCache.Add("OptionVal", this.NI_CustomerOption.Text);
                    }
                }
                if (App.Manager.MainCache.tempCustomer == null || App.Manager.MainCache.tempProducts.Count < 1 && App.Manager.MainCache.tempProducts.Count < 1) { _check = false; }
                if (_check == true)
                {
                    Invoice x = new Invoice(_tCache);
                    App.MainW.MP.ViewControl.SelectedIndex = 0;
                }
                else { this.ViewPopup.IsOpen = true; }
            }
        }
        private void NI_Button_AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp = new Popup("SelectCustomer.xaml");
            App.MainW.MP.pp.Show();
        }
        private void NI_Button_ServiceAdd_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp = new Popup("FindService.xaml");
            App.MainW.MP.pp.Show();
        }
        private void NI_Button_ProductRemove_Click(object sender, RoutedEventArgs e)
        {
            App.Manager.MainCache.tempProducts.Remove((Products)this.NI_ProductView.SelectedItem);
        }
        private void NI_Button_ServiceRemove_Click(object sender, RoutedEventArgs e)
        {
            App.Manager.MainCache.tempServices.Remove((Service)this.NI_ServiceView.SelectedItem);

        }
        private void NI_Button_ServiceChange_Copy_Click(object sender, RoutedEventArgs e)
        {
            Products _x = (Products)this.NI_ProductView.SelectedItem;
            Products _y = (Products)_x.Clone();
            _y.Count = Convert.ToInt32(this.NI_ProductQuantity.Text);
            App.Manager.MainCache.tempProducts.Remove(_x);
            App.Manager.MainCache.tempProducts.Add(_y);
            this.CountTotals();

        }
        private void NI_Button_ServiceChange_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Service _x = (Service)this.NI_ServiceView.SelectedItem;
            Service _y = (Service)_x.Clone();
            _y.Count = Convert.ToInt32(this.NI_ServiceQuantity.Text);
            App.Manager.MainCache.tempServices.Remove(_x);
            App.Manager.MainCache.tempServices.Add(_y);
            this.CountTotals();

        }
        public void CountTotals()
        {
            double _tDub = new double();
            double _tDub2 = new double();
            double _tTax = new double();
            foreach (Products _pr in App.Manager.MainCache.tempProducts)
            {
                _tDub = _tDub + (_pr.Cost * _pr.Count);
                _tTax = _tTax + (_pr.Cost * _pr.Count * App.Manager.company.Tax);
            }
            foreach (Service _sr in App.Manager.MainCache.tempServices)
            {
                _tDub2 = _tDub2 + (_sr.Cost * _sr.Count);
            }
            _tTax = Math.Round(_tTax, 2, MidpointRounding.AwayFromZero);
            this.ServiceCost = Math.Round(_tDub2, 2, MidpointRounding.AwayFromZero);
            this.CLabel_Service.Content = ServiceCost;
            this.ProductCost = Math.Round(_tDub, 2, MidpointRounding.AwayFromZero);
            this.CLabel_Product.Content = ProductCost;
            this.TotalCost = Math.Round(_tDub + _tDub2 + _tTax, 2, MidpointRounding.AwayFromZero);
            this.CLabel_Total.Content = TotalCost;
            this.TaxCost = _tTax;
            this.CLabel_Tax.Content = _tTax;

        }

        private void NI_CustomerPhone_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }
    }
}
