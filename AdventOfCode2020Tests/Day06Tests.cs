using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day06Tests : Tester
    {
        protected override Solver Solver => new Day06(Resources.Day06Input);

        protected override string OutputPart1 => Resources.Day06Part1Output;
        protected override string OutputPart2 => Resources.Day06Part2Output;


        [TestMethod]
        [DataRow("abc", 3)]
        [DataRow("a\r\nb\r\nc", 3)]
        [DataRow("ab\r\nac", 3)]
        [DataRow("a\r\na\r\na\r\na", 1)]
        [DataRow("b", 1)]
        public void CalculateNumberOfDifferentQuestionsTest(string groupAnswer, int expectedNumberOfQuestions)
        {
            Assert.AreEqual(expectedNumberOfQuestions, Day06.CalculateNumberOfDifferentQuestions(groupAnswer));
        }

        [TestMethod]
        [DataRow("abc", 3)]
        [DataRow("a\r\nb\r\nc", 0)]
        [DataRow("ab\r\nac", 1)]
        [DataRow("a\r\na\r\na\r\na", 1)]
        [DataRow("b", 1)]
        public void CalculateNumberOfEveryoneAnsweredQuestionsTest(string groupAnswer, int expectedNumberOfQuestions)
        {
            Assert.AreEqual(expectedNumberOfQuestions, Day06.CalculateNumberOfEveryoneAnsweredQuestions(groupAnswer));
        }
    }
}