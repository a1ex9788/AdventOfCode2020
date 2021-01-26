using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day02 : Solver
    {
        string[] criteriasAndPasswords;

        public Day02(string input)
        {
            criteriasAndPasswords = input.Split("\r\n");
        }


        public override long SolvePart1()
        {
            return MeetsCriteria(MeetsRangeOcurrenciesCriteria);
        }

        public override long SolvePart2()
        {
            return MeetsCriteria(MeetsPositionsCriteria);
        }


        private long MeetsCriteria(Func<string, bool> criteria)
        {
            return criteriasAndPasswords.Where(cap => criteria(cap)).Count();
        }

        public static bool MeetsRangeOcurrenciesCriteria(string criteriaAndPassword)
        {
            CriteriaAndPassword criteriaAndPasswordObject = new CriteriaAndPassword(criteriaAndPassword);

            return criteriaAndPasswordObject.MeetsRangeOcurrenciesCriteria();
        }

        public static bool MeetsPositionsCriteria(string criteriaAndPassword)
        {
            CriteriaAndPassword criteriaAndPasswordObject = new CriteriaAndPassword(criteriaAndPassword);

            return criteriaAndPasswordObject.MeetsPositionsCriteria();
        }
    }

    class CriteriaAndPassword
    {
        int firstCriteriaNumber, secondCriteriaNumber, ocurrencies = 0;

        char character;

        string password;

        public CriteriaAndPassword(string criteriaAndPassword)
        {
            Match match = Regex.Match(criteriaAndPassword, @"(\d*)-(\d*)\s(\w):\s(\w*)");

            firstCriteriaNumber = Convert.ToInt32(match.Groups[1].Value);
            secondCriteriaNumber = Convert.ToInt32(match.Groups[2].Value);
            character = match.Groups[3].Value[0];
            password = match.Groups[4].Value;

            ocurrencies = Regex.Matches(password, character.ToString()).Count;
        }

        public bool MeetsRangeOcurrenciesCriteria()
        {
            return firstCriteriaNumber <= ocurrencies && ocurrencies <= secondCriteriaNumber;
        }

        public bool MeetsPositionsCriteria()
        {
            bool firstPositionMeets = password[firstCriteriaNumber - 1] == character;
            bool secondPositionMeets = password[secondCriteriaNumber - 1] == character;

            return (firstPositionMeets && !secondPositionMeets) || (!firstPositionMeets && secondPositionMeets);
        }
    }
}