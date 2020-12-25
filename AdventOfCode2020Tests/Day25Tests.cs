using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day25Tests : Tester
    {
        protected override Solver Solver => new Day25(Resources.Day25Input);

        protected override string OutputPart1 => Resources.Day25Part1Output;
        protected override string OutputPart2 => Resources.Day25Part2Output;


        [TestMethod]
        [DataRow(8, 7, 5764801)]
        [DataRow(11, 7, 17807724)]
        public void ApplyLoopSizeTest(int loopSize, int subjectNumber, int expectedEncryptionKey)
        {
            Assert.AreEqual(expectedEncryptionKey, Day25.ApplyLoopSize(loopSize, subjectNumber));
        }

        [TestMethod]
        [DataRow(5764801, 8)]
        [DataRow(17807724, 11)]
        public void CalculateLoopSizeTest(int wantedNumber, int expectedLoopSize)
        {
            Assert.AreEqual(expectedLoopSize, Day25.CalculateLoopSize(wantedNumber));
        }

        [TestMethod]
        [DataRow("5764801\r\n17807724", 14897079)]
        public void SolvePart1Test(string input, int expectedEncryptionKey)
        {
            Assert.AreEqual(expectedEncryptionKey, new Day25(input).SolvePart1());
        }
    }
}