using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day03Tests : Tester
    {
        protected override Solver Solver => new Day03(Resources.Day03Input);

        protected override string OutputPart1 => Resources.Day03Part1Output;
        protected override string OutputPart2 => Resources.Day03Part2Output;


        [TestMethod]
        [DataRow(3, 1, 7)]
        [DataRow(1, 1, 2)]
        [DataRow(5, 1, 3)]
        [DataRow(7, 1, 4)]
        [DataRow(1, 2, 2)]
        public void CalculeNumberOfTreesEncounteredTest(int rightSlope, int downSlope, int numberOfTrees)
        {
            Assert.AreEqual(numberOfTrees, new Day03(Resources.Day03TestInput).CalculeNumberOfTreesEncountered(rightSlope, downSlope));
        }
    }
}