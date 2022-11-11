using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{

    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();










   private void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }


    private void Update()
    {
        if (Player.position.x +5 > spawnedChunks[spawnedChunks.Count - 1].End.position.x)
        {
            SpawnChunk();
        }

    }


    private void  SpawnChunk()
    {

       Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);

        if(spawnedChunks.Count >3)
        {
            Destroy(spawnedChunks[1].gameObject);
            spawnedChunks.RemoveAt(1);
        }

    }







}
