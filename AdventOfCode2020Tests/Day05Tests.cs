using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day05Tests : Tester
    {
        protected override Solver Solver => new Day05(Resources.Day05Input);

        protected override string OutputPart1 => Resources.Day05Part1Output;
        protected override string OutputPart2 => Resources.Day05Part2Output;


        [TestMethod]
        [DataRow("FBFBBFFRLR", 357)]
        [DataRow("BFFFBBFRRR", 567)]
        [DataRow("FFFBBBFRRR", 119)]
        [DataRow("BBFFBBFRLL", 820)]
        public void CalculateSeatIdTest(string boardingPass, int expectedSeatId)
        {
            Assert.AreEqual(expectedSeatId, Day05.CalculateSeatId(boardingPass));
        }
    }
}