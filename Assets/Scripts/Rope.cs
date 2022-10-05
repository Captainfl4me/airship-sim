using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class Rope : MonoBehaviour
{
    public Rigidbody attachPoint1;
    public Rigidbody attachPoint2;

    [Header("Rope characteristics")] 
    public int ropeSubdivision = 10;
    public float length = 1f;
    public float kCoeff = 50f;
    public float maxTensionForce = 800f;
    
    

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
        transform.position = (attachPoint1.transform.position + attachPoint2.transform.position) / 2;
        
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

        GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cyl.transform.parent = transform;
        cyl.transform.localPosition = Vector3.zero;
        cyl.transform.localScale = new Vector3(0.2f, length, 0.2f);
        cyl.transform.LookAt(attachPoint1.transform);
        cyl.transform.Rotate(90, 0, 0);
        
        //setup joints
        HingeJoint firstJoint = cyl.AddComponent<HingeJoint>();
        firstJoint.connectedBody = attachPoint1;

        //clear last attach joints
        HingeJoint[] oldJoints = attachPoint2.gameObject.GetComponents<HingeJoint>();
        foreach (HingeJoint joint in oldJoints)
            if(Application.isEditor)
                DestroyImmediate(joint);
            else
                Destroy(joint);
        
        HingeJoint secondJoint = attachPoint2.gameObject.AddComponent<HingeJoint>();
        secondJoint.connectedBody = cyl.GetComponent<Rigidbody>();
        
        //TO-do
        /*
         * Mettre joint sur les attach (+ script pour les attaches )
         * Ici gère uniquement les liens entre petits bouts de corde + longueur de corde
         */
         
    }
}