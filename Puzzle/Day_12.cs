using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_12 : LoadData
    {
        public static int Puzzle1()
        {
            var input = LoadDataListAsStringList(12, 1);

            var direction = "east";

            var compas = new Dictionary<string, int>()
            {
                 { "north", 0 }
                ,{ "east" , 0 }
                ,{ "south" , 0 }
                ,{ "west", 0}
            };

            var compas_points = new List<string>() { "north", "east", "south", "west" };

            foreach (string action in input)
            {
                var letter = action[0].ToString();
                var value = int.Parse(action[1..]);

                switch (letter)
                {
                    case "F": //moving forward in de set direction
                        // relatieve value = value  - value opposit direction
                        var value_opp_dir = 0;
                        switch (direction)
                        {
                            case "north": value_opp_dir = compas["south"]; compas["south"] = 0; break;
                            case "east": value_opp_dir = compas["west"]; compas["west"] = 0; break;
                            case "south": value_opp_dir = compas["north"]; compas["north"] = 0; break;
                            case "west": value_opp_dir = compas["east"]; compas["east"] = 0; break;
                            default:
                                break;
                        }

                        var relative_value = value - value_opp_dir;
                        compas[direction] = compas[direction] + relative_value;
                        break;
                    case "R":  //turning rigth by a given degrees (90, 180 or 270)
                        switch (value)
                        {
                            case 90: // if value is 90 take next wind direction
                                if (direction != "west")
                                {
                                    var current_direction_index = compas_points.IndexOf(direction);
                                    direction = compas_points[current_direction_index + 1];
                                }
                                else
                                {
                                    direction = compas_points[0]; // north
                                }
                                break;
                            case 180:
                                if (!(direction == "south" || direction == "west"))
                                {
                                    var current_direction_index = compas_points.IndexOf(direction);
                                    direction = compas_points[current_direction_index + 2];
                                }
                                else if (direction == "south")
                                {
                                    direction = compas_points[0]; //north
                                }
                                else if (direction == "west")
                                {
                                    direction = compas_points[1]; //east
                                }
                                break;
                            case 270:
                                if (direction != "north")
                                {
                                    var current_direction_index = compas_points.IndexOf(direction);
                                    direction = compas_points[current_direction_index -1 ];
                                }
                                else
                                {
                                    direction = compas_points[3]; // west
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "L": //turning left by a given degrees (90, 180 or 270)
                        switch (value)
                        {
                            case 90:
                                if (direction != "north")
                                {
                                    var current_direction_index = compas_points.IndexOf(direction);
                                    direction = compas_points[current_direction_index -1];
                                }
                                else
                                {
                                    direction = compas_points[3]; ; // west
                                }
                                break;
                            case 180:
                                if ( !(direction == "east" || direction == "north") )
                                {
                                    var current_direction_index = compas_points.IndexOf(direction);
                                    direction = compas_points[current_direction_index - 2];
                                }
                                else if (direction == "east")
                                {
                                    direction = compas_points[3]; //west
                                }
                                else if (direction == "north")
                                {
                                    direction = compas_points[2]; //south
                                }
                                break;
                            case 270:
                                if (direction != "west")
                                {
                                    var current_direction_index = compas_points.IndexOf(direction);
                                    direction = compas_points[current_direction_index + 1];
                                }
                                else
                                {
                                    direction = compas_points[0]; // north
                                }
                                break;
                            default:
                                break;
                        }

                        break;
                    case "N": //adding distance to north
                        var rel_value_north = value - compas["south"];
                        compas["north"] = value +  rel_value_north;
                        compas["south"] = 0;
                        break;
                    case "E": //adding distance to east
                        var rel_value_east = value - compas["west"];
                        compas["east"] = value + rel_value_east;
                        compas["west"] = 0;
                        break;
                    case "S": //adding distance to south
                        var rel_value_south = value - compas["north"];
                        compas["south"] = value + rel_value_south;
                        compas["north"] = 0;
                        break;
                    case "W": //adding distance to west
                        var rel_value_west = value - compas["east"];
                        compas["west"] = value + rel_value_west;
                        compas["east"] = 0;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("North: {0}", compas["north"].ToString());
            Console.WriteLine("East: {0}", compas["east"].ToString());
            Console.WriteLine("South: {0}", compas["south"].ToString());
            Console.WriteLine("West: {0}", compas["west"].ToString());

            var keys_with_val = compas.Where(k => k.Value != 0).Select(k => k.Key).ToList(); 

            foreach (var key in keys_with_val)
            {
                Console.WriteLine("Key {0} has value {1}", key, compas[key]);
            }

            int result = compas[keys_with_val[0]] + compas[keys_with_val[1]];
            return result;
        }
    }
}
