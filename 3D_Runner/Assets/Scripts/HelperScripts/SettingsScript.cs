using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{

    private bool isVolumeOn = true;
    public GameObject []menuMusic;
    

    public void ToggleVolume()
    {
        isVolumeOn = !isVolumeOn;
        UpdateVolume();
        
    }

    private void UpdateVolume()
    {
        AudioListener.volume = isVolumeOn ? 1.0f : 0.0f;
    }

    public void SoundOn()
    {
        AudioListener.volume = 1.0f;    
    }

    public void SoundOff()
    {
        AudioListener.volume = 0.0f;
        isVolumeOn = !isVolumeOn;
    }

    public void MenuExit()
    {
        SceneManager.LoadScene("MainMenu2");
        UpdateVolume();
    }



}
