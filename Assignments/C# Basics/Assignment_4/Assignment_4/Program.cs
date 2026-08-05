using System;

namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question 1
            double[] prices1 = { 25.5, 40, 33.75 };
            Console.WriteLine(prices1[1]);
            #endregion

            #region Question 2
            int[,] shelfCopies =
            {
                {3,5},
                {1,4}
            };

            Console.WriteLine(shelfCopies[1, 0]);
            #endregion

            #region Question 3
            PrintWelcomeMessage();
            #endregion

            #region Question 4
            PrintBookTitle("Clean Code");
            #endregion

            #region Question 5
            int pages = 400;
            AddBonusPages(pages);

            Console.WriteLine(pages); // 400
            // عشان passed by value
            #endregion

            #region Question 6
            double[] prices2 = { 25.5, 40 };

            ApplyDiscount(prices2);

            Console.WriteLine(prices2[0]); // 20.5
            // بسبب ان ال Array Reference Type
            #endregion

            #region Question 7
            AddBonusPagesByRef(ref pages);

            Console.WriteLine(pages); // 450
            // عشان استخدمنا ref
            #endregion

            #region Question 8
            ReplaceArray(ref prices2);

            Console.WriteLine(prices2.Length);
            #endregion

            #region Question 9
            double price;

            if (TryGetPrice("Clean Code", out price))
            {
                Console.WriteLine($"Price: {price}");
            }
            else
            {
                Console.WriteLine("Book not found");
            }
            #endregion

            #region Question 10
            PrintBookInfo("Atomic Habits");

            PrintBookInfo("The Pragmatic Programmer", 350);
            #endregion

            #region Question 11
            PrintBookInfo(pages: 500, title: "Refactoring");
            #endregion

            #region Question 12
            PrintAllTitles(
                "Clean Code",
                "Atomic Habits",
                "The Pragmatic Programmer");
            #endregion
        }

        #region Methods

        // Question 3
        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Library!");
        }

        // Question 4
        static void PrintBookTitle(string title)
        {
            Console.WriteLine("Book title: " + title);
        }

        // Question 5
        static void AddBonusPages(int pages)
        {
            pages += 50;
        }

        // Question 6
        static void ApplyDiscount(double[] prices)
        {
            prices[0] -= 5;
        }

        // Question 7
        static void AddBonusPagesByRef(ref int pages)
        {
            pages += 50;
        }

        // Question 8
        static void ReplaceArray(ref double[] prices)
        {
            prices = new double[] { 10.0, 12.5, 15.0 };
        }

        // Question 9
        static bool TryGetPrice(string title, out double price)
        {
            if (title == "Clean Code")
            {
                price = 25.5;
                return true;
            }

            price = 0;
            return false;
        }

        // Question 10 & 11
        static void PrintBookInfo(string title, int pages = 300)
        {
            Console.WriteLine($"Title: {title}, Pages: {pages}");
        }

        // Question 12
        static void PrintAllTitles(params string[] titles)
        {
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }

        #endregion
    }
}