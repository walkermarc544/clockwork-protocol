using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPos;
    public float spawnDelay = 5.0f;
    public float spawnVariance = 1.5f;
    public float newRoundDelay = 15.0f;
    private int curRound;
    private int spawnCount;
    private int spawnMax = 15;
    private bool isSpawning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawning && spawnCount < spawnMax)
        {
            StartCoroutine("Spawn");
        }
    }
    IEnumerator Spawn()
    {
        isSpawning = true;
        Instantiate(enemyPrefab, spawnPos);
        spawnCount++;
        yield return new WaitForSeconds(Random.Range(spawnDelay - (spawnVariance / 2), spawnDelay + (spawnVariance / 2)));
        isSpawning = false;
    }
}
