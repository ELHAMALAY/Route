namespace Task15_NullForgivingOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? name = "Youssef";
            string confirmedName = name!;

            Console.WriteLine(confirmedName);
        }
    }
}
