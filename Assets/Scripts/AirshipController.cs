using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipController : MonoBehaviour
{
    public Servo servo1;
    public Servo servo2;
    public Servo servo3;
    public Servo servo4;
    
    public Motor motor1;
    public Motor motor2;
    public Motor motor3;
    public Motor motor4;

    // Update is called once per frame
    void Update()
    {
        float horizontal = -Input.GetAxis("Horizontal");
        float vertical = -Input.GetAxis("Vertical");

        servo1.RotateServo(vertical*80f - horizontal*80f);
        servo2.RotateServo(vertical*80f - horizontal*80f);
        servo3.RotateServo(vertical*80f + horizontal*80f);
        servo4.RotateServo(vertical*80f + horizontal*80f);

        float smallGas = Input.GetAxis("SmallGas") * 0.1f;
        
        motor1.SetThrottle(smallGas);
        motor2.SetThrottle(smallGas);
        motor3.SetThrottle(smallGas);
        motor4.SetThrottle(smallGas);        
    }
}
