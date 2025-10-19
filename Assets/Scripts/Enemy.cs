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
    public GameObject resourceDrop;
    int resourceChance;
    public AudioSource enemySounds;
    public AudioClip enemyHitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(targetTag).transform;
        curHealth = maxHealth;
        resourceChance = Random.Range(1, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if(curHealth <= 0)
        {
            if (resourceChance == 1)
            {
            Instantiate(resourceDrop, transform.position, Quaternion.identity);
            }
            resourceChance = Random.Range(1, 8);
            Destroy(gameObject);
        }
        if(follow && target != null)
        {
            myAgent.SetDestination(target.position);
            myAgent.updateRotation = false;
            if(enemySprite != null)
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
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
             if (enemyHitSound != null)
        {
            enemySounds.PlayOneShot(enemyHitSound);
        }
            curHealth -= other.GetComponent<BulletId>().dmg;
            Destroy(other.gameObject);
        }
    }
}
