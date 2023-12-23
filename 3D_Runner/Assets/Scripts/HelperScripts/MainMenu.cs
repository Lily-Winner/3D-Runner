using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator anim;
    private int recordScore;
    [SerializeField] public TMP_Text record_score;

    //Display recording score in start of this scene
    private void Start()
    {
        recordScore = PlayerPrefs.GetInt("MyKey");
        record_score.text = recordScore.ToString();
    }

    public void PlayGame()
    {
        anim.Play("CameraSlider");

        GameObject myMusic = GameObject.FindGameObjectWithTag("Music");
        Destroy(myMusic);
    }

    public void OpenMap()
    {
        SceneManager.LoadScene("MapMenu");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
