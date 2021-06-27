using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg_controller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 0.5f;
    public GameObject explosion_effect;
    public float force;
    public float field_impact;
    public LayerMask LayerToHit;

    public AudioClip explosion_sound;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, field_impact, LayerToHit);
        foreach (Collider2D col in colliders)
        {
            Vector2 direction = col.transform.position - transform.position;
            col.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        GameObject explosion = Instantiate(explosion_effect, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosion_sound, transform.position);
        Destroy(explosion, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bird")
        {
            Explode();
            Destroy(gameObject);
        }
    }
}
