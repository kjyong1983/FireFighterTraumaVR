using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSelector : MonoBehaviour {

    public Camera mainDisplayCam;
    public LayerMask doNotRender;

	void Start () {
        mainDisplayCam.cullingMask = ~doNotRender;
	}
	
}
