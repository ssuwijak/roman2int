using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConsoleApp1
{
    public class RomanNumber
    {
        protected string roman_chars = "MDCLXVI";
        protected int[] roman_values = { 1000, 500, 100, 50, 10, 5, 1 };
        public string Text { get; set; }
        protected int getValue(string c)
        {
            int i = 0, j = 0;

            string value = c.Trim().ToUpper();

            if (value.Length == 1)
            {
                i = roman_chars.IndexOf(value);
                if (i > -1)
                    j = roman_values[i];
            }

            return j;
        }

        public string chkText(string value)
        {
            value = value.Trim().ToUpper();
            int len = value.Length;

            if (len < 1 || len > 15)
                throw new Exception($"'{value}', length was invalid.");
            else if (value.Contains(" "))
                throw new Exception($"'{value}' contained a space.");
            else
            {
                bool flag = true;
                foreach (char c in value)
                {
                    if (!roman_chars.Contains(c))
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                    return value;
                else
                    throw new Exception($"'{value}' contained invalid character");
            }
        }


        public int GetValue(string value)
        {
            List<string> r1 = new List<string>();
            List<string> r2 = new List<string>();
            List<int> r3 = new List<int>();

            int total = 0;
            int i = 0;

            // split roman number
            int k = value.Length - 1;

            for (i = 0; i < k; i++)
            {
                r1.Add(value.Substring(i, 2));
            }
            r1.Add(value.Substring(k));

            // consider the splitted roman number
            for (i = 0; i < k; i++)
            {
                string v = r1[i];

                if (v.Length == 1)
                {
                    r2.Add(v);
                    r3.Add(this.getValue(v));
                }
                else if ("IV,IX,XL,XC,CD,CM".Contains(v))
                {
                    r2.Add(v);

                    var a1 = v.Substring(0, 1);
                    var a2 = v.Substring(1, 1);
                    var a3 = this.getValue(a2) - this.getValue(a1);

                    r3.Add(a3);

                    i++;// continue;
                }
                else
                {
                    var a1 = v.Substring(0, 1);
                    var a2 = this.getValue(a1);

                    r2.Add(a1);
                    r3.Add(a2);
                }
            }

            // check order ... max to min
            bool flagError = false;
            k = roman_values[0];
            foreach (int v in r3)
            {
                flagError = v > k;
                if (flagError)
                {
                    // error .. invalid order
                    break;
                }
                else
                    k = v;
            }

            // if no error .. calculate the total
            if (flagError)

                throw new Exception($"'{value}' invalid order");
            else
            {
                total = 0;

                foreach (int v in r3)
                    total += v;
            }

            return total;
        }
    }
}
