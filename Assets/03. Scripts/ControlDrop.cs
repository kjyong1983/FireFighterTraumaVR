using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDrop : MonoBehaviour
{
    public AudioSource audio;

    public void ActivateObject()
    {
        GetComponent<DropEvent>().Drop();
        audio.Play();
    }
}