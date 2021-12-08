using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day08
    {
        public static void Part1()
        {
            var outputs = File.ReadAllLines("Inputs/day08.txt").ToList().Select(s => s.Split(" | ")[1]).ToList().Select(s=>s.Split(" ")).ToList();
            Console.WriteLine(outputs.Sum(o => o.Count(s => s.Length == 2 || s.Length == 7 || s.Length == 3 || s.Length == 4)));
        }
        public static void Part2()
        {
            var outputs = File.ReadAllLines("Inputs/day08.txt").ToList().Select(s => s.Split(" | ")[1]).ToList().Select(s => s.Split(" ")).ToList();
            var numbersList = File.ReadAllLines("Inputs/day08.txt").ToList().Select(s=>s.Replace(" | ", " ")).ToList().Select(s => s.Split(" ")).ToList();
            long outputCount = 0;
            for (int i = 0; i < outputs.Count; i++)
            {
                var oneString = numbersList[i].First(n => n.Length == 2);
                var fourString = numbersList[i].First(n => n.Length == 4);
                var sevenString = numbersList[i].First(n => n.Length == 3);
                var threeString = numbersList[i].First(n => n.Length == 5 && n.Contains(sevenString[0]) && n.Contains(sevenString[1]) && n.Contains(sevenString[2]));
                var nineString = numbersList[i].First(n => n.Length == 6 && n.Contains(threeString[0]) && n.Contains(threeString[1]) && n.Contains(threeString[2]) && n.Contains(threeString[3]) && n.Contains(threeString[4]));
                var eightString = numbersList[i].First(n => n.Length == 7);
                var upperMiddle = sevenString.Replace(oneString[0].ToString(), "").Replace(oneString[1].ToString(), "")[0];
                var upperLeft = fourString.Replace(threeString[0].ToString(), "").Replace(threeString[1].ToString(), "").Replace(threeString[2].ToString(), "").Replace(threeString[3].ToString(), "").Replace(threeString[4].ToString(), "")[0];
                var middleMiddle = fourString.Replace(oneString[0].ToString(), "").Replace(oneString[1].ToString(), "").Replace(upperLeft.ToString(), "")[0];
                var zeroString = numbersList[i].First(n => n.Length == 6 && !n.Contains(middleMiddle));
                var twoString = numbersList[i].First(n => n.Length == 5 && n != threeString && !n.Contains(upperLeft));
                var fiveString = numbersList[i].First(n => n.Length == 5 && n.Contains(upperLeft));
                var sixString = numbersList[i].First(n => n.Length == 6 && n != zeroString && n != nineString);
                var outputNumberString = "";
                foreach (var output in outputs[i])
                {
                    if (output.OrderBy(a => a).SequenceEqual(zeroString.OrderBy(a=>a))) outputNumberString += "0";
                    if (output.OrderBy(a => a).SequenceEqual(oneString.OrderBy(a => a))) outputNumberString += "1";
                    if (output.OrderBy(a => a).SequenceEqual(twoString.OrderBy(a => a))) outputNumberString += "2";
                    if (output.OrderBy(a => a).SequenceEqual(threeString.OrderBy(a => a))) outputNumberString += "3";
                    if (output.OrderBy(a => a).SequenceEqual(fourString.OrderBy(a => a))) outputNumberString += "4";
                    if (output.OrderBy(a => a).SequenceEqual(fiveString.OrderBy(a => a))) outputNumberString += "5";
                    if (output.OrderBy(a => a).SequenceEqual(sixString.OrderBy(a => a))) outputNumberString += "6";
                    if (output.OrderBy(a => a).SequenceEqual(sevenString.OrderBy(a => a))) outputNumberString += "7";
                    if (output.OrderBy(a => a).SequenceEqual(eightString.OrderBy(a => a))) outputNumberString += "8";
                    if (output.OrderBy(a => a).SequenceEqual(nineString.OrderBy(a => a))) outputNumberString += "9";
                }
                outputCount += int.Parse(outputNumberString);
            }
            Console.WriteLine(outputCount);
        }  
    }
}
