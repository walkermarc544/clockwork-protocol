using UnityEngine;

public class HealTurretDestroy : MonoBehaviour
{
    public GameObject resource;
    public AudioSource turretDestroySounds;
    public AudioClip turretDestroySound;

    public GameObject upgradeButtons;
    public GameObject goalHealHits;
    private bool toggleUI;

    [SerializeField] GameObject autoTurret;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resource = GameObject.FindGameObjectWithTag("ResourceManager");
        upgradeButtons = GameObject.FindGameObjectWithTag("UpgradeButtons");
        goalHealHits = GameObject.FindGameObjectWithTag("Finish");
        if (upgradeButtons != null)
        {
            upgradeButtons.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

        if (upgradeButtons == null)
        {
            upgradeButtons.SetActive(true);
        }

    }

    public void UpgradeSpeed() {
if (resource.GetComponent<ResourceManager>().Count < 1)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-1);
if (autoTurret.GetComponent<AutoTurret1>().shootDelay > 0.01f) {
autoTurret.GetComponent<AutoTurret1>().shootDelay -= 0.01f;
    }
Debug.Log("SPEED UPGRADE!");
Cancel();

    }

    public void UpgradeDmg() {
if (resource.GetComponent<ResourceManager>().Count < 1)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-1);
if (goalHealHits.GetComponent<LoseCondition>().HealHitMeter > 5) {
goalHealHits.GetComponent<LoseCondition>().HealHitMeter -= 5;
}
Debug.Log("DAMAGE UPGRADE!");
Cancel();

    }

    public void Scrap() {

if (turretDestroySound != null)
        {
            turretDestroySounds.PlayOneShot(turretDestroySound);
        }
        ResourceManager.Instance.AddResource(1);
        Debug.Log("Turret down!");
        Destroy(gameObject);

    }

    public void Cancel() {

upgradeButtons.SetActive(false);

    }
}
