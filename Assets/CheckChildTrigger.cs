using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;

public class CheckChildTrigger : MonoBehaviour, IColliderEventHoverEnterHandler {

    public Transform playerCam;
    public Vector3 offset;

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        Debug.Log("OnColliderEventHoverEnter");
        Debug.Log(eventData.eventCaster.gameObject.name);

        //if (eventData.eventCaster.gameObject.tag == "Player")
        //{
        //    Debug.Log("Player");
        //}
        //if (eventData.eventCaster.gameObject.tag == "Hand")
        //{
        //    Debug.Log("Hand");
        //}

        transform.position = playerCam.position + offset;
        transform.parent = playerCam;

    }
}
