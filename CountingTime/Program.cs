using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            FigureItOut fo = new FigureItOut();
            double yo = 0;

            yo = fo.CalcFee(new DateTime(2022, 4, 1, 7, 00, 00), new DateTime(2022, 4, 1, 17, 00, 00));
            Console.WriteLine(string.Format("{0:c}", yo));
            yo = fo.CalcFee(new DateTime(2022, 4, 1, 7, 00, 00), new DateTime(2022, 4, 1, 20, 00, 00));
            Console.WriteLine(string.Format("{0:c}", yo));
            yo = fo.CalcFee(new DateTime(2022, 12, 25, 7, 00, 00), new DateTime(2022, 12, 25, 20, 00, 00));
            Console.WriteLine(string.Format("{0:c}", yo));
            yo = fo.CalcFee(new DateTime(2022, 12, 25, 23, 55, 00), new DateTime(2022, 12, 26, 10, 00, 00));
            Console.WriteLine(string.Format("{0:c}", yo));
            //party!!
            yo = fo.CalcFee(new DateTime(2021, 12, 31, 20, 00, 00), new DateTime(2022, 1, 3, 04, 00, 00));
            Console.WriteLine(string.Format("{0:c}", yo));
            //this will generate an exception, but will work if you comment out the current year exception
            yo = fo.CalcFee(new DateTime(2023, 12, 25, 23, 55, 00), new DateTime(2023, 12, 26, 10, 00, 00));
            Console.WriteLine(string.Format("{0:c}", yo));
        }
    }
}
