using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBin : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ActivateObject()
    {
        Debug.Log("ActivateObject");
        rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }

    public void DeactivateObject()
    {
    }
}