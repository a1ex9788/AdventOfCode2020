using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day14 : Solver
    {
        List<MaskBlock> maskBlocks;

        public Day14(string input)
        {
            maskBlocks = input.Split("mask = ").Where(i => !i.Equals("")).Select(i => new MaskBlock(i)).ToList();
        }


        public override long SolvePart1()
        {
            Hashtable memory = new Hashtable();

            foreach (MaskBlock maskBlock in maskBlocks)
            {
                foreach ((int memoryPos, int value) in maskBlock.MemoryChanges)
                {
                    memory[memoryPos] = Convert.ToInt64(ApplyVersion1Mask(ToBinary36(value), maskBlock.Mask), 2);
                }
            }

            return memory.Values.Cast<long>().Sum();
        }

        public override long SolvePart2()
        {
            Hashtable memory = new Hashtable();

            foreach (MaskBlock maskBlock in maskBlocks)
            {
                foreach ((int memoryPos, int value) in maskBlock.MemoryChanges)
                {
                    foreach (string memoryAdress in ApplyVersion2Mask(ToBinary36(memoryPos), maskBlock.Mask))
                    {
                        memory[memoryAdress] = value;
                    }
                }
            }

            long result = 0;

            foreach (int value in memory.Values.Cast<int>())
            {
                result += value;
            }

            return result;
        }


        private static string ToBinary36(int number)
        {
            string binary = Convert.ToString(number, 2);

            string binary36 = "";

            for (int i = 0; i < 36 - binary.Length; i++)
            {
                binary36 += "0";
            }

            binary36 += binary;

            return binary36;
        }

        private static string ApplyVersion1Mask(string number, string mask)
        {
            string maskAppliedNumber = "";

            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == 'X')
                {
                    maskAppliedNumber += number[i];
                }
                else
                {
                    maskAppliedNumber += mask[i];
                }
            }

            return maskAppliedNumber;
        }

        private static List<string> ApplyVersion2Mask(string number, string mask)
        {
            List<string> maskAppliedList = new List<string>() { "" };

            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == '0')
                {
                    for (int j = 0; j < maskAppliedList.Count(); j++)
                    {
                        maskAppliedList[j] += number[i];
                    }
                }
                else if (mask[i] == '1')
                {
                    for (int j = 0; j < maskAppliedList.Count(); j++)
                    {
                        maskAppliedList[j] += 1;
                    }
                }
                else
                {
                    List<string> maskAppliedListDuplicated = new List<string>();

                    for (int j = 0; j < maskAppliedList.Count(); j++)
                    {
                        maskAppliedListDuplicated.Add(maskAppliedList[j] + '1');
                        maskAppliedList[j] += '0';
                    }

                    maskAppliedList.AddRange(maskAppliedListDuplicated);
                }
            }

            return maskAppliedList;
        }
    }

    class MaskBlock
    {
        public string Mask;

        public List<(int memoryPos, int value)> MemoryChanges = new List<(int memoryPos, int value)>();

        public MaskBlock(string maskBlock)
        {
            string[] maskBlockSplitted = maskBlock.Split("\r\n");

            Mask = maskBlockSplitted[0];

            for (int i = 1; i < maskBlockSplitted.Length; i++)
            {
                if (maskBlockSplitted[i].Equals(""))
                {
                    continue;
                }

                string memoryChange = maskBlockSplitted[i].Replace("mem[", "").Replace("]", "").Trim();
                string[] memoryChangeSplitted = memoryChange.Split("=");

                MemoryChanges.Add((Convert.ToInt32(memoryChangeSplitted[0]), Convert.ToInt32(memoryChangeSplitted[1])));
            }
        }
    }
}