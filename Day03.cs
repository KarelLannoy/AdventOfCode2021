using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day03
    {
        public static void Part1()
        {
            var inputs = File.ReadAllLines("Inputs/day03.txt").ToList();
            var gamma = "";
            var epsilon = "";
            for (int i = 0; i < inputs[0].Length; i++)
            {
                var mostCommon = inputs.Count(str => str[i] == '0') < inputs.Count(str => str[i] == '1') ? "1" : "0";
                gamma += mostCommon;
                epsilon += mostCommon == "1" ? "0" : "1";
            }
            Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));
        }

        public static void Part2()
        {
            var inputs = File.ReadAllLines("Inputs/day03.txt").ToList();
            var oxygenList = inputs.Where(x => 1 == 1).ToList();
            var co2List = inputs.Where(x => 1 == 1).ToList();
            for (int i = 0; i < inputs[0].Length; i++)
            {
                if (oxygenList.Count != 1)
                { 
                    var oxygen_occurenses_0 = oxygenList.Count(str => str[i] == '0');
                    var oxygen_occurenses_1 = oxygenList.Count(str => str[i] == '1');
                    var oxygenBitToRemove = '0';
                    if (oxygen_occurenses_0 != oxygen_occurenses_1) oxygenBitToRemove = oxygen_occurenses_1 > oxygen_occurenses_0 ? '0' : '1';
                     oxygenList.RemoveAll(str => str[i] == oxygenBitToRemove);
                }
                if (co2List.Count != 1)
                {
                    var co2_occurenses_0 = co2List.Count(str => str[i] == '0');
                    var co2_occurenses_1 = co2List.Count(str => str[i] == '1');
                    var co2BitToRemove = '1';
                    if (co2_occurenses_0 != co2_occurenses_1) co2BitToRemove = co2_occurenses_1 < co2_occurenses_0 ? '0' : '1';
                    co2List.RemoveAll(str => str[i] == co2BitToRemove);
                }
            }
            Console.WriteLine(Convert.ToInt32(oxygenList[0], 2) * Convert.ToInt32(co2List[0], 2));
        }
    }
}
