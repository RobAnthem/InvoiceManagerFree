using System;
using System.Collections.Generic;

namespace Invoice_Manager
{
    [Serializable]
    public class User
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string Title { get; private set; }
        public Dictionary<DateTime, double> Hours { get; private set; }
        public string Password { get; set; }
        public Permissions Perms { get; set; }
        public List<String> Sales { get; set; }
        public DateTime StartDate { get; private set; }
        public User(Dictionary<string, object> x)
        {
            this.Name = (string)x["Name"];
            this.Username = (string)x["Username"];
            this.Email = (string)x["Email"];
            if (x.ContainsKey("Phone"))
            {
                this.Phone = (string)x["Phone"];
            }
            else { this.Phone = "000-000-0000"; }
            //this.Title = (string)x["Title"];
            this.Password = (string)x["Password"];
            this.Sales = new List<string>();
            this.StartDate = DateTime.Now;
            if (!x.ContainsKey("Owner"))
            {
                this.Perms = new Permissions(true);
                App.Manager.UserAccounts.Add(this.Username, this);
                this.ID = 0;
            }
            else if (x.ContainsKey("Perm_AddPS"))
            {
                this.Perms = new Permissions(x);
                this.ID = App.Manager.MainCache.EmployeeIDRef++;
                App.Manager.UserAccounts.Add(this.Username, this);

            }
        }
    }
}

