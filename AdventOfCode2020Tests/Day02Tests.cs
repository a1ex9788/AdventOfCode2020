using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day02Tests : Tester
    {
        protected override Solver Solver => new Day02(Resources.Day02Input);

        protected override string OutputPart1 => Resources.Day02Part1Output;
        protected override string OutputPart2 => Resources.Day02Part2Output;


        [TestMethod]
        [DataRow("1-3 a: abcde", true)]
        [DataRow("1-3 b: cdefg", false)]
        [DataRow("2-9 c: ccccccccc", true)]
        public void MeetsRangeOcurrenciesCriteriaTest(string criteriaAndPassword, bool isValid)
        {
            Assert.AreEqual(isValid, Day02.MeetsRangeOcurrenciesCriteria(criteriaAndPassword));
        }

        [TestMethod]
        [DataRow("1-3 a: abcde", true)]
        [DataRow("1-3 b: cdefg", false)]
        [DataRow("2-9 c: ccccccccc", false)]
        public void MeetsPositionsCriteriaTest(string criteriaAndPassword, bool isValid)
        {
            Assert.AreEqual(isValid, Day02.MeetsPositionsCriteria(criteriaAndPassword));
        }
    }
}