using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
//[ExecuteInEditMode]

public class EnemyDamage : MonoBehaviour
{
    private float timer;
    public GameObject Enemy;
    //NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /*agent = Enemy.GetComponent<NavMeshAgent>();
        if(Enemy.GetComponent<RobotsEnemy>().counter == 1)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }
        */
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {
            Enemy.GetComponent<Animator>().SetBool("Fire", false);
            Enemy.GetComponent<Animator>().SetBool("Damage", true);
            if (Enemy.tag == "AI")
            {
                Enemy.GetComponent<EnemyHealth>().Health -= 7;
            }
            /*if (Enemy.tag == "AI1")
            {
                Enemy.GetComponent<EnemyHealth>().Health1 -= 7;
            }
            */

        }
    }
    /*void OnTriggerStay(Collider col)
    {
        if (col.tag == "Bullet")
        {
            Enemy.GetComponent<Animator>().SetBool("Fire", false);
            Enemy.GetComponent<Animator>().SetBool("Damage", true);
            if (Enemy.tag == "AI")
            {
                Enemy.GetComponent<EnemyHealth>().Health -= 7;
            }
            /*if (Enemy.tag == "AI1")
            {
                Enemy.GetComponent<EnemyHealth>().Health1 -= 7;
            }            
        }
    }
    */

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Bullet")
        {
            
            Enemy.GetComponent<Animator>().SetBool("Fire", true);
            Enemy.GetComponent<Animator>().SetBool("Damage", false);
        }
    }
    
}
