using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day02
    {
        public static void Part1()
        {
            var inputs = File.ReadAllLines("Inputs/day02.txt").ToList();
            var position = new Point(0, 0);
            foreach (var input in inputs)
            {
                var direction = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                int steps = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                switch (direction)
                {
                    case "forward":
                        position.X += steps;
                        break;
                    case "up":
                        position.Y -= steps;
                        break;
                    case "down":
                        position.Y += steps;
                        break;
                }
            }
            Console.WriteLine(position.X * position.Y);
        }

        public static void Part2()
        {
            var inputs = File.ReadAllLines("Inputs/day02.txt").ToList();
            var position = new Point(0, 0);
            var aim = 0;
            foreach (var input in inputs)
            {
                var direction = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                int steps = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                switch (direction)
                {
                    case "forward":
                        position.X += steps;
                        position.Y += steps * aim;
                        break;
                    case "up":
                        aim -= steps;
                        break;
                    case "down":
                        aim += steps;
                        break;
                }
            }
            Console.WriteLine(position.X * position.Y);
        }
    }
}
