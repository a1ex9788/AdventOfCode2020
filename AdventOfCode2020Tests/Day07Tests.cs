using AdventOfCode2020;
using AdventOfCode2020Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020Tests
{
    [TestClass]
    public class Day07Tests : Tester
    {
        protected override Solver Solver => new Day07(Resources.Day07Input);

        protected override string OutputPart1 => Resources.Day07Part1Output;
        protected override string OutputPart2 => Resources.Day07Part2Output;


        [TestMethod]
        [DataRow("light red bags contain 1 bright white bag, 2 muted yellow bags.\r\n" +
                 "dark orange bags contain 3 bright white bags, 4 muted yellow bags.\r\n" +
                 "bright white bags contain 1 shiny gold bag.\r\n" +
                 "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.\r\n" +
                 "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.\r\n" +
                 "dark olive bags contain 3 faded blue bags, 4 dotted black bags.\r\n" +
                 "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.\r\n" +
                 "faded blue bags contain no other bags.\r\n" +
                 "dotted black bags contain no other bags.", 4)]
        public void CalculateNumberOfBagColoursToContainOneShinyGoldBagTest(string rules, int expectedNumberOfBagColours)
        {
            Assert.AreEqual(expectedNumberOfBagColours, new Day07(rules).CalculateNumberOfBagColoursToContainOneShinyGoldBag());
        }

        [TestMethod]
        [DataRow("faded blue", 0)]
        [DataRow("dotted black", 0)]
        [DataRow("vibrant plum", 11)]
        [DataRow("dark olive", 7)]
        public void CalculateNumberOfBagsInsideTest(string wantedBagColour, int expectedNumberOfBagsInside)
        {
            string rules = "light red bags contain 1 bright white bag, 2 muted yellow bags.\r\n" +
                 "dark orange bags contain 3 bright white bags, 4 muted yellow bags.\r\n" +
                 "bright white bags contain 1 shiny gold bag.\r\n" +
                 "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.\r\n" +
                 "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.\r\n" +
                 "dark olive bags contain 3 faded blue bags, 4 dotted black bags.\r\n" +
                 "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.\r\n" +
                 "faded blue bags contain no other bags.\r\n" +
                 "dotted black bags contain no other bags.";

            Assert.AreEqual(expectedNumberOfBagsInside, new Day07(rules).CalculateNumberOfBagsInside(wantedBagColour));
        }

        [TestMethod]
        [DataRow("light red bags contain 1 bright white bag, 2 muted yellow bags.\r\n" +
                 "dark orange bags contain 3 bright white bags, 4 muted yellow bags.\r\n" +
                 "bright white bags contain 1 shiny gold bag.\r\n" +
                 "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.\r\n" +
                 "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.\r\n" +
                 "dark olive bags contain 3 faded blue bags, 4 dotted black bags.\r\n" +
                 "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.\r\n" +
                 "faded blue bags contain no other bags.\r\n" +
                 "dotted black bags contain no other bags.", 32)]
        [DataRow("shiny gold bags contain 2 dark red bags.\r\n" +
                "dark red bags contain 2 dark orange bags.\r\n" +
                "dark orange bags contain 2 dark yellow bags.\r\n" +
                "dark yellow bags contain 2 dark green bags.\r\n" +
                "dark green bags contain 2 dark blue bags.\r\n" +
                "dark blue bags contain 2 dark violet bags.\r\n" +
                "dark violet bags contain no other bags.", 126)]
        public void CalculateNumberOfBagsInsideOneShinyGoldBagTest(string rules, int expectedNumberOfBagColours)
        {
            Assert.AreEqual(expectedNumberOfBagColours, new Day07(rules).CalculateNumberOfBagsInsideOneShinyGoldBag());
        }
    }
}