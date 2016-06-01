using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;


public class PlayerSetUp : NetworkBehaviour 
{
    [SerializeField]
    Behaviour[] _OnNetDisabledComps;
    Camera sceneCamera;

    private void InitializePlayer()
    {
        // Differentiates between local and online players
        if (!isLocalPlayer)
        {
            for (int i = 0; i < _OnNetDisabledComps.Length; i++)
            {
                _OnNetDisabledComps[i].enabled = false;                
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
