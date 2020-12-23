using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day23Tests : Tester
    {
        protected override Solver Solver => new Day23(Resources.Day23Input);

        protected override string OutputPart1 => Resources.Day23Part1Output;
        protected override string OutputPart2 => Resources.Day23Part2Output;


        [TestMethod]
        [DataRow("389125467", 10, 92658374)]
        [DataRow("389125467", 20, 64937258)]
        [DataRow("389125467", 30, 35298467)]
        [DataRow("389125467", 35, 74985236)]
        [DataRow("389125467", 36, 78524936)]
        [DataRow("389125467", 100, 67384529)]
        public void GetLabellingAfterNMovesTest(string initialLabelling, int movesNumber, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day23(initialLabelling).GetLabellingAfterNMoves(movesNumber));
        }

        [TestMethod]
        [DataRow("389125467", 149245887792)]
        public void SolvePart2Test(string initialLabelling, long expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day23(initialLabelling).SolvePart2());
        }
    }
}