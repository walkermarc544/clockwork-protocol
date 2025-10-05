using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPos1;
    public Transform spawnPos2;
    public Transform spawnPos3;
    public float spawnDelay = 5.0f;
    public float spawnVariance = 1.5f;
    float timePassed = 0.0f;
    float waveTime = 30.0f;
    public float newRoundDelay = 15.0f;
    private int curRound;
    private int spawnCount;
    private int spawnMax = 15;
    private bool isSpawning = false;
    int spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     spawnPosition = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;

        if (!isSpawning && spawnCount < spawnMax)
        {
            StartCoroutine("Spawn");
        }

        if (!isSpawning && spawnCount == spawnMax)
        {

            if (timePassed > waveTime)
            {
                new WaitForSeconds(10);
                spawnCount = 0;
                timePassed = 0.0f;
                spawnMax += 5;
                waveTime += 5.0f;
            }
        }
  
    }
    IEnumerator Spawn()
    {
        isSpawning = true;

        if (spawnPosition == 1) {
            new WaitForSeconds(3);
            Instantiate(enemyPrefab, spawnPos1);
            spawnPosition = Random.Range(1, 4);
            Debug.Log("Spawned at Pos 1");
        }
        else if (spawnPosition == 2) {
            new WaitForSeconds(3);
            Instantiate(enemyPrefab, spawnPos2);
            spawnPosition = Random.Range(1, 4);
            Debug.Log("Spawned at Pos 2");
        }
        else if (spawnPosition == 3) {
            new WaitForSeconds(3);
            Instantiate(enemyPrefab, spawnPos3);
            spawnPosition = Random.Range(1, 4);
            Debug.Log("Spawned at Pos 3");
        };
        spawnCount++;
        yield return new WaitForSeconds(Random.Range(1, 3));
        isSpawning = false;
    }
}
