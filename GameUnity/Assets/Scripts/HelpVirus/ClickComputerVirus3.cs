using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickComputerVirus3 : MonoBehaviour {

    private Camera mainCamera;

    void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 3.4f;
        mainCamera.transform.position = new Vector3(320.4f, 31.77f, 0);
        mainCamera.transform.Rotate(-90, 0, 0);

        transform.parent.gameObject.GetComponent<VirusManager3>().virusStart = true;
        GameController.gamePause = true;

        GameController.PlayPauseTime();
    }
}
