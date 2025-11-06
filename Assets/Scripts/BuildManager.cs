using System.Resources;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    public GameObject[] turretPrefabs;
    public GameObject[] obstaclePrefabs;
    public Tile selectedTile;
    public Vector3 positionOffset;
    public GameObject TurretUI;
    public GameObject ObstacleUI;
    public GameObject modifyUI;//Referenced in Tile.cs
    public AudioSource buildSounds;
    public AudioClip destroySound;
    public bool canBuild = true;

    public GameObject resourceManager;

    void Start()
    {
        resourceManager = GameObject.FindGameObjectWithTag("ResourceManager");
    }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
        canBuild = true;
    }
    public void UpgradeSpeed()
    {
        if (selectedTile != null && resourceManager.GetComponent<ResourceManager>().Count >= 3)
        {
            AutoTurret selected = selectedTile.buildPrefab.GetComponentInChildren<AutoTurret>();
            selected.speedLevel++;
            ResourceManager.Instance.AddResource(-3);
            Back();
        }
    }
    public void BuildTurret(int turretIndex)
    {
        GameObject[] turrets = turretPrefabs;
        if (turretIndex == 0)
        {
            if (resourceManager.GetComponent<ResourceManager>().Count < 2)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-2);
        }
        if (turretIndex == 1)
        {
            if (resourceManager.GetComponent<ResourceManager>().Count < 4)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-4);
        }
        if (turretIndex == 2)
        {
            if (resourceManager.GetComponent<ResourceManager>().Count < 6)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-6);
        }
        selectedTile.buildPrefab = Instantiate(turrets[turretIndex], selectedTile.transform.position + positionOffset, selectedTile.transform.rotation);
        Back();
    }
    public void BuildObstacle(int obstacleIndex)
    {
        GameObject[] obstacles = obstaclePrefabs;
        ResourceManager.Instance.AddResource(-2);
        selectedTile.buildPrefab = Instantiate(obstacles[obstacleIndex], selectedTile.transform.position + positionOffset, selectedTile.transform.rotation);
        Back();
    }
    public void DestroyBuild()
    {
        Destroy(selectedTile.buildPrefab);
        ResourceManager.Instance.AddResource(1);
        Back();
    }
    public void Back()
    {
        if (selectedTile.buildButtons.activeSelf)
            selectedTile.buildButtons.SetActive(false);
        else if(modifyUI.activeSelf)
            modifyUI.SetActive(false);
        canBuild = true;
    }
}
