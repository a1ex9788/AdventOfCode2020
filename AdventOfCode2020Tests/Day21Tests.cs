using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day21Tests : Tester
    {
        protected override Solver Solver => new Day21(Resources.Day21Input);

        protected override string OutputPart1 => Resources.Day21Part1Output;
        protected override string OutputPart2 => Resources.Day21Part2Output;


        [TestMethod]
        [DataRow(5)]
        public void SolvePart1Test(int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day21(Resources.Day21TestInput1).SolvePart1());
        }

        [TestMethod]
        [DataRow("mxmxvkd,sqjhc,fvjkl")]
        public void SolvePart2Test(string expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day21(Resources.Day21TestInput1).SolvePart2String());
        }

        [TestMethod]
        [DataRow("spcqmzfg,rpf,dzqlq,pflk,bltrbvz,xbdh,spql,bltzkxx")]
        public void Part2TestString(string expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day21(Resources.Day21Input).SolvePart2String());
        }
    }
}