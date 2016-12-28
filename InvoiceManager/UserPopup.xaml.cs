using System;
using System.Windows;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for UserPopup.xaml
    /// </summary>
    public partial class UserPopup : Window
    {
        public User tUser { get; set; }
        public UserPopup(string p)
        {
            InitializeComponent();
            this.UPupFrame.Source = new Uri(p, UriKind.Relative);
        }

        private void On_Deactivated(object sender, EventArgs e)
        {
            tUser = null;
            Close();
        }
    }
}
