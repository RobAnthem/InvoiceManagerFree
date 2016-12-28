using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        public Popup(string p)
        {
            InitializeComponent();
            this.ViewFrame.Source = new Uri(p, UriKind.Relative);
        }
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            Close();
        }
        public Popup(string p, Products p2)
        {
            InitializeComponent();
            this.ViewFrame.Source = new Uri(p, UriKind.Relative);
            App.Manager.MainCache.tPro = p2;

        }
        public Popup(string p, Service p2)
        {
            InitializeComponent();
            this.ViewFrame.Source = new Uri(p, UriKind.Relative);
            App.Manager.MainCache.tSer = p2;

        }
        public Popup(string p, ObservableCollection<Products> p2)
        {
            InitializeComponent();
            this.ViewFrame.Source = new Uri(p, UriKind.Relative);

        }
    }
}
