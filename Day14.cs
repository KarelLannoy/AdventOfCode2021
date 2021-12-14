using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day14
    {
        public static void Part1()
        {
            var originalPolymerTemplate = File.ReadAllLines("Inputs/day14.txt")[0];
            var polymerTemplate = originalPolymerTemplate;
            var insertionPairs = File.ReadAllLines("Inputs/day14.txt").Skip(2).ToDictionary(x => x.Split(" -> ")[0], x => x.Split(" -> ")[1]);

            for (int i = 0; i < 10; i++)
            {
                var newTemplate = "";
                for (int x = 0; x < polymerTemplate.Length - 1; x++)
                {
                    var templatePair = polymerTemplate.Substring(x, 2);
                    var inBetweenString = insertionPairs[templatePair];
                    newTemplate += templatePair[0].ToString() + inBetweenString;
                }
                newTemplate += polymerTemplate.Last().ToString();
                polymerTemplate = newTemplate;
            }
            List<long> charCounts = new List<long>();
            foreach (var character in polymerTemplate.Distinct().ToList())
            {
                charCounts.Add(polymerTemplate.Count(c => c == character));
            }
            charCounts = charCounts.OrderByDescending(x => x).ToList();
            Console.WriteLine(charCounts.First() - charCounts.Last());
        }
        public static void Part2()
        {
            var originalPolymerTemplate = File.ReadAllLines("Inputs/day14.txt")[0];
            var polymerTemplate = originalPolymerTemplate;
            var insertionPairs = File.ReadAllLines("Inputs/day14.txt").Skip(2).ToDictionary(x => x.Split(" -> ")[0], x => x.Split(" -> ")[1]);
            var pairCounts = insertionPairs.Select(x => new KeyValuePair<string, long>(x.Key, Convert.ToInt64(0))).ToList().ToDictionary(x => x.Key, x => x.Value);
            Dictionary<char, long> charCounts = new Dictionary<char, long>();

            for (int x = 0; x < polymerTemplate.Length - 1; x++)
            {
                pairCounts[$"{polymerTemplate[x]}{polymerTemplate[x + 1]}"]++;
                if (charCounts.ContainsKey(polymerTemplate[x])) charCounts[polymerTemplate[x]]++;
                else charCounts.Add(polymerTemplate[x], 1);
            }
            if (charCounts.ContainsKey(polymerTemplate.Last())) charCounts[polymerTemplate.Last()]++;
            else charCounts.Add(polymerTemplate.Last(), 1);

            for (int i = 0; i < 40; i++)
            {
                var newPairs = pairCounts.ToDictionary(x => x.Key, x => Convert.ToInt64(0));
                foreach (var pairCount in pairCounts)
                {
                    char character = insertionPairs[pairCount.Key][0];
                    string firstPair = $"{pairCount.Key[0]}{character}";
                    string secondPair = $"{character}{pairCount.Key[1]}";

                    newPairs[firstPair] = newPairs[firstPair] += pairCount.Value;
                    newPairs[secondPair] = newPairs[secondPair] += pairCount.Value;
                    if (charCounts.ContainsKey(character)) charCounts[character] += pairCount.Value;
                    else charCounts.Add(character, pairCount.Value);
                }
                pairCounts = newPairs;
            }
            var results = charCounts.OrderByDescending(x => x.Value).ToList();
            Console.WriteLine(results.First().Value - results.Last().Value);
        }
    }
}
