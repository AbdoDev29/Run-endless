
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] building;
    [SerializeField] private GameObject grass;
    [SerializeField] private GameObject roud;


    [SerializeField]private Vector3 spawnRight;
    [SerializeField] private Vector3 spawnLeft;
    [SerializeField] private Vector3 grassRight;
    [SerializeField] private Vector3 grassLeft;
    [SerializeField] private Vector3 roadUndr;
  
    void Update()
    {
        float distancetoHoizon = Vector3.Distance(player.gameObject.transform.position, spawnRight);

        if (distancetoHoizon < 120)
        {
            SpawnBuildings();
            SpawnGrass();
            SpawnRoad();
        }
    }

    private void SpawnRoad()
    {
        roadUndr = new Vector3(0, -0.11f, spawnRight.z + 30);
        GameObject spawnRoad = Instantiate(roud, roadUndr, Quaternion.identity);
    }

    private void SpawnGrass()
    {
        grassRight = new Vector3(5, 0, spawnRight.z-1 * 24);
        GameObject spawnGrassRight = Instantiate(grass, grassRight, Quaternion.identity);

        grassLeft = new Vector3(-5, 0, spawnRight.z-1 * 24);
        GameObject spawnGrassLeft = Instantiate(grass, grassLeft, Quaternion.identity);
    }

    private void SpawnBuildings()
    {
        spawnRight = new Vector3(9f, 0, spawnRight.z + 10);

       GameObject spawnRightBuldings = Instantiate(building[(Random.Range(0, building.Length))], spawnRight, Quaternion.identity);

        spawnLeft = new Vector3(-9f, 0, spawnRight.z + 10);
        GameObject spawnLeftBuildings = Instantiate(building[(Random.Range(0, building.Length))], spawnLeft, Quaternion.Euler(0,180,0));
    }

     
}
