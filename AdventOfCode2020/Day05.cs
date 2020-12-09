using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day05 : Solver
    {
        string[] boardingPasses;
        SortedList seatsIds = new SortedList();

        static int NUMBER_OF_ROWS = 128;
        static int NUMBER_OF_COLUMNS = 8;

        public Day05(string input)
        {
            boardingPasses = input.Split("\r\n");
        }


        public override long SolvePart1()
        {
            return boardingPasses.Max(bp => CalculateSeatId(bp));
        }

        public override long SolvePart2()
        {
            foreach (string boardingPass in boardingPasses)
            {
                seatsIds.Add(CalculateSeatId(boardingPass), true);
            }

            foreach (DictionaryEntry seatId in seatsIds)
            {
                if (!seatsIds.ContainsKey((int) seatId.Key + 1))
                {
                    return (int) seatId.Key + 1;
                }
            }

            throw new Exception("The empty seat was not found.");
        }


        public static int CalculateSeatId(string boardingPass)
        {
            int rowLowerBound = 0, rowUpperBound = NUMBER_OF_ROWS - 1;
            int columnLowerBound = 0, columnUpperBound = NUMBER_OF_COLUMNS - 1;

            for (int i = 0; i < 7; i++)
            {
                int numberOfSeatsLeft = rowUpperBound - rowLowerBound + 1;

                if (boardingPass[i] == 'F')
                {
                    rowUpperBound = rowLowerBound + numberOfSeatsLeft / 2 - 1;
                }
                else
                {
                    rowLowerBound = rowUpperBound - numberOfSeatsLeft / 2 + 1;
                }
            }

            for (int i = 7; i < 10; i++)
            {
                int numberOfSeatsLeft = columnUpperBound - columnLowerBound + 1;

                if (boardingPass[i] == 'L')
                {
                    columnUpperBound = columnLowerBound + numberOfSeatsLeft / 2 - 1;
                }
                else
                {
                    columnLowerBound = columnUpperBound - numberOfSeatsLeft / 2 + 1;
                }
            }

            return rowLowerBound * 8 + columnLowerBound;
        }
    }
}