namespace Task01_BookClassAndObject
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

            Book book = new Book{Title= "Chapter 4" , Pages= 21};

            object obj = book;

            Console.WriteLine(obj);

        }
    }
}
