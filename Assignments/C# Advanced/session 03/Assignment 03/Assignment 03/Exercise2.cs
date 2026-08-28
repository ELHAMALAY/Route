using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_03
{
    internal class Exercise2 : IExercise
    {
        public void Run()
        {
            //1.
            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>();

            leaderboard.Add(500, "Ahmed");
            leaderboard.Add(200, "Sara");
            leaderboard.Add(800, "Ali");
            leaderboard.Add(350, "Mona");

            //2.
            Console.WriteLine("Leaderboard:");

            foreach(var player in leaderboard)
            {
                Console.WriteLine($"{player.Key} = {player.Value}");
            }

            //3.
            int firstKey = leaderboard.First().Key;
            string firstValue = leaderboard.First().Value;

            Console.WriteLine($"\nFirst Key: {firstKey}");
            Console.WriteLine($"First Value: {firstValue}");

            //4.
            bool has500 = leaderboard.ContainsKey(500);
            Console.WriteLine($"\nScore 500 exists: {has500}");

            //5.
            if(leaderboard.TryGetValue(999, out string playerName))
            {
                Console.WriteLine($"\nPlayer with score 999: {playerName}\n");
            }
            else
            {
                Console.WriteLine("\nPlayer with score 999: Not Found\n");
            }

            //6
            leaderboard.Remove(200);

            foreach(var player in leaderboard)
            {
                Console.WriteLine($"{player.Key} = {player.Value}");
            }
        }
    }
}
