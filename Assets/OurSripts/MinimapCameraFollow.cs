using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
    public GameObject myPlayer;
   // public GameObject myPlayerCar;
    public float distance=100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myPlayer.transform.position + Vector3.up*distance;
        //transform.position = myPlayerCar.transform.position + Vector3.up * distance;
    }
}
