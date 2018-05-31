using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TongueMenu : MonoBehaviour, IPointerDownHandler {

    public GameObject image;
    public GameObject flou;

    private Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        animator = image.GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isOpen = !isOpen;
        Debug.Log(isOpen);
        animator.SetBool("isOpen", isOpen);
        GameController.gamePause = !GameController.gamePause;

        if (isOpen)
            flou.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        else
            flou.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }
}
