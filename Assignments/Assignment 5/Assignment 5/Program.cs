using System;

namespace CSharpAssignment
{
    enum Genre
    {
        Fiction,
        NonFiction,
        Science
    }

    class Book
    {
        // Question 1
        private string password = "secret";

        // Question 2
        internal int copiesInStock = 5;

        // Question 3
        public string Title;

        // Question 4
        public Genre Genre { get; set; } = Genre.Science;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();

            #region Question 1

            // Console.WriteLine(book.password);

            /*
              This line does not compile Because password is private, so it can only be accessed
              from inside the Book class
             */

            #endregion


            #region Question 2

            Console.WriteLine($"Copies In Stock: {book.copiesInStock}");

            /*
              Yes, it compiles Because internal members are accessible anywhere
              inside the same project (assembly)
             */

            #endregion


            #region Question 3 

            book.Title = "Clean Code";
            Console.WriteLine($"Title: {book.Title}");

            #endregion


            #region Question 4 

            Console.WriteLine($"Genre: {book.Genre}");

            #endregion


            #region Question 5 

            Console.WriteLine((int)Genre.Fiction);
            Console.WriteLine((int)Genre.NonFiction);
            Console.WriteLine((int)Genre.Science);

            #endregion


            #region Question 6 

            int genreNumber = 1;
            Genre genreFromNumber = (Genre)genreNumber;

            Console.WriteLine(genreFromNumber);

            #endregion


            #region Question 7 

            Genre genre = Genre.Fiction;
            string genreString = genre.ToString();

            Console.WriteLine(genreString);

            #endregion


            #region Question 8

            string genreText = "Science";

            Genre parsedGenre = (Genre)Enum.Parse(typeof(Genre), genreText);

            Console.WriteLine(parsedGenre);

            #endregion


            #region Question 9 

            string invalidGenre = "Mystery";

            if (Enum.TryParse(invalidGenre, out Genre result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Unknown genre");
            }

            #endregion
        }
    }
}