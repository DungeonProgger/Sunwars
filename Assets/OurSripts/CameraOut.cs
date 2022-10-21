using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOut : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera.GetComponent<End3>().enabled = true;
        Camera.GetComponent<End>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Camera.GetComponent<End>().enabled = true;
            Camera.GetComponent<End3>().enabled = false;
        }
        if (Input.GetKey(KeyCode.X))
        {
            Camera.GetComponent<End3>().enabled = true;
            Camera.GetComponent<End>().enabled = false;
        }
    }
}
