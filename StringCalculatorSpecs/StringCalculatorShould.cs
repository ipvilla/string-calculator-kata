using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorSpecs
{
    public class StringCalculatorShould
    {
        private StringCalculator.StringCalculator _stringCalculator;

        [SetUp]
        public void SetUp()
        {
            _stringCalculator = new StringCalculator.StringCalculator();
        }

        [Test]
        public void return_0_when_input_string_is_empty()
        {
            var inputString = string.Empty;

            var result = _stringCalculator.Add(inputString);

            result.Should().Be(0);
        }

        [Test]
        public void return_1_as_a_number_when_input_string_is_1()
        {
            const string inputString = "1";

            var result = _stringCalculator.Add(inputString);

            result.Should().Be(1);
        }

        [Test]
        public void return_2_as_a_number_when_input_string_is_2()
        {
            const string inputString = "2";

            var result = _stringCalculator.Add(inputString);

            result.Should().Be(2);
        }
    }
}