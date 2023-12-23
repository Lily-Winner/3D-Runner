using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    public GameObject [] menuMusic;

    private void Awake()
    {
        menuMusic = GameObject.FindGameObjectsWithTag("Music");

        if (menuMusic.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
