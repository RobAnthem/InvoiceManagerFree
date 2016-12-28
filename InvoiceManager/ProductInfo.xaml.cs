using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Page
    {
        public ProductInfo()
        {
            InitializeComponent();
            this.PI_Header.Content = App.Manager.MainCache.tPro.Name;
            this.PI_ID.Content = App.Manager.MainCache.tPro.ID;
            this.PI_Type.Content = App.Manager.MainCache.tPro.Type;
            this.PI_Cost.Content = App.Manager.MainCache.tPro.Cost;
            this.PI_Stock.Content = App.Manager.MainCache.tPro.Count;
            this.PI_Notes.Content = App.Manager.MainCache.tPro.Notes;
            if (App.Manager.ComplexOptions.ContainsKey("ProductParam") && App.Manager.ComplexOptions["ProductParam"].Bool == true)
            {
                this.PI_OptLab.Visibility = Visibility.Visible;
                this.PI_OptVal.Visibility = Visibility.Visible;
                if (string.IsNullOrWhiteSpace(App.Manager.MainCache.tPro.OptionVal))
                {
                    this.PI_OptVal.Content = App.Manager.MainCache.tPro.OptionVal;
                }
            }
        }
        private void PI_AddNoteButt_Click(object sender, RoutedEventArgs e)
        {
            if (App.Manager.ActiveUser.Perms.CanAddPS == true)
            {
                App.Manager.MainCache.tPro.AddNote(this.PI_NewNotes.Text);
                this.PI_Notes.Content = App.Manager.MainCache.tPro.Notes;
            }
        }


        private void NP_Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp.Close();
            App.MainW.MP.pp = null;
        }
    }
}
