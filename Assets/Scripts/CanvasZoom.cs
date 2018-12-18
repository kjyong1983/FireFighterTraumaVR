using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CanvasZoom : MonoBehaviour,  IScrollHandler{
    public void OnScroll(PointerEventData eventData)
    {
        if (eventData.scrollDelta != Vector2.zero)
        {
            Debug.Log(eventData.scrollDelta);
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
