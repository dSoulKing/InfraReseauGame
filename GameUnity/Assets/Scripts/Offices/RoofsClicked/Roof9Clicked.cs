﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof9Clicked : MonoBehaviour {

    public Camera mainCamera;
    public GameObject thisRoof;

    public static bool cam9;

    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
        thisRoof.SetActive(true);
        cam9 = true;
    }

    void Update()
    {
        if (cam9 == false)
        {
            thisRoof.SetActive(false);
        }
        else if (cam9 == true)
        {
            thisRoof.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == true)
        {
            mainCamera.orthographicSize = 1.8f;
            mainCamera.transform.position = new Vector3(12.04f, 5.3f, 1.56f);
            //mainCamera.rect = new Rect(2f, 5f, 1, 1);
            cam9 = false;
            RoofsBool.cam = false;
        }
        else if (RoofsBool.cam == false)
        {
            GameObject groundBackObject = GameObject.Find("GroundBack");
            GroundBack groundBack = groundBackObject.GetComponent<GroundBack>();
            groundBack.SetActiveAll();

            mainCamera.orthographicSize = 9.1f;
            mainCamera.transform.position = new Vector3(12, 2.9f, 9);

            RoofsBool.cam = true;

        }
    }
}
