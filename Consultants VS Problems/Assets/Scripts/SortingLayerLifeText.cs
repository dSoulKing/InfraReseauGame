using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerLifeText : MonoBehaviour {

    Renderer thisRenderer;
    // Use this for initialization
    void Start () {
        thisRenderer = gameObject.GetComponent<Renderer>();
        thisRenderer.sortingOrder = 2;

    }
	
}
