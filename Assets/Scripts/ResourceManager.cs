using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public int Count;
    public TextMeshProUGUI ResourceText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
       Count = 3;
        UpdateHUD();
    }

    public void AddResource(int amount)
    {
        Count += amount;
        UpdateHUD();
    }

    void UpdateHUD()
    {
        if (ResourceText != null)
            ResourceText.text = "Resources: " + Count;
    }
}