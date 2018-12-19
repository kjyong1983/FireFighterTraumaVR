using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class Test : MonoBehaviour {

    public GameObject testPrefab;
    public Material[] grabMats;
    
    public void OnCreatButtonClick()
    {
        Instantiate(testPrefab, transform.position, Quaternion.identity);
    }

    public void OnButton1Click()
    {
        Debug.Log("1");
    }
    public void OnButton2Click()
    {
        Debug.Log("2");
    }
    public void OnButton3Click()
    {
        Debug.Log("3");
    }
    public void OnButton4Click()
    {
        Debug.Log("4");
    }
    public void OnButton5Click()
    {
        Debug.Log("5");
    }
    public void OnButton6Click()
    {
        Debug.Log("6");
    }
    public void OnButton7Click()
    {
        Debug.Log("7");
    }

    public void AfterGrabbed()
    {
        Debug.Log("afterGrabb");
        //ViveInput.event
    }

    public void OnDrop()
    {
        Debug.Log("afterGrabb");
    }

}
