using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Invoice_Manager
{
    public class ErrorLogger
    {
        public string FileName { get; set; }
        private List<string> _log { get; set; }
        public string Log
        {
            get { return _log[_log.Count]; }
            set { _log.Add(value); }
        }
        public ErrorLogger()
        {
            this.FileName = "data/errors/ErrorLog.txt";
            this._log = new List<string>();
        }
        public void Write()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream writerFileStream = new FileStream(DateTime.Now.ToString() + this.FileName, FileMode.Create, FileAccess.Write);
            formatter.Serialize(writerFileStream, this);
            writerFileStream.Close();
        }
        public void CheckLength()
        {
            if (_log.Count >= 10)
            {
                this.Write();
                _log.Clear();
            }
        }
    }
}
