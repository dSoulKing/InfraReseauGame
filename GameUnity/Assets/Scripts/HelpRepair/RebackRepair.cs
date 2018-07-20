using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebackRepair : MonoBehaviour {

    Roof roof;
    GameObject roofObject;

    public GameObject allRepair;

    private Camera mainCamera;
    private GameController gameController;

    private void Start()
    {
        roofObject = GameObject.Find("Roofs");
        roof = roofObject.GetComponent<Roof>();

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 9.1f;
        mainCamera.transform.position = new Vector3(12, 29f, 9);
        mainCamera.transform.Rotate(90, 0, 0);

        GameController.gamePause = false;

        roof.GroundClicked();

        if (RepairManager.losePointOK)
        {
            gameController.UpdateScore(10);
            RepairManager.losePointOK = false;
        }

        Destroy(allRepair);
    }
}
