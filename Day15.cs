using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day15
    {
        public static void Part1()
        {
            var lines = File.ReadAllLines("Inputs/day15.txt").ToList();
            ConcurrentDictionary<Point, int> risks = new ConcurrentDictionary<Point, int>();
            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    risks.TryAdd(new Point(x, y), int.Parse(lines[y][x].ToString()));
                }
            }
            _maxX = risks.Keys.Max(k => k.X);
            _maxY = risks.Keys.Max(k => k.Y);
            _lessOptimalScore = risks.Where(x => x.Key.X == 0).Sum(x => x.Value) + risks.Where(y => y.Key.Y == lines.Count() - 1 && y.Key.X != 0).Sum(y => y.Value);

            Point start = new Point(0, 0);
            _end = new Point(risks.Keys.Max(k => k.X), risks.Keys.Max(k => k.Y));

            MapRoute_Part1(start, risks, 0);

            Console.WriteLine(_bestScores[_end] - _bestScores[start]);

        }
        private static int _lessOptimalScore { get; set; }
        private static Point _end { get; set; }
        private static ConcurrentDictionary<Point, long> _bestScores = new ConcurrentDictionary<Point, long>();
        private static int _maxX { get; set; }
        private static int _maxY { get; set; }

        private static void MapRoute_Part1(Point start, ConcurrentDictionary<Point, int> risks, long routeScore)
        {
            if (routeScore > _lessOptimalScore) return;
            if (_bestScores.ContainsKey(_end) && routeScore > _bestScores[_end]) return;
            if (start.X < 0 || start.Y < 0 || start.X > _maxX || start.Y > _maxY) return;
            routeScore = routeScore + risks[start];
            if (_bestScores.ContainsKey(start))
            {
                var previousScore = _bestScores[start];
                if (previousScore > routeScore)
                {
                    _bestScores[start] = routeScore;
                }
                else return;
            }
            else _bestScores.TryAdd(start, routeScore);
            var neigbours = new List<Point>() { new Point(start.X - 1, start.Y), new Point(start.X + 1, start.Y), new Point(start.X, start.Y + 1) };
            neigbours.ForEach(neigbour => { MapRoute_Part1(neigbour, risks, routeScore); });
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines("Inputs/day15.txt").ToList();
            ConcurrentDictionary<Point, int> risks = new ConcurrentDictionary<Point, int>();
            _maxX = lines.Count();
            _maxY = lines.Count();
            for (int y = 0; y < lines.Count * 5; y++)
            {
                var yIndex = Convert.ToInt32(Math.Floor((decimal)y / (decimal)_maxY));
                var ypos = y % (_maxY);
                //Console.WriteLine();
                for (int x = 0; x < lines[ypos].Length * 5; x++)
                {
                    var xIndex = Convert.ToInt32(Math.Floor((decimal)x / (decimal)_maxX));
                    var xpos = x % (_maxX);
                    var value = ((int.Parse(lines[ypos][xpos].ToString()) + xIndex + yIndex) % 9);
                    risks.TryAdd(new Point(x, y), value == 0 ? 9 : value);
                    //Console.Write(value);

                }
            }
            //Console.WriteLine();

            _maxX = risks.Keys.Max(k => k.X);
            _maxY = risks.Keys.Max(k => k.Y);
            _lessOptimalScore = risks.Where(x => x.Key.X == 0).Sum(x => x.Value) + risks.Where(y => y.Key.Y == lines.Count() - 1 && y.Key.X != 0).Sum(y => y.Value);
            _bestScores = new ConcurrentDictionary<Point, long>();

            Point start = new Point(0, 0);
            _end = new Point(risks.Keys.Max(k => k.X), risks.Keys.Max(k => k.Y));

            MapRoute_Part2(start, risks, 0);

            Console.WriteLine(_bestScores[_end] - _bestScores[start]);
        }

        private static void MapRoute_Part2(Point start, ConcurrentDictionary<Point, int> risks, long routeScore)
        {
            if (routeScore > _lessOptimalScore) return;
            if (_bestScores.ContainsKey(_end) && routeScore > _bestScores[_end]) return;
            if (!risks.ContainsKey(start)) return;
            routeScore = routeScore + risks[start];
            if (_bestScores.ContainsKey(start))
            {
                var previousScore = _bestScores[start];
                if (previousScore > routeScore)  _bestScores[start] = routeScore;
                else return;
            }
            else _bestScores.TryAdd(start, routeScore);
            var neigbours = new List<Point>() { new Point(start.X - 1, start.Y), new Point(start.X + 1, start.Y), new Point(start.X, start.Y - 1), new Point(start.X, start.Y + 1) };
            Parallel.ForEach(neigbours, neigbour => { MapRoute_Part2(neigbour, risks, routeScore); });
        }
    }
}
