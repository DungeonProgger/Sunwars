using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCamera : MonoBehaviour
{
    public GameObject Gun;
   
    // Start is called before the first frame update
    void Start()
    {
        Gun.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Gun.SetActive(true);
          
        }
        if (Input.GetKey(KeyCode.X))
        {
            Gun.SetActive(false);
            
        }

    }
}
