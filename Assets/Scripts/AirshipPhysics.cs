using System;
using UnityEngine;

[ExecuteInEditMode]
public class AirshipPhysics : MonoBehaviour
{
    [Header("Airship params")]
    public int volume = 7;
    public MeshCollider envelope;
    public float mass = 3.5f;
    public Vector3 centerOfVolume;
    public Vector3 centerOfMass;
    //Points
    private Vector3 _globalCenterOfVolume;
    private Vector3 _globalCenterOfMass;
    //Forces
    private Vector3 _liftForce;
    private Vector3 _weight;
    
    [Header("Physic constant")]
    public float gravity = 9.81f;
    public float heliumMass = 0.178f; // (en g/L)
    public float airMass = 1.29f; // (en kg/m3)
    
    private Vector3 _finalForce;
    private Rigidbody _rig;
    // Start is called before the first frame update
    void Start()
    {
        _rig = gameObject.GetComponent<Rigidbody>();
        //Apply lift force
        Vector3 weightForce = new Vector3(0, -weight * Settings.Gravity, 0);

        Vector3 finalForce = weightForce;
        _finalForce = finalForce;
        
        _rig.centerOfMass = new Vector3(0, -0.4f, 0);
    }

    private void Update()
    {
        _globalCenterOfVolume = transform.TransformPoint(centerOfVolume);
        _globalCenterOfMass = transform.TransformPoint(centerOfMass);
        
        _liftForce = new Vector3(0, -(heliumMass - airMass) * volume * gravity, 0);
    }
    
    void OnDrawGizmosSelected()
    {
        const float forceDrawingCoeff = 0.02f;
        //Draw center of volume
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_globalCenterOfVolume, 0.05f);
        //Draw simulate lift force
        Gizmos.DrawLine(_globalCenterOfVolume, _globalCenterOfVolume + _liftForce*forceDrawingCoeff);
        
        //Draw center of mass
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_globalCenterOfMass, 0.05f);
        //Draw simulate lift force
        Gizmos.DrawLine(_globalCenterOfMass, _globalCenterOfMass - new Vector3(0, _rig.mass*gravity*forceDrawingCoeff, 0));
        
    }

    private void FixedUpdate()
    {
        _rig.centerOfMass = centerOfMass;
        
        _rig.AddForceAtPosition(_liftForce, _globalCenterOfVolume);

        Vector3 localVelocity = transform.InverseTransformVector(_rig.velocity);
        Debug.Log(localVelocity);
        Vector3 airDrag = new Vector3(-Mathf.Sign(localVelocity.x)*Mathf.Pow(localVelocity.x, 2) * 9 * 0.5f, -Mathf.Sign(localVelocity.y)*Mathf.Pow(localVelocity.y, 2) * 9 *0.5f,-Mathf.Sign(localVelocity.z)*Mathf.Pow(localVelocity.z, 2) * 7 * 0.2f) * airMass/2;
        
        //calculate airResistance
        _rig.AddForce(transform.TransformVector(airDrag));
    }
}
