using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickComputerVirus2 : MonoBehaviour {

    private Camera mainCamera;

    public GameObject directLight;

    void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 3.4f;
        mainCamera.transform.position = new Vector3(320.4f, 16.32f, 0);
        mainCamera.transform.Rotate(-90, 0, 0);

        directLight.SetActive(true);

        transform.parent.gameObject.GetComponent<VirusManager2>().virusStart = true;
        GameController.gamePause = true;
    }
}
