using UnityEngine;
using System.Collections;

public class TileLeaves : Tile {

	public TileLeaves() : base()
    {

    }

    public override void SetTileType()
    {
        Type = TileType.Leaves;
    }

    public override TileTextureData TexturePosition(TileChunk tileChunk, int x, int y)
    {
        TileTextureData tileTextureData = new TileTextureData();
        tileTextureData.x = 2;
        tileTextureData.y = 1;

        return tileTextureData;
    }

    public override bool IsSolid()
    {
        return true;
    }
}
