﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanOnFireCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("sdfadf");
        }
    }

}
