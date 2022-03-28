using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorSpecs
{
    public class StringCalculatorShould
    {
        private StringCalculator.StringCalculator _stringCalculator;

        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator.StringCalculator();
        }

        [Test]
        public void return_number_when_only_one_number_in_input_string()
        {
            var result = _stringCalculator.Add("1");

            result.Should().Be(1);
        }

        [Test]
        public void return_zero_when_input_string_is_empty()
        {
            var result = _stringCalculator.Add("");

            result.Should().Be(0);
        }
    }
}