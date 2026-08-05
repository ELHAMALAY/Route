namespace Task13_NullConditionalOperator
{
    class Book
    {
        public string Title = "Chapter 4";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book? book = null;

            string? title = book?.Title;

            Console.WriteLine(title);
        }
    }
}
