//ANSLID - 5.30.2016
using UnityEngine;
using System.Collections;

public enum InvertMouseAxes
{
    yes = 1,
    no = -1
}
public class InputManager : MonoBehaviour
{    
    // use the method section to have access to all the good things you need
    #region fields
    float _xMove;
    float _zMove;
    float _xRotation;
    float _yRotation;

    [SerializeField]
    float _mouseSensitivity = 10f;
    [SerializeField]
    InvertMouseAxes _invertMous = InvertMouseAxes.no;

    Vector3 _moveHorizontal;
    Vector3 _moveVertical;
    Vector3 _rotationOnY_Player; // this deals with Player Rotation
    Vector3 _rotationOnX_Camera; // this one deals with camare rotation

    Vector3 _velocity;
    #endregion

    #region mehtods
    internal Vector3 CalculateVelocity ()
    {
        _xMove = Input.GetAxisRaw("Horizontal");
        _zMove = Input.GetAxisRaw("Vertical");
        _moveHorizontal = transform.right * _xMove;
        _moveVertical = transform.forward * _zMove; 

        _velocity = (_moveHorizontal + _moveVertical).normalized * PlayerController.Singleton.Motor.Speed;

        return _velocity;

    }
    internal Vector3 CalculateRotation()
    {
        // Issue #01 : Not sure what happens here, seems to be right but the rotation sounds off a little bit.
        _yRotation = Input.GetAxisRaw("Mouse X");
        _rotationOnY_Player = new Vector3(0f, _yRotation, 0f) * _mouseSensitivity;
        // Issue #01 fixed on class: PlayerController

        return _rotationOnY_Player;
    }

    internal Vector3 CalculateCameraRotation()
    {
        _xRotation = Input.GetAxisRaw("Mouse Y");
        _rotationOnX_Camera = new Vector3(_xRotation, 0f, 0f) * _mouseSensitivity * (int) InvertMouseAxes.no;

        return _rotationOnX_Camera;

    }
    #endregion
     
}
