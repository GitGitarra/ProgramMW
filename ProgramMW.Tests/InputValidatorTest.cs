using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgramMW.Tests
{
    [TestClass]
    public class InputValidatorTest
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void NoArgumentsPassedThrowsIndexOutOfRangeExeption()
        {
            string[] args = new string[] { };
            InputValidator inputValidator = new InputValidator(args);
        }

        [TestMethod]
        public void NoArgumentsPassedThrowsIndexOutOfRangeExeptionUsingTryCatch()
        {
            try
            {
                string[] args = new string[] { };
                InputValidator inputValidator = new InputValidator(args);

            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
            Assert.Fail("No aruments passed did not throw IndexOutOfRangeException");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void OneArgumentPassedThrowIndexOutOfRangeException()
        {
            string[] args = new string[] { "01.01.2000" };
            InputValidator inputValidator = new InputValidator(args);
        }

        [TestMethod]
        public void FisrstArgumentInvalidPassedReturnFalse()
        {
            string[] args = new string[] { "101010", "01.01.2000" };
            InputValidator inputValidator = new InputValidator(args);
            Assert.IsFalse(inputValidator.IsValidInput());
        }

        [TestMethod]
        public void SecondArgumentInvalidPassedReturnFalse()
        {
            string[] args = new string[] { "01.01.2000", "101010" };
            InputValidator inputValidator = new InputValidator(args);
            Assert.IsFalse(inputValidator.IsValidInput());
        }

        [TestMethod]
        public void TwoArgumentInvalidPassedReturnFalse()
        {
            string[] args = new string[] { "01.012000", "101010" };
            InputValidator inputValidator = new InputValidator(args);
            Assert.IsFalse(inputValidator.IsValidInput());
        }

        [TestMethod]
        public void MonthDayFormatReturnFalse()
        {
            string[] args = new string[] { "05.22.2017", "01.01.2017" };
            InputValidator inputValidator = new InputValidator(args);
            Assert.IsFalse(inputValidator.IsValidInput());
        }

        [TestMethod]
        public void OneDigitDayReturnFalse()
        {
            string[] args = new string[] { "5.02.2017", "01.05.2017" };
            InputValidator inputValidator = new InputValidator(args);
            Assert.IsFalse(inputValidator.IsValidInput());
        }

        [TestMethod]
        public void OneDigitMonthReturnFalse()
        {
            string[] args = new string[] { "15.2.2017", "01.11.2017" };
            InputValidator inputValidator = new InputValidator(args);
            Assert.IsFalse(inputValidator.IsValidInput());
        }

        [TestMethod]
        public void YearMonthDayFormatReturnFalse()
        {
            string[] args = new string[] { "2017.02.22", "2018.05.14" };
            InputValidator inputValidator = new InputValidator(args);
            Assert.IsFalse(inputValidator.IsValidInput());
        }
    }
}
