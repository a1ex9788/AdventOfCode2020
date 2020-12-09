using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day06 : Solver
    {
        string[] groupAnswers;

        public Day06(string input)
        {
            groupAnswers = input.Split("\r\n\r\n");
        }


        public override long SolvePart1()
        {
            return groupAnswers.Sum(ga => CalculateNumberOfDifferentQuestions(ga));
        }

        public override long SolvePart2()
        {
            return groupAnswers.Sum(ga => CalculateNumberOfEveryoneAnsweredQuestions(ga));
        }


        public static int CalculateNumberOfDifferentQuestions(string groupAnswer)
        {
            Hashtable hashtable = new Hashtable();

            foreach (char answer in groupAnswer.Replace("\r\n", "").Trim())
            {
                if (!hashtable.ContainsKey(answer))
                {
                    hashtable[answer] = true;
                }
            }

            return hashtable.Keys.Count;
        }

        public static int CalculateNumberOfEveryoneAnsweredQuestions(string groupAnswer)
        {
            Hashtable hashtable = new Hashtable();

            foreach (char answer in groupAnswer.Replace("\r\n", "").Trim())
            {
                if (!hashtable.ContainsKey(answer))
                {
                    hashtable[answer] = true;
                }
            }

            int numberOfEveryoneAnsweredQuestions = 0;

            foreach (char answer in hashtable.Keys)
            {
                bool everyoneAnswered = true;

                foreach (string answers in groupAnswer.Split("\r\n"))
                {
                    if (!answers.Contains(answer))
                    {
                        everyoneAnswered = false;
                    }
                }

                if (everyoneAnswered)
                {
                    numberOfEveryoneAnsweredQuestions++;
                }
            }

            return numberOfEveryoneAnsweredQuestions;
        }
    }
}