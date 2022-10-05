using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed = 100f;
    public RotateAxis thrustAxis = RotateAxis.Y;
    
    private Vector3 _thrustAxisVector;
    // Start is called before the first frame update
    void Start()
    {
        _thrustAxisVector = new Vector3(thrustAxis == RotateAxis.X ? 1: 0, thrustAxis == RotateAxis.Y ? 1: 0, thrustAxis == RotateAxis.Z ? 1: 0);
    }

    // Update is called once per frame
    void Update()
    {
        _thrustAxisVector = new Vector3(thrustAxis == RotateAxis.X ? 1: 0, thrustAxis == RotateAxis.Y ? 1: 0, thrustAxis == RotateAxis.Z ? 1: 0);
        
        transform.rotation *= Quaternion.Euler(_thrustAxisVector * ((speed *360/60) * Time.fixedDeltaTime));
    }
}
