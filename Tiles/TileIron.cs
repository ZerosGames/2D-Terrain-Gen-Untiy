using UnityEngine;
using System.Collections;

public class TileIron : Tile {

	public TileIron() : base()
    {

    }

    public override void SetTileType()
    {
        Type = TileType.Iron;
    }

    public override TileTextureData TexturePosition(TileChunk tileChunk, int x, int y)
    {
        TileTextureData tileTextureData = new TileTextureData();
        tileTextureData.x = 0;
        tileTextureData.y = 2;

        return tileTextureData;
    }

    public override bool IsSolid()
    {
        return true;
    }
}
