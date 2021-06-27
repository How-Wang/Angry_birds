using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class level_1_button : MonoBehaviour,IPointerClickHandler {
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(2);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
