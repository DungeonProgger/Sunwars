using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Bandit : MonoBehaviour {
    private float timer;
    private float timer2;
    public GameObject Player;
    public GameObject Player1;
    public AudioClip BunditFire;
    public GameObject FireBole;
    public GameObject Panel;
    // Use this for initialization
    void Start() {
        FireBole.SetActive(false);
        Panel.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
       if(Player.GetComponent<Health_Player>().Health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            Player1.GetComponent<WeaponCamera>().Gun.SetActive(false);
            Player1.GetComponent<CameraOut>().Camera.GetComponent<End3>().enabled = true;
            Player1.GetComponent<CameraOut>().Camera.GetComponent<End>().enabled = false;
            GetComponent<AudioSource>().Stop();


        }
        if (gameObject.GetComponent<EnemyHealth>().Health <= 0)
        {
            GetComponent<AudioSource>().Stop();
            Collider col = GetComponent<Collider>();
            col.GetComponent<Collider>();
            col.enabled = false;
            Panel.SetActive(false);
        }
    }
	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player") {
			Player = col.gameObject;
            Panel.SetActive(true);
            gameObject.GetComponent<Animator> ().SetBool ("Fire", true);
			transform.LookAt (col.transform.position);
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
			onFire ();
           

        }
	}
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
            Panel.SetActive(false);
            gameObject.GetComponent<Animator> ().SetBool ("Fire", false);
            FireBole.SetActive(false);
        }
	}
	void onFire()
	{
		timer += 1 * Time.deltaTime;
        timer2 += 1 * Time.deltaTime;
        if (timer >= 1.2f)
        {
            Player.GetComponent<Health_Player>().Health -= 10;
            timer = 0;
            GetComponent<AudioSource>().PlayOneShot(BunditFire);
            FireBole.SetActive(true);
          
        }
            if (timer2 >= 1.2f)
            {
                FireBole.SetActive(false);
            }
    }
}

