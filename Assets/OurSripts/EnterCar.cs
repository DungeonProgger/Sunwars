using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCar : MonoBehaviour
{
   
    public Camera PlayerCam;
    public Camera CarCam;
    public GameObject ThePlayer;
    public GameObject ExitTrigger;
    public GameObject TheCar;
    public string Key;
    public string Controller;
    public string UserControl;
    bool triggerCheck = true;
   


    private void OnTriggerEnter(Collider other)
    {
        System.Console.WriteLine("Trigger enter");
        //triggerCheck = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //triggerCheck = false;
    }

    void Update()
    {
        if (!triggerCheck || !Input.GetButtonDown(Key))
            return;
        
        CarCam.enabled = true;
        PlayerCam.enabled = false;
        ThePlayer.SetActive(false);
        ((MonoBehaviour) TheCar.GetComponent(Controller)).enabled = true;
        ((MonoBehaviour)TheCar.GetComponent(UserControl)).enabled = true;
        ExitTrigger.SetActive(true);        
    }
}
