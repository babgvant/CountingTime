using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingTime
{
    public class FigureItOut
    {
        private double highRate = 0.25;
        private double lowRate = 0.10;
        private List<DateTime> freeHolidays = new List<DateTime>();
        private int currentYear = DateTime.Now.Year;
       
        public FigureItOut()
        {
            //should pull from a db or something
            freeHolidays.Add(new DateTime(currentYear, 12, 25)); //xmas
            freeHolidays.Add(new DateTime(currentYear + 1, 01, 01));
        }

        public double CalcFee(DateTime timeIn, DateTime timeOut)
        {
            //highRate M-F 9am-5pm, lowRate M-F 6pm-10pm
            DateTime loopTime = timeIn;
            double runningTotal = 0;
            //TODO: test this for a date span that cross year boundry
            if (timeIn.Year > currentYear || timeOut.Year > currentYear
            || timeIn.Year < currentYear - 1 || timeOut.Year < currentYear - 1)
            {
                throw new Exception("INVALID DATE!!!");
            }

            while (loopTime < timeOut)
            {
                //we only care about 30 min increments
                if ((int)loopTime.DayOfWeek > 0 && (int)loopTime.DayOfWeek < 6)
                {
                    bool isHoliday = freeHolidays.Any(holiday => holiday.Month == loopTime.Month && holiday.Day == holiday.Day);
                    if (!isHoliday)
                    {
                        if (loopTime.Hour >= 9 && loopTime.Hour < 17)
                        {
                            runningTotal += highRate / 12;
                        }
                        else if (loopTime.Hour >= 18 && loopTime.Hour < 22)
                        {
                            runningTotal += lowRate / 12;
                        }
                    }
                }
                loopTime = loopTime.AddMinutes(5);
            }

            return runningTotal;
        }
    }
}
