using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day04
    {
        public static void Part1()
        {
            var inputs = File.ReadAllLines("Inputs/day04.txt").ToList();
            var bingoNumbers = inputs[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            var bingoGrids = new List<BingoNumber>();
            int indexer = 0;
            var rowCount = 0;
            for (int i = 2; i < inputs.Count; i++)
            {
                if (inputs[i] == "")
                {
                    indexer++;
                    rowCount = 0;
                    continue;
                }
                var line = inputs[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                var columncount = 0;
                foreach (var item in line)
                {
                    bingoGrids.Add(new BingoNumber() { GridNumber = indexer, BingoNumberValue = item, GridLocation = new Point(columncount, rowCount) });
                    columncount++;
                }
                rowCount++;
            }
            int? foundWinner = null;
            foreach (var number in bingoNumbers)
            {
                bingoGrids.Where(v => v.BingoNumberValue == number).ToList().ForEach(x => x.Hit = true);
                var groups = bingoGrids.GroupBy(x => x.GridNumber);
                foreach (var group in groups)
                {
                    var rowhit = group.GroupBy(x => x.GridLocation.X).Any(x => x.Count(y => y.Hit) == 5);
                    var columnhit = group.GroupBy(x => x.GridLocation.Y).Any(x => x.Count(y => y.Hit) == 5);
                    if (rowhit || columnhit)
                    {
                        foundWinner = group.Key;
                        var answer = group.Where(x => !x.Hit).Sum(x => x.BingoNumberValue) * number;
                        Console.WriteLine(answer);
                        break;
                    }
                }
                if (foundWinner != null)
                {
                    break;
                }
            }
        }
        public static void Part2()
        {
            var inputs = File.ReadAllLines("Inputs/day04.txt").ToList();
            var bingoNumbers = inputs[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            var bingoGrids = new List<BingoNumber>();
            int indexer = 0;
            var rowCount = 0;
            for (int i = 2; i < inputs.Count; i++)
            {
                if (inputs[i] == "")
                {
                    indexer++;
                    rowCount = 0;
                    continue;
                }
                var line = inputs[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                var columncount = 0;
                foreach (var item in line)
                {
                    bingoGrids.Add(new BingoNumber() { GridNumber = indexer, BingoNumberValue = item, GridLocation = new Point(columncount, rowCount) });
                    columncount++;
                }
                rowCount++;
            }

            bool lastOne = false;
            foreach (var number in bingoNumbers)
            {
                bingoGrids.Where(v => v.BingoNumberValue == number).ToList().ForEach(x => x.Hit = true);
                var groups = bingoGrids.GroupBy(x => x.GridNumber);
                if (groups.Count() == 1)
                {
                    lastOne = true;
                }
                List<int> winningNumbers = new List<int>();

                foreach (var group in groups)
                {
                    var rowhit = group.GroupBy(x => x.GridLocation.X).Any(x => x.Count(y => y.Hit) == 5);
                    var columnhit = group.GroupBy(x => x.GridLocation.Y).Any(x => x.Count(y => y.Hit) == 5);
                    if (rowhit || columnhit)
                    {
                        winningNumbers.Add(group.Key);
                    }
                }
                if (winningNumbers.Any())
                {
                    if (lastOne)
                    {
                        var answer = bingoGrids.Where(x => !x.Hit).Sum(x => x.BingoNumberValue) * number;
                        Console.WriteLine(answer);
                        break;
                    }
                    foreach (var winningNumber in winningNumbers)
                    {
                        bingoGrids.RemoveAll(x => x.GridNumber == winningNumber);
                    }
                    winningNumbers = new List<int>();
                }
            }
        }
        public class BingoNumber
        {
            public int GridNumber { get; set; }
            public Point GridLocation { get; set; }
            public int BingoNumberValue { get; set; }
            public bool Hit { get; set; }
        }
    }
}
