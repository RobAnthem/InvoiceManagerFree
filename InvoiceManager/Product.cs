using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Invoice_Manager
{
    [Serializable]
    public class Products
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string FileName { get; private set; }
        public string Notes { get; set; }
        public bool Notify { get; private set; }
        public int NotifyAmount { get; private set; }
        public string OptionVal { get; private set; }
        public int Count { get; set; }
        public double Cost { get; private set; }
        public Products(Dictionary<string, object> x)
        {
            this.ID = App.Manager.MainCache.ProductIDRef;
            this.Name = (string)x["Name"];
            this.Type = (string)x["Type"];
            List<string> u = new List<string>();
            if (x.ContainsKey("Notify"))
            {
                if (x.ContainsKey("NotifyValue"))
                {
                    this.Notify = (bool)x["Notify"];
                    this.NotifyAmount = (int)x["NotifyAmount"];
                }
            }
            if (x.ContainsKey("Notes"))
            {
                this.Notes = (string)x["Notes"];
            }
            this.Cost = (double)x["Cost"];
            this.Count = new int();
            this.FileName = "data/products/ProductID" + this.ID + ".inv";
            if (x.ContainsKey("ServiceParam") && App.Manager.ComplexOptions["ServiceParam"].Bool == true)
            {
                if (x.ContainsKey("OptionVal"))
                {
                    this.OptionVal = (string)x["OptionVal"];
                }
                else { this.OptionVal = App.Manager.ComplexOptions["ServiceParam"].Info; }
            }
            else { this.OptionVal = ""; }
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
            this.Notes = "*Added* Note: " + s;
        }
        public void Add(int i)
        {
            this.Count = this.Count + i;
        }
        public bool Remove(int i)
        {
            int tI = this.Count - i;
            if (tI < 0) { return false; }
            else { this.Count = tI; return true; }
        }
        public Object Clone()
        {
            if (File.Exists(this.FileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream readerFileStream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read);
                Object s = (Products)formatter.Deserialize(readerFileStream);
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

