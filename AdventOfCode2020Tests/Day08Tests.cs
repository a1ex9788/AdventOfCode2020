using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day08Tests : Tester
    {
        protected override Solver Solver => new Day08(Resources.Day08Input);

        protected override string OutputPart1 => Resources.Day08Part1Output;
        protected override string OutputPart2 => Resources.Day08Part2Output;


        [TestMethod]
        [DataRow("nop +0\r\n" +
                 "acc +1\r\n" +
                 "jmp +4\r\n" +
                 "acc +3\r\n" +
                 "jmp -3\r\n" +
                 "acc -99\r\n" +
                 "acc +1\r\n" +
                 "jmp -4\r\n" +
                 "acc +6", 5)]
        public void GameBoy_ExecuteProgramTest(string program, int expectedAccumulator)
        {
            Assert.AreEqual(expectedAccumulator, new GameBoy(program).ExecuteProgram());
        }

        [TestMethod]
        [DataRow("nop +0\r\n" +
                 "acc +1\r\n" +
                 "jmp +4\r\n" +
                 "acc +3\r\n" +
                 "jmp -3\r\n" +
                 "acc -99\r\n" +
                 "acc +1\r\n" +
                 "jmp -4\r\n" +
                 "acc +6", 8)]
        public void GameBoy_ReplaceJmpOrNopWrongInstructionAndExecuteProgramTest(string program, int expectedAccumulator)
        {
            Assert.AreEqual(expectedAccumulator, new GameBoy(program).ReplaceJmpOrNopWrongInstructionAndExecuteProgram());
        }
    }
}