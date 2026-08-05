namespace Task03_CompileTimeError
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* It's wrong because it a compile time error
            int number = "7";
            */

            // Fix it :

            int number_01 = int.Parse("7");
            // OR
            int number_02 = Convert.ToInt32("10");

            Console.WriteLine(number_01);
            Console.WriteLine(number_02);
        }
    }
}
