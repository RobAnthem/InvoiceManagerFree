using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Page
    {
        public NewProduct()
        {
            InitializeComponent();
            this.NP_ID.Content = App.Manager.MainCache.ProductIDRef;
            if (App.Manager.ComplexOptions.ContainsKey("ProductParam") && App.Manager.ComplexOptions["ProductParam"].Bool == true)
            {
                this.NP_OptLab.Content = App.Manager.ComplexOptions["ProductParam"].Name;
                this.NP_OptBox.Visibility = Visibility.Visible;
                this.NP_OptLab.Visibility = Visibility.Visible;
            }
        }

        private void NP_Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp.Close();
            App.MainW.MP.pp = null;
        }

        private void NP_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.NP_Name.Text) && !string.IsNullOrWhiteSpace(this.NP_Type.Text) && !string.IsNullOrWhiteSpace(this.NP_Cost.Text) && !string.IsNullOrWhiteSpace(this.NP_Cost_Copy.Text))
            {
                Dictionary<string, object> tProduct = new Dictionary<string, object>();
                if (!string.IsNullOrWhiteSpace(this.NP_NotifyAmount.Text)) { tProduct.Add("NotifyAmount", this.NP_NotifyAmount.Text); }
                if (!string.IsNullOrWhiteSpace(this.NP_OptBox.Text)) { tProduct.Add("OptionVal", this.NP_OptBox.Text); }
                tProduct.Add("Name", this.NP_Name.Text);
                tProduct.Add("Type", this.NP_Type.Text);
                tProduct.Add("Cost", Convert.ToDouble(this.NP_Cost.Text + "." + this.NP_Cost_Copy.Text));
                Products p = new Products(tProduct);
                App.MainW.MP.pp.Close();
                App.MainW.MP.pp = null;
            }
        }

        private void NP_Cost_KeyDown(object sender, KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }
    }
}
