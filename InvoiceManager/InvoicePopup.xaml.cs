using System;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for InvoicePopup.xaml
    /// </summary>
    public partial class InvoicePopup : Window
    {
        public InvoicePopup()
        {
            InitializeComponent();
            this.IP_Frame.Source = new Uri("ViewInvoice.xaml", UriKind.Relative);
            WinSelf = this;
        }
        public Window WinSelf { get; set; }
        protected override void OnDeactivated(EventArgs e)
        {
            this.Close();
        }


    }
}
