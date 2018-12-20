using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPeople : MonoBehaviour
{
    public Move[] people;

    public void ActivateObject()
    {
        Debug.Log("ActivateObject");
        for (int i = 0; i < people.Length; i++)
        {
            people[i].canExit = true;
        }
    }
}