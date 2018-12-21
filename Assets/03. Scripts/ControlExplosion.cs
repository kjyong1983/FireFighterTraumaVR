using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlExplosion : MonoBehaviour
{
    public  CameraShake shake;

    public void ActivateObject()
    {
        GetComponent<ExplosiveTest>().Explosion();
        shake.ShakeCamera(1f, 1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            shake.ShakeCamera(1f, 1f);
        }
    }
}