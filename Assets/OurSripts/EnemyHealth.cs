using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
[ExecuteInEditMode]

public class EnemyHealth : MonoBehaviour
{
    public int Health;
    public Slider slider;
    public Transform Enemy;
    public float timer;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        slider.value = Health;
        if (Health <= 0)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            /*timer += 1 * Time.deltaTime;
            if (timer == 2.2f)
            {
                Enemy.Translate(new Vector3(0.0f, -0.9f, 0.0f));
            }
            */
            gameObject.GetComponent<Animator>().SetBool("move", false);
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            gameObject.GetComponent<Animator>().SetBool("Damage", false);
            //gameObject.GetComponent<AI_Bandit>().enabled = false;            
            gameObject.GetComponent<Animator>().SetBool("Die", true);

        }
    }
}
