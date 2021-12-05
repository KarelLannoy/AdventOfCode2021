using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day05
    {
        public static void Part1()
        {
            var inputs = File.ReadAllLines("Inputs/day05.txt").ToList();
            var vectors = new List<Vector>();
            foreach (var input in inputs)
            {
                var commaSeperated = input.Replace(" -> ", ",");
                var parts = commaSeperated.Split(",");
                if (parts[0] == parts[2] || parts[1] == parts[3])
                {
                    vectors.Add(new Vector(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                }
            }
            var allPoints = new List<Point>();
            foreach (var vector in vectors)
            {
                allPoints.AddRange(vector.Points);
            }
            Console.WriteLine(allPoints.GroupBy(p => p).SelectMany(grp => grp.Skip(1)).Distinct().ToList().Count());
        }
        public static void Part2()
        {
            var inputs = File.ReadAllLines("Inputs/day05.txt").ToList();
            var vectors = new List<Vector>();
            foreach (var input in inputs)
            {
                var commaSeperated = input.Replace(" -> ", ",");
                var parts = commaSeperated.Split(",");
                vectors.Add(new Vector(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
            }
            var allPoints = new List<Point>();
            foreach (var vector in vectors)
            {
                allPoints.AddRange(vector.Points);
            }
            Console.WriteLine(allPoints.GroupBy(p => p).SelectMany(grp => grp.Skip(1)).Distinct().ToList().Count());

        }
        public class Vector
        {
            public Vector(int x1, int y1, int x2, int y2)
            {
                Points = new List<Point>();
                if (x1 == x2)
                {

                    for (int i = Math.Min(y1, y2); i <= Math.Max(y1, y2); i++)
                    {
                        Points.Add(new Point(x1, i));
                    }
                }
                else if (y1 == y2)
                {
                    for (int i = Math.Min(x1, x2); i <= Math.Max(x1, x2); i++)
                    {
                        Points.Add(new Point(i, y1));
                    }
                }
                else
                {
                    var horizontalMovement = -1;
                    if (x1 < x2) horizontalMovement = 1;
                    var verticalMovement = -1;
                    if (y1 < y2) verticalMovement = 1;

                    var previousY = y1 - verticalMovement;
                    for (int i = x1; horizontalMovement > 0 ? i <= x2 : i >= x2; i += horizontalMovement)
                    {
                        Points.Add(new Point(i, previousY += verticalMovement));
                    }
                }
            }
            public List<Point> Points { get; set; }
        }
    }
}
