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
            return int.Parse(inputString);
        }
    }
}