using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{

    public GameObject pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
pauseMenu.SetActive(true);
Time.timeScale = 0f;
    }

        public void RestartGame()
    {
Time.timeScale = 1.0f;
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
Time.timeScale = 1.0f;
    }

    public void UnpauseGame()
    {
pauseMenu.SetActive(false);
Time.timeScale = 1f;
    }

     public void ExitToMenu()
    {
        if(SceneManager.GetActiveScene().buildIndex - 2 >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        else
        {
            Debug.Log("SCENE NOT LOADED. SCENE INDEX OUT OF RANGE");
            return;
        }
    }
}
