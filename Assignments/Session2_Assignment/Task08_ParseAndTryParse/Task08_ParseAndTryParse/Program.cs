namespace Task08_ParseAndTryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string yearText = "2023";
            int yearNum = int.Parse(yearText);
            Console.WriteLine(yearNum);

            string badText = "abc";

            if(int.TryParse(badText, out int number))
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Invalid number");
            }
        }
    }
}
