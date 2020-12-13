using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day12Tests : Tester
    {
        protected override Solver Solver => new Day12(Resources.Day12Input);

        protected override string OutputPart1 => Resources.Day12Part1Output;
        protected override string OutputPart2 => Resources.Day12Part2Output;


        [TestMethod]
        [DataRow("F10\r\n" +
                 "N3\r\n" +
                 "F7\r\n" +
                 "R90\r\n" +
                 "F11", 25)]
        public void SolvePart1Test(string instructions, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day12(instructions).SolvePart1());
        }

        [TestMethod]
        [DataRow("F10\r\n" +
                 "N3\r\n" +
                 "F7\r\n" +
                 "R90\r\n" +
                 "F11", 286)]
        public void SolvePart2Test(string instructions, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day12(instructions).SolvePart2());
        }
    }
}