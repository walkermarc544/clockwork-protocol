using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
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
    public GameObject destroyTurret;
    public GameObject boostResource;
    public AudioSource enemyDBSounds;
    public AudioClip enemyDBHitSound;
    public AudioSource turretDestroySounds;
    public AudioClip turretDestroySound;
    private bool canDrop = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(targetTag).transform;
        curHealth = maxHealth;
        resourceChance = Random.Range(1, 6);
        destroyTurret = GameObject.FindGameObjectWithTag("Turret");
        boostResource = GameObject.FindGameObjectWithTag("ResourceManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(curHealth <= 0)
        {
            if (resourceChance == 1 && canDrop)
            {
                Instantiate(resourceDrop, transform.position, Quaternion.identity);
                if (turretDestroySound != null)
        {
            turretDestroySounds.PlayOneShot(turretDestroySound);
        }
                canDrop = false;
            }
            Destroy(destroyTurret.gameObject);
            ResourceManager.Instance.AddResource(1);
            Destroy(gameObject);
        }
        if(follow && target != null)
        {
            myAgent.SetDestination(target.position);
            myAgent.updateRotation = false;
            if(myAgent.velocity.x < 0)
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
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
              if (enemyDBHitSound != null)
        {
            enemyDBSounds.PlayOneShot(enemyDBHitSound);
        }
            curHealth -= other.GetComponent<BulletId>().dmg;
            Destroy(other.gameObject);
        }
    }
}
