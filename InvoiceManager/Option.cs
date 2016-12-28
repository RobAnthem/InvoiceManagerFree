using System;

namespace Invoice_Manager
{
    [Serializable]
    public class Option
    {
        public string Name { get; private set; }
        public bool Bool { get; private set; }
        public string Info { get; private set; }
        public Option(string n, bool b, string co)
        {
            this.Name = n;
            this.Bool = b;
            this.Info = co;
        }
        public void OptionToggle()
        {
            this.Bool = !this.Bool;

        }
        public void ChangeName(string n)
        {
            this.Name = n;
        }
        public void Edit(string i)
        {
            this.Info = i;
        }
    }
}
