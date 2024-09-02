using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrafap; // Array that incloude all tiles
    [SerializeField] private float zSpawn = 0;
    [SerializeField] private float tileLength = 27; 
    [SerializeField] private int numberOfTiles= 4; 
    [SerializeField] private Transform player; 

    private List<GameObject> activeTiles = new List<GameObject>();
    private void Start()
    {
      for(int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
            SpawnTile(Random.Range(0, tilePrafap.Length));
        }
    }

    private void Update()
    {
        {
            // i make -100 pecause that player in a safe area
            if (player.position.z-100 > zSpawn - (numberOfTiles * tileLength))
            {
                SpawnTile(Random.Range(0, tilePrafap.Length));
                DeleteTile();
            }
        }
    }


    private void SpawnTile(int tileIndex)
    {
        Vector3 newpath = new Vector3(-1, 0, 0);
       GameObject tile = Instantiate(tilePrafap[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(tile);
        zSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
