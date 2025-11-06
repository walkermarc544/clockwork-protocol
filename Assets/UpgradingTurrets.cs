using UnityEngine;

public class UpgradingTurrets : MonoBehaviour
{

    public Tile spawnTile;
    public GameObject resource;
    private AutoTurret selectedTurret;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resource = GameObject.FindGameObjectWithTag("ResourceManager");     
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedTurret != null)
        spawnTile = GameObject.FindGameObjectWithTag("ModifyTurret").GetComponent<Tile>();

    }

    public void UpgradeSpeed() 
    {
    if (resource.GetComponent<ResourceManager>().Count < 1)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-1);
    if (spawnTile.GetComponent<Tile>())
        {
            selectedTurret = spawnTile.buildPrefab.GetComponent<AutoTurret>();
        }
        if (selectedTurret.shootDelay >= 0.01f)
        {
            selectedTurret.shootDelay = 0.01f;
        }
Debug.Log("SPEED UPGRADE!");
spawnTile.tag = "Turret";
gameObject.SetActive(false);
Cancel();
    }

    void UpgradeDmg() {
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

    void Scrap() {

        ResourceManager.Instance.AddResource(1);
        Debug.Log("Turret down!");
        Destroy(spawnTile);
        gameObject.SetActive(false);
        Cancel();

    }

    void Cancel() 
    {
        gameObject.SetActive(false);
    }
}