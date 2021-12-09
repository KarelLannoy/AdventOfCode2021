using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Day09.Part1();

            sw.Stop();
            Console.WriteLine($"Timing: {sw.Elapsed}");
            sw.Reset();
            sw.Start();

            Day09.Part2();

            sw.Stop();
            Console.WriteLine($"Timing: {sw.Elapsed}");
        }
    }
}
