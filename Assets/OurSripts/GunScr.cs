using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScr : MonoBehaviour
{
    public Transform bullet;
    public int bulletForce = 100;
    public int Magaz = 7;
    public GameObject Pistol;
    public GameObject PistolLeft;
    public AudioClip Fire;
    public AudioClip Reload;
    public GameObject FireBole;

    // Start is called before the first frame update
    void Start()
    {
        FireBole.SetActive(false);
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & Magaz > 0)
        {
            FireBole.SetActive(true);
            Pistol.GetComponent<Animator>().SetTrigger("Shoot");
            Transform BulletInstance = (Transform)Instantiate(bullet, GameObject.Find("Spawn").transform.position, Quaternion.identity);
            BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
            Magaz = Magaz - 1;
            GetComponent<AudioSource>().PlayOneShot(Fire);
          
        }
        if(Input.GetKeyDown(KeyCode.T)){
            Magaz=7;
            GetComponent<AudioSource>().PlayOneShot(Reload);
            PistolLeft.GetComponent<Animator>().SetTrigger("Reload");
        }
        if (Input.GetMouseButtonUp(0))
        {
            FireBole.SetActive(false);
        }
    }
}
