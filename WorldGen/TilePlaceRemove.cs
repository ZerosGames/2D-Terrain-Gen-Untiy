using UnityEngine;
using System.Collections;

public class TilePlaceRemove
{
    public static TileWorldPos GetTilePos(Vector2 pos)
    {
        TileWorldPos TilePos = new TileWorldPos(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));

        return TilePos;
    }

    public static bool SetTile(TileWorld World, Tile tile, Vector2 Pos)
    {
        TileChunk chunk = World.GetChunk(Mathf.RoundToInt(Pos.x), Mathf.RoundToInt(Pos.y));
        if (chunk == null)
            return false;

        TileWorldPos pos = GetTilePos(Pos);

        chunk.World.SetTile(pos.x, pos.y, tile);

        return true;
    }
}
