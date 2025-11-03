using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer enemySprite;
    public string targetTag;
    private NavMeshAgent myAgent;
    public bool follow;
    //HEALTH
    public int maxHealth = 100;
    public int curHealth = 100;
    public int dmg = 25;
    public float dmgDelay = 2.0f;
    public GameObject resourceDrop;
    int resourceChance;
    public AudioSource enemySounds;
    public AudioClip enemyHitSound;
    private bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(targetTag).transform;
        curHealth = maxHealth;
        resourceChance = Random.Range(1, 6);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
        {
            if (resourceChance == 1)
            {
                Instantiate(resourceDrop, transform.position, Quaternion.identity);
            }
            resourceChance = Random.Range(1, 6);
            Destroy(gameObject);
        }
        if (follow && target != null)
        {
            myAgent.SetDestination(target.position);
            myAgent.updateRotation = false;
            if (enemySprite != null)
            {
                if (myAgent.velocity.x < 0)
                {
                    Debug.Log("LEFT");
                    enemySprite.flipX = true;
                }
                else if (myAgent.velocity.x > 0)
                {
                    enemySprite.flipX = false;
                }
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (enemyHitSound != null)
            {
                enemySounds.PlayOneShot(enemyHitSound, 0.25f);
            }
            curHealth -= other.GetComponent<BulletId>().dmg;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Barricade") && !isAttacking)
        {
            Debug.Log("DAMAGING");
            StartCoroutine("attack", other.GetComponent<Barricade>());
        }
    }
    IEnumerator attack(Barricade victim)
    {
        isAttacking = true;
        victim.curHealth -= dmg;
        yield return new WaitForSeconds(dmgDelay);
        isAttacking = false;
    }
}
