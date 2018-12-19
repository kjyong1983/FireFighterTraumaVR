using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject testPrefab;
    
    public void OnCreatButtonClick()
    {
        Instantiate(testPrefab, transform.position, Quaternion.identity);
    }

}
