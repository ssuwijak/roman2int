using System;

namespace Roman2Int
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string roman = "MMMMCMXLIV";// "DCCLXXXVI";// "MCMXCIV";

            //x1(roman);
            x2(roman);

            Console.WriteLine("press any key to close ...");
            Console.ReadKey();
        }

        static void x1(string roman)
        {
            roman = roman.ToUpper();

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


        }

        static void x2(string roman)
        {
            int total = 0;

            Console.WriteLine("roman = " + roman);

            RomanNumber r = new RomanNumber();
            try
            {
                total = r.GetValue(roman);

                Console.WriteLine("total = " + total.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }


    }






}
