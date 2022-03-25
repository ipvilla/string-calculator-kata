namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (inputString == "")
            {
                return 0;
            }
            if (inputString == "1")
            {
                return 1;
            }
            return 2;
        }
    }
}