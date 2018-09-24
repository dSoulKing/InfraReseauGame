using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontLike : MonoBehaviour {

    public GameObject parent;

    private void OnMouseDown()
    {
        Destroy(parent);
    }
}
