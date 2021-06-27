using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void producer()
    {
       // SceneManager.LoadScene(7);
        if (ball_controller.istouch)
        {
            SceneManager.LoadScene(7);
        }
        
    }
    public void special()
    {
        
    }
}
