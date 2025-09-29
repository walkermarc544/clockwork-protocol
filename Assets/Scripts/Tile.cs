using UnityEngine;

public class Tile : MonoBehaviour
{

public Color hoverColor;
public Vector3 positionOffset;

private GameObject turret;

private Renderer rend;
private Color startColor;
public GameObject resource;

void Start()
{
    resource = GameObject.FindGameObjectWithTag("ResourceManager");
    rend = GetComponent<Renderer>();
    startColor = rend.material.color;
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
    GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
    turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
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
