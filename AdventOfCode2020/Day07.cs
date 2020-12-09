using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day07 : Solver
    {
        List<Rule> rules;

        public Day07(string input)
        {
            rules = input.Split("\r\n").Select(r => new Rule(r)).ToList();
        }


        public override long SolvePart1()
        {
            return CalculateNumberOfBagColoursToContainOneShinyGoldBag();
        }

        public override long SolvePart2()
        {
            return CalculateNumberOfBagsInsideOneShinyGoldBag();
        }


        public int CalculateNumberOfBagColoursToContainOneShinyGoldBag()
        {
            return CalculateBagColoursToContain("shiny gold").Count();
        }

        private HashSet<string> CalculateBagColoursToContain(string bagColour)
        {
            HashSet<string> bagColours = new HashSet<string>();

            foreach (string continent in rules.Where(r => r.HasContent(bagColour)).Select(r => r.Continent))
            {
                if (bagColours.Contains(continent))
                {
                    continue;
                }

                bagColours.Add(continent);

                bagColours.UnionWith(CalculateBagColoursToContain(continent));
            }

            return bagColours;
        }

        public int CalculateNumberOfBagsInsideOneShinyGoldBag()
        {
            return CalculateNumberOfBagsInside("shiny gold");
        }

        public int CalculateNumberOfBagsInside(string bagColour)
        {
            return CalculateNumberOfBagsInside(new BagQuantity("1 " + bagColour));
        }

        private int CalculateNumberOfBagsInside(BagQuantity bagQuantity)
        {
            int numberOfContainedBags = 0;

            List<BagQuantity> content = rules.Find(r => r.HasContinent(bagQuantity.BagColour)).Content;

            if (content.Count() == 0)
            {
                return 0;
            }

            foreach (BagQuantity bq in content)
            {
                numberOfContainedBags += bq.Quantity + bq.Quantity * CalculateNumberOfBagsInside(bq);
            }

            return numberOfContainedBags;
        }
    }

    class Rule
    {
        public string Continent;

        public List<BagQuantity> Content = new List<BagQuantity>();

        public Rule(string rule)
        {
            string[] splittedRule = rule.Replace(" bags", "").Replace(" bag", "").Replace(".", "").Split(" contain ");

            Continent = splittedRule[0];

            string[] splittedContent = splittedRule[1].Split(", ");

            foreach (string contentElement in splittedContent)
            {
                if (contentElement.Equals("no other"))
                {
                    continue;
                }

                Content.Add(new BagQuantity(contentElement));
            }
        }

        public bool HasContinent(string continent)
        {
            return Continent.Equals(continent);
        }

        public bool HasContent(string content)
        {
            return Content.Select(c => c.BagColour).Contains(content);
        }
    }

    class BagQuantity
    {
        public int Quantity;

        public string BagColour;

        public BagQuantity(string bagQuantity)
        {
            int firstEmpty = bagQuantity.TrimStart().IndexOf(" ");

            Quantity = Convert.ToInt32(bagQuantity.Substring(0, firstEmpty));

            BagColour = bagQuantity.Substring(firstEmpty + 1);
        }

        public bool HasColour(string colour)
        {
            return BagColour.Equals(colour);
        }
    }
}