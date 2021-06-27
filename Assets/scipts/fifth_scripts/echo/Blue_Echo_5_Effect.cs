using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Echo_5_Effect : MonoBehaviour {
    private float timeBtwSpawns = 0;
    public float startTimeBtwSpawns;

    public GameObject echo;
    public blue_bird_5_control ba;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ba.isReleased == true && ba.isCollied == false)
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject ob = Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(ob, 5f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
