using System;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float maxThrustForce = 14;
    public float maxRPM = 2000f;
    public RotateAxis thrustAxis = RotateAxis.Y;

    [Header("Debug")] 
    public bool overrideThrottle = false;
    [Range(0, 100)]
    public float debugThrottle = 0;
    
    private Vector3 _thrustAxisVector;
    public Rigidbody parentRigidbody;
    private float _throttle = 0f;
    void Start()
    {
        //set rotation vector
        _thrustAxisVector = new Vector3(thrustAxis == RotateAxis.X ? 1: 0, thrustAxis == RotateAxis.Y ? 1: 0, thrustAxis == RotateAxis.Z ? 1: 0);
    }

    private void FixedUpdate()
    {
        if (overrideThrottle)
        {
            float force = debugThrottle / 100;
            SetThrottle(force);
        }
        
        parentRigidbody.AddForceAtPosition(transform.up*(maxThrustForce*_throttle), transform.position);
        transform.rotation *= Quaternion.Euler(_thrustAxisVector * (_throttle * (maxRPM*360/60) * Time.fixedDeltaTime));
    }

    public void SetThrottle(float force)
    {
        if (force < 0) force = 0;
        if (force > 1) force = 1;
        
        _throttle = force;
    }
}
