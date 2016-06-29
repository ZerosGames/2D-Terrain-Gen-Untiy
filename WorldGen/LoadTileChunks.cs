using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadTileChunks : MonoBehaviour
{
    static List<TileWorldPos> ChunkPosition;
    public TileWorld World;

    List<TileWorldPos> updateList = new List<TileWorldPos>();

    float timer;

    void Start()
    {
        ChunkPosition = new List<TileWorldPos>();

        timer = Time.fixedTime + 60.0f;

        for (int i = -4; i <= 4; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                ChunkPosition.Add(new TileWorldPos(i, j));
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        FindChunksToLoad();
        timer++;
        if(timer >= 300)
        {
            LoadAndRenderChunks();
            timer = 0;
        }
    }

    void FindChunksToLoad()
    {
        //Get the position of this gameobject to generate around
        TileWorldPos playerPos = new TileWorldPos(
            Mathf.FloorToInt(transform.position.x / TileChunk.ChunkSizeX) * TileChunk.ChunkSizeX, Mathf.FloorToInt(transform.position.y / TileChunk.ChunkSizeY) * TileChunk.ChunkSizeY);

        //If there aren't already chunks to generat
        //Cycle through the array of positions
        for (int i = 0; i < ChunkPosition.Count; i++)
        {
            //translate the player position and array position into chunk position
            TileWorldPos newChunkPos = new TileWorldPos(ChunkPosition[i].x * TileChunk.ChunkSizeX + playerPos.x, ChunkPosition[i].y * TileChunk.ChunkSizeY + playerPos.y);

            //Get the chunk in the defined position
            TileChunk newChunk = World.GetChunk(newChunkPos.x, newChunkPos.y);

            //If the chunk already exists and it's already
            //rendered or in queue to be rendered continue
            if (newChunk != null)
                continue;

            //load a column of chunks in this position
           
            updateList.Add(new TileWorldPos(newChunkPos.x, newChunkPos.y));
        }
    }

    void LoadAndRenderChunks()
    {
        for (int i = 0; i < updateList.Count; i++)
        {
            TileChunk chunk = World.GetChunk(updateList[i].x, updateList[i].y);
            if (chunk != null)
            {
                chunk.ChunkUpdate = true;
            }
            updateList.RemoveAt(i);
        }

    }
}

