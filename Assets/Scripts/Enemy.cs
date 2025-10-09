using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public string targetTag;
    private NavMeshAgent myAgent;
    public bool follow;
    //HEALTH
    public int maxHealth = 100;
    public int curHealth = 100;
    public GameObject resourceDrop;
    int resourceChance;
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
        if(follow && target != null)
        {
            myAgent.SetDestination(target.position);
            myAgent.updateRotation = false;
        }
        if(curHealth <= 0)
        {
            if (resourceChance == 1)
            {
            Instantiate(resourceDrop, transform.position, Quaternion.identity);
            }
            resourceChance = Random.Range(1, 8);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            curHealth -= other.GetComponent<BulletId>().dmg;
            Destroy(other.gameObject);
        }
    }
}
