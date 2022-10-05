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
        float largeGas = Input.GetAxis("LargeGas") * 0.9f;

        float gas = smallGas + largeGas;
        motor1.SetThrottle(gas);
        motor2.SetThrottle(gas);
        motor3.SetThrottle(gas);
        motor4.SetThrottle(gas);        
    }
}
