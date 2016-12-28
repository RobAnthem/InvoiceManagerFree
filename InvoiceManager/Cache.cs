using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Invoice_Manager
{
    [Serializable]
    public class Cache
    {
        public ObservableCollection<Service> tSlist { get; set; }
        public Service tSer { get; set; }
        public ObservableCollection<Products> ProductCache { get; set; }
        public ObservableCollection<Service> ServiceCache { get; set; }
        public ObservableCollection<Customer> CustomerCache { get; set; }
        public ObservableCollection<ListCache> InvoiceCache { get; set; }
        public ObservableCollection<Products> tempProducts { get; set; }
        public ObservableCollection<Service> tempServices { get; set; }
        public Customer tempCustomer { get; set; }
        public int ProductIDRef { get; set; }
        public int ServiceIDRef { get; set; }
        public int CustomerIDRef { get; set; }
        public int EmployeeIDRef { get; set; }
        public int InvoiceIDRef { get; set; }
        public Products tPro { get; set; }
        public Cache()
        {
            this.tSlist = new ObservableCollection<Service>();
            this.ProductCache = new ObservableCollection<Products>();
            this.ServiceCache = new ObservableCollection<Service>();
            this.CustomerCache = new ObservableCollection<Customer>();
            this.InvoiceCache = new ObservableCollection<ListCache>();
            this.tempProducts = new ObservableCollection<Products>();
            this.tempServices = new ObservableCollection<Service>();
            this.ProductIDRef = new int();
            this.ServiceIDRef = new int();
            this.CustomerIDRef = new int();
            this.EmployeeIDRef = 1;
            this.InvoiceIDRef = new int();
        }
        public void Add(object d)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            switch (d.GetType().Name)
            {
                case "Products":
                    this.ProductIDRef++;
                    Products p = (Products)d;
                    this.ProductCache.Add(p);
                    FileStream ProductWriter = new FileStream("data/cache/products.loa", FileMode.Create, FileAccess.Write);
                    formatter.Serialize(ProductWriter, this.ProductCache);
                    ProductWriter.Close();
                    break;
                case "Service":
                    this.ServiceIDRef++;
                    Service s = (Service)d;
                    this.ServiceCache.Add(s);
                    FileStream ServiceWriter = new FileStream("data/cache/services.loa", FileMode.Create, FileAccess.Write);
                    formatter.Serialize(ServiceWriter, this.ServiceCache);
                    ServiceWriter.Close();
                    break;
                case "Customer":
                    this.CustomerIDRef++;
                    Customer c = (Customer)d;
                    this.CustomerCache.Add(c);
                    FileStream CustomerWriter = new FileStream("data/cache/customers.loa", FileMode.Create, FileAccess.Write);
                    formatter.Serialize(CustomerWriter, this.CustomerCache);
                    CustomerWriter.Close();
                    break;
                case "Invoice":
                    this.InvoiceIDRef++;
                    Invoice i = (Invoice)d;
                    this.InvoiceCache.Add(new ListCache(i.ID, i.CusInfo.Name, i.CusInfo.Phone, i.Date, i.Value, i.Type));
                    FileStream InvoiceWriter = new FileStream("data/cache/invoices.loa", FileMode.Create, FileAccess.Write);
                    formatter.Serialize(InvoiceWriter, this.InvoiceCache);
                    InvoiceWriter.Close();
                    break;
            }
        }
        public void Remove(object o)
        {

            switch (o.GetType().Name)
            {

                case "Products":
                    Products p = (Products)o;
                    this.ProductCache.Remove(p);
                    break;
                case "Service":
                    Service s = (Service)o;
                    this.ServiceCache.Remove(s);
                    break;
                case "Customer":
                    Customer c = (Customer)o;
                    this.CustomerCache.Remove(c);
                    break;
                case "ListCache":
                    ListCache lc = (ListCache)o;
                    this.InvoiceCache.Remove(lc);
                    break;
            }
        }
        public void SaveAll()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream ProductWriter = new FileStream("data/cache/products.loa", FileMode.Create, FileAccess.Write);
            formatter.Serialize(ProductWriter, this.ProductCache);
            ProductWriter.Close();
            FileStream ServiceWriter = new FileStream("data/cache/services.loa", FileMode.Create, FileAccess.Write);
            formatter.Serialize(ServiceWriter, this.ServiceCache);
            ServiceWriter.Close();
            FileStream CustomerWriter = new FileStream("data/cache/customers.loa", FileMode.Create, FileAccess.Write);
            formatter.Serialize(CustomerWriter, this.CustomerCache);
            CustomerWriter.Close();
            FileStream InvoiceWriter = new FileStream("data/cache/invoices.loa", FileMode.Create, FileAccess.Write);
            formatter.Serialize(InvoiceWriter, this.InvoiceCache);
            InvoiceWriter.Close();
        }
        public void ReplaceProduct(Products p, Products p2)
        {
            try
            {
                App.Manager.MainCache.ProductCache.Remove(p);
                App.Manager.MainCache.ProductCache.Add(p2);
            }
            catch (Exception e)
            {
                App.Errors.Log = e.ToString();
            }
        }
    }
}
