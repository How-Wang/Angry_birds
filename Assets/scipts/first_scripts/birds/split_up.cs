using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class split_up : MonoBehaviour
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
        rb.AddForce(rb.mass * new Vector2(700f, -50f), ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
