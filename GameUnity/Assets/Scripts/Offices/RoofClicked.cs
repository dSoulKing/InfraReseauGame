using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoofClicked : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    private float sizeCam;
    [SerializeField]
    Roof roof;

    public GameObject office;

    public void OnPointerClick(PointerEventData data)
    {
        roof.ClickOnRoof(gameObject, sizeCam);
    }
}
