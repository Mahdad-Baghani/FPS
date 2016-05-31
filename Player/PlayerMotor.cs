//ANSLID - 5.30.2016
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private float _speed = 5f;
    public float Speed { get { return _speed; } set { _speed = value; } }

    [SerializeField]
    private Vector3 _velocity;
    public Vector3 Velocity { get { return _velocity; } set { _velocity = value; } }
    
    [SerializeField]
    private Vector3 _rotation;
    public Vector3 Rotation { get {return _rotation;} set {_rotation = value;} }


    private Rigidbody _rigidBuddy; //!!!!!!!!!
    #endregion

    #region Methods
    void Awake()
    {
        _rigidBuddy = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        MoveAndRotate();
    }


    public void MoveAndRotate()
    {
        // applying movement
        Velocity = PlayerController.Singleton.inputManager.CalculateVelocity();
        if (Velocity != Vector3.zero)
        {
            // MovePosition checks for collision while performing the transfer
            _rigidBuddy.MovePosition(_rigidBuddy.position + Velocity * Time.fixedDeltaTime);
        }

        // applying rotation
        Rotation = PlayerController.Singleton.inputManager.CalculateRotation();

        /* the rotation on the rigidbody is a quaternion already,
         * so we have to convert our Vector3 into a quaternion
         * this way we don't have to mess around with Quaternions, 
         * cause they are said to be tough for even mathematicians
         */
        _rigidBuddy.MoveRotation(_rigidBuddy.rotation * Quaternion.Euler(Rotation));


        PlayerController.Singleton.RotateCamera();

    }
    #endregion

}
