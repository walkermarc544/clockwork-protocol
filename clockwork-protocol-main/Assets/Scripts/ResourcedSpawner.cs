using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcedSpawner : MonoBehaviour
{
    //map size, change in editor
    public GameObject Item;
    public float mapMinX = -5f;
    public float mapMaxX = 5f;
    public float mapMinZ = -5f;
    public float mapMaxZ = 5f;
    public float fixedY = 20f;

    void Start()
    {
        StartCoroutine(SpawnResource());
    }

    IEnumerator SpawnResource()
    {
        while (true)
        {
            SpawnR();
            //intervals between pickup spawns
            yield return new WaitForSeconds(7f);
        }
    }

    public void SpawnR()
    {
        //float fixedY = transform.position.y;

 
        float centerX = Random.Range(mapMinX, mapMaxX);
        float centerZ = Random.Range(mapMinZ, mapMaxZ);
        //range between pickups, edit here

        float spawnX = centerX + Random.Range(-8f, 8f);
        float spawnZ = centerZ + Random.Range(-8f, 8f);

        Vector3 spawnPosition = new Vector3(spawnX, fixedY, spawnZ);

        Instantiate(Item, spawnPosition, Quaternion.identity);
    }
}