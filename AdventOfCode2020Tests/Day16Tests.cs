using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day16Tests : Tester
    {
        protected override Solver Solver => new Day16(Resources.Day16Input);

        protected override string OutputPart1 => Resources.Day16Part1Output;
        protected override string OutputPart2 => Resources.Day16Part2Output;


        [TestMethod]
        [DataRow("7,3,47", 0)]
        [DataRow("40,4,50", 4)]
        [DataRow("55,2,20", 55)]
        [DataRow("38,6,12", 12)]
        public void CalculateTicketScanningErrorsTest(string nearbyTicket, int expectedNumberOfScanningErrors)
        {
            string numbersList = "class: 1-3 or 5-7\r\n" +
                 "row: 6-11 or 33-44\r\n" +
                 "seat: 13-40 or 45-50\r\n\r\n" +
                 "your ticket:\r\n" +
                 "7,1,14\r\n\r\n" +
                 "nearby tickets:\r\n" +
                 "7,3,47\r\n" +
                 "40,4,50\r\n" +
                 "55,2,20\r\n" +
                 "38,6,12";

            Assert.AreEqual(expectedNumberOfScanningErrors, new Day16(numbersList).CalculateTicketScanningErrors(nearbyTicket));
        }

        [TestMethod]
        [DataRow("class: 1-3 or 5-7\r\n" +
                 "row: 6-11 or 33-44\r\n" +
                 "seat: 13-40 or 45-50\r\n\r\n" +
                 "your ticket:\r\n" +
                 "7,1,14\r\n\r\n" +
                 "nearby tickets:\r\n" +
                 "7,3,47\r\n" +
                 "40,4,50\r\n" +
                 "55,2,20\r\n" +
                 "38,6,12", 71)]
        public void SolvePart1Test(string numbersList, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day16(numbersList).SolvePart1());
        }
    }
}