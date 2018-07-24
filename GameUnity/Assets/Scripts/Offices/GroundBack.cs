using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundBack : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    Roof roof;

    public void OnPointerClick(PointerEventData data)
    {
        roof.GroundClicked();
    }
}
