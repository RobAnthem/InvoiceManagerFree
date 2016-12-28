using System;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Next_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.Source = new Uri("CompanyInfo.xaml", UriKind.Relative);
        }
    }
}
