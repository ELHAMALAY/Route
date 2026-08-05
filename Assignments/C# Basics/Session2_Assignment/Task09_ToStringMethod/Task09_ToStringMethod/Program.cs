namespace Task09_ToStringMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = 464;
            string text = pages.ToString();

            Console.WriteLine(text);
            Console.WriteLine(text.GetType());
        }
    }
}
