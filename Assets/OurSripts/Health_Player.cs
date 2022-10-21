using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Player : MonoBehaviour
{
    public GameObject Panel;
    public int Health;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Health;
        if (Health <= 0)
        {
            Panel.SetActive(true);
            gameObject.GetComponent<Animator>().SetBool("Die", true);

        }

    }
}
