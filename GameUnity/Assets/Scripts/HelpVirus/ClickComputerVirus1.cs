﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickComputerVirus1 : MonoBehaviour {

    private Camera mainCamera;

    public GameObject directLight;

    void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 3.4f;
        mainCamera.transform.position = new Vector3(320.4f, -0.5f, 0);
        mainCamera.transform.Rotate(-90, 0, 0);

        directLight.SetActive(true);

        transform.parent.gameObject.GetComponent<VirusManager1>().virusStart = true;
        GameController.gamePause = true;
    }
}
