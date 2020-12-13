using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day12 : Solver
    {
        string[] instructions;
        List<char> DIRECTIONS = new List<char>() { 'N', 'E', 'S', 'W' };

        public Day12(string input)
        {
            instructions = input.Split("\r\n");
        }


        public override long SolvePart1()
        {
            char lastDirection = 'E';
            int x = 0, y = 0;

            foreach (string instruction in instructions)
            {
                char action = instruction[0];
                int value = Convert.ToInt32(instruction.Substring(1));

                if (action == 'L')
                {
                    int posInDirections = DIRECTIONS.IndexOf(lastDirection);
                    int newDirectionPos = posInDirections - (value / 90) % 4;
                    if (newDirectionPos < 0)
                    {
                        newDirectionPos += 4;
                    }

                    lastDirection = DIRECTIONS[newDirectionPos];
                    continue;
                }
                else if (action == 'R')
                {
                    int posInDirections = DIRECTIONS.IndexOf(lastDirection);
                    int newDirectionPos = posInDirections + (value / 90) % 4;
                    if (newDirectionPos > 4 - 1)
                    {
                        newDirectionPos -= 4;
                    }

                    lastDirection = DIRECTIONS[newDirectionPos];
                    continue;
                }
                else if (action == 'F')
                {
                    action = lastDirection;
                }

                if (action == 'N')
                {
                    y += value;
                }
                else if (action == 'S')
                {
                    y -= value;
                }
                else if (action == 'E')
                {
                    x += value;
                }
                else if (action == 'W')
                {
                    x -= value;
                }
            }

            return CalculateManhattanDistance(x, y);
        }

        public override long SolvePart2()
        {
            int shipX = 0, shipY = 0, waypointRelativeX = 10, waypointRelativeY = 1;

            foreach (string instruction in instructions)
            {
                char action = instruction[0];
                int value = Convert.ToInt32(instruction.Substring(1));

                if (action == 'L')
                {
                    int rotation = (value / 90) % 4;
                    for (int i = 0; i < rotation; i++)
                    {
                        int aux = waypointRelativeX;
                        waypointRelativeX = -waypointRelativeY;
                        waypointRelativeY = aux;
                    }
                }
                else if (action == 'R')
                {
                    int rotation = (value / 90) % 4;
                    for (int i = 0; i < rotation; i++)
                    {
                        int aux = waypointRelativeX;
                        waypointRelativeX = waypointRelativeY;
                        waypointRelativeY = -aux;
                    }
                }
                else if (action == 'F')
                {
                    shipX += value * waypointRelativeX;
                    shipY += value * waypointRelativeY;
                }
                else if (action == 'N')
                {
                    waypointRelativeY += value;
                }
                else if (action == 'S')
                {
                    waypointRelativeY -= value;
                }
                else if (action == 'E')
                {
                    waypointRelativeX += value;
                }
                else if (action == 'W')
                {
                    waypointRelativeX -= value;
                }
            }

            return CalculateManhattanDistance(shipX, shipY);
        }


        private long CalculateManhattanDistance(int x, int y)
        {
            return Math.Abs(x) + Math.Abs(y);
        }
    }
}