using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    public partial class FindProduct : Page
    {
        public FindProduct()
        {
            InitializeComponent();
            this.PopUpSearchView.ItemsSource = App.Manager.MainCache.ProductCache;
        }
        private void PopUpAdd_Click(object sender, RoutedEventArgs e)
        {
            if (this.PopUpSearchView.SelectedItem != null)
            {
                ObservableCollection<Products> tPlist = new ObservableCollection<Products>();

                Products _x = (Products)this.PopUpSearchView.SelectedItem;
                Products _y = (Products)_x.Clone();
                _y.Count = Convert.ToInt32(FP_Count.Text);
                App.Manager.MainCache.tempProducts.Add(_y);
                App.MainW.MP.pp.Close();
                App.MainW.MP.pp = null;
            }
        }
        private void PopUpSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.PopUpSearchBox.Text))
            {
                ObservableCollection<Products> _tPlist = new ObservableCollection<Products>();
                this.PopUpSearchView.ItemsSource = _tPlist;
                foreach (Products _c in App.Manager.MainCache.ProductCache)
                {
                    if (_c.Name.Contains(this.PopUpSearchBox.Text) || _c.Type.Contains(this.PopUpSearchBox.Text))
                    {
                        _tPlist.Add(_c);
                    }
                }
            }
            else
            {
                this.PopUpSearchView.ItemsSource = App.Manager.MainCache.ProductCache;
            }
        }
        private void PopUpCancel_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp.Close();
            App.MainW.MP.pp = null;
        }
        private void FP_Count_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }
    }
}
