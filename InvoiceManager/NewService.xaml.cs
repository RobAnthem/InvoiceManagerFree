using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for NewService.xaml
    /// </summary>
    public partial class NewService : Page
    {
        public NewService()
        {
            InitializeComponent();
            this.NS_ID.Content = App.Manager.MainCache.ServiceIDRef;
            if (App.Manager.ComplexOptions.ContainsKey("ServiceParam") && App.Manager.ComplexOptions["ServiceParam"].Bool == true)
            {
                this.NS_OptLabel.Content = App.Manager.ComplexOptions["ServiceParam"].Name;
                this.NS_OptBox.Visibility = Visibility.Visible;
                this.NS_OptLabel.Visibility = Visibility.Visible;
            }
        }

        private void NS_AddService_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NS_Name.Text) && !string.IsNullOrWhiteSpace(NS_Type.Text) && !string.IsNullOrWhiteSpace(NS_Cost.Text) && !string.IsNullOrWhiteSpace(NS_Cost2.Text))
            {
                Dictionary<string, object> tService = new Dictionary<string, object>();
                if (!string.IsNullOrWhiteSpace((this.NS_Notes.Text))) { tService.Add("Notes", this.NS_Notes.Text); } else { tService.Add("Notes", ""); }
                tService.Add("Name", NS_Name.Text);
                tService.Add("Type", NS_Type.Text);
                if (!string.IsNullOrWhiteSpace(this.NS_OptBox.Text)) { tService.Add("OptionVal", this.NS_OptBox.Text); }
                tService.Add("Cost", Convert.ToDouble(this.NS_Cost.Text + "." + this.NS_Cost2.Text));
                Service p = new Service(tService);
                App.MainW.MP.pp.Close();
                App.MainW.MP.pp = null;
            }
        }

        private void NS_Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp.Close();
            App.MainW.MP.pp = null;
        }

        private void NS_Cost_KeyDown(object sender, KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }
    }
}
