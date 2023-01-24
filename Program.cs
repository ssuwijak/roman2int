using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //x1();
            x2();

        }

        static void x1()
        {
            string roman = "MCMXCIV".ToUpper();

            int x = 0;
            int y = 0;
            int total = 0;

            int len = roman.Length;

            for (int i = 0; i < len; i++)
            {
                string rr = roman[i].ToString();

                if (rr == "M")
                    x = 1000;
                else if (rr == "D")
                    x = 500;
                else if (rr == "C")
                {
                    x = 100;
                    if (i + 1 < len)
                    {
                        var rrr = roman[i + 1].ToString();
                        if (rrr == "D" || rrr == "M")
                            y = -100;
                    }
                }
                else if (rr == "L")

                    x = 50;

                else if (rr == "X")
                {
                    x = 10;
                    if (i + 1 < len)
                    {
                        var rrr = roman[i + 1].ToString();
                        if (rrr == "L" || rrr == "C")
                            y = -10;
                    }

                }
                else if (rr == "V")
                {
                    x = 5;
                    y = 0;
                }
                else if (rr == "I")
                {
                    x = 1;
                    if (i + 1 < len)
                    {
                        var rrr = roman[i + 1].ToString();
                        if (rrr == "V" || rrr == "X")
                            y = -1;
                    }
                }
                else
                {
                    x = 0;
                    y = 0;
                }


                total += x + y;
            }


            Console.WriteLine("roman = " + roman);
            Console.WriteLine("total = " + total.ToString());

            Console.ReadKey();
        }

        static void x2()
        {
            string roman = "MCMXCIV";
            int total = 0;

            Console.WriteLine("roman = " + roman);

            RomanNumber r = new RomanNumber();
            try
            {
                string value = r.chkText(roman);
                total = r.GetValue(value);
               
                Console.WriteLine("total = " + total.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("press any key to close");
            Console.ReadKey();
        }

   
    }






}
