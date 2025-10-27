using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    public GameObject[] turretPrefabs;
    public GameObject[] obstaclePrefabs;
    public Tile spawnTile;
    public Vector3 positionOffset;
    public GameObject TurretUI;
    public GameObject ObstacleUI;
    public AudioSource buildSounds;
    public AudioClip destroySound;
    public bool canBuild = true;

    public GameObject resource;

    void Start()
    {
        resource = GameObject.FindGameObjectWithTag("ResourceManager");
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
    public void BuildTurret(int turretIndex)
    {
        GameObject[] turrets = turretPrefabs;
        if (turretIndex == 0)
        {
            if (resource.GetComponent<ResourceManager>().Count < 2)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-2);
        }
        if (turretIndex == 1)
        {
            if (resource.GetComponent<ResourceManager>().Count < 4)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-4);
        }
        if (turretIndex == 2)
        {
            if (resource.GetComponent<ResourceManager>().Count < 6)
        {
            return;
        }
        ResourceManager.Instance.AddResource(-6);
        }
        spawnTile.buildPrefab = Instantiate(turrets[turretIndex], spawnTile.transform.position + positionOffset, spawnTile.transform.rotation);
        Back();
    }
    public void BuildObstacle(int obstacleIndex)
    {
        GameObject[] obstacles = obstaclePrefabs;
        ResourceManager.Instance.AddResource(-2);
        spawnTile.buildPrefab = Instantiate(obstacles[obstacleIndex], spawnTile.transform.position + positionOffset, spawnTile.transform.rotation);
        Back();
    }
    public void Back()
    {
        spawnTile.buildButtons.SetActive(false);
        canBuild = true;
    }
}
