using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball_3_controller : MonoBehaviour
{

    public Rigidbody2D rb;
    public Rigidbody2D hook;
    public TrailRenderer tr;
    public GameObject next_birds;
    public bool isReleased = false;
    public bool isPressed = false;
    public float released_time = 0.15f;
    public float max_distance = 2f;
    public bool isCollied = false;
    public AudioClip birdfly_sound;
    AudioSource audioSource;

    public LineRenderer linef;
    public LineRenderer lineb;

    private Ray leftCatapultToProjectile;
    private float circleRadius;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        tr.enabled = false;//do not see the trail at first until Release
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = birdfly_sound;
        audioSource.Stop();

        LineRendererSetup();
        circleRadius = 0.3f;
        leftCatapultToProjectile = new Ray(linef.transform.position, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == true)
        {//change the position of birds along with mouse
            Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mouse_pos, hook.position) > max_distance)//if mouse position is too far
                rb.position = hook.position + (mouse_pos - hook.position).normalized * max_distance;
            else
                rb.position = mouse_pos;
        }
        LineRendererUpdate();

    }
    void LineRendererSetup()
    {
        linef.enabled = true;
        lineb.enabled = true;
        linef.SetPosition(0, linef.transform.position);
        lineb.SetPosition(0, lineb.transform.position);
        linef.sortingLayerName = "Foreground";
        lineb.sortingLayerName = "Foreground";

        linef.sortingOrder = 3;
        lineb.sortingOrder = 1;
    }
    void LineRendererUpdate()
    {
        Vector2 catapultToProjectile = transform.position - linef.transform.position;
        leftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);

        linef.SetPosition(1, holdPoint);
        lineb.SetPosition(1, holdPoint);
    }
    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;//will not be influced by spring
        isReleased = true;
        Parameter_script.birds_counts--;
        StartCoroutine(Release());//release the birds for0.15 sec
        StartCoroutine(Delete());//delete it for 8 sec
        audioSource.clip = birdfly_sound;
        audioSource.Play();
    }
    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollied = true;
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(released_time);//wait for seconds
        GetComponent<SpringJoint2D>().enabled = false;//make the birds flay
        tr.enabled = true;

        this.enabled = false;
        yield return new WaitForSeconds(2f);
        if (next_birds != null)//if there are  other bird , make it active
            next_birds.SetActive(true);
        else
        {//there is no birds
            if (Enemy_controller.Enemy_count != 0)
            {//there are others enemy, load the game(scene 2)again
                Enemy_controller.Enemy_count = 0;
                Parameter_script.birds_counts = 3;
                SceneManager.LoadScene(4);
            }
        }

    }

    IEnumerator Delete()
    {//delete the birds for 8 sec
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
