using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03
{
    internal class Exercise6 : IExercise
    {
        public void Run()
        {
            //1.
            Stack<string> browserHistory = new Stack<string>();

            browserHistory.Push("google.com");
            browserHistory.Push("github.com");
            browserHistory.Push("stackoverflow.com");
            browserHistory.Push("youtube.com");
            browserHistory.Push("claude.ai");

            //2.
            Console.WriteLine($"Current page: {browserHistory.Peek()}");

            //3.
            Console.WriteLine("\nGoing back:");

            for (int i = 0; i < 3; i++)
            {
                string page = browserHistory.Pop();

                Console.WriteLine($"Leaving: {page}");
            }

            //4.
            Console.WriteLine($"\nCurrent page after going back: {browserHistory.Peek()}");

            //5.
            browserHistory.Clear();

            bool success = browserHistory.TryPop(out string lastPage);

            Console.WriteLine($"\nTryPop succeeded: {success}");
        }
    }
}
