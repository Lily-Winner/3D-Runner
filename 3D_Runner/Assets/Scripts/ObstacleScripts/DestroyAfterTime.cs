using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    // Destroy all objects after ground movement ("GroundBlock" script)
    public float timer = 3f;

    private void Start()
    {
        Invoke("DeactivateGameObject", timer);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
