using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : Page
    {
        public ProductView()
        {
            InitializeComponent();
            App.MainW.MP.Page_PV = this;
            this.ProductViewBox.ItemsSource = App.Manager.MainCache.ProductCache;
        }
        public ObservableCollection<Products> tPlist { get; set; }
        private void ProductsView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.ProductViewBox.SelectedItem != null)
            {
                this.ViewPopup.IsOpen = true;
            }
        }

        private void PV_Button_Add(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanAddPS == true)
            {
                App.MainW.MP.pp = new Popup("NewProduct.xaml");
                App.MainW.MP.pp.Show();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.ProductViewBox.SelectedItem != null)
            {
                App.MainW.MP.pp = new Popup("ProductInfo.xaml", (Products)this.ProductViewBox.SelectedItem);
                App.MainW.MP.pp.Show();
                this.ViewPopup.IsOpen = false;

            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanDeletelPS == true)
            {
                App.Manager.MainCache.Remove((Products)this.ProductViewBox.SelectedItem);
                this.ViewPopup.IsOpen = false;
            }
        }

        private void PV_CountButt_Click(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanRestock == true)
            {
                if (!string.IsNullOrWhiteSpace(this.PV_CountBox.Text))
                {
                    Products _p = (Products)this.ProductViewBox.SelectedItem;
                    Products _p2 = (Products)_p.Clone();
                    _p2.Count = Convert.ToInt32(this.PV_CountBox.Text);
                    App.Manager.MainCache.ReplaceProduct(_p, _p2);
                    this.PV_CountBox.Text = "";
                }
            }
        }

        private void PV_CountBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyHandler.NumericOnly(sender, e);
        }

        private void PopUpSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.tPlist = new ObservableCollection<Products>();
            if (!string.IsNullOrWhiteSpace(PopUpSearchBox.Text))
            {
                this.ProductViewBox.ItemsSource = null;
                this.tPlist.Clear();
                this.ProductViewBox.ItemsSource = tPlist;
                foreach (Products _c in App.Manager.MainCache.ProductCache)
                {
                    if (_c.Name.Contains(this.PopUpSearchBox.Text) || _c.Type.Contains(this.PopUpSearchBox.Text))
                    {
                        tPlist.Add(_c);
                    }
                }
            }
            else
            {
                tPlist.Clear();
                this.ProductViewBox.ItemsSource = App.Manager.MainCache.ProductCache;
            }
        }
    }
}
