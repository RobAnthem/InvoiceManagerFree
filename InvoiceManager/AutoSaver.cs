using System;
using System.Threading;

namespace Invoice_Manager
{
    [Serializable]

    public class AutoSaver
    {
        public Listener SaveListener { get; set; }
        public Timer SaveTimer { get; set; }
        public AutoResetEvent Saving { get; set; }
        public AutoSaver()
        {
            this.SaveListener = new Listener();
            this.Saving = new AutoResetEvent(false);
            this.SaveTimer = new Timer(SaveListener.Handle, Saving, 0, 60000);
        }
        public void Save()
        {

        }
    }
}
