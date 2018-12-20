using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSmoke : MonoBehaviour
{
    public GameObject[] smokes;

    public void ActivateObject()
    {
        Debug.Log("ActivateObject");
        for (int i = 0; i < smokes.Length; i++)
        {
            smokes[i].SetActive(true);
        }
    }
}