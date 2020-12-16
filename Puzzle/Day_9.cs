using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
	class Day_9 : LoadData
	{
		public static long Puzzle1()
		{
			//List<int> cijfers = new List<int>()
			//{35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576};
			long result = 0;

			var cijfers = LoadDataListAsLongList(9, 1);

			for (int i = 0; i < cijfers.Count - 25; i++)
			{
				List<long> FiveItems = new List<long>();
				FiveItems = cijfers.Skip(i).Take(25).ToList();
				var nextNr = cijfers[i + 25];

				//foreach (var item in FiveItems)
				//{
				//	Console.WriteLine(item.ToString());
				//}

				Console.WriteLine("Next nr = {0}", nextNr.ToString());

				// check if cijfer is som of any 2 dist cijfers in FiveItems
				List<long> s = new List<long>();
				for (int j = 0; j < FiveItems.Count; ++j)
				{
					long temp = nextNr - FiveItems[j];
					// checking for condition
					if (FiveItems.Contains(temp))
					{
						Console.Write("Pair with given sum " + nextNr + " is (" + FiveItems[j] + ", " + temp + ")");
						Console.WriteLine("");

						s.Add(FiveItems[j]);
					}
				}

				if (s.Count == 0)
				{
					Console.WriteLine("No match for this number: {0}", nextNr);
					Console.WriteLine("");
					result = nextNr;
					break;
				}

				if (s.Count > 1)
				{
					Console.WriteLine("All good for number: {0}", nextNr);
					Console.WriteLine("");
				}

				if (s.Count == 1 && (s[0] * 2) == nextNr)
				{
					Console.WriteLine("No match for this number: {0}", nextNr);
					Console.WriteLine("");
					result = nextNr;
					break;
				}
			}
			Console.WriteLine("First number to Fail: {0}", result);
			Console.WriteLine("");

			return result;
		}


		public static long Puzzle2()
        {
			int sum = 105950735;
			//List<int> cijfers = new List<int>()
			//{35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576};


			var cijfers = LoadDataListAsLongList(9, 1);
			var result_list = new List<long>();

			long curr_sum;
			int n = cijfers.Count;
			long result = 0;
			int min_index = -1;
			int max_index = -1;

			// Pick a starting point 
			for (int i = 0; i < n; i++)
			{
				curr_sum = cijfers[i];

				if (min_index != -1 && max_index != -1)
				{ break; }
				// try all subarrays 
				// starting with 'i' 
				for (int j = i + 1; j <= n; j++)
				{
					if (curr_sum == sum)
					{
						int p = j - 1;
						Console.Write("Sum found between "
									  + "indexes " + i + " and " + p);
						min_index = i;
						max_index = p;
						Console.WriteLine("min_index = {0}, max_index = {1}", min_index, max_index);

						for (int x = min_index; x <= max_index; x++)
						{
							result_list.Add(cijfers[x]);
						}

						result = result_list.Min() + result_list.Max();
						Console.WriteLine("Result is: {0}", result);
						break;
					}
					if (curr_sum > sum || j == n)
						break;
					curr_sum = curr_sum + cijfers[j];
				}
			}
			
			Console.Write("No subarray found");
			return result;
		}
	}
}

