//ANSLID - 5.30.2016
using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(PlayerMotor))]
[RequireComponent (typeof(InputManager))]
[RequireComponent (typeof(Camera))]
public class PlayerController : MonoBehaviour 
{
    #region Fields

    public static PlayerController Singleton { get; private set; }
    public PlayerMotor Motor { get; private set; }
    public InputManager inputManager { get; private set; } 

    public Camera Cam;
    public Vector3 cameraRotaion;

    #endregion

    #region Methods
    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        Motor = GetComponent<PlayerMotor>();
        inputManager = GetComponent<InputManager>();
        Cam = GetComponent<Camera>();
    }

    public void RotateCamera()
    {
        cameraRotaion = inputManager.CalculateCameraRotation();
        Cam.transform.Rotate(cameraRotaion);
    }
    #endregion
    
}
