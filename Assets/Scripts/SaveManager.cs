using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public TMP_InputField massInput;
    public Rigidbody massToUpdate;

    // Start is called before the first frame update
    void Start()
    {
        float mass = PlayerPrefs.GetFloat("mass", -1f);
        if(mass > 0) massToUpdate.mass = mass;
        massInput.text = massToUpdate.mass.ToString("G");
    }

    public void saveMass()
    {
        float mass = float.Parse(massInput.text);
        PlayerPrefs.SetFloat("mass", mass);
        if(mass > 0) massToUpdate.mass = mass;
        massInput.text = massToUpdate.mass.ToString("G");
    }
}
