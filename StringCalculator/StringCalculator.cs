namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (inputString == string.Empty)
            {
                return 0;
            }
            return int.Parse(inputString);

        }
    }
}