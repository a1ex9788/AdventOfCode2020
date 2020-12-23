using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day23 : Solver
    {
        string input;

        public Day23(string input)
        {
            this.input = input;
        }


        public override long SolvePart1()
        {
            return GetLabellingAfterNMoves(100);
        }

        public override long SolvePart2()
        {
            return -1;

            CupsCircle1M cupsCircle1M = new CupsCircle1M(input);

            cupsCircle1M.SimulateNMoves(10000000);

            (long a, long b) = cupsCircle1M.Get2NextToOneCups();

            return a * b;
        }


        public long GetLabellingAfterNMoves(int movesNumber)
        {
            CupsCircle cupsCircle = new CupsCircle(input);

            cupsCircle.SimulateNMoves(movesNumber);

            return cupsCircle.GetResultingLabelling();
        }
    }

    class CupsCircle
    {
        string cups;
        int currentCupPosition;

        public CupsCircle(string cups)
        {
            this.cups = cups;
            currentCupPosition = 0;
        }


        public void SimulateNMoves(int movesNumber)
        {
            for (int i = 0; i < movesNumber; i++)
            {
                int destinationCupPosition = GetDestinationCupPosition(currentCupPosition);

                MoveNext3CupsTo(currentCupPosition, destinationCupPosition);

                currentCupPosition = (currentCupPosition + 1) % cups.Length;
            }
        }

        public long GetResultingLabelling()
        {
            int indexOfOne = cups.IndexOf('1');

            return Convert.ToInt64(cups.Substring(indexOfOne + 1) + cups.Substring(0, indexOfOne));
        }

        public (long, long) Get2NextToOneCups()
        {
            int indexOfOne = cups.IndexOf('1');

            return (Get(indexOfOne + 1), Get(indexOfOne + 2));
        }

        private char Get(int cupPos)
        {
            return cups[cupPos % cups.Length];
        }

        private void MoveNext3CupsTo(int currentCupPosition, int destinationCupPosition)
        {
            char destination = cups[destinationCupPosition];

            string next3Cups = Get(currentCupPosition + 1) + "" + Get(currentCupPosition + 2) + "" + Get(currentCupPosition + 3);

            string cupsWithoutNext3 = RemoveNext3();

            int newDestinationCupPosition = cupsWithoutNext3.IndexOf(destination);
            string cupsWithNext3Moved = cupsWithoutNext3.Substring(0, newDestinationCupPosition + 1) + next3Cups + cupsWithoutNext3.Substring(newDestinationCupPosition + 1);

            if (destinationCupPosition < currentCupPosition)
            {
                while (cupsWithNext3Moved[currentCupPosition] != cups[currentCupPosition])
                {
                    cupsWithNext3Moved = cupsWithNext3Moved.Substring(1) + cupsWithNext3Moved[0];
                }
            }

            cups = cupsWithNext3Moved;
        }

        private int GetDestinationCupPosition(int currentCupPosition)
        {
            int wantedCup = Convert.ToInt32(cups[currentCupPosition] + "") - 1;

            while (true)
            {
                if (wantedCup == 0)
                {
                    wantedCup = cups.Length;
                }

                int wantedCupPos = cups.IndexOf(wantedCup + "");

                if (RemoveNext3().Contains(wantedCup + ""))
                {
                    return wantedCupPos;
                }

                wantedCup--;
            }
        }

        private string RemoveNext3()
        {
            string cupsWithoutNext3 = cups;

            try
            {
                cupsWithoutNext3 = cupsWithoutNext3.Remove(currentCupPosition + 1, 3);
            }
            catch
            {
                try
                {
                    cupsWithoutNext3 = cupsWithoutNext3.Remove(currentCupPosition + 1, 2);
                    cupsWithoutNext3 = cupsWithoutNext3.Substring(1);
                }
                catch
                {
                    try
                    {
                        cupsWithoutNext3 = cupsWithoutNext3.Remove(currentCupPosition + 1, 1);
                        cupsWithoutNext3 = cupsWithoutNext3.Substring(2);
                    }
                    catch
                    {
                        cupsWithoutNext3 = cupsWithoutNext3.Substring(3);
                    }
                }
            }

            return cupsWithoutNext3;
        }
    }

    class CupsCircle1M
    {
        string cups;
        int currentCupPosition;

        public CupsCircle1M(string cups)
        {
            this.cups = cups;

            for (int i = cups.Length; i < 1000000; i++) // Mal, 12345678910111213141516...
            {
                cups += i + 1;
            }

            currentCupPosition = 0;
        }


        public void SimulateNMoves(int movesNumber)
        {
            for (int i = 0; i < movesNumber; i++)
            {
                int destinationCupPosition = GetDestinationCupPosition(currentCupPosition);

                MoveNext3CupsTo(currentCupPosition, destinationCupPosition);

                currentCupPosition = (currentCupPosition + 1) % cups.Length;
            }
        }

        public long GetResultingLabelling()
        {
            int indexOfOne = cups.IndexOf('1');

            return Convert.ToInt64(cups.Substring(indexOfOne + 1) + cups.Substring(0, indexOfOne));
        }

        public (long, long) Get2NextToOneCups()
        {
            int indexOfOne = cups.IndexOf('1');

            return (Get(indexOfOne + 1), Get(indexOfOne + 2));
        }

        private char Get(int cupPos)
        {
            return cups[cupPos % cups.Length];
        }

        private void MoveNext3CupsTo(int currentCupPosition, int destinationCupPosition)
        {
            char destination = cups[destinationCupPosition];

            string next3Cups = Get(currentCupPosition + 1) + "" + Get(currentCupPosition + 2) + "" + Get(currentCupPosition + 3);

            string cupsWithoutNext3 = RemoveNext3();

            int newDestinationCupPosition = cupsWithoutNext3.IndexOf(destination);
            string cupsWithNext3Moved = cupsWithoutNext3.Substring(0, newDestinationCupPosition + 1) + next3Cups + cupsWithoutNext3.Substring(newDestinationCupPosition + 1);

            if (destinationCupPosition < currentCupPosition)
            {
                while (cupsWithNext3Moved[currentCupPosition] != cups[currentCupPosition])
                {
                    cupsWithNext3Moved = cupsWithNext3Moved.Substring(1) + cupsWithNext3Moved[0];
                }
            }

            cups = cupsWithNext3Moved;
        }

        private int GetDestinationCupPosition(int currentCupPosition)
        {
            int wantedCup = Convert.ToInt32(cups[currentCupPosition] + "") - 1;

            while (true)
            {
                if (wantedCup == 0)
                {
                    wantedCup = cups.Length;
                }

                int wantedCupPos = cups.IndexOf(wantedCup + "");

                if (RemoveNext3().Contains(wantedCup + ""))
                {
                    return wantedCupPos;
                }

                wantedCup--;
            }
        }

        private string RemoveNext3()
        {
            string cupsWithoutNext3 = cups;

            try
            {
                cupsWithoutNext3 = cupsWithoutNext3.Remove(currentCupPosition + 1, 3);
            }
            catch
            {
                try
                {
                    cupsWithoutNext3 = cupsWithoutNext3.Remove(currentCupPosition + 1, 2);
                    cupsWithoutNext3 = cupsWithoutNext3.Substring(1);
                }
                catch
                {
                    try
                    {
                        cupsWithoutNext3 = cupsWithoutNext3.Remove(currentCupPosition + 1, 1);
                        cupsWithoutNext3 = cupsWithoutNext3.Substring(2);
                    }
                    catch
                    {
                        cupsWithoutNext3 = cupsWithoutNext3.Substring(3);
                    }
                }
            }

            return cupsWithoutNext3;
        }
    }
}