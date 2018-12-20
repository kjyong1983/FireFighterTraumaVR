using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void OpenDoor()
    {
        anim.SetBool("OpenDoor", true);
    }

    public void CloseDoor()
    {
        anim.SetBool("OpenDoor", false);
    }
}
