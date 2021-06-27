using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_2_controller : MonoBehaviour {

    public static int Enemy_count = 0;
    public float wait_time;
    public GameObject death_effect;
    public Sprite beaten_pig;
    public bool isKing;
    private float max_health;

    private bool isKilled=false;
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
    {//every time collision minus the health blood(4) and check it is die or not
        health = health - collision.relativeVelocity.magnitude;
        if (health <= max_health/2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = beaten_pig;
        }
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(dead, transform.position);//***

            if (isKilled == false)
            {
                Debug.Log(Enemy_count);
                isKilled = true;
                Enemy_count--;
                Instantiate(death_effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
        else if (collision.gameObject.tag == "border")
        {
            AudioSource.PlayClipAtPoint(dead, transform.position);//***
            if (isKilled == false)
            {
                isKilled = true;
                Enemy_count--;
                Destroy(gameObject);
                Instantiate(death_effect, transform.position, Quaternion.identity);
            }
        }
    }
}
