using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_18 : LoadData
    {
        public static long Puzzle1()
        {
            //var input = "8 + ((9 * 7) + 2) + (4 * (9 * 3 * 9 + 3 + 8) + 6 + 5 + 8)";
            var input = LoadDataListAsStringList(18, 1);

            var list_results = new List<long>();
            foreach (string equation in input)
            {
                var result = Int64.Parse(SolvePart1(equation));
                Console.WriteLine("result of line is: {0}", result);
                list_results.Add(result);
            }

            long som = list_results.Sum();

            return som;

        }

        public static string SolvePart1(string input)
        {
            var homework = input.Replace(" ", "");

            while (homework.Contains("("))
            {
                var matches = new List<string>();
                Match match = null;
                match = Regex.Match(homework, @"\(([0-9+* ]+)\)");

                if(match.Success)
                {
                    string key = match.Groups[0].Value;
                    var test = Regex.Replace(key, @"[\(.\)]", "");
                    //Console.WriteLine(test);
                    matches.Add(test);
                    //homework.Replace(key, SolvePart1(matches[0]));
                    var replace = SolvePart1(matches[0]);
                    homework = homework.Replace(key, replace);
                }
            }

            // split formula but keep operators
            string regex = "([+*])";
            var items = Regex.Split(homework, regex).ToList();
            //var items = homework.Select(c => c.ToString()).ToList();
            //var operators = "";
            
            while(items.Count > 1)
            {
                var number_1 = long.Parse(items[0]);
                items.RemoveAt(0);
                var operators = items[0];
                items.RemoveAt(0);
                var number_2 = long.Parse(items[0]);
                items.RemoveAt(0);
                long value = -1;
                if (operators == "+")
                { value = number_1 + number_2; }
                if (operators == "*")
                { value = number_1 * number_2; }
                items.Insert(0, value.ToString());
            }

            return items[0].ToString();
        }
        

        public static long Puzzle2()
        {
            //var input = "8 + ((9 * 7) + 2) + (4 * (9 * 3 * 9 + 3 + 8) + 6 + 5 + 8)";

            //var result = long.Parse(SolvePart2(input));

            //return result;

            var input = LoadDataListAsStringList(18, 1);

            var list_results = new List<long>();
            foreach (string equation in input)
            {
                var result = Int64.Parse(SolvePart2(equation));
                Console.WriteLine("result of line is: {0}", result);
                list_results.Add(result);
            }

            long som = list_results.Sum();

            return som;
        }

        public static string SolvePart2(string input)
        {
            var homework = input.Replace(" ", "");

            while (homework.Contains("("))
            {
                var matches = new List<string>();
                Match match = null;
                match = Regex.Match(homework, @"\(([0-9+* ]+)\)");

                if (match.Success)
                {
                    string key = match.Groups[0].Value;
                    var test = Regex.Replace(key, @"[\(.\)]", "");
                    //Console.WriteLine(test);
                    matches.Add(test);
                    //homework.Replace(key, SolvePart1(matches[0]));
                    var replacement = SolvePart2(matches[0]);
                    homework = homework.Replace(key, replacement);
                }
            }

            // zolang er + in het huiswerk zit, substring de som, los ze op en replace de som met het resultaat
            while (homework.Contains("+"))
            {
                var huiswerk_som = Regex.Match(homework, @"([0-9]{1,}[+][0-9]{1,})").Value;
                var items = huiswerk_som.Split("+").ToList();
                while (items.Count > 1)
                {
                    var number_1 = long.Parse(items[0]);
                    items.RemoveAt(0);
                    var number_2 = long.Parse(items[0]);
                    items.RemoveAt(0);
                    long value = number_1 + number_2; 
                    items.Insert(0, value.ToString());
                }
                homework = homework.Replace(huiswerk_som, items[0]);
            }

            // zolang er * in het huiswerk zit, substring de vermenigvuldiging, los ze op en replace deze met het resultaat
            while (homework.Contains("*"))
            {
                var huiswerk_som = Regex.Match(homework, @"([0-9]{1,}[*][0-9]{1,})").Value;
                var items = huiswerk_som.Split("*").ToList();
                while (items.Count > 1)
                {
                    var number_1 = long.Parse(items[0]);
                    items.RemoveAt(0);
                    var number_2 = long.Parse(items[0]);
                    items.RemoveAt(0);
                    long value = number_1 * number_2;
                    items.Insert(0, value.ToString());
                }
                homework = homework.Replace(huiswerk_som, items[0]);
            }

            return homework.ToString();
        }
    }
}
