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
    }

    public void RotateCamera()
    {
        Cam.transform.Rotate(inputManager.CalculateCameraRotation());
    }
    #endregion
    
}
