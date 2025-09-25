using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    //TARGET
    public GameObject target;
    public string targetTag = "Enemy";
    public float maxRange = 10f;
    public float followSpeed = 1.0f;
    public Vector3 targetOffset;
    public bool targetAcquired = false;
    public bool onTarget;
    public LayerMask targetLayer;
    //BULLET
    public Rigidbody bulletPrefab;
    public Transform bulletSpawn;
    public float shootDelay = 0.02f;
    public float velocityMult = 100f;
    //AUDIO
    public AudioSource gunSounds;
    public AudioClip shootSound;
    //SHELLS
    public bool ejectShells;
    public Rigidbody shellPrefab;
    public Transform shellSpawn;
    public float shellVelocityMult = 0.5f;
    //FLASH
    public bool toggleFlash;
    public Light muzzleFlash;
    public GameObject[] objsInRange;
    //OTHER
    private RaycastHit hit;
    private bool isShooting;
    private float cooldown;
    private GameObject playerObj;
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
       /* Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();
        Vector3 farPoint = transform.position + forward * 100f;
        Vector3 dirToTarget = farPoint - bulletSpawn.position;
        Quaternion newRot = Quaternion.LookRotation(dirToTarget);*/
        //transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * gunDampening);
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
        Vector3 fwd = bulletSpawn.TransformDirection(Vector3.forward);
        Debug.DrawRay(bulletSpawn.position, fwd * maxRange, Color.red);
        if (Physics.Raycast(bulletSpawn.position, fwd, out hit, maxRange, targetLayer) && hit.transform.CompareTag(targetTag) && !isShooting)
        {
            StartCoroutine("shoot");
            onTarget = true;
        }
    }
    IEnumerator shoot()
    {
        isShooting = true;
        cooldown = shootDelay;
        Rigidbody bullet;
        Rigidbody shell;
        Vector3 spawnPos = bulletSpawn.position;
        bullet = Instantiate(bulletPrefab, spawnPos, bulletSpawn.rotation);
        if (ejectShells)
        {
            Vector3 shellRot = Vector3.forward + new Vector3(Random.Range(0, 0.5f), Random.Range(0, 0.25f), 0);
            shell = Instantiate(shellPrefab, shellSpawn.position, shellSpawn.rotation);
            shell.linearVelocity = shellSpawn.TransformDirection(shellRot * shellVelocityMult);
        }
        if (playerObj && bullet.GetComponent<BulletId>())
            bullet.GetComponent<BulletId>().sender = playerObj;
        bullet.linearVelocity = bulletSpawn.TransformDirection(Vector3.forward * velocityMult);
        if (shootSound != null)
        {
            gunSounds.PlayOneShot(shootSound);
        }
        if (toggleFlash)
        {
            muzzleFlash.enabled = true;
            yield return new WaitForSeconds(0.01f);
            muzzleFlash.enabled = false;
        }
        yield return new WaitForSeconds(shootDelay);
        isShooting = false;
    }
}
