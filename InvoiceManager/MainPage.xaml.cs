using System;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            ViewControl = this.MainControl;
            IFrame = this.NewInvoiceFrame;
            App.MainW.MP = this;
        }
        public InvoiceView Page_IV { get; set; }
        public Popup pp;
        public UserPopup upp;
        public ServiceView Page_SV { get; set; }
        public ProductView Page_PV { get; set; }
        public OptionsPage Page_OP { get; set; }
        public NewInvoice Page_NI { get; set; }
        public Frame IFrame { get; set; }
        public TabControl ViewControl { get; set; }
        private void InvTab_Loaded(object sender, RoutedEventArgs e)
        {
            this.InvoiceFrame.Source = new Uri("InvoiceView.xaml", UriKind.Relative);
        }
        private void InvTab_Unloaded(object sender, RoutedEventArgs e)
        {
            this.InvoiceFrame.Source = null;
        }
        private void Product_Loaded(object sender, RoutedEventArgs e)
        {
            this.ProductFrame.Source = new Uri("ProductView.xaml", UriKind.Relative);
        }
        private void Product_Unloaded(object sender, RoutedEventArgs e)
        {
            this.ProductFrame.Source = null;
        }
        private void Service_Loaded(object sender, RoutedEventArgs e)
        {
            this.ServiceFrame.Source = new Uri("ServiceView.xaml", UriKind.Relative);
        }
        private void Service_Unloaded(object sender, RoutedEventArgs e)
        {
            this.ServiceFrame.Source = null;
        }
        private void Customer_Loaded(object sender, RoutedEventArgs e)
        {
            this.CustomerFrame.Source = new Uri("CustomerView.xaml", UriKind.Relative);
        }
        private void Customer_Unloaded(object sender, RoutedEventArgs e)
        {
            this.CustomerFrame.Source = null;
        }

        private void NewInvoiceTab_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void NewInvoiceFrame_Unloaded(object sender, RoutedEventArgs e)
        {
            this.NewInvoiceFrame.Source = null;

        }
        private void Options_Loaded(object sender, RoutedEventArgs e)
        {
            this.OptionFrame.Source = new Uri("OptionsPage.xaml", UriKind.Relative);
        }
        private void Options_Unloaded(object sender, RoutedEventArgs e)
        {
            this.OptionFrame.Source = null;
        }
    }
}
