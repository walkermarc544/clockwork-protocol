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
        ResourceManager.Instance.AddResource(-2);
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
