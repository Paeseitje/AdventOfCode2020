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


        public static int Puzzle2()
        {
            var input = LoadDataListAsStringList(2, 1);
            int result = 0;

            foreach (string line in input)
            {
                var password = line.Substring(line.LastIndexOf(" ") + 1);
                var range = line.Split(' ')[0];
                var pos_1 = Convert.ToInt32(range.Split('-')[0]);
                var pos_2 = Convert.ToInt32(range.Split('-')[1]);

                var pos_1_abs = pos_1 - 1;
                var pos_2_abs = pos_2 - 1;

                var char_pos_1 = password.Substring(pos_1_abs , 1)[0];
                var char_pos_2 = password.Substring(pos_2_abs, 1)[0];

                var pos = line.IndexOf(':');
                char letter = line.Substring(pos - 1, 1)[0];

                if ((char_pos_1 == letter && char_pos_2 != letter) || (char_pos_1 != letter && char_pos_2 == letter))
                {
                    result += 1;
                }

            }

            return result;
        }
    }
}
