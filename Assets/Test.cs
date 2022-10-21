using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    private Dictionary<string, Collider> inTrigger;
    public GameObject Player;
    private float timer;
    private void Start()
    {
        inTrigger = new Dictionary<string, Collider>();
    }
    private void CheckForUseCase()
    {
        if (inTrigger.ContainsKey("Player") && inTrigger.ContainsKey("Gun"))
        {
            inTrigger["Player"].GetComponent<Animator>().SetBool("Fire", true);
            inTrigger["Gun"].GetComponent<Animator>().SetBool("Fire", true);
        }
    }

    private void OnTriggerEnter(Collider col)
    {

        inTrigger.Add(col.tag, col);
        
        CheckForUseCase();
        Player = col.gameObject;
        transform.LookAt(col.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        onFire();
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player" || col.tag == "Gun")
        {
            inTrigger["Player"].GetComponent<Animator>().SetBool("Fire", false);
            inTrigger["Gun"].GetComponent<Animator>().SetBool("Fire", false);
        }
        inTrigger.Remove(col.tag);
    }
    void onFire()
    {
        timer += 1 * Time.deltaTime;

        if (timer >= 1.2f)
        {
            Player.GetComponent<Health_Player>().Health -= 5;
            timer = 0;
            //GetComponent<AudioSource>().PlayOneShot(BunditFire);

        }

    }
}
