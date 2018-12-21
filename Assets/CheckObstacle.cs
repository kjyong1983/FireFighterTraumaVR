using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObstacle : MonoBehaviour
{
    public SphereCollider sphere;
    public GameObject[] obstacles;
    public GameObject door;
    public Move[] people;

    public AudioSource doorSound;
    public bool isSoundPlayed = false;

    private void Update()
    {
        float distance1 = Vector3.Distance(obstacles[0].transform.position, transform.position);
        float distance2 = Vector3.Distance(obstacles[1].transform.position, transform.position);

        if (distance1 > sphere.radius * 1.5 && distance2 > sphere.radius * 1.5)
        {
            Invoke("SendOpenDoorMessage", 1f);
        }
    }

    void SendOpenDoorMessage()
    {
        door.SendMessage("OpenDoor");
        if (!isSoundPlayed)
        {
            doorSound.Play();
            isSoundPlayed = true;
        }

        for (int i = 0; i < people.Length; i++)
        {
            people[i].canExit = true;
        }
    }
}