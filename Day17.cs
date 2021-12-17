using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day17
    {
        public static void Part1()
        {
            var targetStringParts = File.ReadAllText("Inputs/day17.txt").Split(": ")[1].Split(", ");
            var xMin = int.Parse(targetStringParts[0].Replace("x=", "").Split("..")[0]);
            var xMax = int.Parse(targetStringParts[0].Replace("x=", "").Split("..")[1]);
            var yMin = int.Parse(targetStringParts[1].Replace("y=", "").Split("..")[0]);
            var yMax = int.Parse(targetStringParts[1].Replace("y=", "").Split("..")[1]);
            HashSet<Point> target = new HashSet<Point>();
            for (int y = yMin; y <= yMax; y++)
            {
                for (int x = xMin; x <= xMax; x++)
                {
                    target.Add(new Point(x, y));
                }
            }
            var highestY = 0;
            Point BestVelocity = new Point();
            var possibleVelocities = new List<Point>();
            var biggest = (Math.Max(Math.Abs(xMax), Math.Abs(yMax)))*2;
            for (int y = 0; y <= biggest; y++)
            {
                for (int x = 0; x < biggest; x++)
                {
                    possibleVelocities.Add(new Point(x, y));
                }
            }
            foreach (var initialVelocity in possibleVelocities)
            {
                var velocity = initialVelocity;
                Point position = new Point(0, 0);
                var highestPotentialY = 0;
                while (position.X < xMax && position.Y > yMin)
                {
                    position.X += velocity.X;
                    position.Y += velocity.Y;
                    velocity.X = velocity.X < 0 ? velocity.X + 1 : velocity.X > 0 ? velocity.X - 1 : 0;
                    velocity.Y -= 1;
                    highestPotentialY = highestPotentialY < position.Y ? position.Y : highestPotentialY;

                    if (target.Contains(position))
                    {
                        if (highestPotentialY > highestY)
                        {
                            highestY = highestPotentialY;
                            BestVelocity = initialVelocity;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine($"({BestVelocity.X}, {BestVelocity.Y}) - {highestY}");
        }

        public static void Part2()
        {
            var targetStringParts = File.ReadAllText("Inputs/day17.txt").Split(": ")[1].Split(", ");
            var xMin = int.Parse(targetStringParts[0].Replace("x=", "").Split("..")[0]);
            var xMax = int.Parse(targetStringParts[0].Replace("x=", "").Split("..")[1]);
            var yMin = int.Parse(targetStringParts[1].Replace("y=", "").Split("..")[0]);
            var yMax = int.Parse(targetStringParts[1].Replace("y=", "").Split("..")[1]);
            HashSet<Point> target = new HashSet<Point>();
            for (int y = yMin; y <= yMax; y++)
            {
                for (int x = xMin; x <= xMax; x++)
                {
                    target.Add(new Point(x, y));
                }
            }
            var counter = 0;
            var possibleVelocities = new List<Point>();
            var biggest = (Math.Max(Math.Abs(xMax), Math.Abs(yMax))) * 2;
            for (int y = biggest * -1; y <= biggest; y++)
            {
                for (int x = biggest * -1; x < biggest; x++)
                {
                    possibleVelocities.Add(new Point(x, y));
                }
            }
            foreach (var initialVelocity in possibleVelocities)
            {
                var velocity = initialVelocity;
                Point position = new Point(0, 0);
                var highestPotentialY = 0;
                while (position.X < xMax && position.Y > yMin)
                {
                    position.X += velocity.X;
                    position.Y += velocity.Y;
                    velocity.X = velocity.X < 0 ? velocity.X + 1 : velocity.X > 0 ? velocity.X - 1 : 0;
                    velocity.Y -= 1;
                    highestPotentialY = highestPotentialY < position.Y ? position.Y : highestPotentialY;
                    if (target.Contains(position))
                    {
                        counter++;
                        break;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
