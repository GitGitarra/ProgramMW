using System;

namespace ProgramMW
{
    public class RangeDatesDisplayer
    {
        private string[] _args;

        public RangeDatesDisplayer(string[] args)
        {
            _args = args;
        }

        public void DisplayRangeDates()
        {
            try
            {
                InputValidator userArguments = new InputValidator(_args);

                if (userArguments.IsValidInput())
                {
                    userArguments.ParseToDates();
                    if (userArguments.CheckIfDatesChoronoligic())
                    {
                        userArguments.ViewDates();
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                FormatView.InvalidInputMsg();
            }
            FormatView.EndMsg();
        }
    }
}
