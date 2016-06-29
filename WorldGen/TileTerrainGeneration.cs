using UnityEngine;
using System.Collections;
using SimplexNoise;

public class TileTerrainGeneration
{

    float stoneBaseHeight = 20;
    float stoneBaseNoise = 0.05f;
    float stoneBaseNoiseHeight = 15;

    float stoneMountainHeight = 160;
    float stoneMountainFrequency = 0.005f;

    float dirtBaseHeight = 70;
    float dirtNoise = 0.03f;
    float dirtNoiseHeight = 6;

    float dirtMountainHeight = 50;
    float dirtMountainFrequency = 0.006f;

    public TileChunk ChunkGen(TileChunk chunk)
    {
        for (int x = chunk.pos.x; x < chunk.pos.x + TileChunk.ChunkSizeX; x++)
        {
            for (int y = chunk.pos.y; y < chunk.pos.y + TileChunk.ChunkSizeY; y++)
            {
                chunk = TileChunkColumnGen(chunk, x, y);
            }
        }
        return chunk;
    }

    public static int GetNoise(int x, int y, float scale, int max)
    {
        return Mathf.FloorToInt((Noise.Generate(x * scale, 0, y * scale) + 1f) * (max / 2f));
    }

    public TileChunk TileChunkColumnGen(TileChunk chunk, int x, int y)
    {
        int stoneHeight = Mathf.FloorToInt(stoneBaseHeight);
        stoneHeight += GetNoise(x, 0, stoneMountainFrequency, Mathf.FloorToInt(stoneMountainHeight));

        int dirtHeight = Mathf.FloorToInt(dirtBaseHeight);
        dirtHeight += GetNoise(x, 0, dirtMountainFrequency, Mathf.FloorToInt(dirtMountainHeight));
        dirtHeight += GetNoise(x, y, dirtNoise, Mathf.FloorToInt(dirtNoiseHeight));

        stoneHeight += GetNoise(x, 0, stoneBaseNoise, Mathf.FloorToInt(stoneBaseNoiseHeight));

        for (int yi = chunk.pos.y; yi < chunk.pos.y + TileChunk.ChunkSizeY; yi++)
        {
            if (yi <= stoneHeight)
            {
                chunk.SetTile(x - chunk.pos.x, yi - chunk.pos.y, new TileStone());
            }
            else if (yi <= dirtHeight)
            {
                chunk.SetTile(x - chunk.pos.x, yi - chunk.pos.y, new TileDirt());
            }
            else
            {
                chunk.SetTile(x - chunk.pos.x, yi - chunk.pos.y, new TileAir());
            }
        }

        return chunk;
    }
}
