using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Invoice_Manager
{
    [Serializable]
    public class Service
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public bool Coupon { get; private set; }
        public string OptionVal { get; private set; }
        public string FileName { get; private set; }
        public string Notes { get; private set; }
        public int Count{ get; set; }
        public double Cost { get; private set; }
        public Service(Dictionary<string, object> x)
        {
            this.ID = App.Manager.MainCache.ServiceIDRef;
            this.Name = (string)x["Name"];
            if (x.ContainsKey("Type")) { this.Type = (string)x["Type"]; } else { this.Type = "None"; }
            if (x.ContainsKey("Notes")) { this.Notes = (string)x["Notes"]; } else { this.Notes = ""; }
            this.Cost = (double)x["Cost"];
            if (x.ContainsKey("Coupon")) { this.Coupon = (bool)x["Coupon"]; } else { this.Coupon = false; }
            if (App.Manager.ComplexOptions.ContainsKey("ServiceParam") && App.Manager.ComplexOptions["ServiceParam"].Bool == true
                && x.ContainsKey("OptionVal"))
            {
                this.OptionVal = (string)x["OptionVal"];
            }
            else { this.OptionVal = ""; }
            this.FileName = "data/services/ServiceID" + this.ID.ToString() + ".ser";
            this.Count = new int();
            Write();
            App.Manager.MainCache.Add(this);
        }
        public void Write()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream writerFileStream = new FileStream(this.FileName, FileMode.Create, FileAccess.Write);
            formatter.Serialize(writerFileStream, this);
            writerFileStream.Close();
        }
        public void AdjustCost(double NewCost)
        {
            this.Cost = NewCost;
        }
        public void Delete()
        {
            App.Manager.MainCache.Remove(this);
        }
        public void ChangeName(string s)
        {
            this.Name = s;
        }
        public void ChangeType(string s)
        {
            this.Type = s;
        }
        public void AddNote(string s)
        {
            this.Notes = this.Notes + "*Added* Note: " + s;
        }
        public void Add(int i)
        {
            this.Count = this.Count + i;
        }
        public void Remove(int i)
        {
            this.Count = this.Count = i;
            this.Count = this.Count.Limit(1, 5);
        }
        public Object Clone()
        {
            if (File.Exists(this.FileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream readerFileStream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read);
                Object s = (Service)formatter.Deserialize(readerFileStream);
                readerFileStream.Close();
                return s;
            }
            else
            {
                Object c = App.Clone(this);
                return c;
            }
        }

    }
}
