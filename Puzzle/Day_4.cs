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


        public static int Puzzle2()
        {
            var input = LoadDataAsStringListBis(4,1);
            var result = 0;

            foreach (string passport in input)
            {
                var valid_ecl = false;
                var valid_pid = false;
                var valid_eyr = false;
                var valid_hcl = false;
                var valid_byr = false;
                var valid_iyr = false;
                var valid_hgt = false;

                var trimmed = passport.Trim();
                var list = trimmed.Split(" ");
                var dict = new Dictionary<string, string>();
                foreach (var l in list)
                {
                    var t = l.Split(':');
                    dict.Add(t[0], t[1]);
                }

                foreach (KeyValuePair<string, string> kvp in dict)
                {
                    // Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    // check validity of the value

                    switch (kvp.Key)
                    {
                        case "byr":
                           valid_byr = int.Parse(kvp.Value) >= 1920 && int.Parse(kvp.Value) <= 2002 ? true : false;
                            break;
                        case "iyr":
                            valid_iyr = int.Parse(kvp.Value) >= 2010 && int.Parse(kvp.Value) <= 2020 ? true : false;
                            break;
                        case "eyr":
                            valid_eyr = int.Parse(kvp.Value) >= 2020 && int.Parse(kvp.Value) <= 2030;
                            break;
                        case "pid":
                            valid_pid = kvp.Value.All(char.IsDigit) && kvp.Value.Length == 9;
                            break;
                        case "ecl":
                            var ecl_list = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                            valid_ecl = ecl_list.Contains(kvp.Value) ? true : false;
                            break;
                        case "hcl":
                            valid_hcl = kvp.Value.StartsWith("#") && kvp.Value.Substring(1).Length == 6 && kvp.Value.Substring(1).All(c => char.IsLetterOrDigit(c));
                            break;
                        case "hgt":
                            try
                            {
                                var substring = kvp.Value.Substring(0, kvp.Value.Length - 2);
                                var hgt = int.Parse(substring);
                                valid_hgt =
                                    kvp.Value.EndsWith("in") && (hgt >= 59 && hgt <= 76) ? true :
                                    kvp.Value.EndsWith("cm") && (hgt >= 150 && hgt <= 193) ? true : false;
                            }
                            catch (Exception)
                            {
                                valid_hgt = false;
                                //throw;
                            }
                            break;
                        default:
                            break;
                    }

                    

                }


                if (valid_ecl && valid_pid && valid_eyr && valid_hcl && valid_byr && valid_iyr && valid_hgt)
                {
                    result += 1;
                   // Console.WriteLine("true");
                }
                //else
                //{
                //    Console.WriteLine("false");
                //}
            }


            return result;
        }
    }
}

            
       