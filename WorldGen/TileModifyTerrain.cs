using UnityEngine;
using System.Collections;
using System.IO;

public class TileModifyTerrain {

    private TileCaveGeneration tileCaveGen = new TileCaveGeneration();

    private int[,] map;

    public void ModifyTerrain(TileWorld world)
    {
        GenerateCaves(world);
        GenerateOreVeins(world);
    }

    public void GenerateCaves(TileWorld world)
    {
        map = tileCaveGen.GenerateMap(TileWorld.WorldSizeInPixelsX, TileWorld.WorldSizeInPixelsY);

        for (int xi = 0; xi < TileWorld.WorldSizeInPixelsX; xi++)
        {
            for (int yi = 0; yi < TileWorld.WorldSizeInPixelsY; yi++)
            {
                if (map[xi, yi] != 1)
                {
                    if (world.GetTile((-TileWorld.WorldX * 16 + xi) + 1, -TileWorld.WorldY * 16 + yi).Type != Tile.TileType.Dirt)
                    {
                        world.SetTile(-TileWorld.WorldX * 16 + xi, -TileWorld.WorldY * 16 + yi, new TileAir());
                    }
                }
            }
        }
    }

    public void GenerateOreVeins(TileWorld world)
    {

    }
}
