using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnOff : MonoBehaviour
{
    public ParticleSystem pat;
    private bool isOn = false;

    // Use this for initialization
    private void Start()
    {
        pat.Stop();
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetKeyDown("1"))
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (!isOn)
            {
                pat.Play();
                isOn = true;
            }
            else
            {
                pat.Stop();
                isOn = false;
            }
        }
    }
}