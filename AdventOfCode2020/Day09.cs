using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day09 : Solver
    {
        string[] numbers;
        int PREAMBLE_LENGHT;

        public Day09(string input, int preambleLenght)
        {
            numbers = input.Split("\r\n");
            PREAMBLE_LENGHT = preambleLenght;
        }


        public override long SolvePart1()
        {
            for (int i = PREAMBLE_LENGHT; i < numbers.Length; i++)
            {
                if (IsIncorrectNumber(numbers[i], i))
                {
                    return Convert.ToInt64(numbers[i]);
                }
            }

            throw new Exception("Any incorrect number found.");
        }

        public override long SolvePart2()
        {
            long firstIncorrectNumber = SolvePart1();

            for (int i = 0; i < numbers.Length; i++)
            {
                long sum = 0, j = 0;

                while (sum < firstIncorrectNumber)
                {
                    sum += Convert.ToInt64(numbers[i + j]);
                    j++;
                }

                if (sum != firstIncorrectNumber)
                {
                    continue;
                }

                List<long> wantedNumbers = new List<long>();

                for (int k = i; k < i + j; k++)
                {
                    wantedNumbers.Add(Convert.ToInt64(numbers[k]));
                }

                return wantedNumbers.Min() + wantedNumbers.Max();
            }

            throw new Exception("The wanted numbers were not found.");
        }


        public bool IsIncorrectNumber(string wantedNumber, int posInNumberList)
        {
            string numbersToInspect = "";

            for (int i = posInNumberList - PREAMBLE_LENGHT; i < posInNumberList; i++)
            {
                numbersToInspect += numbers[i] + "\r\n";
            }

            numbersToInspect = numbersToInspect.Substring(0, numbersToInspect.Length - 2);

            try
            {
                Day01 day01 = new Day01(numbersToInspect);
                day01.WANTED_NUMBER = Convert.ToInt64(wantedNumber);
                day01.SolvePart1();

                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}