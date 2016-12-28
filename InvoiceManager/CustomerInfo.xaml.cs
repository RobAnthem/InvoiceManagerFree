using System;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for CustomerInfo.xaml
    /// </summary>
    public partial class CustomerInfo : Page
    {
        public CustomerInfo()
        {
            InitializeComponent();
        }

        private void Invoice_ParaBool_Checked(object sender, RoutedEventArgs e)
        {
            Invoice_ParaNLabel.IsEnabled = true;
            Invoice_ParaN.IsEnabled = true;
            Invoice_ParaDVLabel.IsEnabled = true;
            Invoice_ParaDV.IsEnabled = true;
            Invoice_ParaSearch.IsEnabled = true;
            Invoice_ParaNLabel.Visibility = Visibility.Visible;
            Invoice_ParaN.Visibility = Visibility.Visible;
            Invoice_ParaDVLabel.Visibility = Visibility.Visible;
            Invoice_ParaDV.Visibility = Visibility.Visible;
            Invoice_ParaSearch.Visibility = Visibility.Visible;
        }

        private void Customer_ParaBool_Checked(object sender, RoutedEventArgs e)
        {
            Customer_ParaNLabel.IsEnabled = true;
            Customer_ParaN.IsEnabled = true;
            Customer_ParaDVLabel.IsEnabled = true;
            Customer_ParaDV.IsEnabled = true;
            Customer_ParaSearch.IsEnabled = true;
            Customer_ParaNLabel.Visibility = Visibility.Visible;
            Customer_ParaN.Visibility = Visibility.Visible;
            Customer_ParaDVLabel.Visibility = Visibility.Visible;
            Customer_ParaDV.Visibility = Visibility.Visible;
            Customer_ParaSearch.Visibility = Visibility.Visible;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Options_Optin.IsThreeState == true) { App.Init.tempCache.Add("Optin_Option", true); }
            else { App.Init.tempCache.Add("Optin_Option", false); }
            if (Options_Discount.IsThreeState == true) { App.Init.tempCache.Add("DiscountOption", true); }
            else { App.Init.tempCache.Add("DiscountOption", false); }
            if (Options_Estimates.IsThreeState == true) { App.Init.tempCache.Add("EstimatesOption", true); }
            else { App.Init.tempCache.Add("EstimatesOption", false); }
            if (Customer_ParaBool.IsChecked == true)
            {
                Option p = new Option(Customer_ParaN.Text, true, Customer_ParaDV.Text);
                App.Init.tempCache.Add("CustomerParam", p);
            }
            else
            {
                Option p = new Option("empty", false, "none");
                App.Init.tempCache.Add("CustomerParam", p);
            }
            if (Invoice_ParaBool.IsChecked == true)
            {
                Option p = new Option(Invoice_ParaN.Text, true, Invoice_ParaDV.Text);
                App.Init.tempCache.Add("InvoiceParam", p);
            }
            else
            {
                Option p = new Option("empty", false, "none");
                App.Init.tempCache.Add("InvoiceParam", p);
            }
            Company c = new Company(App.Init.tempCache);
            App.Manager = new Setup(c);
            App.Manager.ActiveUser = App.Manager.company.Owner;
            App.MainW.Source = new Uri("MainPage.xaml", UriKind.Relative);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
