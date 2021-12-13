using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day12
    {
        public static void Part1()
        {
            var connections = File.ReadAllLines("Inputs/day12.txt").ToList().Select(x => new Connection() { First = x.Split("-")[0], Second = x.Split("-")[1] }).ToList();
            List<string> caves = connections.Select(x => x.First).Distinct().ToList();
            caves.AddRange(connections.Select(s => s.Second).Distinct().ToList());
            caves = caves.Distinct().ToList();
            List<string> paths = new List<string>();
            MapPath_1("start", connections);
            //_paths.ForEach(p => Console.WriteLine(p));
            Console.WriteLine(_paths.Count);

        }
        private static List<string> _paths = new List<string>();
        private static void MapPath_1(string previousPath, List<Connection> connections)
        {
            var previousCave = previousPath.Split(",").Last();
            var possibleNextCaves = connections.Where(c => c.First == previousCave || c.Second == previousCave).ToList();
            foreach (var nextCave in possibleNextCaves)
            {
                var newPreviousPath = previousPath;
                var nextCaveLetter = nextCave.First == previousCave ? nextCave.Second : nextCave.First;
                if (nextCaveLetter == "end")
                {
                    _paths.Add(newPreviousPath += "," + nextCaveLetter);
                    continue;
                }
                if (nextCaveLetter == "start") continue;
                if (nextCaveLetter.All(char.IsUpper))
                {
                    newPreviousPath += "," + nextCaveLetter;
                    MapPath_1(newPreviousPath, connections);
                }
                if (!nextCaveLetter.Any(char.IsUpper))
                {
                    if (newPreviousPath.Contains(nextCaveLetter))continue;
                    newPreviousPath += "," + nextCaveLetter;
                    MapPath_1(newPreviousPath, connections);
                }
            }
        }
        public static void Part2()
        {
            var lines = File.ReadAllLines("Inputs/day12.txt").ToList();
            var connections = File.ReadAllLines("Inputs/day12.txt").ToList().Select(x => new Connection() { First = x.Split("-")[0], Second = x.Split("-")[1] }).ToList();
            List<string> caves = connections.Select(x => x.First).Distinct().ToList();
            caves.AddRange(connections.Select(s => s.Second).Distinct().ToList());
            caves = caves.Distinct().ToList();
            _paths = new List<string>();
            MapPath_2("start", connections, null);
            //_paths.ForEach(p => Console.WriteLine(p));
            Console.WriteLine(_paths.Count);
        }

        private static void MapPath_2(string previousPath, List<Connection> connections, string smallLetterVisited)
        {
            var previousCave = previousPath.Split(",").Last();
            var possibleNextCaves = connections.Where(c => c.First == previousCave || c.Second == previousCave).ToList();
            foreach (var nextCave in possibleNextCaves)
            {
                var newPreviousPath = previousPath;
                var smallLetterVisitedThisItteration = smallLetterVisited;
                var nextCaveLetter = nextCave.First == previousCave ? nextCave.Second : nextCave.First;
                if (nextCaveLetter == "end")
                {
                    _paths.Add(newPreviousPath += "," + nextCaveLetter);
                    continue;
                }
                if (nextCaveLetter == "start") continue;
                if (nextCaveLetter.All(char.IsUpper))
                {
                    newPreviousPath += "," + nextCaveLetter;
                    MapPath_2(newPreviousPath, connections, smallLetterVisitedThisItteration);
                }
                if (!nextCaveLetter.Any(char.IsUpper))
                {
                    if (newPreviousPath.Contains(nextCaveLetter))
                    {
                        if (smallLetterVisitedThisItteration == null)
                        {
                            smallLetterVisitedThisItteration = nextCaveLetter;
                        }
                        else continue;
                    }
                    newPreviousPath += "," + nextCaveLetter;
                    MapPath_2(newPreviousPath, connections, smallLetterVisitedThisItteration);
                }
            }
        }
        private class Connection
        {
            public string First { get; set; }

            public string Second { get; set; }
        }
    }
}
