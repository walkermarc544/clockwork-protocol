using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public BuildManager buildManager;
    public Color hoverColor;
    public Vector3 positionOffset;
private GameObject turret;

private Renderer rend;
private Color startColor;
public GameObject resource;

public GameObject turretButtons;
    private bool toggleUI;

void Start()
{
    resource = GameObject.FindGameObjectWithTag("ResourceManager");
    rend = GetComponent<Renderer>();
    startColor = rend.material.color;

    if (turretButtons != null)
        {
            turretButtons.SetActive(false);
        }

}

void OnMouseDown ()
{
    if (turret != null)
    {
        Debug.Log("Can't build there!");
        return;
    }

    if (resource.GetComponent<ResourceManager>().Count <= 1)
        {
            Debug.Log("Not enough resources!");
            return;
         }
        buildManager.spawn = this.transform;
    turretButtons.SetActive(true);
ResourceManager.Instance.AddResource(-2);
 //   GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
 //   turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
}

public void BuildTurret(int turretIndex)
    {
        Debug.Log(buildManager.turretPrefabs);
        GameObject[] turrets = buildManager.turretPrefabs;
        turret = (GameObject)Instantiate(turrets[turretIndex], buildManager.spawn.position + positionOffset, buildManager.spawn.rotation);
        turretButtons.SetActive(false);
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
