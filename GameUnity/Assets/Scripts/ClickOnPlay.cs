using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnPlay : MonoBehaviour, IPointerClickHandler
{

    public GameObject pauseButton;
    public GameObject pauseGameobject;

    public void OnPointerClick(PointerEventData eventData)
    {
        pauseButton.SetActive(true);
        pauseGameobject.SetActive(false);
        GameController.gamePause = false;
        Debug.Log("click");
    }
}
