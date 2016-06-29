using UnityEngine;
using System.Collections;

public class TileWood : Tile {

    public TileWood() : base()
    {
    }

    public override void SetTileType()
    {
        Type = TileType.Wood;
    }

    public override TileTextureData TexturePosition(TileChunk tileChunk, int x, int y)
    {
        TileTextureData tileTextureData = new TileTextureData();
        tileTextureData.x = 2;
        tileTextureData.y = 0;

        return tileTextureData;
    }

    public override bool IsSolid()
    {
        return true;
    }
}
