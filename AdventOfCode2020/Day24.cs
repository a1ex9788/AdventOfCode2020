using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day24 : Solver
    {
        string[] tileLists;
        Dictionary<(int, int), bool> blackTiles = new Dictionary<(int, int), bool>();

        public Day24(string input)
        {
            tileLists = input.Split("\r\n");
        }


        public override long SolvePart1()
        {
            foreach (string tileList in tileLists)
            {
                (int x, int y) currentTile = (0, 0);

                string currentTileList = tileList;

                while (currentTileList.Length > 0)
                {
                    currentTile = GetNeighbour(currentTile, GetNextStep(ref currentTileList));
                }

                if (blackTiles.ContainsKey(currentTile))
                {
                    blackTiles.Remove(currentTile);
                }
                else
                {
                    blackTiles.Add(currentTile, true);
                }
            }

            return blackTiles.Count();


            string GetNextStep(ref string currentTileList)
            {
                string nextStep = currentTileList[0] + "";

                if (nextStep.Equals("e") || nextStep.Equals("w"))
                {
                    currentTileList = currentTileList.Substring(1);
                }
                else
                {
                    nextStep = currentTileList.Substring(0, 2);
                    currentTileList = currentTileList.Substring(2);
                }

                return nextStep;
            }
        }

        public override long SolvePart2()
        {
            return SimulateNSteps(100);
        }

        public long SimulateNSteps(int steps)
        {
            if (blackTiles.Count() == 0)
            {
                SolvePart1();
            }

            for (int i = 0; i < steps; i++)
            {
                List<(int x, int y)> tilesToBlack = new List<(int x, int y)>();
                List<(int x, int y)> tilesToWhite = new List<(int x, int y)>();

                int maxX = blackTiles.Keys.Max(bt => bt.Item1) + 50;
                int maxY = blackTiles.Keys.Max(bt => bt.Item2) + 10;

                for (int y = -maxY; y <= maxY; y++)
                {
                    int adaptedMaxX = y % 2 == 0
                         ? (maxX % 2 == 0 ? maxX : maxX + 1)
                         : (maxX % 2 == 0 ? maxX + 1 : maxX);

                    for (int x = -adaptedMaxX; x <= adaptedMaxX; x += 2)
                    {
                        int neighbourBlackTiles = GetNeighbourBlackTiles(x, y);

                        if (blackTiles.ContainsKey((x, y)))
                        {
                            if (neighbourBlackTiles == 0 || neighbourBlackTiles > 2)
                            {
                                tilesToWhite.Add((x, y));
                            }
                        }
                        else
                        {
                            if (neighbourBlackTiles == 2)
                            {
                                tilesToBlack.Add((x, y));
                            }
                        }
                    }
                }

                foreach ((int x, int y) in tilesToBlack.Distinct())
                {
                    blackTiles.Add((x, y), true);
                }

                foreach ((int x, int y) in tilesToWhite.Distinct())
                {
                    blackTiles.Remove((x, y));
                }
            }

            return blackTiles.Count();


            int GetNeighbourBlackTiles(int x, int y)
            {
                int neighbourBlackTiles = 0;
                (int x, int y) currentTile = (x, y);
                
                if (blackTiles.ContainsKey(GetNeighbour(currentTile, "e")))
                {
                    neighbourBlackTiles++;
                }
                if (blackTiles.ContainsKey(GetNeighbour(currentTile, "w")))
                {
                    neighbourBlackTiles++;
                }
                if (blackTiles.ContainsKey(GetNeighbour(currentTile, "se")))
                {
                    neighbourBlackTiles++;
                }
                if (blackTiles.ContainsKey(GetNeighbour(currentTile, "sw")))
                {
                    neighbourBlackTiles++;
                }
                if (blackTiles.ContainsKey(GetNeighbour(currentTile, "ne")))
                {
                    neighbourBlackTiles++;
                }
                if (blackTiles.ContainsKey(GetNeighbour(currentTile, "nw")))
                {
                    neighbourBlackTiles++;
                }

                return neighbourBlackTiles;
            }
        }

        private (int x, int y) GetNeighbour((int x, int y) currentTile, string neighbour)
        {
            switch (neighbour)
            {
                case "e":
                    return (currentTile.x + 2, currentTile.y);
                case "w":
                    return (currentTile.x - 2, currentTile.y);
                case "se":
                    return (currentTile.x + 1, currentTile.y - 1);
                case "sw":
                    return (currentTile.x - 1, currentTile.y - 1);
                case "nw":
                    return (currentTile.x - 1, currentTile.y + 1);
                case "ne":
                    return (currentTile.x + 1, currentTile.y + 1);
                default:
                    throw new Exception("Invalid neighbour.");
            }
        }
    }
}