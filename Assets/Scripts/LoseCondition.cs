using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoseCondition : MonoBehaviour
{

public GameObject youLose;
public TextMeshProUGUI healthText;
public TextMeshProUGUI loseText;
public int Health = 3;
private int HealHits = 0;

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
}

public void LoseHealth(int amount)
    {
        Health -= amount;
        UpdateHUD();
    }

void UpdateHUD()
    {
        if (healthText != null)
            healthText.text = "Health: " + Health;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {

            LoseHealth(1);
            Destroy(other.gameObject);
            
        }
        else if(other.CompareTag("HealBullet"))
        {

            HealHits += 1;
            Destroy(other.gameObject);
            
        }

if (HealHits == 30)
{
LoseHealth(-1);
HealHits = 0;
}

    }
}
