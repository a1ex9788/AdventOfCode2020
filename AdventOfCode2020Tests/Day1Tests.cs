using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day01Tests : Tester
    {
        protected override Solver Solver => new Day01(Resources.Day01Input);

        protected override string OutputPart1 => Resources.Day01Part1Output;
        protected override string OutputPart2 => Resources.Day01Part2Output;


        [TestMethod]
        [DataRow("1721\n979\n366\n299\n675\n1456", 514579)]
        public void SearchWantedPairTest(string numbersList, int expectedNumber)
        {
            Assert.AreEqual(expectedNumber, new Day01(numbersList).SolvePart1());
        }

        [TestMethod]
        [DataRow("1721\n979\n366\n299\n675\n1456", 241861950)]
        public void SearchWantedTrioTest(string numbersList, int expectedNumber)
        {
            Assert.AreEqual(expectedNumber, new Day01(numbersList).SolvePart2());
        }
    }
}