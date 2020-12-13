using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day13 : Solver
    {
        long earliestTimestamp;
        string[] busIds;

        Hashtable availableTimestamps = new Hashtable();

        public Day13(string input)
        {
            string[] inputSplitted = input.Split("\r\n");

            earliestTimestamp = Convert.ToInt32(inputSplitted[0]);
            busIds = inputSplitted[1].Split(",");
        }


        public override long SolvePart1()
        {
            foreach (string busId in busIds)
            {
                if (busId.Equals("x"))
                {
                    continue;
                }

                BusTimestamp busTimestamp = null;
                long busIdConverted = Convert.ToInt32(busId);
                long currentTimestamp = busIdConverted;

                while (busTimestamp == null)
                {
                    if (currentTimestamp >= earliestTimestamp)
                    {
                        busTimestamp = new BusTimestamp(busIdConverted, currentTimestamp);
                    }

                    currentTimestamp += busIdConverted;
                }

                if (!availableTimestamps.ContainsKey(busTimestamp.Timestamp))
                {
                    availableTimestamps.Add(busTimestamp.Timestamp, busTimestamp.BusId);
                }
            }

            BusTimestamp earliestAvailableTimestamp = GetEarliestAvailableTimestamp();

            return earliestAvailableTimestamp.BusId * (earliestAvailableTimestamp.Timestamp - earliestTimestamp);
        }

        public override long SolvePart2()
        {
            List<int> busIds = new List<int>();
            List<int> a = new List<int>();

            for (int i = 0; i < this.busIds.Length; i++)
            {
                if (this.busIds[i].Equals("x"))
                {
                    continue;
                }

                int busIdConverted = Convert.ToInt32(this.busIds[i]);
                busIds.Add(busIdConverted);
                a.Add(busIdConverted - i % busIdConverted);
            }

            return ChineseRemainderTheorem.Solve(busIds.ToArray(), a.ToArray());
        }

        public long SolvePart2Inefficient()
        {
            List<(int busId, int offset)> busesAndOffsets = new List<(int, int)>();

            for (int i = 0; i < busIds.Length; i++)
            {
                if (busIds[i].Equals("x"))
                {
                    continue;
                }

                int busIdConverted = Convert.ToInt32(busIds[i]);
                busesAndOffsets.Add((busIdConverted, i));
            }

            long currentTimeStamp = 0;
            int biggestId = busesAndOffsets.Max(bao => bao.busId);
            while (true)
            {
                bool found = true;

                foreach ((int busId, int offset) in busesAndOffsets)
                {
                    if ((currentTimeStamp + offset) % busId != 0)
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return currentTimeStamp;
                }

                currentTimeStamp += busesAndOffsets[0].busId;
            }
        }

        private BusTimestamp GetEarliestAvailableTimestamp()
        {
            BusTimestamp earliestAvailableTimestamp = null;
            long currentTimestamp = earliestTimestamp;

            while (earliestAvailableTimestamp == null)
            {
                if (availableTimestamps.ContainsKey(currentTimestamp))
                {
                    earliestAvailableTimestamp = new BusTimestamp((long) availableTimestamps[currentTimestamp], currentTimestamp);
                }

                currentTimestamp++;
            }

            return earliestAvailableTimestamp;
        }
    }

    class BusTimestamp
    {
        public long BusId;
        public long Timestamp;

        public BusTimestamp(long busId, long timestamp)
        {
            this.BusId = busId;
            this.Timestamp = timestamp;
        }
    }

    static class ChineseRemainderTheorem
    {
        public static long Solve(int[] n, int[] a)
        {
            long prod = n.Aggregate(1, (i, j) => (i * j));
            long p;
            long sm = 0;
            for (long i = 0; i < n.Length; i++)
            {
                p = prod / n[i];
                sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
            }
            return sm % prod;
        }

        private static long ModularMultiplicativeInverse(long a, long mod)
        {
            long b = a % mod;
            for (long x = 1; x < mod; x++)
            {
                if ((b * x) % mod == 1)
                {
                    return x;
                }
            }
            return 1;
        }
    }
}