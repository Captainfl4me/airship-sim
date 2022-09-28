using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class AirshipPhysics : MonoBehaviour
{
    public float weight = 1;

    public Transform motor1;
    public Transform motor2;
    public Transform motor3;
    public Transform motor4;

    public float motorMaxForce = 14;
    // Start is called before the first frame update
    void Start()
    {
        //Apply lift force
        Vector3 liftForce = new Vector3(0, -gameObject.GetComponentInChildren<LiftGaz>().GETLiftForce(), 0);
        Vector3 weightForce = new Vector3(0, -weight * 9.81f, 0);

        Vector3 finalForce = liftForce + weightForce;
        gameObject.GetComponent<Rigidbody>().AddForce(finalForce);
        
        Debug.Log(finalForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
