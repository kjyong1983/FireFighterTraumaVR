using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterControl : MonoBehaviour
{
    public GameObject[] controlObjects;

    public void OnControlObjectButtonClick(int num)
    {
        Debug.Log("OnControlObjectButtonClick " + num);
        controlObjects[num].SendMessage("ActivateObject");
    }
}