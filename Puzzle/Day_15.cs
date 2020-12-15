using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_15
    {
        public static int Puzzle1()
        {
            //var input = new List<int> { 2, 20, 0, 4, 1, 17 };
            int lastNmbrSpoken = 0;
            //var listSpokenNmnrs = new List<int> { 2, 20, 0, 4, 1, 17 };
            //var age;

            var spokenNmbrsDict = new Dictionary<int, List<int>>
            {
                {2 , new List<int>{1} },
                {20 ,  new List<int>{2} },
                {0,  new List<int>{3} },
                {4,  new List<int>{4} },
                {1,  new List<int>{5} },
                {17,  new List<int>{6} }
             };

            //var spokenNmbrsDict = new Dictionary<int, List<int>>
            //{
            //    {3 , new List<int>{1} },
            //    {1 ,  new List<int>{2} },
            //    {2,  new List<int>{3} },
            //    {0, new List<int>{4} }
            // };

            // last nmbr of start seq is 17 on turn 6
            // turn 7: lastnr is 17, first time -> so spoken nr is 0 : add to dict key 0 if exists
            // turn 8: last nr spoken is 0 on turn 7
            //          --> nmbr is not yet spoken -> add nmbr/turn to dict + last spoken nmbr = 0
            //          --> nmb is already spoken -> add turn to key + last spoken nmbr is last turn - previous turn

            for (int turn = 8; turn <= 30000000; turn++)
            {
                var previousTurn = turn - 1;

                // als laatste gesproken nr niet in de dict zit -> voeg toe aan dict
                if (!spokenNmbrsDict.ContainsKey(lastNmbrSpoken))
                {
                    spokenNmbrsDict.Add(lastNmbrSpoken, new List<int> { previousTurn });
                    lastNmbrSpoken = 0;
                }
                else
                {
                    spokenNmbrsDict[lastNmbrSpoken].Add(previousTurn);
                    var value_list = spokenNmbrsDict[lastNmbrSpoken];
                    var Lastitem = value_list[value_list.Count - 1];
                    var SecToLast = value_list[value_list.Count - 2];
                    lastNmbrSpoken = Lastitem - SecToLast;
                }
            }

            return lastNmbrSpoken;
        }
    }
}
