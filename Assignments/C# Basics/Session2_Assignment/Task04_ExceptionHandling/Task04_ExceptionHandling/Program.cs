namespace Task04_ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = 100;
            int number2 = 0;

            try
            {
                int divideResult = number1 / number2;
                Console.WriteLine(divideResult);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero");
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }
    }
}
