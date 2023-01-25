using System;
using System.Collections.Generic;
using System.Linq;

namespace Roman2Int
{
    public class RomanNumber
    {
        protected string roman_chars = "MDCLXVI";
        protected int[] roman_values = { 1000, 500, 100, 50, 10, 5, 1 };
        protected string roman_specials = "IV,IX,XL,XC,CD,CM";

        public bool CheckText(ref string value, bool enableException = false)
        {
            bool ret = false;
            string msg = "ok";

            value = value.Trim().ToUpper();

            int len = value.Length;

            if (len < 1 || len > 15)
                msg = $"'{value}', length was invalid.";
            else
            {
                ret = true;

                foreach (char c in value)
                {
                    ret = roman_chars.Contains(c);
                    if (!ret)
                    {
                        msg = $"'{value}' contained invalid character";
                        break;
                    }
                }
            }

            if (!ret && enableException)
                throw new Exception(msg);

            return ret;
        }
        protected int getValue(char c)
        {
            int ret = 0;

            int i = roman_chars.IndexOf(c);
            if (i > -1)
                ret = roman_values[i];

            return ret;
        }
        protected int getValue(string strLen2)
        {
            int ret = 0;

            if (strLen2 is null || strLen2.Length != 2)
                return ret;

            if (roman_specials.Contains(strLen2))
            {
                char[] c = { 'a', 'a' };
                c[0] = strLen2[0];
                c[1] = strLen2[1];

                ret = this.getValue(c[1]) - this.getValue(c[0]);
            }

            return ret;
        }
        public int GetValue(string value, bool checkText = true)
        {
            int ret = 0;

            if (checkText)
                if (!this.CheckText(ref value))
                    return ret;

            int len = value.Length;

            if (len == 1)
                ret = this.getValue(value[0]);
            else if (len == 2 && roman_specials.Contains(value))
                ret = this.getValue(value);
            else
            {
                List<string> r1 = new List<string>();
                List<string> r2 = new List<string>();
                List<int> r3 = new List<int>();

                int i, j;

                // split roman number by 2 chars. 
                j = len - 1;

                for (i = 0; i < j; i++)
                {
                    r1.Add(value.Substring(i, 2));// ex. abcde --> ab,bc,cd,de,e
                }
                r1.Add(value.Substring(j));// add the last character.

                // consider the splitted roman number
                for (i = 0; i < len; i++)
                {
                    string vv = r1[i];

                    if (vv.Length == 1)
                    {
                        r2.Add(vv);
                        r3.Add(this.getValue(vv[0]));
                    }
                    else if (roman_specials.Contains(vv))
                    {
                        r2.Add(vv);
                        r3.Add(this.getValue(vv));

                        i++;// ignore and skip the next value, due to already read this round.
                    }
                    else
                    {
                        string v = vv.Substring(0, 1);// read only the 1st char.

                        r2.Add(v);
                        r3.Add(this.getValue(v[0]));
                    }
                }

                // check order ... max to min
                bool flagOrderError = false;
                j = roman_values[0];// max value of roman number.

                foreach (int v in r3)
                {
                    flagOrderError = v > j;
                    if (flagOrderError)
                    {
                        // error .. invalid order
                        break;
                    }
                    else
                        j = v;
                }

                // if no error .. calculate the total
                if (flagOrderError)
                    throw new Exception($"'{value}' invalid order");
                else
                {
                    ret = 0;

                    foreach (int v in r3)
                        ret += v;
                }
            }

            return ret;
        }
    }
}
