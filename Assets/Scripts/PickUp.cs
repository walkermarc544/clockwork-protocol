using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnMouseDown()
    {
        ResourceManager.Instance.AddResource(1);
        Destroy(gameObject);}

    


}
