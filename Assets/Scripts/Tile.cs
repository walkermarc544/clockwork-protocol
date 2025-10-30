using UnityEngine;
using TMPro;
using UnityEngine.UI;
public enum build { Turret, Obstacle }
public class Tile : MonoBehaviour
{
    public BuildManager buildManager;
    public Color hoverColor;

    public GameObject buildPrefab;

    private Renderer rend;
    private Color startColor;
    public GameObject resource;

    public GameObject buildButtons;
    private bool toggleUI;
    public build buildType;
    public bool tileTaken = false;


    private GameObject[] tiles;



    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        resource = GameObject.FindGameObjectWithTag("ResourceManager");
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        if (buildType == build.Turret)
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

    void OnMouseDown()
    {
        if (buildManager.canBuild)
        {
            if (buildPrefab == null && resource.GetComponent<ResourceManager>().Count > 1)//Build Prefab
            {
                buildManager.spawnTile = this.GetComponent<Tile>();
                buildButtons.SetActive(true);
                buildManager.canBuild = false;
            }
            else if (buildPrefab != null)//Destroy Prefab
            {
                if (buildManager.destroySound != null)
                {
                    buildManager.buildSounds.PlayOneShot(buildManager.destroySound);
                }
                ResourceManager.Instance.AddResource(1);
                Debug.Log("Turret down!");
                Destroy(buildPrefab);
            }



        }

        //   GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        //   turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMouseEnter()
    {

        rend.material.color = hoverColor;

    }

    void OnMouseExit()
    {

        rend.material.color = startColor;

    }

}
