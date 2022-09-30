using UnityEngine;

public class Motor : MonoBehaviour
{
    public float maxThrustForce = 14;
    public RotateAxis thrustAxis = RotateAxis.Y;
    
    private Vector3 _thrustAxisVector;
    public Rigidbody parentRigidbody;
    void Start()
    {
        //set rotation vector
        _thrustAxisVector = new Vector3(thrustAxis == RotateAxis.X ? 1: 0, thrustAxis == RotateAxis.Y ? 1: 0, thrustAxis == RotateAxis.Z ? 1: 0);
    }
    
    public void SetThrottle(float force)
    {
        if (force < 0) force = 0;
        if (force > 1) force = 1;
        
        parentRigidbody.AddForceAtPosition(transform.up*(maxThrustForce*force), transform.position, ForceMode.Impulse);
    }
}
