using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day03 : Solver
    {
        string[] rows;

        int X_CELLS, Y_CELLS;

        public Day03(string input)
        {
            rows = input.Split("\r\n");

            X_CELLS = rows[0].Length;
            Y_CELLS = rows.Length;
        }


        public override long SolvePart1()
        {
            return CalculeNumberOfTreesEncountered(3, 1);
        }

        public override long SolvePart2()
        {
            return CalculeNumberOfTreesEncountered(1, 1)
                * CalculeNumberOfTreesEncountered(3, 1)
                * CalculeNumberOfTreesEncountered(5, 1)
                * CalculeNumberOfTreesEncountered(7, 1)
                * CalculeNumberOfTreesEncountered(1, 2);
        }


        public int CalculeNumberOfTreesEncountered(int rightSlope, int downSlope)
        {
            int numberOfTrees = 0;
            (int x, int y) currentPos = (0, 0);

            while (currentPos.y < Y_CELLS)
            {
                if (rows[currentPos.y][currentPos.x] == '#')
                {
                    numberOfTrees++;
                }

                currentPos.x += rightSlope;
                if (currentPos.x >= X_CELLS)
                {
                    currentPos.x = currentPos.x % X_CELLS;
                }

                currentPos.y += downSlope;
            }

            return numberOfTrees;
        }
    }
}