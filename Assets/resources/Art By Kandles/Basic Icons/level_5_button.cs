using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class level_5_button : MonoBehaviour, IPointerClickHandler
{

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(6);
    }
}
