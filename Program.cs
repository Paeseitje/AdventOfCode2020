using AdventOfCode2020.Puzzle;
using System;

namespace AdventOfCode2020
{
    class Program : LoadData
    {
        public const string INPUT_FILE_DIR = "Input/Day_";

        static void Main(string[] args)
        {

            int day = 22;
            int puzzle = 2;

            if (puzzle == 1)
            {
                Console.WriteLine("Starting puzzle 1");
                var solve1 = Day_22.Puzzle1();
                Console.WriteLine("Solution to puzzle 1 of day {0}: {1}", day, solve1);
            }
            else
            {
                Console.WriteLine("Starting puzzle 2");
                var solve2 = Day_22.Puzzle2();
                Console.WriteLine("Solution to puzzle 2 of day {0}: {1}", day, solve2);
            }
        }
    }
}
