using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoll : MonoBehaviour {

    public CameraShake shake;
    public Transform viveCameraRig;
    public Transform camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Roll");
            StartRollCamera();
            //shake.ShakeCamera(5, 3);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Restore");
            StartRestoreCamera();
            //shake.ShakeCamera(5, 3);
        }

    }

    void StartRollCamera()
    {
        StartCoroutine(RollCamera());
    }
    void StartRestoreCamera()
    {
        StartCoroutine(RestoreCamera());
    }

    IEnumerator RollCamera()
    {
        viveCameraRig.transform.position = camera.transform.position;
        camera.transform.position = viveCameraRig.transform.position;

        Quaternion targetRot = Quaternion.Euler(new Vector3(-90, 0, 0));

        while ( !Quaternion.Equals(viveCameraRig.transform.rotation , targetRot))
        {
            viveCameraRig.transform.rotation = Quaternion.Slerp(viveCameraRig.transform.rotation, targetRot, Time.deltaTime);
            yield return null;
        }

    }

    IEnumerator RestoreCamera()
    {
        Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, 0));

        while (!Quaternion.Equals(viveCameraRig.transform.rotation, targetRot))
        {
            viveCameraRig.transform.rotation = Quaternion.Slerp(viveCameraRig.transform.rotation, targetRot, Time.deltaTime);
            yield return null;
        }
    }
}
