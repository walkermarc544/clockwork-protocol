using UnityEngine;
using TMPro ;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject youLose;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI loseText;
    public int Health = 5;
    private int HealHits = 0;
    public int HealHitMeter = 30;
    public int winScene;
    public bool endlessMode;
    public WaveSpawner spawnScript;

    void Start()
    {
        UpdateHUD();

        if (youLose != null)
        {
            youLose.SetActive(false);
        }

    }

    void Update()
    {
        if (Health == 0)
        {
            youLose.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            if(spawnScript.curWave > 3 && spawnScript.spawnCount == 0 && !endlessMode)
            {
                winGame();
            }
        }
    }

    public void LoseHealth(int amount)
    {
        Health -= amount;
        UpdateHUD();
    }

    public void Restarted()
    {
        Health = 5;
        Time.timeScale = 1.0f;
        UpdateHUD();
    }

    void UpdateHUD()
    {
        if (healthText != null)
            healthText.text = "Health: " + Health;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            LoseHealth(1);
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("HealBullet"))
        {

            HealHits += 1;
            Destroy(other.gameObject);

        }

        if (HealHits == HealHitMeter)
        {
            LoseHealth(-1);
            HealHits = 0;
        }

    }
    public void winGame()
    {
        SceneManager.LoadScene(winScene);
    }
}