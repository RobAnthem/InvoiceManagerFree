using System.Windows.Input;

namespace Invoice_Manager
{
    public static class KeyHandler
    {

        public static void NumericOnly(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9) { e.Handled = true; }
            else { e.Handled = false; }
        }
        public static void AlphaOnly(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9 || e.Key < Key.NumPad0 || e.Key > Key.NumPad9) { e.Handled = false; }
            else { e.Handled = true; }
        }
    }
}
