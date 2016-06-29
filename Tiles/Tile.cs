using UnityEngine;
using System.Collections;

public class Tile
{

    public TileType Type;

    public bool bHasAnimatedTexture;

    const float tileSize = 0.0625f;

    public enum Direction { Up, Down, Left, Right };

    public struct TileTextureData { public int x; public int y; }

    public enum TileType
    {
        Tile,
        Air,
        Stone,
        Dirt,
        Coal,
        Gold,
        Iron,
        Leaves,
        Wood,
        Grass,
    };
    

    public bool changed = true;

    public Tile()
    {
        SetTileType();
        SetAnimatedTexture();
        SetAnimatedTile();
    }

    public virtual void Tick(TileData tileData, TileChunk chunk, int x, int y, float deltaTime)
    {
 
    }

    public virtual void SetTileType()
    {
        Type = TileType.Tile;
    }

    public virtual void SetAnimatedTexture()
    {
        bHasAnimatedTexture = false;
    }

    public virtual void OnTileReplaced()
    {
        return;
    }

    public virtual TileTextureData TexturePosition(TileChunk tileChunk, int x, int y)
    {
        TileTextureData tileTextureData = new TileTextureData();
        tileTextureData.x = 0;
        tileTextureData.y = 0;

        return tileTextureData;
    }

    public virtual TileData TileData(TileChunk tileChunk, int x, int y, TileData _tileData)
    {

        _tileData.RenderDataforCol = true;

        if (tileChunk.GetTile(x + 1, y).IsSolid() 
            && tileChunk.GetTile(x - 1, y).IsSolid() 
            && tileChunk.GetTile(x, y - 1).IsSolid()
            && tileChunk.GetTile(x, y + 1).IsSolid()){

            _tileData.RenderDataforCol = false;
        }

        _tileData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, 0));
        _tileData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, 0));
        _tileData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, 0));
        _tileData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, 0));

        _tileData.AddUVs(TileUVs(tileChunk, x, y));

        _tileData.AddQuadTriangles();

        return _tileData;
    }

    public virtual TileData UpdateUV(TileChunk Chunk, int x, int y, TileData _tileData)
    {
        _tileData.AddUVs(TileUVs(Chunk, x, y));
        return _tileData;
    }

    public virtual Vector2[] TileUVs(TileChunk tileChunk, int x, int y)
    {

        Vector2[] UVs = new Vector2[4];
        TileTextureData tilePos = TexturePosition(tileChunk, x,  y);

        UVs[0] = new Vector2(tileSize * tilePos.x + tileSize, tileSize * tilePos.y);
        UVs[1] = new Vector2(tileSize * tilePos.x + tileSize, tileSize * tilePos.y + tileSize);
        UVs[2] = new Vector2(tileSize * tilePos.x, tileSize * tilePos.y + tileSize);
        UVs[3] = new Vector2(tileSize * tilePos.x, tileSize * tilePos.y);

        return UVs;
    }

    public virtual bool IsSolid()
    {
        return true;
    }

    public virtual void SetAnimatedTile()
    {
        bHasAnimatedTexture = false;
    }
}
