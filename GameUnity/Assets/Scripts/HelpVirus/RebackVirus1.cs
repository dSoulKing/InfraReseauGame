using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebackVirus1 : MonoBehaviour {
    
    Roof roof;
    GameObject roofObject;

    private Camera mainCamera;
    private GameController gameController;

    private void Start()
    {
        roofObject = GameObject.Find("Roofs");
        roof = roofObject.GetComponent<Roof>();

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 9.1f;
        mainCamera.transform.position = new Vector3(12, 29f, 9);
        mainCamera.transform.Rotate(90, 0, 0);

        if (VirusManager1.losePointOk)
            gameController.UpdateScore(10);

        GameController.gamePause = false;

        GameController.PlayPauseTime();

        roof.GroundClicked();

        Destroy(transform.parent.gameObject);
    }
}
