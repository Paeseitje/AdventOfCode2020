using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_5 : LoadData
    {
        public static int Puzzle1()
        {
            var input = LoadDataListAsStringList(5, 1);
            
            var highest_Id = 0;

            foreach (string boardingpas in input)
            {
                var RowCode = boardingpas.Substring(0, 7);
                var ColumnCOde = boardingpas[7..];

                var row = Row(RowCode);
                var column = Column(ColumnCOde);

                var SeatId = (row * 8) + column;

                highest_Id = SeatId > highest_Id ? SeatId : highest_Id;
            }

            return highest_Id;
        }

        public static int Row(string RowCode)
        {
            var min = 0;
            var max = 127;
            var modifier = 64;

            Console.WriteLine("We are now at [ {0} - {1}]", min, max);

            char[] characters = RowCode.ToCharArray();
            // F = lower half
            // B = upper half

            var checks = 1;

            foreach (char letter in characters)
            {
                if (checks > 7)
                {
                    if (min != max)
                    {
                        // This is strange we should have found a seat by now
                        Console.WriteLine("Should have found a seat after 7 iterations");
                    }
                }

                switch (letter) 
                {
                    case 'F':
                        max -= modifier;
                        break;
                    case 'B':
                        min += modifier;
                        break;
                }
                Console.WriteLine("We are now at [ {0} - {1} ]", min, max);
                modifier /= 2;
                checks++;
            }

            int rownr = max;

            return rownr;
        }

        public static int Column(string ColumnCode)
        {
            int modifier = 4;
            int min = 0;
            int max = 7;

            char[] characters = ColumnCode.ToCharArray();

            foreach (char letter in characters)
            {
                switch (letter)
                {
                    case 'L':
                        max -= modifier;
                        break;
                    case 'R':
                        min += modifier;
                        break;
                }
                Console.WriteLine("We are now at [ {0} - {1} ]", min, max);
                modifier /= 2;
            }
            int columnr = max;
            return columnr;
        }

    }
}
