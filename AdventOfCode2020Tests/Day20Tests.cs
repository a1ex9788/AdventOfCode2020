using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day20Tests : Tester
    {
        protected override Solver Solver => new Day20(Resources.Day20Input);

        protected override string OutputPart1 => Resources.Day20Part1Output;
        protected override string OutputPart2 => Resources.Day20Part2Output;


        [TestMethod]
        [DataRow(20899048083289)]
        public void SolvePart1Test(long expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day20(Resources.Day20TestInput1).SolvePart1());
        }
    }
}