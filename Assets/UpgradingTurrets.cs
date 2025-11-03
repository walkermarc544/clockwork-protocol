using UnityEngine;

public class UpgradingTurrets : MonoBehaviour
{

    public GameObject spawnTile;
       public GameObject resource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                resource = GameObject.FindGameObjectWithTag("ResourceManager");
                
    }

    // Update is called once per frame
    void Update()
    {
        spawnTile = GameObject.FindGameObjectWithTag("UpgradingTurret");
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
spawnTile.tag = "Turret";
gameObject.SetActive(false);
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
gameObject.SetActive(false);
Cancel();

    }

    public void Scrap() {

        ResourceManager.Instance.AddResource(1);
        Debug.Log("Turret down!");
        Destroy(spawnTile);
        gameObject.SetActive(false);
        Cancel();

    }

    public void Cancel() {

gameObject.SetActive(false);

    }
}
