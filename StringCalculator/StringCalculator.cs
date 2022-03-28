using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return 0;
            }

            var numbers = inputString.Split(",");

            return numbers.Sum(number => int.Parse(number));
        }
    }
}