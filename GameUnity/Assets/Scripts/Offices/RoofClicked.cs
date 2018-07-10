using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofClicked : MonoBehaviour {

    [SerializeField]
    private float sizeCam;
    [SerializeField]
    Roof roof;

    private void OnMouseDown()
    {
        roof.ClickOnRoof(gameObject, sizeCam);
    }
}
