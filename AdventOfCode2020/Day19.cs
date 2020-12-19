using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day19 : Solver
    {
        Hashtable rules;
        string[] messages;

        public Day19(string input)
        {
            rules = new Hashtable();

            string[] inputSplitted = input.Split("\r\n\r\n");

            foreach (string rule in inputSplitted[0].Split("\r\n"))
            {
                string[] ruleSplitted = rule.Split(": ");

                rules[Convert.ToInt32(ruleSplitted[0])] = ruleSplitted[1];
            }

            messages = inputSplitted[1].Split("\r\n");
        }


        public override long SolvePart1()
        {
            return messages.Count(m => MatchRule0(m));
        }

        public override long SolvePart2()
        {
            IntroduceLoops();

            return messages.Count(m => MatchRule0(m));
        }


        public void IntroduceLoops()
        {
            rules[8] = "42 | 42 8";
            rules[11] = "42 31 | 42 11 31";
        }

        public bool MatchRule0(string message)
        {
            (bool match, List<string> currentMessages) = MatchRule((string)rules[0], message);

            return match && currentMessages.Any(cm => cm.Length == 0);
        }

        private (bool match, List<string> currentMessages) MatchRule(string rule, string currentMessage)
        {
            if (currentMessage.Length == 0)
            {
                return (false, null);
            }

            (bool match, List<string> newMessages) = (false, new List<string>());

            if (rule.Contains('|'))
            {
                string[] options = rule.Split(" | ");

                foreach (string option in options)
                {
                    (bool newMatch, List<string> resultMessages) = MatchRule(option, currentMessage);

                    if (newMatch)
                    {
                        match = true;
                        newMessages.AddRange(resultMessages);
                    }
                }

                return (match, newMessages);
            }

            if (rule.Contains('\"'))
            {
                char charToMatch = rule[1];

                bool matches = currentMessage[0] == charToMatch;

                if (matches)
                {
                    return (true, new List<string>() { currentMessage.Substring(1) });
                }

                return (false, null);
            }

            List<int> ruleNumbersToMatch = rule.Split(' ').Select(r => Convert.ToInt32(r)).ToList();

            (match, newMessages) = MatchRule((string)rules[ruleNumbersToMatch[0]], currentMessage);

            if (!match)
            {
                return (false, null);
            }

            if (ruleNumbersToMatch.Count == 1)
            {
                return (match, newMessages);
            }

            foreach (string newMessage in newMessages)
            {
                (bool newMatch, List<string> resultMessages) = MatchRule(rule.Substring(rule.IndexOf(' ') + 1), newMessage);

                if (newMatch)
                {
                    return (true, resultMessages);
                }
            }

            return (false, null);
        }
    }
}