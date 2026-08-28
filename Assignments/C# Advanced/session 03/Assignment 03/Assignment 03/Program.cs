using System.Collections.Generic;
using System.Linq;
namespace Assignment_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Exercise 1 ==========");
            IExercise exercise1 = new Exercise1();
            exercise1.Run();

            Console.WriteLine("\n========== Exercise 2 ==========");
            IExercise exercise2 = new Exercise2();
            exercise2.Run();

            Console.WriteLine("\n========== Exercise 3 ==========");
            IExercise exercise3 = new Exercise3();
            exercise3.Run();

            Console.WriteLine("\n========== Exercise 4 ==========");
            IExercise exercise4 = new Exercise4();
            exercise4.Run();

            Console.WriteLine("\n========== Exercise 5 ==========");
            IExercise exercise5 = new Exercise5();
            exercise5.Run();

            Console.WriteLine("\n========== Exercise 6 ==========");
            IExercise exercise6 = new Exercise6();
            exercise6.Run();
        }
    }
}
