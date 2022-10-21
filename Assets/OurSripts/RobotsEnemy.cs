using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[ExecuteInEditMode]

public class RobotsEnemy : MonoBehaviour
{
    private float timer;
    public int counter=0;
    public GameObject Player;
    public GameObject Gun;
    public GameObject Player1;
    public GameObject Enemy;
    public Transform Enemy1;
    public AudioClip BunditFire;
    public GameObject Panel;

    NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        Panel.SetActive(false);
        Gun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Health_Player>().Health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            
            Player1.GetComponent<WeaponCamera>().Gun.SetActive(false);
            Player1.GetComponent<CameraOut>().Camera.GetComponent<End3>().enabled = true;
            Player1.GetComponent<CameraOut>().Camera.GetComponent<End>().enabled = false;
            GetComponent<AudioSource>().Stop();
            Gun.SetActive(false);
            Panel.SetActive(false);
            agent.Resume();
        }
        if (Enemy.GetComponent<EnemyHealth>().Health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("move", false);
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            gameObject.GetComponent<Animator>().SetBool("Damage", false);
            GetComponent<AudioSource>().Stop();
            Collider col = GetComponent<Collider>();
            col.GetComponent<Collider>();
            gameObject.GetComponent<npcIndividual>().enabled = false;
            gameObject.GetComponent<Animator>().SetBool("Die", true);
            col.enabled = false;
            Panel.SetActive(false);
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Gun")
        {
            counter = 1;
            Gun.SetActive(true);
            agent = GetComponent<NavMeshAgent>();
            Panel.SetActive(true);
            gameObject.GetComponent<Animator>().SetBool("move", false);
            agent.Stop();
            gameObject.GetComponent<Animator>().SetBool("Fire", true);
            transform.LookAt(Player.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            onFire();

        }
    }
  
    void OnTriggerExit(Collider col)
    {
        if ( col.tag== "Gun")
        {
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            agent.Resume();
            gameObject.GetComponent<Animator>().SetBool("move", true);
            Gun.SetActive(false);
            Panel.SetActive(false);

        }
    }
    void onFire()
    {
        timer += 1 * Time.deltaTime;
       
        if (timer >= 1.2f)
        {
            Player.GetComponent<Health_Player>().Health -= 5;
            timer = 0;
            GetComponent<AudioSource>().PlayOneShot(BunditFire);
           
        }
        
    }
}