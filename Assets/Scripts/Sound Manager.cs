using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;  // references the UI slider 

    //  called before the first frame update
    void Start()
    {
        
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
    
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();  // load the saved volume setting
        }
        else
        {
            // if a saved volume exists, simply load it
            Load();
        }
    }

    // called when the user changes the volume slider
    public void ChangeVolume()
    {
        // sets the AudioListener volume to the slider value
        AudioListener.volume = volumeSlider.value;
        Save();  // save the new volume setting
    }

    // loads the saved volume value from PlayerPrefs
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");  // set slider value to saved volume
    }

    // saves the current volume slider value to PlayerPrefs
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);  // store the slider value for future use
    }
}

