using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day10
    {
        private static List<char> _openingChars = new List<char>() { '(', '[', '{', '<' };
        private static List<char> _closingChars = new List<char>() { ')', ']', '}', '>' };
        private static int _index = 0;
        private static string _ending = "";
        public static void Part1()
        {
            var lines = File.ReadAllLines("Inputs/day10.txt").ToList();
            int score = 0;
            foreach (var line in lines)
            {
                _index = 0;
                try
                {
                    MapNextChar_part1(line);
                }
                catch (Exception e)
                {
                    if (e.Message != "incomplete")
                    {
                        switch (e.Message)
                        {
                            case ")":
                                score += 3;
                                break;
                            case "]":
                                score += 57;
                                break;
                            case "}":
                                score += 1197;
                                break;
                            case ">":
                                score += 25137;
                                break;
                        }
                    }
                }

            }
            Console.WriteLine(score);
        }

        private static char MapNextChar_part1(string line)
        {
            if (_index >= line.Length)
            {
                throw new Exception("incomplete");
            }
            var v = line[_index];
            if (_openingChars.Contains(v))
            {
                _index++;
                var nextClosing = MapNextChar_part1(line);
                if (_openingChars.IndexOf(v) != _closingChars.IndexOf(nextClosing))
                {
                    throw new Exception(nextClosing.ToString());
                }
                _index++;
                return MapNextChar_part1(line); ;
            }
            else
            {
                return v;
            }
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines("Inputs/day10.txt").ToList();
            var endings = new List<string>();
            foreach (var line in lines)
            {
                _index = 0;
                try
                {
                    _ending = "";
                    MapNextChar_part2(line);
                    endings.Add(_ending);
                }
                catch (Exception)
                {
                }
            }
            List<long> scores = new List<long>();
            foreach (var ending in endings)
            {
                long subScore = 0;
                for (int i = 0; i < ending.Length; i++)
                {
                    subScore *= 5;
                    subScore += (_closingChars.IndexOf(ending[i]) + 1);
                }
                scores.Add(subScore);
            }
            var score = scores.OrderBy(x => x).Skip(Convert.ToInt32(Math.Floor(((decimal)scores.Count / (decimal)2)))).Take(1).First();
            Console.WriteLine(score);
        }

        private static char MapNextChar_part2(string line)
        {
            if (_index >= line.Length)
            {
                return ' ';
            }
            var v = line[_index];
            if (_openingChars.Contains(v))
            {
                _index++;
                var nextClosing = MapNextChar_part2(line);
                if (_openingChars.IndexOf(v) != _closingChars.IndexOf(nextClosing))
                {
                    if (nextClosing == ' ')
                    {
                        _ending += _closingChars[_openingChars.IndexOf(v)];
                        return nextClosing;
                    }
                    throw new Exception(nextClosing.ToString());
                }
                _index++;
                return MapNextChar_part2(line); ;
            }
            else
            {
                return v;
            }
        }
    }
}
