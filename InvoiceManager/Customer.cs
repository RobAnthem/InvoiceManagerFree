using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Invoice_Manager
{
    [Serializable]
    public class Customer
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string FileName { get; private set; }
        public string Phone { get; private set; }
        public string OptionValue { get; private set; }
        public string Email { get; private set; }
        public string Notes { get; private set; }
        public double Total { get; private set; }
        public List<string> CustomerInvoices { get; set; }
        public Customer(Dictionary<string, object> c)
        {
            this.ID = App.Manager.MainCache.CustomerIDRef;
            if (c.ContainsKey("Name")) { this.Name = (string)c["Name"]; } else { this.Name = "empty"; }
            if (c.ContainsKey("Address")) { this.Address = (string)c["Address"]; } else { this.Address = "empty"; }
            if (c.ContainsKey("Email")) { this.Email = (string)c["Email"]; } else { this.Email = "empty"; }
            if (c.ContainsKey("Phone")) { this.Phone = (string)c["Phone"]; } else { this.Phone = "empty"; }
            if (c.ContainsKey("OptionVal")) { this.OptionValue = (string)c["OptionVal"]; } else { this.OptionValue = ""; }
            this.FileName = "data/customers/CustomerID" + this.ID.ToString() + ".cus";
            this.Total = new double();
            this.CustomerInvoices = new List<string>();
            if (!App.Manager.MainCache.CustomerCache.Contains(this)) { App.Manager.MainCache.Add(this); }
            this.Write();

        }
        public void Write()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream writerFileStream = new FileStream(this.FileName, FileMode.Create, FileAccess.Write);
            formatter.Serialize(writerFileStream, this);
            writerFileStream.Close();
        }
        public void ChangeName(string s)
        {
            this.Name = s;
        }
        public void ChangeAddress(string s)
        {
            this.Address = s;
        }
        public void ChangePhone(string s)
        {
            this.Phone = s;
        }
        public void AddNote(string s)
        {
            this.Notes = "*Added - " + DateTime.Now.ToString() + "*" + s;
        }
        public void ChangeEmail(string s)
        {
            this.Email = s;
        }
        public void AdjustTotal(double d)
        {
            this.Total = this.Total + d;
        }

    }
}