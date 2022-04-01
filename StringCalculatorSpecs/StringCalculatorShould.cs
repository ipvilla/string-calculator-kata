using System;
using System.Linq;
using NUnit.Framework;

namespace StringCalculatorSpecs
{
    public class StringCalculatorShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void return_0_when_input_string_is_empty()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        public void return_sum_of_numbers_when_input_string_is_numbers_separated_by_commas(string inputNumbers, int expectedResult)
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add(inputNumbers);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void return_sum_of_numbers_when_input_string_is_numbers_separated_by_commas_and_carriage_returns()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void support_any_kind_of_indicated_delimiter()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void throw_exception_when_negative_number()
        {
            var stringCalculator = new StringCalculator();

            var ex = Assert.Throws<NegativesNotAllowed>(() => stringCalculator.Add("//;\n-1;2"));

            Assert.AreEqual("Negatives not allowed", ex.Message);
            Assert.AreEqual(-1, ex.Number);

        }
    }

    public class NegativesNotAllowed : Exception
    {
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

            var splitNumbers = numbers.Replace("\n", delimiter).Split(delimiter).ToList();
            return splitNumbers.Sum(int.Parse);
        }
    }
}