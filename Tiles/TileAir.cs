using UnityEngine;
using System.Collections;

public class TileAir : Tile {

	public TileAir() : base()
    {
	}

    public override void SetTileType()
    {
        Type = TileType.Air;
    }

    public override TileData TileData (TileChunk tileChunk, int x, int y, TileData _tileData)
	{
        _tileData.RenderDataforCol = false;
        return _tileData;
	}

    public override TileData UpdateUV(TileChunk Chunk, int x, int y, TileData _tileData)
    {
        return _tileData;
    }

    public override bool IsSolid()
	{
		return false;
	}

    public override void OnTileReplaced()
    {
        return;
    }
}
