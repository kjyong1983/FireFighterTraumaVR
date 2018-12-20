using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class WaterHoseController : MonoBehaviour
{
    public GameObject hose;
    private ParticleOnOff waterController;
    public HandRole handRole;
    private ControllerButton button = ControllerButton.Trigger;

    private void Start()
    {
        waterController = hose.GetComponentInChildren<ParticleOnOff>();
    }

    // Update is called once per frame
    private void Update()
    {
        //if (ViveInput.GetPressDown(handRole, button) && hose.activeSelf)
        if (ViveInput.GetPress(handRole, button) && hose.activeSelf)
        {
            waterController.pat.Play();
        }
    }
}