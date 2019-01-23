using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDisplayControl : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.

        for (int i = 0; i < Display.displays.Length; i++)
        {
            if (Display.displays[i] != null)
            {
                Debug.Log(Display.displays[i].ToString());
                Display.displays[i].Activate();
            }
        }

        // Check if additional displays are available and activate each.
        //if (Display.displays.Length > 1)
        //    Display.displays[1].Activate();
        //if (Display.displays.Length > 2)
        //    Display.displays[2].Activate();
    }
}