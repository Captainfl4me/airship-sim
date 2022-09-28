using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftGaz : MonoBehaviour
{
    public int volume = 7;
    public bool autoVolumeCalc = false;
    public float gravity = 9.81f;

    public float GETLiftForce()
    {
        //Constant
        float heliumMass = 0.178f; // (en g/L)
        float airMass = 1.29f; // (en kg/m3)
        
        return (heliumMass - airMass) * volume * gravity;
    }
}
