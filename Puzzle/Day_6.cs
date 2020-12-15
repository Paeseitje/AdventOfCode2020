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


                if (numberOfGroups > 1)
                {
                    IEnumerable<char> CommonList = null;

                    for (int i = 0; i < numberOfGroups - 1; i++)
                    {
                        var dist_i = list[i].Distinct();
                        var dist_ii = list[i + 1].Distinct();
                        CommonList = dist_i.Intersect(dist_ii);
                    }
                    result += CommonList.Count();
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
