using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public int Count = 3;
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