using UnityEngine;
using System.Collections;

public class TileGold : Tile {

    public float count = 0;

	public TileGold() : base()
    {

    }

    public override void SetTileType()
    {
        Type = TileType.Gold;
    }

    public override TileTextureData TexturePosition(TileChunk tileChunk, int x, int y)
    {
        TileTextureData tileTextureData = new TileTextureData();

        if (count < 60)
        {   
            tileTextureData.x = 0;
            tileTextureData.y = 3;

        }
        else
        {
            tileTextureData.x = 0;
            tileTextureData.y = 0;
        }

        if(count >= 120)
        {
            count = 0;
        }

        count++;

        return tileTextureData;
    }

    public override bool IsSolid()
    {
        return true;
    }

    public override void SetAnimatedTile()
    {
        bHasAnimatedTexture = true;
    }
}
