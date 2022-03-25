using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorSpecs
{
    public class StringCalculatorShould
    {
        [Test]
        public void return_0_when_input_string_is_empty()
        {
            var inputString = string.Empty;
            var stringCalculator = new StringCalculator.StringCalculator();

            var result = stringCalculator.Add(inputString);

            result.Should().Be(0);
        }

        [Test]
        public void return_string_as_a_number_when_input_string_is_only_one_number()
        {
            var inputString = "1";
            var stringCalculator = new StringCalculator.StringCalculator();

            var result = stringCalculator.Add(inputString);

            result.Should().Be(1);
        }
    }
}