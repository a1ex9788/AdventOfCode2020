using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day22Tests : Tester
    {
        protected override Solver Solver => new Day22(Resources.Day22Input);

        protected override string OutputPart1 => Resources.Day22Part1Output;
        protected override string OutputPart2 => Resources.Day22Part2Output;


        [TestMethod]
        [DataRow(306)]
        public void SolvePart1Test(int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day22(Resources.Day22TestInput1).SolvePart1());
        }

        [TestMethod]
        [DataRow(291)]
        public void SolvePart2Test(int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day22(Resources.Day22TestInput1).SolvePart2());
        }
    }
}