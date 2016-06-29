using UnityEngine;
using System.Collections;

public class TileDirt : Tile {

	public TileDirt() : base()
    {
		
	}

    public override void SetTileType()
    {
        Type = TileType.Dirt;
    }

    public override TileTextureData TexturePosition(TileChunk tileChunk, int x, int y)
	{
		TileTextureData tileTextureData = new TileTextureData ();
		tileTextureData.x = 1;
		tileTextureData.y = 0;

        if(!tileChunk.GetTile(x, y + 1).IsSolid())
        {
            tileTextureData.x = 1;
            tileTextureData.y = 1;
        }

		return tileTextureData;
	}

	public override bool IsSolid()
	{
		return true;
	}
}
