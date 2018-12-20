using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour {

    public GameObject trackTarget;
    public Vector3 offset;
    public float smooth;

	// Use this for initialization
	void Start () {
        //디스플레이 
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //transform.position = trackTarget.transform.position + offset;

        Vector3 targetPosition = trackTarget.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smooth * Time.deltaTime);

    }
}
