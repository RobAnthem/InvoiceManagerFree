using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for FindService.xaml
    /// </summary>
    public partial class FindService : Page
    {
        public FindService()
        {
            InitializeComponent();
            this.PopUpSearchView.ItemsSource = App.Manager.MainCache.ServiceCache;
        }
        private void PopUpAdd_Click(object sender, RoutedEventArgs e)
        {
            if (this.PopUpSearchView.SelectedItem != null)
            {
                Service _x = (Service)PopUpSearchView.SelectedItem;
                Service _y = (Service)_x.Clone();
                if (!string.IsNullOrWhiteSpace(FP_Count.Text))
                {
                    _y.Count = Convert.ToInt32(FP_Count.Text);
                }
                else _y.Count = 1;
                App.Manager.MainCache.tempServices.Add(_y);
                App.MainW.MP.pp.Close();
                App.MainW.MP.pp = null;
                App.MainW.MP.Page_NI.CountTotals();
            }
        }
        private void PopUpSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(PopUpSearchBox.Text))
            {
                this.PopUpSearchView.ItemsSource = null;
                App.Manager.MainCache.tSlist.Clear();
                this.PopUpSearchView.ItemsSource = App.Manager.MainCache.tSlist;
                foreach (Service c in App.Manager.MainCache.ServiceCache)
                {
                    if (c.Name.Contains(this.PopUpSearchBox.Text) || c.Type.Contains(this.PopUpSearchBox.Text))
                    {
                        App.Manager.MainCache.tSlist.Add(c);
                    }
                }
            }
            else
            {
                App.Manager.MainCache.tSlist.Clear();
                this.PopUpSearchView.ItemsSource = App.Manager.MainCache.ServiceCache;
            }
        }
        private void PopUpCancel_Click(object sender, RoutedEventArgs e)
        {
            App.Manager.MainCache.tSlist.Clear();
            App.MainW.MP.pp.Close();
            App.MainW.MP.pp = null;
        }
        private void FP_Count_KeyDown(object sender, KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }
    }
}
