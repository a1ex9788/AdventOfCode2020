using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day10Tests : Tester
    {
        protected override Solver Solver => new Day10(Resources.Day10Input);

        protected override string OutputPart1 => Resources.Day10Part1Output;
        protected override string OutputPart2 => Resources.Day10Part2Output;


        [TestMethod]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 35)]
        [DataRow("28\r\n33\r\n18\r\n42\r\n31\r\n14\r\n46\r\n20\r\n48\r\n47\r\n24\r\n23\r\n49\r\n45\r\n19\r\n38\r\n39\r\n11\r\n1\r\n32\r\n25\r\n35\r\n8\r\n17\r\n7\r\n9\r\n4\r\n2\r\n34\r\n10\r\n3", 220)]
        public void SolvePart1Test(string numbersList, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day10(numbersList).SolvePart1());
        }

        [TestMethod]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 8)]
        [DataRow("28\r\n33\r\n18\r\n42\r\n31\r\n14\r\n46\r\n20\r\n48\r\n47\r\n24\r\n23\r\n49\r\n45\r\n19\r\n38\r\n39\r\n11\r\n1\r\n32\r\n25\r\n35\r\n8\r\n17\r\n7\r\n9\r\n4\r\n2\r\n34\r\n10\r\n3", 19208)]
        public void SolvePart2Test(string numbersList, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day10(numbersList).SolvePart2());
        }

        [TestMethod]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 12, 1)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 11, 1)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 10, 1)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 9, 1)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 8, 1)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 7, 1)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 6, 2)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 5, 2)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 4, 2)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 3, 4)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 2, 8)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 1, 8)]
        [DataRow("16\r\n10\r\n15\r\n5\r\n1\r\n11\r\n7\r\n19\r\n6\r\n12\r\n4", 0, 8)]
        public void GetPossibleArrangements(string numbersList, int posInAdapters, int expectedPossibleArrangements)
        {
            Assert.AreEqual(expectedPossibleArrangements, new Day10(numbersList).GetPossibleArrangements(posInAdapters));
        }
    }
}