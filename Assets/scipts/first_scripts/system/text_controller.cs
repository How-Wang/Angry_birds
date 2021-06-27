using UnityEngine;
using UnityEngine.UI;

public class text_controller : MonoBehaviour {

    public Text tx;
    //public ball_controller ba;

    private void Update()
    {//to get the output
        tx.text = "remains birds :" + Parameter_script.birds_counts.ToString();
    }

}
