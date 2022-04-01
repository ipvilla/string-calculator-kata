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
        public void return_input_string_as_number_when_input_string_is_numbers_separated_by_commas(string inputNumbers, int expectedResult)
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add(inputNumbers);

            Assert.AreEqual(expectedResult, result);
        }
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            var splitNumbers = numbers.Split(",").ToList();
            return splitNumbers.Sum(int.Parse);
        }
    }
}