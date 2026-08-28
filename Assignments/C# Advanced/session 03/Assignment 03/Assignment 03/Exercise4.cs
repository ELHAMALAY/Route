using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03
{
    internal class Exercise4 : IExercise
    {
        public void Run()
        {
            //1.
            HashSet<string> emails = new HashSet<string>(
                StringComparer.OrdinalIgnoreCase
             );

            //2.
            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            //3.
            Console.WriteLine($"Email Count: {emails.Count}"); // Email Count: 2
            /*
             
            */

            //4
            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            //5.
                // Union
            HashSet<int> union = new HashSet<int>(setA);
            union.UnionWith(setB);

            Console.Write("Union:");
            Console.WriteLine(string.Join(", ", union));

                // Intersection
            HashSet<int> intersection = new HashSet<int>(setA);
            intersection.IntersectWith(setB);

            Console.Write("Intersection:");
            Console.WriteLine(string.Join(", ", intersection));

                // Except
            HashSet<int> except = new HashSet<int>(setA);
            except.ExceptWith(setB);

            Console.Write("Except:");
            Console.WriteLine(string.Join(", ", except));

            //6.
            HashSet<int> subset = new HashSet<int> { 1, 2 };

            bool isSubset = subset.IsSubsetOf(setA);
            Console.WriteLine($"{{1, 2}} is subset of Set A: {isSubset}");
        }
    }
}
