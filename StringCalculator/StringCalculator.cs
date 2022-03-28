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
            return int.Parse(inputString);
        }
    }
}