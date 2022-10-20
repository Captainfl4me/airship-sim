using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class RopeAttachPoint : MonoBehaviour
{
    public bool overrideMass = false;
    public float mass = 0.01f;
    private Rigidbody _rig;
    private void Awake()
    {
        _rig = gameObject.GetComponent<Rigidbody>();
        if(overrideMass)
            _rig.mass = mass;
        _rig.useGravity = true;
    }

    public void createAttachRope(Rigidbody rope)
    {
        HingeJoint joint = gameObject.AddComponent<HingeJoint>();
        joint.connectedBody = rope;
    }
    
    public void applyForce(Vector3 force)
    {
        _rig.AddForce(force, ForceMode.Impulse);
    }
}
