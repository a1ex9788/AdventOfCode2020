using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day08 : Solver
    {
        string program;

        public Day08(string input)
        {
            program = input;
        }


        public override long SolvePart1()
        {
            return CalculateAccumulatorBeforeLoop();
        }

        public override long SolvePart2()
        {
            return CalculateAccumulatorReplacingWrongInstruction();
        }


        public int CalculateAccumulatorBeforeLoop()
        {
            return new GameBoy(program).ExecuteProgram();
        }

        public int CalculateAccumulatorReplacingWrongInstruction()
        {
            return new GameBoy(program).ReplaceJmpOrNopWrongInstructionAndExecuteProgram();
        }
    }
}