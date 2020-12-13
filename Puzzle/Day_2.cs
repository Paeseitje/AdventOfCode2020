using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Puzzle
{
    class Day_2 : LoadData
    {
        public static int Puzzle1()
        {
            var input = LoadDataListAsStringList(2, 1);
            int result = 0;

            foreach (string line in input)
            {
                var range = line.Split(' ')[0];
                var minimum = Convert.ToInt32(range.Split('-')[0]);
                var max = Convert.ToInt32(range.Split('-')[1]);
                var pos = line.IndexOf(':');
                char letter = line.Substring(pos - 1, 1)[0];

                var password = line.Substring(line.LastIndexOf(" ") + 1);
                var aantal = password.Count(c => (c == letter));

                if (aantal >= minimum && aantal <= max)
                {
                    result = result + 1;
                }
            }

            return result;

        }
    }
}
