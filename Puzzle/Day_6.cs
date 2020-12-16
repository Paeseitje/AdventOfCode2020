using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_6 : LoadData
    {
        public static int Puzzle1()
        {
            List<string> input = LoadDataAsStringListBis(6, 2);

            int result = 0;

            foreach (string line in input)
            {
                string trim = Regex.Replace(line, " ", "");
                char[] chars = trim.ToCharArray();
                var dist = chars.Distinct();
                var positives = dist.Count();
                result += positives;
            }


            return result;
        }

        public static int Puzzle2()
        {
            var input = LoadDataAsStringListBis(6, 1);
            var result = 0;

            foreach (string line in input)
            {
                string trim = line.Trim();
                var list = trim.Split(" ");

                var numberOfGroups = list.Count();


               
                var dist = "";
                // if its more that 1 person, make answers for each person distinct
                // add answers together and get all answers that occure multiple times
                if (numberOfGroups > 1)
                {
                    dist = list.Aggregate((x, y) => string.Concat(x.Intersect(y)));
                    foreach (var item in dist) { Console.WriteLine(item); }

                    result += dist.Length;
                    Console.WriteLine("Result is now {0}", result);
                    Console.WriteLine(" ");
                }
                else
                {
                    result += list[0].Length;
                }

            }


            return result;
        }

        // not mine
        //public static int Puzzle2()
        //{
        //    return GetInputAsStringList(6, 1).Aggregate((x, y) => x + ":" + y).Split("::").Where(s => s.Length > 0).Select(s => s.Split(':').Aggregate((x, y) => string.Concat(x.Intersect(y))).Count()).Sum();
        //}
    }
}
