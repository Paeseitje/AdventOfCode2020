using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_23
    {
        public static long Puzzle1()
        {
            var input = new List<int>() 
            //{ 5, 8, 6, 4, 3, 9, 1, 7, 2 };

            //test case : na 10x 92658374, na 100x 67384529
            { 3, 8, 9, 1, 2, 5, 4, 6, 7 };

            var iterations = 10;

            // starting position
            var current_cup = 3;

            // keep track of relative position in the list, so you can go back to ind 0 at the end of the list
            var index = 0;

            for (int i = 1; i <= iterations; i++)
            {
                Console.WriteLine("Round {0}:", i);
                Console.WriteLine("cups: {0}",string.Join(" ", input));
                // index of current cup
                var index_current = input.IndexOf(current_cup);
                var take_3 = new List<int>();

                if (index_current < 6)
                {
                    take_3 = input.Skip(index_current + 1).Take(3).ToList();
                    Console.WriteLine("Pick up: {0}", string.Join(" ", take_3));
                }
                else if (index_current == 6)
                {
                    take_3 = input.Skip(index_current + 1).Take(2).ToList();
                    take_3.Add(input[0]);
                    Console.WriteLine("Pick up: {0}", string.Join(" ", take_3));
                }
                else if (index_current == 7)
                {
                    take_3.Add(input[8]);
                    take_3.Add(input[0]);
                    take_3.Add(input[1]);
                    Console.WriteLine("Pick up: {0}", string.Join(" ", take_3));
                }
                else
                {
                    take_3 = input.Take(3).ToList();
                    Console.WriteLine("Pick up: {0}", string.Join(" ", take_3));
                }


                // delete the 3 items from the list
                foreach (int item in take_3)
                {
                    input.Remove(item);
                }

                // detirmine the destination (index value in shortned list) of where the 3 items needs to be put
                // current - 1 (if in list) -> keep checking untill the number is less then the lowest number available then pick the highest number available as dsetination

                var destination_index = DetermineDestination(input, current_cup) + 1;
                Console.WriteLine("Destination: {0}", input[destination_index -1]);

                if (destination_index < input.Count -1)
                {
                    
                    for (int tk = 0; tk < 3; tk++)
                    {
                        input.Insert(destination_index, take_3[tk]);
                        destination_index += 1;
                    }
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        input.Add(take_3[j]);
                    }
                }
                Console.WriteLine("New cups order: {0}", string.Join(" ", input));


                //index += 1;

                if (index < 8)
                {
                    var new_cup_index = input.IndexOf(current_cup) + 1;
                    if (new_cup_index < 8)
                    {
                        current_cup = input[new_cup_index];
                        Console.WriteLine("New current cup : {0}", current_cup.ToString());
                        index += 1;
                    }
                    else
                    {
                        current_cup = input[0];
                        Console.WriteLine("New current cup : {0}", current_cup.ToString());
                        index += 1;
                    }
                }
                else
                {
                    current_cup = input[0];
                    Console.WriteLine("New current cup : {0}", current_cup.ToString());
                    index = 0;
                }
            }

            // order of cups starting at 1 without 1

            var pos_of_1 = input.IndexOf(1);
            var answer = new List<int>();
            if (pos_of_1 < 8)
            {
                // first part
                answer = input.Skip(pos_of_1 + 1).ToList();
                var aantal_resterend = pos_of_1;
                var rest = input.Take(aantal_resterend).ToList();
                answer.AddRange(rest);
            }
            else
            {
                answer = input.Take(8).ToList();
            }
            var result = long.Parse(string.Join("", answer));
            return result;
        }

        public static int DetermineDestination(List<int> shortnedList, int current_cup)
        {
            int destination = current_cup - 1;
            int max = shortnedList.Max();
            int min = shortnedList.Min();

            int destination_index;

            while (destination >= min)
            {
                if (shortnedList.Contains(destination))
                {
                    destination_index = shortnedList.IndexOf(destination);
                    return destination_index;
                }
                else
                {
                    destination -= 1;
                }
            }

            destination = max;
            destination_index = shortnedList.IndexOf(destination);

            return destination_index;
        }

        public static int Puzzle2()
        {
            int result = 0;
            return result;
        }
    }
}
