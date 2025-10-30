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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(targetTag).transform;
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(follow && target != null)
        {
            myAgent.SetDestination(target.position);
        }
        if(curHealth <= 0)
        {
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
