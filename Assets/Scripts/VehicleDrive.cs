using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDrive : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontWheelRB;
    [SerializeField] private Rigidbody2D _backWheelRB;
    [SerializeField] private Rigidbody2D _caRb;
    [SerializeField] private float _speed=200000f;
    [SerializeField] private float _rotationspeed=400000f;


    private float moveInput;

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");    
    }

    private void FixedUpdate()
    {
        _frontWheelRB.AddTorque(-moveInput*_speed*Time.fixedDeltaTime);
        _backWheelRB.AddTorque(-moveInput*_speed*Time.fixedDeltaTime);
        _caRb.AddTorque(moveInput*_rotationspeed*Time.fixedDeltaTime);
    }
}
