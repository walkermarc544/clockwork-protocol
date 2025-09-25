using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour
{
    public GameObject playerObj;
    public bool canShoot = true;
    public Transform bulletSpawn;
    public Rigidbody bulletPrefab;
    public bool ejectShells = false;
    public Transform shellSpawn;
    public Rigidbody shellPrefab;
    public float shellVelocityMult;
    public AudioSource gunSounds;
    public AudioClip shootSound;
    public bool toggleFlash = true;
    public Light muzzleFlash;
    //public float gunDampening = 0.5f;
    public float velocityMultiplier;
    public float shootDelay;
    public bool autoFire;
    private bool isShooting = false;
    public bool altFire = false;
    public Component cooldownUI;
    public float cooldown;
    private float coolScaler;
    private Vector3 uiScale;
    private Vector3 defScale;
    [Header("Reticle Settings:")]
    public bool toggleReticle;
    public Transform reticlePrefab;
    public Transform reticle;
    public LayerMask reticleMask;
    private Vector3 reticlePosition;
    private byte retAlphaActive = 28;
    private byte retAlphaInactive = 7;
    public bool camGun = false;

    private RaycastHit hit;
    [Header("AI Controls:")]
    public bool aiShoot;
    public bool aiMode;
    // Start is called before the first frame update
    void Start()
    {
        if (toggleReticle)
        {
            reticle = Instantiate(reticlePrefab, GameObject.FindGameObjectWithTag("Gm_UI").transform);
        }
        defScale = transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();
        Vector3 farPoint = transform.position + forward * 100f;
        Vector3 dirToTarget = farPoint - bulletSpawn.position;
        Quaternion newRot = Quaternion.LookRotation(dirToTarget);
        //transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * gunDampening);
        if (aiMode)
        {
            if (aiShoot && !isShooting)
                StartCoroutine("shoot");
        }
        else
        {
            if (toggleReticle)
            {
                if (Physics.Raycast(bulletSpawn.transform.position, transform.forward, out hit, 50000, reticleMask))
                {
                    //Position reticle to hit position
                    Vector3 pos = Camera.main.WorldToScreenPoint(hit.point);
                    reticle.position = new Vector3(pos.x, pos.y, 0);
                    reticle.gameObject.SetActive(true);
                    if (hit.transform.gameObject.CompareTag("Target"))
                    {
                        reticle.GetComponent<Image>().color = new Color32(90, 0, 0, retAlphaActive);
                    }
                    else
                    {
                        reticle.GetComponent<Image>().color = new Color32(255, 255, 255, retAlphaActive);
                    }
                }
                else
                {
                    reticle.position = Camera.main.WorldToScreenPoint(bulletSpawn.transform.TransformPoint(Vector3.forward * 1000));
                    reticle.GetComponent<Image>().color = new Color32(255, 255, 255, retAlphaInactive);
                }

            }
            if (altFire)
            {
                if (!isShooting && canShoot && autoFire && (Input.GetMouseButton(1) || Input.GetKey(KeyCode.Keypad1)))
                {
                    StartCoroutine(nameof(shoot));
                }
                else if (!isShooting && canShoot && (Input.GetMouseButtonDown(1) || Input.GetKey(KeyCode.Keypad1)))
                {
                    StartCoroutine(nameof(shoot));
                }

                if (cooldownUI != null)
                {
                    uiScale = new Vector3(cooldownUI.transform.localScale.x, coolScaler, cooldownUI.transform.localScale.z);
                    cooldownUI.transform.localScale = uiScale;
                }
                else
                {
                    //GET COOLDOWN UI cooldownUI = GameObject.FindGameObjectWithTag("Cluster").GetComponent<Cluster>().cooldownUI;
                }
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime;
                    coolScaler = cooldown / shootDelay;
                }
                else if (cooldown != 0)
                {
                    coolScaler = 0;
                }

            }
            else
            {
                if (!Input.GetKey(KeyCode.Mouse2) && !camGun)
                {
                    if (!isShooting && canShoot && autoFire && (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Keypad0)) || !isShooting && canShoot && (Input.GetMouseButtonDown(0)))
                    {
                        StartCoroutine(nameof(shoot));
                    }
                }
                else if (Input.GetKey(KeyCode.Mouse2) && camGun)
                {
                    if (!isShooting && canShoot && autoFire && (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Keypad0)) || !isShooting && canShoot && (Input.GetMouseButtonDown(0)))
                    {
                        StartCoroutine(nameof(shoot));
                    }
                }
            }
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
        bullet.linearVelocity = bulletSpawn.TransformDirection(Vector3.forward * velocityMultiplier);
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
