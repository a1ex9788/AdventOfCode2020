using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day11 : Solver
    {
        string[] seats;

        public Day11(string input)
        {
            seats = input.Split("\r\n");
        }


        public override long SolvePart1()
        {
            return CalculateFinalOccupiedSeats(ExecuteOneIterationAdjacentSeatsStrategy);
        }

        public override long SolvePart2()
        {
            return CalculateFinalOccupiedSeats(ExecuteOneIterationVisibleSeatsStrategy);
        }


        private int CalculateFinalOccupiedSeats(Func<string> ExecuteOneIterationStrategy)
        {
            int previousNumberOfOccupiedSeats = 0;

            while (true)
            {
                ExecuteOneIterationStrategy();

                int currentNumberOfOccupiedSeats = GetNumberOfOcuppiedSeats();

                if (previousNumberOfOccupiedSeats == currentNumberOfOccupiedSeats)
                {
                    return currentNumberOfOccupiedSeats;
                }

                previousNumberOfOccupiedSeats = currentNumberOfOccupiedSeats;
            }
        }

        private int GetNumberOfOcuppiedSeats()
        {
            int occupiedSeats = 0;

            for (int x = 0; x < seats[0].Length; x++)
            {
                for (int y = 0; y < seats.Length; y++)
                {
                    if (seats[y][x] == '#')
                    {
                        occupiedSeats++;
                    }
                }
            }

            return occupiedSeats;
        }

        public string ExecuteOneIterationAdjacentSeatsStrategy()
        {
            string[] previousSeats = (string[])seats.Clone();

            for (int x = 0; x < previousSeats[0].Length; x++)
            {
                for (int y = 0; y < previousSeats.Length; y++)
                {
                    if (previousSeats[y][x] == '.')
                    {
                        continue;
                    }

                    int numberOfAdjacentOccupiedSeats = GetNumberOfAdjacentOccupiedSeats(x, y);

                    if (previousSeats[y][x] == 'L' && numberOfAdjacentOccupiedSeats == 0)
                    {
                        seats[y] = ChangeChar(seats[y], x, '#');
                    }
                    else if (previousSeats[y][x] == '#' && numberOfAdjacentOccupiedSeats >= 4)
                    {
                        seats[y] = ChangeChar(seats[y], x, 'L');
                    }
                }
            }

            int GetNumberOfAdjacentOccupiedSeats(int x, int y)
            {
                int numberOfAdjacentOccopiedSeats = 0;

                bool rightExists = x + 1 < previousSeats[0].Length, leftExists = x - 1 >= 0, upExists = y + 1 < previousSeats.Length, downExists = y - 1 >= 0;

                if (rightExists && previousSeats[y][x + 1] == '#')
                {
                    numberOfAdjacentOccopiedSeats++;
                }
                if (leftExists && previousSeats[y][x - 1] == '#')
                {
                    numberOfAdjacentOccopiedSeats++;
                }
                if (upExists && previousSeats[y + 1][x] == '#')
                {
                    numberOfAdjacentOccopiedSeats++;
                }
                if (downExists && previousSeats[y - 1][x] == '#')
                {
                    numberOfAdjacentOccopiedSeats++;
                }

                if (rightExists && upExists && previousSeats[y + 1][x + 1] == '#')
                {
                    numberOfAdjacentOccopiedSeats++;
                }
                if (rightExists && downExists && previousSeats[y - 1][x + 1] == '#')
                {
                    numberOfAdjacentOccopiedSeats++;
                }
                if (leftExists && upExists && previousSeats[y + 1][x - 1] == '#')
                {
                    numberOfAdjacentOccopiedSeats++;
                }
                if (leftExists && downExists && previousSeats[y - 1][x - 1] == '#')
                {
                    numberOfAdjacentOccopiedSeats++;
                }

                return numberOfAdjacentOccopiedSeats;
            }

            return SeatsToString();
        }

        public string ExecuteOneIterationVisibleSeatsStrategy()
        {
            string[] previousSeats = (string[]) seats.Clone();

            for (int x = 0; x < previousSeats[0].Length; x++)
            {
                for (int y = 0; y < previousSeats.Length; y++)
                {
                    if (previousSeats[y][x] == '.')
                    {
                        continue;
                    }

                    int numberOfVisibleOccupiedSeats = GetNumberOfVisibleOccupiedSeats(x, y);

                    if (previousSeats[y][x] == 'L' && numberOfVisibleOccupiedSeats == 0)
                    {
                        seats[y] = ChangeChar(seats[y], x, '#');
                    }
                    else if (previousSeats[y][x] == '#' && numberOfVisibleOccupiedSeats >= 5)
                    {
                        seats[y] = ChangeChar(seats[y], x, 'L');
                    }
                }
            }

            int GetNumberOfVisibleOccupiedSeats(int x, int y)
            {
                int numberOfAdjacentOccopiedSeats = 0;

                if (CanSeeASeatAtRight()) numberOfAdjacentOccopiedSeats++;
                if (CanSeeASeatAtLeft()) numberOfAdjacentOccopiedSeats++;
                if (CanSeeASeatAtUp()) numberOfAdjacentOccopiedSeats++;
                if (CanSeeASeatAtDown()) numberOfAdjacentOccopiedSeats++;

                if (CanSeeASeatAtRightUp()) numberOfAdjacentOccopiedSeats++;
                if (CanSeeASeatAtRightDown()) numberOfAdjacentOccopiedSeats++;
                if (CanSeeASeatAtLeftUp()) numberOfAdjacentOccopiedSeats++;
                if (CanSeeASeatAtLeftDown()) numberOfAdjacentOccopiedSeats++;

                return numberOfAdjacentOccopiedSeats;

                bool CanSeeASeatAtRight()
                {
                    int currentX = x, currentY = y;

                    while (currentX + 1 < previousSeats[0].Length)
                    {
                        char currentSeat = previousSeats[currentY][currentX + 1];

                        if (currentSeat == '#')
                        {
                            return true;
                        }
                        else if (currentSeat == 'L')
                        {
                            return false;
                        }

                        currentX++;
                    }

                    return false;
                }

                bool CanSeeASeatAtLeft()
                {
                    int currentX = x, currentY = y;

                    while (currentX - 1 >= 0)
                    {
                        char currentSeat = previousSeats[currentY][currentX - 1];

                        if (currentSeat == '#')
                        {
                            return true;
                        }
                        else if (currentSeat == 'L')
                        {
                            return false;
                        }

                        currentX--;
                    }

                    return false;
                }

                bool CanSeeASeatAtUp()
                {
                    int currentX = x, currentY = y;

                    while (currentY + 1 < previousSeats.Length)
                    {
                        char currentSeat = previousSeats[currentY + 1][currentX];

                        if (currentSeat == '#')
                        {
                            return true;
                        }
                        else if (currentSeat == 'L')
                        {
                            return false;
                        }

                        currentY++;
                    }

                    return false;
                }

                bool CanSeeASeatAtDown()
                {
                    int currentX = x, currentY = y;

                    while (currentY - 1 >= 0)
                    {
                        char currentSeat = previousSeats[currentY - 1][currentX];

                        if (currentSeat == '#')
                        {
                            return true;
                        }
                        else if (currentSeat == 'L')
                        {
                            return false;
                        }

                        currentY--;
                    }

                    return false;
                }

                bool CanSeeASeatAtRightUp()
                {
                    int currentX = x, currentY = y;

                    while (currentX + 1 < previousSeats[0].Length && currentY + 1 < previousSeats.Length)
                    {
                        char currentSeat = previousSeats[currentY + 1][currentX + 1];

                        if (currentSeat == '#')
                        {
                            return true;
                        }
                        else if (currentSeat == 'L')
                        {
                            return false;
                        }

                        currentX++;
                        currentY++;
                    }

                    return false;
                }

                bool CanSeeASeatAtRightDown()
                {
                    int currentX = x, currentY = y;

                    while (currentX + 1 < previousSeats[0].Length && currentY - 1 >= 0)
                    {
                        char currentSeat = previousSeats[currentY - 1][currentX + 1];

                        if (currentSeat == '#')
                        {
                            return true;
                        }
                        else if (currentSeat == 'L')
                        {
                            return false;
                        }

                        currentX++;
                        currentY--;
                    }

                    return false;
                }

                bool CanSeeASeatAtLeftUp()
                {
                    int currentX = x, currentY = y;

                    while (currentX - 1 >= 0 && currentY + 1 < previousSeats.Length)
                    {
                        char currentSeat = previousSeats[currentY + 1][currentX - 1];

                        if (currentSeat == '#')
                        {
                            return true;
                        }
                        else if (currentSeat == 'L')
                        {
                            return false;
                        }

                        currentX--;
                        currentY++;
                    }

                    return false;
                }

                bool CanSeeASeatAtLeftDown()
                {
                    int currentX = x, currentY = y;

                    while (currentX - 1 >= 0 && currentY - 1 >= 0)
                    {
                        char currentSeat = previousSeats[currentY - 1][currentX - 1];

                        if (currentSeat == '#')
                        {
                            return true;
                        }
                        else if (currentSeat == 'L')
                        {
                            return false;
                        }

                        currentX--;
                        currentY--;
                    }

                    return false;
                }
            }

            return SeatsToString();
        }

        private string ChangeChar(string stringg, int pos, char charr)
        {
            string res = "";

            for (int i = 0; i < stringg.Length; i++)
            {
                if (i == pos)
                {
                    res += charr;
                }
                else
                {
                    res += stringg[i];
                }
            }

            return res;
        }

        private string SeatsToString()
        {
            string toString = "";

            for (int y = 0; y < seats.Length; y++)
            {
                toString += seats[y] + "\r\n";
            }

            return toString.Substring(0, toString.Length - 2);
        }
    }
}