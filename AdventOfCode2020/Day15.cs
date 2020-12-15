using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day15 : Solver
    {
        List<int> numbers;

        public Day15(string input)
        {
            numbers = input.Split(",").Select(i => Convert.ToInt32(i)).ToList();
        }


        public override long SolvePart1()
        {
            return CalculateNthNumber(2020);
        }

        public override long SolvePart2()
        {
            return CalculateNthNumber(30000000);
        }


        private long CalculateNthNumber(int nthNumber)
        {
            Hashtable lastOccurrencies = new Hashtable();

            int i;
            for (i = 0; i < numbers.Count(); i++)
            {
                lastOccurrencies.Add(numbers[i], i);
            }

            for (; i < nthNumber; i++)
            {
                if (lastOccurrencies.ContainsKey(numbers[i - 1]))
                {
                    int currentNumber = (i - 1) - (int)lastOccurrencies[numbers[i - 1]];
                    numbers.Add(currentNumber);
                }
                else
                {
                    numbers.Add(0);
                }

                lastOccurrencies[numbers[i - 1]] = i - 1;
            }

            return numbers[nthNumber - 1];
        }
    }
}