using UnityEngine;
using System.Collections;

public class TileStone : Tile {

	public TileStone() : base()
    {
	}

    public override TileTextureData TexturePosition(TileChunk tileChunk, int x, int y)
    {
        TileTextureData tileTextureData = new TileTextureData();
          
        tileTextureData.x = 0;
        tileTextureData.y = 0;

        return tileTextureData;
    }

    public override void SetTileType()
    {
        Type = TileType.Stone;
    }

    public override bool IsSolid()
	{
		return true;
	}
}
