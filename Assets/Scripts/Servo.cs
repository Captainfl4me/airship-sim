using System;
using UnityEngine;

[ExecuteInEditMode]
public class Servo : MonoBehaviour
{
    public RotateAxis rotateAxis = RotateAxis.X;
    public Vector2 rotationLimit = new Vector2(-80, 80);
    public float rotationOffset = 0f;
    
    private Vector3 _rotateAxisVector;
    private Vector3 _fixedAxisVector;
    
    // Start is called before the first frame update
    private void Awake()
    {
        //set rotation vector
        _rotateAxisVector = new Vector3(rotateAxis == RotateAxis.X ? 1: 0, rotateAxis == RotateAxis.Y ? 1: 0, rotateAxis == RotateAxis.Z ? 1: 0);
        _fixedAxisVector = Vector3.one - _rotateAxisVector;
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            _rotateAxisVector = new Vector3(rotateAxis == RotateAxis.X ? 1: 0, rotateAxis == RotateAxis.Y ? 1: 0, rotateAxis == RotateAxis.Z ? 1: 0);
            _fixedAxisVector = Vector3.one - _rotateAxisVector;
            transform.localEulerAngles = Vector3.Scale(_fixedAxisVector, transform.localEulerAngles) + _rotateAxisVector * rotationOffset;
        }
    }

    public void RotateServo(float angle)
    {
        if (angle < rotationLimit.x) angle = rotationLimit.x;
        if (angle > rotationLimit.y) angle = rotationLimit.y;
        
        transform.localEulerAngles = Vector3.Scale(_fixedAxisVector, transform.localEulerAngles) + _rotateAxisVector * (angle + rotationOffset);
    }
}
