using UnityEngine;
using UnityEngine.Tilemaps;
using ViewModels.Interfaces;
using WorldGeneration;

namespace ViewModels
{
    public class WorldGeneratorViewModel : IViewModel
    {
        public void Generate(int width, int height, int fillPercent, int smoothFactor, Tilemap tilemap, Tile tile)
        {
            var generator = new WorldGenerator(width, height, fillPercent, smoothFactor);
            
            int[,] world = generator.Generate();
            
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var position = new Vector3Int(x, y, 0);
                    Tile tileValue = world[x, y] > 0 ? tile : null;
                    
                    tilemap.SetTile(position, tileValue);
                }
            }
        }
    }
}