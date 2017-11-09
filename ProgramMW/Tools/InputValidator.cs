using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProgramMW
{
    public class InputValidator
    {
        private string _dateOne;
        private string _dateTwo;
        private List<DateTime> _validDates = new List<DateTime>();

        public InputValidator(string[] userInput)
        {
            try
            {
                _dateOne = userInput[0];
                _dateTwo = userInput[1];
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
        }

        public bool IsValidInput()
        {
            Regex rgx = new Regex(@"(0[1-9]|[12][0-9]|3[01])[\/\.](0[1-9]|1[012])[\/\.]\d{4}");
            if (rgx.IsMatch(_dateOne) && rgx.IsMatch(_dateTwo))
            {
                return true;
            }
            FormatView.InvalidInputMsg();
            return false;
        }

        public void ParseToDates()
        {
            DateTime validStratDate = DateTime.Parse(_dateOne);
            _validDates.Add(validStratDate);
            DateTime validEndDate = DateTime.Parse(_dateTwo);
            _validDates.Add(validEndDate);
        }

        public bool CheckIfDatesChoronoligic()
        {
            DateTime startDate = _validDates[0];
            DateTime endDate = _validDates[1];

            int result = DateTime.Compare(startDate, endDate);
            if (result > 0)
            {
                Console.WriteLine("Start date must be earlier than end date.");
                return false;
            }
            return true;
        }

        public void ViewDates()
        {
            DateTime startDate = _validDates[0];
            DateTime endDate = _validDates[1];
            bool yearsSame = startDate.Year == endDate.Year;
            bool monthsSame = startDate.Month == endDate.Month;
            bool daysSame = startDate.Day == endDate.Day;

            if (!yearsSame)
            {
                FormatView.DispalyResult(_validDates, DatesFormat.FullDates);
            }
            else if (yearsSame && !monthsSame)
            {
                FormatView.DispalyResult(_validDates, DatesFormat.DaysMonthsYear);
            }
            else if (yearsSame && monthsSame && !daysSame)
            {
                FormatView.DispalyResult(_validDates, DatesFormat.DaysMonthYear);
            }
            else FormatView.DispalyResult(_validDates, DatesFormat.OneDate);
        }
    }
}
