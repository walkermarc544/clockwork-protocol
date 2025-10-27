using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
    public int dmg = 25;
    public float dmgDelay = 2.0f;
    private bool isDamaging = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine("damage", other.GetComponent<Enemy>());
        }
    }
    IEnumerator damage(Enemy victim)
    {
        isDamaging = true;
        victim.curHealth -= dmg;
        yield return new WaitForSeconds(dmgDelay);
        isDamaging = false;
    }
}
