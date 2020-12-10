using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day10 : Solver
    {
        List<int> adapters;
        int CHARGING_OUTLET_JOLTS = 0;
        Hashtable knownArrengements = new Hashtable();

        public Day10(string input)
        {
            adapters = input.Split("\r\n").Select(i => Convert.ToInt32(i)).ToList();
            adapters.Add(CHARGING_OUTLET_JOLTS);
            adapters = adapters.OrderBy(i => i).ToList();
            adapters.Add(adapters.Last() + 3);
        }


        public override long SolvePart1()
        {
            int numberOf1JoltDifferences = 0, numberOf3JoltsDifferences = 0;
            
            for (int i = 0; i < adapters.Count - 1; i++)
            {
                int currentAdapter = adapters[i], nextAdapter = adapters[i+1];

                if (nextAdapter - currentAdapter == 1)
                {
                    numberOf1JoltDifferences++;
                }
                else if (nextAdapter - currentAdapter == 3)
                {
                    numberOf3JoltsDifferences++;
                }
                else
                {
                    throw new Exception("No adapter with 3 or less difference to the current jolts was found.");
                }                
            }

            return numberOf1JoltDifferences * numberOf3JoltsDifferences;
        }

        public override long SolvePart2()
        {
            return GetPossibleArrangements(0);
        }

        public long GetPossibleArrangements(int posInAdapters)
        {
            long possibleArrangements = 0;

            if (posInAdapters == adapters.Count - 1)
            {
                return 1;
            }

            if (posInAdapters + 2 < adapters.Count && adapters[posInAdapters + 2] - adapters[posInAdapters] == 2)
            {
                long possibleArrangementsPosInAdaptersPlus2;

                if (knownArrengements.ContainsKey(posInAdapters + 2))
                {
                    possibleArrangementsPosInAdaptersPlus2 = (long) knownArrengements[posInAdapters + 2];
                }
                else
                {
                    possibleArrangementsPosInAdaptersPlus2 = GetPossibleArrangements(posInAdapters + 2);
                    knownArrengements.Add(posInAdapters + 2, possibleArrangementsPosInAdaptersPlus2);
                }

                possibleArrangements += possibleArrangementsPosInAdaptersPlus2;

                if (posInAdapters + 3 < adapters.Count && adapters[posInAdapters + 3] - adapters[posInAdapters] == 3)
                {
                    long possibleArrangementsPosInAdaptersPlus3;

                    if (knownArrengements.ContainsKey(posInAdapters + 3))
                    {
                        possibleArrangementsPosInAdaptersPlus3 = (long) knownArrengements[posInAdapters + 3];
                    }
                    else
                    {
                        possibleArrangementsPosInAdaptersPlus3 = GetPossibleArrangements(posInAdapters + 3);
                        knownArrengements.Add(posInAdapters + 3, possibleArrangementsPosInAdaptersPlus3);
                    }

                    possibleArrangements += possibleArrangementsPosInAdaptersPlus3;
                }
            }

            possibleArrangements += GetPossibleArrangements(posInAdapters + 1);

            return possibleArrangements;
        }
    }
}