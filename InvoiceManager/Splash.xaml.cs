using System;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Page
    {
        public Splash()
        {
            InitializeComponent();
            if (App.firstStart == true) { this.SetupButton.Visibility = Visibility.Visible;  }
            else
            {
                this.LoginButton.Visibility = Visibility.Visible;
                this.IM_Password.Visibility = Visibility.Visible;
                this.IM_UsernameBox.Visibility = Visibility.Visible;
                this.UsernameLabel.Visibility = Visibility.Visible;
                this.PasswordLabel.Visibility = Visibility.Visible;

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button_Launch(object sender, RoutedEventArgs e)
        {
            App.MainW.Source = new Uri("Start.xaml", UriKind.Relative);

        }
        private void button_Login(object sender, RoutedEventArgs e)
        {
            if (App.Manager.company.Owner.Username == IM_UsernameBox.Text && App.Manager.company.Owner.Password == IM_Password.Password || App.Manager.UserAccounts.ContainsKey(IM_UsernameBox.Text) && App.Manager.UserAccounts[IM_UsernameBox.Text].Password == IM_Password.Password)
            {
                App.MainW.Source = new Uri("MainPage.xaml", UriKind.Relative);
                if (App.Manager.company.Owner.Username == IM_UsernameBox.Text)
                {
                    App.Manager.ActiveUser = App.Manager.company.Owner;
                }
                else
                {
                    App.Manager.ActiveUser = App.Manager.UserAccounts[IM_UsernameBox.Text];

                }
            }
            else
            {
                IM_Incorrect.Visibility = Visibility.Visible;
            }

        }
    }
}
