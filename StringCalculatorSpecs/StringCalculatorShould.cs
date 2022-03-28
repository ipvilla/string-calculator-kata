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
            var stringCalculator = new StringCalculator.StringCalculator();

            var result = stringCalculator.Add("1");

            result.Should().Be(1);
        }

        [Test]
        public void return_zero_when_input_string_is_empty()
        {
            var stringCalculator = new StringCalculator.StringCalculator();

            var result = stringCalculator.Add("");

            result.Should().Be(0);
        }
    }
}