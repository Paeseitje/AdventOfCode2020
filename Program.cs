using AdventOfCode2020.Puzzle;
using System;

namespace AdventOfCode2020
{
    class Program : LoadData
    {
        public const string INPUT_FILE_DIR = "Input/Day_";

        static void Main(string[] args)
        {

            int day = 15;

            Console.WriteLine("Starting puzzle 1");
            var solve1 = Day_15.Puzzle1();
            Console.WriteLine("Solution to puzzle 1 of day {0}: {1}", day, solve1);

            //Console.WriteLine("Starting puzzle 2");
            //int solve2 = Day_4.Puzzle2();
            //Console.WriteLine("Solution to puzzle 2 of day {0}: {1}", day, solve2);
        }
    }
}
