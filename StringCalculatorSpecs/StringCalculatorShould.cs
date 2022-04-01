using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace StringCalculatorSpecs
{
    public class StringCalculatorShould
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void return_0_when_input_string_is_empty()
        {
            var result = _stringCalculator.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        public void return_sum_of_numbers_when_input_string_is_numbers_separated_by_commas(string inputNumbers, int expectedResult)
        {
            var result = _stringCalculator.Add(inputNumbers);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void return_sum_of_numbers_when_input_string_is_numbers_separated_by_commas_and_carriage_returns()
        {
            var result = _stringCalculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void support_any_kind_of_indicated_delimiter()
        {
            var result = _stringCalculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void throw_exception_when_negative_number()
        {
            var ex = Assert.Throws<NegativesNotAllowedException>(() => _stringCalculator.Add("//;\n-1;2"));

            Assert.AreEqual("Negatives not allowed", ex.Message);
            Assert.AreEqual(-1, ex.Number);
        }

        [Test]
        public void throw_exception_when_two_negative_numbers_and_show_numbers_in_exception_message()
        {
            var ex = Assert.Throws<NegativesNotAllowedException>(() => _stringCalculator.Add("//;\n-1;-2"));

            Assert.AreEqual("Negatives not allowed: -1, -2", ex.Message);
            Assert.AreEqual(0, ex.Number);
        }
    }

    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(int number, string message) : base(message)
        {
            Number = number;
        }

        public int Number { get; set; }
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var delimiter = ",";
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;
            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2].ToString();
                numbers = numbers.Substring(4);
            }

            var splitNumbers = SplitNumbers(numbers, delimiter);
            var negativeNumbers = GetNegativeNumbers(splitNumbers);

            if (negativeNumbers.Any())
            {
                var negativesNotAllowedException = BuildException(negativeNumbers);
                throw negativesNotAllowedException;
            }

            return splitNumbers.Sum(int.Parse);
        }

        private static NegativesNotAllowedException BuildException(IEnumerable<int> negativeNumbers)
        {
            var negativeNumbersCount = negativeNumbers.Count();
            var exceptionMessage = "Negatives not allowed";
            var exceptionArgument = negativeNumbersCount > 1 ? 0 : negativeNumbers.FirstOrDefault();
            exceptionMessage += negativeNumbersCount > 1 ? ": " + string.Join(", ", negativeNumbers) : "";
            
            return new NegativesNotAllowedException(exceptionArgument, exceptionMessage);
        }

        private static List<int> GetNegativeNumbers(List<string> splitNumbers)
        {
            var negativeNumbers = splitNumbers.Where(x => int.Parse(x) < 0).Select(int.Parse);
            return negativeNumbers.ToList();
        }

        private static List<string> SplitNumbers(string numbers, string delimiter)
        {
            var splitNumbers = numbers.Replace("\n", delimiter).Split(delimiter).ToList();
            return splitNumbers;
        }
    }
}