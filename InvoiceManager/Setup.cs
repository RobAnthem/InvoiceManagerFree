using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Invoice_Manager
{
    [Serializable]
    public class Setup
    {
        public int SetupId { get; private set; }
        public Company company { get; private set; }
        public Dictionary<string, bool> Options { get; private set; }
        public Dictionary<string, User> UserAccounts { get; private set; }
        public Cache MainCache { get; set; }
        public string FileName { get; private set; }
        public int Logout { get; private set; }
        public User ActiveUser { get; set; }
        public Dictionary<string, object> tempCache = new Dictionary<string, object>();
        public Dictionary<string, Option> ComplexOptions { get; set; }
        public Setup(Company c)
        {
            this.SetupId = 0;
            this.company = c;
            this.Options = new Dictionary<string, bool>();
            this.ComplexOptions = new Dictionary<string, Option>();
            this.MainCache = new Cache();
            this.Logout = new int();
            this.UserAccounts = new Dictionary<string, User>();
            this.FileName = "data/IMSETUP" + this.SetupId.ToString() + ".sim";
            Save();
        }
        public void AddOwner(User o)
        {
        }
        public void AddCompany (Company c)
        {
            this.company = c;
        }
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream writerFileStream = new FileStream(this.FileName, FileMode.Create, FileAccess.Write);
            formatter.Serialize(writerFileStream, this);
            writerFileStream.Close();
            if (this.MainCache != null)
            {
                this.MainCache.SaveAll();

            }
        }
        public void Backup()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream writerFileStream = new FileStream("backup/" + this.FileName, FileMode.Create, FileAccess.Write);
            formatter.Serialize(writerFileStream, this);
            writerFileStream.Close();
        }
        public void Restore()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream readerFileStream = new FileStream("_back" + this.FileName, FileMode.Open, FileAccess.Read);
                Setup s = (Setup)formatter.Deserialize(readerFileStream);
                readerFileStream.Close();
                FileStream writerFileStream = new FileStream(this.FileName, FileMode.Create, FileAccess.Write);
                formatter.Serialize(writerFileStream, s);
                writerFileStream.Close();
            }
            catch (Exception e)
            {
                App.Errors.Log = e.ToString();
            }
        }

    }
}

