using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHandModel : MonoBehaviour {

    public GameObject rightHand;
    public GameObject leftHand;

    public GameObject[] hands;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

        if (other.gameObject == rightHand)
        {
            rightHand = hands[1];
        }

        if (other.gameObject == leftHand)
        {
            leftHand = hands[1];
        }
    }
}
