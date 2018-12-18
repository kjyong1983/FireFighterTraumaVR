using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceIdenfier : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
        var msg = SystemInfo.deviceModel + "\n" +
        SystemInfo.deviceType + "\n" +
        SystemInfo.deviceName + "\n" +
        SystemInfo.graphicsDeviceID + "\n" +
        SystemInfo.graphicsDeviceName + "\n" +
        SystemInfo.graphicsDeviceType + "\n" +
        SystemInfo.graphicsDeviceVendor + "\n" +
        SystemInfo.graphicsDeviceVendorID + "\n" +
        SystemInfo.graphicsDeviceVersion + "\n"
        ;

        //Valve.VR.CVRExtendedDisplay



        for (int i = 0; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
            //Debug.Log(Display.displays[i].);
        }



        Debug.Log(msg
        );
        text.text = msg;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
