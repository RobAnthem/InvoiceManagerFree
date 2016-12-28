using System;

namespace Invoice_Manager
{
    public static class Extensions
    {
        public static int Limit(this int value, int min)
        {
            if (value <= min) { return min; }
            else { return value; }
        }
        public static int Limit(this int value, int min, int max)
        {
            if (value <= min) { return min; }
            if (value >= max) { return max; }
            else { return value; }
        }
        public static int[] Split(this double value)
        {
            string[] s = value.ToString().Split('.');
            int[] r = new int[] { };
            r[0] = Convert.ToInt32(s[0]);
            r[1] = Convert.ToInt32(s[1]);
            return r;
        }
    }
}
