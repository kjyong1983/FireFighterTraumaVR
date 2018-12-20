using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEvent : MonoBehaviour {
    public Rigidbody[] DropRigid;
    public GameObject[] fireObj;
    public ParticleSystem[] fires;
	// Use this for initialization
	void Start () {
		
	}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Drop();
        }
    }
    void Drop()
    {
        for (int i = 0; i < DropRigid.Length; i++)
        {
            fireObj[i].SetActive(true);
            DropRigid[i].isKinematic = false;
            fires[i].Play();
        }
    }
}
