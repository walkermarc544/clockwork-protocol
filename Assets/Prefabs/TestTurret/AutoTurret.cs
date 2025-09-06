using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public GameObject target;
    public string targetTag = "Infected";
    public float maxRange = 10f;
    public float followSpeed = 1.0f;
    public Vector3 targetOffset;
    public bool targetAcquired = false;
    public GunShoot gunShootScript;

    public GameObject[] objsInRange;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    public int findClosest(GameObject[] input)//Find Closest Object Within Array
    {
        int closest = 0;
        float winner = 1f;
        float dist = 0f;
        for (int i = 0; i < objsInRange.Length; i++)
        {
            dist = Vector3.Distance(transform.position, objsInRange[i].transform.position);
            if (objsInRange[i].name == gameObject.name)
            {
                Debug.Log(gameObject.name + " has skipped " + objsInRange[i].name);
                continue;
            }
            if (i == 0)
            {
                closest = i;
                winner = dist;
                //Debug.Log("i = " + i);
            }
            else if (dist < winner)
            {
                winner = dist;
                closest = i;
                //Debug.Log("THE WINNER IS: " + objsInRange[i].name);
            }
        }
        return closest;
    }
    // Update is called once per frame
    void Update()
    {
        objsInRange = GameObject.FindGameObjectsWithTag(targetTag);//Get All Players
        target = objsInRange[findClosest(objsInRange)];
        if (Vector3.Distance(transform.position, target.transform.position) <= maxRange)//Check if Object is Within Range
        {
            Vector3 targetPos = new Vector3(target.transform.position.x + targetOffset.x, target.transform.position.y + targetOffset.y, target.transform.position.z + targetOffset.z);
            Quaternion targetRot = Quaternion.LookRotation(targetPos - this.transform.position, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, followSpeed);
            targetAcquired = true;
        }
        else
        {
            targetAcquired = false;
        }
        Vector3 fwd = gunShootScript.bulletSpawn.TransformDirection(Vector3.forward);
        Debug.DrawRay(gunShootScript.bulletSpawn.position, fwd * maxRange, Color.red);
        if (Physics.Raycast(gunShootScript.bulletSpawn.position, fwd, out hit, maxRange) && hit.transform.CompareTag(targetTag))
        {
            gunShootScript.aiShoot = true;
        }
        else
        {
            gunShootScript.aiShoot = false;
        }
    }
}
