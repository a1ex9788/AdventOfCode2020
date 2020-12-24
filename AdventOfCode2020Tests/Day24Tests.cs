using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day24Tests : Tester
    {
        protected override Solver Solver => new Day24(Resources.Day24Input);

        protected override string OutputPart1 => Resources.Day24Part1Output;
        protected override string OutputPart2 => Resources.Day24Part2Output;


        [TestMethod]
        [DataRow(10)]
        public void SolvePart1Test(int expectedBlackTiles)
        {
            Assert.AreEqual(expectedBlackTiles, new Day24(Resources.Day24TestInput1).SolvePart1());
        }

        [TestMethod]
        [DataRow(1, 15)]
        [DataRow(2, 12)]
        [DataRow(3, 25)]
        [DataRow(4, 14)]
        [DataRow(5, 23)]
        [DataRow(6, 28)]
        [DataRow(7, 41)]
        [DataRow(8, 37)]
        [DataRow(9, 49)]
        [DataRow(10, 37)]
        public void SimulateNStepsTest(int steps, int expectedBlackTiles)
        {
            Assert.AreEqual(expectedBlackTiles, new Day24(Resources.Day24TestInput1).SimulateNSteps(steps));
        }

        [TestMethod]
        [DataRow(2208)]
        public void SolvePart2Test(int expectedBlackTiles)
        {
            Assert.AreEqual(expectedBlackTiles, new Day24(Resources.Day24TestInput1).SolvePart2());
        }
    }
}