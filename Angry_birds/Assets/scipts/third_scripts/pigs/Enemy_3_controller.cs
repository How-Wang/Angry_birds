using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3_controller : MonoBehaviour {

    public static int Enemy_count = 0;
    public float wait_time;
    public GameObject death_effect;
    public Sprite beaten_pig;
    public bool isKing;
    private float max_health;

    //private bool isKilled = false;
    private float health;

    public AudioClip dead; //***
    private void Start()
    {//if thre is a pig enemy ,+1
        if (isKing)
            max_health = 20;
        else
            max_health = 8;
        health = max_health;
        Enemy_count++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health = health - collision.relativeVelocity.magnitude;
        if (health <= max_health / 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = beaten_pig;
        }
        if (health <= 0)
        {//if it will die ,instantiate a death_effect
            AudioSource.PlayClipAtPoint(dead, transform.position);//***
            Destroy(gameObject);
            Instantiate(death_effect, transform.position, Quaternion.identity);
            Enemy_count--;
        }
        if (collision.gameObject.tag == "border")
        {
            AudioSource.PlayClipAtPoint(dead, transform.position);//***
            Enemy_count--;
            Destroy(gameObject);
            Instantiate(death_effect, transform.position, Quaternion.identity);
        }
    }
}
