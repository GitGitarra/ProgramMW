using System;

namespace ProgramMW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RangeDatesDisplayer rangeDatesDisplayer = new RangeDatesDisplayer(args);
            rangeDatesDisplayer.DisplayRangeDates();
        }
    }
}
