using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day13
    {
        public static void Part1()
        {
            var dots = File.ReadAllLines("Inputs/day13.txt").Where(x => x != "" && char.IsNumber(x[0])).Select(dot => new Point(int.Parse(dot.Split(",")[0]), int.Parse(dot.Split(",")[1]))).ToList();
            var foldInstrucions = File.ReadAllLines("Inputs/day13.txt").Where(x => x.StartsWith("fold along")).Select(inst => new Instruction() { Axis = inst.Substring(11).Split("=")[0], Position = int.Parse(inst.Substring(11).Split("=")[1]) }).ToList();
            var instruction = foldInstrucions[0];
            switch (instruction.Axis)
            {
                case "y":
                    var foldedDotsY = dots.Where(d => d.Y > instruction.Position).ToList();
                    dots.RemoveAll(dot => foldedDotsY.Contains(dot));
                    foreach (var dot in foldedDotsY)
                    {
                        var newY = dot.Y - ((dot.Y - instruction.Position) * 2);
                        dots.Add(new Point(dot.X, newY));
                    }
                    break;
                case "x":
                    var foldedDotsX = dots.Where(d => d.X > instruction.Position).ToList();
                    dots.RemoveAll(dot => foldedDotsX.Contains(dot));
                    foreach (var dot in foldedDotsX)
                    {
                        var newX = dot.X - ((dot.X - instruction.Position) * 2);
                        dots.Add(new Point(newX, dot.Y));
                    }
                    break;
            }
            dots = dots.Distinct().ToList();
            Console.WriteLine(dots.Count);
        }
        public static void Part2()
        {
            var dots = File.ReadAllLines("Inputs/day13.txt").Where(x => x != "" && char.IsNumber(x[0])).Select(dot => new Point(int.Parse(dot.Split(",")[0]), int.Parse(dot.Split(",")[1]))).ToList();
            var foldInstrucions = File.ReadAllLines("Inputs/day13.txt").Where(x => x.StartsWith("fold along")).Select(inst => new Instruction() { Axis = inst.Substring(11).Split("=")[0], Position = int.Parse(inst.Substring(11).Split("=")[1]) }).ToList();
            foreach (var instruction in foldInstrucions)
            {
                switch (instruction.Axis)
                {
                    case "y":
                        var foldedDotsY = dots.Where(d => d.Y > instruction.Position).ToList();
                        dots.RemoveAll(dot => foldedDotsY.Contains(dot));
                        foreach (var dot in foldedDotsY)
                        {
                            var newY = dot.Y - ((dot.Y - instruction.Position) * 2);
                            dots.Add(new Point(dot.X, newY));
                        }
                        break;
                    case "x":
                        var foldedDotsX = dots.Where(d => d.X > instruction.Position).ToList();
                        dots.RemoveAll(dot => foldedDotsX.Contains(dot));
                        foreach (var dot in foldedDotsX)
                        {
                            var newX = dot.X - ((dot.X - instruction.Position) * 2);
                            dots.Add(new Point(newX, dot.Y));
                        }
                        break;
                }
                dots = dots.Distinct().ToList();
            }
            for (int y = 0; y <= dots.Max(d => d.Y); y++)
            {
                for (int x = 0; x <= dots.Max(d => d.X); x++)
                {
                    if (dots.Contains(new Point(x, y))) Console.Write("█");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        private class Instruction
        {
            public string Axis { get; set; }
            public int Position { get; set; }
        }
    }
}
