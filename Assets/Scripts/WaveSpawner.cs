using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public TMP_Text currentRoundUI;
    /*public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;*/ // <- Better to use Arrays in this instance in order to do more with less lines of code
    public Transform[] spawns;
    public float spawnDelay = 5.0f;
    public float spawnVariance = 1.5f;
    float timePassed = 0.0f;
    float waveTime = 30.0f;
    public float newRoundDelay = 15.0f;
    private int curRound;
    private int spawnCount;
    private int spawnMax = 15;
    private bool isSpawning = false;
    private bool[] toggleEnemy;
    int spawnPos;
    int randomEnemyType;
    int destinyBondChance;
    public int[] spawnMult = { 1 };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     spawnPos = Random.Range(1, 4);
     randomEnemyType = Random.Range(1, 4);
     destinyBondChance = Random.Range(1, 4);
     currentRoundUI.text = "Round: 1";
    }

    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;

        if (!isSpawning && spawnCount < spawnMax)
        {
            StartCoroutine("Spawn");
        }

        if (!isSpawning && spawnCount >= spawnMax)
        {

            if (timePassed > waveTime)
            {
                // new WaitForSeconds(4); <- This doesn't call anything, because that function only works within a coroutine function because it's a yield function, which can only be called within a coroutine function. <3 - Marc
                
                spawnCount = 0;
                timePassed = 0.0f;
                spawnMax += 5;
                waveTime += 2.0f;
                spawnMult[curRound] += 1;
                currentRoundUI.text = "Round: " + curRound;
                Debug.Log("Wave Phase: " + curRound);
            }
        }
  
    }
    IEnumerator Spawn()
    {
        isSpawning = true;
        spawnPos = Random.Range(0, spawns.Length);
        randomEnemyType = Random.Range(0, spawns.Length);
            yield return new WaitForSeconds(spawnDelay);
            if (randomEnemyType < 4) {
                Instantiate(enemyPrefabs[randomEnemyType], spawns[spawnPos]);
             }
             else if (randomEnemyType == 4) {
                    Instantiate(enemyPrefabs[4], spawns[spawnPos]);//Spawn Destiny Bond
             }
        spawnCount++;
        /*
        if (spawnMult== 1) {
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
        if (spawnMult== 2) {
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
        if (spawnMult== 3) {
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
        if (spawnMult== 4) {
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
        if (spawnMult== 5) {
            yield return new WaitForSeconds(1);
        }
        if (spawnMult== 6) {
            yield return new WaitForSeconds(1);
        }
        if (spawnMult== 7) {
            yield return new WaitForSeconds(0.7f);
        }
        if (spawnMult== 8) {
            yield return new WaitForSeconds(0.7f);
        }
        if (spawnMult== 9) {
            yield return new WaitForSeconds(0.5f);
        }
        if (spawnMult== 10) {
            yield return new WaitForSeconds(0.5f);
        }
        if (spawnMult== 11) {
            yield return new WaitForSeconds(0.3f);
        }
        if (spawnMult== 12) {
            yield return new WaitForSeconds(0.3f);
        }
        if (spawnMult== 13) {
            yield return new WaitForSeconds(0.2f);
        }
        if (spawnMult== 14) {
            yield return new WaitForSeconds(0.2f);
        }
        if (spawnMult>= 15) {
            yield return new WaitForSeconds(0.1f);
        }*/
        // ^^^ USE THE spawnMult ARRAY IN THE INSPECTOR TO CHANGE SPECIFIC ROUND SPAWN TIMES
        isSpawning = false;
    }
}
