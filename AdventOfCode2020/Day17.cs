using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day17 : Solver
    {
        string input;
        static int CYCLES = 6;
        static char ACTIVE_CUBE_STATE = '#';

        public Day17(string input)
        {
            this.input = input;
        }


        public override long SolvePart1()
        {
            TridimensionalSpace tridimensionalSpace = new TridimensionalSpace(input);

            for (int i = 0; i < CYCLES; i++)
            {
                tridimensionalSpace.SimulateOneCycle();
            }

            return tridimensionalSpace.GetActiveCubesNumber();
        }

        public override long SolvePart2()
        {
            FourdimensionalSpace fourdimensionalSpace = new FourdimensionalSpace(input);

            for (int i = 0; i < CYCLES; i++)
            {
                fourdimensionalSpace.SimulateOneCycle();
            }

            return fourdimensionalSpace.GetActiveCubesNumber();
        }


        class TridimensionalSpace
        {
            Hashtable activeCubes = new Hashtable();

            public TridimensionalSpace(string input)
            {
                string[] inputSplitted = input.Split("\r\n");

                for (int y = 0; y < inputSplitted.Length; y++)
                {
                    for (int x = 0; x < inputSplitted[0].Length; x++)
                    {
                        if (inputSplitted[y][x] == ACTIVE_CUBE_STATE)
                        {
                            ActiveCube(x, y, 0);
                        }
                    }
                }
            }


            public void SimulateOneCycle()
            {
                List<(int, int, int)> cubesToActive = new List<(int, int, int)>();
                List<(int, int, int)> cubesToDesactive = new List<(int, int, int)>();

                List<(int, int, int)> activeCubesList = activeCubes.Keys.Cast<(int, int, int)>().ToList();
                int xMin = activeCubesList.Min(ac => ac.Item1), xMax = activeCubesList.Max(ac => ac.Item1);
                int yMin = activeCubesList.Min(ac => ac.Item2), yMax = activeCubesList.Max(ac => ac.Item2);
                int zMin = activeCubesList.Min(ac => ac.Item3), zMax = activeCubesList.Max(ac => ac.Item3);

                for (int x = xMin - 1; x <= xMax + 1; x++)
                {
                    for (int y = yMin - 1; y <= yMax + 1; y++)
                    {
                        for (int z = zMin - 1; z <= zMax + 1; z++)
                        {
                            (int, int, int) cube = (x, y, z);
                            int activeNeighbours = CountActiveNeighbours(cube);

                            if (IsActive(cube))
                            {
                                if (activeNeighbours < 2 || 3 < activeNeighbours)
                                {
                                    cubesToDesactive.Add(cube);
                                }
                            }
                            else
                            {
                                if (activeNeighbours == 3)
                                {
                                    cubesToActive.Add(cube);
                                }
                            }
                        }
                    }
                }

                foreach ((int x, int y, int z) in cubesToActive)
                {
                    ActiveCube(x, y, z);
                }

                foreach ((int x, int y, int z) in cubesToDesactive)
                {
                    DesactiveCube(x, y, z);
                }
            }

            public long GetActiveCubesNumber()
            {
                return activeCubes.Keys.Count;
            }


            private bool IsActive((int x, int y, int z) cube)
            {
                return activeCubes.ContainsKey(cube);
            }

            private void ActiveCube(int x, int y, int z)
            {
                activeCubes.Add((x, y, z), true);
            }

            private void DesactiveCube(int x, int y, int z)
            {
                activeCubes.Remove((x, y, z));
            }

            private int CountActiveNeighbours((int x, int y, int z) cube)
            {
                int activeNeighbours = 0;
                List<(int x, int y, int z)> neighbours = new List<(int x, int y, int z)>()
                {
                    (0, 0, 1),
                    (0, 1, 0),
                    (0, 1, 1),
                    (1, 0, 0),
                    (1, 0, 1),
                    (1, 1, 0),
                    (1, 1, 1),

                    (0, 0, -1),
                    (0, -1, 0),
                    (0, -1, -1),
                    (-1, 0, 0),
                    (-1, 0, -1),
                    (-1, -1, 0),
                    (-1, -1, -1),

                    (0, 1, -1),
                    (0, -1, 1),
                    (1, 0, -1),
                    (-1, 0, 1),
                    (1, -1, 0),
                    (-1, 1, 0),

                    (1, 1, -1),
                    (1, -1, 1),
                    (-1, 1, 1),

                    (1, -1, -1),
                    (-1, -1, 1),
                    (-1, 1, -1),
                };

                foreach ((int x, int y, int z) neighbour in neighbours)
                {
                    if (IsActive(SumVectors(cube, neighbour)))
                    {
                        activeNeighbours++;
                    }
                }

                return activeNeighbours;


                (int x, int y, int z) SumVectors((int x, int y, int z) v1, (int x, int y, int z) v2)
                {
                    return (v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
                }
            }
        }

        class FourdimensionalSpace
        {
            Hashtable activeCubes = new Hashtable();

            public FourdimensionalSpace(string input)
            {
                string[] inputSplitted = input.Split("\r\n");

                for (int y = 0; y < inputSplitted.Length; y++)
                {
                    for (int x = 0; x < inputSplitted[0].Length; x++)
                    {
                        if (inputSplitted[y][x] == ACTIVE_CUBE_STATE)
                        {
                            ActiveCube(x, y, 0, 0);
                        }
                    }
                }
            }


            public void SimulateOneCycle()
            {
                List<(int, int, int, int)> cubesToActive = new List<(int, int, int, int)>();
                List<(int, int, int, int)> cubesToDesactive = new List<(int, int, int, int)>();

                List<(int, int, int, int)> activeCubesList = activeCubes.Keys.Cast<(int, int, int, int)>().ToList();
                int xMin = activeCubesList.Min(ac => ac.Item1), xMax = activeCubesList.Max(ac => ac.Item1);
                int yMin = activeCubesList.Min(ac => ac.Item2), yMax = activeCubesList.Max(ac => ac.Item2);
                int zMin = activeCubesList.Min(ac => ac.Item3), zMax = activeCubesList.Max(ac => ac.Item3);
                int wMin = activeCubesList.Min(ac => ac.Item4), wMax = activeCubesList.Max(ac => ac.Item4);

                for (int x = xMin - 1; x <= xMax + 1; x++)
                {
                    for (int y = yMin - 1; y <= yMax + 1; y++)
                    {
                        for (int z = zMin - 1; z <= zMax + 1; z++)
                        {
                            for (int w = wMin - 1; w <= wMax + 1; w++)
                            {
                                (int, int, int, int) cube = (x, y, z, w);
                                int activeNeighbours = CountActiveNeighbours(cube);

                                if (IsActive(cube))
                                {
                                    if (activeNeighbours < 2 || 3 < activeNeighbours)
                                    {
                                        cubesToDesactive.Add(cube);
                                    }
                                }
                                else
                                {
                                    if (activeNeighbours == 3)
                                    {
                                        cubesToActive.Add(cube);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach ((int x, int y, int z, int w) in cubesToActive)
                {
                    ActiveCube(x, y, z, w);
                }

                foreach ((int x, int y, int z, int w) in cubesToDesactive)
                {
                    DesactiveCube(x, y, z, w);
                }
            }

            public long GetActiveCubesNumber()
            {
                return activeCubes.Keys.Count;
            }


            private bool IsActive((int x, int y, int z, int w) cube)
            {
                return activeCubes.ContainsKey(cube);
            }

            private void ActiveCube(int x, int y, int z, int w)
            {
                activeCubes.Add((x, y, z, w), true);
            }

            private void DesactiveCube(int x, int y, int z, int w)
            {
                activeCubes.Remove((x, y, z, w));
            }

            private int CountActiveNeighbours((int x, int y, int z, int w) cube)
            {
                int activeNeighbours = 0;
                List<(int x, int y, int z, int w)> neighbours = new List<(int x, int y, int z, int w)>()
                {
                    (1, 0, 0, 0),
                    (-1, 0, 0, 0),

                    (0, 0, 0, 1),
                    (0, 0, 1, 0),
                    (0, 0, 1, 1),
                    (0, 1, 0, 0),
                    (0, 1, 0, 1),
                    (0, 1, 1, 0),
                    (0, 1, 1, 1),
                    (0, 0, 0, -1),
                    (0, 0, -1, 0),
                    (0, 0, -1, -1),
                    (0, -1, 0, 0),
                    (0, -1, 0, -1),
                    (0, -1, -1, 0),
                    (0, -1, -1, -1),
                    (0, 0, 1, -1),
                    (0, 0, -1, 1),
                    (0, 1, 0, -1),
                    (0, -1, 0, 1),
                    (0, 1, -1, 0),
                    (0, -1, 1, 0),
                    (0, 1, 1, -1),
                    (0, 1, -1, 1),
                    (0, -1, 1, 1),
                    (0, 1, -1, -1),
                    (0, -1, -1, 1),
                    (0, -1, 1, -1),

                    (1, 0, 0, 1),
                    (1, 0, 1, 0),
                    (1, 0, 1, 1),
                    (1, 1, 0, 0),
                    (1, 1, 0, 1),
                    (1, 1, 1, 0),
                    (1, 1, 1, 1),
                    (1, 0, 0, -1),
                    (1, 0, -1, 0),
                    (1, 0, -1, -1),
                    (1, -1, 0, 0),
                    (1, -1, 0, -1),
                    (1, -1, -1, 0),
                    (1, -1, -1, -1),
                    (1, 0, 1, -1),
                    (1, 0, -1, 1),
                    (1, 1, 0, -1),
                    (1, -1, 0, 1),
                    (1, 1, -1, 0),
                    (1, -1, 1, 0),
                    (1, 1, 1, -1),
                    (1, 1, -1, 1),
                    (1, -1, 1, 1),
                    (1, 1, -1, -1),
                    (1, -1, -1, 1),
                    (1, -1, 1, -1),

                    (-1, 0, 0, 1),
                    (-1, 0, 1, 0),
                    (-1, 0, 1, 1),
                    (-1, 1, 0, 0),
                    (-1, 1, 0, 1),
                    (-1, 1, 1, 0),
                    (-1, 1, 1, 1),
                    (-1, 0, 0, -1),
                    (-1, 0, -1, 0),
                    (-1, 0, -1, -1),
                    (-1, -1, 0, 0),
                    (-1, -1, 0, -1),
                    (-1, -1, -1, 0),
                    (-1, -1, -1, -1),
                    (-1, 0, 1, -1),
                    (-1, 0, -1, 1),
                    (-1, 1, 0, -1),
                    (-1, -1, 0, 1),
                    (-1, 1, -1, 0),
                    (-1, -1, 1, 0),
                    (-1, 1, 1, -1),
                    (-1, 1, -1, 1),
                    (-1, -1, 1, 1),
                    (-1, 1, -1, -1),
                    (-1, -1, -1, 1),
                    (-1, -1, 1, -1),
                };

                foreach ((int x, int y, int z, int w) neighbour in neighbours)
                {
                    if (IsActive(SumVectors(cube, neighbour)))
                    {
                        activeNeighbours++;
                    }
                }

                return activeNeighbours;


                (int x, int y, int z, int w) SumVectors((int x, int y, int z, int w) v1, (int x, int y, int z, int w) v2)
                {
                    return (v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
                }
            }
        }
    }    
}