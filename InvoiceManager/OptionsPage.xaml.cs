using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        public OptionsPage()
        {
            InitializeComponent();
            App.MainW.MP.Page_OP = this;
            if (App.Manager.ComplexOptions.ContainsKey("CustomerParam"))
            {
                this.Customer_Add.IsChecked = App.Manager.ComplexOptions["CustomerParam"].Bool;
                this.Customer_AddP.Text = App.Manager.ComplexOptions["CustomerParam"].Name;
                this.Customer_AddD.Text = App.Manager.ComplexOptions["CustomerParam"].Info;
            }
            if (App.Manager.ComplexOptions.ContainsKey("ProductParam"))
            {
                this.Product_Add.IsChecked = App.Manager.ComplexOptions["Productaram"].Bool;
                this.Product_AddP.Text = App.Manager.ComplexOptions["ProductParam"].Name;
                this.Product_AddD.Text = App.Manager.ComplexOptions["ProductParam"].Info;
            }
            if (App.Manager.ComplexOptions.ContainsKey("ServiceParam"))
            {
                this.Service_Add.IsChecked = App.Manager.ComplexOptions["ServiceParam"].Bool;
                this.Service_AddP.Text = App.Manager.ComplexOptions["ServiceParam"].Name;
                this.Service_AddD.Text = App.Manager.ComplexOptions["ServiceParam"].Info;
            }
            if (App.Manager.ComplexOptions.ContainsKey("InvoiceParam"))
            {
                this.Invoice_Add.IsChecked = App.Manager.ComplexOptions["InvoiceParam"].Bool;
                this.Invoice_AddP.Text = App.Manager.ComplexOptions["InvoiceParam"].Name;
                this.Invoice_AddD.Text = App.Manager.ComplexOptions["InvoiceParam"].Info;
            }
            if (App.Manager.company.Tax < 0.00)
            {
                this.Product_Tax.IsChecked = true;
                int[] s = App.Manager.company.Tax.Split();
                this.Product_TV1.Text = s[0].ToString();
                if (s[1] < 0) { s[1] = 0; }
                this.Invoice_AddD.Text = s[1].ToString();
            }
            if (App.Manager.Options.ContainsKey("Receipt") && App.Manager.Options["Receipt"] == true)
            {
                this.Invoice_Email.IsChecked = true;

            }
            if (App.Manager.Options.ContainsKey("InventoryOption") && App.Manager.Options["InventoryOption"] == true)
            {
                this.Product_Low.IsChecked = true;

            }
            if (App.Manager.Options.ContainsKey("EstimatesOption") && App.Manager.Options["EstimatesOption"] == true)
            {
                this.Invoice_Estim.IsChecked = true;
            }
            if (App.Manager.Options.ContainsKey("CouponOption") && App.Manager.Options["CouponOption"] == true)
            {
                this.Invoice_Cpn.IsChecked = true;
            }
        }
        private void NI_Button_AddCustomer_Copy_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.Source = new Uri("Splash.xaml", UriKind.Relative);

        }

        private void NI_Button_AddCustomer_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanExit == true)
            {
                App.Manager.Save();
                Application.Current.Shutdown();
            }
        }

        private void NI_Button_AddCustomer_Copy3_Click(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanOptions == true)
            {
                App.Manager.Backup();
            }
        }

        private void NI_Button_AddCustomer_Copy4_Click(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanOptions == true)
            {
                App.Manager.Restore();
            }
        }

        private void Options_Apply_Click(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanOptions == true)
            {
                if (this.Customer_Add.IsChecked == true && !string.IsNullOrWhiteSpace(this.Customer_AddP.Text) && !string.IsNullOrWhiteSpace(this.Customer_AddD.Text))
                {
                    if (App.Manager.ComplexOptions.ContainsKey("CustomerParam"))
                    {
                        App.Manager.ComplexOptions["CustomerParam"].OptionToggle();
                        App.Manager.ComplexOptions["CustomerParam"].ChangeName(this.Customer_AddP.Text);
                        App.Manager.ComplexOptions["CustomerParam"].Edit(this.Customer_AddD.Text);
                    }
                    else
                    {
                        App.Manager.ComplexOptions.Add("CustomerParam", new Option(this.Customer_AddP.Text, true, this.Customer_AddD.Text));
                    }
                }
                if (this.Product_Add.IsChecked == true && !string.IsNullOrWhiteSpace(this.Product_AddP.Text) && !string.IsNullOrWhiteSpace(this.Product_AddD.Text))
                {
                    if (App.Manager.ComplexOptions.ContainsKey("ProductParam"))
                    {
                        App.Manager.ComplexOptions["ProductParam"].OptionToggle();
                        App.Manager.ComplexOptions["ProductParam"].ChangeName(this.Product_AddP.Text);
                        App.Manager.ComplexOptions["ProductParam"].Edit(this.Product_AddD.Text);
                    }
                    else
                    {
                        App.Manager.ComplexOptions.Add("ProductParam", new Option(this.Product_AddP.Text, true, this.Product_AddD.Text));
                    }
                }
                if (this.Service_Add.IsChecked == true && !string.IsNullOrWhiteSpace(this.Service_AddP.Text) && !string.IsNullOrWhiteSpace(this.Service_AddD.Text))
                {
                    if (App.Manager.ComplexOptions.ContainsKey("ServiceParam"))
                    {
                        App.Manager.ComplexOptions["ServiceParam"].OptionToggle();
                        App.Manager.ComplexOptions["ServiceParam"].ChangeName(this.Service_AddP.Text);
                        App.Manager.ComplexOptions["ServiceParam"].Edit(this.Service_AddD.Text);
                    }
                    else
                    {
                        App.Manager.ComplexOptions.Add("ServiceParam", new Option(this.Service_AddP.Text, true, this.Service_AddD.Text));
                    }
                }
                if (this.Invoice_Add.IsChecked == true && !string.IsNullOrWhiteSpace(this.Invoice_AddP.Text) && !string.IsNullOrWhiteSpace(this.Invoice_AddD.Text))
                {
                    if (App.Manager.ComplexOptions.ContainsKey("InvoiceParam"))
                    {
                        App.Manager.ComplexOptions["InvoiceParam"].OptionToggle();
                        App.Manager.ComplexOptions["InvoiceParam"].ChangeName(this.Invoice_AddP.Text);
                        App.Manager.ComplexOptions["InvoiceParam"].Edit(this.Invoice_AddD.Text);
                    }
                    else
                    {
                        App.Manager.ComplexOptions.Add("InvoiceParam", new Option(this.Invoice_AddP.Text, true, this.Invoice_AddD.Text));
                    }
                }
                if (this.Product_Low.IsChecked == true)
                {
                    if (App.Manager.Options.ContainsKey("InventoryOption"))
                    {
                        App.Manager.Options["InventoryOption"] = true;
                    }
                    else
                    {
                        App.Manager.Options.Add("InventoryOption", true);
                    }
                }
                if (this.Product_Tax.IsChecked == true && !string.IsNullOrWhiteSpace(this.Product_TV1.Text) && !string.IsNullOrWhiteSpace(this.Product_TV2.Text))
                {
                    if (App.Manager.Options.ContainsKey("TaxOption"))
                    {
                        App.Manager.Options["TaxOption"] = true;
                        App.Manager.company.Tax = Convert.ToDouble("0." + this.Product_TV1.Text + this.Product_TV2.Text);
                    }
                    else
                    {
                        App.Manager.Options.Add("TaxOption", true);
                        App.Manager.company.Tax = Convert.ToDouble("0." + this.Product_TV1.Text + this.Product_TV2.Text);
                    }
                    if (this.Invoice_Cpn.IsChecked == true)
                    {
                        if (App.Manager.Options.ContainsKey("CouponOption"))
                        {
                            App.Manager.Options["CouponOption"] = true;
                        }
                        else
                        {
                            App.Manager.Options.Add("CouponOption", true);
                        }
                    }
                    if (this.Invoice_Estim.IsChecked == true)
                    {
                        if (App.Manager.Options.ContainsKey("EstimatesOption"))
                        {
                            App.Manager.Options["EstimatesOption"] = true;
                        }
                        else
                        {
                            App.Manager.Options.Add("EstimatesOption", true);
                        }
                    }
                    if (this.Invoice_Email.IsChecked == true)
                    {
                        if (App.Manager.Options.ContainsKey("Receipt"))
                        {
                            App.Manager.Options["Receipt"] = true;
                        }
                        else
                        {
                            App.Manager.Options.Add("Receipt", true);
                        }
                    }
                }
            }
        }

        private void NI_Button_AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanDoAccounts == true)
            {
                App.MainW.MP.upp = new UserPopup("NewUser.xaml");
                App.MainW.MP.upp.Show();
            }
        }
        private void NumericCheck(object sender, KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }

        private void NI_Button_AddCustomer_Copy2_Click(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanDoAccounts == true)
            {
                App.MainW.MP.upp = new UserPopup("ViewUsers.xaml");
                App.MainW.MP.upp.Show();
            }
        }
    }
}
