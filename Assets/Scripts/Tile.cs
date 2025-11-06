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

    private string myTag;


    void Start()
    {
        myTag = gameObject.tag;
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

         if (buildManager.modifyUI != null)
        {
            buildManager.modifyUI.SetActive(false);
        }

    }

    void OnMouseDown()
    {
        if (buildManager.canBuild)
        {
            buildManager.selectedTile = this.GetComponent<Tile>();
            if (buildPrefab == null && resource.GetComponent<ResourceManager>().Count > 1)//Build Prefab
            {    
                buildButtons.SetActive(true);
                buildManager.canBuild = false;
            }
            else if (buildPrefab != null)//Open Modify Menu
            {
                Debug.Log("UPGRADES");
                buildManager.modifyUI.SetActive(true);
                buildManager.canBuild = false;
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
