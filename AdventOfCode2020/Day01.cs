using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day01 : Solver
    {
        string[] numbersList;

        public long WANTED_NUMBER = 2020;

        public Day01(string input)
        {
            numbersList = input.Split("\r\n");
        }


        public override long SolvePart1()
        {
            (long firstNumber, long secondNumber) = SearchWantedPair();

            return firstNumber * secondNumber;
        }

        public override long SolvePart2()
        {
            (int firstNumber, int secondNumber, int thirdNumber) = SearchWantedTrio();

            return firstNumber * secondNumber * thirdNumber;
        }


        private (long, long) SearchWantedPair()
        {
            Hashtable hashtable = new Hashtable();
            int FOUND = 5;

            foreach (string number in numbersList)
            {
                long currentNumber = Convert.ToInt64(number);
                long expectedNumber = WANTED_NUMBER - currentNumber;

                if (FOUND.Equals(hashtable[expectedNumber]) && !currentNumber.Equals(expectedNumber))
                {
                    return (currentNumber, expectedNumber);
                }

                hashtable[currentNumber] = FOUND;
            }

            throw new Exception("The wanted numbers were not found.");
        }

        private (int, int, int) SearchWantedTrio()
        {
            foreach (string firstNumber in numbersList)
            {
                foreach (string secondNumber in numbersList.ToList().Except(new List<string>() { firstNumber }))
                {
                    foreach (string thirdNumber in numbersList.ToList().Except(new List<string>() { firstNumber, secondNumber }))
                    {
                        int a = Convert.ToInt32(firstNumber);
                        int b = Convert.ToInt32(secondNumber);
                        int c = Convert.ToInt32(thirdNumber);

                        if (a + b + c == 2020)
                        {
                            return (a, b, c);
                        }
                    }
                }
            }

            throw new Exception("The wanted numbers were not found.");
        }
    }
}