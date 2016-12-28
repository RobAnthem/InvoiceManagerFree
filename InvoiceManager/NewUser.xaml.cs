using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        public NewUser()
        {
            InitializeComponent();
            this.NU_ID.Content = App.Manager.MainCache.EmployeeIDRef;
        }

        private void NU_AddUser_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.NU_Name.Text) && !string.IsNullOrWhiteSpace(this.NU_Pass1.Password)
                && !string.IsNullOrWhiteSpace(this.NU_Pass2.Password) && !string.IsNullOrWhiteSpace(this.NU_Username.Text))
            {
                if (this.NU_Pass1.Password == this.NU_Pass2.Password)
                {
                    if (!App.Manager.UserAccounts.ContainsKey(this.NU_Username.Text))
                    {
                        string _ph;
                        string _mail;
                        Dictionary<string, object> _d = new Dictionary<string, object>();
                        if (!string.IsNullOrWhiteSpace(this.NU_Phone1.Text) && !string.IsNullOrWhiteSpace(this.NU_Phone2.Text)
                            && !string.IsNullOrWhiteSpace(this.NU_Phone3.Text))
                        {
                            _ph = this.NU_Phone1.Text + "-" + this.NU_Phone2.Text + "-" + this.NU_Phone3.Text;
                        }
                        else { _ph = "000-000-0000"; }
                        if (!string.IsNullOrWhiteSpace(this.NU_Email.Text)) { _mail = this.NU_Email.Text; }
                        else { _mail = "none"; }
                        _d.Add("Phone", _ph);
                        _d.Add("Email", _mail);
                        _d.Add("Name", this.NU_Name.Text);
                        _d.Add("Username", this.NU_Username.Text);
                        _d.Add("Password", this.NU_Pass1.Password);
                        if (Perm_AddPS.IsChecked == true) { _d.Add("Perm_AddPS", true); } else { _d.Add("Perm_AddPS", false); }
                        if (Perm_DelIC.IsChecked == true) { _d.Add("Perm_DelIC", true); } else { _d.Add("Perm_DelIC", false); }
                        if (Perm_DelPS.IsChecked == true) { _d.Add("Perm_DelPS", true); } else { _d.Add("Perm_DelPS", false); }
                        if (Perm_Discount.IsChecked == true) { _d.Add("Perm_Discount", true); } else { _d.Add("Perm_Discount", false); }
                        if (Perm_Exit.IsChecked == true) { _d.Add("Perm_Exit", true); } else { _d.Add("Perm_Exit", false); }
                        if (Perm_Options.IsChecked == true) { _d.Add("Perm_Options", true); } else { _d.Add("Perm_Options", false); }
                        if (Perm_Stock.IsChecked == true) { _d.Add("Perm_Stock", true); } else { _d.Add("Perm_Stock", false); }
                        if (Perm_Users.IsChecked == true) { _d.Add("Perm_Users", true); } else { _d.Add("Perm_Users", false); }
                        if (Perm_Write.IsChecked == true) { _d.Add("Perm_Write", true); } else { _d.Add("Perm_Write", false); }
                        User u = new User(_d);
                        App.MainW.MP.upp.Close();
                        App.MainW.MP.upp = null;
                    }
                    else { this.errorBlock.Text = "Username Taken!"; }
                }
                else { this.errorBlock.Text = "Password does not match!"; }
            }
            else { this.errorBlock.Text = "Missing information."; }
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
    }
}
