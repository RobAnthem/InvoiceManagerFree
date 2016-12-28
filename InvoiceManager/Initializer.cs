using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Navigation;

namespace Invoice_Manager
{
    class Initializer
    {
        public Dictionary<string, object> tempCache { get; set; }
        public NavigationWindow tMain { get; set; }
        public Initializer()
        {
            if (File.Exists("data/IMSETUP0.sim"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream readerFileStream = new FileStream("data/IMSETUP0.sim", FileMode.Open, FileAccess.Read);
                Setup s = (Setup)formatter.Deserialize(readerFileStream);
                readerFileStream.Close();
                this.tempCache = new Dictionary<string, object>();
                App.Manager = s;
                App.firstStart = false;
                App.Errors = new ErrorLogger();
                if (File.Exists("data/cache/products.loa"))
                {
                    FileStream ProductReader = new FileStream("data/cache/products.loa", FileMode.Open, FileAccess.Read);
                    App.Manager.MainCache.ProductCache = (ObservableCollection<Products>)formatter.Deserialize(ProductReader);
                    ProductReader.Close();
                }
                if (File.Exists("data/cache/services.loa"))
                {
                    FileStream ServiceReader = new FileStream("data/cache/services.loa", FileMode.Open, FileAccess.Read);
                    App.Manager.MainCache.ServiceCache = (ObservableCollection<Service>)formatter.Deserialize(ServiceReader);
                    ServiceReader.Close();
                }
                if (File.Exists("data/cache/customers.loa"))
                {
                    FileStream CustomerReader = new FileStream("data/cache/customers.loa", FileMode.Open, FileAccess.Read);
                    App.Manager.MainCache.CustomerCache = (ObservableCollection<Customer>)formatter.Deserialize(CustomerReader);
                    CustomerReader.Close();
                }
                if (File.Exists("data/cache/invoices.loa"))
                {
                    FileStream InvoiceReader = new FileStream("data/cache/invoices.loa", FileMode.Open, FileAccess.Read);
                    App.Manager.MainCache.InvoiceCache = (ObservableCollection<ListCache>)formatter.Deserialize(InvoiceReader);
                    InvoiceReader.Close();
                }
                App.AutoSave = new AutoSaver();
            }
            else
            {
                this.tempCache = new Dictionary<string, object>();
                App.firstStart = true;

            }
        }
    }
}
