using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day20 : Solver
    {
        List<Tile> tiles;

        public Day20(string input)
        {
            tiles = input.Split("\r\n\r\n").Select(i => new Tile(i)).ToList();
        }


        public override long SolvePart1()
        {
            foreach (Tile currentTile in tiles)
            {
                foreach (Tile anotherTile in tiles)
                {
                    if (anotherTile.Equals(currentTile))
                    {
                        continue;
                    }

                    if (currentTile.HasBorder(anotherTile.upBorder)
                        || currentTile.HasBorder(anotherTile.downBorder)
                        || currentTile.HasBorder(anotherTile.rightBorder)
                        || currentTile.HasBorder(anotherTile.leftBorder))
                    {
                        currentTile.neighboursNumber++;
                    }
                }
            }

            return PrepareResult();


            long PrepareResult()
            {
                List<Tile> corners = new List<Tile>();
                long result = 1;

                tiles.ForEach(t =>
                {
                    if (t.IsCorner())
                    {
                        corners.Add(t);
                    }
                });

                corners.ForEach(c => result *= c.Number);

                return result;
            }
        }

        public override long SolvePart2()
        {
            return -1;
        }
    }

    class Tile
    {
        public int Number;
        public string upBorder, downBorder, rightBorder, leftBorder;

        public int neighboursNumber = 0;

        public Tile(string tile)
        {
            string[] tileSplitted = tile.Split("\r\n");
            string numberAndColon = tileSplitted[0].Split(' ')[1];

            Number = Convert.ToInt32(numberAndColon.Substring(0, numberAndColon.Length - 1));

            upBorder = tileSplitted[1];
            downBorder = tileSplitted[tileSplitted.Length - 1];
            rightBorder = "";
            leftBorder = "";

            for (int i = 1; i < tileSplitted.Length; i++)
            {
                rightBorder += tileSplitted[i].Last();
                leftBorder += tileSplitted[i].First();
            }
        }

        public bool HasBorder(string s)
        {
            return HasUp(s) || HasDown(s) || HasRight(s) || HasLeft(s);
        }

        public bool HasUp(string s)
            => Has(upBorder, s);

        public bool HasDown(string s)
            => Has(downBorder, s);

        public bool HasRight(string s)
            => Has(rightBorder, s);

        public bool HasLeft(string s)
            => Has(leftBorder, s);

        private bool Has(string border, string s)
        {
            return border.Equals(s) || Reverse(border).Equals(s);
        }

        public bool IsCorner()
        {
            return neighboursNumber == 2;
        }

        private string Reverse(string s)
        {
            string reverse = "";

            for (int i = 0; i < s.Length; i++)
            {
                reverse = s[i] + reverse;
            }

            return reverse;
        }

        public override bool Equals(object obj)
        {
            return this.Number == ((Tile)obj).Number;
        }
    }
}