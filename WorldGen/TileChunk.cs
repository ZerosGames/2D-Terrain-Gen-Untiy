using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum UpdateType
{
    FullChunkUpdate,
    FullChunkColisionUpdate,
    FullChunkUVUpdate,
};

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileChunk : MonoBehaviour
{
    private Tile[,] tiles = new Tile[ChunkSizeX, ChunkSizeY];
    private TileData BaseTileData = new TileData();
    public static int ChunkSizeX = 16;
    public static int ChunkSizeY = 16;

    MeshFilter filter;
    MeshCollider coll;
    MeshRenderer MeshRenderer;

    public TileWorld World;
    public TileWorldPos pos;

    public bool ChunkUpdate = true;
    public bool ChunkNeedUvUpdate = false;
    public bool Isvisable = false;
    public bool rendered;

    // Use this for initialization
    void Start()
    {
        MeshRenderer = gameObject.GetComponent<MeshRenderer>();
        filter = gameObject.GetComponent<MeshFilter>();
        coll = gameObject.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkNeedUvUpdate = false;

        Isvisable = MeshRenderer.isVisible;

        if (ChunkUpdate)
        {
            ChunkUpdate = false;
            UpdateChunk(UpdateType.FullChunkUpdate);
        }

        if (MeshRenderer.isVisible)
        {
            for (int x = 0; x < ChunkSizeX; x++)
            {
                for (int y = 0; y < ChunkSizeY; y++)
                {
                    if (tiles[x, y].bHasAnimatedTexture)
                    {
                        ChunkNeedUvUpdate = true;
                    }
                }
            }
        }
        else
        {
            ChunkNeedUvUpdate = false;
        }

        if (!ChunkUpdate && ChunkNeedUvUpdate)
        {
            
            UpdateChunk(UpdateType.FullChunkUVUpdate);
        }
    }

    public void SetTile(int x, int y, Tile tile)
    {
        if (InRange(x, y))
        {
            //tiles[x, y].OnTileReplaced();
            tiles[x, y] = tile;
        }
        else
        {
            World.SetTile(pos.x + x, pos.y + y, tile);
        }
    }

    public void SetTileUnmodified()
    {
        foreach (Tile tile in tiles)
        {
            tile.changed = false;
        }
    }

    public Tile GetTile(int x, int y)
    {
        if (InRange(x, y) && InRange(x, y))
            return tiles[x, y];
        return World.GetTile(pos.x + x, pos.y + y);
    }

    public static bool InRange(int indexX, int indexY)
    {
        if (indexX < 0 || indexX >= ChunkSizeX)
            return false;
        if (indexY < 0 || indexY >= ChunkSizeY)
            return false;

        return true;
    }

    void UpdateChunk(UpdateType _type)
    {

        TileData NewtileData = new TileData();
        BaseTileData.uv.Clear();

        for (int x = 0; x < ChunkSizeX; x++)
        {
            for (int y = 0; y < ChunkSizeY; y++)
            {


                switch (_type)
                {

                    case UpdateType.FullChunkUpdate:

                        BaseTileData = tiles[x, y].TileData(this, x, y, NewtileData);
                        break;
                    case UpdateType.FullChunkColisionUpdate:
                        BaseTileData.colVertices = tiles[x, y].TileData(this, x, y, NewtileData).colVertices;
                        BaseTileData.colTriangles = tiles[x, y].TileData(this, x, y, NewtileData).colTriangles;

                        break;
                    case UpdateType.FullChunkUVUpdate:
                        BaseTileData = tiles[x, y].UpdateUV(this, x, y, BaseTileData);
                        break;
                }
            }
        }

        switch (_type)
        {

            case UpdateType.FullChunkUpdate:
                FullMeshUpdate(BaseTileData);   
                break;
            case UpdateType.FullChunkColisionUpdate:
                break;
            case UpdateType.FullChunkUVUpdate:
                FullUVUpdate(BaseTileData);
                break;
        }
    }

    void FullUVUpdate(TileData tileData)
    {

        filter.mesh.SetUVs(0, tileData.uv);
    }

    void FullMeshUpdate(TileData tileData)
    {

        filter.mesh.Clear();
        filter.mesh.SetVertices(tileData.vertices);
        filter.mesh.SetUVs(0,tileData.uv);
        filter.mesh.SetTriangles(tileData.triangles, 0);
        filter.mesh.RecalculateNormals();

        coll.sharedMesh = null;
        Mesh mesh = new Mesh();
        mesh.vertices = tileData.colVertices.ToArray();
        mesh.triangles = tileData.colTriangles.ToArray();
        mesh.RecalculateNormals();

        coll.sharedMesh = mesh;
    }
}
