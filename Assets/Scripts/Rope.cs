using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class Rope : MonoBehaviour
{
    public RopeAttachPoint attachPoint;
    public RopeAttachPoint attachPoint2;

    [Header("Rope characteristics")] 
    public int ropeSubdivision = 10;

    public float spring = 1000f;
    public float length = 1f;
    public float ropeRadius = 0.2f;
    public float spaceBetweenBone = 0.1f;
    public float kCoeff = 50f;
    public float maxTensionForce = 800f;

    private RopeAttachPoint[] subAttachPoints;
    private RopeSubdivision[] subdivisions;

    private void Awake()
    {
        UpdateRope();
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    public void UpdateRope()
    {
        transform.position = attachPoint.transform.position;

        //Find all children
        int i = 0;
        GameObject[] allChildren = new GameObject[transform.childCount];
        foreach (Transform child in transform)
            allChildren[i++] = child.gameObject;

        //Clear all children
        foreach (GameObject child in allChildren)
            if(Application.isEditor)
                DestroyImmediate(child.gameObject);
            else
                Destroy(child.gameObject);

        float cylHeight = length / (ropeSubdivision+1);
        
        subAttachPoints = new RopeAttachPoint[ropeSubdivision];
        subdivisions = new RopeSubdivision[ropeSubdivision+1];
        for (i = 0; i < ropeSubdivision; i++)
        {
            GameObject attach = new GameObject();
            attach.name = "Attach " + i;
            attach.transform.parent = transform;
            attach.transform.localPosition = new Vector3(0, -(cylHeight) * (i + 1), 0);
            attach.transform.localScale = new Vector3(ropeRadius, cylHeight, ropeRadius);
            RopeAttachPoint attachComponent = attach.AddComponent<RopeAttachPoint>();
            attachComponent.mass = 0.01f;
            subAttachPoints[i] = attachComponent;

        }

        for (i = 0; i < ropeSubdivision + 1; i++)
        {

            GameObject ropeSub = new GameObject();
            ropeSub.name = "Rope " + i;
            ropeSub.transform.parent = transform;
            RopeSubdivision ropeSubComponent = ropeSub.AddComponent<RopeSubdivision>();
            ropeSubComponent.length = cylHeight;
            ropeSubComponent.kSpring = spring;
            
            if (i > 0)
                ropeSubComponent.attachPoint = subAttachPoints[i - 1];
            else
                ropeSubComponent.attachPoint = attachPoint;
            
            if (i < ropeSubdivision)
                ropeSubComponent.attachPoint2 = subAttachPoints[i];
            else
                ropeSubComponent.attachPoint2 = attachPoint2;
            subdivisions[i] = ropeSubComponent;
        }
/*
            HingeJoint hingeJoint = cyl.AddComponent<HingeJoint>();
            hingeJoint.breakForce = maxTensionForce;
            
            hingeJoint.useSpring = true;
            JointSpring localSpring = new JointSpring();
            localSpring.spring = spring;
            
            hingeJoint.spring = localSpring;
            
            if (i > 0)
                hingeJoint.connectedBody = cylinderList[i - 1].GetComponent<Rigidbody>();
            else
                hingeJoint.connectedBody = attachPoint.GetComponent<Rigidbody>();

        if (attachPoint2)
        {
            attachPoint2.createAttachRope(cylinderList[cylinderList.Length-1].GetComponent<Rigidbody>());
        }

        //setup joints
        //clear last attach joint1
        HingeJoint[] oldJoints = attachPoint.gameObject.GetComponents<HingeJoint>();
        foreach (HingeJoint joint in oldJoints)
            if(Application.isEditor)
                DestroyImmediate(joint);
            else
                Destroy(joint);
        //Add joint from attach point 1 to rope
        HingeJoint firstJoint = attachPoint.gameObject.AddComponent<HingeJoint>();
        //firstJoint.connectedBody = ropeRig;

        attachPoint.gameObject.GetComponent<Rigidbody>().isKinematic = true;*/
    }
}