using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for ViewUsers.xaml
    /// </summary>
    public partial class ViewUsers : Page
    {
        public ViewUsers()
        {
            InitializeComponent();
            this.UserViewBox.ItemsSource = App.Manager.UserAccounts.Values;
        }
        public ObservableCollection<User> _tUlist = new ObservableCollection<User>();
        private void VU_View_Click(object sender, RoutedEventArgs e)
        {
            if (this.UserViewBox.SelectedItem != null)
            {
                App.MainW.MP.upp.tUser = (User)this.UserViewBox.SelectedItem;
                App.MainW.MP.upp.UPupFrame.Source = new Uri("UserInfo.xaml", UriKind.Relative);
            }
        }
        private void PopUpSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(PopUpSearchBox.Text))
            {
                this.UserViewBox.ItemsSource = null;
                this._tUlist.Clear();
                this.UserViewBox.ItemsSource = this._tUlist;
                foreach (KeyValuePair<string, User> c in App.Manager.UserAccounts)
                {
                    if (c.Value.Name.Contains(this.PopUpSearchBox.Text) || c.Value.Username.Contains(this.PopUpSearchBox.Text))
                    {
                        this._tUlist.Add(c.Value);
                    }
                }
            }
            else
            {
                this.UserViewBox.Items.Clear();
                this._tUlist.Clear();
                this.UserViewBox.ItemsSource = App.Manager.UserAccounts;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.Close();
            App.MainW.MP.upp = null;
        }
    }
}
