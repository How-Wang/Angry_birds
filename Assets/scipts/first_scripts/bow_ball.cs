using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow_ball : MonoBehaviour {
    public Rigidbody2D rb;
    public Rigidbody2D Hook;

    public float releaseTime = .15f;
    public float maxDragDistance = 2f;

    private bool isPressed = false;

    public LineRenderer linef;
    public LineRenderer lineb;

    private Ray leftCatapultToProjectile;
    private float circleRadius;
	// Use this for initialization
	void Start () {
        LineRendererSetup();
        circleRadius = 0.3f;
        leftCatapultToProjectile = new Ray(linef.transform.position, Vector3.zero);
    }
	
	// Update is called once per frame
	void Update () {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, Hook.position) > maxDragDistance)
            {
                rb.position = Hook.position + (mousePos - Hook.position).normalized * maxDragDistance;
            }
            else {
                rb.position = mousePos;
            }
        }
        LineRendererUpdate();
	}
    void LineRendererSetup()
    {
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
        Vector3  holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);

        linef.SetPosition(1, holdPoint);
        lineb.SetPosition(1, holdPoint);
    }
    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
    }

}
