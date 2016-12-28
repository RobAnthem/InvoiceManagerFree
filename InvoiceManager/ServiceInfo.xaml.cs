using System.Windows;
using System.Windows.Controls;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for ServiceInfo.xaml
    /// </summary>
    public partial class ServiceInfo : Page
    {
        public ServiceInfo()
        {
            InitializeComponent();
            this.SI_Header.Content = App.Manager.MainCache.tSer.Name;
            this.SI_ID.Content = App.Manager.MainCache.tSer.ID;
            this.SI_Type.Content = App.Manager.MainCache.tSer.Type;
            this.SI_Cost.Content = App.Manager.MainCache.tSer.Cost;
            this.SI_Notes.Content = App.Manager.MainCache.tSer.Notes;
            if (App.Manager.ComplexOptions.ContainsKey("ServiceParam") && App.Manager.ComplexOptions["ServiceParam"].Bool == true)
            {
                this.SI_OptLab.Visibility = Visibility.Visible;
                this.SI_OptVal.Visibility = Visibility.Visible;
                if (string.IsNullOrWhiteSpace(App.Manager.MainCache.tSer.OptionVal))
                {
                    this.SI_OptVal.Content = App.Manager.MainCache.tSer.OptionVal;
                }
            }
        }
        private void SI_AddNoteButt_Click(object sender, RoutedEventArgs e)
        {
            App.Manager.MainCache.tSer.AddNote(App.Manager.MainCache.tSer.Notes + this.SI_NewNotes.Text);

        }

        private void NP_Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.MainW.MP.pp.Close();
            App.MainW.MP.pp = null;
        }
    }
}
