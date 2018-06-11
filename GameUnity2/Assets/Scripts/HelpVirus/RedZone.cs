using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour {

    public SpriteRenderer backgroundComputer;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("virusEnter");
        backgroundComputer.color = new Color(255,58,58);
    }
}
