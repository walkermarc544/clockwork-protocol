using UnityEngine;

public class TurretDestroy : MonoBehaviour
{

    public GameObject resource;
    public AudioSource turretDestroySounds;
    public AudioClip turretDestroySound;

    public GameObject upgradeButtons;
    public GameObject upgradingTurrets;
    private bool toggleUI;

    public GameObject spawnTile;
    public bool isUpgrading;
    public int boolNumber;

    [SerializeField] GameObject autoTurret;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resource = GameObject.FindGameObjectWithTag("ResourceManager");
        upgradeButtons = GameObject.FindGameObjectWithTag("UpgradeButtons");
        if (upgradeButtons != null)
        {
            upgradeButtons.SetActive(false);
        }

        isUpgrading = false;
        boolNumber = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boolNumber == 1) {
            isUpgrading = true;
        }
if (isUpgrading == true) {
    gameObject.tag = "UpgradingTurret";
}
if (isUpgrading == false) {
    gameObject.tag = "Untagged";
}
    }

    void OnMouseDown()
    {

upgradeButtons.GetComponent<UpgradingTurrets>().spawnTile = this.GetComponent<GameObject>();
Debug.Log("Tag Changed!");

        if (upgradeButtons == null)
        {

            upgradeButtons.SetActive(true);
            Debug.Log("BOOL NUMBER");
            gameObject.tag = "UpgradingTurret";
            isUpgrading = true;
            boolNumber += 1;
        }

    }

    public void UpgradeSpeed() {
if (resource.GetComponent<ResourceManager>().Count < 1)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-1);
if (spawnTile.GetComponent<AutoTurret>().shootDelay > 0.01f) {
spawnTile.GetComponent<AutoTurret>().shootDelay -= 0.01f;
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
spawnTile.GetComponent<AutoTurret>().turretDmg += 3;
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
        Cancel();
        Destroy(gameObject);

    }

    public void Cancel() {

upgradeButtons.SetActive(false);

    }
}
