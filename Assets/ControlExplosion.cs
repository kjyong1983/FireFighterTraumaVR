using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlExplosion : MonoBehaviour
{
    public void ActivateObject()
    {
        GetComponent<ExplosiveTest>().Explosion();
    }
}