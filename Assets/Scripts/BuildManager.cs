using UnityEngine;

public class BuildManager : MonoBehaviour
{

public static BuildManager instance;
    public Transform spawn;

void Awake ()
{
    if (instance != null)
    {
        Debug.LogError("More than one BuildManager in scene");
        return;
    }
    instance = this;
}
    public GameObject[] turretPrefabs;
    /*
public GameObject standardTurretPrefab;
public GameObject strongTurretPrefab;
public GameObject healTurretPrefab;*/

void Start()
{/*
    turretToBuild1 = standardTurretPrefab;
    turretToBuild2 = strongTurretPrefab;
    turretToBuild3 = healTurretPrefab;
    */
}

    private GameObject turretToBuild1;
    private GameObject turretToBuild2;
    private GameObject turretToBuild3;

    public GameObject GetTurretToBuild1 ()
    {
        return turretToBuild1;
    }
    public GameObject GetTurretToBuild2 ()
    {
        return turretToBuild2;
    }
    public GameObject GetTurretToBuild3 ()
    {
        return turretToBuild3;
    }
}
