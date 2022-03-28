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
            if (inputString.Contains(","))
            {
                var sum = 0;
                var numbers = inputString.Split(",");
                for(int i = 0 ; i < numbers.Length; i++)
                {
                    sum += int.Parse(numbers[i]);
                }

                return sum;
            }
            return int.Parse(inputString);
        }
    }
}