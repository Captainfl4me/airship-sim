using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RopeSubdivision : MonoBehaviour
{
    public float mass = 0.01f;
    public float kSpring = 100f;
    public float length = 1f;
    
    public RopeAttachPoint attachPoint;
    public RopeAttachPoint attachPoint2;
    
    private Rigidbody _rig;
        
    private void Awake()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(attachPoint && attachPoint2)
            transform.position = (attachPoint.transform.position + attachPoint2.transform.position)/2;
    }

    private void FixedUpdate()
    {
        Vector3 vectorAb = attachPoint2.transform.position - attachPoint.transform.position;
        float lengthBetweenPoints = vectorAb.magnitude;
        
        Vector3 forceToApply = vectorAb.normalized * (kSpring*(lengthBetweenPoints-length));

        attachPoint.applyForce(forceToApply);
        attachPoint2.applyForce(-forceToApply);
    }
}
