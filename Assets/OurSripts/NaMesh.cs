using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[ExecuteInEditMode]

public class NaMesh : MonoBehaviour
{
    public GameObject Player;
    private float timer;
    public Transform target;
    public GameObject Player1;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("Run", true);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {       
        agent.SetDestination(target.position);
        if (Player.GetComponent<Health_Player>().Health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Kick", false);
            gameObject.GetComponent<Animator>().SetBool("Run", false);
            Player1.GetComponent<WeaponCamera>().Gun.SetActive(false);
            Player1.GetComponent<CameraOut>().Camera.GetComponent<End3>().enabled = true;
            Player1.GetComponent<CameraOut>().Camera.GetComponent<End>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;


        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("Run", false);
            gameObject.GetComponent<Animator>().SetBool("Kick", true);
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            transform.LookAt(Player.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            onFire();

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("Run", true);
            gameObject.GetComponent<Animator>().SetBool("Kick", false);
            gameObject.GetComponent<NavMeshAgent>().enabled = true;

        }
    }
    void onFire()
    {
        timer += 1 * Time.deltaTime;

        if (timer >= 1.2f)
        {
            Player.GetComponent<Health_Player>().Health -= 30;
            timer = 0;
            

        }

    }
}
