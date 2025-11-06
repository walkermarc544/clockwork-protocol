using UnityEngine;

public class UpgradingTurrets : MonoBehaviour
{

    public Tile selectedTile;
    public GameObject resourceManager;
    public BuildManager buildManager;
    public AutoTurret selectedTurret;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = GameObject.FindGameObjectWithTag("ResourceManager");
    }
    void UpgradeSpeed()
    {
        selectedTurret = GameObject.FindGameObjectWithTag("Modify").GetComponent<AutoTurret>();
        if (selectedTurret != null)
        {
            selectedTurret.shootDelay = 0.001f;
        }
    }
    void Back()
    {
        buildManager.modifyUI.SetActive(false);
    }
}