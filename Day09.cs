using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day09
    {
        public static void Part1()
        {
            var lines = File.ReadAllLines("Inputs/day09.txt").ToList();
            Dictionary<Point, int> heights = new Dictionary<Point, int>();
            for (int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0; y < lines.Count; y++)
                {
                    heights.Add(new Point(x, y), int.Parse(lines[y][x].ToString()));
                }
            }
            List<Point> lowPoints = new List<Point>();
            foreach (var location in heights)
            {
                var left = heights.ContainsKey(new Point(location.Key.X - 1, location.Key.Y)) ? heights[new Point(location.Key.X - 1, location.Key.Y)] : int.MaxValue;
                var right = heights.ContainsKey(new Point(location.Key.X + 1, location.Key.Y)) ? heights[new Point(location.Key.X + 1, location.Key.Y)] : int.MaxValue;
                var up = heights.ContainsKey(new Point(location.Key.X, location.Key.Y - 1)) ? heights[new Point(location.Key.X, location.Key.Y - 1)] : int.MaxValue;
                var down = heights.ContainsKey(new Point(location.Key.X, location.Key.Y + 1)) ? heights[new Point(location.Key.X, location.Key.Y + 1)] : int.MaxValue;
                if (location.Value < new List<int> { left, right, up, down }.Min()) lowPoints.Add(location.Key);
            }
            Console.WriteLine(lowPoints.Select(l => heights[l] + 1).Sum());
        }
        public static void Part2()
        {
            var lines = File.ReadAllLines("Inputs/day09.txt").ToList();
            Dictionary<Point, int> heights = new Dictionary<Point, int>();
            for (int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0; y < lines.Count; y++)
                {
                    heights.Add(new Point(x, y), int.Parse(lines[y][x].ToString()));
                }
            }
            List<List<Point>> basins = new List<List<Point>>();
            HashSet<Point> used = new HashSet<Point>(); 
            foreach (var location in heights)
            {
                if (used.Contains(location.Key)) continue;
                if (location.Value == 9) continue;

                List<Point> basin = new List<Point>();
                MapBasin(location.Key, heights, basin, used);
                basins.Add(basin);
            }
            Console.WriteLine(basins.OrderByDescending(b => b.Count()).Take(3).Select(b=>b.Count()).ToList().Aggregate((a,x) => a * x));
        }

        private static void MapBasin(Point key, Dictionary<Point, int> heights, List<Point> basin, HashSet<Point> used)
        {
            if (used.Contains(key)) return;
            if (heights[key] == 9) return;
            used.Add(key);
            basin.Add(key);
            if (heights.ContainsKey(new Point(key.X - 1, key.Y))) MapBasin(new Point(key.X - 1, key.Y), heights, basin, used);
            if (heights.ContainsKey(new Point(key.X + 1, key.Y))) MapBasin(new Point(key.X + 1, key.Y), heights, basin, used);
            if (heights.ContainsKey(new Point(key.X, key.Y - 1))) MapBasin(new Point(key.X, key.Y - 1), heights, basin, used);
            if (heights.ContainsKey(new Point(key.X, key.Y + 1))) MapBasin(new Point(key.X, key.Y + 1), heights, basin, used);
        }
    }
}
