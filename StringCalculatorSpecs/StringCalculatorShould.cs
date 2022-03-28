using FluentAssertions;
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
        public void return_number_when_only_one_number_in_input_string()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1");

            result.Should().Be(1);
        }
    }

    public class StringCalculator
    {
        public int Add(string inputString)
        {
            throw new System.NotImplementedException();
        }
    }
}