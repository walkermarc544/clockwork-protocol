using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
