using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTest : MonoBehaviour {

    public Camera mainDisplayCam;
    public LayerMask doNotRender;

	// Use this for initialization
	void Start () {
        mainDisplayCam.cullingMask = ~doNotRender;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
