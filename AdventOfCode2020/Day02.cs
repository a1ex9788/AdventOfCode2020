using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            string[] criteriaAndPasswordSeparated = criteriaAndPassword.Split(": ");            
            string fullCriteria = criteriaAndPasswordSeparated[0];
            password = criteriaAndPasswordSeparated[1];

            string[] criteria = fullCriteria.Split(" ");
            string fullOcurrenciesRange = criteria[0];
            character = criteria[1][0];

            string[] ocurrenciesRange = fullOcurrenciesRange.Split("-");
            firstCriteriaNumber = Convert.ToInt32(ocurrenciesRange[0]);
            secondCriteriaNumber = Convert.ToInt32(ocurrenciesRange[1]);

            CalculateOcurrencies();
        }

        private void CalculateOcurrencies()
        {
            foreach (char c in password)
            {
                if (c == character)
                {
                    ocurrencies++;
                }
            }
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