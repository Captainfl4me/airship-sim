using System;
using UnityEngine;
using GD.MinMaxSlider;


public class Servo : MonoBehaviour
{
    public RotateAxis rotateAxis = RotateAxis.X;
    [MinMaxSlider(-180, 180)]
    public Vector2 rotationLimit = new Vector2(-80, 80);

    private Vector3 _rotateAxisVector;
    private Vector3 _fixedAxisVector;
    
    // Start is called before the first frame update
    void Start()
    {
        //set rotation vector
        _rotateAxisVector = new Vector3(rotateAxis == RotateAxis.X ? 1: 0, rotateAxis == RotateAxis.Y ? 1: 0, rotateAxis == RotateAxis.Z ? 1: 0);
    }

    public void RotateServo(float angle)
    {
        if (angle < rotationLimit.x) angle = rotationLimit.x;
        if (angle > rotationLimit.y) angle = rotationLimit.y;
        
        transform.localEulerAngles = _rotateAxisVector * angle;
    }
}
