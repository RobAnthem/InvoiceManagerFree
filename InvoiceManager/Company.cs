using System;
using System.Collections.Generic;

namespace Invoice_Manager
{
    [Serializable]

    public class Company
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string Slogan { get; private set; }
        public bool EMailRecept { get; private set; }
        public bool Notify { get; private set; }
        public string Logo { get; private set; }
        public User Owner { get; private set; }
        public string FAX { get; set; }
        public double Tax { get; set; }
        public Company(Dictionary<string, object> x)
        {
            if (x.ContainsKey("Name")) { this.Name = (string)x["Name"]; } else { this.Name = "none"; }
            if (x.ContainsKey("Address")) { this.Address = (string)x["Address"]; } else { this.Address = "none"; }
            if (x.ContainsKey("Phone")) { this.Phone = (string)x["Phone"]; } else { this.Phone = "none"; }
            if (x.ContainsKey("Slogan")) { this.Slogan = (string)x["Slogan"]; } else { this.Slogan = "none"; }
            if (x.ContainsKey("Logo")) { this.Logo = (string)x["Logo"]; } else { this.Logo = "none"; }
            if (x.ContainsKey("FAX")) { this.FAX = (string)x["FAX"]; } else { this.FAX = "none"; }
            if (x.ContainsKey("Receipt")) { this.EMailRecept = (bool)x["Receipt"]; } else { this.EMailRecept = false; }
            if (x.ContainsKey("Notify")) { this.Notify = (bool)x["Notify"]; } else { this.Notify = false; }
            Dictionary<string, object> y = new Dictionary<string, object>();
            if (x.ContainsKey("TaxOption"))
            {
                if ((bool)x["TaxOption"] == true)
                {
                    this.Tax = (double)x["TAX"];
                }
                else
                {
                    this.Tax = 0.00;
                }
            }
            else
            {
                this.Tax = 0.00;
            }
            if (x.ContainsKey("OwnerName")) { y.Add("Name", x["OwnerName"]); } else { y.Add("Name", "none"); }
            if (x.ContainsKey("OwnerEmail")) { y.Add("Email", x["OwnerEmail"]); } else { y.Add("Email", "none"); }
            if (x.ContainsKey("OwnerPhone")) { y.Add("Phone", x["OwnerPhone"]); } else { y.Add("Phone", "none"); }
            if (x.ContainsKey("Address")) { y.Add("Address", x["Address"]); } else { y.Add("Address", "none"); }
            y.Add("Username", x["Username"]);
            y.Add("Title", "Owner");
            y.Add("PayScale", 0.00);
            y.Add("Salary", true);
            y.Add("Owner", "doesn't matter");
            y.Add("Password", x["Password"]);
            this.Owner = new User(y);
        }

    }
}
