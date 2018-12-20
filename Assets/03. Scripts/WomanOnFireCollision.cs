using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanOnFireCollision : MonoBehaviour {

    private Animator animWoman;
    public MoveWoman moveWoman;

    public GameObject door;

    private bool hashRun = false;

  
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
            Debug.Log("move woman");
            moveWoman.isRun = true;
            door.SendMessage("OpenDoor");
            
        }
    }

}
