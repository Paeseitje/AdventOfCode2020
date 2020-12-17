using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_10 : LoadData
    {
        public static int Puzzle1()
        {
			//var input = new List<int>()
			//{16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4};

			//{28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3};

			var input = LoadDataListAsIntList(10, 1);

			input.Sort();

			foreach (int nr in input) { Console.WriteLine(nr.ToString()); }

			int diff_1 = 0;
			int diff_3 = 0;
			int current_adapter = 0;

			for (int i = 0; i < input.Count; i++)
			{
				Console.WriteLine("We are at index {0}", i);
				int difference = input[i] - current_adapter;
				if (difference == 1)
				{
					diff_1 = diff_1 + 1;
					Console.WriteLine("diff_1 = {0}", diff_1);
					current_adapter = input[i];
					Console.WriteLine("current adaptor = {0}", current_adapter);

				}
				if (difference == 3)
				{
					diff_3 = diff_3 + 1;
					Console.WriteLine("diff_3 = {0}", diff_3);
					current_adapter = input[i];
					Console.WriteLine("current adaptor = {0}", current_adapter);
				}

				if (current_adapter == input[input.Count - 1])
				{
					diff_3 = diff_3 + 1;
					current_adapter = current_adapter + 3;
					Console.WriteLine("This was the last iteration");
					Console.WriteLine("Current adapter is now at {0}", current_adapter);

					break;
				}
			}

			Console.WriteLine("Diff_1 = {0}", diff_1);
			Console.WriteLine("Diff_3 = {0}", diff_3);
			int result = diff_1 * diff_3;
			Console.WriteLine(result.ToString());

			return result;
		}

    }
}
