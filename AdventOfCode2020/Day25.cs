using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day25 : Solver
    {
        int cardPublicKey;
        int doorPublicKey;

        public Day25(string input)
        {
            string[] inputSplitted = input.Split("\r\n");

            cardPublicKey = Convert.ToInt32(inputSplitted[0]);
            doorPublicKey = Convert.ToInt32(inputSplitted[1]);
        }

        public override long SolvePart1()
        {
            int cardLoopSize = CalculateLoopSize(cardPublicKey);

            return ApplyLoopSize(cardLoopSize, doorPublicKey);
        }

        public override long SolvePart2()
        {
            return 5;
        }


        public static int CalculateLoopSize(int wantedNumber)
        {
            int loopSize = 0;
            int currentNumber = 1;
            int subjectNumber = 7;

            while (currentNumber != wantedNumber)
            {
                currentNumber = (currentNumber * subjectNumber) % 20201227;
                loopSize++;
            }

            return loopSize;
        }

        public static int ApplyLoopSize(int loopSize, int subjectNumber = 7)
        {
            long result = 1;

            for (int i = 0; i < loopSize; i++)
            {
                result = (result * subjectNumber) % 20201227;
            }

            return Convert.ToInt32(result);
        }
    }
}