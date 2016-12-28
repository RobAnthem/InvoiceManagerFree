using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace Invoice_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow MainW { get; set; }
        internal static Initializer Init = new Initializer();
        internal static User ActiveUser { get; set; }
        internal static Setup Manager;
        public static AutoSaver AutoSave;
        public static Invoice VisibleInvoice { get; set; }
        public static ErrorLogger Errors { get; set; }
        public static Invoice LoadInvoice(string s)
        {
            if (File.Exists(s))
            {

                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream readerFileStream = new FileStream(s, FileMode.Open, FileAccess.Read);
                    Invoice x = (Invoice)formatter.Deserialize(readerFileStream);
                    readerFileStream.Close();
                    return x;


                }
                catch (Exception e)
                {
                    App.Errors.Log = e.ToString();
                }
            }
            return null;
        }
        internal static bool firstStart { get; set; }
        internal static Object Clone(Object obj)
        {
            Type CloneType = obj.GetType();
            PropertyInfo[] CloneProperties = CloneType.GetProperties();
            object Clone = CloneType.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, 0, null);
            foreach (PropertyInfo p in CloneProperties)
            {
                if (p.CanWrite)
                {
                    p.SetValue(Clone, p.GetValue(0, null), null);
                }
            }
            return Clone;
        }
    }
}
