using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day11
    {
        private static int _flashes = 0;
        public static void Part1()
        {
            var lines = File.ReadAllLines("Inputs/day11.txt").ToList();
            Dictionary<Point, int?> octopy = new Dictionary<Point, int?>();
            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    octopy.Add(new Point(x, y), int.Parse(lines[y][x].ToString()));
                }
            }
            for (int i = 0; i < 100; i++)
            {
                Step(octopy);
            }
            Console.WriteLine(_flashes);
        }

        private static void Step(Dictionary<Point, int?> octopy)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    octopy[new Point(x, y)]++;
                }
            }
            while (octopy.Any(v => v.Value > 9))
            {
                foreach (var octopusKey in octopy.Where(o => o.Value > 9).Select(o => o.Key).ToList())
                {
                    //Flash
                    _flashes++;
                    octopy[octopusKey] = null;
                    IncreaseAllNeigbours(octopusKey, octopy);
                }
            }
            foreach (var octopusKey in octopy.Where(o => !o.Value.HasValue).Select(o => o.Key).ToList())
            {
                octopy[octopusKey] = 0;
            }
            //for (int y = 0; y < 5; y++)
            //{
            //    for (int x = 0; x < 5; x++)
            //    {
            //        Console.Write(octopy[new Point(x, y)]);
            //    }
            //    Console.WriteLine();
            //}
        }
        private static void IncreaseAllNeigbours(Point octopusKey, Dictionary<Point, int?> octopy)
        {
            List<Point> neighbours = new List<Point>() { new Point(octopusKey.X - 1, octopusKey.Y),
                new Point(octopusKey.X - 1, octopusKey.Y -1), new Point(octopusKey.X, octopusKey.Y - 1),
                new Point(octopusKey.X + 1, octopusKey.Y - 1), new Point(octopusKey.X + 1, octopusKey.Y),
                new Point(octopusKey.X + 1, octopusKey.Y + 1), new Point(octopusKey.X, octopusKey.Y + 1),
                new Point(octopusKey.X -1, octopusKey.Y + 1)};

            foreach (var neighbour in neighbours)
            {
                if (octopy.ContainsKey(neighbour) && octopy[neighbour] != null) octopy[neighbour]++;
            }
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines("Inputs/day11.txt").ToList();
            Dictionary<Point, int?> octopy = new Dictionary<Point, int?>();
            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    octopy.Add(new Point(x, y), int.Parse(lines[y][x].ToString()));
                }
            }
            var stepCounter = 0;
            while (!octopy.All(o=>o.Value == 0))
            {
                Step(octopy);
                stepCounter++;
            }
                
            Console.WriteLine(stepCounter);
        }

    }
}
