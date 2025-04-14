using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera cameraPlayer;
    public Camera cameraGlobal;

    void Start()
    {
        SetFollowView(); // Par défaut sur la caméra de suivi
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle entre les deux
            if (cameraPlayer.gameObject.activeSelf)
                SetOverviewView();
            else
                SetFollowView();
        }
    }

    void SetFollowView()
    {
        cameraPlayer.gameObject.SetActive(true);
        cameraGlobal.gameObject.SetActive(false);
    }

    void SetOverviewView()
    {
        cameraPlayer.gameObject.SetActive(false);
        cameraGlobal.gameObject.SetActive(true);
    }
}
