using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day19Tests : Tester
    {
        protected override Solver Solver => new Day19(Resources.Day19Input);

        protected override string OutputPart1 => Resources.Day19Part1Output;
        protected override string OutputPart2 => Resources.Day19Part2Output;


        [TestMethod]
        [DataRow("ababbb", true)]
        [DataRow("bababa", false)]
        [DataRow("abbbab", true)]
        [DataRow("aaabbb", false)]
        [DataRow("aaaabbb", false)]
        public void MatchRule(string message, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day19(Resources.Day19TestInput1).MatchRule0(message));
        }

        [TestMethod]
        [DataRow(2)]
        public void SolvePart1Test(int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day19(Resources.Day19TestInput1).SolvePart1());
        }

        [TestMethod]
        [DataRow("aaaabbaaaabbaaa", false)]
        [DataRow("abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa", false)]
        [DataRow("bbabbbbaabaabba", true)]
        [DataRow("babbbbaabbbbbabbbbbbaabaaabaaa", true)]
        [DataRow("aaabbbbbbaaaabaababaabababbabaaabbababababaaa", true)]
        [DataRow("bbbbbbbaaaabbbbaaabbabaaa", true)]
        [DataRow("bbbababbbbaaaaaaaabbababaaababaabab", true)]
        [DataRow("ababaaaaaabaaab", true)]
        [DataRow("ababaaaaabbbaba", true)]
        [DataRow("baabbaaaabbaaaababbaababb", true)]
        [DataRow("abbbbabbbbaaaababbbbbbaaaababb", true)]
        [DataRow("aaaaabbaabaaaaababaa", true)]
        [DataRow("aaaabbaabbaaaaaaabbbabbbaaabbaabaaa", true)]
        [DataRow("babaaabbbaaabaababbaabababaaab", false)]
        [DataRow("aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba", true)]
        public void MatchRuleWithLoops(string message, bool expectedResult)
        {
            Day19 solver = new Day19(Resources.Day19TestInput2);
            solver.IntroduceLoops();

            Assert.AreEqual(expectedResult, solver.MatchRule0(message));
        }

        [TestMethod]
        [DataRow(12)]
        public void SolvePart2Test(int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day19(Resources.Day19TestInput2).SolvePart2());
        }
    }
}