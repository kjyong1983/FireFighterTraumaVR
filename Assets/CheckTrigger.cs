using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour {

    public GameObject door;
    public AudioSource doorSound;
    public bool isSoundPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.SendMessage("OpenDoor");
            if (!isSoundPlayed)
            {
                doorSound.Play();
                isSoundPlayed = true;
            }
        }
    }
}
