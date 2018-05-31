using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    

    private void Start()
    {
    }

    private void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("circle recive");

    }
}
