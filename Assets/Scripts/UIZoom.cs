using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIZoom : MonoBehaviour, IScrollHandler {

    public RectTransform rectTransform;

    public void OnScroll(PointerEventData eventData)
    {
        if (eventData.scrollDelta != Vector2.zero)
        {
            //Debug.Log(eventData.scrollDelta);
            if (eventData.scrollDelta.y > 0)
            {
                rectTransform.localScale *= 1.1f;
            }
            else if (eventData.scrollDelta.y < 0)
            {
                rectTransform.localScale *= 0.9f;
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
