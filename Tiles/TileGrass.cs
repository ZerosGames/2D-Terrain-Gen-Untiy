using UnityEngine;
using System.Collections;

public class TileGrass : Tile {

	public TileGrass() : base()
    {
	}

    public override void SetTileType()
    {
        Type = TileType.Grass;
    }

    public override TileTextureData TexturePosition(TileChunk tileChunk, int x, int y)
	{
		TileTextureData tileTextureData = new TileTextureData ();
		tileTextureData.x = 1;
		tileTextureData.y = 1;

		return tileTextureData;
	}

	public override bool IsSolid()
	{
		return true;
	}
}
