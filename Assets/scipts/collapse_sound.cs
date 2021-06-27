using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collapse_sound : MonoBehaviour {
    int i = 1;
    float rotate_angle;
    float x,y;
    float x_diff,y_diff;
    public AudioClip collapse;
    // Use this for initialization
    void Start () {
        x = transform.localPosition.x;
        y = transform.localPosition.y;
    }
	
	// Update is called once per frame
	void Update () {
        rotate_angle = CheckAngle(transform.localEulerAngles.z);
        x_diff = CheckPosition(transform.localPosition.x - x);
        y_diff = CheckPosition(transform.localPosition.y - y);
        if (rotate_angle > 20f || rotate_angle < -20f || x_diff > 0.5f || y_diff > 0.5f)
        {
            if(i != 0)
            {
                AudioSource.PlayClipAtPoint(collapse, transform.position);
                i = 0;
            }
        }
	}

    float CheckAngle(float euler)
    {
        float angle = euler - 180;
        if(angle > 0) { return angle - 180; }
        return angle + 180;
    }

    float CheckPosition(float value)
    {
        if(value > 0) { return value; }
        return -value;
    }
}
