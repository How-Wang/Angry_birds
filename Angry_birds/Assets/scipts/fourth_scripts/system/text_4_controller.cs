using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_4_controller : MonoBehaviour
{
    public Text tx;
    //public ball_controller ba;

    private void Update()
    {//to get the output
        tx.text = "remains birds :" + Parameter_4_script.birds_counts.ToString();
    }

}
