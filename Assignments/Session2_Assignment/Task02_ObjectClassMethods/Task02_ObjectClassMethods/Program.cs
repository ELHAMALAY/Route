namespace Task02_ObjectClassMethods
{
    class Book
    {
        public string Title;
        public int Pages;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book {Title = "Chapter 4", Pages = 21};

            Console.WriteLine(book.ToString());
            Console.WriteLine(book.Equals(book));
            Console.WriteLine(book.GetHashCode());
            Console.WriteLine(book.GetType());
        }
    }
}
