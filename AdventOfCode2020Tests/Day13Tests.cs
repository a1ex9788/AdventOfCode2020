using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day13Tests : Tester
    {
        protected override Solver Solver => new Day13(Resources.Day13Input);

        protected override string OutputPart1 => Resources.Day13Part1Output;
        protected override string OutputPart2 => Resources.Day13Part2Output;


        [TestMethod]
        [DataRow("939\r\n7,13,x,x,59,x,31,19", 295)]
        public void SolvePart1Test(string input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day13(input).SolvePart1());
        }

        [TestMethod]
        //[DataRow("5\r\n17,x,13,19", 3417)]
        //[DataRow("5\r\n67,7,59,61", 754018)]
        //[DataRow("5\r\n67,x,7,59,61", 779210)]
        //[DataRow("5\r\n67,7,x,59,61", 1261476)]
        [DataRow("5\r\n1789,37,47,1889", 1202161486)]
        public void SolvePart2Test(string input, int expectedEarliestCommonTimestamp)
        {
            Assert.AreEqual(expectedEarliestCommonTimestamp, new Day13(input).SolvePart2());
        }
    }
}