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
        public void return_input_string_as_number_when_input_string_is_only_one_number()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void return_sum_of_numbers_when_input_string_is_two_numbers_separated_by_comma()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void return_sum_of_numbers_when_input_string_is_three_numbers_separated_by_commas()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1,2,3");

            Assert.AreEqual(6, result);
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