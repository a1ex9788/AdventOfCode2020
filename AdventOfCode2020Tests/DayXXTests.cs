using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class DayXXTests : Tester
    {
        protected override Solver Solver => new DayXX(Resources.DayXXInput);

        protected override string OutputPart1 => Resources.DayXXPart1Output;
        protected override string OutputPart2 => Resources.DayXXPart2Output;


        [TestMethod]
        [DataRow("\r\n", -1)]
        public void SolvePart1Test(string numbersList, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new DayXX(numbersList).SolvePart1());
        }
    }
}