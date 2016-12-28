using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Invoice_Manager
{
    [Serializable]
    public class Invoice
    {
        public int ID { get; private set; }
        public string Notes { get; private set; }
        public string Type { get; set; }
        public string FileName { get; private set; }
        public Customer CusInfo { get; private set; }
        public User UserInfo { get; private set; }
        public double Value { get; set; }
        public double ProVal { get; set; }
        public double SerVal { get; set; }
        public double Tax { get; set; }
        public bool Edit { get; set; }
        public string Custom { get; set; }
        public DateTime EditDate { get; set; }
        public string Method { get; set; }
        public ObservableCollection<Service> SSales { get; private set; }
        public ObservableCollection<Products> PSales { get; private set; }
        public DateTime Date { get; private set; }
        public Invoice(Dictionary<string, object> d)
        {
            this.ID = App.Manager.MainCache.InvoiceIDRef++;
            this.Notes = "";
            if (App.Manager.MainCache.tempCustomer != null) {this.CusInfo = App.Manager.MainCache.tempCustomer; }
            else { Dictionary<string, object> g = new Dictionary<string, object>();  this.CusInfo = new Customer(g); }
            if (d.ContainsKey("Value")) { this.Value = (double)d["Value"]; } else { this.Value = new double(); }
            if (d.ContainsKey("Type")) { this.Type = (string)d["Type"]; } else { this.Type = "Invoice"; }
            if (d.ContainsKey("Method")) { this.Method = (string)d["Method"]; } else { this.Method = "unknown"; }
            if (d.ContainsKey("Value")) { this.Tax = (double)d["Tax"]; } else { this.Tax = new double(); }
            if (d.ContainsKey("ProductVal")) { this.ProVal = (double)d["ProductVal"]; } else { this.ProVal = new double(); }
            if (d.ContainsKey("ServiceVal")) { this.SerVal = (double)d["ServiceVal"]; } else { this.SerVal = new double(); }
            if (d.ContainsKey("OptionVal")) { this.Custom = ((string)d["OptionVal"]); } else { this.Custom = ""; }
            this.UserInfo = App.Manager.ActiveUser;
            this.SSales = App.Manager.MainCache.tempServices;
            this.PSales = App.Manager.MainCache.tempProducts;
            this.FileName = "data/invoices/InvoiceID" + this.ID.ToString() + ".inv";
            this.Edit = false;
            this.Date = DateTime.Now;
            App.Manager.MainCache.Add(this);
            App.Manager.MainCache.tempCustomer.CustomerInvoices.Add(this.FileName);
            App.Manager.MainCache.tempCustomer = null;
            Write();
            App.Manager.MainCache.tempServices.Clear();
            App.Manager.MainCache.tempProducts.Clear();
        }
        public void Write()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream writer1 = new FileStream(this.FileName, FileMode.Create, FileAccess.Write);
            formatter.Serialize(writer1, this);
            writer1.Close();
        }
        public void AdjustCost(double NewCost)
        {
            this.Value = NewCost;
        }
        public void AddSale(Object o)
        {
            switch (o.GetType().Name)
            {
                case "Products":
                    this.PSales.Add((Products)o);
                    break;
                case "Service":
                    this.SSales.Add((Service)o);
                    break;
            }
        }
        public void AddNote(string s)
        {
            this.Notes = this.Notes + "*Added* Note: " + s;
        }
        public Object Clone()
        {
            if (File.Exists(this.FileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream readerFileStream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read);
                Invoice s = (Invoice)formatter.Deserialize(readerFileStream);
                readerFileStream.Close();
                s.ID = App.Manager.MainCache.InvoiceIDRef;
                Write();
                return s;
            }
            else
            {
                Object c = App.Clone(this);
                Invoice i = (Invoice)c;
                i.ID = App.Manager.MainCache.InvoiceIDRef;
                Write();
                return c;
            }
        }
        public void AddCustomer(Customer c)
        {
            this.CusInfo = c;

        }
    }
}
