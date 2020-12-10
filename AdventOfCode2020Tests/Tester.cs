using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public abstract class Tester
    {
        protected abstract Solver Solver { get; }

        protected abstract string OutputPart1 { get; }
        protected abstract string OutputPart2 { get; }


        [TestMethod]
        public void Part1Test()
        {
            Assert.AreEqual(Convert.ToInt64(OutputPart1), Solver.SolvePart1());
        }

        [TestMethod]
        public void Part2Test()
        {
            Assert.AreEqual(Convert.ToInt64(OutputPart2), Solver.SolvePart2());
        }
    }
}
