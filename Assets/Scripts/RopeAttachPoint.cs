using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeAttachPoint : MonoBehaviour
{
    public bool isRigidbodyOnOtherObject = false;

    public Rigidbody OtherRigidbody;

    private Rigidbody _rig;
    private void Start()
    {
        if (isRigidbodyOnOtherObject)
            _rig = OtherRigidbody;
        else
            _rig = gameObject.GetComponent<Rigidbody>();
    }

    public void ApplyRopeForce(Vector3 force)
    {
        _rig.AddForceAtPosition(force, transform.position);
    }
}
