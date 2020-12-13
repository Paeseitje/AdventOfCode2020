using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_4 : LoadData
    {

        public static int Puzzle1()
        {
            var input = LoadDataAsStringListBis(4, 1);
            var result = 0;

            var abbrs = new List<string>
            {
                  "ecl"
                , "pid"
                , "eyr"
                , "hcl"
                , "byr"
                , "iyr"
                //, "cid"
                , "hgt"
            };


            foreach (string passport in input)
            {
                var contains_ecl = passport.Contains("ecl");
                var contains_pid = passport.Contains("pid");
                var contains_eyr = passport.Contains("eyr");
                var contains_hcl = passport.Contains("hcl");
                var contains_byr = passport.Contains("byr");
                var contains_iyr = passport.Contains("iyr");
                var contains_hgt = passport.Contains("hgt");


                if (contains_ecl && contains_pid && contains_eyr && contains_hcl && contains_byr && contains_iyr && contains_hgt) 
                {
                    result += 1;
                }

            }

            return result;
        }
    }
}

            
       