using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int[] enemyWaveToggle;
    public TMP_Text currentwaveUI;
    /*public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;*/ // <- Better to use Arrays in this instance in order to do more with less lines of code
    public Transform[] spawns;
    public float spawnDelay = 5.0f;
    public float spawnVariance = 1.5f;
    float timePassed = 0.0f;
    float waveTime = 30.0f;
    public float newwaveDelay = 15.0f;
    private int curWave;
    private int spawnCount;
    private int spawnMax = 15;
    private bool isSpawning = false;
    private bool[] toggleEnemy;
    int spawnPos;
    int randomEnemyType;
    public float waveDifficultyMult = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     spawnPos = Random.Range(0, spawns.Length);
     randomEnemyType = Random.Range(0, enemyPrefabs.Length);
     currentwaveUI.text = "Wave: 1";
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
                spawnMax += (int)(5* waveDifficultyMult);//Multiply max enemy spawn cap for every wave
                waveTime += 2.0f;//Increase wave spawn time for every wave
                curWave += 1;
                spawnDelay /= waveDifficultyMult;//Divide spawn delay every new wave, increasing spawn frequency
                currentwaveUI.text = "Wave: " + curWave;
                Debug.Log("Wave: " + curWave);
            }
        }
  
    }
    IEnumerator Spawn()
    {
        isSpawning = true;
        spawnPos = Random.Range(0, spawns.Length - 1);
        randomEnemyType = Random.Range(0, enemyPrefabs.Length);
        Debug.Log(randomEnemyType);
        if (enemyWaveToggle[randomEnemyType] <= curWave)
        {
            yield return new WaitForSeconds(Random.Range(spawnDelay - spawnVariance, spawnDelay + spawnVariance));
            Instantiate(enemyPrefabs[randomEnemyType], spawns[spawnPos]);//Spawn Random Enemy
            spawnCount++;
        }
        isSpawning = false;
    }
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
    // ^^^ DIFFICULTY AND SPAWN FREQUENCY SHOULD BE CONTROLLED BY A MULTIPLIER. IN THIS CASE, waveDifficultyMult
}
