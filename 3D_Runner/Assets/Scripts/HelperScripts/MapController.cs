using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public Animator anim;
    public AudioSource mySound;

    private void Start()
    {
        AudioListener.volume = 1.0f;
    }

    //Selection of location
    public void StartChoose()
    {
        anim.Play("CameraSlider");
        mySound.Play();
        GameObject myMusic = GameObject.FindGameObjectWithTag("Music");
        Destroy(myMusic);

    }

    public void MainMenuExit()
    {
        SceneManager.LoadScene("MainMenu2");
    }

    
    
}
