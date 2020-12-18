using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day18Tests : Tester
    {
        protected override Solver Solver => new Day18(Resources.Day18Input);

        protected override string OutputPart1 => Resources.Day18Part1Output;
        protected override string OutputPart2 => Resources.Day18Part2Output;


        [TestMethod]
        [DataRow("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [DataRow("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [DataRow("2 * 3 + (4 * 5)", 26)]
        [DataRow("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [DataRow("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void EvaluateExpressionWithLeftToRightRuleTest(string expression, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Day18.EvaluateExpressionWithLeftToRightRule(expression));
        }

        [TestMethod]
        [DataRow("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [DataRow("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [DataRow("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [DataRow("2 * 3 + (4 * 5)", 46)]
        [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [DataRow("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void EvaluateExpressionWithSumPrecedenceRuleTest(string expression, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Day18.EvaluateExpressionWithSumPrecedenceRule(expression));
        }
    }
}