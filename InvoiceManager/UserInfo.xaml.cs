using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        public UserInfo()
        {
            InitializeComponent();
            string[] s = App.MainW.MP.upp.tUser.Phone.Split('-');
            if (!string.IsNullOrEmpty(s[0]) && !string.IsNullOrEmpty(s[1]) && !string.IsNullOrEmpty(s[2]))
            {
                this.UI_Phone1.Text = s[0];
                this.UI_Phone2.Text = s[1];
                this.UI_Phone3.Text = s[2];
            }
            this.UI_Name.Content = App.MainW.MP.upp.tUser.Name;
            if (!string.IsNullOrWhiteSpace(App.MainW.MP.upp.tUser.Email)) { this.UI_Email.Text = App.MainW.MP.upp.tUser.Name; }
            this.UI_Username.Text = App.MainW.MP.upp.tUser.Username;
            this.UI_ID.Content = App.MainW.MP.upp.tUser.ID;
            this.UI_Date.Content = App.MainW.MP.upp.tUser.StartDate;
            if (App.MainW.MP.upp.tUser.Perms.CanAddPS == true) { this.Perm_AddPS.IsChecked = true; }
            if (App.MainW.MP.upp.tUser.Perms.CanWrite == true) { this.Perm_Write.IsChecked = true; }
            if (App.MainW.MP.upp.tUser.Perms.CanDeleteCI == true) { this.Perm_DelIC.IsChecked = true; }
            if (App.MainW.MP.upp.tUser.Perms.CanDiscount == true) { this.Perm_Discount.IsChecked = true; }
            if (App.MainW.MP.upp.tUser.Perms.CanDoAccounts == true) { this.Perm_Users.IsChecked = true; }
            if (App.MainW.MP.upp.tUser.Perms.CanExit == true) { this.Perm_Exit.IsChecked = true; }
            if (App.MainW.MP.upp.tUser.Perms.CanOptions == true) { this.Perm_Options.IsChecked = true; }
            if (App.MainW.MP.upp.tUser.Perms.CanRestock == true) { this.Perm_Stock.IsChecked = true; }
            if (App.MainW.MP.upp.tUser.Perms.CanDeletelPS == true) { this.Perm_DelPS.IsChecked = true; }

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.Close();
            App.MainW.MP.upp = null;
        }
        private void NumericCheck(object sender, KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }
        private void Perm_Write_Checked(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.tUser.Perms.CanWrite = !App.MainW.MP.upp.tUser.Perms.CanWrite;
        }
        private void Perm_AddPS_Checked(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.tUser.Perms.CanAddPS = !App.MainW.MP.upp.tUser.Perms.CanAddPS;
        }
        private void Perm_DelPS_Checked(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.tUser.Perms.CanDeletelPS = !App.MainW.MP.upp.tUser.Perms.CanDeletelPS;
        }
        private void Perm_DelIC_Checked(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.tUser.Perms.CanDeleteCI = !App.MainW.MP.upp.tUser.Perms.CanDeleteCI;
        }
        private void Perm_Exit_Checked(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.tUser.Perms.CanExit = !App.MainW.MP.upp.tUser.Perms.CanExit;
        }
        private void Perm_Users_Checked(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.tUser.Perms.CanDoAccounts = !App.MainW.MP.upp.tUser.Perms.CanDoAccounts;
        }
        private void Perm_Stock_Checked(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.tUser.Perms.CanRestock = !App.MainW.MP.upp.tUser.Perms.CanRestock;
        }
        private void Perm_Options_Checked(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.tUser.Perms.CanOptions = !App.MainW.MP.upp.tUser.Perms.CanOptions;
        }
        private void Perm_Discount_Checked(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.upp.tUser.Perms.CanDiscount = !App.MainW.MP.upp.tUser.Perms.CanDiscount;
        }
        private void UI_Phone_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.UI_Phone1.Text) && !string.IsNullOrEmpty(this.UI_Phone2.Text) && !string.IsNullOrEmpty(this.UI_Phone3.Text))
            {
                App.MainW.MP.upp.tUser.Phone = this.UI_Phone1.Text + "-" + this.UI_Phone2.Text + "-" + this.UI_Phone3.Text;
            }
        }
        private void UI_Email_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.UI_Email.Text))
            {
                App.MainW.MP.upp.tUser.Email = this.UI_Email.Text;
            }
        }
        private void UI_Username_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.UI_Username.Text))
            {
                App.MainW.MP.upp.tUser.Username = this.UI_Username.Text;
            }
        }
        private void UI_Password_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.UI_Pass1.Password) && !string.IsNullOrEmpty(this.UI_Pass2.Password) && this.UI_Pass1.Password == this.UI_Pass2.Password)
            {
                App.MainW.MP.upp.tUser.Password = this.UI_Pass1.Password;
            }
        }
    }
}