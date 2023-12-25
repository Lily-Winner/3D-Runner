using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScreen : MonoBehaviour
{
    private Animator cuisinesAnim;
    

    void Start()
    {
        cuisinesAnim = GameObject.Find("Logo").GetComponent<Animator>(); 
        cuisinesAnim.Play("|LogoAnimation");
        
        Invoke("LoadGame", 3f);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("MainMenu2");
    }
}

