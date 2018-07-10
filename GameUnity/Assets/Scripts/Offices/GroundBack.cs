using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBack : MonoBehaviour {

    [SerializeField]
    Roof roof;
    
    private void OnMouseDown()
    {
        roof.GroundClicked();
    }
}
