using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day16
    {
        public static void Part1()
        {
            var hexstring = File.ReadAllText("Inputs/day16.txt");
            string binarystring = String.Join(String.Empty, hexstring.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            _versions = new List<int>();
            DecodeString(binarystring);
            Console.WriteLine(_versions.Sum(x => x));
        }

        public static void Part2()
        {
            var hexstring = File.ReadAllText("Inputs/day16.txt");
            string binarystring = String.Join(String.Empty, hexstring.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            _versions = new List<int>();
            var value = DecodeString(binarystring);
            Console.WriteLine(value.Item2);
        }

        private static List<int> _versions { get; set; }

        private static (int, long) DecodeString(string binarystring)
        {
            long value = 0;
            var version = binarystring.Substring(0, 3);
            _versions.Add(Convert.ToInt32(version, 2));
            var typeId = binarystring.Substring(3, 3);
            var typeIdInt = Convert.ToInt32(typeId, 2);
            var position = 6;
            if (typeIdInt == 4)
            {
                //Literal
                var leadingBit = 1;
                var litteral = "";
                while(leadingBit == 1)
                {
                    var digit = binarystring.Substring(position, 5);
                    leadingBit = int.Parse(digit[0].ToString());
                    litteral += digit.Substring(1);
                    position += 5;
                    
                }
                value = Convert.ToInt64(litteral, 2);
            }
            else
            {
                List<long> Values = new List<long>();
                //Operator
                var lengthTypeId = binarystring.Substring(position, 1);
                position += 1;
                if (lengthTypeId == "0")
                {
                    //TotalLength
                    var totalLengthInBits = binarystring.Substring(position, 15);
                    position += 15;
                    var totalLength = Convert.ToInt32(totalLengthInBits, 2);

                    var previousPosition = position;
                    while (position - previousPosition < totalLength)
                    {
                        var result = DecodeString(binarystring.Substring(position));
                        position += result.Item1;
                        Values.Add(result.Item2);
                    }
                }else
                {
                    var totalLengthInBits = binarystring.Substring(position, 11);
                    position += 11;
                    var numberOfPackets = Convert.ToInt32(totalLengthInBits, 2);
                    int counter = 0;
                    while (counter < numberOfPackets)
                    {
                        var result = DecodeString(binarystring.Substring(position));
                        position += result.Item1;
                        Values.Add(result.Item2);
                        counter++;
                    }
                }
                switch (typeIdInt)
                {
                    case 0:
                        value = Values.Sum();
                        break;
                    case 1:
                        value = Values.Aggregate((x, y) => x * y);
                        break;
                    case 2:
                        value = Values.Min();
                        break;
                    case 3:
                        value = Values.Max();
                        break;
                    case 5:
                        value = Values[0] > Values[1] ? 1 : 0;
                        break;
                    case 6:
                        value = Values[0] < Values[1] ? 1 : 0;
                        break;
                    case 7:
                        value = Values[0] == Values[1] ? 1 : 0;
                        break;
                }
            }
            return (position, value);
        }
    }
}
