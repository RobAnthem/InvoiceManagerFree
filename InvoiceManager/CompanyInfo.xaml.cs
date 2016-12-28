using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class CompanyInfo : Page
    {
        public CompanyInfo()
        {
            InitializeComponent();
        }
        public string lgo { get; set; }
        public void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog LogoFile = new OpenFileDialog();
            LogoFile.Title = "Select an Image as a Logo";
            LogoFile.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (LogoFile.ShowDialog() == true)
            {
                Logo.Source = new BitmapImage(new Uri(LogoFile.FileName));
                lgo = LogoFile.FileName;
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            bool test = true;
            string error = "none";
            if (!string.IsNullOrWhiteSpace(lgo)) { App.Init.tempCache.Add("Logo", lgo);} else { App.Init.tempCache.Add("Logo", "images/Buttons/icon2.png"); }
            if (!string.IsNullOrWhiteSpace(C_NameBox.Text)) { App.Init.tempCache.Add("Name", C_NameBox.Text); } else { test = false; error = "Company Name cannot be empty."; }
            if (!string.IsNullOrWhiteSpace(C_AddBox.Text)) { App.Init.tempCache.Add("Address", C_AddBox.Text); } else { test = false; error = "Company Address cannot be empty."; }
            if (!string.IsNullOrWhiteSpace(C_PhoneBox.Text) && !string.IsNullOrWhiteSpace(C_PhoneBox2.Text) && !string.IsNullOrWhiteSpace(C_PhoneBox3.Text))
            { App.Init.tempCache.Add("Phone", C_PhoneBox.Text + "-" + C_PhoneBox2.Text + "-" + C_PhoneBox3.Text); } else { test = false; error = "Company Phone cannot be empty."; }
            if (!string.IsNullOrWhiteSpace(C_FAXBox1.Text) && !string.IsNullOrWhiteSpace(C_FAXBox2.Text) && !string.IsNullOrWhiteSpace(C_FAXBox3.Text))
            { App.Init.tempCache.Add("FAX", C_FAXBox1.Text + "-" + C_FAXBox2.Text + "-" + C_FAXBox3.Text); } else { App.Init.tempCache.Add("FAX", "000-000-0000"); }
            if (!string.IsNullOrWhiteSpace(C_SloganBox.Text)) { App.Init.tempCache.Add("Slogan", C_SloganBox.Text); } else { App.Init.tempCache.Add("Slogan", ""); }
            if (!string.IsNullOrWhiteSpace(O_NameBox.Text)) { App.Init.tempCache.Add("OwnerName", O_NameBox.Text); } else { test = false; error = "Owner name cannot be empty."; }
            if (!string.IsNullOrWhiteSpace(O_PhoneBox.Text) && !string.IsNullOrWhiteSpace(O_PhoneBox2.Text) && !string.IsNullOrWhiteSpace(O_PhoneBox3.Text))
            { App.Init.tempCache.Add("OwnerPhone", O_PhoneBox.Text + "-" + O_PhoneBox2.Text + "-" + O_PhoneBox3.Text); } else { App.Init.tempCache.Add("OwnerPhone", C_PhoneBox.Text); }
            if (!string.IsNullOrWhiteSpace(O_EmailBox.Text)) { App.Init.tempCache.Add("OwnerEmail", O_EmailBox.Text); } else { App.Init.tempCache.Add("OwnerEmail", ""); }
            if (!string.IsNullOrWhiteSpace(UsernameBox.Text)) { App.Init.tempCache.Add("Username", UsernameBox.Text); } else { test = false; error = "You must create a Username."; }
            if (!string.IsNullOrWhiteSpace(PassBox.Password))
            {
                if (PassBox.Password == ConfirmPassBox.Password)
                {
                    App.Init.tempCache.Add("Password", PassBox.Password); 

                }
                else { test = false; error = "Password does not match, or password is empty."; }

            }
            else { test = false; error = "Password does not match, or password is empty."; }

            if (C_OptionNotify.IsThreeState == true) { App.Init.tempCache.Add("Receipt", true); }
            else { App.Init.tempCache.Add("Receipt", false); }

            if ( C_OptionNotify.IsThreeState == true){ App.Init.tempCache.Add("Notify", true); }
            else { App.Init.tempCache.Add("Notify", false); }
            if (test == true)
            {
                App.MainW.Source = new Uri("CollectionsInfo.xaml", UriKind.Relative);
            }
            else { this.ErrorString.Content = error; this.ErrorString.Visibility = Visibility.Visible; App.Init.tempCache.Clear(); }


        }

        private void NumericCheck(object sender, KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }
    }
}
