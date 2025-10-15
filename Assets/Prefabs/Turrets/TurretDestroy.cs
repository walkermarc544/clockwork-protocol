using UnityEngine;

public class TurretDestroy : MonoBehaviour
{

    public GameObject resource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resource = GameObject.FindGameObjectWithTag("ResourceManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown ()
{
    ResourceManager.Instance.AddResource(1);
    Debug.Log("Turret down!");
    Destroy(gameObject);
}
}
