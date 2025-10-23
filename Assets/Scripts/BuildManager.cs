using UnityEngine;

public class BuildManager : MonoBehaviour
{

public static BuildManager instance;
    public Transform spawn;
    public GameObject TurretUI;
    public GameObject ObstacleUI;

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
    public GameObject[] obstaclePrefabs;
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
}
