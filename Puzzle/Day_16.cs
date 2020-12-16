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

            var aantalInput = input.Count;
            Console.WriteLine("Input contains {0} tickets", aantalInput);
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

            //Threads.RemoveAll(list => list.Count == 0);
            var cleandupInput = input.RemoveAll(list => list.Count == 0);

            var result = invalidValues.Sum();

            //departure location: 50-688 or 707-966
            //departure station: 33-340 or 351-960
            //departure platform: 42-79 or 105-954
            //departure track: 46-928 or 943-959
            //departure date: 42-464 or 482-974
            //departure time: 25-595 or 614-972

            Console.WriteLine("input list is cleaned");
            var aantalTicketsValid = input.Count;
            Console.WriteLine("Input now contains {0} tickets", aantalTicketsValid);

            int dep_location = -1;
            int dep_station = -1;
            int dep_platform = -1;
            int dep_track = -1;
            int dep_date = -1;
            int dep_time = -1;

            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine("We are at index {0}", i.ToString());
                var list_index = new List<int>();
                foreach (var ticket in input)
                {
                    list_index.Add(ticket[i]);
                }

                var dep_location_Valid = false;
                var dep_station_Valid = false;
                var dep_platform_Valid = false;
                var dep_track_Valid = false;
                var dep_date_Valid = false;
                var dep_time_Valid = false;

                // find dep_location index
                if (dep_location == -1)
                {
                    foreach (int nr in list_index)
                    {
                        Console.WriteLine(nr.ToString());
                        if ((nr >= 50 && nr <= 688) || (nr >= 707 && nr <= 966))
                        {
                            Console.WriteLine("Nr {0} is valid for dep_location", nr.ToString());
                            dep_location_Valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Nr {0} is not valid for dep_location", nr.ToString());
                            dep_location_Valid = false;
                            break;
                        }
                    }
                }
                
                // find dep_station index
                if (dep_station == -1)
                {
                    foreach (int nr in list_index)
                    {
                        //33-340 or 351-960
                        Console.WriteLine(nr.ToString());
                        if ((nr >= 33 && nr <= 340) || (nr >= 351 && nr <= 960))
                        {
                            Console.WriteLine("Nr {0} is valid for dep_station", nr.ToString());
                            dep_station_Valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Nr {0} is not valid for dep_station", nr.ToString());
                            dep_station_Valid = false;
                            break;
                        }
                    }
                }

                // find dep_platform index
                if (dep_platform == -1)
                {
                    foreach (int nr in list_index)
                    {
                        //42 - 79 or 105 - 954
                        Console.WriteLine(nr.ToString());
                        if ((nr >= 42 && nr <= 79) || (nr >= 105 && nr <= 954))
                        {
                            Console.WriteLine("Nr {0} is valid for dep_platform", nr.ToString());
                            dep_platform_Valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Nr {0} is not valid for dep_platform", nr.ToString());
                            dep_platform_Valid = false;
                            break;
                        }
                    }
                }

                // find dep_track index
                if (dep_track == -1)
                {
                    foreach (int nr in list_index)
                    {
                        //46-928 or 943-959
                        Console.WriteLine(nr.ToString());
                        if ((nr >= 46 && nr <= 928) || (nr >= 943 && nr <= 959))
                        {
                            Console.WriteLine("Nr {0} is valid for dep_track", nr.ToString());
                            dep_track_Valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Nr {0} is not valid for dep_track", nr.ToString());
                            dep_track_Valid = false;
                            break;
                        }
                    }
                }

                // find dep_date index
                if (dep_date == -1)
                {
                    foreach (int nr in list_index)
                    {
                        //42-464 or 482-974
                        Console.WriteLine(nr.ToString());
                        if ((nr >= 42 && nr <= 464) || (nr >= 482 && nr <= 974))
                        {
                            Console.WriteLine("Nr {0} is valid for dep_date", nr.ToString());
                            dep_date_Valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Nr {0} is not valid for dep_date", nr.ToString());
                            dep_date_Valid = false;
                            break;
                        }
                    }
                }

                // find dep_time index
                if (dep_time == -1)
                {
                    foreach (int nr in list_index)
                    {
                        //25-595 or 614-972
                        Console.WriteLine(nr.ToString());
                        if ((nr >= 25 && nr <= 595) || (nr >= 614 && nr <= 972))
                        {
                            Console.WriteLine("Nr {0} is valid for dep_time", nr.ToString());
                            dep_time_Valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Nr {0} is not valid for dep_time", nr.ToString());
                            dep_time_Valid = false;
                            break;
                        }
                    }
                }


                if (dep_location_Valid && dep_location == -1)
                {
                    dep_location = i;
                    Console.WriteLine("Index of dep_location is {0}", dep_location.ToString());
                }
                if (dep_station_Valid && dep_station == -1)
                {
                    dep_station = i;
                    Console.WriteLine("Index of dep_station is {0}", dep_station.ToString());
                }
                if (dep_platform_Valid && dep_platform == -1)
                {
                    dep_platform = i;
                    Console.WriteLine("Index of dep_platform is {0}", dep_platform.ToString());
                }
                if (dep_track_Valid && dep_track == -1)
                {
                    dep_track = i;
                    Console.WriteLine("Index of dep_track is {0}", dep_track.ToString());
                }
                if (dep_date_Valid && dep_date == -1)
                {
                    dep_date = i;
                    Console.WriteLine("Index of dep_time is {0}", dep_date.ToString());
                }
                if (dep_time_Valid && dep_time == -1)
                {
                    dep_time = i;
                    Console.WriteLine("Index of dep_time is {0}", dep_time.ToString());
                }


            }
            Console.WriteLine("dep_location Index = {0}", dep_location.ToString());
            Console.WriteLine("dep_station Index = {0}", dep_station.ToString());
            Console.WriteLine("dep_platform Index = {0}", dep_platform.ToString());
            Console.WriteLine("dep_track Index = {0}", dep_track.ToString());
            Console.WriteLine("dep_date Index = {0}", dep_date.ToString());
            Console.WriteLine("dep_time Index = {0}", dep_time.ToString());





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