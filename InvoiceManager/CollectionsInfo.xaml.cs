using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for CollectionsInfo.xaml
    /// </summary>
    public partial class CollectionsInfo : Page
    {
        public CollectionsInfo()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Options_InventoryBool.IsThreeState == true) { App.Init.tempCache.Add("InventoryOption", true); }
            else { App.Init.tempCache.Add("InventoryOption", false); }
            if (Options_TaxBool.IsThreeState == true) { App.Init.tempCache.Add("TaxOption", true); App.Init.tempCache.Add("TAX", Convert.ToDecimal("0.0" + Options_TaxVal.Text + Options_TaxVal2.Text)); }
            else { App.Init.tempCache.Add("TaxOption", false); }
            App.Init.tempCache.Add("CouponOption", Options_CouponsBool.IsChecked);
            if (Product_ParaBool.IsChecked == true)
            {
                Option p = new Option(Product_ParaN.Text, true, Product_ParaDV.Text);
                App.Init.tempCache.Add("ProductParam", p);
            }
            else
            {
                Option p = new Option("empty", false, "none");
                App.Init.tempCache.Add("ProductParam", p);
            }

            if (Service_ParaBool.IsChecked == true)
            {
                Option p = new Option(Service_ParaN.Text, true, Service_ParaDV.Text);
                App.Init.tempCache.Add("ServiceParam", p);
            }
            else
            {
                Option p = new Option("empty", false, "none");
                App.Init.tempCache.Add("ServiceParam", p);
            }
            App.MainW.Source = new Uri("CustomerInfo.xaml", UriKind.Relative);

        }

        private void Product_ParaBool_Checked(object sender, RoutedEventArgs e)
        {
            Product_ParaNLabel.IsEnabled = true;
            Product_ParaN.IsEnabled = true;
            Product_ParaDVLabel.IsEnabled = true;
            Product_ParaDV.IsEnabled = true;
            Product_ParaSearch.IsEnabled = true;
            Product_ParaNLabel.Visibility = Visibility.Visible;
            Product_ParaN.Visibility = Visibility.Visible;
            Product_ParaDVLabel.Visibility = Visibility.Visible;
            Product_ParaDV.Visibility = Visibility.Visible;
            Product_ParaSearch.Visibility = Visibility.Visible;
        }

        private void Service_ParaBool_Checked(object sender, RoutedEventArgs e)
        {
            Service_ParaNLabel.IsEnabled = true;
            Service_ParaN.IsEnabled = true;
            Service_ParaDVLabel.IsEnabled = true;
            Service_ParaDV.IsEnabled = true;
            Service_ParaSearch.IsEnabled = true;
            Service_ParaNLabel.Visibility = Visibility.Visible;
            Service_ParaN.Visibility = Visibility.Visible;
            Service_ParaDVLabel.Visibility = Visibility.Visible;
            Service_ParaDV.Visibility = Visibility.Visible;
            Service_ParaSearch.Visibility = Visibility.Visible;
        }

        private void Options_TaxBool_Checked(object sender, RoutedEventArgs e)
        {
            Options_TaxVal.IsEnabled = true;
            Options_TaxVal2.IsEnabled = true;
            Options_TaxVal.Visibility = Visibility.Visible;
            Options_TaxVal2.Visibility = Visibility.Visible;
            Options_TaxValL1.Visibility = Visibility.Visible;
            Options_TaxValL2.Visibility = Visibility.Visible;
        }

        private void Options_TaxVal_KeyDown(object sender, KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }
    }
}
