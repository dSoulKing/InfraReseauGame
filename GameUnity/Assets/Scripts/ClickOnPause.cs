using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnPause : MonoBehaviour, IPointerClickHandler {

    public GameObject pauseGameObject;

    public void OnPointerClick(PointerEventData eventData)
    {
        pauseGameObject.SetActive(true);
        gameObject.SetActive(false);
        GameController.gamePause = true;
    }
}
