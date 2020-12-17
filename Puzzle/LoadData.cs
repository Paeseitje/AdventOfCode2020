using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Puzzle
{
    class LoadData
    {
        protected static string GetPath(int day, int puzzle)
        {
            return String.Format("{0}{1}/day_{1}_{2}.txt", Program.INPUT_FILE_DIR, day, puzzle);
        }

        // load data as a list<int>
        protected static List<int> LoadDataColumnAsIntList(int day, int puzzle)
        {
            List<int> input = new List<int>();
            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day, puzzle)))
                {
                    while (!sr.EndOfStream)
                    {
                        input.Add(int.Parse(sr.ReadLine()));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return input;
        }

        protected static List<int> LoadDataListAsIntList(int day, int puzzle)
        {
            List<int> input = new List<int>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day, puzzle)))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        input.Add(int.Parse(line));
                        //input = line.Split(',').Select(int.Parse).ToList();

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return input;
        }

        protected static List<long> LoadDataListAsLongList(int day, int puzzle)
        {
            List<long> input = new List<long>();
            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day, puzzle)))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        input.Add(long.Parse(line));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return input;
        }

        protected static List<List<int>> LoadDataListAsIntListList(int day, int puzzle)
        {
            List<List<int>> input = new List<List<int>>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day, puzzle)))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Split(",").Select(int.Parse).ToList();
                        input.Add(line);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return input;
        }

        protected static List<string> LoadDataListAsStringList(int day, int puzzle)
        {
            List<string> input = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day, puzzle)))
                {
                    while (!sr.EndOfStream)
                    {
                        input.Add(sr.ReadLine());

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return input;
        }

        protected static List<string> LoadDataAsStringListBis(int day, int puzzle)
        {
            var input = new List<string>();
            string line;
            string totalLine = "";
            try
            {
                using StreamReader sr = new StreamReader(GetPath(day, puzzle));
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    if(!string.IsNullOrEmpty(line)) 
                    {
                        totalLine += line;
                        totalLine += " ";

                    }
                    else
                    {
                        input.Add(totalLine);
                        totalLine = "";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return input;
        }

        protected static List<List<string>> LoadDataListAsStringListList(int day, int puzzle)
        {
            List<List<string>> list = new List<List<string>>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day, puzzle)))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add(sr.ReadLine().Split(',').ToList());
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return list;
        }

        


    }

}
