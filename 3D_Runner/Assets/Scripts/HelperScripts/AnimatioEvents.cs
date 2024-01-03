using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatioEvents : MonoBehaviour
{
    private PlayerController playerController;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Player").
            GetComponent<PlayerController>();
    }

    // As condition of load scene in animation
    void CameraStartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ResetShooting()
    {
        playerController.canShoot = true;
        anim.Play("Idle");
    }
}
