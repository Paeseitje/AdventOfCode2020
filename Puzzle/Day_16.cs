using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_16 : LoadData
    {
        public static int Puzzle1()
        {
            var input = LoadDataListAsIntListList(16, 1);
            var invalidValues = new List<int>();

            foreach(var ticket in input)
            {

                foreach (var value in ticket)
                {
                    if (
                        !((value >= 50 && value <= 688 || value >= 707 && value <= 966))
                        &&
                        !((value >= 33 && value <= 340 || value >= 351 && value <= 960))
                        &&
                        !((value >= 42 && value <= 79 || value >= 105 && value <= 954))
                        &&
                        !((value >= 46 && value <= 464 || value >= 482 && value <= 974))
                        &&
                        !((value >= 42 && value <= 464 || value >= 482 && value <= 974))
                        &&
                        !((value >= 25 && value <= 595 || value >= 614 && value <= 972))
                        &&
                        !((value >= 26 && value <= 483 || value >= 494 && value <= 962))
                        &&
                        !((value >= 31 && value <= 901 || value >= 913 && value <= 957))
                        &&
                        !((value >= 35 && value <= 721 || value >= 736 && value <= 958))
                        &&
                        !((value >= 44 && value <= 639 || value >= 661 && value <= 960))
                        &&
                        !((value >= 45 && value <= 391 || value >= 416 && value <= 969))
                        &&
                        !((value >= 46 && value <= 167 || value >= 186 && value <= 962))
                        &&
                        !((value >= 42 && value <= 312 || value >= 335 && value <= 969))
                        &&
                        !((value >= 36 && value <= 369 || value >= 375 && value <= 971))
                        &&
                        !((value >= 46 && value <= 870 || value >= 877 && value <= 972))
                        &&
                        !((value >= 49 && value <= 836 || value >= 846 && value <= 961))
                        &&
                        !((value >= 50 && value <= 442 || value >= 450 && value <= 970))
                        &&
                        !((value >= 37 && value <= 706 || value >= 715 && value <= 952))
                        &&
                        !((value >= 45 && value <= 674 || value >= 687 && value <= 962))
                        &&
                        !((value >= 40 && value <= 198 || value >= 219 && value <= 963))
                        )
                    {
                        Console.WriteLine("Value {0} is invalid", value);
                        invalidValues.Add(value);
                    }
                }
            }
            var result = invalidValues.Sum();

            return result;

        }

        public static int Puzzle2()
        {
            var input = LoadDataListAsIntListList(16, 1);
            var invalidValues = new List<int>();

            foreach (var ticket in input)
            {
                var validTicket = true;

                foreach (var value in ticket)
                {
                    if (
                        !((value >= 50 && value <= 688 || value >= 707 && value <= 966))
                        &&
                        !((value >= 33 && value <= 340 || value >= 351 && value <= 960))
                        &&
                        !((value >= 42 && value <= 79 || value >= 105 && value <= 954))
                        &&
                        !((value >= 46 && value <= 464 || value >= 482 && value <= 974))
                        &&
                        !((value >= 42 && value <= 464 || value >= 482 && value <= 974))
                        &&
                        !((value >= 25 && value <= 595 || value >= 614 && value <= 972))
                        &&
                        !((value >= 26 && value <= 483 || value >= 494 && value <= 962))
                        &&
                        !((value >= 31 && value <= 901 || value >= 913 && value <= 957))
                        &&
                        !((value >= 35 && value <= 721 || value >= 736 && value <= 958))
                        &&
                        !((value >= 44 && value <= 639 || value >= 661 && value <= 960))
                        &&
                        !((value >= 45 && value <= 391 || value >= 416 && value <= 969))
                        &&
                        !((value >= 46 && value <= 167 || value >= 186 && value <= 962))
                        &&
                        !((value >= 42 && value <= 312 || value >= 335 && value <= 969))
                        &&
                        !((value >= 36 && value <= 369 || value >= 375 && value <= 971))
                        &&
                        !((value >= 46 && value <= 870 || value >= 877 && value <= 972))
                        &&
                        !((value >= 49 && value <= 836 || value >= 846 && value <= 961))
                        &&
                        !((value >= 50 && value <= 442 || value >= 450 && value <= 970))
                        &&
                        !((value >= 37 && value <= 706 || value >= 715 && value <= 952))
                        &&
                        !((value >= 45 && value <= 674 || value >= 687 && value <= 962))
                        &&
                        !((value >= 40 && value <= 198 || value >= 219 && value <= 963))
                        )
                    {
                        Console.WriteLine("Value {0} is invalid", value);
                        invalidValues.Add(value);
                        validTicket = false;
                    }
                }
                if (!validTicket)
                {
                    ticket.Clear();
                }
            }
            var result = invalidValues.Sum();

            return result;

        }
    }
}


//if
//                        (
//                            !((value >= 1 && value <= 3) || (value >= 5 && value <= 7))
//                            &&
//                            !((value >= 6 && value <= 11) || (value >= 33 && value <= 44))
//                            &&
//                            !((value >= 13 && value <= 40) || (value >= 45 && value <= 50))
//                        )
//if(!((value >= 13 && value <= 40) || (value >= 45 && value <= 50)))