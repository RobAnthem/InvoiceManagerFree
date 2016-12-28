using System;
using System.Collections.Generic;

namespace Invoice_Manager
{
    [Serializable]
    public class Permissions
    {
        public bool CanWrite { get; set; }
        public bool CanAddPS { get; set; }
        public bool CanRestock { get; set; }
        public bool CanDiscount { get; set; }
        public bool CanDeletelPS { get; set; }
        public bool CanDeleteCI { get; set; }
        public bool CanExit { get; set; }
        public bool CanOptions { get; set; }
        public bool CanDoAccounts { get; set; }
        public Permissions()
        {
            this.CanWrite = false;
            this.CanAddPS = false;
            this.CanRestock = false;
            this.CanDiscount = false;
            this.CanDeletelPS = false;
            this.CanExit = false;
            this.CanDeleteCI = false;
            this.CanOptions = false;
            this.CanDoAccounts = false;
        }
        public Permissions(bool b)
        {
            if (b == true)
            {
                this.CanWrite = true;
                this.CanAddPS = true;
                this.CanRestock = true;
                this.CanDiscount = true;
                this.CanDeletelPS = true;
                this.CanExit = true;
                this.CanOptions = true;
                this.CanDeleteCI = true;
                this.CanDoAccounts = true;
            }
            if (b == false)
            {
                this.CanWrite = true;
                this.CanAddPS = false;
                this.CanRestock = false;
                this.CanDiscount = false;
                this.CanDeletelPS = false;
                this.CanExit = false;
                this.CanOptions = false;
                this.CanDeleteCI = false;
                this.CanDoAccounts = true;
            }
        }
        public Permissions(Dictionary<string, object> d)
        {
            this.CanWrite = (bool)d["Perm_Write"];
            this.CanAddPS = (bool)d["Perm_AddPS"];
            this.CanRestock = (bool)d["Perm_Stock"];
            this.CanDiscount = (bool)d["Perm_Discount"];
            this.CanDeletelPS = (bool)d["Perm_DelPS"];
            this.CanExit = (bool)d["Perm_Exit"];
            this.CanDeleteCI = (bool)d["Perm_DelIC"];
            this.CanOptions = (bool)d["Perm_Options"];
            this.CanDoAccounts = (bool)d["Perm_Users"];
        }
    }

}
