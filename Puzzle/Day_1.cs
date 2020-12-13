using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Puzzle
{
    class Day_1 : LoadData
    {
        public static int Puzzle1()
        {
            var expences = LoadData.LoadDataColumnAsIntList(1,1);

            int check = 2020;
            int aantal = expences.Count;
            int result = 0;

            foreach (int expence in expences)
            {
                for (int i = 0; i < aantal; i++)
                {
                    int som = expence + expences[i];
                    if (som == check)
                    {
                        result = expence * expences[i];
                    }

                    i++;
                }

            }
            return result;
        }


        public static int Puzzle2()
        {
            var expences = LoadData.LoadDataColumnAsIntList(1, 2);

            int check = 2020;
            int aantal = expences.Count;
            int result = 0;

            foreach (int expence in expences)
            {
                for (int i = 0; i < aantal; i++)
                {
                    for (int j = 0; j < aantal; j++)
                    {
                        int som = expence + expences[i] + expences[j];
                        if (som == check)
                        {
                            result = expence * expences[i] * expences[j];
                        }
                        j++;
                    }
                }
            }
            return result;
        }
    }
}
