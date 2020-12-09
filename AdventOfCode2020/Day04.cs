using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day04 : Solver
    {
        string[] passports;

        public Day04(string input)
        {
            passports = input.Split("\r\n\r\n");
        }


        public override long SolvePart1()
        {
            return passports.Where(p => ContainsRequiredFields(p)).Count();
        }

        public override long SolvePart2()
        {
            return passports.Where(p => ContainsRequiredFieldsAndHaveValidValues(p)).Count();
        }


        public static bool ContainsRequiredFields(string passport)
        {
            Passport passportObject = new Passport(passport);

            return passportObject.ContainsRequiredFields();
        }

        public static bool ContainsRequiredFieldsAndHaveValidValues(string passport)
        {
            Passport passportObject = new Passport(passport);

            return passportObject.ContainsRequiredFields() && passportObject.HasValidValues();
        }
    }

    class Passport
    {
        string birthYear, issueYear, expirationYear, height;
        string hairColour, eyeColour;
        string passportId;

        public Passport(string passport)
        {
            string[] fields = passport.Replace("\r", "").Replace(": ", ":").Split(new char[] { ' ', '\n' });

            foreach (string field in fields)
            {
                string[] fieldNameAndValue = field.Split(':');

                string fieldName = fieldNameAndValue[0].Trim();
                string fieldValue = fieldNameAndValue[1].Trim();

                switch (fieldName)
                {
                    case "byr":
                        birthYear = fieldValue;
                        break;
                    case "iyr":
                        issueYear = fieldValue;
                        break;
                    case "eyr":
                        expirationYear = fieldValue;
                        break;
                    case "hgt":
                        height = fieldValue;
                        break;
                    case "hcl":
                        hairColour = fieldValue;
                        break;
                    case "ecl":
                        eyeColour = fieldValue;
                        break;
                    case "pid":
                        passportId = fieldValue;
                        break;
                }
            }
        }

        public bool ContainsRequiredFields()
        {
            return birthYear != null
                && issueYear != null
                && expirationYear != null
                && height != null
                && hairColour != null
                && eyeColour != null
                && passportId != null;
        }

        public bool HasValidValues()
        {
            return ValidBirthYear()
                && ValidIssueYear()
                && ValidExpirationYear()
                && ValidHeight()
                && ValidHairColour()
                && ValidEyeColour()
                && ValidPassportId();
        }

        private bool ValidBirthYear()
        {
            try
            {
                int birthYearConverted = Convert.ToInt32(birthYear);

                return 1920 <= birthYearConverted && birthYearConverted <= 2002;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidIssueYear()
        {
            try
            {
                int issueYearConverted = Convert.ToInt32(issueYear);

                return 2010 <= issueYearConverted && issueYearConverted <= 2020;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidExpirationYear()
        {
            try
            {
                int expirationYearConverted = Convert.ToInt32(expirationYear);

                return 2020 <= expirationYearConverted && expirationYearConverted <= 2030;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidHeight()
        {
            if (height.Contains("cm"))
            {
                int heightValue = Convert.ToInt32(height.Substring(0, height.IndexOf("cm")));

                return 150 <= heightValue && heightValue <= 193;
            }
            else if (height.Contains("in"))
            {
                int heightValue = Convert.ToInt32(height.Substring(0, height.IndexOf("in")));

                return 59 <= heightValue && heightValue <= 76;
            }

            return false;
        }

        private bool ValidHairColour()
        {
            if (!hairColour.StartsWith("#") || hairColour.Length != 7)
            {
                return false;
            }

            string hairColourValue = hairColour.Substring(1);

            string validChars = "abcdef0123456789";

            return hairColourValue.Where(c => validChars.Contains(c)).Count() == 6;
        }

        private bool ValidEyeColour()
        {
            string[] validEyeColours = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            return validEyeColours.Contains(eyeColour);
        }

        private bool ValidPassportId()
        {
            try
            {
                int id = Convert.ToInt32(passportId);

                return passportId.Length == 9;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}