using System;
using System.Collections.Generic;

namespace ProgramMW
{
    static class FormatView
    {

        static public void DispalyResult(List<DateTime> validDates, DatesFormat format)
        {
            DateTime startDate = validDates[0];
            DateTime endDate = validDates[1];

            switch (format)
            {
                case DatesFormat.FullDates:
                    Console.WriteLine(startDate.ToShortDateString() + " - " + endDate.ToShortDateString());
                    break;
                case DatesFormat.DaysMonthsYear:
                    Console.WriteLine($"{startDate:dd}.{startDate:MM} - " + endDate.ToShortDateString());
                    break;
                case DatesFormat.DaysMonthYear:
                    Console.WriteLine($"{startDate:dd} - " + endDate.ToShortDateString());
                    break;
                case DatesFormat.OneDate:
                    Console.WriteLine(startDate.ToShortDateString());
                    break;
            }
        }

        static public void InvalidInputMsg()
        {
            Console.WriteLine("Invalid inputs. Please insert two dates in format dd.mm.yyyy");
        }

        static public void EndMsg()
        {
            Console.WriteLine("Press any key to exit:");
            Console.ReadKey();
        }
    }
}
