using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{

public Color hoverColor;
public Vector3 positionOffset;

private GameObject turret;

private Renderer rend;
private Color startColor;
public GameObject resource;

public GameObject turretButtons;

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

    if (resource.GetComponent<ResourceManager>().Count <= 0)
        {
            Debug.Log("Not enough resources!");
            return;
         }

ResourceManager.Instance.AddResource(-1);
    turretButtons.SetActive(true);
 //   GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
 //   turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
}

public void BuildFastTurret()
    {
        GameObject turretToBuild1 = BuildManager.instance.GetTurretToBuild1();
        turret = (GameObject)Instantiate(turretToBuild1, transform.position + positionOffset, transform.rotation);
    turretButtons.SetActive(false);
    }

    public void BuildStrongTurret()
    {
        GameObject turretToBuild2 = BuildManager.instance.GetTurretToBuild2();
        turret = (GameObject)Instantiate(turretToBuild2, transform.position + positionOffset, transform.rotation);
    turretButtons.SetActive(false);
    }

    public void BuildHealTurret()
    {
        GameObject turretToBuild3 = BuildManager.instance.GetTurretToBuild3();
        turret = (GameObject)Instantiate(turretToBuild3, transform.position + positionOffset, transform.rotation);
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
