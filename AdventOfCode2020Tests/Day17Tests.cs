using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day17Tests : Tester
    {
        protected override Solver Solver => new Day17(Resources.Day17Input);

        protected override string OutputPart1 => Resources.Day17Part1Output;
        protected override string OutputPart2 => Resources.Day17Part2Output;


        [TestMethod]
        [DataRow(".#.\r\n..#\r\n###", 112)]
        public void SolvePart1Test(string input, int expectedActiveCubesNumber)
        {
            Assert.AreEqual(expectedActiveCubesNumber, new Day17(input).SolvePart1());
        }

        [TestMethod]
        [DataRow(".#.\r\n..#\r\n###", 848)]
        public void SolvePart2Test(string input, int expectedActiveCubesNumber)
        {
            Assert.AreEqual(expectedActiveCubesNumber, new Day17(input).SolvePart2());
        }
    }
}