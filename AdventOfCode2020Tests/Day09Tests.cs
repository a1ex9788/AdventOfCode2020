using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day09Tests : Tester
    {
        protected override Solver Solver => new Day09(Resources.Day09Input, 25);

        protected override string OutputPart1 => Resources.Day09Part1Output;
        protected override string OutputPart2 => Resources.Day09Part2Output;


        [TestMethod]
        [DataRow("35\r\n" +
                 "20\r\n" +
                 "15\r\n" +
                 "25\r\n" +
                 "47\r\n" +
                 "40\r\n" +
                 "62\r\n" +
                 "55\r\n" +
                 "65\r\n" +
                 "95\r\n" +
                 "102\r\n" +
                 "117\r\n" +
                 "150\r\n" +
                 "182\r\n" +
                 "127\r\n" +
                 "219\r\n" +
                 "299\r\n" +
                 "277\r\n" +
                 "309\r\n" +
                 "576", 5, 127)]
        public void CalculateSeatIdTest(string numbersList, int preambleLenght, int firstIncorrectNumber)
        {
            Assert.AreEqual(firstIncorrectNumber, new Day09(numbersList, preambleLenght).SolvePart1());
        }

        [TestMethod]
        [DataRow("1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n20\r\n21\r\n22\r\n23\r\n24\r\n25", 25, 26, 25, false)]
        [DataRow("1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n20\r\n21\r\n22\r\n23\r\n24\r\n25", 25, 49, 25, false)]
        [DataRow("1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n20\r\n21\r\n22\r\n23\r\n24\r\n25", 25, 50, 25, true)]
        [DataRow("1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n20\r\n21\r\n22\r\n23\r\n24\r\n25", 25, 100, 25, true)]
        [DataRow("1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n20\r\n21\r\n22\r\n23\r\n25\r\n25", 25, 50, 25, true)]
        [DataRow("20\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n1\r\n21\r\n22\r\n23\r\n24\r\n25\r\n45", 25, 26, 26, false)]
        [DataRow("20\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n1\r\n21\r\n22\r\n23\r\n24\r\n25\r\n45", 25, 65, 26, true)]
        [DataRow("20\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n1\r\n21\r\n22\r\n23\r\n24\r\n25\r\n45", 25, 64, 26, false)]
        [DataRow("20\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n1\r\n21\r\n22\r\n23\r\n24\r\n25\r\n45", 25, 66, 26, false)]
        public void IsIncorrectNumberTest(string numbersList,int preambleLenght, int wantedNumber, int posInNumberList, bool isIncorrect)
        {
            Assert.AreEqual(isIncorrect, new Day09(numbersList, preambleLenght).IsIncorrectNumber(wantedNumber.ToString(), posInNumberList));
        }

        [TestMethod]
        [DataRow("35\r\n" +
                 "20\r\n" +
                 "15\r\n" +
                 "25\r\n" +
                 "47\r\n" +
                 "40\r\n" +
                 "62\r\n" +
                 "55\r\n" +
                 "65\r\n" +
                 "95\r\n" +
                 "102\r\n" +
                 "117\r\n" +
                 "150\r\n" +
                 "182\r\n" +
                 "127\r\n" +
                 "219\r\n" +
                 "299\r\n" +
                 "277\r\n" +
                 "309\r\n" +
                 "576", 5, 62)]
        public void SolvePart2Test(string numbersList, int preambleLenght, int expectedResult)
        {
            Assert.AreEqual(expectedResult, new Day09(numbersList, preambleLenght).SolvePart2());
        }
    }
}