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
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return 0;
        }
    }
}