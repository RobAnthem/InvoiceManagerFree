using System;

namespace Invoice_Manager
{
    [Serializable]
    public class ListCache
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string Type { get; set; }
        public ListCache(int i, string n, string p, DateTime d, double v, string t)
        {
            this.ID = i;
            this.Name = n;
            this.Phone = p;
            this.Date = d;
            this.Value = v;
            this.Type = t;
        }

    }
}
