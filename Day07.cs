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
            var positions = File.ReadAllLines("Inputs/day07.txt").ToList()[0].Split(",").Select(x => int.Parse(x)).ToList();
            var lowestFuelCost = long.MaxValue;
            for (int i = positions.Min(); i <= positions.Max(); i++)
            {
                long totalFuelCost = 0;
                foreach (var position in positions) totalFuelCost += Math.Abs(i - position);
                if (totalFuelCost < lowestFuelCost) lowestFuelCost = totalFuelCost;
            }
            Console.WriteLine(lowestFuelCost);
        }
        public static void Part2()
        {
            var positions = File.ReadAllLines("Inputs/day07.txt").ToList()[0].Split(",").Select(x => int.Parse(x)).ToList();
            var lowestFuelCost = long.MaxValue;
            for (int i = positions.Min(); i <= positions.Max(); i++)
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
