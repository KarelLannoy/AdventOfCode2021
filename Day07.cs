using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day07
    {
        public static void Part1()
        {
            var inputs = File.ReadAllLines("Inputs/day07.txt").ToList();
            var positions = inputs[0].Split(",").Select(x => int.Parse(x)).ToList();
            var max = positions.Max();
            var min = positions.Min();
            var lowestFuelCost = long.MaxValue;
            for (int i = min; i <= max; i++)
            {
                long totalFuelCost = 0;
                foreach (var position in positions) totalFuelCost += Math.Abs(i - position);
                if (totalFuelCost < lowestFuelCost) lowestFuelCost = totalFuelCost;
            }
            Console.WriteLine(lowestFuelCost);
        }
        public static void Part2()
        {
            var inputs = File.ReadAllLines("Inputs/day07.txt").ToList();
            var positions = inputs[0].Split(",").Select(x => int.Parse(x)).ToList();
            var max = positions.Max();
            var min = positions.Min();
            var lowestFuelCost = long.MaxValue;
            for (int i = min; i <= max; i++)
            {
                long totalFuelCost = 0;
                foreach (var position in positions)
                {
                    var steps = Math.Abs(i - position);
                    totalFuelCost += (steps * (steps + 1)) / 2;
                }
                if (totalFuelCost < lowestFuelCost) lowestFuelCost = totalFuelCost;
            }
            Console.WriteLine(lowestFuelCost);
        }
    }
}
