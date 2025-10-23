using UnityEngine;
using TMPro;
using UnityEngine.UI;
public enum build { Turret, Obstacle }
public class Tile : MonoBehaviour
{
    public BuildManager buildManager;
    public Color hoverColor;
    public Vector3 positionOffset;
private GameObject buildPrefab;

private Renderer rend;
private Color startColor;
public GameObject resource;

private GameObject buildButtons;
    private bool toggleUI;
    public build buildType;
    public bool canBuild = true;
    private GameObject[] tiles;


void Start()
{
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    resource = GameObject.FindGameObjectWithTag("ResourceManager");
    rend = GetComponent<Renderer>();
    startColor = rend.material.color;
        if(buildType == build.Turret)
        {
            buildButtons = buildManager.TurretUI;
        }
        else if (buildType == build.Obstacle)
        {
            buildButtons = buildManager.ObstacleUI;
        }
        if (buildButtons != null)
        {
            buildButtons.SetActive(false);
        }

}

void OnMouseDown ()
{
    if (buildPrefab != null)
    {
        Debug.Log("Can't build there!");
        return;
    }

    if (resource.GetComponent<ResourceManager>().Count <= 1)
        {
            Debug.Log("Not enough resources!");
            return;
         }
    else if(canBuild)
        {
            buildManager.spawn = this.transform;
            buildButtons.SetActive(true);
            foreach (GameObject tile in tiles)
            {
                tile.GetComponent<Tile>().canBuild = false;
            }
        }

 //   GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
 //   turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
}

public void BuildTurret(int turretIndex)
    {
        Debug.Log(buildManager.turretPrefabs);
        GameObject[] turrets = buildManager.turretPrefabs;
        ResourceManager.Instance.AddResource(-2);
        buildPrefab = (GameObject)Instantiate(turrets[turretIndex], buildManager.spawn.position + positionOffset, buildManager.spawn.rotation);
        buildButtons.SetActive(false);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<Tile>().canBuild = true;
        }
    }
    public void BuildObstacle(int obstacleIndex)
    {
        Debug.Log(buildManager.turretPrefabs);
        GameObject[] obstacles = buildManager.obstaclePrefabs;
        ResourceManager.Instance.AddResource(-2);
        buildPrefab = (GameObject)Instantiate(obstacles[obstacleIndex], buildManager.spawn.position + positionOffset, buildManager.spawn.rotation);
        buildButtons.SetActive(false);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<Tile>().canBuild = true;
        }
    }
    public void Back()
    {
        buildButtons.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMouseEnter ()
    {

       rend.material.color = hoverColor;
  
    }

 void OnMouseExit ()
    {

       rend.material.color = startColor;
  
    }

}
