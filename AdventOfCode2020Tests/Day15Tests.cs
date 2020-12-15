using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day15Tests : Tester
    {
        protected override Solver Solver => new Day15(Resources.Day15Input);

        protected override string OutputPart1 => Resources.Day15Part1Output;
        protected override string OutputPart2 => Resources.Day15Part2Output;


        [TestMethod]
        [DataRow("0,3,6", 436)]
        [DataRow("1,3,2", 1)]
        [DataRow("2,1,3", 10)]
        [DataRow("1,2,3", 27)]
        [DataRow("2,3,1", 78)]
        [DataRow("3,2,1", 438)]
        [DataRow("3,1,2", 1836)]
        public void SolvePart1Test(string startingNumbers, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day15(startingNumbers).SolvePart1());
        }

        [TestMethod]
        [DataRow("0,3,6", 175594)]
        //[DataRow("1,3,2", 2578)]
        //[DataRow("2,1,3", 3544142)]
        //[DataRow("1,2,3", 261214)]
        //[DataRow("2,3,1", 6895259)]
        //[DataRow("3,2,1", 18)]
        //[DataRow("3,1,2", 362)]
        public void SolvePart2Test(string startingNumbers, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day15(startingNumbers).SolvePart2());
        }
    }
}