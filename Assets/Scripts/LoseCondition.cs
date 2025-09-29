using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoseCondition : MonoBehaviour
{

public GameObject youLose;
public TextMeshProUGUI loseText;

void Start()
{
if (youLose != null)
        {
            youLose.SetActive(false);
        }

}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
youLose.SetActive(true);
            Time.timeScale = 0.0f;
            
        }
    }
}
