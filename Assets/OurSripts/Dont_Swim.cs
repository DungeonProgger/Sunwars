using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Swim : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            Player.GetComponent<Health_Player>().Health = 0;
            gameObject.GetComponent<Animator>().SetBool("Die", true);
            Player1.GetComponent<WeaponCamera>().Gun.SetActive(false);
            Player1.GetComponent<CameraOut>().Camera.GetComponent<End3>().enabled = true;
            Player1.GetComponent<CameraOut>().Camera.GetComponent<End>().enabled = false;
        }
    }
}
