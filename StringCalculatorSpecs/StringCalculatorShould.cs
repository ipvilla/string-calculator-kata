using System;
using NUnit.Framework;
using FluentAssertions;

namespace StringCalculatorSpecs
{
    public class StringCalculatorShould
    {
        [Test]
        public void return_0_when_input_string_is_empty()
        {
            var inputString = string.Empty;
            StringCalculator stringCalculator = new StringCalculator();

            var result = stringCalculator.Add(inputString);

            result.Should().Be(0);
        }
    }

    public class StringCalculator
    {
        public int Add(string inputString)
        {
            return 0;
        }
    }
}