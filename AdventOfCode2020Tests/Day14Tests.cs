using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day14Tests : Tester
    {
        protected override Solver Solver => new Day14(Resources.Day14Input);

        protected override string OutputPart1 => Resources.Day14Part1Output;
        protected override string OutputPart2 => Resources.Day14Part2Output;


        [TestMethod]
        [DataRow("mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X\r\n" +
                 "mem[8] = 11\r\n" +
                 "mem[7] = 101\r\n" +
                 "mem[8] = 0", 165)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day14(input).SolvePart1());
        }

        [TestMethod]
        [DataRow("mask = 000000000000000000000000000000X1001X\r\n" +
                 "mem[42] = 100\r\n" +
                 "mask = 00000000000000000000000000000000X0XX\r\n" +
                 "mem[26] = 1", 208)]
        public void SolvePart2Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day14(input).SolvePart2());
        }
    }
}