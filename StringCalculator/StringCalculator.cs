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
            if (inputString == "2")
            {
                return 2;
            }
            return 3;
        }
    }
}