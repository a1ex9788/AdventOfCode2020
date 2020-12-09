using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day08 : Solver
    {
        List<Instruction> instructions;
        string input;

        public Day08(string input)
        {
            this.input = input;

            InitializeInstructions();
        }

        private void InitializeInstructions()
        {
            instructions = input.Split("\r\n").Select(i => new Instruction(i)).ToList();
        }


        public override long SolvePart1()
        {
            return CalculateAccumulatorBeforeLoop().accumulator;
        }

        public override long SolvePart2()
        {
            return CalculateAccumulatorReplacingWrongInstruction();
        }


        public (int accumulator, bool finished) CalculateAccumulatorBeforeLoop()
        {
            int accumulator = 0;
            int pc = 0;
            Hashtable visitedInstructions = new Hashtable();

            while (true)
            {
                if (visitedInstructions.ContainsKey(pc))
                {
                    return (accumulator, false);
                }

                if (pc == instructions.Count)
                {
                    return (accumulator, true);
                }

                Instruction currentInstruction = instructions[pc];

                visitedInstructions[pc] = true;

                switch (currentInstruction.NameInstruction)
                {
                    case "acc":
                        accumulator += currentInstruction.HasPositiveParameter() ? currentInstruction.ParameterValue : -currentInstruction.ParameterValue;
                        pc++;
                        break;
                    case "jmp":
                        pc += currentInstruction.HasPositiveParameter() ? currentInstruction.ParameterValue : -currentInstruction.ParameterValue;
                        break;
                    case "nop":
                        pc++;
                        break;
                }
            }
        }

        public int CalculateAccumulatorReplacingWrongInstruction()
        {
            for (int i = 0; i < instructions.Count(); i++)
            {
                Instruction instruction = instructions[i];

                if (instruction.IsAcc())
                {
                    continue;
                }

                if (instruction.IsJmp())
                {
                    instruction.ChangeToNop();
                }
                else
                {
                    instruction.ChangeToJmp();
                }

                (int accumulator, bool finished) = CalculateAccumulatorBeforeLoop();

                if (finished)
                {
                    return accumulator;
                }

                InitializeInstructions();
            }

            throw new Exception("The wrong instruction was not found.");
        }
    }

    class Instruction
    {
        public string NameInstruction;

        char ParameterSing;

        public int ParameterValue;

        public Instruction(string instruction)
        {
            string[] instructionSplited = instruction.Split(" ");

            NameInstruction = instructionSplited[0];

            string parameter = instructionSplited[1];

            ParameterSing = parameter[0];
            ParameterValue = Convert.ToInt16(parameter.Substring(1));
        }

        public bool HasPositiveParameter()
        {
            return ParameterSing == '+';
        }

        public bool IsAcc()
        {
            return NameInstruction.Equals("acc");
        }

        public bool IsJmp()
        {
            return NameInstruction.Equals("jmp");
        }

        public void ChangeToJmp()
        {
            NameInstruction = "jmp";
        }

        public bool IsNop()
        {
            return NameInstruction.Equals("nop");
        }

        public void ChangeToNop()
        {
            NameInstruction = "nop";
        }

        public override bool Equals(object obj)
        {
            Instruction other = obj as Instruction;

            return other.NameInstruction.Equals(other.NameInstruction)
                && other.ParameterSing.Equals(other.ParameterSing)
                && other.ParameterValue.Equals(other.ParameterValue);
        }
    }
}