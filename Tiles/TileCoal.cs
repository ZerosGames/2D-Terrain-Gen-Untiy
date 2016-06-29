using UnityEngine;
using System.Collections;

public class TileCoal : Tile {

    public TileCoal() : base() {
    }

    public override void SetTileType()
    {
        Type = TileType.Coal;
    }

    public override TileTextureData TexturePosition(TileChunk tileChunk, int x, int y)
    {
        TileTextureData tileTextureData = new TileTextureData();
        tileTextureData.x = 0;
        tileTextureData.y = 1;

        return tileTextureData;
    }

    public override bool IsSolid()
    {
        return true;
    }
}
