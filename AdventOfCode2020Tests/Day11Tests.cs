using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day11Tests : Tester
    {
        protected override Solver Solver => new Day11(Resources.Day11Input);

        protected override string OutputPart1 => Resources.Day11Part1Output;
        protected override string OutputPart2 => Resources.Day11Part2Output;


        [TestMethod]
        public void ExecuteOneIterationAdjacentSeatsStrategyTest()
        {
            Assert.AreEqual(Resources.Day11TestInput2, new Day11(Resources.Day11TestInput1).ExecuteOneIterationAdjacentSeatsStrategy());
            Assert.AreEqual(Resources.Day11TestInput3, new Day11(Resources.Day11TestInput2).ExecuteOneIterationAdjacentSeatsStrategy());
            Assert.AreEqual(Resources.Day11TestInput4, new Day11(Resources.Day11TestInput3).ExecuteOneIterationAdjacentSeatsStrategy());
            Assert.AreEqual(Resources.Day11TestInput5, new Day11(Resources.Day11TestInput4).ExecuteOneIterationAdjacentSeatsStrategy());
            Assert.AreEqual(Resources.Day11TestInput6, new Day11(Resources.Day11TestInput5).ExecuteOneIterationAdjacentSeatsStrategy());
        }

        [TestMethod]
        public void CalculateFinalOccupiedSeatsAdjacentStrategyTest()
        {
            Assert.AreEqual(37, new Day11(Resources.Day11TestInput1).SolvePart1());
        }

        [TestMethod]
        public void ExecuteOneIterationVisibleSeatsStrategyTest()
        {
            Assert.AreEqual(Resources.Day11TestInput2, new Day11(Resources.Day11TestInput1).ExecuteOneIterationVisibleSeatsStrategy());
            Assert.AreEqual(Resources.Day11TestInput13, new Day11(Resources.Day11TestInput2).ExecuteOneIterationVisibleSeatsStrategy());
            Assert.AreEqual(Resources.Day11TestInput14, new Day11(Resources.Day11TestInput13).ExecuteOneIterationVisibleSeatsStrategy());
            Assert.AreEqual(Resources.Day11TestInput15, new Day11(Resources.Day11TestInput14).ExecuteOneIterationVisibleSeatsStrategy());
            Assert.AreEqual(Resources.Day11TestInput16, new Day11(Resources.Day11TestInput15).ExecuteOneIterationVisibleSeatsStrategy());
            Assert.AreEqual(Resources.Day11TestInput17, new Day11(Resources.Day11TestInput16).ExecuteOneIterationVisibleSeatsStrategy());
        }

        [TestMethod]
        public void CalculateFinalOccupiedSeatsVisibleStrategyTest()
        {
            Assert.AreEqual(26, new Day11(Resources.Day11TestInput1).SolvePart2());
        }
    }
}