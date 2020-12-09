using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class GameBoy
    {
        List<Instruction> instructions;
        string program;

        int accumulator = 0;
        int pc = 0;
        Hashtable executedInstructions;


        public GameBoy(string program)
        {
            this.program = program;

            InitializeInstructions();
        }

        private void InitializeInstructions()
        {
            instructions = program.Split("\r\n").Select(i => new Instruction(i)).ToList();
        }


        public int ExecuteProgram() => InvokeExecuteProgram().accumulator;

        private (int accumulator, bool infiniteLoop) InvokeExecuteProgram()
        {
            accumulator = 0;
            pc = 0;
            executedInstructions = new Hashtable();

            while (true)
            {
                if (executedInstructions.ContainsKey(pc))
                {
                    return (accumulator, true);
                }

                if (pc == instructions.Count)
                {
                    return (accumulator, false);
                }

                Instruction currentInstruction = instructions[pc];

                executedInstructions[pc] = true;

                switch (currentInstruction.Type)
                {
                    case InstructionType.Acc:
                        accumulator += currentInstruction.HasPositiveFirstParameter() ? currentInstruction.ParameterValue : -currentInstruction.ParameterValue;
                        pc++;
                        break;
                    case InstructionType.Jmp:
                        pc += currentInstruction.HasPositiveFirstParameter() ? currentInstruction.ParameterValue : -currentInstruction.ParameterValue;
                        break;
                    case InstructionType.Nop:
                        pc++;
                        break;
                }
            }
        }

        public int ReplaceJmpOrNopWrongInstructionAndExecuteProgram()
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

                (int accumulator, bool infiniteLoop) = InvokeExecuteProgram();

                if (!infiniteLoop)
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
        public InstructionType Type;

        char parameterSing;

        public int ParameterValue;

        public Instruction(string instruction)
        {
            string[] instructionSplited = instruction.Split(" ");

            switch (instructionSplited[0])
            {
                case "acc":
                    Type = InstructionType.Acc;
                    break;
                case "jmp":
                    Type = InstructionType.Jmp;
                    break;
                case "nop":
                    Type = InstructionType.Nop;
                    break;
                default:
                    throw new Exception("Instruction type not supported.");
            }

            string firstParameter = instructionSplited[1];

            parameterSing = firstParameter[0];
            ParameterValue = Convert.ToInt32(firstParameter.Substring(1));
        }

        public bool HasPositiveFirstParameter()
        {
            return parameterSing == '+';
        }

        public bool IsAcc()
        {
            return Type == InstructionType.Acc;
        }

        public bool IsJmp()
        {
            return Type == InstructionType.Jmp;
        }

        public void ChangeToJmp()
        {
            Type = InstructionType.Jmp;
        }

        public bool IsNop()
        {
            return Type == InstructionType.Nop;
        }

        public void ChangeToNop()
        {
            Type = InstructionType.Nop;
        }
    }


    public enum InstructionType
    {
        Acc, Jmp, Nop
    }
}
