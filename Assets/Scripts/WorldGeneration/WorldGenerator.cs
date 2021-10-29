using UnityEngine;
using WorldGeneration.Interfaces;

namespace WorldGeneration
{
    public class WorldGenerator : IWorldGenerator
    {
        private const int CountWall = 4;
        
        private readonly int _width;
        private readonly int _height;
        private readonly int _randomFillPercent;
        private readonly int _factorSmooth;
        
        private int[,] _world;

        public WorldGenerator(int width, int height, int randomFillPercent, int factorSmooth)
        {
            _width = width;
            _height = height;
            _randomFillPercent = randomFillPercent;
            _factorSmooth = factorSmooth;

            _world = new int[width, height];
        }
        
        public int[,] Generate()
        {
            FillRandom();
            
            for (var i = 0; i < _factorSmooth; i++)
                Smooth();
            
            return _world;
        }

        private void FillRandom()
        {
            var seed = Time.time.ToString();
            var pseudoRandom = new System.Random(seed.GetHashCode());

            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    if (IsEdge(x, y))
                        _world[x, y] = 1;
                    else
                        _world[x, y] = pseudoRandom.Next(0, 100) < _randomFillPercent ? 1 : 0;
                }
            }
        }

        private void Smooth()
        {
            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    if (IsEdge(x, y))
                        _world[x, y] = 1;
                    else
                        _world[x, y] = CountNeighborTiles(x, y) > CountWall ? 1 : 0;
                }
            }
        }

        private int CountNeighborTiles(int x, int y)
        {
            var neighborCount = 0;

            for (int neighbourX = x - 1; neighbourX <= x + 1; neighbourX++)
            {
                for (int neighbourY = y - 1; neighbourY <= y + 1; neighbourY++)
                {
                    bool isInside = neighbourX >= 0 && neighbourX < _width && neighbourY >= 0 && neighbourY < _height;
                    
                    if (isInside)
                    {
                        bool isSelf = neighbourX == x && neighbourY == y;
                        
                        if (!isSelf)
                            neighborCount += _world[neighbourX, neighbourY];
                    }
                    else
                    {
                        neighborCount++;
                    }
                }
            }

            return neighborCount;
        }

        private bool IsEdge(int x, int y)
        {
            return x == 0 || x == _width - 1 || y == 0 || y == _height - 1;
        }
    }
}