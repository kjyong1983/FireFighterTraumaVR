using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDrop : MonoBehaviour
{
    public void ActivateObject()
    {
        GetComponent<DropEvent>().Drop();
    }
}