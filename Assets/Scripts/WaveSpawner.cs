using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
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
    int randomEnemyType;
    int destinyBondChance;
    int wavePhase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     spawnPosition = Random.Range(1, 4);
     randomEnemyType = Random.Range(1, 4);
     destinyBondChance = Random.Range(1, 4);
     wavePhase = 1;
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
                new WaitForSeconds(4);
                spawnCount = 0;
                timePassed = 0.0f;
                spawnMax += 5;
                waveTime += 2.0f;
                wavePhase += 1;
            }
        }
  
    }
    IEnumerator Spawn()
    {
        isSpawning = true;

        if (spawnPosition == 1) {
            new WaitForSeconds(3);
             if (randomEnemyType == 1) {
 Instantiate(enemyPrefab, spawnPos1);
             }
             if (randomEnemyType == 2) {
 Instantiate(enemy2Prefab, spawnPos1);
             }
             if (randomEnemyType == 3) {
 Instantiate(enemy3Prefab, spawnPos1);
             }
             if (randomEnemyType == 4) {
                if (destinyBondChance == 1) {
                 Instantiate(enemyPrefab, spawnPos1);
                }
                if (destinyBondChance == 2) {
                 Instantiate(enemyPrefab, spawnPos1);
                }
                if (destinyBondChance == 3) {
                 Instantiate(enemy4Prefab, spawnPos1);
                }
             }
            spawnPosition = Random.Range(1, 4);
            randomEnemyType = Random.Range(1, 5);
            Debug.Log("Spawned at Pos 1");
        }
        else if (spawnPosition == 2) {
            new WaitForSeconds(3);
            if (randomEnemyType == 1) {
 Instantiate(enemyPrefab, spawnPos2);
             }
             if (randomEnemyType == 2) {
 Instantiate(enemy2Prefab, spawnPos2);
             }
             if (randomEnemyType == 3) {
 Instantiate(enemy3Prefab, spawnPos2);
             }
             if (randomEnemyType == 4) {
if (destinyBondChance == 1) {
                 Instantiate(enemyPrefab, spawnPos2);
                }
                if (destinyBondChance == 2) {
                 Instantiate(enemy4Prefab, spawnPos2);
                }
                if (destinyBondChance == 3) {
                 Instantiate(enemy4Prefab, spawnPos2);
                }
             }
            spawnPosition = Random.Range(1, 4);
        randomEnemyType = Random.Range(1, 5);
            Debug.Log("Spawned at Pos 2");
        }
        else if (spawnPosition == 3) {
            new WaitForSeconds(3);
            if (randomEnemyType == 1) {
 Instantiate(enemyPrefab, spawnPos3);
             }
             if (randomEnemyType == 2) {
 Instantiate(enemy2Prefab, spawnPos3);
             }
             if (randomEnemyType == 3) {
 Instantiate(enemy3Prefab, spawnPos3);
             }
             if (randomEnemyType == 4) {
if (destinyBondChance == 1) {
                 Instantiate(enemyPrefab, spawnPos3);
                }
                if (destinyBondChance == 2) {
                 Instantiate(enemyPrefab, spawnPos3);
                }
                if (destinyBondChance == 3) {
                 Instantiate(enemy4Prefab, spawnPos3);
                }
             }
            spawnPosition = Random.Range(1, 4);
            randomEnemyType = Random.Range(1, 5);
            Debug.Log("Spawned at Pos 3");
        };
        spawnCount++;
        if (wavePhase == 1) {
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
        if (wavePhase == 2) {
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
        if (wavePhase == 3) {
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
        if (wavePhase == 4) {
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
        if (wavePhase == 5) {
            yield return new WaitForSeconds(1);
        }
        if (wavePhase == 6) {
            yield return new WaitForSeconds(1);
        }
        if (wavePhase == 7) {
            yield return new WaitForSeconds(0.7f);
        }
        if (wavePhase == 8) {
            yield return new WaitForSeconds(0.7f);
        }
        if (wavePhase == 9) {
            yield return new WaitForSeconds(0.5f);
        }
        if (wavePhase == 10) {
            yield return new WaitForSeconds(0.5f);
        }
        if (wavePhase == 11) {
            yield return new WaitForSeconds(0.3f);
        }
        if (wavePhase == 12) {
            yield return new WaitForSeconds(0.3f);
        }
        if (wavePhase == 13) {
            yield return new WaitForSeconds(0.2f);
        }
        if (wavePhase == 14) {
            yield return new WaitForSeconds(0.2f);
        }
        if (wavePhase >= 15) {
            yield return new WaitForSeconds(0.1f);
        }
        isSpawning = false;
    }
}
