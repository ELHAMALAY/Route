namespace Task11_NullableValueTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? year = null;

            Console.WriteLine(year.HasValue);

            year = 2023;

            Console.WriteLine(year.HasValue);
            Console.WriteLine(year);
        }
    }
}
