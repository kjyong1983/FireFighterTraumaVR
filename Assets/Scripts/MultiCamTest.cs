//https://stackoverflow.com/questions/39618597/unity3d-displaying-different-scenes-on-multiple-monitors
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCamTest : MonoBehaviour {

    public Camera[] cams;
    void Start()
    {
        //Call function when new display is connected
        Display.onDisplaysUpdated += OnDisplaysUpdated;

        //Map each Camera to a Display
        mapCameraToDisplay();
    }

    void mapCameraToDisplay()
    {
        //Loop over Connected Displays
        //for (int i = 0; i < Display.displays.Length; i++)
        //{
        //    cams[i].targetDisplay = i; //Set the Display in which to render the camera to
        //    Display.displays[i].Activate(); //Enable the display
        //}

        cams[0].targetDisplay = 0;
        cams[1].targetDisplay = 1;

        //Valve.VR.IVRSystem.

    }

    void OnDisplaysUpdated()
    {
        Debug.Log("New Display Connected. Show Display Option Menu....");
    }

}
