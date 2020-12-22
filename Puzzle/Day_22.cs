using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzle
{
    class Day_22
    {
        public static int Puzzle1()
        {
            var player_1 = new List<int>()
            { 19, 5, 35, 6, 12, 22, 45, 39, 14, 42, 47, 38, 2, 26, 13, 30, 4, 34, 43, 40, 16, 8, 23, 50, 36 };
           // { 9, 2, 6, 3, 1 };

            var player_2 = new List<int>()
            { 1, 21, 29, 41, 32, 28, 9, 37, 49, 20, 17, 27, 24, 3, 33, 44, 48, 31, 15, 25, 18, 46, 7, 10, 11 };
            //{ 5, 8, 4, 7, 10 };

            var round = 0;

            while (player_1.Any() && player_2.Any())
            {
                round += 1;

                var cijfer = player_1[0];
                var nr = player_2[0];

                if (cijfer > nr)
                {
                    player_1.Add(cijfer);
                    player_1.Add(nr);
                    player_1.RemoveAt(0);
                    player_2.RemoveAt(0);
                }
                if (nr > cijfer)
                {
                    player_2.Add(nr);
                    player_2.Add(cijfer);
                    player_2.RemoveAt(0);
                    player_1.RemoveAt(0);
                }
                Console.WriteLine("we are at roudn {0}", round);
            }

            Console.WriteLine("Aantal rondes: {0}", round);

            var winner = player_1.Any() ? player_1 : player_2;
            var result = CalculateScore(winner);

            return result;
        }


        public static int Puzzle2()
        {
            var player_1 = new List<int>()
            { 19, 5, 35, 6, 12, 22, 45, 39, 14, 42, 47, 38, 2, 26, 13, 30, 4, 34, 43, 40, 16, 8, 23, 50, 36 };
            //{ 9, 2, 6, 3, 1 };

            var player_2 = new List<int>()
            { 1, 21, 29, 41, 32, 28, 9, 37, 49, 20, 17, 27, 24, 3, 33, 44, 48, 31, 15, 25, 18, 46, 7, 10, 11 };
            // { 5, 8, 4, 7, 10 };

            var current_player2 = new List<int>();
            var current_player1 = new List<int>();

            var previous_player1 = new List<List<int>>();
            var previous_player2 = new List<List<int>>();

            var round = 0;

            while (player_1.Any() && player_2.Any())
            {
                round += 1;

                var cijfer = player_1[0];
                var nr = player_2[0];

                // If both players have at least as many cards remaining in their deck as the value of the card they just drew -> new game
                // if # cards in deck (minus the card dealt) < cijfer/nr -> normal rules apply
                if (player_1.Count -1 < cijfer || player_2.Count -1 < nr)
                {
                    if (cijfer > nr)
                    {
                        player_1.Add(cijfer);
                        player_1.Add(nr);
                        player_1.RemoveAt(0);
                        player_2.RemoveAt(0);
                        current_player1 = player_1.Take(player_1.Count).ToList();
                        previous_player1.Add(current_player1);
                    }
                    else
                    //if (nr > cijfer)
                    {
                        player_2.Add(nr);
                        player_2.Add(cijfer);
                        player_2.RemoveAt(0);
                        player_1.RemoveAt(0);
                        current_player2 = player_2.Take(player_2.Count).ToList();
                        previous_player2.Add(current_player2);
                    }
                }
                
                // if # cards in deck (minus the card dealt) >= cijfer/nr (then there are min that nr of cards left in both decks) -> new game
                //if(player_1.Count -1 >= cijfer && player_2.Count -1 >= nr)
                else
                {
                    var sub_1 = player_1.Skip(1).Take(cijfer).Select(c => c).ToList();
                    var sub_2 = player_2.Skip(1).Take(nr).Select(n => n).ToList();

                    var winner_1 = RecursiveGame(sub_1, sub_2);

                    if (winner_1 == "player_1")
                    {
                        player_1.Add(cijfer);
                        player_1.Add(nr);
                        player_1.RemoveAt(0);
                        player_2.RemoveAt(0);
                        current_player1 = player_1.Take(player_1.Count).ToList();
                        previous_player1.Add(current_player1);
                    }
                    else
                    {
                        player_2.Add(nr);
                        player_2.Add(cijfer);
                        player_2.RemoveAt(0);
                        player_1.RemoveAt(0);
                        current_player1 = player_1.Take(player_1.Count).ToList();
                        previous_player1.Add(current_player1);
                    }
                }
                
                Console.WriteLine("we are at round {0}", round);
            }
            var winner = player_1.Any() ? player_1 : player_2;
            var result = CalculateScore(winner);

            return result;
        }

        public static string RecursiveGame(List<int> sub_1, List<int> sub_2)
        {
            var round_bis = 1;
            while (sub_1.Any() && sub_2.Any())
            {
                round_bis += 1;

                var cijfer_sub = sub_1[0];
                var nr_sub = sub_2[0];

                // If both players have at least as many cards remaining in their deck as the value of the card they just drew -> new game
                // if # cards in deck (minus the card dealt) < cijfer/nr -> normal rules apply
                if (sub_1.Count - 1 < cijfer_sub || sub_2.Count - 1 < nr_sub)
                {
                    if (cijfer_sub > nr_sub)
                    {
                        sub_1.Add(cijfer_sub);
                        sub_1.Add(nr_sub);
                        sub_1.RemoveAt(0);
                        sub_2.RemoveAt(0);
                    }
                    //if (nr_sub > cijfer_sub)
                    else
                    {
                        sub_2.Add(nr_sub);
                        sub_2.Add(cijfer_sub);
                        sub_2.RemoveAt(0);
                        sub_1.RemoveAt(0);
                    }
                    
                }

                // if # cards in deck (minus the card dealt) >= cijfer/nr (then there are min that nr of cards left in both decks) -> new game
                //if (sub_1.Count - 1 >= cijfer_sub && sub_2.Count - 1 >= nr_sub)
                else
                {
                    var sub_1_1 = sub_1.Skip(1).Take(cijfer_sub).Select(c => c).ToList();
                    var sub_2_2 = sub_2.Skip(1).Take(nr_sub).Select(n => n).ToList();

                    var winner2 = RecursiveGame(sub_1_1, sub_2_2);
                    if (winner2 == "player_1")
                    {
                        sub_1.Add(cijfer_sub);
                        sub_1.Add(nr_sub);
                        sub_1.RemoveAt(0);
                        sub_2.RemoveAt(0);
                    }
                    else
                    {
                        sub_2.Add(nr_sub);
                        sub_2.Add(cijfer_sub);
                        sub_2.RemoveAt(0);
                        sub_1.RemoveAt(0);
                    }
                }

                Console.WriteLine("we are at round {0}", round_bis);
            }

            var winner = sub_1.Any() ? "player_1" : "player_2";
            //var winner = "player_1";
            return winner;
        }

        public static int CalculateScore(List<int> winner)
        {
            int result = 0;
            var length = winner.Count;
            int multi = 1;
            int index = length - 1;

            while (index >= 0)
            {
                var pruduct = winner[index] * multi;
                result += pruduct;
                multi += 1;
                index -= 1;
            }

            return result;
        }
    }
}
