using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day16 : Solver
    {
        List<TicketField> ticketFields;
        string[] ticket;
        string[] nearbyTickets;
        Random random = new Random();

        public Day16(string input)
        {
            string[] inputSplitted = input.Split("\r\n\r\n");

            ticketFields = inputSplitted[0].Split("\r\n").Select(tf => new TicketField(tf)).ToList();
            ticket = inputSplitted[1].Split("\r\n")[1].Split(",");
            nearbyTickets = inputSplitted[2].Split("nearby tickets:\r\n")[1].Split("\r\n");
        }


        public override long SolvePart1()
        {
            return nearbyTickets.Sum(nt => CalculateTicketScanningErrors(nt));
        }

        public override long SolvePart2()
        {
            List<List<string>> possibleTicketFieldsPerPositions = InitializePossibleTicketFieldsPerPositions();

            List<string> validTickets = nearbyTickets.Where(nt => HasNoTicketScanningErrors(nt)).ToList();

            foreach (string nearbyTicket in validTickets)
            {
                List<int> nearbyTicketValues = nearbyTicket.Split(",").Select(nt => Convert.ToInt32(nt)).ToList();

                for (int posInTicket = 0; posInTicket < nearbyTicketValues.Count(); posInTicket++)
                {
                    List<string> invalidFields = new List<string>();

                    for (int j = 0; j < ticketFields.Count(); j++)
                    {
                        if (!IsValidTicketValue(nearbyTicketValues[posInTicket], ticketFields[j]))
                        {
                            invalidFields.Add(ticketFields[j].Name);
                        }
                    }

                    if (invalidFields.Count() > 0)
                    {
                        possibleTicketFieldsPerPositions[posInTicket].RemoveAll(ptfpp => invalidFields.Contains(ptfpp));
                    }
                }
            }

            while (possibleTicketFieldsPerPositions.Any(ptfpp => ptfpp.Count() > 1))
            {
                List<string> resolvedTicketFields = possibleTicketFieldsPerPositions.Where(ptfpp => ptfpp.Count() == 1).Select(ptfpp => ptfpp[0]).ToList();
                string ticketFieldResolved = resolvedTicketFields[random.Next(resolvedTicketFields.Count)];

                foreach (List<string> possibleTicketFieldsPerPositionsList in possibleTicketFieldsPerPositions.Where(ptfpp => ptfpp.Count() > 1))
                {
                    possibleTicketFieldsPerPositionsList.Remove(ticketFieldResolved);
                }
            }

            List<int> departurePositionsInTicket = new List<int>();
            long result = 1;

            for (int i = 0; i < possibleTicketFieldsPerPositions.Count; i++)
            {
                if (possibleTicketFieldsPerPositions[i][0].StartsWith("departure"))
                {
                    result *= Convert.ToInt32(ticket[i]);
                }
            }

            return result;


            List<List<string>> InitializePossibleTicketFieldsPerPositions()
            {
                List<List<string>> possibleTicketFieldsPerPositions = new List<List<string>>();

                foreach (string s in ticket)
                {
                    possibleTicketFieldsPerPositions.Add(GetFieldNames());
                }

                return possibleTicketFieldsPerPositions;
            }
        }


        public long CalculateTicketScanningErrors(string nearbyTicket)
        {
            return nearbyTicket.Split(",").Where(nv => IsInvalidForEveryTicketField(Convert.ToInt32(nv))).Sum(nv => Convert.ToInt32(nv));


            bool IsInvalidForEveryTicketField(int nearbyTicketValue)
            {
                foreach (TicketField ticketField in ticketFields)
                {
                    if (IsValidTicketValue(nearbyTicketValue, ticketField))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public bool HasNoTicketScanningErrors(string nearbyTicket)
        {
            return nearbyTicket.Split(",").Where(nv => IsInvalidForEveryTicketField(Convert.ToInt32(nv))).Count() == 0;


            bool IsInvalidForEveryTicketField(int nearbyTicketValue)
            {
                foreach (TicketField ticketField in ticketFields)
                {
                    if (IsValidTicketValue(nearbyTicketValue, ticketField))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private static bool IsValidTicketValue(int nearbyTicketValue, TicketField ticketField)
        {
            return (ticketField.firstLimitLowerBound <= nearbyTicketValue && nearbyTicketValue <= ticketField.firstLimitUpperBound)
                || (ticketField.secondLimitLowerBound <= nearbyTicketValue && nearbyTicketValue <= ticketField.secondLimitUpperBound);
        }

        private List<string> GetFieldNames()
        {
            return ticketFields.Select(tf => (string)tf.Name.Clone()).ToList();
        }
    }

    class TicketField
    {
        public string Name;
        public int firstLimitLowerBound, firstLimitUpperBound, secondLimitLowerBound, secondLimitUpperBound;

        public TicketField(string ticketField)
        {
            Name = ticketField.Split(": ")[0];

            string[] ticketFieldLimitValues = ticketField.Split(": ")[1].Split(" or ");

            string[] firstLimitValues = ticketFieldLimitValues[0].Split("-");
            string[] secondLimitValues = ticketFieldLimitValues[1].Split("-");

            firstLimitLowerBound = Convert.ToInt32(firstLimitValues[0]);
            firstLimitUpperBound = Convert.ToInt32(firstLimitValues[1]);
            secondLimitLowerBound = Convert.ToInt32(secondLimitValues[0]);
            secondLimitUpperBound = Convert.ToInt32(secondLimitValues[1]);
        }
    }
}