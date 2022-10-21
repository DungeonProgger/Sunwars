using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCar : MonoBehaviour
{
    public Camera PlayerCam;
    public Camera CarCam;
    public GameObject ThePlayer;
    public GameObject ExitTrigger;
    public GameObject TheCar;
    public GameObject ExitPlace;
    public string Key;
    public string Controller;
    public string UserControl;

    void Update()
    {
        if (!Input.GetButtonDown(Key))
            return;

        CarCam.enabled = false;
        PlayerCam.enabled = true;
        ThePlayer.SetActive(true);
        ThePlayer.transform.position = new Vector3(ExitPlace.transform.position.x-1, ExitPlace.transform.position.y, ExitPlace.transform.position.z);
        ((MonoBehaviour)TheCar.GetComponent(Controller)).enabled = false;
        ((MonoBehaviour)TheCar.GetComponent(UserControl)).enabled = false;
        ExitTrigger.SetActive(false);
    }
}
